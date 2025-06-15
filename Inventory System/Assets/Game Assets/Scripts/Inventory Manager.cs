using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Action Events")]

    public static Action<InventoryUpdater> OnAddItem;

    [Header("Instance")]

    public static InventoryManager instance;
    public UIManager _UIManager;

    [Header("Storing Data")]

    public List<ItemScriptable> inventory = new List<ItemScriptable>();
    public List<Sprite> inventorySprites = new List<Sprite>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


    public void AddItem(ItemScriptable scriptableItem)
    {
        InventoryUpdater updater = new InventoryUpdater();
        updater.AddInventory(inventorySprites, inventory, scriptableItem);
        OnAddItem?.Invoke(updater);
    }
}