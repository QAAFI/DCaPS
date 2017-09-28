using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerCanopyPhotosynthesis
{
    public abstract class PhotoLayerSolver { 
   
        PhotosynthesisModel _PM;
        int _layer;

        //--------------------------------------------------------------
        public PhotoLayerSolver( PhotosynthesisModel PM, int layer)
        {
            _PM = PM;
            _layer = layer;
        }

        public abstract double calcPhotosynthesis(PhotosynthesisModel PM, SunlitShadedCanopy s, int layer, double _Cc);
        //---------------------------------------------------------------------------------------------------------
        public abstract double calcAc(double Cc, LeafCanopy canopy, SunlitShadedCanopy s, int layer);
        //---------------------------------------------------------------------------------------------------------
        public abstract double calcAj(double Cc, LeafCanopy canopy, SunlitShadedCanopy s, int layer);
    }
}
