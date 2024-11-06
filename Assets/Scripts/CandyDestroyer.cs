using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public CandyManager candyManager;
    public int reward;
    public GameObject effectPrefab;
    public Vector3 effectRotation;
    public EventManager em;
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Candy")){
            candyManager.AddCandy(reward);
            Destroy(other.gameObject);
            if(effectPrefab != null){
                Instantiate(
                    effectPrefab,
                    other.transform.position,
                    Quaternion.Euler(effectRotation)
                );
            }
        }
        else if(other.CompareTag("Boots")){
            if(em != null && !em.isMove){
                StartCoroutine(em.BootsEvent());
            }
        }
        
    }
}
