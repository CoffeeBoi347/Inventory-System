using UnityEngine;

public class ObjectType : MonoBehaviour
{
    public ItemScriptable scriptableItem;
    public ItemType typeItem;
    public int index;

    private void Start()
    {
        SetupScriptableItem();
    }

    public ItemScriptable SetupScriptableItem()
    {
        if(scriptableItem != null)
        {
            typeItem = scriptableItem.itemType;
            return scriptableItem;
        }

        return null;
    }
}