using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    
    Color green = Color.green;
    Color red = Color.white;
    public GameObject obj;

    public void SelectColor()
    {
        if(obj.transform.childCount > 0)
        {
  
            var mesh = obj.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < mesh.Length; i++)
            {
                mesh[i].material.color = green;
            }

        }else
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material.color = green;
        }

    }

    public void UnSelectColor()
    {
        if (obj.transform.childCount > 0)
        {

            var mesh = obj.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < mesh.Length; i++)
            {
                mesh[i].material.color = red;
            }

        }
        else
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material.color = red;
        }
    }

}
