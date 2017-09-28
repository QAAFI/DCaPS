using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerCanopyPhotosynthesis;

namespace LayerCanopyPhotosynthesis
{

    //[System.Xml.Serialization.XmlInclude(typeof(SunlitCanopy))]
    //[System.Xml.Serialization.XmlInclude(typeof(ShadedCanopy))]
    public abstract class SunlitShadedCanopy
    {
        protected int _nLayers;

        [ModelVar("yeYEA", "LAI of the sunlit and shade leaf fractions", "LAI", "", "m2/m2", "l,t", "m2 leaf/m2 ground")]
        public double[] LAIS { get; set; }

        [ModelVar("aRNmW", "Irradiance incident on leaves", "I", "inc", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] incidentIrradiance { get; set; }

        [ModelVar("wKFLV", "PAR absorbed by the sunlit and shade leaf fractions", "I", "abs", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] absorbedIrradiance { get; set; }

        [ModelVar("0PWTP", "Direct-beam absorbed by leaves", "Integrate over LAIsun", "", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] absorbedRadiationDirect { get; set; }

        [ModelVar("OsYZA", "Diffuse absorbed by leaves", "Integrate over LAIsun", "", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] absorbedRadiationDiffuse { get; set; }

        [ModelVar("jRJiA", "Scattered-beam absorbed by leaves", "Integrate over LAIsun", "", "μmol m-2 ground s-1")]
        public double[] absorbedRadiationScattered { get; set; }

        [ModelVar("hwe6f", "Vcmax for the sunlit and shade leaf fractions  @ 25°", "V", "c_max", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] VcMax25 { get; set; }

        [ModelVar("nX8u7", "Vcmax for the sunlit and shade leaf fractions  @ T°", "V", "c_max", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] VcMaxT { get; set; }

        [ModelVar("y1rt7", "Maximum rate of P activity-limited carboxylation @ 25°", "V", "p_max", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] VpMax25 { get; set; }

        [ModelVar("Bl7oY", "Maximum rate of Rubisco carboxylation", "V", "p_max", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] VpMaxT { get; set; }

        [ModelVar("lAx5b", "Jmax for the sunlit and shade leaf fractions @ 25°", "J", "max", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] JMax25 { get; set; }

        [ModelVar("Gx6ir", "Maximum rate of electron transport", "J", "max", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] JMaxT { get; set; }

        [ModelVar("xMC5L", "Temperature of sunlit and shade leaf fractions", "T", "l", "°C", "l,t")]
        public double[] leafTemp { get; set; }

        [ModelVar("VOep5", "Leaf-to-air vapour pressure deficit for sunlit and shade leaf fractions", "VPD", "al", "kPa", "l,t")]
        public double[] VPD { get; set; }

        [ModelVar("YC5yq", "", "", "", "")]
        public double[] fVPD { get; set; }

        [ModelVar("N14in", "PEP regeneration rate at Temp", "V", "pr", "μmol/m2/s", "l,t")]
        public double[] Vpr { get; set; }

        [ModelVar("opoaH", "Leaf boundary layer conductance for CO2 for the sunlit and shade fractions", "g", "b_CO2", "mol/m2/s", "l,t", "mol H20, m2 ground")]
        public double[] gb_CO2 { get; set; }

        [ModelVar("L3FnM", "Leakiness", "ɸ", "", "", "l,t")]
        public double[] F { get; set; }

        [ModelVar("VBqDL", "Half the reciprocal of Sc/o", "γ*", "", "", "l,t")]
        public double[] g_ { get; set; }


        //---------------------------------------------------------------------------------------------------------
        public SunlitShadedCanopy() { }
        //---------------------------------------------------------------------------------------------------------
        public SunlitShadedCanopy(int nLayers)
        {
            //_nLayers = nLayers;
            initArrays(nLayers);
        }
        //---------------------------------------------------------------------------------------------------------

        public void initArrays(int nLayers)
        {
            _nLayers = nLayers;

            incidentIrradiance = new double[nLayers];
            absorbedRadiationDirect = new double[nLayers];
            absorbedRadiationDiffuse = new double[nLayers];
            absorbedRadiationScattered = new double[nLayers];
            absorbedIrradiance = new double[nLayers];
            VcMax25 = new double[nLayers];
            VcMaxT = new double[nLayers];
            JMaxT = new double[nLayers];
            JMax25 = new double[nLayers];
            VpMax25 = new double[nLayers];
            VpMaxT = new double[nLayers];

            J = new double[nLayers];
            r_ = new double[nLayers];
            r_ac = new double[nLayers];
            r_aj = new double[nLayers];
            ScO = new double[nLayers];
            Kc = new double[nLayers];
            Ko = new double[nLayers];
            VcVo = new double[nLayers];
            K_ = new double[nLayers];
            Rd25 = new double[nLayers];
            RdT = new double[nLayers];
            Aj = new double[nLayers];
            Ac = new double[nLayers];
            A = new double[nLayers];
            gs_CO2 = new double[nLayers];
            gm_CO2T = new double[nLayers];
            Ci = new double[nLayers];
            Cc = new double[nLayers];
            x1J = new double[nLayers];
            x1V = new double[nLayers];
            x2J = new double[nLayers];
            x2V = new double[nLayers];

            lE = new double[nLayers];
            s = new double[nLayers];
            Rn = new double[nLayers];
            Sn = new double[nLayers];
            //φ = new double[nLayers];
            //Φ = new double[nLayers];
            es = new double[nLayers];
            rs_H2O = new double[nLayers];
            gs = new double[nLayers];

            leafTemp = new double[nLayers];
            es = new double[nLayers];
            s = new double[nLayers];
            gs = new double[nLayers];
            rs_H2O = new double[nLayers];
            lE = new double[nLayers];
            Sn = new double[nLayers];
            R_ = new double[nLayers];
            g_ = new double[nLayers];

            Rn = new double[nLayers];

            //LAIS = new double[nLayers];

            VPD = new double[nLayers];
            fVPD = new double[nLayers];
            gb_CO2 = new double[nLayers];

            Vpr = new double[nLayers];


            //C4 variables 
            Oc = new double[nLayers];
            Oc_ac = new double[nLayers];
            Oc_aj = new double[nLayers];
            Cm = new double[nLayers];
            Cm_ac = new double[nLayers];
            Cm_aj = new double[nLayers];
            Cc = new double[nLayers];
            Ccac = new double[nLayers];
            Ccaj = new double[nLayers];
            Vp = new double[nLayers];
            //AC3j = new double[nLayers];
            //AC3c = new double[nLayers];
            Ag = new double[nLayers];
            Rm = new double[nLayers];
            L = new double[nLayers];
            gbs = new double[nLayers];
            F = new double[nLayers];

            Kp = new double[nLayers];
            Om = new double[nLayers];
            Oi = new double[nLayers];
            CiCaRatio = new double[nLayers];


        }
        //---------------------------------------------------------------------------------------------------------
        public virtual void calcLAI(LeafCanopy canopy, SunlitShadedCanopy counterpart) { }
        public virtual void calcIncidentRadiation(EnvironmentModel EM, LeafCanopy canopy, SunlitShadedCanopy counterpart) { }
        public virtual void calcAbsorbedRadiation(EnvironmentModel EM, LeafCanopy canopy, SunlitShadedCanopy counterpart) { }
        public virtual void calcMaxRates(LeafCanopy canopy, SunlitShadedCanopy counterpart, PhotosynthesisModel EM) { }
        //---------------------------------------------------------------------------------------------------------
        void calcPhotosynthesis(LeafCanopy canopy)
        {
        }
        //---------------------------------------------------------------------------------------------------------
        public void calcPhotosynthesis(PhotosynthesisModel PM, int layer)
        {
            LeafCanopy canopy = PM.canopy;

            leafTemp[layer] = PM.envModel.getTemp(PM.time);

            double vpd = PM.envModel.getVPD(PM.time);

            canopy.CPath.CiCaRatio = canopy.CPath.CiCaRatioSlope * vpd + canopy.CPath.CiCaRatioIntercept;

            VcMaxT[layer] = TempFunctionExp.val(leafTemp[layer], VcMax25[layer], canopy.CPath.VcMax_c, canopy.CPath.VcMax_b);
            RdT[layer] = TempFunctionExp.val(leafTemp[layer], Rd25[layer], canopy.CPath.Rd_c, canopy.CPath.Rd_b);
            JMaxT[layer] = TempFunction.val(leafTemp[layer], JMax25[layer], canopy.CPath.JMax_TOpt, canopy.CPath.JMax_Omega);
            VpMaxT[layer] = TempFunctionExp.val(leafTemp[layer], VpMax25[layer], canopy.CPath.VpMax_c, canopy.CPath.VpMax_b);

            Vpr[layer] = canopy.Vpr_l * LAIS[layer];

            //TODO: I2 = canopy.ja * absorbedIrradiance[layer]
            canopy.ja = (1 - canopy.f) / 2;

            J[layer] = (canopy.ja * absorbedIrradiance[layer] + JMaxT[layer] - Math.Pow(Math.Pow(canopy.ja * absorbedIrradiance[layer] + JMaxT[layer], 2) -
            4 * canopy.θ * JMaxT[layer] * canopy.ja * absorbedIrradiance[layer], 0.5)) / (2 * canopy.θ);

            Kc[layer] = TempFunctionExp.val(leafTemp[layer], canopy.CPath.Kc_P25, canopy.CPath.Kc_c, canopy.CPath.Kc_b);
            Ko[layer] = TempFunctionExp.val(leafTemp[layer], canopy.CPath.Ko_P25, canopy.CPath.Ko_c, canopy.CPath.Ko_b);
            VcVo[layer] = TempFunctionExp.val(leafTemp[layer], canopy.CPath.VcMax_VoMax_P25, canopy.CPath.VcMax_VoMax_c, canopy.CPath.VcMax_VoMax_b);

            ScO[layer] = Ko[layer] / Kc[layer] * VcVo[layer];

            g_[layer] = 0.5 / ScO[layer];

            canopy.Sco = ScO[layer]; //For reporting ??? 

            K_[layer] = Kc[layer] * (1 + canopy.oxygenPartialPressure / Ko[layer]);

            es[layer] = 5.637E-7 * Math.Pow(leafTemp[layer], 4) + 1.728E-5 * Math.Pow(leafTemp[layer], 3) + 1.534E-3 *
                Math.Pow(leafTemp[layer], 2) + 4.424E-2 * leafTemp[layer] + 6.095E-1;

            canopy.airDensity = 1.295 * Math.Exp(-3.6E-3 * PM.envModel.getTemp(PM.time));

            canopy.ra = canopy.airDensity * 1000.0 / 28.966;


            VPD[layer] = PM.envModel.getVPD(PM.time);

            fVPD[layer] = canopy.a / (1 + VPD[layer] / canopy.Do);

            gs[layer] = fVPD[layer];

            gm_CO2T[layer] = LAIS[layer] * TempFunction.val(leafTemp[layer], canopy.CPath.gm_P25, canopy.CPath.gm_TOpt, canopy.CPath.gm_Omega);

            gb_CO2[layer] = 1 / canopy.rb_CO2s[layer] * LAIS[layer] * canopy.ra;

        }

        #region Instaneous Photosynthesis
        [ModelVar("0svKg", "Rate of electron transport of sunlit and shade leaf fractions", "J", "", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] J { get; set; }
        [ModelVar("Q7w4j", "CO2 compensation point in the absence of Rd for the sunlit and shade leaf fractions for layer l", "Γ*", "", "μbar", "l,t")]
        public double[] r_ { get; set; }
        [ModelVar("QQQww", "CO2 compensation point in the absence of Rd for the sunlit and shade leaf fractions for layer l", "Γ*", "", "μbar", "l,t")]
        public double[] r_ac { get; set; }
        [ModelVar("Orprw", "CO2 compensation point in the absence of Rd for the sunlit and shade leaf fractions for layer l", "Γ*", "", "μbar", "l,t")]
        public double[] r_aj { get; set; }
        [ModelVar("LL1b6", "Relative CO2/O2 specificity factor for Rubisco", "S", "c/o", "bar/bar", "l,t")]
        public double[] ScO { get; set; }
        [ModelVar("ZLENJ", "Kc for the sunlit and shade leaf fractions for layer l", "K", "c", "μbar", "l,t")]
        public double[] Kc { get; set; }
        [ModelVar("TMWa9", "Ko for the sunlit and shade leaf fractions for layer l", "K", "o", "μbar", "l,t")]
        public double[] Ko { get; set; }
        [ModelVar("P0HgR", "", "", "", "", "")]
        public double[] VcVo { get; set; }
        [ModelVar("hv6R5", "Effective Michaelis-Menten constant", "K'", "", "μbar")]
        public double[] K_ { get; set; }
        [ModelVar("AyR6r", "Rd for the sunlit and shade leaf fractions @ 25°", "Rd @ 25", "", "μmol/m2/s1", "l,t", "m2 ground")]
        public double[] Rd25 { get; set; }
        [ModelVar("hJOu6", "Rd for the sunlit and shade leaf fractions @ T°", "R", "d", "μmol/m2/s1", "l,t", "m2 ground")]
        public double[] RdT { get; set; }

        [ModelVar("6HJkr", "Electron-transport-limited rate of CO2 assimilation of sunlit and shade leaf fractions", "A", "j", "μmol CO2/m2/s", "l,t", "m2 ground")]
        public double[] Aj { get; set; }
        [ModelVar("r6dx6", "Rubisco-activity-limited rate of CO2 assimilation of sunlit and shade leaf fractions", "A", "c", "μmol CO2/m2/s", "l,t", "m2 ground")]
        public double[] Ac { get; set; }
        [ModelVar("CZFJx", "min(Aj, Ac) of sunlit and shade leaf fractions for layer l", "A", "", "μmol CO2/m2/s", "l,t", "m2 ground")]
        public double[] A { get; set; }
        [ModelVar("YFblo", "Leaf stomatal conductance for CO2 for the sunlit and shade fractions", "g", "s_CO2", "mol/m2/s", "l,t", "mol H20, m2 ground")]
        public double[] gs_CO2 { get; set; }
        [ModelVar("XrAH2", "Leaf mesophyll conductance for CO2 for the sunlit and shade fractions", "g", "m_CO2", "mol/m2/s", "l,t", "mol H20, m2 ground")]
        public double[] gm_CO2T { get; set; }
        [ModelVar("cozpi", "Intercellular CO2 partial pressure for the sunlit and shade leaf fractions", "C", "i", "μbar", "l,t")]
        public double[] Ci { get; set; }
        [ModelVar("8VmlI", "Chloroplastic CO2 partial pressure for the sunlit and shade leaf fractions", "C", "c", "μbar", "l,t")]
        public double[] Cc { get; set; }

        [ModelVar("ccAc55", "Chloroplastic CO2 partial pressure for the sunlit and shade leaf fractions from Rubisco", "C", "c_Ac", "μbar", "l,t")]
        public double[] Ccac { get; set; }
        [ModelVar("ccAj76", "Chloroplastic CO2 partial pressure for the sunlit and shade leaf fractions from Electron Transport", "C", "c_Aj", "μbar", "l,t")]
        public double[] Ccaj { get; set; }

        public double[] x1J { get; set; }
        public double[] x1V { get; set; }
        public double[] x2J { get; set; }
        public double[] x2V { get; set; }
        #endregion

        #region Conductance and Resistance parameters

        #endregion

        #region Leaf temperature from Penman-Monteith combination equation (isothermal form)

        [ModelVar("B2QqH", "Laten heat of vaporizatin for water * evaporation rate", "lE", "", "J s-1 kg-1 * kg m-2")]
        public double[] lE { get; set; }
        [ModelVar("G3rwq", "Slope of curve relating saturating water vapour pressure to temperature", "s", "", "kPa K-1")]
        public double[] s { get; set; }
        [ModelVar("rJSil", "Net isothermal radiation absorbed by the leaf", "Rn", "", "J s-1 m-2")]
        public double[] Rn { get; set; }
        [ModelVar("be7vB", "Absorbed short-wave radiation (PAR + NIR)", "Sn", "", "J s-1 m-2")]
        public double[] Sn { get; set; }
        [ModelVar("KbcZq", "Outgoing long-wave radiation", "R↑", "", "J s-1m-2")]
        public double[] R_ { get; set; }
        [ModelVar("EYrht", "Saturated water vapour pressure @ Tl", "es(Tl)", "", "")]
        public double[] es { get; set; }
        [ModelVar("ii3Kr", "Leaf stomatal resistance for H2O", "rs_H2O", "", "s m-1")]
        public double[] rs_H2O { get; set; }
        [ModelVar("a4Pbr", "", "gs", "", "m s-1")]
        public double[] gs { get; set; }

        [ModelVar("XenBm", "Michealise-Menten constant of PEPc for CO2", "K", "p", "μbar", "l,t", "", true)]
        public double[] Kp { get; set; }
        [ModelVar("09u65", "(Mesophyll oxygen partial pressure for sunlit and shade leaf fractions,", "O", "m", "μbar", "l,t")]
        public double[] Om { get; set; }
        [ModelVar("85YYK", "Intercellular oxygen partial pressure for sunlit and shade leaf fractions", "O", "i", "μbar", "l,t")]
        public double[] Oi { get; set; }
        [ModelVar("nIyeA", "Ci to Ca ratio", "Ci/Ca", "ratio", "", "l,t")]
        public double[] CiCaRatio { get; set; }


        //---------------------------------------------------------------------------------------------------------
        public double calcLeafTemperature(PhotosynthesisModel PM, int layer, double _leafTemp)
        {
            EnvironmentModel EM = PM.envModel;
            LeafCanopy canopy = PM.canopy;

            double airTemp = EM.getTemp(PM.time);

            s[layer] = (es[layer] - canopy.es_Ta) / (leafTemp[layer] - EM.maxT);

            gs[layer] = gs_CO2[layer] / canopy.ra;

            rs_H2O[layer] = (1 / gs[layer] - 1.3 * canopy.rb_H_LAIs[layer] - canopy.rts[layer]) / 1.6;

            Sn[layer] = canopy.energyConvRatio * absorbedIrradiance[layer];

            R_[layer] = canopy.Bz * Math.Pow((leafTemp[layer] + 273), 4) * canopy.fvap * canopy.fclear * LAIS[layer] / canopy.LAIs.Sum();

            Rn[layer] = Sn[layer] - R_[layer];

            lE[layer] = (s[layer] * Rn[layer] + canopy.airDensity * canopy.cp * VPD[layer] / (canopy.rb_H_LAIs[layer] + canopy.rts[layer])) /
                (s[layer] + canopy.g * ((canopy.rb_H2O_LAIs[layer] + canopy.rts[layer] + rs_H2O[layer]) / (canopy.rb_H_LAIs[layer] + canopy.rts[layer])));

            double calcLeafTemp = airTemp + (canopy.rb_H_LAIs[layer] + canopy.rts[layer]) * (Rn[layer] - lE[layer]) / (canopy.airDensity * canopy.cp);

            //return Math.Pow(1 - _leafTemp / calcLeafTemp, 2);
            return Math.Pow(_leafTemp - calcLeafTemp, 2);
        }

        #endregion

        //---------------------------------------------------------------------------------------------------------
        public virtual void run(int nlayers, PhotosynthesisModel PM, SunlitShadedCanopy counterpart)
        {
            _nLayers = nlayers;
            initArrays(_nLayers);
            calcIncidentRadiation(PM.envModel, PM.canopy, counterpart);
            calcAbsorbedRadiation(PM.envModel, PM.canopy, counterpart);
            calcMaxRates(PM.canopy, counterpart, PM);
        }


        [ModelVar("s4Vg0", "Oxygen partial pressure at the oxygenating site of Rubisco in the chloroplast for sunlit and shade leaf fractions", "O", "c", "μbar", "l,t")]
        public double[] Oc { get; set; }
        [ModelVar("s4Vg4", "Oxygen partial pressure at the oxygenating site of Rubisco in the chloroplast for sunlit and shade leaf fractions", "O", "c", "μbar", "l,t")]
        public double[] Oc_ac { get; set; }
        [ModelVar("s4Vg5", "Oxygen partial pressure at the oxygenating site of Rubisco in the chloroplast for sunlit and shade leaf fractions", "O", "c", "μbar", "l,t")]
        public double[] Oc_aj { get; set; }

        [ModelVar("mmxWN", "Mesophyll CO2 partial pressure for the sunlit and shade leaf fractions", "C", "m", "μbar", "l,t", "", true)]
        public double[] Cm { get; set; }
        [ModelVar("mmxWa", "Mesophyll CO2 partial pressure for the sunlit and shade leaf fractions", "C", "m", "μbar", "l,t", "", true)]
        public double[] Cm_ac { get; set; }
        [ModelVar("mmxWb", "Mesophyll CO2 partial pressure for the sunlit and shade leaf fractions", "C", "m", "μbar", "l,t", "", true)]
        public double[] Cm_aj { get; set; }

        [ModelVar("7u3JF", "Chloroplast or BS CO2 partial pressuer", "Cbs", "", "μbar")]
        public double[] Cbs { get; set; }

        [ModelVar("JiUIt", "Rate of PEPc", "V", "p", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] Vp { get; set; }

        [ModelVar("FCzCY", "Gross canopy CO2 assimilation per second", "Ag", "", "μmol CO2 m-2 ground s-1")]
        public double[] Ag { get; set; }

        [ModelVar("a2eBP", "", "", "", "")]
        public double[] L { get; set; }

        [ModelVar("iuUvg", "Mitochondrial respiration occurring in the mesophyll", "R", "m", "μmol/m2/s", "l,t", "m2 ground")]
        public double[] Rm { get; set; }

        [ModelVar("oem3o", "Conductance to CO2 leakage from the bundle sheath to mesophyll", "g", "bsCO2", "mol/m2/s", "l,t", "mol of H20, m2 leaf", true)]
        public double[] gbs { get; set; }

    }
}
