using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform follow;
    private Vector3 targetPosition;

    void Start ()
    {

        follow = GameObject.FindWithTag("PlayerCamera").transform;

	}
	
	void LateUpdate ()
    {

        //Set the target postion to be the correct offest from the Camera
        targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
        Debug.DrawRay(follow.position, follow.up * distanceUp, Color.red);
        Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue);
        Debug.DrawRay(follow.position, targetPosition, Color.magenta);

        //Make a smooth transition between current position and position the camera wants to be in
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        //Make camera look at the Follow object
        transform.LookAt(follow);

	}
}
