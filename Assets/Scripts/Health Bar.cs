using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health health;

    void Update()
    {
        var scaleX = health.hp / 5f;
        transform.localScale = new Vector3(scaleX, 1, 1);
    }
}
