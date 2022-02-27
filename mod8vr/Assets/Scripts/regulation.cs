using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weapontype {
    solid,
    energy
}
public enum shouldertype {
    rocket,
    missile,
    cannon
}
[System.Serializable]
public class regulationdata {
    public head[] headdata;
    public body[] bodydata;
    public arms[] armsdata;
    public legs[] legsdata;
    public weapon[] weapondata;
    public shoulder[] shoulderdata;
}
[System.Serializable]
public class head {
    public string name;
    public int ap;
    public int weight;
    public int solid_def;
    public int energy_def;
}
[System.Serializable]
public class body {
    public string name;
    public int ap;
    public int weight;
    public int solid_def;
    public int energy_def;
    public float energy_max;
    public float vertical_boost_power;
    public float vertical_boost_energy;
}
[System.Serializable]
public class legs {
    public string name;
    public int ap;
    public int weight;
    public int solid_def;
    public int energy_def;
    public float horizontal_boost_power;
    public float horizontal_boost_energy;
}
[System.Serializable]
public class arms {
    public string name;
    public bool isweaponarm;
    public int ap;
    public int weight;
    public int solid_def;
    public int energy_def;
    public int weapon_use_damage;
    public float weapon_use_energy;
    public int weapon_arm_ammocount;
}
[System.Serializable]
public class weapon {
    public string name;
    public weapontype type;
    public int damage;
    public float velocity;
    public short ammocount;
    public int reload;
}
[System.Serializable]
public class shoulder {
    public string name;
    public weapontype type;
    public shouldertype stype;
    public int damage;
    public float velocity;
    public short ammocount;
    public int reload;
    public Vector3 firedirection;
    public float trackstarttime;
    public float trackendtime;
    public float trackperformance;
}

