using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        anm=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Equals("AtomRocket"))
        {
            anm.SetBool("rocketIsNear", true);
        }
        
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name.Equals("KillSpike"))
        {
            GetComponent<Collider>().enabled=false;
            GetComponent<Rigidbody>().detectCollisions=false;
            anm.SetBool("isDead", true);

            Invoke("destroyBoss", 2f);
            Debug.Log("You should be dead. Stop defying logic");
        }
    }

    void destroyBoss()
    {
        Destroy(gameObject);
    }
}


