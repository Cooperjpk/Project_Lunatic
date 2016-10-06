using UnityEngine;
using System.Collections;

public class FireProjectile : Ability {

    public GameObject projectile;
    public GameObject firepoint;

    public Vector3 direction;

    public float speed;

    public override void UseAbility()
    {

        Rigidbody fireball = Instantiate(projectile, firepoint.transform.position, firepoint.transform.rotation) as Rigidbody;
        fireball.velocity = firepoint.transform.TransformDirection(direction * speed);

        StartCooldown();
        
    }

}
