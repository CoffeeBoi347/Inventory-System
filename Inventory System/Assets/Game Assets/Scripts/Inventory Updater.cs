using System.Collections.Generic;
using UnityEngine;

public class InventoryUpdater
{
    public ItemScriptable addedItem;
    public Sprite addedSprite;
    public InventoryUpdater AddInventory(List<Sprite> newSprite, List<ItemScriptable> inventoryHolder, ItemScriptable newItem)
    {
        if(newItem != null)
        {
            newSprite.Add(newItem.itemSprite);
            inventoryHolder.Add(newItem);

            addedItem = newItem;
            addedSprite = newSprite[newSprite.Count - 1];
        }

        return this;
    }

    public void CreateUIElement(GameObject prefab, Transform parent)
    {
        GameObject.Instantiate(prefab, parent);
    }
}
