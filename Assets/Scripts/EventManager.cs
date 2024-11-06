using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject[] items;
    public Transform bottom;
    public bool isMove{get;set;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    GameObject SampleCandy(){
        int idx = Random.Range(0,items.Length);
        return items[idx];
    }
    Vector3 randomPos(){
        Vector3 pos = new Vector3();
        pos.x = Random.Range(-1.5f,1.5f);
        pos.y = Random.Range(15f,30f);
        pos.z = Random.Range(-4f,3f);
        return pos;
    }

    public IEnumerator BootsEvent(){
        isMove=true;
        //Debug.Log("called");
        for(int i=0;i<200;i++){
            //Debug.Log(i);
            Instantiate(
                SampleCandy(),
                new Vector3(
                   Random.Range(-1.5f,1.5f),
                    15+(i*0.5f),
                   Random.Range(-4f,3f) 
                ),
                Quaternion.identity
            );
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        while(bottom.position.z > -10f){
            bottom.Translate(0,0,-1f*Time.deltaTime);
            yield return null;
        }
        while(bottom.position.z < 0f){
            bottom.Translate(0,0,1f*Time.deltaTime);
            yield return null;
        }
        isMove=false;
        
    }
}
