using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerCanopyPhotosynthesis
{
    public class TempFunctionExp
    {
        public TempFunctionExp() { }

        public static double val(double temp,  double P25, double c, double b)
        {
            return P25 * Math.Exp(c - b / (temp + 273));
        }
    }
}
