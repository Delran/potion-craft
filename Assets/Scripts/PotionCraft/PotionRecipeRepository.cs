using System.Collections.Generic;

namespace PotionCraft
{
    static class PotionRecipeRepository
    {
        public static HashSet<PotionRecipe> Recipes { get; } = new();

        static PotionRecipeRepository()
        {
            var healingPotion = new Dictionary<PotionRecipe.Ingredient, uint>()
            {
                [PotionRecipe.Ingredient.Garlic] = 2,
                [PotionRecipe.Ingredient.Aloe] = 1
            };

            Recipes.Add(new PotionRecipe("Healing Potion", healingPotion));

            var sicknessPotion = new Dictionary<PotionRecipe.Ingredient, uint>()
            {
                [PotionRecipe.Ingredient.Lichen] = 1,
                [PotionRecipe.Ingredient.Garlic] = 1
            };

            Recipes.Add(new PotionRecipe("Sickness Potion", sicknessPotion));
        }
    }
}