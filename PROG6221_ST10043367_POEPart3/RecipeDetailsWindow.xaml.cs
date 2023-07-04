using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace PROG6221_ST10043367_POEPart3
{
    public partial class RecipeDetailsWindow : Window
    {
        private Recipe recipe;
        private List<RecipeIngredient> originalIngredients;

        public RecipeDetailsWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;

            // Create a deep copy of the original ingredients to track changes
            originalIngredients = recipe.Ingredients.Select(ingredient => ingredient.Clone()).ToList();

            // Set the data context of the window to the recipe
            DataContext = this.recipe;

            // Check if the recipe exceeds the calorie limit and display a warning if necessary
            CheckRecipeCalories();

            // Calculate and display the total calories of the recipe
            CalculateTotalCalories();
        }



        public event Action RecipeDetailsWindowClosedEvent;

        protected override void OnClosed(EventArgs e)
        {
            RecipeDetailsWindowClosedEvent?.Invoke();
            base.OnClosed(e);
        }

        //Checking if the recipe is over 300 calories
        private void CheckRecipeCalories()
        {
            int totalCalories = recipe.Ingredients.Sum(ingredient => ingredient.Calories);

            if (totalCalories > 300)
            {
                RecipeNameLabel.Foreground = Brushes.Red;
                MessageBox.Show("Warning: The recipe exceeds 300 calories!", "Calorie Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Calculates the total calories for a recipe
        private void CalculateTotalCalories()
        {
            int totalCalories = originalIngredients.Sum(ingredient => ingredient.Calories); // Use originalIngredients instead of recipe.Ingredients
            CalorieMessageLabel.Content = $"Total Calories: {totalCalories}";
        }

        private void btnResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            ResetIngredientQuantities();
            CalculateTotalCalories();
            MessageBox.Show("Ingredient quantities have been reset to their original values.", "Reset Quantities", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Allows the recipes quantities to be reset back to their defaults
        private void ResetIngredientQuantities()
        {
            // Reset the ingredient quantities to the original values
            for (int i = 0; i < recipe.Ingredients.Count; i++)
            {
                recipe.Ingredients[i].Quantity = originalIngredients[i].Quantity;
            }
        }
    }



    public static class RecipeIngredientExtensions
    {
        public static RecipeIngredient Clone(this RecipeIngredient ingredient)
        {

            return new RecipeIngredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, ingredient.Calories, ingredient.FoodGroup);
        }
    }
}
