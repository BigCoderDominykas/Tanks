using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destructionObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            for(int i = 0; i < 5; i++)
                Instantiate(destructionObject, new Vector3(transform.position.x + i / 1.2f, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }
}
