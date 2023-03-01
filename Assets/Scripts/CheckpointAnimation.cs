using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointAnimation : MonoBehaviour
{   
    [SerializeField] float checkpointAnimationVelocity = 0.3f;
    [SerializeField] float playerHeight = 1f;
    [SerializeField] float nextLevelDelay = 2f;

    AudioSource audio;

    private void OnCollisionEnter(Collision other)
    {
        audio = GetComponent<AudioSource>();

        if (!audio.isPlaying) {
            audio.Play();   
        }
    }

    private void OnCollisionStay(Collision other)
    {   
        scrollCheckpoint(-checkpointAnimationVelocity);

        if (other.gameObject.transform.localPosition.y <= playerHeight)
        {   
            StartNextLevelSequence(other);
        }          
    }

    private void OnCollisionExit(Collision other)
    {
        scrollCheckpoint(checkpointAnimationVelocity);

        if (transform.localPosition.y >= 0.25)
        {   
            scrollCheckpoint(0);
        }        
    }

    void StartNextLevelSequence(Collision other)
    {
        other.gameObject.GetComponent<Mover>().enabled = false;
        Invoke("LoadNextLevel", nextLevelDelay);
    }

    public void LoadNextLevel()
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    void scrollCheckpoint(float checkpointAnimationVelocity)
    {
        // if checkpointAnimationVelocity is positive, then the method scoll checkpoint up
        // if checkpointAnimationVelocity is negative, then the method scoll checkpoint down
        transform.Translate(0, Time.deltaTime * checkpointAnimationVelocity, 0);
    }
}
