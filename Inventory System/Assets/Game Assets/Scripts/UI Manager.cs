using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; 
 // public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public List<Image> buttonChildrenImage = new List<Image>();
    public List<GameObject> buttons = new List<GameObject>();

    private void Awake() 
    {
        //ensuring only a single instance persists across all scenes

        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        //for each button in the list, we access the first image object and add that to the buttonChildrenImage list
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

        else if(index > buttonChildrenImage.Count - 1)
        {
            Debug.LogError("Out of index boundaries! Throw an object to remove it.");
        }
    }

    public void AddButton(GameObject buttonType, Image childImage)
    {
        buttons.Add(buttonType);
        buttonChildrenImage.Add(childImage);
      //GameObject buttonTypeObj = Instantiate(buttonType, buttonParent.transform);
      //Image getButtonImage = buttonTypeObj.GetComponentInChildren<Image>();
      //getButtonImage.sprite = buttonImage;
    }

    public void DestroyItem(int index)
    {
        if(index < 0 || index > buttons.Count)
        {
            Debug.LogError("Invalid index!");
            return;
        }

        GameObject toDestroy = buttons[index];
        buttons.RemoveAt(index);
        buttonChildrenImage.RemoveAt(index);
        Destroy(toDestroy);
    }

}