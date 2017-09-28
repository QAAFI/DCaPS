using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerCanopyPhotosynthesis
{
    //[System.Xml.Serialization.XmlInclude(typeof(PathwayParametersC3))]
    //[System.Xml.Serialization.XmlInclude(typeof(PathwayParametersC4))]
    public class PathwayParameters
    {
        public delegate void Notifier();
        //[System.Xml.Serialization.XmlIgnore]
        public Notifier notifyChanged;

        public PathwayParameters()
        {
        }
        
        [ModelPar("GUUtv", "Base leaf nitrogen content at or below which PS = 0", "N", "b", "mmol N/m2", "", "m2 leaf")]
        public double structuralN { get; set; }

        [ModelPar("6awks", "Ratio of SLNo to SLNav", "SLN", "ratio_top", "")]
        public double SLNRatioTop { get; set; }

        [ModelPar("cNPBJ", "Average SLN over the canopy", "SLN", "av", "g N/m2", "", "m2 leaf")]
        public double SLNAv { get; set; }

        [ModelPar("36Sr7", "Ratio of Ci to Ca for the sunlit and shade leaf fraction", "Ci/Ca", "", "")]
        public double CiCaRatio { get; set; }

        [ModelPar("WE2QN", "Intercept of linear relationship of Ci/Ca ratio to VPD", "b", "", "")]
        public double CiCaRatioIntercept { get; set; }

        [ModelPar("jC0xB", "Slope of linear relationship of Ci/Ca ratio to VPD", "a", "", "1/kPa")]
        public double CiCaRatioSlope { get; set; }

        [ModelPar("uk6BV", "Fraction of electrons at PSI that follow cyclic transport around PSI", "f", "cyc", "")]
        public double fcyc { get; set; }

        [ModelPar("3WXTb", "Slope of the linear relationship between Rd_l and N(L) at 25°C with intercept = 0", "psi", "Rd", "mmol/mol N/s")]
        public double psiRd { get; set; }

        [ModelPar("l2mwD", "Slope of the linear relationship between Vcmax_l and N(L) at 25°C with intercept = 0", "psi", "Vc", "mmol/mol N/s")]
        public double psiVc { get; set; }

        [ModelPar("I0uh7", "Slope of the linear relationship between J2max_l and N(L) at 25°C with intercept = 0", "psi", "J2", "mmol/mol N/s")]
        public double psiJ2 { get; set; }

        [ModelPar("JwwUu", "Slope of the linear relationship between Jmax_l and N(L) at 25°C with intercept = 0", "psi", "J", "mmol/mol N/s")]
        public double psiJ { get; set; }

        [ModelPar("pYisy", "Slope of the linear relationship between Vpmax_l and N(L) at 25°C with interception = 0", "psi", "Vp", "mmol/mol N/s", "","", true)]
        public double psiVp { get; set; }

        [ModelPar("tuksS", "Fraction of electron transport partitioned to mesophyll chlorplast", "x", "", "", "","", true)]
        public double x { get; set; }

        #region KineticParams

        // Kc μbar	
        [ModelPar("Kc_P25", "", "", "", "")]
        public double Kc_P25 { get; set; }
        [ModelPar("Kc_c", "", "K", "c", "μbar")]
        public double Kc_c { get; set; }
        [ModelPar("Kc_b", "", "", "", "")]
        public double Kc_b { get; set; }

        // Kc μbar	-- C4
        [ModelPar("Kp_P25", "", "", "", "")]
        public double Kp_P25 { get; set; }
        [ModelPar("Kp_c", "", "K", "p", "μbar")]
        public double Kp_c { get; set; }
        [ModelPar("Kp_b", "", "", "", "")]
        public double Kp_b { get; set; } 

        //Ko μbar	
        [ModelPar("Ko_P25", "", "", "", "")]
        public double Ko_P25 { get; set; }
        [ModelPar("Ko_c", "", "K", "o", "μbar")]
        public double Ko_c { get; set; }
        [ModelPar("Ko_b", "", "", "", "")]
        public double Ko_b { get; set; }

        //Vcmax/Vomax	-	
        [ModelPar("VcMax.VoMax_P25", "", "", "", "")]
        public double VcMax_VoMax_P25 { get; set; }
        [ModelPar("VcMax.VoMax_c", "", "Vc_max/Vo_max", "", "")]
        public double VcMax_VoMax_c { get; set; }
        [ModelPar("VcMax.VoMax_b", "", "", "", "")]
        public double VcMax_VoMax_b { get; set; }
        //Vomax/Vcmax	-	
        //   -	-	-
        //Vcmax μmol/m2/s*	
        [ModelPar("VcMax_c", "", "V", "c_max", "μmol/m2/s")]
        public double VcMax_c { get; set; }
        [ModelPar("VcMax_b", "", "", "", "")]
        public double VcMax_b { get; set; }

        //Vpmax μmol/m2/s*	
        [ModelPar("VpMax_c", "", "V", "p_max", "μmol/m2/s", "","", true)]
        public double VpMax_c { get; set; }
        [ModelPar("VpMax_b", "", "", "", "", "","",true)]
        public double VpMax_b { get; set; }

        //Rd μmol/m2/s*	
        [ModelPar("Rd_c", "", "R", "d", "μmol/m2/s")]
        public double Rd_c { get; set; }
        [ModelPar("Rd_b", "", "", "", "")]
        public double Rd_b { get; set; }

        //Jmax(Barley, Farquhar 1980)    μmol/m2/s*	
        [ModelPar("JMax_TOpt", "", "", "", "")]
        public double JMax_TOpt { get; set; }
        [ModelPar("JMax_Omega", "", "J", "max", "μmol/m2/s")]
        public double JMax_Omega { get; set; } 

        //gm(Arabidopsis, Bernacchi 2002)    μmol/m2/s/bar	
        [ModelPar("gm_P25", "", "", "", "")]
        public double gm_P25 { get; set; } 
        [ModelPar("gm_TOpt", "", "", "", "")]
        public double gm_TOpt { get; set; } 
        [ModelPar("gm_Omega", "", "g", "m", "mol/m2/s/bar")]
        public double gm_Omega { get; set; } 

        [ModelPar("THGeL", "Quantum efficiency of PSII e- folow on PSII-absorbed light basis at the strictly limiting light level", "ɸ", "2(LL)", "")]
        public double F2 { get; set; }
        [ModelPar("6RyTa", "Quantum efficiency of PSI e- flow at the strictly limiting light level", "ɸ", "1(LL)", "")]
        public double F1 { get; set; }
        #endregion
    }
}
