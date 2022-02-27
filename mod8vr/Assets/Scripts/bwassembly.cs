using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bwassembly : MonoBehaviour {
    [SerializeField] GameCore gc;
    [SerializeField] modelloader ml;
    [SerializeField] GameObject bwstarget;
    [SerializeField] string tagname;
    // Start is called before the first frame update
    void Start() {
        gc = gameObject.GetComponent<GameCore>();
        ml = gameObject.GetComponent<modelloader>();
        bwstarget = GameObject.FindGameObjectWithTag(tagname);
    }
    public void doasm(int headid, int bodyid,int armsid,int legsid,int leftwid,int rightwid,int leftsid,int rigltsid) {
        foreach (Transform t in bwstarget.transform) {
            Destroy(t.gameObject);
        }
        GameObject headobj = GameObject.Instantiate(ml.getheadmodel(headid), bwstarget.gameObject.transform);
        GameObject bodyobj = GameObject.Instantiate(ml.getbodymodel(bodyid), bwstarget.gameObject.transform);
        GameObject armsobj = GameObject.Instantiate(ml.getarmsmodel(armsid), bwstarget.gameObject.transform);
        GameObject legsobj = GameObject.Instantiate(ml.getlegsmodel(legsid), bwstarget.gameObject.transform);
        headobj.gameObject.transform.localPosition = Vector3.zero;
        bodyobj.gameObject.transform.localPosition = Vector3.zero;
        armsobj.gameObject.transform.localPosition = Vector3.zero;
        legsobj.gameObject.transform.localPosition = Vector3.zero;

    }

}
