using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public ItemData itemData;

    public void Collect(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();

        if (inventory != null)
        {
            inventory.AddItem(itemData);
        }

        Destroy(gameObject);
    }
}