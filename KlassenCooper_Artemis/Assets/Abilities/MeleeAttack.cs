using UnityEngine;
using System.Collections;

public class MeleeAttack : Ability {

    [Header("Animation")]
    public Animator playerAnimator;
    public string playerAnimation;
    public float animSpeed;

    [Header("Collision")]
    public GameObject collisionBox;

    public override void UseAbility()
    {
        //Set the collision for the melee attack to active
        collisionBox.SetActive(true);

        //Play the animation for the melee attack
        playerAnimator.Play(playerAnimation, 0);

        //Set the time so that after the animSpeed, the collision will deactivate, should be when the animation is complete
        iDeactivateCollision();

    }

    IEnumerator iDeactivateCollision()
    {

        yield return new WaitForSeconds(animSpeed);

        collisionBox.SetActive(false);

    }
}
