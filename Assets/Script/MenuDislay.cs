using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDislay : MonoBehaviour
{

    public GameObject go;

    public void afficheMenu()
    {
        go.SetActive(!go.active);
    }
}
