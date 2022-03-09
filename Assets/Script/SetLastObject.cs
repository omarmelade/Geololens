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
        lastSelected.gameObject.GetComponent<VirtualObject>().textArbo.color = Color.white;
        lastSelected = transform.gameObject;
        transform.gameObject.GetComponent<VirtualObject>().textArbo.color = Color.green;
        Debug.Log(lastSelected);
    }
}