using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    public bool autoDestroy = true;
    public int particleCount;
    public GameObject particle;
    public GameObject explosionMark;
    public AudioClip hitSound;
    public AudioClip destroySound;

    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Damage()
    {
        hp--;
        if (hp == 0)
            Die();
        else
            source.PlayOneShot(hitSound);
    }

    public void Die()
    {
        if (autoDestroy)
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < particleCount; i++)
        {
            var offset = Random.insideUnitSphere;
            particle.transform.localScale = new Vector3(Random.Range(0.01f, 1f), Random.Range(0.01f, 1f), Random.Range(0.01f, 1f));
            Instantiate(particle, transform.position + offset, transform.rotation);
        }

        var explosionPos = new Vector3(transform.position.x, 0.01f, transform.position.z);
        explosionMark.GetComponent<AudioSource>().clip = destroySound;
        Instantiate(explosionMark, explosionPos, transform.rotation);
    }
}
