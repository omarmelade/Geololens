using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    
    Color green = Color.green;
    Color red = Color.white;

    public bool selected;
    public float minWidth;
    public float maxWidth;

    public void SelectColor()
    {
        selected = true;
        StartCoroutine("Selected");
    }

    public void UnSelectColor()
    {
        
        selected = false;
        StartCoroutine("Unselected");
    }

    IEnumerator Selected(){
        float currentWidth = this.GetComponent<Outline>().OutlineWidth;
        float step = (maxWidth-minWidth)/10.0f;
        while (selected && currentWidth<maxWidth)
        {
            currentWidth += step;
            if(currentWidth>maxWidth){
                currentWidth = maxWidth;
            }
            this.GetComponent<Outline>().OutlineWidth = currentWidth;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Unselected(){
        float currentWidth = this.GetComponent<Outline>().OutlineWidth;
        float step = (maxWidth-minWidth)/10.0f;
        while (!selected && currentWidth>minWidth)
        {
            currentWidth -= step;
            if(currentWidth<minWidth){
                currentWidth = minWidth;
            }
            this.GetComponent<Outline>().OutlineWidth = currentWidth;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
