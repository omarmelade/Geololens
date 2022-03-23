using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using System;

public class SliderScale : MonoBehaviour
{
    private GameObject obj;
    public PinchSlider slider;

    public GameObject valX;
    public GameObject valY;
    public GameObject valZ;

    private bool holding = false;
    private Vector3 posAtBegin = Vector3.zero;

    public void setObj()
    {
        obj = transform.parent.transform.parent.GetComponent<ObjectTarget>().GetTarget();
    }

    public void changeX()
    {
        float sliderVal = (slider.SliderValue - 0.5f) * 2;
        setupPos();
        obj.transform.localScale = holding ? new Vector3(sliderVal + posAtBegin.x, obj.transform.localScale.y, obj.transform.localScale.z) : obj.transform.localScale;


        TextMeshPro valtxtX = valX.GetComponent<TextMeshPro>();
        valtxtX.SetText($"{Math.Round(obj.transform.localScale.x, 2)}");
    }

    public void changeY()
    {
        float sliderVal = (slider.SliderValue - 0.5f) * 2;
        setupPos();
        obj.transform.localScale = holding ? new Vector3(obj.transform.localScale.x, sliderVal + posAtBegin.y, obj.transform.localScale.z) : obj.transform.localScale;


        TextMeshPro valtxtY = valY.GetComponent<TextMeshPro>();
        valtxtY.SetText($"{Math.Round(obj.transform.localScale.y, 2)}");
    }

    public void changeZ()
    {
        float sliderVal = (slider.SliderValue - 0.5f) * 2;
        setupPos();
        obj.transform.localScale = holding ? new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, sliderVal + posAtBegin.z) : obj.transform.localScale;


        TextMeshPro valtxtZ = valZ.GetComponent<TextMeshPro>();
        valtxtZ.SetText($"{Math.Round(obj.transform.localScale.z, 2)}");
    }


    public void setupPos()
    {
        setObj();
        if (!holding)
        {
            posAtBegin = obj.transform.localScale;
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
        if (posAtBegin != obj.transform.localScale)
        {
            posAtBegin = obj.transform.localScale;
        }
    }
}
