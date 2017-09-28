﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerCanopyPhotosynthesis
{
    public class PathwayParametersC3 : PathwayParameters
    {
        public PathwayParametersC3() : base()
        {

            structuralN = 25;
            SLNRatioTop = 1.32;

            SLNAv = 1.45;
            CiCaRatio = 0.7;
            CiCaRatioIntercept = 0.90;
            CiCaRatioSlope = -0.12;
            fcyc = 0;
            psiRd = 0.0116;
            psiVc = 1.16;
            psiJ = 2.4;
            psiVp = 0;
            x = 0.4;

            Kc_P25 = 272.38;
            Kc_c = 32.689;
            Kc_b = 9741.400;

            Kp_P25 = 139;
            Kp_c = 14.644;
            Kp_b = 4366.129;

            Ko_P25 = 165820;
            Ko_c = 9.574;
            Ko_b = 2853.019;

            VcMax_VoMax_P25 = 4.580;
            VcMax_VoMax_c = 13.241;
            VcMax_VoMax_b = 3945.722;

            VcMax_c = 26.355;
            VcMax_b = 7857.830;

            VpMax_c = 0;
            VpMax_b = 0;

            Rd_c = 18.715;
            Rd_b = 5579.745;

            JMax_TOpt = 28.796;
            JMax_Omega = 15.536;

            gm_P25 = 0.55;
            gm_TOpt = 34.309;
            gm_Omega = 20.791;

            F2 = 0.75;
            F1 = 0.95;
        }
    }
}
