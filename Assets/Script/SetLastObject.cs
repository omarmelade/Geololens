using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLastObject : MonoBehaviour
{
    public static GameObject lastSelected = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLastSelectedObject()
    {
        lastSelected = transform.gameObject;
        Debug.Log(lastSelected);
    }
}
