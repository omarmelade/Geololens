using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObjects : MonoBehaviour
{
    public void recup()
    {
        print("recup");
        Object[] GameobjectList = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject go in GameobjectList)
        {
            print(go.name);
        }
    }
}
