using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public GameObject particle;
    public int particleCount;
    public GameObject explosionMark;

    AudioSource source;

    void Start()
    {
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
            Destroy(collision.gameObject);

            var explosionPos = new Vector3(transform.position.x, 0.01f, transform.position.z);
            Instantiate(explosionMark, explosionPos, transform.rotation);

            for (int i = 0; i < particleCount; i++)
            {
                var offset = Random.insideUnitSphere;
                print(offset);
                Instantiate(particle, transform.position + offset, transform.rotation);
            }
        }

        Destroy(gameObject);
    }
}
