using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollistionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2.0f;
    [SerializeField] ParticleSystem successParticale;
    [SerializeField] ParticleSystem failureParticale;

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Fuel":
                break;
            case "Friendly":
                Debug.Log("Start Your Journey");
                break;
            case "Finish":
                StartSuccessSequance();
                break;
            default:
                StartCrashSequance();
                    break;
        }
    }
    private void StartCrashSequance()
    {
        GetComponent<Movement>().enabled = false;
        failureParticale.Play();
        Invoke("ReloadLevel", 1f);
    }
    private void StartSuccessSequance()
    {
        GetComponent<Movement>().enabled = false;
        successParticale.Play();
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
   public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0; // Reset to first Level
        SceneManager.LoadScene(nextSceneIndex);
    }

}
