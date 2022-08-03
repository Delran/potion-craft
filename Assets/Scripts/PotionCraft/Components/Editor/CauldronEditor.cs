using System.Linq;
using UnityEditor;
using UnityEngine;

namespace PotionCraft.Components.Editor
{
    [CustomEditor(typeof(Cauldron))]
    public class CauldronEditor : UnityEditor.Editor
    {
        private Cauldron _cauldron;

        private void OnEnable()
        {
            _cauldron = (Cauldron) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();


            EditorGUILayout.Space();
            var ingredients = _cauldron.Ingredients;

            if (ingredients.Any())
            {
                GUILayout.Label("Ingredients :");

                EditorGUILayout.Space();

                foreach (var (ingredient, quantity) in ingredients)
                {
                    GUILayout.Label($"{ingredient} : {quantity}");
                }
            }

            EditorGUILayout.Space();
            if (GUILayout.Button("BrewPotion"))
            {
                _cauldron.BrewPotion();
            }
        }
    }
}