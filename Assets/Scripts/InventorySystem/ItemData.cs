using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string itemId;
    public ItemType itemType;
    public Sprite itemIcon;
    public string description;
    public int? maxStack = null;
    public int maxCharge = 1;
}
