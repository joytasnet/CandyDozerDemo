using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Candy")){
            Destroy(other.gameObject);
        }
        
    }

}
