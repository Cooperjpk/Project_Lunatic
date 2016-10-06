using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Shooter02 : Ability
{
    [Space]
    public Rigidbody bullet;
    public GameObject firepoint;
    public Vector3 vector;

    public float speed;

    //This is an example of how to create new abilities
    //Always use the " override public void UseAbility()" and then inside of the controller script the player can use that ability
    //As long as that script is attached to the player as well

        //Currently cooldown does not function so MAKE IT HAPPEN

    override public void UseAbility()
    {
        if (actualCooldown <= 0)
        {
            //Do ability things
            Rigidbody cachedBullet = Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation) as Rigidbody;
            cachedBullet.velocity = firepoint.transform.TransformDirection(vector * speed);

            //Begin the cooldown afterwards
            StartCooldown();
        }

    }


}
