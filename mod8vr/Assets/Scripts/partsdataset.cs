using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class partsdataset : MonoBehaviour {
    // Start is called before the first frame update
    public regulationdata regdata;
    public string jsondata;

    public void savegamedata() {
        StreamWriter writer = new StreamWriter(Application.dataPath + "/regulation.json", false);
        jsondata = JsonUtility.ToJson(regdata);
        writer.Write(jsondata);
        writer.Flush();
        writer.Close();
    }
    public void loadgamedata() {

        StreamReader reader = new StreamReader(Application.dataPath + "/regulation.json");
        jsondata = reader.ReadToEnd();
        reader.Close();
        regdata = JsonUtility.FromJson<regulationdata>(jsondata);
    }
}

/*public enum weapontype {
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
    private head[] headdata;
    private body[] bodydata;
    private arms[] armsdata;
    private legs[] legsdata;
    private weapon[] weapondata;
    private shoulder[] shoulderdata;
}
[System.Serializable]
public class head {

    private string name;
    private int ap;
    private int weight;
    private int solid_def;
    private int energy_def;
}
[System.Serializable]
public class body {
    public body(string name, int ap, int weight, int solid_def, int energy_def, int vertical_boost_power, int vertical_boost_energy) {
        this.ap = ap;
        this.weight = weight;
        this.solid_def = solid_def;
        this.energy_def = energy_def;
        this.vertical_boost_power = vertical_boost_power;
        this.vertical_boost_energy = vertical_boost_energy;
    }
    private string name;
    private int ap;
    private int weight;
    private int solid_def;
    private int energy_def;
    private float energy_max;
    private float vertical_boost_power;
    private float vertical_boost_energy;
}
[System.Serializable]
public class legs {
    private string name;
    private int ap;
    private int weight;
    private int solid_def;
    private int energy_def;
    private float horizontal_boost_power;
    private float horizontal_boost_energy;
}
[System.Serializable]
public class arms {
    private string name;
    private bool isweaponarm;
    private int ap;
    private int weight;
    private int solid_def;
    private int energy_def;
    private float weapon_use_power;
    private float weapon_use_energy;
}
[System.Serializable]
public class weapon {
    private string name;
    private weapontype type;
    private int damage;
    private float velocity;
    private short ammocount;
    private float reload;
}
[System.Serializable]
public class shoulder {
    private string name;
    private weapontype type;
    private shouldertype stype;
    private int damage;
    private float velocity;
    private short ammocount;
    private float reload;
}
*/




/*public enum weapontype {
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
    public float weapon_use_power;
    public float weapon_use_energy;
}
[System.Serializable]
public class weapon {
    public string name;
    public weapontype type;
    public int damage;
    public float velocity;
    public short ammocount;
    public float reload;
}
[System.Serializable]
public class shoulder {
    public string name;
    public weapontype type;
    public shouldertype stype;
    public int damage;
    public float velocity;
    public short ammocount;
    public float reload;
}
*/