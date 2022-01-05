using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveObjects : MonoBehaviour
{
    public void recup()
    {
        print("recup");
        Object[] GameobjectList = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject go in GameobjectList)
        {
            
            if(go.GetComponent<Saveable>()){
                string path = AssetDatabase.GetAssetPath(go);
                print(go);
                if(path!=""){
                    path = path.Replace(".prefab", "");
                    path = path.Replace("Assets/Resources/", "");
                    Instantiate(Resources.Load<GameObject>(path));
                }
            }

        }
    }
   
}
