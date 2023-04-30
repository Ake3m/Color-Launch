using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFall : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Equals("AtomRocket"))
        {
            rb.isKinematic=false;
        }
    }
}
