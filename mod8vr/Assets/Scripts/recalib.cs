using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
public class recalib : MonoBehaviour {
    [SerializeField]
    SteamVR_ActionSet acs;
    [SerializeField]
    SteamVR_Input_Sources lefthand, righthand;
    [SerializeField]
    SteamVR_Action_Boolean leftmenu, rightmenu;
    [SerializeField]
    GameObject hmd, hmdfield, center;
    // Start is called before the first frame update
    void Start() {
        acs.Activate();

        manualrecenter();
    }

    // Update is called once per frame
    void Update() {
        if (leftmenu.GetState(lefthand) & rightmenu.GetState(righthand)) {
            manualrecenter();
            Valve.VR.OpenVR.System.GetSeatedZeroPoseToStandingAbsoluteTrackingPose();
            Debug.Log("reset");
        }
    }
    void manualrecenter() {
        Vector3 relativepos;
        relativepos = center.transform.position - hmd.transform.position;
        hmdfield.transform.position = hmdfield.transform.position + relativepos;

    }
}
