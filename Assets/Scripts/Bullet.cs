using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public GameObject particle;
    public int particleCount;
    public AudioClip shotSound;
    public AudioClip explosionSound;

    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(shotSound);
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Destructible")
        {
            collision.gameObject.GetComponent<Health>().Damage();

            for (int i = 0; i < particleCount; i++)
            {
                var offset = Random.insideUnitSphere;
                particle.transform.localScale = new Vector3(Random.Range(0.01f, 1f), Random.Range(0.01f, 1f), Random.Range(0.01f, 1f));
                Instantiate(particle, transform.position + offset, transform.rotation);
            }
        }

        Destroy(gameObject);
    }
}
