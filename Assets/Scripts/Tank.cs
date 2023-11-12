using UnityEngine;

public class Tank : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public KeyCode shootKey;

    public GameObject bullet;
    public Transform shootPoint;

    public string verticalAxis;
    public string horizontalAxis;

    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        var ver = Input.GetAxis(verticalAxis);
        //transform.position += transform.forward * speed * ver * Time.deltaTime;
        GetComponent<Rigidbody>().velocity = transform.forward * speed * ver;

        var hor = Input.GetAxis(horizontalAxis);
        transform.Rotate(0, rotateSpeed * hor * Time.deltaTime, 0);

        if (ver != 0 || hor != 0)
        {
            source.mute = false;
        }
        else source.mute = true;

        if (Input.GetKeyDown(shootKey))
        {
            Instantiate(bullet, shootPoint.position, transform.rotation);
        }
    }
}
