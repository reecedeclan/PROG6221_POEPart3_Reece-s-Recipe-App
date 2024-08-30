using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using PROG6221_ST10043367_POEPart3;

namespace PROG6221_ST10043367_POEPart3
{
    public partial class InputRecipeWindow : Window
    {
        public event EventHandler<RecipeEventArgs> RecipeAdded;

        public InputRecipeWindow()
        {
            InitializeComponent();
        }

        // Event handler for the Save button click event
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = tbxName.Text;
            List<RecipeIngredient> ingredients = new List<RecipeIngredient>();
            List<string> steps = new List<string>();
            int totalCalories = 0;

            // Retrieve ingredient information from the UI
            foreach (var child in spIngredients.Children)
            {
                if (child is StackPanel ingredientStackPanel)
                {
                    if (ingredientStackPanel.Children[0] is TextBox tbxIngredient)
                    {
                        string ingredientName = tbxIngredient.Text;

                        // Check if all ingredient fields are valid
                        if (ingredientStackPanel.Children[1] is TextBox tbxQuantity &&
                            ingredientStackPanel.Children[2] is TextBox tbxUnit &&
                            ingredientStackPanel.Children[3] is TextBox tbxCalories &&
                            ingredientStackPanel.Children[4] is TextBox tbxFoodGroup)
                        {
                            double quantity;
                            if (double.TryParse(tbxQuantity.Text, out quantity))
                            {
                                int calories;
                                if (int.TryParse(tbxCalories.Text, out calories))
                                {
                                    // Create a RecipeIngredient object and add it to the list
                                    RecipeIngredient ingredient = new RecipeIngredient(ingredientName, quantity.ToString(), tbxUnit.Text, calories, tbxFoodGroup.Text);
                                    ingredients.Add(ingredient);
                                    totalCalories += calories;
                                }
                            }
                        }
                    }
                }
            }

            // Retrieve step information from the UI
            foreach (var child in spSteps.Children)
            {
                if (child is TextBox stepTextBox)
                {
                    string step = stepTextBox.Text;
                    steps.Add(step);
                }
            }

            // Check if total calories exceed the limit
            if (totalCalories > 300)
            {
                MessageBoxResult result = MessageBox.Show("The recipe exceeds 300 calories. Do you still want to add it?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            // Create a new Recipe object and raise the RecipeAdded event
            Recipe recipe = new Recipe(recipeName, ingredients, steps);
            RecipeAdded?.Invoke(this, new RecipeEventArgs(recipe));
            Close();
        }


        // Event handler for the Add Ingredient button click event
        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Create UI elements for a new ingredient
            StackPanel ingredientStackPanel = new StackPanel();
            ingredientStackPanel.Orientation = Orientation.Horizontal;

            TextBox tbxIngredient = new TextBox();
            tbxIngredient.Width = 100;

            TextBox tbxQuantity = new TextBox();
            tbxQuantity.Width = 50;

            TextBox tbxUnit = new TextBox();
            tbxUnit.Width = 50;

            TextBox tbxCalories = new TextBox();
            tbxCalories.Width = 70;

            TextBox tbxFoodGroup = new TextBox();
            tbxFoodGroup.Width = 80;

            Button btnRemoveIngredient = new Button();
            btnRemoveIngredient.Content = "Remove";
            btnRemoveIngredient.Click += btnRemoveIngredient_Click;

            // Add the UI elements to the ingredientStackPanel
            ingredientStackPanel.Children.Add(tbxIngredient);
            ingredientStackPanel.Children.Add(tbxQuantity);
            ingredientStackPanel.Children.Add(tbxUnit);
            ingredientStackPanel.Children.Add(tbxCalories);
            ingredientStackPanel.Children.Add(tbxFoodGroup);
            ingredientStackPanel.Children.Add(btnRemoveIngredient);

            // Add the ingredientStackPanel to the container stack panel
            spIngredients.Children.Add(ingredientStackPanel);
        }

        // Event handler for the Remove Ingredient button click event
        private void btnRemoveIngredient_Click(object sender, RoutedEventArgs e)
        {
            Button btnRemoveIngredient = (Button)sender;
            StackPanel ingredientStackPanel = (StackPanel)btnRemoveIngredient.Parent;
            spIngredients.Children.Remove(ingredientStackPanel);
        }

        // Event handler for the Add Step button click event
        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            // Create a new step TextBox
            TextBox stepTextBox = new TextBox();
            stepTextBox.Width = 200;

            // Add the step TextBox to the container stack panel
            spSteps.Children.Add(stepTextBox);
        }

        // Event handler for the Remove Step button click event
        private void btnRemoveStep_Click(object sender, RoutedEventArgs e)
        {
            Button btnRemoveStep = (Button)sender;
            TextBox stepTextBox = (TextBox)btnRemoveStep.Parent;
            spSteps.Children.Remove(stepTextBox);
        }
    }
}
