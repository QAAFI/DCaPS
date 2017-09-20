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
        
        protected double _structuralN = 25;

        [ModelPar("GUUtv", "Base leaf nitrogen content at or below which PS = 0", "N", "b", "mmol N/m2", "", "m2 leaf")]
        public double structuralN
        {
            get { return _structuralN; }
            set { _structuralN = value; }
        }

        protected double _SLNRatioTop = 1.32;
        [ModelPar("6awks", "Ratio of SLNo to SLNav", "SLN", "ratio_top", "")]
        public double SLNRatioTop
        {
            get { return _SLNRatioTop; }
            set { _SLNRatioTop = value; }
        }

        protected double _SLNAv = 1.45;
        [ModelPar("cNPBJ", "Average SLN over the canopy", "SLN", "av", "g N/m2", "", "m2 leaf")]
        public double SLNAv
        {
            get { return _SLNAv; }
            set { _SLNAv = value; }
        }


        //Parmas based on C3
        protected double _CiCaRatio = 0.7;
        [ModelPar("36Sr7", "Ratio of Ci to Ca for the sunlit and shade leaf fraction", "Ci/Ca", "", "")]
        public double CiCaRatio
        {
            get { return _CiCaRatio; }
            set { _CiCaRatio = value; }
        }

        protected double _CiCaRatioIntercept = 0.90;
        [ModelPar("WE2QN", "Intercept of linear relationship of Ci/Ca ratio to VPD", "b", "", "")]
        public double CiCaRatioIntercept
        {
            get { return _CiCaRatioIntercept; }
            set { _CiCaRatioIntercept = value; }
        }

        protected double _CiCaRatioSlope = -0.12;
        [ModelPar("jC0xB", "Slope of linear relationship of Ci/Ca ratio to VPD", "a", "", "1/kPa")]
        public double CiCaRatioSlope
        {
            get { return _CiCaRatioSlope; }
            set { _CiCaRatioSlope = value; }
        }

        protected double _fcyc = 0;
        [ModelPar("uk6BV", "Fraction of electrons at PSI that follow cyclic transport around PSI", "f", "cyc", "")]
        public double fcyc
        {
            get { return _fcyc; }
            set { _fcyc = value; }
        }

        protected double _psiRd = 0.0175;
        [ModelPar("3WXTb", "Slope of the linear relationship between Rd_l and N(L) at 25°C with intercept = 0", "psi", "Rd", "mmol/mol N/s")]
        public double psiRd
        {
            get { return _psiRd; }
            set { _psiRd = value; }
        }

        protected double _psiVc = 1.75;
        [ModelPar("l2mwD", "Slope of the linear relationship between Vcmax_l and N(L) at 25°C with intercept = 0", "psi", "Vc", "mmol/mol N/s")]
        public double psiVc
        {
            get { return _psiVc; }
            set { _psiVc = value; }
        }

        protected double _psiJ2 = 2.43;
        [ModelPar("I0uh7", "Slope of the linear relationship between J2max_l and N(L) at 25°C with intercept = 0", "psi", "J2", "mmol/mol N/s")]
        public double psiJ2
        {
            get { return _psiJ2; }
            set { _psiJ2 = value; }
        }

        protected double _psiJ = 3.20;
        [ModelPar("JwwUu", "Slope of the linear relationship between Jmax_l and N(L) at 25°C with intercept = 0", "psi", "J", "mmol/mol N/s")]
        public double psiJ
        {
            get { return _psiJ; }
            set { _psiJ = value; }
        }

        protected double _psiVp = 3.39;
        [ModelPar("pYisy", "Slope of the linear relationship between Vpmax_l and N(L) at 25°C with interception = 0", "psi", "Vp", "mmol/mol N/s", "","", true)]
        public double psiVp
        {
            get { return _psiVp; }
            set { _psiVp = value; }
        }

        protected double _x = 0.4;
        [ModelPar("tuksS", "Fraction of electron transport partitioned to mesophyll chlorplast", "x", "", "", "","", true)]
        public double x
        {
            get { return _x; }
            set { _x = value; }
        }



        #region KineticParams

        // Kc μbar	
        [ModelPar("Kc_P25", "", "", "", "")]
        public double Kc_P25 { get; set; } = 272.38;
        [ModelPar("Kc_c", "", "K", "c", "μbar")]
        public double Kc_c { get; set; } = 32.689;
        [ModelPar("Kc_b", "", "", "", "")]
        public double Kc_b { get; set; } = 9741.400;

        // Kc μbar	-- C4
        [ModelPar("Kp_P25", "", "", "", "")]
        public double Kp_P25 { get; set; } = 139;
        [ModelPar("Kp_c", "", "K", "p", "μbar")]
        public double Kp_c { get; set; } = 14.644;
        [ModelPar("Kp_b", "", "", "", "")]
        public double Kp_b { get; set; } = 4366.129;

        //Ko μbar	
        [ModelPar("Ko_P25", "", "", "", "")]
        public double Ko_P25 { get; set; } = 165820;
        [ModelPar("Ko_c", "", "K", "o", "μbar")]
        public double Ko_c { get; set; } = 9.574;
        [ModelPar("Ko_b", "", "", "", "")]
        public double Ko_b { get; set; } = 2853.019;

        //Vcmax/Vomax	-	
        [ModelPar("VcMax.VoMax_P25", "", "", "", "")]
        public double VcMax_VoMax_P25 { get; set; } = 4.580;
        [ModelPar("VcMax.VoMax_c", "", "Vc_max/Vo_max", "", "")]
        public double VcMax_VoMax_c { get; set; } = 13.241;
        [ModelPar("VcMax.VoMax_b", "", "", "", "")]
        public double VcMax_VoMax_b { get; set; } = 3945.722;
        //Vomax/Vcmax	-	
        //   -	-	-
        //Vcmax μmol/m2/s*	
        [ModelPar("VcMax_c", "", "V", "c_max", "μmol/m2/s")]
        public double VcMax_c { get; set; } = 26.355;
        [ModelPar("VcMax_b", "", "", "", "")]
        public double VcMax_b { get; set; } = 7857.830;

        //Vpmax μmol/m2/s*	
        [ModelPar("VpMax_c", "", "V", "p_max", "μmol/m2/s", "","", true)]
        public double VpMax_c { get; set; } = 26.355;
        [ModelPar("VpMax_b", "", "", "", "", "","",true)]
        public double VpMax_b { get; set; } = 7857.830;

        //Rd μmol/m2/s*	
        [ModelPar("Rd_c", "", "R", "d", "μmol/m2/s")]
        public double Rd_c { get; set; } = 18.715;
        [ModelPar("Rd_b", "", "", "", "")]
        public double Rd_b { get; set; } = 5579.745;

        //Jmax(Barley, Farquhar 1980)    μmol/m2/s*	
        [ModelPar("JMax_TOpt", "", "", "", "")]
        public double JMax_TOpt { get; set; } = 28.796;
        [ModelPar("JMax_Omega", "", "J", "max", "μmol/m2/s")]
        public double JMax_Omega { get; set; } = 15.536;

        //gm(Arabidopsis, Bernacchi 2002)    μmol/m2/s/bar	
        [ModelPar("gm_P25", "", "", "", "")]
        public double gm_P25 { get; set; } = 0.55;
        [ModelPar("gm_TOpt", "", "", "", "")]
        public double gm_TOpt { get; set; } = 34.309;
        [ModelPar("gm_Omega", "", "g", "m", "mol/m2/s/bar")]
        public double gm_Omega { get; set; } = 20.791;

        // protected double _J2_Ea = 26900;
        // [ModelPar("iYz3f", "", "J2.Ea", "", "kJ mol-1")]
        // public double J2_Ea
        // {
        //     get { return _J2_Ea; }
        //     set
        //     {
        //         _J2_Ea = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _J2_S = 650;
        // [ModelPar("PrCtL", "", "J2.S", "", "J K-1 mol-1")]
        // public double J2_S
        // {
        //     get { return _J2_S; }
        //     set
        //     {
        //         _J2_S = value;
        //         //notifyChanged(); 
        //     }
        // }
        // protected double _J2_D = 200000;
        // [ModelPar("v5Qfa", "", "J2.D", "", "J mol-1")]
        // public double J2_D
        // {
        //     get { return _J2_D; }
        //     set
        //     {
        //         _J2_D = value;
        //         //notifyChanged(); 
        //     }
        // }

        // protected double _J_Ea = 26900;
        // [ModelPar("c5Agl", "", "J.Ea", "", "kJ mol-1")]
        // public double J_Ea
        // {
        //     get { return _J_Ea; }
        //     set
        //     {
        //         _J_Ea = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _J_S = 650;
        // [ModelPar("pmsEq", "", "J2.S", "", "J K-1 mol-1")]
        // public double J_S
        // {
        //     get { return _J_S; }
        //     set
        //     {
        //         _J_S = value;
        //         //notifyChanged();
        //     }
        // }
        // protected double _J_D = 200000;
        // [ModelPar("l9K0J", "", "J2.D", "", "J mol-1")]
        // public double J_D
        // {
        //     get { return _J_D; }
        //     set
        //     {
        //         _J_D = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _Vc_Ea = 65330;
        // [ModelPar("mshP8", "", "Vc.Ea", "", "kJ mol-1")]
        // public double Vc_Ea
        // {
        //     get { return _Vc_Ea; }
        //     set
        //     {
        //         _Vc_Ea = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _Kc_25 = 270;
        // [ModelPar("ZqMUg", "", "Kc.25", "", "μbar")]
        // public double Kc_25
        // {
        //     get { return _Kc_25; }
        //     set
        //     {
        //         _Kc_25 = value;
        //         //notifyChanged();
        //     }
        // }
        // protected double _Kc_Ea = 80990;
        // [ModelPar("DpzNv", "", "Kmc.Ea", "", "kJ mol-1")]
        // public double Kc_Ea
        // {
        //     get { return _Kc_Ea; }
        //     set
        //     {
        //         _Kc_Ea = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _Ko_25 = 165000;
        // [ModelPar("bwZmR", "", "Kmo.25", "", "μbar")]
        // public double Ko_25
        // {
        //     get { return _Ko_25; }
        //     set
        //     {
        //         _Ko_25 = value;
        //         //notifyChanged();
        //     }
        // }
        // protected double _Ko_Ea = 23720;
        // [ModelPar("zeDFl", "", "Kmo.Ea", "", "kJ mol-1")]
        // public double Ko_Ea
        // {
        //     get { return _Ko_Ea; }
        //     set
        //     {
        //         _Ko_Ea = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _Rd_Ea = 46390;
        // [ModelPar("a59q8", "", "Rd.Ea", "", "kJ mol-1")]
        // public double Rd_Ea
        // {
        //     get { return _Rd_Ea; }
        //     set
        //     {
        //         _Rd_Ea = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _gm_CO2_25 = 0.4;
        // [ModelPar("YCJYl", "Mesophyll conductance at 25°C", "g", "m_CO2,25", "mol/m2/s", "", "m2 leaf")]
        // public double gm_CO2_25
        // {
        //     get { return _gm_CO2_25; }
        //     set
        //     {
        //         _gm_CO2_25 = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _gm_CO2_Ea = 0;
        // [ModelPar("vI6em", "", "gm.Ea", "", "kJ mol-1")]
        // public double gm_CO2_Ea
        // {
        //     get { return _gm_CO2_Ea; }
        //     set
        //     {
        //         _gm_CO2_Ea = value;
        //         //notifyChanged();
        //     }
        // }
        // protected double _gm_CO2_S = 0;
        // [ModelPar("IfoQF", "", "gm.S", "", "J K-1 mol-1")]
        // public double gm_CO2_S
        // {
        //     get { return _gm_CO2_S; }
        //     set
        //     {
        //         _gm_CO2_S = value;
        //         // notifyChanged();
        //     }
        // }
        // protected double _gm_CO2_D = 0;
        // [ModelPar("NOyMH", "", "gm.D", "", "J mol-1")]
        // public double gm_CO2_D
        // {
        //     get { return _gm_CO2_D; }
        //     set
        //     {
        //         _gm_CO2_D = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _ScO_25 = 0;
        // [ModelPar("2JEsm", "", "Sc/o.25", "", "bar bar-1")]
        // public double ScO_25
        // {
        //     get { return _ScO_25; }
        //     set
        //     {
        //         _ScO_25 = value;
        //         //notifyChanged();
        //     }
        // }
        // protected double _ScO_Ea = -24460;
        // [ModelPar("sNkGP", "", "Sc/o.Ea", "", "kJ mol-1")]
        // public double ScO_Ea
        // {
        //     get { return _ScO_Ea; }
        //     set
        //     {
        //         _ScO_Ea = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _R_25 = 8.314;
        // [ModelPar("k6foH", "", "R.25", "", "J mol-1 K-1")]
        // public double R_25
        // {
        //     get { return _R_25; }
        //     set
        //     {
        //         _R_25 = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _Vp_Ea = 0;
        // [ModelPar("NjCLC", "", "Vp.Ea", "", "kJ mol-1")]
        // public double Vp_Ea
        // {
        //     get { return _Vp_Ea; }
        //     set
        //     {
        //         _Vp_Ea = value;
        //         //notifyChanged();
        //     }
        // }
        // protected double _Vp_S = 0;
        // [ModelPar("OiwRo", "", "Vp.S", "", "J K-1 mol-1")]
        // public double Vp_S
        // {
        //     get { return _Vp_S; }
        //     set
        //     {
        //         _Vp_S = value;
        //         //notifyChanged();
        //     }
        // }
        // protected double _Vp_D = 0;
        // [ModelPar("FuYMt", "", "Vp.D", "", "J mol-1")]
        // public double Vp_D
        // {
        //     get { return _Vp_D; }
        //     set
        //     {
        //         _Vp_D = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _Kp_25 = 0;
        // [ModelPar("Tsf6K", "", "Kp.25", "", "", "μbar")]
        // public double Kp_25
        // {
        //     get { return _Kp_25; }
        //     set
        //     {
        //         _Kp_25 = value;
        //         // notifyChanged();
        //     }
        // }

        // protected double _Kp_Ea = 0;
        // [ModelPar("O4xIG", "", "Kp.Ea", "", "", "")]
        // public double Kp_Ea
        // {
        //     get { return _Kp_Ea; }
        //     set
        //     {
        //         _Kp_Ea = value;
        //         //notifyChanged();
        //     }
        // }

        // protected double _VoVc_25 = 0.29;
        // [ModelPar("J6Adp", "", "VoVc.25", "", "", "")]
        // public double VoVc_25
        // {
        //     get { return _VoVc_25; }
        //     set
        //     {
        //         _VoVc_25 = value;
        //         // notifyChanged();
        //     }
        // }
        // protected double _VoVc_Ea = 0;
        // [ModelPar("e2jbG", "", "VoVc.Ea", "", "", "")]
        // public double VoVc_Ea
        // {
        //     get { return _VoVc_Ea; }
        //     set
        //     {
        //         _VoVc_Ea = value;
        //         //notifyChanged();
        //     }
        // }

        protected double _F2 = 0.75;
        [ModelPar("THGeL", "Quantum efficiency of PSII e- folow on PSII-absorbed light basis at the strictly limiting light level", "ɸ", "2(LL)", "")]
        public double F2
        {
            get { return _F2; }
            set { _F2 = value; }
        }

        protected double _F1 = 0.95;
        [ModelPar("6RyTa", "Quantum efficiency of PSI e- flow at the strictly limiting light level", "ɸ", "1(LL)", "")]
        public double F1
        {
            get { return _F1; }
            set { _F1 = value; }
        }


        #endregion
    }
}
