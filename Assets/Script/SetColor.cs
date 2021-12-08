using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    
    Color green = Color.green;
    Color red = Color.white;
    public GameObject obj;

    public bool selected;
    public float minWidth;
    public float maxWidth;

    public void SelectColor()
    {
        selected = true;
        //GameObject[] objs = new GameObject[];
        StartCoroutine("SelectColor");

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

    IEnumerator Selected(GameObject[] objs){
        float currentWidth = minWidth;
        float step = (maxWidth-minWidth)/100.0f;
        while (selected && currentWidth<maxWidth)
        {
            currentWidth += step;
            if(currentWidth>maxWidth){
                currentWidth = maxWidth;
            }
            foreach (GameObject obj in objs)
            {
                obj.GetComponent<Outline>().OutlineWidth = currentWidth;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Unselected(GameObject[] objs){
        float currentWidth = minWidth;
        float step = (maxWidth-minWidth)/100.0f;
        while (!selected && currentWidth>minWidth)
        {
            currentWidth -= step;
            if(currentWidth<minWidth){
                currentWidth = minWidth;
            }
            foreach (GameObject obj in objs)
            {
                obj.GetComponent<Outline>().OutlineWidth = currentWidth;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

}
