using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class bwmove : MonoBehaviour {
    public float brekerate;
    [SerializeField] Rigidbody rb;
    public float boostpow, walkpow, turnpow;
    [SerializeField] GameObject gamecore;
    GameCore gc;
    // Start is called before the first frame update
    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody>();
        gamecore = GameObject.FindGameObjectWithTag("System");
        gc = gamecore.GetComponent<GameCore>();
    }
    public void bwlocomotion(Vector2 input, bool activateboost) {

        if (input.magnitude > 1.0f) {
            input = new Vector2(input.x / input.magnitude, input.y / input.magnitude);
        }
        Vector3 movevec = (this.gameObject.transform.forward * input.y + this.gameObject.transform.right * input.x);
        if (Input.GetKey(KeyCode.W))
            movevec += this.gameObject.transform.forward;
        if (Input.GetKey(KeyCode.S))
            movevec -= this.gameObject.transform.forward; ;
        if (Input.GetKey(KeyCode.A))
            movevec -= this.gameObject.transform.right;
        if (Input.GetKey(KeyCode.D))
            movevec += this.gameObject.transform.right;
        if (activateboost) {
            rb.AddForce(movevec * boostpow * Time.deltaTime);
        }
        else {
            rb.AddForce(movevec * walkpow * Time.deltaTime);
        }
        rb.AddForce(rb.velocity * (-brekerate));
    }
    public void bwturnleft() {
        this.gameObject.transform.Rotate(0, -turnpow * Time.deltaTime, 0);
        Debug.Log("left");
    }
    public void bwturnright() {
        this.gameObject.transform.Rotate(0, turnpow * Time.deltaTime, 0);
        Debug.Log("right");
    }

    // Update is called once per frame
    void Update() {

    }
}
