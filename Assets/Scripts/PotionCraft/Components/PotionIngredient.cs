using UnityEngine;

namespace PotionCraft.Components
{
    public class PotionIngredient: MonoBehaviour
    {
        [SerializeField] private GameObject cauldronGameObject;

        [SerializeField] private PotionRecipe.Ingredient ingredient;

        private SphereCollider _cauldronCollider;

        private IBrewingCauldron _cauldron;

        private void Awake()
        {
            if (cauldronGameObject is not null)
            {
                _cauldron = cauldronGameObject.GetComponent<IBrewingCauldron>();

                if (_cauldron is not null) return;
            }

            var ingredientObject = gameObject;
            ingredientObject.name += " [IN ERROR]";
            ingredientObject.SetActive(false);

            throw new MissingComponentException($"{ingredientObject.name} is missing the cauldron gameobject");
        }

        private void Start()
        {
            _cauldronCollider = cauldronGameObject.GetComponent<SphereCollider>();

            gameObject.name = ingredient.ToString();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other != _cauldronCollider) return;

            _cauldron.AddIngredient(ingredient);
            Destroy(gameObject);
        }
    }
}