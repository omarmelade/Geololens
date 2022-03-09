using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using System;

public class SliderManagement : MonoBehaviour
{
    public String axe;
    private GameObject obj;
    public PinchSlider slider;
    public GameObject valV;

    private bool holding = false;
    private Vector3 posAtBegin = Vector3.zero;


    public void Start()
    {
        obj = transform.parent.parent.gameObject.GetComponent<ObjectTarget>().GetTarget();
    }

    /// ------------------ POSITION
    public void ChangePositionVal()
    {
        float sliderVal = (slider.SliderValue - 0.5f) * 2f;
        setupPos();
        Vector3 newVectorPos;
        float posValToText;
        
        switch (axe)
        {
            case "x":
                newVectorPos = new Vector3(sliderVal + posAtBegin.x, obj.transform.position.y, obj.transform.position.z);
                posValToText = sliderVal + posAtBegin.x;
                break;
            case "y":
                newVectorPos = new Vector3(obj.transform.position.x, sliderVal + posAtBegin.y, obj.transform.position.z);
                posValToText = sliderVal + posAtBegin.y;
                break;
            case "z":
                newVectorPos = new Vector3(obj.transform.position.x, obj.transform.position.y, sliderVal + posAtBegin.z);
                posValToText = sliderVal + posAtBegin.z;
                break;
            default:
                newVectorPos = new Vector3();
                posValToText = sliderVal + posAtBegin.x;
                break;
        }
        
        obj.transform.position = holding ? newVectorPos : obj.transform.position;
        TextMeshPro valTxtV = valV.GetComponent<TextMeshPro>();
        valTxtV.SetText($"{Math.Round(posValToText, 2)}");
    }


  
    public void setupPos()
    {
        if (!holding)
        {
            posAtBegin = obj.transform.position;
            holding = true;
        }
    }
    public void setSlidePosVal()
    {
        if(posAtBegin != obj.transform.position)
        {
            posAtBegin = obj.transform.position;
        }
    }

    

     /// ------------------ SCALE
    public void ChangeScaleVal()
    {
        float sliderVal = (slider.SliderValue - 0.5f) * 2f;
        setupScale();
        Vector3 newVectorScale;
        float scaleValToText;
        switch (axe)
        {
            case "x":
                newVectorScale = new Vector3(sliderVal + posAtBegin.x, obj.transform.localScale.y, obj.transform.localScale.z);
                scaleValToText = sliderVal + posAtBegin.x;
                break;
            case "y":
                newVectorScale = new Vector3(obj.transform.localScale.x, sliderVal + posAtBegin.y, obj.transform.localScale.z);
                scaleValToText = sliderVal + posAtBegin.y;
                break;
            case "z":
                newVectorScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, sliderVal + posAtBegin.z);
                scaleValToText = sliderVal + posAtBegin.z;
                break;
            default:
                newVectorScale = new Vector3();
                scaleValToText = sliderVal + posAtBegin.x;
                break;
        }

        obj.transform.localScale = holding ? newVectorScale : obj.transform.localScale;
        TextMeshPro valTxtV = valV.GetComponent<TextMeshPro>();
        valTxtV.SetText($"{Math.Round(scaleValToText, 2)}");
    }



    public void setupScale()
    {
        if (!holding)
        {
            posAtBegin = obj.transform.localScale;
            holding = true;
        }
    }
    public void setSlideScaleVal()
    {
        if(posAtBegin != obj.transform.localScale)
        {
            posAtBegin = obj.transform.localScale;
        }
    }


    /// ----- RESET Slider
    public void resetSlide()
    {
        holding = false;
        slider.SliderValue = 0.5f;
    }

}

