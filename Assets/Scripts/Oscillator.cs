using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementFactor;
    [SerializeField] float period=2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //to protect agsinst 0
        if(period<=Mathf.Epsilon){
            return;
        }
        float cycles=Time.time/period; // continues to change throughout the movemnt of time 
        const float tau = Mathf.PI*2; // constant value of 6.283
        float SinWave=Mathf.Sin(cycles * tau); 
        movementFactor =(SinWave + 1f) / 2f; // in order to put it to 0-1
        Vector3 offset=movementVector* movementFactor;
        transform.position = startingPosition+offset;
        
    }
}
