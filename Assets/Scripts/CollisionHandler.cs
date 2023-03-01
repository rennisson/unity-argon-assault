using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] int life = 3;
    [SerializeField] float nextLevelDelay = 2f;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;

    bool collisionDisabled = false;

    private void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    private void OnCollisionEnter(Collision other)
    {   
        if (collisionDisabled) { return; }

        switch (other.gameObject.tag)
        {
            case "Enemy":
                life--;
                
                if (life == 0)
                {
                    StartDeathSequence();
                }
                break;

            case "Checkpoint":
                successParticles.Play();
                break;

            default:
                Debug.Log("Default");
                break;
        }
    }

    void StartDeathSequence()
    {
        deathParticles.Play();
        GetComponent<Mover>().enabled = false;
        Invoke("ReloadLevel", nextLevelDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
    }

    void LoadNextLevel() // FIX IT!
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
