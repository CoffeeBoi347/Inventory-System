using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public ItemScriptable itemScriptable;
    public Sprite currentItemClicked;

    private void OnMouseDown()
    {
        Setup(itemScriptable);
    }

    public void Setup(ItemScriptable itemScriptable)
    {
        currentItemClicked = itemScriptable.itemSprite;
        InventoryManager.instance.AddItem(itemScriptable);
    }
}
