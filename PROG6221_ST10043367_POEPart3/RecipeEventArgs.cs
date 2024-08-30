using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_ST10043367_POEPart3
{
    public class RecipeEventArgs : EventArgs
    {
        public Recipe Recipe { get; }

        // Constructor for the RecipeEventArgs class
        public RecipeEventArgs(Recipe recipe)
        {
            Recipe = recipe;
        }
    }
}
