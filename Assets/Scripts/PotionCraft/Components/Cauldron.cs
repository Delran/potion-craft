using System.Collections.Generic;
using UnityEngine;

namespace PotionCraft.Components
{
    public interface IBrewingCauldron
    {
        public void AddIngredient(PotionRecipe.Ingredient ingredient);
        public GameObject BrewPotion();
    }


    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Cauldron : MonoBehaviour, IBrewingCauldron
    {
        public Dictionary<PotionRecipe.Ingredient, uint> Ingredients { get; private set; } = new();

        [SerializeField] private SphereCollider cauldronCollider;
        private readonly PotionBrewer _potionBrewer = new();
        private uint _numberOfIngredients;

        private void Awake()
        {
            cauldronCollider ??= GetComponent<SphereCollider>();
            // Set the collider as trigger to interact with ingredients GameObject
            cauldronCollider.isTrigger = true;
        }


        public void AddIngredient(PotionRecipe.Ingredient ingredient)
        {
            // Keep track of the number of ingredients added
            _numberOfIngredients++;

            if (!Ingredients.ContainsKey(ingredient))
            {
                Ingredients[ingredient] = 1;
            }
            else
            {
                Ingredients[ingredient]++ ;
            }
        }

        public GameObject BrewPotion()
        {
            var ingredientQueue = new Queue<KeyValuePair<PotionRecipe.Ingredient, uint>>(Ingredients);

            var potionObject = _potionBrewer.MakePotion(ingredientQueue, _numberOfIngredients);

            if (potionObject is not null)
            {
                Debug.Log($"We made a {potionObject.name} !");
                potionObject.transform.position = transform.position;
            }
            else
            {
                Debug.Log("We failed to make any potion !!!");
            }

            Ingredients = new Dictionary<PotionRecipe.Ingredient, uint>();
            _numberOfIngredients = 0;

            return potionObject;
        }
    }
}

