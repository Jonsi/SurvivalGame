using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingGuide : MonoBehaviour
{
    public List<ItemRecipe> Recipes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class ItemRecipe
{
    public Item Result;
    public List<RecipeIngredient> recipeIngredients;
}

[System.Serializable]
public class RecipeIngredient
{
    public ItemType Type;
    public int Amount;
}
