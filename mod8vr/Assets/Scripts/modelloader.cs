using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelloader : MonoBehaviour {
    [SerializeField] GameObject[] headmodels;
    [SerializeField] GameObject[] bodymodels;
    [SerializeField] GameObject[] armsmodels;
    [SerializeField] GameObject[] legsmodels;
    [SerializeField] GameObject[] weaponmodels;
    [SerializeField] GameObject[] shouldermodels;
    public GameObject getheadmodel(int headid) {
        return headmodels[headid];
    }
    public GameObject getbodymodel(int bodyid) {
        return bodymodels[bodyid];
    }
    public GameObject getarmsmodel(int armsid) {
        return armsmodels[armsid];
    }
    public GameObject getlegsmodel(int legsid) {
        return legsmodels[legsid];
    }
    public GameObject getweaponmodel(int weaponid) {
        return weaponmodels[weaponid];
    }
    public GameObject getshouldermodel(int shoulderid) {
        return shouldermodels[shoulderid];
    }
}
