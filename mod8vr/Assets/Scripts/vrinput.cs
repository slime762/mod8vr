using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class vrinput : MonoBehaviour {
    public GameObject target;
    public bwmove bwm;
    public bwshoot bws;
    [SerializeField]
    SteamVR_ActionSet acs;
    [SerializeField]
    SteamVR_Input_Sources lefthand, righthand;
    [SerializeField]
    SteamVR_Action_Boolean leftgrip, rightgrip, lefttrigger, righttrigger, rcup, rcdown, rcright, rcleft, lspush;
    [SerializeField]
    SteamVR_Action_Pose leftbase, rightbase;
    [SerializeField]
    SteamVR_Action_Vector2 leftstick;
    // Start is called before the first frame update
    void Start() {
        acs.Activate();
        bwm = target.GetComponent<bwmove>();
        bws = target.GetComponent<bwshoot>();
    }
    bool getlefthandstate() {
        bool ret = lefttrigger.GetState(lefthand);
        return ret;
    }
    bool getrighthandstate() {
        bool ret = righttrigger.GetState(righthand);
        return ret;
    }
    // Update is called once per frame
    void Update() {
        bws.setlefthandstate(lefttrigger.GetState(lefthand));
        bws.setrighttandstate(righttrigger.GetState(righthand));
        bwm.bwlocomotion(leftstick.GetAxis(lefthand), lspush.GetState(lefthand));
        if (rcleft.GetState(righthand) | Input.GetKey(KeyCode.LeftArrow)) {
            bwm.bwturnleft();
        }
        if (rcright.GetState(righthand) | Input.GetKey(KeyCode.RightArrow)) {
            bwm.bwturnright();
        }
    }
}
