using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 1f + Mathf.Sin(Time.time * 3f) * 0.1f, 0);
    }
}