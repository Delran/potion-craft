using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PotionCraft
{
    public class PotionRecipe
    {
        public enum Ingredient
        {
            Garlic,
            Aloe,
            Lichen
        }

        public string Name { get; }
        public uint NumberOfIngredients { get; }

        // A dictionary containing the quantity of
        // each ingredient needed to make this potion
        private Dictionary<Ingredient, uint> Recipe { get; }

        // The Potion GameObject can contain the prefab
        // corresponding to this potion and its components
        private readonly GameObject _potionPrefab;

        public PotionRecipe(string name, Dictionary<Ingredient, uint> recipe, GameObject potionPrefab = null)
        {
            Name = name;
            Recipe = recipe;
            NumberOfIngredients = (uint)Recipe.Values.Sum(u => u);
            _potionPrefab = potionPrefab;
        }

        // Check if the recipe is made with the given ingredient and if the amount of it is correct
        public bool IsMadeWith(Ingredient ingredient, uint quantity)
        {
            if (!Recipe.ContainsKey(ingredient)) return false;

            return Recipe[ingredient] == quantity;
        }

        public GameObject CreatePotion()
        {
            // Instantiate the potion prefab or create a new empty object for demonstration
            return _potionPrefab ? Object.Instantiate(_potionPrefab) : new GameObject(Name);
        }
    }
}