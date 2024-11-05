using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    const int DefaultCandyAmount = 30;

    public int candy=DefaultCandyAmount;

    public void ConsumeCandy(){
        if(candy > 0 ) candy--;
    }

    public int GetCandyAmount(){
        return candy;
    }

    public void AddCandy(int amount){
        candy += amount;
    }

    void OnGUI(){
        GUI.matrix=Matrix4x4.Scale(Vector3.one*2);
        GUI.color=Color.black;

        string label ="Candy :" + candy;
        GUI.Label(new Rect(20,20,100,30),label);
    }
}
