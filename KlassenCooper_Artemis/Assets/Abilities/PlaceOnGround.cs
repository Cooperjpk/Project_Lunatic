using UnityEngine;
using System.Collections;

public class PlaceOnGround : Ability {

    public GameObject playerObject;
    public GameObject firepoint;
    public Camera cam;

    public float maxDistance;
    public string layer;


    public override void UseAbility()
    {

        if (Physics.Raycast(firepoint.transform.position,cam.transform.forward,maxDistance))//,LayerMask.NameToLayer(layer)))

        {

            Debug.Log("You touched the ground.");

        }
        else
        {

            Debug.Log("You missed the ground.");

        }



    }

}
