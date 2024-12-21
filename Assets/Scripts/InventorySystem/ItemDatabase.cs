using System.Collections.Generic;

public class ItemDatabase : Singleton<ItemDatabase>
{
    public List<ItemData> database = new List<ItemData>();
    public List<Recipe> recipes;

    public ItemData getItemDataById(string itemId)
    {
        ItemData itemData = database.Find(i => i.itemId == itemId);

        if (itemData != null)
        {
            return itemData;
        }

        return null;
    }

    public string checkForRecipe(string id1, string id2)
    {
        Recipe foundRecipe = recipes.Find(recipe =>
        {
            if (id1 == recipe.ingredient1.itemId)
            {
                if (id2 == recipe.ingredient2.itemId)
                {
                    return true;
                }
            }

            else if (id1 == recipe.ingredient2.itemId)
            {
                if (id2 == recipe.ingredient1.itemId)
                {
                    return true;
                }
            }

            return false;
        });

        if (foundRecipe == null) return null;

        return foundRecipe.product.itemId;
    }
}

[System.Serializable]
public class Recipe
{
    public ItemData ingredient1;
    public ItemData ingredient2;
    public ItemData product;
}