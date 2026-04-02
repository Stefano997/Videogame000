using UnityEngine;
using System;

public class MonsterStats : MonoBehaviour
{
    public float hunger = 75;
    public int maxHunger = 100;

    public int hungerThreshold = 80;
    public int fullThreshold = 20;

    public bool isHungry = false;

    public event Action OnHungry;
    public event Action OnFed;

    void Start()
    {
        GameTimeManager.Instance.OnTimeChanged += IncreaseHunger;
    }

    void IncreaseHunger()
    {
        hunger += 0.8f;

        if (hunger > maxHunger)
            hunger = maxHunger;

        CheckHungerState();
    }

    public void Feed(int amount)
    {
        hunger -= amount;

        if (hunger < 0)
            hunger = 0;

        CheckHungerState();
    }
    
    void CheckHungerState()
    {
        bool wasHungry = isHungry;

        if (hunger > hungerThreshold)
            isHungry = true;
        else if (hunger < fullThreshold)
            isHungry = false;

        // trigger eventi SOLO se cambia stato
        if (!wasHungry && isHungry)
            OnHungry?.Invoke();

        if (wasHungry && !isHungry)
            OnFed?.Invoke();
    }
}