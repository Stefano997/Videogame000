using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI quantityText;

    private ItemData itemData;

    public ItemContextMenu contextMenu;

    public void Setup(ItemData item, int quantity)
    {
        itemData = item;

        //debug
        if (icon == null || nameText == null || quantityText == null)
        {
            Debug.LogError("Slot UI non configurato!");
            return;
        }

        icon.sprite = item.icon;
        nameText.text = item.itemName;
        quantityText.text = quantity.ToString();
    }

    public void OnClick()
    {
        Debug.Log("slot cliccato");

        if (contextMenu == null)
        {
            Debug.LogError("ContextMenu NON assegnato!");
            return;
        }

        contextMenu.Open(itemData, Input.mousePosition);
    }
}