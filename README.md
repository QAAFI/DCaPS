# DCaPS (Diurnal Canopy Photosynthesis Simulator)

##About DCaPS
DCaPS is a model that can simulate diurnal canopy photosynthesis of both C3 and C4 field crops. It is driven by diurnal environmental variables and canopy attributes, and represents the canopy with the sun-shade modelling approach, to calculate diurnal canopy photosynthesis and daily above-ground biomass accumulation. The model can be used to assess consequences of photosynthetic changes and/or incorporated into crop growth and development model.

For a working web-based application of DCaPS, please visit http://www.dcaps.net.au.
For model detail, please visit the documentation page on http://www.dcaps.net.au.


## Model Description

* There are several classes which are all owned by the PhotsynthesisModel class. Following is a list of the main sub model and a brief list of their functionality:
* EnvironmentModel
     * Calculates solar geometry
     * Calculates diurnal radiation, temperature and VPD
* LeafCanopy
     * Calculuates diurnal sunlit / shaded LAI (Leaf Area Index)
     * Calculates absorbed radiation
     * Calculates leaf nitrogen
* SunlitCanopy / ShadedCanopy
     * Calculates absorbed radiation
     * Calculates assimilation through rubisco and electron transport  


## Using the model

The source code is a C# .Net project and can be used with several develepment UI's eg. Misrosoft Visual Studio.

The code does not use any non standard libraries.

Included in the project is a console application that instantiates a PhotoSynthesis model and runs it for both the C3 and C4 pathways. All of the parameters and variables are properties of the particular class and can be set directly.

All parameters have default values.


* Step 1 - Instantiate a PhotosynthesisModel

```csharp
PhotosynthesisModel PM = new PhotosynthesisModel();
```

* Step 2 - Set the desired photosynthetic pathway

```csharp
PM.photoPathway = PhotosynthesisModel.PhotoPathway.C3;
```        

* Step 3 - Set the location (latitude) and daily environmental parameters

```csharp
//Set the latitiude
PM.envModel.latitude = new Angle(-27.5, AngleType.Deg);

//Set Ambient air CO2 partial pressure
PM.canopy.Ca = 400;

//Set the daily environmental variables
PM.envModel.DOY = 298;
PM.envModel.maxT = 21;
PM.envModel.minT = 7;
```

* Step 4 - Set the leaf architecture and nitogen status

```csharp
//Set the leaf angle
PM.canopy.leafAngle = 60;

//Set daily LAI and SLN values
PM.canopy.LAI = 6;
PM.canopy.CPath.SLNAv = 1.45;
```

* Step 5 - Run the model

```csharp
PM.envModel.initilised = true;
PM.initialised = true;

//Run the model
PM.runDaily();
```

## Feedback

https://github.com/QAAFI/DCaPS