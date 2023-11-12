using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float duration;
    public float fadeDelay;

    void Start()
    {
        duration += Random.Range(-1f, 1f);
        Destroy(gameObject, duration + fadeDelay);
    }

    void Update()
    {
        fadeDelay -= Time.deltaTime;

        if(fadeDelay <= 0f)
        {
            Color color = this.GetComponent<Renderer>().material.color;
            float fadeAmount = color.a - (Time.deltaTime / duration);

            color = new Color(color.r, color.g, color.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = color;
        }
    }
}
