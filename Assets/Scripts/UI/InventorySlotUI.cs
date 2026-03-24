using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI quantityText;

    public void Setup(ItemData item, int quantity)
    {
        if (icon == null || quantityText == null)
        {
            Debug.LogError("Slot UI non configurato!");
            return;
        }

        icon.sprite = item.icon;
        quantityText.text = quantity.ToString();
    }
}