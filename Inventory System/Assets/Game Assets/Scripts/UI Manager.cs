using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public List<Image> buttonChildrenImage = new List<Image>();
    public List<Button> buttons = new List<Button>();

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

    private void Start()
    {
        foreach (var button in buttons)
        {
            var getChildren = button.GetComponentsInChildren<Image>()[0];
            buttonChildrenImage.Add(getChildren);
        }
    }

    private void OnEnable()
    {
        InventoryManager.OnAddItem += UpdateInventory;
    }

    private void OnDisable()
    {
        InventoryManager.OnAddItem -= UpdateInventory;
    }

    public void UpdateInventory(InventoryUpdater updater)
    {
        int index = InventoryManager.instance.inventorySprites.Count - 1;
        if (index <= buttonChildrenImage.Count - 1)
        {
            buttonChildrenImage[index].sprite = updater.addedSprite;
        }
    }

}