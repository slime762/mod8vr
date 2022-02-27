using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asm : MonoBehaviour
{
    [SerializeField] GameObject head, body, arms, legs, leftarmweapon,rightarmweapon,leftbackweapon,rightbackweapon,shoulder;
    [SerializeField] string tagstring;
    GameObject gamecore;
    public bool asmbutton;
    regulationloader regloader;
    regulationdata regdat;
    // Start is called before the first frame update
    void Start(){
        gamecore = GameObject.FindGameObjectWithTag("System");
        regloader = gamecore.GetComponent<regulationloader>();
        regdat = regloader.getregulationdata();
    }
    private void Update() {
        if (asmbutton)
            doasm();
    }
    // Update is called once per frame
    void doasm() {
        
    }
}
