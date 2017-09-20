using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerCanopyPhotosynthesis;

namespace LayerCanopyPhotosynthesis
{
    public class ShadedCanopy : SunlitShadedCanopy
    {
        public ShadedCanopy(int _nLayers) : base(_nLayers) { }
        public ShadedCanopy() { }
        //---------------------------------------------------------------------------------------------------------
        public override void calcLAI(LeafCanopy canopy, SunlitShadedCanopy sunlit)
        {
            LAIS = new double[canopy.nLayers];

            for (int i = 0; i < canopy.nLayers; i++)
            {
                LAIS[i] = canopy.LAIs[i] - sunlit.LAIS[i];
            }
        }
        //----------------------------------------------------------------------
        public override void calcIncidentRadiation(EnvironmentModel EM, LeafCanopy canopy, SunlitShadedCanopy sunlit)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                incidentIrradiance[i] = EM.diffuseRadiationPAR * canopy.propnInterceptedRadns[i] / (sunlit.LAIS[i] + LAIS[i]) *
                    LAIS[i] + 0.15 * (sunlit.incidentIrradiance[i] * sunlit.LAIS[i]) / (LAIS[i] + (i < (_nLayers - 1) ? LAIS[i + 1] : 0)) * LAIS[i]; //+ *((E70*E44)/(E45+F45)
            }
        }
        //----------------------------------------------------------------------
        public override void calcAbsorbedRadiation(EnvironmentModel EM, LeafCanopy canopy, SunlitShadedCanopy sunlit)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                absorbedIrradiance[i] = canopy.absorbedRadiation[i] - sunlit.absorbedIrradiance[i];
            }
        }
        //----------------------------------------------------------------------
        public void calcRubiscoActivity25(LeafCanopy canopy, SunlitShadedCanopy sunlit, PhotosynthesisModel PM)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                VcMax25[i] = canopy.VcMax25[i] - sunlit.VcMax25[i];
            }
        }
        //----------------------------------------------------------------------
        public void calcRdActivity25(LeafCanopy canopy, SunlitShadedCanopy sunlit, PhotosynthesisModel PM)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                Rd25[i] = canopy.Rd25[i] - sunlit.Rd25[i];
            }
        }
        //---------------------------------------------------------------------------------------------------------
        public void calcElectronTransportRate25(LeafCanopy canopy, SunlitShadedCanopy sunlit, PhotosynthesisModel PM)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                J2Max25[i] = canopy.J2Max25[i] - sunlit.J2Max25[i];
                JMax25[i] = canopy.JMax25[i] - sunlit.JMax25[i];

            }
        }

        //---------------------------------------------------------------------------------------------------------
        public void calcPRate25(LeafCanopy canopy, SunlitShadedCanopy sunlit, PhotosynthesisModel PM)
        {
            for (int i = 0; i < _nLayers; i++)
            {
                VpMax25[i] = canopy.VpMax25[i] - sunlit.VpMax25[i];
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
    }
}

