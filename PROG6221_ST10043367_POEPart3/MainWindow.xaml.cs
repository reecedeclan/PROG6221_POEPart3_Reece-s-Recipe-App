using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace PROG6221_ST10043367_POEPart3
{
    public partial class MainWindow : Window
    {
        public RecipeManager recipeManager;

        public MainWindow()
        {
            InitializeComponent();
            InitializeRecipeManager();
        }

        private void InitializeRecipeManager()
        {
            // Create some sample recipes
            List<Recipe> recipes = new List<Recipe>
            {
                // Recipe 1: Pancakes
                new Recipe("Pancakes", new List<RecipeIngredient>
                {
                    // Ingredients for the recipe Pancakes
                    new RecipeIngredient("Flour", "1 cup", "grams", 120, "Grains"),
                    new RecipeIngredient("Milk", "1 cup", "ml", 103, "Dairy"),
                    new RecipeIngredient("Egg", "1", "", 72, "Protein"),
                    new RecipeIngredient("Butter", "2 tbsp", "grams", 204, "Fats")
                }, new List<string>
                {
                    // Steps for the recipe Pancakes
                    "Mix flour, milk, and egg in a bowl.",
                    "Heat a non-stick pan and melt butter on it.",
                    "Pour the batter onto the pan and cook until golden brown on both sides."
                }),

                // Recipe 2: Salad
                new Recipe("Salad", new List<RecipeIngredient>
                {
                    // Ingredients for the Salad recipe
                    new RecipeIngredient("Lettuce", "2 cups", "grams", 10, "Vegetables"),
                    new RecipeIngredient("Tomato", "1", "", 22, "Vegetables"),
                    new RecipeIngredient("Cucumber", "1", "", 16, "Vegetables"),
                    new RecipeIngredient("Carrot", "1", "", 41, "Vegetables"),
                    new RecipeIngredient("Olive oil", "2 tbsp", "grams", 239, "Fats")
                }, new List<string>
                {
                    // Steps for the recipe Salad
                    "Wash and chop the vegetables.",
                    "Mix the vegetables in a bowl.",
                    "Drizzle olive oil over the salad and toss gently."
                })
            };

            // Create a recipe manager and assign the sample recipes to it
            recipeManager = new RecipeManager(recipes);
            recipeManager.RecipeCaloriesExceededEvent += RecipeCaloriesExceededEventHandler;

            DisplayAllRecipes();
        }

        // Event handler for the RecipeCaloriesExceededEvent
        public void RecipeCaloriesExceededEventHandler(Recipe recipe)
        {
            // Display a warning message when the recipe exceeds 300 calories
            MessageBox.Show($"Warning: The recipe '{recipe.Name}' exceeds 300 calories!", "High Calorie Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            System.Media.SystemSounds.Beep.Play();
        }

        // Display all recipes in the list box
        public void DisplayAllRecipes()
        {
            lbxDisplay.Items.Clear();
            List<Recipe> sortedRecipes = recipeManager.Recipes.OrderBy(recipe => recipe.Name).ToList();
            foreach (Recipe recipe in sortedRecipes)
            {
                lbxDisplay.Items.Add(recipe.ToString());
            }
        }

        // Filter recipes based on the specified food group
        public void FilterRecipes()
        {
            string foodGroup = tbxFilterFoodGroup.Text;
            List<Recipe> filteredRecipes = recipeManager.GetRecipesByFoodGroup(foodGroup);

            if (filteredRecipes.Count > 0)
            {
                lbxDisplay.Items.Clear();
                foreach (Recipe recipe in filteredRecipes)
                {
                    lbxDisplay.Items.Add(recipe.ToString());
                }
            }
            else
            {
                MessageBox.Show($"No recipes found with the food group '{foodGroup}'.", "Error", MessageBoxButton.OK);
            }
        }

        // Modify a recipe by scaling its ingredients
        public void ModifyRecipe()
        {
            string name = tbxRecipeName.Text;

            Recipe recipe = recipeManager.GetRecipeByName(name);

            if (recipe != null)
            {
                string scaleFactorString = tbxScaleFactor.Text;
                if (double.TryParse(scaleFactorString, out double scaleFactor))
                {
                    // Scale the recipe based on the specified scale factor
                    Recipe scaledRecipe = recipeManager.ScaleRecipe(recipe, scaleFactor);
                    if (scaledRecipe != null)
                    {
                        // Update the recipe with the scaled recipe
                        recipeManager.UpdateRecipe(recipe, scaledRecipe);
                        DisplayAllRecipes();
                        MessageBox.Show($"Recipe '{name}' has been scaled by a factor of {scaleFactor}.", "Recipe Scaled", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Invalid scale factor. Please enter a valid number greater than 0.", "Invalid Scale Factor", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid scale factor. Please enter a valid number greater than 0.", "Invalid Scale Factor", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"Recipe '{name}' could not be found.", "Recipe Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for the Filter button click
        public void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterRecipes();
        }

        // Event handler for the Scale Recipe button click
        public void btnScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            ModifyRecipe();
        }

        // Event handler for the Reset Recipes button click
        public void btnResetRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Reset all recipes to their original quantities
            recipeManager.ResetRecipes();
            DisplayAllRecipes();
            MessageBox.Show("All recipes have been reset.", "Recipes Reset", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for the Input button click
        public void btnInput_Click(object sender, RoutedEventArgs e)
        {
            InputRecipeWindow inputRecipeWindow = new InputRecipeWindow();
            inputRecipeWindow.RecipeAdded += InputRecipeWindow_RecipeAdded;
            inputRecipeWindow.ShowDialog();
        }

        // Event handler for the RecipeAdded event in the InputRecipeWindow
        public void InputRecipeWindow_RecipeAdded(object sender, RecipeEventArgs e)
        {
            // Add the new recipe to the recipe manager
            Recipe recipe = e.Recipe;
            recipeManager.AddRecipe(recipe);
            DisplayAllRecipes();
        }

        // Event handler for the Display button click
        public void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            DisplaySelectedRecipe();
        }

        // Event handler for the RecipeDetailsWindowClosedEvent
        public void RecipeDetailsWindowClosed()
        {
            DisplayAllRecipes();
        }

        // Display the selected recipe in a new window
        public void DisplaySelectedRecipe()
        {
            if (lbxDisplay.SelectedItem is string recipeName)
            {
                Recipe recipe = recipeManager.GetRecipeByName(recipeName);
                if (recipe != null)
                {
                    RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(recipe);
                    recipeDetailsWindow.RecipeDetailsWindowClosedEvent += RecipeDetailsWindow_RecipeDetailsWindowClosed;
                    recipeDetailsWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Recipe '{recipeName}' not found.", "Recipe Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to display.", "No Recipe Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Event handler for the RecipeDetailsWindowClosedEvent
        private void RecipeDetailsWindow_RecipeDetailsWindowClosed()
        {
            DisplayAllRecipes();
        }

        // Event handler for the Reset button click
        public void btnReset_Click(object sender, RoutedEventArgs e)
        {
            // Reset all recipes by clearing the list
            recipeManager.ResetRecipes();
            DisplayAllRecipes();
            MessageBox.Show("All recipes have been deleted.", "Delete Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for the Reset to Original button click
        public void btnResettoOrigional_Click(object sender, RoutedEventArgs e)
        {
            // Reset recipe quantities to their original values
            ResetRecipeQuantities();
            DisplayAllRecipes();
            MessageBox.Show("Recipe quantities have been reset to their original values.", "Reset Quantities", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Reset the quantities of all recipes to their original values
        private void ResetRecipeQuantities()
        {
            foreach (Recipe recipe in recipeManager.Recipes)
            {
                foreach (RecipeIngredient ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity = ingredient.OriginalQuantity;
                }
            }
        }

        // Event handler for the selection change in the lbxDisplay ListBox
        public void lbxDisplay_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Enable the Display button if a recipe is selected
            btnDisplay.IsEnabled = lbxDisplay.SelectedItem != null;
        }

        // Event handler for the Scale button click
        public void btnScale_Click(object sender, RoutedEventArgs e)
        {
            ModifyRecipe();
        }
    }

    // Class for managing recipes
    public class RecipeManager
    {
        public List<Recipe> Recipes { get; private set; }

        // Event for notifying when a recipe exceeds the calorie limit
        public event Action<Recipe> RecipeCaloriesExceededEvent;

        public RecipeManager(List<Recipe> recipes)
        {
            Recipes = recipes;
        }

        // Add a recipe to the recipe manager
        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
            CheckRecipeCalories(recipe);
        }

        // Get recipes by food group
        public List<Recipe> GetRecipesByFoodGroup(string foodGroup)
        {
            return Recipes.Where(recipe => recipe.Ingredients.Any(ingredient => ingredient.FoodGroup == foodGroup)).ToList();
        }

        // Get a recipe by name
        public Recipe GetRecipeByName(string name)
        {
            return Recipes.FirstOrDefault(recipe => recipe.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Update a recipe with the updated version
        public void UpdateRecipe(Recipe originalRecipe, Recipe updatedRecipe)
        {
            int index = Recipes.IndexOf(originalRecipe);
            if (index >= 0)
            {
                Recipes[index] = updatedRecipe;
            }
        }

        // Scale a recipe by a given scale factor
        public Recipe ScaleRecipe(Recipe recipe, double scaleFactor)
        {
            List<RecipeIngredient> scaledIngredients = new List<RecipeIngredient>();
            foreach (RecipeIngredient ingredient in recipe.Ingredients)
            {
                int scaledCalories = (int)(ingredient.Calories * scaleFactor);
                RecipeIngredient scaledIngredient = new RecipeIngredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, scaledCalories, ingredient.FoodGroup);
                scaledIngredients.Add(scaledIngredient);
            }

            List<string> scaledSteps = new List<string>(recipe.Steps);

            return new Recipe(recipe.Name, scaledIngredients, scaledSteps);
        }

        // Reset all recipes to their original quantities
        public void ResetRecipes()
        {
            foreach (Recipe recipe in Recipes)
            {
                foreach (RecipeIngredient ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity = ingredient.OriginalQuantity;
                }
            }
        }

        // Check if a recipe exceeds the calorie limit and raise the RecipeCaloriesExceededEvent if it does
        private void CheckRecipeCalories(Recipe recipe)
        {
            int totalCalories = recipe.Ingredients.Sum(ingredient => ingredient.Calories);
            if (totalCalories > 300)
            {
                RecipeCaloriesExceededEvent?.Invoke(recipe);
            }
        }
    }

    // Class representing a recipe
    public class Recipe
    {
        public string Name { get; private set; }
        public List<RecipeIngredient> Ingredients { get; private set; }
        public List<string> Steps { get; private set; }

        public Recipe(string name, List<RecipeIngredient> ingredients, List<string> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    // Class representing an ingredient in a recipe
    public class RecipeIngredient
    {
        public string Name { get; private set; }
        public string Quantity { get; set; }
        public string Unit { get; private set; }
        public int Calories { get; private set; }
        public string FoodGroup { get; private set; }
        public string OriginalQuantity { get; private set; }

        public RecipeIngredient(string name, string quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
            OriginalQuantity = quantity;
        }
    }
}
