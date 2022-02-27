using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // Start is called before the first frame update
    weapontype wptype;
    int damage;
    damagedef ddef;
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnCollisionEnter(Collision collision) {
        
        collision.gameObject.SendMessage("Damage", ddef, SendMessageOptions.DontRequireReceiver);
        Destroy(this.gameObject);
    }
    public void setdamage(damagedef sdamage) => ddef = sdamage;
}
