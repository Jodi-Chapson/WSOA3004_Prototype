using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    
    public Transform target;
    public float SmoothnessOfCamera = 1;
    public float yPosRestriction = -1;
    public float VisionForward = 1;
    public float VisionForwardThreshold = 0.1f;
    public float VisionForwardSpeed = 0.5f;
    float offsetFromZ;
    float nextTimeToSearch = 0;

    Vector3 PlayerPosition;
    Vector3 Velocity;
    Vector3 VisionForwardPos;

    void Start()
    {
        PlayerPosition = target.position;
        offsetFromZ = (transform.position - target.position).z;
        transform.parent = null;
    }


    void Update()
    {

        if (target == null)
        {
            FindPlayer();
            return;
        }


        float xMoveDelta = (target.position - PlayerPosition).x;

        bool updateVisionForwardTarget = Mathf.Abs(xMoveDelta) > VisionForwardThreshold;

        if (updateVisionForwardTarget)
        {
            VisionForwardPos = VisionForward * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            VisionForwardPos = Vector3.MoveTowards(VisionForwardPos, Vector3.zero, Time.deltaTime * VisionForwardSpeed);
        }

        Vector3 aheadTargetPos = target.position + VisionForwardPos + Vector3.forward * offsetFromZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref Velocity, SmoothnessOfCamera);

        newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y, yPosRestriction, Mathf.Infinity), newPos.z);

        transform.position = newPos;

        PlayerPosition = target.position;
    }

    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
                target = searchResult.transform;
            nextTimeToSearch = Time.time + 0.5f;
        }
    }
}
