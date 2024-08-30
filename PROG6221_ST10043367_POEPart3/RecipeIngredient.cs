using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_ST10043367_POEPart3
{
    public class CustomRecipeIngredient
    {
        public string NewRecipeName { get; }
        // Constructor for the CustomRecipeIngredient class
        public CustomRecipeIngredient(string name)
        {
            NewRecipeName = name;
        }
    }
}