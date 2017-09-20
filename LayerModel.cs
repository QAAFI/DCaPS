using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerCanopyPhotosynthesis
{

    public class LayerModel
    {
        NaturalSpline spline;
        public LayerModel(double[] x, double[] y)
        {
            spline = new NaturalSpline(x, y);
        }

        //---------------------------------------------------------------------------
        public double getValue(double value)
        {
            return spline.getValue(value);
        }
    }
}
