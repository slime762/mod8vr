using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bwstate : MonoBehaviour {
    [SerializeField] int leftbullet, rightbullet, leftsbullet, rightsbullet, ap;
    [SerializeField] GameObject gamecore;
    [SerializeField] GameCore gc;
    // Start is called before the first frame update
    private void Awake() {

    }
    void Start() {
        gamecore = GameObject.FindGameObjectWithTag("System");
        gc = gamecore.GetComponent<GameCore>();
        ap = gc.getheaddata().ap + gc.getarmsdata().ap + gc.getbodydata().ap + gc.getlegsdata().ap;
        leftbullet = gc.getleftweapondata().ammocount;
        rightbullet = gc.getrightweapondata().ammocount;
        leftsbullet = gc.getleftshoulderdata().ammocount;
        rightsbullet = gc.getrightshoulderdata().ammocount;
        Debug.Log(rightbullet);
        Debug.Log(gc.getrightweapondata().ammocount);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            leftbullet--;
        }
    }
    public int getap() => ap;
    public int getleftbullet => leftbullet;
    public int getrightbullet => rightbullet;
    public int getleftsbullet => leftsbullet;
    public int getrightsbullet => rightsbullet;
    public void useleftbullet() => leftbullet--;
    public void userightbullet() => rightbullet--;
    public void useleftsbullet() => leftsbullet--;
    public void userightsbullet() => rightbullet--;
}
