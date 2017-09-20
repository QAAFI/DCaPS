using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerCanopyPhotosynthesis
{
    public class TempFunctionNormal
    {
        public TempFunctionNormal() { }

        public static double val(double temp, double P25, double TOpt, double Omega)
        {
            return P25 * Math.Exp(-1 *( Math.Pow((temp - TOpt) / Omega, 2)) + (Math.Pow((25 - TOpt) /Omega, 2)));
        }
    }
}
