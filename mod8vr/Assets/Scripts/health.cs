using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] int ap, soliddef, energydef;
    public void Damage(damagedef ddef) {
        ap = ap - (ddef.damage * (soliddef + 425)) / 950 - (ddef.damage * (energydef + 425) / 950);
        if (ap <= 0) this.gameObject.SetActive(false);
    }
}
