using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Action Events")]

    public static Action<InventoryUpdater> OnAddItem;

    [Header("Instance")]

    public static InventoryManager instance;
    public InventoryUpdater updater;

    [Header("Storing Data")]

    public int currentItems = 0;
    public List<ItemScriptable> inventory = new List<ItemScriptable>();
//  public List<GameObject> currentInventoryObjs = new List<GameObject>();
    public List<Sprite> inventorySprites = new List<Sprite>();
    public List<GameObject> deletedObjs = new List<GameObject> ();
    public GameObject inventoryObj;
    public GameObject inventoryParent;

    [Header("Other Components")]

    public UIManager _UIManager;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        inventory.Clear();
        inventorySprites.Clear();   
    }

    #region adding and removing items

    public void AddItem(ItemScriptable scriptableItem)
    {
        currentItems++;
        updater.AddInventory(inventorySprites, inventory, scriptableItem);
        updater.CreateUIElement(inventoryObj, inventoryParent.transform, scriptableItem.itemSprite);
        OnAddItem?.Invoke(updater);
    }

    public void RemoveItem(int holdIndex)
    {
        if(holdIndex >= 0 && holdIndex < inventory.Count)
        {
            var itemToRemove = inventory[holdIndex];
            DropItem(holdIndex);
            inventory.Remove(itemToRemove);
            inventorySprites.Remove(inventorySprites[holdIndex]);
        }

        else if(holdIndex > inventory.Count || holdIndex < 0)
        {
            Debug.Log("Out of index!");
        }
    }

    #endregion

    public void DropItem(int index)
    {
        UIManager.instance.DestroyItem(index);
        if (inventory[index].itemType == UIManager.instance.buttons[index].GetComponent<InventoryItem>().typeItem)
        {
            UIManager.instance.DestroyItem(index);
        }
    }
}