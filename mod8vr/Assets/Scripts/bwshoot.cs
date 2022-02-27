using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bwshoot : MonoBehaviour {
    secondlock seclock;
    bwaiming bwaim;
    [SerializeField] Vector3[] aimpoint = new Vector3[3] { Vector3.zero, Vector3.zero, Vector3.zero };
    [SerializeField] Vector3 finalaimpoint, lefthandpoint, righthandpoint, test;
    [SerializeField] float bulletspd;
    [SerializeField] int weaponselect, leftreload = 0, rightreload = 0;
    [SerializeField] private int leftreloadtime = 15;
    [SerializeField] int[] rightreloadtime = new int[3];
    [SerializeField] bool lefthandstate, righthandstate, regloadflg = false;
    [SerializeField] GameObject lasttarget;
    int locktime = 0;
    [SerializeField] regulationloader regloader;
    [SerializeField] regulationdata regdat;
    [SerializeField] GameObject gamecore, lockcursor, bulletprefab, lefthand, righthand,leftshoulder,rightshoulder;
    [SerializeField] bwstate bws;
    [SerializeField] GameCore gc;
    [SerializeField] bool[] isnoequip = { false, false, false };
    // Start is called before the first frame update
    void Start() {
        bws = this.gameObject.GetComponent<bwstate>();
        gamecore = GameObject.FindGameObjectWithTag("System");
        gc = gamecore.GetComponent<GameCore>();
        regloader = gamecore.GetComponent<regulationloader>();
        regdat = regloader.getregulationdata();
        leftreloadtime=gc.getleftweapondata().reload;
        rightreloadtime[0] = gc.getrightweapondata().reload;
        rightreloadtime[1] = gc.getrightshoulderdata().reload;
        rightreloadtime[2] = gc.getleftshoulderdata().reload;
    }
    private void Awake() {
        seclock = this.gameObject.GetComponent<secondlock>();
        bwaim = this.gameObject.GetComponent<bwaiming>();
    }
    void loadreg() {

    }
    
    public void toggleweapon() {
        weaponselect = (weaponselect + 1) % 3;
    }
    public void setlefthandstate(bool state) {
        lefthandstate = state;
    }
    public void setrighttandstate(bool state) {
        righthandstate = state;
    }
    // Update is called once per frame
    void Update() {
        if (!regloadflg) {
            loadreg();
            regloadflg = true;
        }
    }
    void LateUpdate() {

    }
    void FixedUpdate() {
        lasttarget = bwaim.gettargetpoint();
        Debug.Log(bwaim.gettargetpoint());
        if (lasttarget != null) {
            if (lasttarget == bwaim.gettargetpoint()) {

                locktime = Mathf.Clamp(locktime + 1, 0, 3);

            }
            else {
                locktime = 1;

            }
            aimpoint[2] = aimpoint[1];
            aimpoint[1] = aimpoint[0];
            aimpoint[0] = lasttarget.transform.position;

            finalaimpoint = seclock.getaimpoint(aimpoint, locktime);

        }
        if (lasttarget != null & lefthandstate & leftreload == 0 & bws.getleftbullet > 0) {
            leftreload = leftreloadtime;
            damagedef ddef = new damagedef();
            ddef.damage = gc.getleftweapondata().damage;
            ddef.wptype = gc.getleftweapondata().type;
            GameObject bulletl = GameObject.Instantiate(bulletprefab, lefthand.transform.position, Quaternion.identity);
            Bullet bul = bulletl.GetComponent<Bullet>();
            bul.setdamage(ddef);
            Rigidbody rbl = bulletl.GetComponent<Rigidbody>();
            lefthandpoint = (lasttarget.transform.position - lefthand.transform.position).normalized * bulletspd + finalaimpoint;
            test = (lasttarget.transform.position - lefthand.transform.position).normalized * bulletspd;
            rbl.AddForce(lefthandpoint, ForceMode.VelocityChange);
            bws.useleftbullet();
        }
        if (leftreload > 0) leftreload -= 1;
        if (lasttarget != null & righthandstate & rightreload == 0 & !isnoequip[0]) {
            if (weaponselect == 0 & bws.getrightbullet > 0) {
                damagedef ddef = new damagedef();
                ddef.damage = gc.getrightweapondata().damage;
                ddef.wptype = gc.getrightweapondata().type;
                GameObject bulletr = GameObject.Instantiate(bulletprefab, righthand.transform.position, Quaternion.identity);
                Bullet bul = bulletr.GetComponent<Bullet>();
                bul.setdamage(ddef);
                Rigidbody rbr = bulletr.GetComponent<Rigidbody>();
                righthandpoint = (lasttarget.transform.position - righthand.transform.position).normalized * bulletspd + finalaimpoint;
                rbr.AddForce(righthandpoint, ForceMode.VelocityChange);
                rightreload = rightreloadtime[weaponselect];
                bws.userightbullet();
            }
            else if (weaponselect == 1 & bws.getrightsbullet > 0 & !isnoequip[1]) {
                Debug.Log("rightshoulder");
                righthandpoint = (lasttarget.transform.position - rightshoulder.transform.position).normalized * bulletspd + finalaimpoint;
                bws.userightbullet();
                rightreload = rightreloadtime[weaponselect];
            }
            else if (weaponselect == 2 & bws.getleftsbullet > 0 & !isnoequip[2]) {
                Debug.Log("leftshoulder");
                righthandpoint = (lasttarget.transform.position - leftshoulder.transform.position).normalized * bulletspd + finalaimpoint;
                bws.useleftsbullet();
                rightreload = rightreloadtime[weaponselect];
            }




        }
        if (rightreload > 0) rightreload -= 1;
    }
}
