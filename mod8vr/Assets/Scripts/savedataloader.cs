using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class savedataloader : MonoBehaviour
{
    [SerializeField] userdata userdat;
    [SerializeField] string usrdata;
    [SerializeField] GameObject gamecore;
    [SerializeField] GameCore gc;
    public bool saveflg, loadflg;
    private void Start() {
        gamecore = GameObject.FindGameObjectWithTag("System");
        gc = gamecore.GetComponent<GameCore>();
    }
    private void Update() {
        if (saveflg) savedata();
        if (loadflg) loaddata();
    }
    public void savedata() {
        userdat.headid= gc.getheadid();
        userdat.armsid = gc.getarmsid();
        userdat.bodyid = gc.getbodyid();
        userdat.legsid = gc.getlegsid();
        userdat.rightwid = gc.getrightwid();
        userdat.leftwid = gc.getleftwid();
        userdat.rshoulderid = gc.getrightsid();
        userdat.lshoulderid = gc.getleftsid();


        StreamWriter writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        usrdata = JsonUtility.ToJson(userdat);
        writer.Write(usrdata);
        writer.Flush();
        writer.Close();
    }
    public void loaddata() {
        string usrdata;
        StreamReader reader = new StreamReader(Application.dataPath + "/savedata.json");
        usrdata = reader.ReadToEnd();
        reader.Close();
        userdat = JsonUtility.FromJson<userdata>(usrdata);
    }
}
