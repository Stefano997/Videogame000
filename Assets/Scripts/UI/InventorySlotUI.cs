using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI quantityText;

    public void Setup(ItemData item, int quantity)
    {
        if (icon == null || nameText == null || quantityText == null)
        {
            Debug.LogError("Slot UI non configurato!");
            return;
        }

        icon.sprite = item.icon;
        nameText.text = item.itemName;
        quantityText.text = quantity.ToString();
    }
}