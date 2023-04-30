using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleSkyBox : MonoBehaviour
{
    string[] colors={"Red", "Green", "Blue"};
    public int colorIndex;
    [SerializeField] Material defaultSkyBox;
    [SerializeField] Material redSky;
    [SerializeField] Material greenSky;
    [SerializeField] Material blueSky;
    [SerializeField] Material yellowSky;
    AudioSource changerSound;
    [SerializeField] AudioClip zawarudo;
    int numberOfCycles;
    int newNumberOfCycles;

    GameObject rocket;

     GameObject[] obstacles; 

    // Start is called before the first frame update
    void Start()
    {
        colorIndex=0;
        rocket=GameObject.Find("AtomRocket");
        numberOfCycles=rocket.GetComponent<ChangeColor>().numberOfColors;
        newNumberOfCycles=numberOfCycles;
        changerSound=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        newNumberOfCycles=rocket.GetComponent<ChangeColor>().numberOfColors;
        if(newNumberOfCycles!=numberOfCycles)
        {
            numberOfCycles++;
        }
    }

    public void changeSkyBox()
    {
        if(changerSound.isPlaying)
        {

            changerSound.Stop();
        }
        changerSound.PlayOneShot(zawarudo);
        
        
        colorIndex=(colorIndex+1)%numberOfCycles;
        obstacles=GameObject.FindGameObjectsWithTag("RedObstacle");
        switch(colorIndex)
        {
            case 1:
                RenderSettings.skybox=redSky;
                HideRed();
                ShowGreen();
                ShowBlue();
                showYellow();
                DynamicGI.UpdateEnvironment();
            break;
            case 2:
                RenderSettings.skybox=greenSky;
                HideGreen();
                showRed();
                ShowBlue();
                showYellow();
                DynamicGI.UpdateEnvironment();
            break;
            case 3:
                RenderSettings.skybox=blueSky;
                HideBlue();
                showRed();
                ShowGreen();
                showYellow();
                DynamicGI.UpdateEnvironment();
            break;
            case 4:
                RenderSettings.skybox=yellowSky;
                HideYellow();
                ShowBlue();
                showRed();
                ShowGreen();
                DynamicGI.UpdateEnvironment();
            break;
            default:
                RenderSettings.skybox=defaultSkyBox;
                showRed();
                showYellow();
                ShowBlue();
                ShowGreen();
                DynamicGI.UpdateEnvironment();
            break;
        }
    }


    void showYellow()
    {
        obstacles=GameObject.FindGameObjectsWithTag("YellowObstacle");
         foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<MeshRenderer>().enabled=true;
                obstacle.GetComponent<Collider>().enabled=true;
            }
    }
    void HideYellow()
    {
        obstacles=GameObject.FindGameObjectsWithTag("YellowObstacle");
         foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<MeshRenderer>().enabled=false;
                obstacle.GetComponent<Collider>().enabled=false;
            }
    }
     void showRed()
    {
         obstacles=GameObject.FindGameObjectsWithTag("RedObstacle");
         foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<MeshRenderer>().enabled=true;
                obstacle.GetComponent<Collider>().enabled=true;
            }
    }

    void HideRed()
    {
         obstacles=GameObject.FindGameObjectsWithTag("RedObstacle");
         foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<MeshRenderer>().enabled=false;
                obstacle.GetComponent<Collider>().enabled=false;
            }
    }

    
    void ShowGreen()
    {
         obstacles=GameObject.FindGameObjectsWithTag("GreenObstacle");
         foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<MeshRenderer>().enabled=true;
                obstacle.GetComponent<Collider>().enabled=true;
            }
    }
    void HideGreen()
    {
         obstacles=GameObject.FindGameObjectsWithTag("GreenObstacle");
         foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<MeshRenderer>().enabled=false;
                obstacle.GetComponent<Collider>().enabled=false;
            }
    }

    void ShowBlue()
    {
         obstacles=GameObject.FindGameObjectsWithTag("BlueObstacle");
         foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<MeshRenderer>().enabled=true;
                obstacle.GetComponent<Collider>().enabled=true;
            }
    }
    void HideBlue()
    {
         obstacles=GameObject.FindGameObjectsWithTag("BlueObstacle");
         foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<MeshRenderer>().enabled=false;
                obstacle.GetComponent<Collider>().enabled=false;
            }
    }
}
