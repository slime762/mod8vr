using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bwaiming : MonoBehaviour {
    [SerializeField] GameObject gamecore, lefthand, righthand, crosshairmounter, head, lockcursor;
    [SerializeField] LayerMask lm;
    public GameObject target;
    public bool dataloadflg = false;
    [SerializeField] float mindist;
    // Start is called before the first frame update
    public GameObject[] enemylist;
    public int locktime, framecount;
    [SerializeField] regulationloader regloader;
    [SerializeField] regulationdata regdat;
    // Start is called before the first frame update
    void Start() {
        enemylist = GameObject.FindGameObjectsWithTag("enemy");

    }
    void loadreg() {
        gamecore = GameObject.FindGameObjectWithTag("System");
        regloader = gamecore.GetComponent<regulationloader>();
        regdat = regloader.getregulationdata();
    }
    // Update is called once per frame
    public GameObject gettargetpoint() => target;
    private void Update() {
        /*foreach (GameObject index in enemylist) {
            RaycastHit hit;
            if (Physics.Raycast(head.gameObject.transform.position, (index.transform.position - head.gameObject.transform.position), out hit, 500f, LayerMask.GetMask("Crosshair"))) {

                if (hit.collider.gameObject.CompareTag("lockcursor")) {
                    Debug.Log(hit.collider.gameObject.name);
                    Debug.Log(hit.transform.name);
                    target = index;
                    lockcursor.transform.position = hit.point;
                    lockcursor.transform.LookAt(head.transform.position);
                }
            }
        }*/
    }
    void FixedUpdate() {
        
        if (!dataloadflg) {
            loadreg();
            dataloadflg = true;
        }
        if (framecount > 40) {
            enemylist = GameObject.FindGameObjectsWithTag("enemy");
            framecount = 0;
        }
        framecount++;
        mindist = 250000;
        foreach (GameObject index in enemylist) {
            RaycastHit hit;
            if (Physics.Raycast(head.gameObject.transform.position, (index.transform.position - head.gameObject.transform.position), out hit, 500f, LayerMask.GetMask("Crosshair"))) {

                if (hit.collider.gameObject.CompareTag("lockcursor")&&(mindist>(index.gameObject.transform.position-this.gameObject.transform.position).sqrMagnitude)) {
                    target = index;
                    lockcursor.transform.position= hit.point;
                    lockcursor.transform.LookAt(head.transform.position);
                    mindist = (index.gameObject.transform.position - this.gameObject.transform.position).sqrMagnitude;
                }
            }
        }

        if (target != null) {
            if (!Physics.Raycast(head.gameObject.transform.position, (target.transform.position - head.gameObject.transform.position), 500f)) target = null;
        }
    }

}
