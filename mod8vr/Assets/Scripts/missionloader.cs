using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class missionloader : MonoBehaviour {
    // Start is called before the first frame update
    string jsondata;
    [SerializeField] GameObject gcobj;
    [SerializeField] GameCore gc;
    public missiondata msdata;
    [SerializeField] GameObject bwsocket;
    [SerializeField] int missionphase ;
    public int count = 0;
    [SerializeField] int msmax;
    public int phasecount;
    public GameObject[] o;


    void Start () {
        missionphase = 0;
            gcobj = GameObject.FindGameObjectWithTag("System");
        gc = gcobj.GetComponent<GameCore>();
        bwsocket = GameObject.FindGameObjectWithTag("bwsocket");
        int i;
        for(i=1;i< msdata.missionflgs.Length; i++) {
            foreach (GameObject g in msdata.missionflgs[i].gettargetlist()) {
                Debug.Log("g");
                o = msdata.missionflgs[i].gettargetlist();
                g.SetActive(false);

            }
        }
        phasecount = i;
    }
    private void FixedUpdate() {
        
         
        
        
    }
    private void LateUpdate() {

        count = 0;
        GameObject[] obj = msdata.missionflgs[missionphase].gettargetlist();
        foreach (GameObject g in obj) {
            if (g.gameObject.activeSelf) count++;
        }
        if (count == 0) {
            missionphase++;
            msdata.missionflgs[missionphase].gettargetlist().CopyTo(obj, 0);
            foreach (GameObject g in obj) {
                g.SetActive(true);
            }
        }

    }
    void quitmission() {

    }
    void savemission() {
        StreamWriter writer = new StreamWriter(Application.dataPath + "/regulation.json", false);
        jsondata = JsonUtility.ToJson(msdata);
        writer.Write(jsondata);
        writer.Flush();
        writer.Close();
    }
}
