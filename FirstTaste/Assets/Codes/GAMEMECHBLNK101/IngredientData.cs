using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredient", menuName = "Chopping/IngredientData")]
public class IngredientData : ScriptableObject
{
    public string ingredientName;
    public Sprite rawSprite;
    public Sprite choppedSprite;
}
