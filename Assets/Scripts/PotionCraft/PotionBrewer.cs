using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PotionCraft
{
    public class PotionBrewer
    {
        private readonly HashSet<PotionRecipe> _potionRecipes;

        public PotionBrewer()
        {
            // Get the list of recipes from the repository
            _potionRecipes = PotionRecipeRepository.Recipes;
        }

        public GameObject MakePotion(Queue<KeyValuePair<PotionRecipe.Ingredient, uint>> ingredients, uint numberOfIngredients)
        {
            if (ingredients.Count == 0) return null;

            // Only test recipes that have the same number of ingredients in them
            foreach (var recipe in _potionRecipes.Where(recipe => recipe.NumberOfIngredients == numberOfIngredients))
            {
                // Make a copy of the ingredient queue for each loop
                var ingredientsCopy = ingredients;

                PotionRecipe.Ingredient ingredient;
                uint quantity;

                // Iterate over the queue as long as the ingredients are matching
                do
                {
                    // If the ingredient Queue is empty, we matched all the ingredients
                    if (ingredientsCopy.Count == 0)
                    {
                        // Return the potion associated with this recipe
                        return recipe.CreatePotion();
                    }

                    (ingredient, quantity) = ingredientsCopy.Dequeue();

                } while (recipe.IsMadeWith(ingredient, quantity));

            }

            // Otherwise we failed to make a potion out of this recipe
            return null;
        }
    }
}