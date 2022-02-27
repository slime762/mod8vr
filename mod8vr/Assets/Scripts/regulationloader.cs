using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class regulationloader : MonoBehaviour {
    public static regulationloader Instance;
    [SerializeField] regulationdata regdata;
    [SerializeField] bool refreshreg; //REMOVE THIS IN RELEASE
    string jsondata;
    // Start is called before the first frame update
    void Start() {

    }
    private void Awake() {
        loadgamedata();
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update() {
        if (refreshreg) {
            saveregdata();
        }
    }
    void loadgamedata() {
        string jsondata;
        StreamReader reader = new StreamReader(Application.dataPath + "/regulation.json");
        jsondata = reader.ReadToEnd();
        reader.Close();
        regdata = JsonUtility.FromJson<regulationdata>(jsondata);

    }
    public regulationdata getregulationdata() {
        return regdata;
    }
    public void saveregdata() {
        StreamWriter writer = new StreamWriter(Application.dataPath + "/regulation.json", false);
        jsondata = JsonUtility.ToJson(regdata);
        writer.Write(jsondata);
        writer.Flush();
        writer.Close();
    }
}
