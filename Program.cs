using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerCanopyPhotosynthesis;

namespace DCaPS
{
    class Program
    {
        static void Main(string[] args)
        {
            //C3-------------------------------------------------------------
            //Create an instance of the PM Model
            PhotosynthesisModel PM = new PhotosynthesisModel();

            //Set the desired photosynthetic pathway
            PM.photoPathway = PhotosynthesisModel.PhotoPathway.C3;
            
            //Set the latitiude
            PM.envModel.latitude = new Angle(-27.5, AngleType.Deg);

            //Set Ambient air CO2 partial pressure
            PM.canopy.Ca = 400;

            //Set the daily environmental variables
            PM.envModel.DOY = 298;
            PM.envModel.maxT = 21;
            PM.envModel.minT = 7;

            //Set the leaf angle
            PM.canopy.leafAngle = 60;

            //Set daily LAI and SLN values
            PM.canopy.LAI = 6;
            PM.canopy.CPath.SLNAv = 1.45;

            //Set initialised flag - there are several 'notifiers' that run when a property is changed
            // so these are set after cahnges have been made
            PM.envModel.initilised = true;
            PM.initialised = true;

            //Run the model
            PM.runDaily();

            Console.WriteLine("---C3 Test -------------");
            Console.WriteLine("Daily assimilation :" + PM.dailyBiomass.ToString("0.00") + " g / m2");
            Console.WriteLine("------------------------");


            //C4-------------------------------------------------------------

            //Create an instance of the PM Model
            PM = new PhotosynthesisModel();

            //Set the desired photosynthetic pathway
            PM.photoPathway = PhotosynthesisModel.PhotoPathway.C4;

            //Set the latitiude
            PM.envModel.latitude = new Angle(-27.5, AngleType.Deg);

            //Set Ambient air CO2 partial pressure
            PM.canopy.Ca = 400;

            //Set the daily environmental variables
            PM.envModel.DOY = 298;
            PM.envModel.maxT = 30;
            PM.envModel.minT = 20;

            //Set the leaf angle
            PM.canopy.leafAngle = 60;

            //Set daily LAI and SLN values
            PM.canopy.LAI = 6;
            PM.canopy.CPath.SLNAv = 1.36;

            //Set initialised flag - there are several 'notifiers' that run when a property is changed 
            // so flag is set after changes have been made
            PM.envModel.initilised = true;
            PM.initialised = true;

            //Run the model
            PM.runDaily();


            Console.WriteLine("---C4 Test -------------");
            Console.WriteLine("Daily assimilation :" + PM.dailyBiomass.ToString("0.00") + " g / m2");
            Console.WriteLine("------------------------");

            Console.WriteLine("Press any key to exit...");


            Console.ReadKey();

        }
    }
}
