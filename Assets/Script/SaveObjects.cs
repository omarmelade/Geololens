using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public struct ObjetScene{
    public int instanceID;
    public string path;
    public string name;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    public bool gravity;
    public bool isPinned;
    public GameObject refGO;
}

[System.Serializable]
public struct Save
{
    public List<ObjetScene> objects;
}

public class SaveObjects : MonoBehaviour
{
    public void recup()
    {
        // var json = new Dictionary<string,dynamic>(); 
        print("recup");
        Save s = new Save();
        List<ObjetScene> listeObjet = new List<ObjetScene>();
        Object[] GameobjectList = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject go in GameobjectList)
        {
            
            if(go.GetComponent<Saveable>()){
                string path = AssetDatabase.GetAssetPath(go);
                print(go);
                if(path!=""){
                    path = path.Replace(".prefab", "");
                    path = path.Replace("Assets/Resources/", "");
                    ObjetScene os = new ObjetScene();
                    os.instanceID = go.GetInstanceID();
                    os.path = path;
                    os.name = go.name;
                    os.position = go.transform.position;
                    os.rotation = go.transform.rotation.eulerAngles;
                    os.scale = go.transform.localScale;
                    os.gravity = go.GetComponent<Rigidbody>().useGravity;
                    if (go.GetComponent<pinObject>())
                    {
                        os.isPinned = go.GetComponent<pinObject>().isPinned;
                        os.refGO = go.GetComponent<pinObject>().RefGO;
                    }
                    listeObjet.Add(os);


                    // System.IO.File.WriteAllText("Asset/Resources/Save/" + save.name + ".json", json);
                    // json.Add("GameObject",path);

                    // var coordonate = new Dictionary<string, float>();
                    // coordonate.Add("x", go.transform.position.x);
                    // coordonate.Add("y", go.transform.position.y);
                    // coordonate.Add("z", go.transform.position.z);
                    // json.Add("coordonate",coordonate);

                    // var rotation = new Dictionary<string, float>();
                    // rotation.Add("x", go.transform.rotation.x);
                    // rotation.Add("y", go.transform.rotation.y);
                    // rotation.Add("z", go.transform.rotation.z);
                    // json.Add("rotation",rotation);

                    // var scale = new Dictionary<string, float>();
                    // scale.Add("x", go.transform.localScale.x);
                    // scale.Add("y", go.transform.localScale.y);
                    // scale.Add("z", go.transform.localScale.z);
                    // json.Add("scale",scale);


                  
                }
            }

        }
        s.objects = listeObjet;
        string jsonSave = JsonUtility.ToJson(s,true);
        print(jsonSave.GetType());
        print(jsonSave);
        // System.IO.File.WriteAllText("Asset/Resources/Save/save.json", jsonSave);
    }
   
}
