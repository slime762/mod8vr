using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showap : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] GameObject bws,aptext;
    [SerializeField] TextMesh tm;
    bwstate bstate;
    void Start() {
        bws = GameObject.FindGameObjectWithTag("bwsocket");
        bstate = bws.GetComponent<bwstate>();
        tm = aptext.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update() {
        tm.text = "AP:"+bstate.getap().ToString();
    }
}
