using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour{
    [SerializeField] regulationloader regloader;
    [SerializeField] regulationdata regdat;
    [SerializeField]
    GameObject gamecore,text;
    [SerializeField] modelloader ml;
    [SerializeField] bwassembly bwa;
    //public static GameCore Instance;
    [SerializeField] setground sg;
    [SerializeField] int headid, bodyid, armsid, legsid, leftwid, rightwid, lshoulderid, rshoulderid;
    bool doasmflg=false;
    // Start is called before the first frame update
    void Awake(){
        gamecore = gameObject;
        regloader = gamecore.GetComponent<regulationloader>();
        regdat = regloader.getregulationdata();
        ml = gameObject.GetComponent<modelloader>();
        bwa = gameObject.GetComponent<bwassembly>();
        Debug.Log(getrightweapondata().name);
        if ((sg = GameObject.FindGameObjectWithTag("bwasmbase").GetComponent<setground>()) != null) ;
        
    }
    // Update is called once per frame
    void Start() {
        bwa.doasm(headid, bodyid, armsid, legsid, leftwid, rightwid, lshoulderid, rshoulderid);
    }
    public void calldoasm() {
        bwa.doasm(headid, bodyid, armsid, legsid, leftwid, rightwid, lshoulderid, rshoulderid);
        sg.setpos();
    }
    
    public head getheaddata() => regdat.headdata[headid];
    public body getbodydata() => regdat.bodydata[bodyid];
    public arms getarmsdata() => regdat.armsdata[armsid];
    public legs getlegsdata() => regdat.legsdata[legsid];
    public weapon getleftweapondata() => regdat.weapondata[leftwid];
    public weapon getrightweapondata() => regdat.weapondata[rightwid];
    public shoulder getleftshoulderdata() => regdat.shoulderdata[lshoulderid];
    public shoulder getrightshoulderdata() => regdat.shoulderdata[rshoulderid];
    public void setheadid(int dif) => headid = Mathf.Clamp(headid + dif, 0, regdat.headdata.Length);
    public void setarmsid(int dif) => armsid = Mathf.Clamp(armsid + dif, 0, regdat.armsdata.Length);
    public void setbodyid(int dif) => bodyid = Mathf.Clamp(bodyid + dif, 0, regdat.bodydata.Length);
    public void setlegsid(int dif) => legsid = Mathf.Clamp(legsid + dif, 0, regdat.legsdata.Length);
    public void setleftwid(int dif) => leftwid = Mathf.Clamp(leftwid + dif, 0, regdat.weapondata.Length);
    public void setrightwid(int dif) => headid = Mathf.Clamp(headid + dif, 0, regdat.weapondata.Length);
    public void setlshoulderid(int dif) => lshoulderid = Mathf.Clamp(lshoulderid + dif, 0, regdat.shoulderdata.Length);
    public void setrshoulderid(int dif) => rshoulderid = Mathf.Clamp(rshoulderid + dif, 0, regdat.shoulderdata.Length);
    public int getheadid() => headid;
    public int getbodyid() => bodyid;
    public int getarmsid() => armsid;
    public int getlegsid() => legsid;
    public int getrightwid() => rightwid;
    public int getleftwid() => leftwid;
    public int getrightsid() => rshoulderid;
    public int getleftsid() => lshoulderid;


}
