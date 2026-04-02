using UnityEngine;

public class ItemContextMenu : MonoBehaviour
{
    public Inventory inventory;
    public MonsterStats monster;
    public Transform player;

    public RectTransform panel; // il menu visivo

    private ItemData currentItem;

    public void Open(ItemData item, Vector3 clickPosition)
    {
        Debug.Log("Apro menu");
        currentItem = item;

        gameObject.SetActive(true); // attiva overlay (background + panel)

        panel.position = clickPosition; // posiziona il menu dove avveiene il click

        UIManager.Instance.OpenContextMenu(this);
    }

    public void Use()
    {
        if (monster == null || currentItem == null) return;

        monster.Feed(currentItem.hungerRestore);
        inventory.RemoveItem(currentItem);

        Close();
    }

    public void Drop()
    {
        inventory.RemoveItem(currentItem);

        if (currentItem.worldPrefab != null)
        {
            Instantiate(
                currentItem.worldPrefab,
                player.position,
                Quaternion.identity
            );
        }

        Close();
    }

    public void Close()
    {
        gameObject.SetActive(false); // 🔥 chiude overlay + background + panel
    }
}