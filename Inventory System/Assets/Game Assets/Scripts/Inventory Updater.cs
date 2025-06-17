using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUpdater : MonoBehaviour
{
    public ItemScriptable addedItem;
    public Sprite addedSprite;
    public InventoryUpdater AddInventory(List<Sprite> newSprite, List<ItemScriptable> inventoryHolder, ItemScriptable newItem)
    {
        Debug.Log("ADD INVENTORY!");
        if(newItem != null)
        {
            newSprite.Add(newItem.itemSprite);
            inventoryHolder.Add(newItem);

            addedItem = newItem;
            addedSprite = newSprite[newSprite.Count - 1];

            return this;
        }

        else if(newItem == null)
        {
            Debug.Log("Item is empty!");
            return null;
        }

        return null;
    }

    public void CreateUIElement(GameObject prefab, Transform parent, Sprite newSprite)
    {
        GameObject buttonDataObj = GameObject.Instantiate(prefab, parent);
        buttonDataObj.GetComponentsInChildren<Image>()[1].sprite = newSprite;
    }
}
