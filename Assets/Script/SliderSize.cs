using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using System;

public class SliderSize : MonoBehaviour
{
    public GameObject obj;
    public PinchSlider slider;

    public GameObject valX;
    public GameObject valY;
    public GameObject valZ;

    private bool holding = false;
    private Vector3 posAtBegin = Vector3.zero;
    

    public void changeX()
    {
        float sliderVal = (slider.SliderValue - 0.5f) * 2f;
        setupPos();
        obj.transform.position = holding ? new Vector3(sliderVal + posAtBegin.x, obj.transform.position.y, obj.transform.position.z) : obj.transform.position;

        TextMeshPro valtxtX = valX.GetComponent<TextMeshPro>();
        valtxtX.SetText($"{Math.Round(obj.transform.position.x, 2)}");

    }

    public void changeY()
    {
        float sliderVal = (slider.SliderValue - 0.5f) * 2f;
        setupPos();
        obj.transform.position = holding ? new Vector3(obj.transform.position.x, sliderVal + posAtBegin.y, obj.transform.position.z) : obj.transform.position;

        TextMeshPro valtxtY = valY.GetComponent<TextMeshPro>();
        valtxtY.SetText($"{Math.Round(obj.transform.position.y, 2)}");
    }

    public void changeZ()
    {
        float sliderVal = (slider.SliderValue - 0.5f) * 2f;
        setupPos();
        obj.transform.position = holding ? new Vector3(obj.transform.position.x, obj.transform.position.y, sliderVal + posAtBegin.z) : obj.transform.position;

        TextMeshPro valtxtZ = valZ.GetComponent<TextMeshPro>();
        valtxtZ.SetText($"{Math.Round(obj.transform.position.z, 2)}");
    }

    public void setupPos()
    {
        if (!holding)
        {
            posAtBegin = obj.transform.position;
            holding = true;
        }
    }

    public void resetSlide()
    {
        holding = false;
        slider.SliderValue = 0.5f;
    }

    public void setSlideVal()
    {
        if(posAtBegin != obj.transform.position)
        {
            posAtBegin = obj.transform.position;
        }
    }
}

