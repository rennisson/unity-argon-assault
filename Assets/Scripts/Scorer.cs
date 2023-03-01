using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player")
            {
                hits = hits + other.contactCount;
                Debug.Log("You've collided " + hits + " times with "+ other.transform.name );
            }
        
    }
}
