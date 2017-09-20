using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerCanopyPhotosynthesis
{
    class LightVar
    {
        private double _sunlit;
        private double _shaded;

        public double sunlit
        {
            get { return _sunlit; }
            set { _sunlit = value; }
        }

        public double shaded
        {
            get { return _shaded; }
            set { _shaded = value; }
        }
    }
}
