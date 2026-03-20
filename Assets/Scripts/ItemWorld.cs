using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public string itemName = "Mushroom";

    public void Collect()
    {
        Debug.Log("Raccolto: " + itemName);
        Destroy(gameObject);
    }
}