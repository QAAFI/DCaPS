using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerCanopyPhotosynthesis;

namespace LayerCanopyPhotosynthesis
{
    public class SunlitCanopy : SunlitShadedCanopy
    {
        public SunlitCanopy() { }

        public SunlitCanopy(int _nLayers) : base(_nLayers) { }
        //---------------------------------------------------------------------------------------------------------
        public override void calcLAI(LeafCanopy canopy, SunlitShadedCanopy counterpart)
        {
            LAIS = new double[canopy.nLayers];
            for (int i = 0; i < canopy.nLayers; i++)
            {

                LAIS[i] = ((i == 0 ? 1 : Math.Exp(-canopy.beamExtCoeffs[i] * canopy.LAIAccums[i - 1])) -
                    Math.Exp(-canopy.beamExtCoeffs[i] * canopy.LAIAccums[i])) * 1 / canopy.beamExtCoeffs[i];
            }
        }
        //---------------------------------------------------------------------------------------------------------
        public override void calcIncidentRadiation(EnvironmentModel EM, LeafCanopy canopy, SunlitShadedCanopy shaded)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                incidentIrradiance[i] = EM.directRadiationPAR * canopy.propnInterceptedRadns[i] / LAIS[i] * LAIS[i] +
                     EM.diffuseRadiationPAR * canopy.propnInterceptedRadns[i] / (LAIS[i] + shaded.LAIS[i]) * LAIS[i];
            }
        }
        //---------------------------------------------------------------------------------------------------------

        public override void calcAbsorbedRadiation(EnvironmentModel EM, LeafCanopy canopy, SunlitShadedCanopy shaded)
        {
            calcAbsorbedRadiationDirect(EM, canopy);
            calcAbsorbedRadiationDiffuse(EM, canopy);
            calcAbsorbedRadiationScattered(EM, canopy);

            for (int i = 0; i < _nLayers; i++)
            {
                absorbedIrradiance[i] = absorbedRadiationDirect[i] + absorbedRadiationDiffuse[i] + absorbedRadiationScattered[i];
            }
        }
        //---------------------------------------------------------------------------------------------------------
        void calcAbsorbedRadiationDirect(EnvironmentModel EM, LeafCanopy canopy)
        {
            for (int i = 0; i < _nLayers; i++)
            {

                absorbedRadiationDirect[i] = (1 - canopy.leafScatteringCoeffs[i]) * EM.directRadiationPAR *
                    ((i == 0 ? 1 : Math.Exp(-canopy.beamExtCoeffs[i] * canopy.LAIAccums[i - 1])) -
                    Math.Exp(-canopy.beamExtCoeffs[i] * canopy.LAIAccums[i]));
            }
        }
        //---------------------------------------------------------------------------------------------------------
        void calcAbsorbedRadiationDiffuse(EnvironmentModel EM, LeafCanopy canopy)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                absorbedRadiationDiffuse[i] = (1 - canopy.diffuseReflectionCoeffs[i]) * EM.diffuseRadiationPAR *
                    ((i == 0 ? 1 : Math.Exp(-(canopy.diffuseScatteredDiffuses[i] + canopy.beamExtCoeffs[i]) * canopy.LAIAccums[i - 1])) -
                    Math.Exp(-(canopy.diffuseScatteredDiffuses[i] + canopy.beamExtCoeffs[i]) * canopy.LAIAccums[i])) * (canopy.diffuseScatteredDiffuses[i] /
                    (canopy.diffuseScatteredDiffuses[i] + canopy.beamExtCoeffs[i]));
            }
        }
        //---------------------------------------------------------------------------------------------------------
        public override void calcMaxRates(LeafCanopy canopy, SunlitShadedCanopy counterpart, PhotosynthesisModel PM)
        {
            calcRubiscoActivity25(canopy, counterpart, PM);
            calcElectronTransportRate25(canopy, counterpart, PM);
            calcRdActivity25(canopy, counterpart, PM);
            calcPRate25(canopy, counterpart, PM);

        }
        //---------------------------------------------------------------------------------------------------------
        void calcAbsorbedRadiationScattered(EnvironmentModel EM, LeafCanopy canopy)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                if (canopy.beamScatteredBeams[i] + canopy.beamExtCoeffs[i] == 0)
                {
                    absorbedRadiationScattered[i] = 0;
                }
                else
                {
                    absorbedRadiationScattered[i] = EM.directRadiationPAR * (((1 - canopy.beamReflectionCoeffs[i]) *
                         ((i == 0 ? 1 : Math.Exp(-(canopy.beamExtCoeffs[i] + canopy.beamScatteredBeams[i]) * canopy.LAIAccums[i - 1])) -
                         Math.Exp(-(canopy.beamExtCoeffs[i] + canopy.beamScatteredBeams[i]) * canopy.LAIAccums[i])) *
                         (canopy.beamScatteredBeams[i] / (canopy.beamScatteredBeams[i] + canopy.beamExtCoeffs[i]))) -
                         ((1 - canopy.leafScatteringCoeffs[i]) *
                          ((i == 0 ? 1 : Math.Exp(-2 * canopy.beamExtCoeffs[i] * canopy.LAIAccums[i - 1])) -
                          Math.Exp(-2 * canopy.beamExtCoeffs[i] * canopy.LAIAccums[i])) / 2));
                }
            }
        }
        //----------------------------------------------------------------------
        public void calcRubiscoActivity25(LeafCanopy canopy, SunlitShadedCanopy shaded, PhotosynthesisModel PM)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                VcMax25[i] = canopy.LAI * canopy.CPath.psiVc * (canopy.leafNTopCanopy - canopy.CPath.structuralN) *
                   ((i == 0 ? 1 : Math.Exp(-(canopy.beamExtCoeffs[i] + canopy.NAllocationCoeff / canopy.LAI) * canopy.LAIAccums[i - 1])) -
                   Math.Exp(-(canopy.beamExtCoeffs[i] + canopy.NAllocationCoeff / canopy.LAI) * canopy.LAIAccums[i])) /
                   (canopy.NAllocationCoeff + canopy.beamExtCoeffs[i] * canopy.LAI);
            }
        }
        //----------------------------------------------------------------------
        public void calcRdActivity25(LeafCanopy canopy, SunlitShadedCanopy shaded, PhotosynthesisModel PM)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                Rd25[i] = canopy.LAI * canopy.CPath.psiRd * (canopy.leafNTopCanopy - canopy.CPath.structuralN) *
                    ((i == 0 ? 1 : Math.Exp(-(canopy.beamExtCoeffs[i] + canopy.NAllocationCoeff / canopy.LAI) * canopy.LAIAccums[i - 1])) -
                    Math.Exp(-(canopy.beamExtCoeffs[i] + canopy.NAllocationCoeff / canopy.LAI) * canopy.LAIAccums[i])) /
                    (canopy.NAllocationCoeff + canopy.beamExtCoeffs[i] * canopy.LAI);
            }
        }
        //---------------------------------------------------------------------------------------------------------
        public void calcElectronTransportRate25(LeafCanopy canopy, SunlitShadedCanopy shaded, PhotosynthesisModel PM)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                JMax25[i] = canopy.LAI * canopy.CPath.psiJ * (canopy.leafNTopCanopy - canopy.CPath.structuralN) *
                    ((i == 0 ? 1 : Math.Exp(-(canopy.beamExtCoeffs[i] + canopy.NAllocationCoeff / canopy.LAI) * canopy.LAIAccums[i - 1])) -
                    Math.Exp(-(canopy.beamExtCoeffs[i] + canopy.NAllocationCoeff / canopy.LAI) * canopy.LAIAccums[i])) /
                    (canopy.NAllocationCoeff + canopy.beamExtCoeffs[i] * canopy.LAI);
            }
        }

        //---------------------------------------------------------------------------------------------------------
        public void calcPRate25(LeafCanopy canopy, SunlitShadedCanopy shaded, PhotosynthesisModel PM)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                VpMax25[i] = canopy.LAI * canopy.CPath.psiVp * (canopy.leafNTopCanopy - canopy.CPath.structuralN) *
                    ((i == 0 ? 1 : Math.Exp(-(canopy.beamExtCoeffs[i] + canopy.NAllocationCoeff / canopy.LAI) * canopy.LAIAccums[i - 1])) -
                    Math.Exp(-(canopy.beamExtCoeffs[i] + canopy.NAllocationCoeff / canopy.LAI) * canopy.LAIAccums[i])) /
                    (canopy.NAllocationCoeff + canopy.beamExtCoeffs[i] * canopy.LAI);
            }
        }
    }
}
