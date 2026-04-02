using UnityEngine;

/*
 *   Gestione inventario
 */

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public GameObject inventoryPanel;
    public Transform parent;
    public Inventory inventory;
    public ItemContextMenu contextMenu;

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
            if (inventoryPanel.activeSelf)
                UIManager.Instance.CloseMainPanel();
            else
                UIManager.Instance.OpenMainPanel(inventoryPanel);
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
            GameObject obj = Instantiate(slotPrefab, parent); // creo UI

            InventorySlotUI slotUI = obj.GetComponent<InventorySlotUI>(); // Prendo componente UI
            slotUI.contextMenu = contextMenu; // passo i riferimenti

            slotUI.Setup(slot.item, slot.quantity); // faccio setup con i dati
        }
    }
}