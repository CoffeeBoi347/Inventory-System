using System.Dynamic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public ItemScriptable itemScriptable;
    public Sprite currentItemClicked;
    public int indexHolder;

    private void Update()
    {
        foreach (var inp in Input.inputString)
        {
            if (char.IsDigit(inp))
            {
                indexHolder = int.Parse(inp.ToString());
            }
        }

        InputControls();
    }

    void InputControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.zero);

            if(hit.collider != null)
            {
                var getComponentObjectType = hit.collider.GetComponent<ObjectType>();
                Setup(getComponentObjectType.scriptableItem);
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            InventoryManager.instance.RemoveItem(indexHolder);
        }
    }

    public void Setup(ItemScriptable itemScriptable)
    {
        currentItemClicked = itemScriptable.itemSprite;
        InventoryManager.instance.AddItem(itemScriptable);
    }
}
