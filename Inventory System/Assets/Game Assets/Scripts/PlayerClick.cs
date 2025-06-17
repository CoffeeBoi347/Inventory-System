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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null && hit.collider.gameObject.GetComponent<ObjectType>() != null)
                {
                    var getObjectType = hit.collider.gameObject.GetComponent<ObjectType>().scriptableItem;
                    InventoryManager.instance.AddItem(getObjectType);
                }
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
