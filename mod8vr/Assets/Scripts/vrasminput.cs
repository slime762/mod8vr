using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class vrasminput : MonoBehaviour {
    [SerializeField] GameObject gcobj;
    [SerializeField] GameCore gc;
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
    [SerializeField] int asmarea = 0;//0=head,1=arms,2=body,3=legs,4=leftw,5=rightw,6=leftsw,7=rightsw
    [SerializeField] string[] partname= { "head","arms", "body", "legs", "leftweapon", "rightweapon","leftshoulder","rightshoulder" };
    // Start is called before the first frame update
    void Start() {
        gcobj = GameObject.FindGameObjectWithTag("System");
        gc = gcobj.GetComponent<GameCore>();
    }

    // Update is called once per frame
    void Update() {
        if (rcup.GetStateDown(lefthand)) {
            asmarea--;
        }
        if (rcdown.GetStateDown(lefthand)) {
            asmarea++;
        }
        switch (asmarea) {
            case 0:
                if (rcleft.GetStateDown(righthand)) {
                    gc.setheadid(1);
                }
                if (rcright.GetStateDown(righthand)) {
                    gc.setheadid(-1);
                }
                break;
            case 1:
                if (rcleft.GetStateDown(righthand)) {
                    gc.setarmsid(1);
                }
                if (rcright.GetStateDown(righthand)) {
                    gc.setarmsid(-1);
                }
                break;
            case 2:
                if (rcleft.GetStateDown(righthand)) {
                    gc.setbodyid(1);
                }
                if (rcright.GetStateDown(righthand)) {
                    gc.setbodyid(-1);
                }
                break;
            case 3:
                if (rcleft.GetStateDown(righthand)) {
                    gc.setlegsid(1);
                }
                if (rcright.GetStateDown(righthand)) {
                    gc.setlegsid(-1);
                }
                break;
            case 4:
                if (rcleft.GetStateDown(righthand)) {
                    gc.setleftwid(1);
                }
                if (rcright.GetStateDown(righthand)) {
                    gc.setleftwid(-1);
                }
                break;
            case 5:
                if (rcleft.GetStateDown(righthand)) {
                    gc.setrightwid(1);
                }
                if (rcright.GetStateDown(righthand)) {
                    gc.setrightwid(-1);
                }
                break;
            case 6:
                if (rcleft.GetStateDown(righthand)) {
                    gc.setlshoulderid(1);
                }
                if (rcright.GetStateDown(righthand)) {
                    gc.setlshoulderid(-1);
                }
                break;
            case 7:
                if (rcleft.GetStateDown(righthand)) {
                    gc.setrshoulderid(1);
                }
                if (rcright.GetStateDown(righthand)) {
                    gc.setrshoulderid(-1);
                }
                break;
        }
    }
}
