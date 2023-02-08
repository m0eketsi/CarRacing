using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carSpeed;
    public float accRate;
    public Camera cam;
    public float steeringSpeed;
    public string keys;

    // Start is called before the first frame update
    void Start()
    {
        carSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        driveStraight();
        steering();
    }
    public void driveStraight()
    {
        carSpeed += accRate * Time.deltaTime;
        transform.Translate(Vector3.up * carSpeed * Time.deltaTime);
        cam.transform.Translate(Vector3.up * carSpeed * Time.deltaTime);
    }
    public void steering()
    {
        float dir = Input.GetAxis(keys);
        transform.position += new Vector3(dir * Time.deltaTime * steeringSpeed, 0, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("slow"))
        {
            carSpeed = carSpeed - 4;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            
        }
    }
}
