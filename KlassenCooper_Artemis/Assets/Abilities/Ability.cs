using UnityEngine;
using System.Collections;
using System;

public class Ability : MonoBehaviour
{

    [Header("Inherited Variables")]
    public float cooldownTime;
    [Header("Do not edit Actual Cooldown")]
    public float actualCooldown;

    public void StartCooldown()
    {
        actualCooldown = cooldownTime;
        StartCoroutine(iCooldownTime());

    }

    public void ResetCooldown()
    {

        actualCooldown = 0;

    }

    IEnumerator iCooldownTime()
    {
        yield return new WaitForSeconds(cooldownTime);

        ResetCooldown();

    }

    virtual public void UseAbility()
    {

        Debug.Log("This is inside the parent.");
  
    }
}
