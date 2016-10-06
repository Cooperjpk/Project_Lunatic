using UnityEngine;
using System.Collections;

public class MovePlayer : Ability {

    public Rigidbody playerRigidbody;
    public Camera cam;

    public float force;
    public float moveTime;

    [Header("Effects")]
    public GameObject effect;
    public GameObject effectPoint;

    public float effectDuration;

    public override void UseAbility()
    {
        //Add an impulse force that takes mass into account
        playerRigidbody.AddForce(cam.transform.forward * force, ForceMode.Force);

        iRemoveForce();

        if (effect)
        {
            //Spawn an effect at a specific point
            GameObject spawnEffect = Instantiate(effect, effectPoint.transform.position, effectPoint.transform.rotation) as GameObject;

            //Destroy the effect after
            Destroy(effect, effectDuration);
        }

    }

    //This currently does not work
    IEnumerator iRemoveForce()
    {

        yield return new WaitForSeconds(moveTime);

        Debug.Log("Removing Force now :)");
        playerRigidbody.velocity = Vector3.zero;

    }

}
