using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public void BuyItem(string currencyId, int currencyQuantity, string itemId, int itemQuantity)
    {
        if (HasItem(currencyId, currencyQuantity)) {
            RemoveItem(currencyId, currencyQuantity);
            AddItem(itemId, itemQuantity);
        }
    }

    public void AddItem(string itemId, int? quantity = null, int? charge = null)
    {
        Item existingItem = items.Find(i => i.itemId == itemId);

        if (existingItem != null && existingItem.maxStack > 1)
        {
            existingItem.quantity += quantity ?? 1;
            return;
        }

        ItemData itemData = ItemDatabase.Instance.getItemDataById(itemId);

        if (itemData != null )
        {
            items.Add(new Item(itemData, quantity, charge));
        }
    }

    public void RemoveItem(string itemId, int? quantity = null, int? charge = null)
    {
        Item existingItem = items.Find(i => i.itemId == itemId);
        if (existingItem != null)
        {
            existingItem.quantity -= quantity ?? 1;
            if (existingItem.quantity <= 0)
            {
                items.Remove(existingItem);
            }
        }
    }

    public bool HasItem(string itemId, int? quantity = null)
    {
        Item existingItem = items.Find(i => i.itemId == itemId);
        return existingItem != null && existingItem.quantity >= (quantity ?? 1);
    }
}
