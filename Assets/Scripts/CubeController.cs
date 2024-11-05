using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 dir = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDir());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }

    IEnumerator ChangeDir(){
        yield return new WaitForSeconds(1f);
        dir = new Vector3(1f,0,0);
        yield return new WaitForSeconds(2f);
        dir = new Vector3(0f,1f,0);
        yield return new WaitForSeconds(2f);
        dir = new Vector3(-1f,0f,0);
        yield return new WaitForSeconds(2f);
        dir = new Vector3(0f,-1f,0);
        yield return new WaitForSeconds(2f);
        dir = new Vector3(0f,0f,0);
    }
}
