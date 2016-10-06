using UnityEngine;
using System.Collections;

public class CheckLayerCollision : MonoBehaviour {

    public GameObject player;
    public LayerMask layer;

    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == layer)
        {

        }
    }

}
