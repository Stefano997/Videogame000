using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    void Start()
    {
        GameTimeManager.Instance.OnTimeChanged += UpdateClock;
        UpdateClock();
    }

    void UpdateClock()
    {
        clockText.text = GameTimeManager.Instance.GetTimeString();
    }
}