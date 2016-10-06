using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

    //Choose the timelimit
    public float lifetime;

    public void Start()
    {
        Invoke("Destruct", lifetime);
    }
    
    public void Destruct()
    {
        Destroy(this.gameObject);
    }
}
