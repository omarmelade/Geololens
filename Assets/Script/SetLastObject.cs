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
        if(lastSelected != null)
        {
            lastSelected.gameObject.GetComponent<VirtualObject>().textArbo.color = Color.white;
        }
        lastSelected = transform.gameObject;
        if (transform.gameObject.GetComponent<VirtualObject>().textArbo != null)
        {
            transform.gameObject.GetComponent<VirtualObject>().textArbo.color = Color.green;
        }
        Debug.Log(lastSelected);
    }
}