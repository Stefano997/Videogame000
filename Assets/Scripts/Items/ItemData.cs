using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public GameObject worldPrefab;
    public string itemName; // best practice, "name" already used
    public Sprite icon;
    public bool stackable = true;
    [TextArea]
    public string description;
    public int hungerRestore;
}