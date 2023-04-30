using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class CollisionHandler : MonoBehaviour
{

    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip FinishLevel;

    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem FinishParticle;



    GameObject[] obstacles; 
    AudioSource collisonAS;

    bool isTransitioning;
    

    private void Start() {
        collisonAS=GetComponent<AudioSource>();
        isTransitioning=false;
    }
    private void OnCollisionEnter(Collision other) {

        if(isTransitioning)
        {
            return;
        }
        switch(other.gameObject.tag)
        {
            case "Finish":
                startSuccessSequence();
                break;
            case "Friendly":
                Debug.Log("All safe, G. Friendly Item");
                break;
            case "Red":
                Debug.Log("Red Obstacles should be deleted now.");
                findObstacles("Red");
                break;
            default:
            CrashSequence();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(isTransitioning)
        {
            return;
        }
        switch(other.gameObject.tag)
        {
             case "yellowPill":
                GetComponent<ChangeColor>().numberOfColors++;
                other.gameObject.SetActive(false);
            break;
            default:
            break;
        }
    }

    void findObstacles(string color)
    {
        obstacles=GameObject.FindGameObjectsWithTag("RedObstacle");
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<MeshRenderer>().enabled=false;
            obstacle.GetComponent<Collider>().enabled=false;
        }
    }

    void startSuccessSequence()
    {

        FinishParticle.Play();
        isTransitioning=true;
        collisonAS.Stop();
        collisonAS.PlayOneShot(FinishLevel);
        GetComponent<Movement>().enabled=false;
        Invoke("LoadNextLevel" ,2f);

    }
    void CrashSequence()
    {
        crashParticle.Play();
        isTransitioning=true;
        collisonAS.Stop();
        collisonAS.PlayOneShot(crashSound);
        //add crash effect
        //add particle effect
        GetComponent<Movement>().enabled=false;
        GetComponent<ChangeColor>().enabled=false;
        Invoke("ReloadLevel", 3f);
        // GetComponent<Movement>().enabled=true;
    }
    void LoadNextLevel()
    {
        int currentLevel=SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex=currentLevel+1;
        if(nextLevelIndex==SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex=0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
