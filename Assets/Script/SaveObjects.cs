using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using Microsoft.MixedReality.WorldLocking.Core;

[System.Serializable]
public struct ObjetScene{
    public int instanceID;
    public string path;
    public string name;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    public bool gravity;
    public bool kinematic;
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
    // [SerializeField]
    public WorldLockingManager LockingManager;
    public void recup()
    {
        print("recup");
        Save s = new Save();
        List<ObjetScene> listeObjet = new List<ObjetScene>();
        Object[] GameobjectList = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject go in GameobjectList)
        {
            if(go.GetComponent<Saveable>() && go.active){
                // print(PrefabUtility.GetCorrespondingObjectFromSource(go));
                print(go.name);
                // string path = AssetDatabase.GetAssetPath(go);
                string path = go.name.Replace("(Clone)", "");
                print(path);
                print(go);
                if(path!=""){
                    // path = path.Replace(".prefab", "");
                    // path = path.Replace("Assets/Resources/", "");
                    ObjetScene os = new ObjetScene();
                    os.instanceID = go.GetInstanceID();
                    os.path = path;
                    os.name = go.name.Replace("(Clone)", "");
                    os.position = go.transform.position;
                    os.rotation = go.transform.rotation.eulerAngles;
                    os.scale = go.transform.localScale;
                    os.gravity = go.GetComponent<Rigidbody>().useGravity;
                    os.kinematic = go.GetComponent<Rigidbody>().isKinematic;
                    if (go.GetComponent<pinObject>())
                    {
                        os.isPinned = go.GetComponent<pinObject>().isPinned;
                        os.refGO = go.GetComponent<pinObject>().RefGO;
                    }
                    listeObjet.Add(os);                  
                }
            }

        }
        s.objects = listeObjet;
        string jsonSave = JsonUtility.ToJson(s,true);
        File.WriteAllText(Application.dataPath + "/Resources/save.json", jsonSave);
        print(jsonSave.GetType());
        print(jsonSave);
    }



   public void LoadSave()
   {
        print("LoadSave");
        string json = File.ReadAllText(Application.dataPath + "/Resources/save.json");
        Save s = JsonUtility.FromJson<Save>(json);
        foreach (ObjetScene os in s.objects)
        {
            GameObject go = Resources.Load<GameObject>(os.path);
            GameObject go2 = Instantiate(go, os.position, Quaternion.Euler(os.rotation));
            go2.transform.localScale = os.scale;
            go2.name = os.name;
            go2.GetComponent<Rigidbody>().useGravity = os.gravity;
            go2.GetComponent<Rigidbody>().isKinematic = os.kinematic;
            if (os.isPinned)
            {
                go2.GetComponent<pinObject>().isPinned = true;
                go2.GetComponent<pinObject>().RefGO = os.refGO;
            }
        }
    }

    public void SaveWorldLock(){
        LockingManager.Save();
    }

    public void LoadWorldLock(){
        LockingManager.Load();
    }

}