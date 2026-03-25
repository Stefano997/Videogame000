using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public GameObject inventoryPanel;
    public Transform parent;
    public Inventory inventory;

    void Start()
    {
        inventoryPanel.SetActive(false);
        inventory.OnInventoryChanged += UpdateUI;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Premuto I");
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    void UpdateUI()
    {
        // pulisci
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }

        // ricrea
        foreach (var slot in inventory.items)
        {
            GameObject obj = Instantiate(slotPrefab, parent);

            InventorySlotUI slotUI = obj.GetComponent<InventorySlotUI>();
            slotUI.Setup(slot.item, slot.quantity);
        }
    }
}