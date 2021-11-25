using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showObject : MonoBehaviour
{
   
    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        model.SetActive(false);
    }
    
    public void show()
    {
        model.SetActive(!model.activeSelf);
    }
}
