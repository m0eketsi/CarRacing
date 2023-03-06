using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carSpeed;
    public float accRate;
    public float steeringSpeed;
    public string keys;
    public bool canMove;
    public float moveTime;
    public GameObject waypoint;
    public Camera carCam;
    public GameObject zoomUI;
    private bool _crossedFinishLine = false;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        carSpeed = 5;
        waypoint.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.StartGame())
        {
            driveStraight();
            steering();
        }
    }
    public void driveStraight()
    {
        carSpeed += accRate * Time.deltaTime;
        waypoint.transform.Translate(Vector3.up * carSpeed * Time.deltaTime);
        /*transform.Translate(Vector3.up * carSpeed * Time.deltaTime);*/
    }
    public void steering()
    {
        if (transform.position == new Vector3(transform.position.x, 4, transform.position.z))
        {

        }
        transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, steeringSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A) && canMove)
        {
            StartCoroutine(moveTimer());
            waypoint.transform.position = new Vector3(transform.position.x - 2.7f, transform.position.y + 0.25f, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) && canMove)
        {
            StartCoroutine(moveTimer());
            waypoint.transform.position = new Vector3(transform.position.x + 2.7f, transform.position.y + 0.25f, 0);
        }
    }
    IEnumerator moveTimer()
    {
        canMove = false;
        yield return new WaitForSeconds(moveTime);
        canMove = true;
    }
        private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("obstacle"))    
        {
            LevelManager.Instance.GameOver();
        }
    }
    public bool CrossedFinishLine()
    {
        return _crossedFinishLine;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Start Line"))
        {
            LevelManager.Instance.StartGasMeter();
        }

         if(other.gameObject.CompareTag("Finish Line"))
        {
            _crossedFinishLine = true;
            LevelManager.Instance.YouWon();
        }
        if (other.gameObject.CompareTag("slow"))
        {
            carSpeed = carSpeed / 4;
        }
        if (other.gameObject.CompareTag("boost"))
        {
            StartCoroutine(hitBoost());
        }
    }
    IEnumerator hitBoost()
    {
        carSpeed = carSpeed + 6;
        carCam.orthographicSize = 9.4f;
        zoomUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        carSpeed = carSpeed - .75f;
        carCam.orthographicSize = 9.6f;
        zoomUI.SetActive(false);
    }
}
