using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Button _inventoryButton;
    public ItemType typeItem;
    public Image buttonImage;

    public void Setup(GameObject buttonObj)
    {
        if(buttonImage != null)
        {
            var getComponentObjectType = buttonObj.GetComponent<ObjectType>();
            typeItem = getComponentObjectType.typeItem;
        }
    }
}