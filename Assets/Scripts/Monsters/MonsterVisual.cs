using UnityEngine;

/*
 *   Controllore logico della grafica del mostro
 *   
 */

public class MonsterVisual : MonoBehaviour
{
    public MonsterStats stats;
    public GameObject hungerBubble;

    void Start()
    {
        hungerBubble.SetActive(false);

        stats.OnHungry += () => hungerBubble.SetActive(true);
        stats.OnFed += () => hungerBubble.SetActive(false);
    }
}