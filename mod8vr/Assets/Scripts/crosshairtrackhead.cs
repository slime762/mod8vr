using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairtrackhead : MonoBehaviour {
    [SerializeField] GameObject head, target;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        target.transform.localRotation = head.transform.localRotation;

    }
}
