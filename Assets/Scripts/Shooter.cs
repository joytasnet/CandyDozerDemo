using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const int MaxShotPower = 5;
    const int RecoverSeconds = 3;

    int shotPower = MaxShotPower;
    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;
    public CandyManager candyManager;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) Shot();
        
    }
    GameObject SampleCandy(){
        int index = Random.Range(0,candyPrefabs.Length);
        return candyPrefabs[index];
    }
    Vector3 GetInstantiatePosition(){
        float x = baseWidth * 
            (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position+new Vector3(x,0,0);
    }
    public void Shot(){
        if(candyManager.GetCandyAmount() <= 0) return;
        if(shotPower <= 0) return;
        
        GameObject candy = Instantiate(
            SampleCandy(),//何を
            GetInstantiatePosition(),//どこに
            Quaternion.identity//どの向き
        );
        candy.transform.parent= candyParentTransform;

        Rigidbody candyRigidbody=candy.GetComponent<Rigidbody>();
        candyRigidbody.AddForce(transform.forward * shotForce);
        candyRigidbody.AddTorque(new Vector3(0,shotTorque,0));

        candyManager.ConsumeCandy();

        ConsumePower();

    }

    void OnGUI(){
        GUI.color=Color.black;
        GUI.matrix=Matrix4x4.Scale(Vector3.one*2);
        string label="";
        for(int i=0;i<shotPower;i++) label = label+"+";
        GUI.Label(new Rect(20,40,100,30),label);

    }
    void ConsumePower(){
        shotPower--;
        StartCoroutine(RecoverPower());

    }
    IEnumerator RecoverPower(){
        yield return new WaitForSeconds(RecoverSeconds);
        shotPower++;
    }
}
