using TMPro;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    [SerializeField] private TMP_Text indexTxt;
    public static PlayerClick instance;
    public GameObject itemToDelete;
    public ItemScriptable itemScriptable;
    public Sprite currentItemClicked;
    public int indexHolder;
    private GameObject previouslyDeleted;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        foreach (var inp in Input.inputString)
        {
            if (char.IsDigit(inp))
            {
                indexHolder = int.Parse(inp.ToString());
                indexTxt.text = indexHolder.ToString();
            }
        }

        InputControls();
    }

    void InputControls()
    {
        if(UIManager.instance.buttons.Count > 0 && indexHolder < UIManager.instance.buttons.Count)
        {
            itemToDelete = UIManager.instance.buttons[indexHolder];

            if (previouslyDeleted != null && previouslyDeleted != itemToDelete)
            {
                previouslyDeleted.transform.localScale = Vector3.one;
            }

            previouslyDeleted = itemToDelete;

            itemToDelete.transform.localScale = Vector3.one * 2f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.zero);

            if(hit.collider != null)
            {
                var getComponentObjectType = hit.collider.GetComponent<ObjectType>();
                Setup(getComponentObjectType.scriptableItem);
                Destroy(hit.collider.gameObject);
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
