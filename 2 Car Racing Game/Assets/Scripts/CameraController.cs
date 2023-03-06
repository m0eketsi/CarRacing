using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float FollowOffset = 0;
    private Vector3 velocity = Vector3.zero;
    private bool nearEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 210)
        {
            nearEnd = true;
        }
        if (target && !nearEnd)
        {
            Vector3 movePos = new Vector3(target.position.x - target.position.x, target.position.y + FollowOffset, -10f);
            transform.position = Vector3.SmoothDamp(transform.position, movePos, ref velocity, 0.1f);
        }
    }
}
