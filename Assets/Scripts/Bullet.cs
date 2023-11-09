using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public GameObject particle;
    public int particleCount;
    public GameObject explosionMark;
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
            //source.PlayOneShot(explosionSound);

            Destroy(collision.gameObject);

            var explosionPos = new Vector3(transform.position.x, 0.01f, transform.position.z);
            Instantiate(explosionMark, explosionPos, transform.rotation);

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
