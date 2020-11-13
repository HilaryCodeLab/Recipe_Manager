using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;

namespace HSTS_RecipeManager
{
    [Serializable()]
    public class MyRecipe : ISerializable
    {
        //initialize variables
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int PrepTime { get; set; }
        public string Ingredients { get; set; }
        public string Methods { get; set; }
        public int Serving { get; set; }
        public string Category { get; set; }
        

        //default constructor
        public MyRecipe()
        {
            RecipeId = 0;
            Name = null;
            PrepTime = 0;
            Ingredients = null;
            Methods = null;
            Serving = 0;
            Category = null;
        }

        //deserialization constructor
        public MyRecipe(SerializationInfo info, StreamingContext context) 
        {
            //get values from info and assign them to the corresponding properties
            RecipeId = (int)info.GetValue("Recipe_Id", typeof(int));
            Name = (String)info.GetValue("Recipe_Name", typeof(string));
            PrepTime = (int)info.GetValue("Prep_Time", typeof(int));
            Ingredients = (String)info.GetValue("Recipe_Ing", typeof(string));
            Methods = (String)info.GetValue("Recipe_Methods", typeof(string));
            Serving = (int)info.GetValue("Num_Serves", typeof(int));
            Category = (String)info.GetValue("Recipe_Category", typeof(string));

        }

        //serialization function
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Recipe_Id", RecipeId);
            info.AddValue("Recipe_Name", Name);
            info.AddValue("Prep_Time", PrepTime);
            info.AddValue("Recipe_Ing", Ingredients);
            info.AddValue("Recipe_Methods", Methods);
            info.AddValue("Num_Serves", Serving);
            info.AddValue("Recipe_Category", Category);
        }


    }
}
