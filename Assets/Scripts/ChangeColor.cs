using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private UnityEvent colorTrigger;
    [SerializeField] ParticleSystem red;
    [SerializeField] ParticleSystem green;
    [SerializeField] ParticleSystem blue;
    
    [SerializeField] ParticleSystem yellow;

    string[] colors={"Red", "Green", "Blue"};
    public int numberOfColors=4; // 4 because of the neutral state;
    public int colorIndex;
    // Start is called before the first frame update
    void Start()
    {
        colorIndex=0;
        Debug.Log("Current color is"+colors[colorIndex]);
       

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.C))
        {
            colorChange();
            colorTrigger.Invoke();
        }
    }



    void colorChange()
    {
        colorIndex=(colorIndex+1)%numberOfColors;
        if(red.isPlaying)
        {
            red.Stop();
        }
        if(blue.isPlaying)
        {
            blue.Stop();
        }
        if(green.isPlaying)
        {
            green.Stop();
        }
        if(colorIndex==1)
        {
            red.Play();
            blue.Stop();
            green.Stop();
        }
        else if(colorIndex==2)
        {
            green.Play();
        }
        else if(colorIndex==3)
        {
            blue.Play();
        }
        else if(colorIndex==4)
        {
            yellow.Play();
        }
        // Debug.Log("Current color is"+colors[colorIndex]);
        
    }
}
