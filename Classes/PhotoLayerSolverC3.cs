using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DEOptimiser;

namespace LayerCanopyPhotosynthesis
{
    public class PhotoLayerSolverC3 : PhotoLayerSolver
    {
       
        //--------------------------------------------------------------
        public PhotoLayerSolverC3(PhotosynthesisModel PM, int layer) :
            base(PM, layer)
        
        {

        }
        
        //--------------------------------------------------------------

        public override double calcPhotosynthesis(PhotosynthesisModel PM, SunlitShadedCanopy s, int layer, double _Cc)
        {
            LeafCanopy canopy = PM.canopy;

            s.calcPhotosynthesis(PM, layer);

            s.Oi[layer] = canopy.oxygenPartialPressure;

            s.Oc[layer] = s.Oi[layer];

            s.r_[layer] = s.g_[layer] * s.Oc[layer];

            s.Ac[layer] = calcAc(canopy, s, layer);
            s.Aj[layer] = calcAj(canopy, s, layer);

            if (s.Ac[layer] < 0 || double.IsNaN(s.Ac[layer]))
            {
                s.Ac[layer] = 0;
            }

            if (s.Aj[layer] < 0 || double.IsNaN(s.Aj[layer]))
            {
                s.Aj[layer] = 0;
            }

            s.A[layer] = Math.Min(s.Aj[layer], s.Ac[layer]);


           
            if (PM.conductanceModel == PhotosynthesisModel.ConductanceModel.DETAILED)
            {
                // s.Ci[layer] = canopy.Ca - s.A[layer] / s.gb_CO2[layer] - s.A[layer] / s.gs_CO2[layer];
            }
            else
            {
                s.Ci[layer] = canopy.CPath.CiCaRatio * canopy.Ca;
            }

            s.Ccac[layer] = s.Ci[layer] - s.Ac[layer] / s.gm_CO2T[layer];

            s.Ccaj[layer] = s.Ci[layer] - s.Aj[layer] / s.gm_CO2T[layer];

            if (s.Ccac[layer] < 0 || double.IsNaN(s.Ccac[layer]))
            {
                s.Ccac[layer] = 0;
            }
            if (s.Ccaj[layer] < 0 || double.IsNaN(s.Ccaj[layer]))
            {
                s.Ccaj[layer] = 0;
            }

            if (s.Ac[layer] < s.Aj[layer])
            {
                s.Cc[layer] = s.Ac[layer];
            }
            else
            {
                s.Cc[layer] = s.Aj[layer];
            }

            s.Cc[layer] = s.Ci[layer] - s.A[layer] / s.gm_CO2T[layer];
            if (s.Cc[layer] < 0 || double.IsNaN(s.Cc[layer]))
            {
                s.Cc[layer] = 0;
            }
           

            s.CiCaRatio[layer] = s.Ci[layer] / canopy.Ca;

            return Math.Pow(s.Cc[layer] - _Cc, 2);
        }
        //---------------------------------------------------------------------------------------------------------
        public double calcAc(LeafCanopy canopy, SunlitShadedCanopy s, int layer)
        {
            double x1 = s.VcMaxT[layer];
            double x2 = s.Kc[layer] * (1 + canopy.oxygenPartialPressure / s.Ko[layer]);


            double a, b, c, d;

            a = -1 * canopy.CPath.CiCaRatio * canopy.Ca * s.gm_CO2T[layer] - s.gm_CO2T[layer] * x2 + s.RdT[layer] - x1; //Eq	(A56)
            b = -1 * canopy.CPath.CiCaRatio * canopy.Ca * s.gm_CO2T[layer] * s.RdT[layer] + canopy.CPath.CiCaRatio * canopy.Ca * s.gm_CO2T[layer] * x1 -
                s.gm_CO2T[layer] * s.RdT[layer] * x2 - s.gm_CO2T[layer] * s.r_[layer] * x1; // Eq	(A57)
            c = canopy.CPath.CiCaRatio * canopy.Ca * s.gm_CO2T[layer] + s.gm_CO2T[layer] * x2 - s.RdT[layer] + x1; // Eq (A58)
            d = 1;


            return (-1 * Math.Pow((Math.Pow(a, 2) - 4 * b), 0.5) + c) / (2 * d); //Eq (A55)
        }

        public override double calcAc(double Cc, LeafCanopy canopy, SunlitShadedCanopy s, int layer)
        {
            return (Cc - s.r_[layer]) * s.VcMaxT[layer] / (Cc + s.Kc[layer] * (1 + canopy.oxygenPartialPressure / s.Ko[layer])) - s.RdT[layer];
        }
        //---------------------------------------------------------------------------------------------------------
        public double calcAj(LeafCanopy canopy, SunlitShadedCanopy s, int layer)
        {
            double x1 = s.J[layer] / 4;
            double x2 = 2 * s.r_[layer];

            double a, b, c, d;

            a = -1 * canopy.CPath.CiCaRatio * canopy.Ca * s.gm_CO2T[layer] - s.gm_CO2T[layer] * x2 + s.RdT[layer] - x1; //Eq	(A56)
            b = -1 * canopy.CPath.CiCaRatio * canopy.Ca * s.gm_CO2T[layer] * s.RdT[layer] + canopy.CPath.CiCaRatio * canopy.Ca * s.gm_CO2T[layer] * x1 -
                s.gm_CO2T[layer] * s.RdT[layer] * x2 - s.gm_CO2T[layer] * s.r_[layer] * x1; // Eq	(A57)
            c = canopy.CPath.CiCaRatio * canopy.Ca * s.gm_CO2T[layer] + s.gm_CO2T[layer] * x2 - s.RdT[layer] + x1; // Eq (A58)
            d = 1;


            return (-1 * Math.Pow((Math.Pow(a, 2) - 4 * b), 0.5) + c) / (2 * d); //Eq (A55)
        }
        //---------------------------------------------------------------------------------------------------------
        public override double calcAj(double Cc, LeafCanopy canopy, SunlitShadedCanopy s, int layer)
        {
            return (Cc - s.r_[layer]) * s.J[layer] / (4 * (Cc + 2 * s.r_[layer])) - s.RdT[layer];
        }
    }
}
