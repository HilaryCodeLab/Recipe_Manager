using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTS_RecipeManager
{
    interface IRecipeMaker
    {
        void addMethodStep();
        void deleteMethodStep();
        void reorderMethodStep(bool up);
       
    }
}
