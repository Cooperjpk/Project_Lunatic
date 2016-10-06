using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour
{

#region Public Variables

    public float turnSpeed = 4.0f;
    public Transform player;

    public float distanceUp = 1.0f;
    public float distanceAway = 1.0f;

    public float offsetY = 0.0f;
    public float offsetZ = 0.0f;

#endregion

#region Private Variables

    private Vector3 offset;

#endregion

    void Start()
    {
        //Set offset to presets
        offset = new Vector3(player.position.x, player.position.y + distanceUp, player.position.z + distanceAway);
    }

    void LateUpdate()
    {

        //Get mouse x and y and turn camera to look in the same direction
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.left) * offset;

        //Change position of the camera to be at player position + offset
        transform.position = player.position + offset;

        //Make camera forward vector aimed towards the player vector
        transform.LookAt(new Vector3(player.position.x, player.position.y + offsetY, player.position.z + offsetZ));

    }

}