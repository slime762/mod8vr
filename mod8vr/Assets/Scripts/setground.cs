using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setground : MonoBehaviour {
    [SerializeField] GameObject target, defaultpoint;
    [SerializeField] Vector3 rayvec;
    [SerializeField] bool setposflg=false;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
       //if(setposflg)
        //    setpos();
    }
    public void setpos() {
        RaycastHit hit;
        target.transform.position = defaultpoint.transform.position;
        /*if (Physics.BoxCast(gameObject.transform.position, new Vector3(2.0f, 2.0f, 2.0f), rayvec, out hit)) {
            if ((hit.point - defaultpoint.transform.position).magnitude > 0.1f)
                setposflg = false;
            target = GameObject.FindGameObjectWithTag("bwsocket");
            target.transform.position += (gameObject.transform.position - new Vector3(0, hit.point.y, 0));
        }*/
    }
    public void clean() {
        target = GameObject.FindGameObjectWithTag("bwsocket");
        foreach(Transform t in target.transform) {
            Destroy(t.gameObject);
        }
        target.transform.position = defaultpoint.transform.position;
        setposflg = true;
    }
   
}
