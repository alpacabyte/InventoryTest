using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public string itemId;
    public ItemType itemType;
    public Sprite itemIcon;
    public string description;
    public int maxStack = 1;
    public int maxCharge = 1;

    public int quantity = 1;
    public int charge = 1;

    public Item(ItemData data, int? quantity = 1, int? charge = 1)
    {
        itemName = data.itemName;
        itemType = data.itemType;
        itemIcon = data.itemIcon;
        description = data.description;
        maxStack = data.maxStack ?? 999;
        maxCharge = data.maxCharge;
        itemId = data.itemId;

        if (quantity != null)
        {
            this.quantity = (int)quantity;
        }

        else
        {
            this.quantity = 1;
        }

        if (charge != null)
        {
            this.charge = (int)charge;
        }

        else
        {
            this.charge = maxCharge;
        }
    }
}
