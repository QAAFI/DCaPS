using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerCanopyPhotosynthesis
{
    public class TrapezoidLayer
    {
        public TrapezoidLayer() { }

        public static void integrate(int nLayers, double[] final, double[] intermediate, double[] LAIs)
        {
            if (nLayers == 1)
            {
                final[0] = intermediate[0];
            }
            else
            {
                for (int i = 0; i < nLayers; i++)
                {
                    final[i] = (intermediate[i - 1] + intermediate[i]) * LAIs[i] / 2;
                }
            }
        }
    }
}
