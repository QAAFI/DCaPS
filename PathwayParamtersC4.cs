using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerCanopyPhotosynthesis
{
    public class PathwayParametersC4 : PathwayParameters
    {
        public PathwayParametersC4()
            : base()
        {

            structuralN = 14;
            SLNRatioTop = 1.3;
            SLNAv = 1.3;

            // Kc μbar	
            Kc_P25 = 1210;
            Kc_c = 25.899;
            Kc_b = 7721.915;

            //Ko μbar	
            Ko_P25 = 292000;
            Ko_c = 4.236;
            Ko_b = 1262.93;

            //Kp μbar	
            Kp_P25 = 139;
            Kp_c = 14.644;
            Kp_b = 4366.129;

            //Vcmax/Vomax	-	
            VcMax_VoMax_P25 = 5.401;
            VcMax_VoMax_c = 9.126;
            VcMax_VoMax_b = 2719.478;

            //Vcmax μmol/m2/s*	
            VcMax_c = 31.467;
            VcMax_b = 9381.766;

            //Vpmax μmol/m2/s*	
            VpMax_c = 38.244;
            VpMax_b = 11402.450;

            //Rd μmol/m2/s*	
            Rd_c = 18.715;
            Rd_b = 5579.745;

            //Jmax(Barley, Farquhar 1980)    μmol/m2/s*	
            JMax_TOpt = 32.633;
            JMax_Omega = 15.270;


            //gm(Arabidopsis, Bernacchi 2002)    μmol/m2/s/bar	
            gm_P25 = 0.55;
            gm_TOpt = 34.309;
            gm_Omega = 20.791;

            _psiVc = 0.5;
            _psiJ = 2.4;
            _psiRd = 0;
            _psiVp = 1.0;

            _F2 = 0.75;
            _F1 = 0.95;

            _fcyc = 0.136;
            _CiCaRatio = 0.4;
            _CiCaRatioIntercept = 0.84;
            _CiCaRatioSlope = -0.19;
            // _J2_Ea = 77900;
            // _J2_S = 630;
            // _J2_D = 192000;
            // _J_Ea = 77900;
            // _J_S = 630;
            // _J_D = 192000;
            // _Vp_Ea = 94800;
            // _Vp_S = 250;
            // _Vp_D = 73300;
            // _Vc_Ea = 78000;
            // _Kc_25 = 1210;
            // _Kc_Ea = 64200;
            // _Ko_25 = 292000;
            // _Ko_Ea = 10500;
            // _Rd_Ea = 46390;
            // _gm_CO2_25 = 0.3;
            // _gm_CO2_Ea = 46900;
            // _gm_CO2_S = 1400;
            // _gm_CO2_D = 437400;
            // _ScO_25 = 1310;
            // _ScO_Ea = -31100;
            // _R_25 = 8.314;
            // _Kp_25 = 139;
            // _Kp_Ea = 36300;
            // _VoVc_25 = 0.184;
            // _VoVc_Ea = -23000;

        }
    }
}
