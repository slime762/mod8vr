using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class missionflg{

    [SerializeField] GameObject[] target= { };
    [SerializeField] string messgage;
    [SerializeField] float messageduration;


    public GameObject[] gettargetlist() {
        GameObject[] gob=new GameObject[getlength()];
        for(int i = 0; i < getlength(); i++) {
            gob[i] = target[i];

        }
        return gob;
    }
    public int getlength() {
        return target.Length;
    }
}

