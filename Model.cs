using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

namespace LayerCanopyPhotosynthesis
{
    public class ModelJSONStringifier
    {
        public ModelJSONStringifier() { }

        public static string getParDefinitions(Object obj)
        {
            List<ModelPar> modelPars = new List<ModelPar>();

            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                foreach (Attribute at in prop.GetCustomAttributes(true))
                    if (at is ModelPar && !(at is ModelVar))
                    {
                        modelPars.Add((ModelPar)at);
                    }
            }

            //JsonSerializerSettings jss = new JsonSerializerSettings();
            //jss.TypeNameHandling = TypeNameHandling.None;
            //jss.TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            //jss.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            return JsonConvert.SerializeObject(modelPars);
        }

        public static string getVarDefinitions(Object obj)
        {
            List<ModelVar> modelVars = new List<ModelVar>();

            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);

            foreach (FieldInfo field in fields)
            {
                foreach (Attribute at in field.GetCustomAttributes(true))
                    if (at is ModelVar)
                    {
                        modelVars.Add((ModelVar)at);
                    }
            }

            return JsonConvert.SerializeObject(modelVars);
        }

        public string setParValues()
        {
            return "";
        }

        public string getVarValues()
        {
            return "";
        }
    }
}
