using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UI_Item : MonoBehaviour
{
    public string itemId;
    public Item item;
    public Image image;

    private void Start()
    {
        if (itemId == null) return;
        
        ItemData itemData = ItemDatabase.Instance.getItemDataById(itemId);

        if (itemData != null)
        {
            item = new Item(itemData, 1, 3);
            image.sprite = item.itemIcon;
        }
    }

    public void GenerateItem(string itemId)
    {
        ItemData itemData = ItemDatabase.Instance.getItemDataById(itemId);

        if (itemData != null)
        {
            item = new Item(itemData, 1, 3);
            Debug.Log(image.name);
            image.sprite = item.itemIcon;
        }
    }
}
