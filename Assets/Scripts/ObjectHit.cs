using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    MeshRenderer renderer; // Caching a reference
    AudioSource audio;
    Color originalColor;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        //renderer = GetComponent<MeshRenderer>();
        //originalColor = renderer.material.color;
    }

    private void OnCollisionEnter(Collision other)
        {
            Debug.Log("Collided with " + other.transform.name);
            //renderer.material.color = Color.red;

            if (!audio.isPlaying) {
                audio.Play();
            }
        }
    
    private void OnCollisionExit(Collision other)
        {
            Debug.Log("No longer in contact with " + other.transform.name);
            //renderer.material.color = originalColor;
        }
}
