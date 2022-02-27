using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showammocount : MonoBehaviour {
    [SerializeField] GameObject bwprefab;
    [SerializeField] bwstate bs;
    [SerializeField] int select;
    [SerializeField] TextMesh tm;
    // Start is called before the first frame update
    void Start() {
        bwprefab = GameObject.FindGameObjectWithTag("bwsocket");
        bs = bwprefab.GetComponent<bwstate>();
        tm = this.gameObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update() {
        if(select==0)
            tm.text = bs.getrightbullet.ToString();
        if (select == 1)
            tm.text = bs.getrightsbullet.ToString();
        if (select == 2)
            tm.text = bs.getleftsbullet.ToString();
        if (select == 3)
            tm.text = bs.getleftbullet.ToString();
    }
}
