using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam2DFollow : MonoBehaviour
{
	public Transform target;
	public Vector3 targetpos;
	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;
	public float yPosRestriction = -1;
	public float ymod;

	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;

	float nextTimeToSearch = 0;

	// Use this for initialization
	void Start()
	{
		if (target != null)
		{

			lastTargetPosition = target.position;
			offsetZ = (transform.position - target.position).z;
			transform.parent = null;
		}
	}

	// Update is called once per frame
	void Update()
	{

		if (target == null)
		{
			FindPlayer();
			return;
		}

		targetpos = target.position;
		targetpos.y = targetpos.y + ymod;

		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (targetpos - lastTargetPosition).x;

		bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

		if (updateLookAheadTarget)
		{
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		}
		else
		{
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
		}

		Vector3 aheadTargetPos = targetpos + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

		newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y, yPosRestriction, Mathf.Infinity), -10);
		

		transform.position = newPos;

		lastTargetPosition = targetpos;
	}

	void FindPlayer()
	{
		if (nextTimeToSearch <= Time.time)
		{
			GameObject searchResult = GameObject.Find("Player");
			if (searchResult != null)
				target = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}
}
