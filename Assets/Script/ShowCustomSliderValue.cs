//
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;


public class ShowCustomSliderValue : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textMesh = null;

    [SerializeField]
    private int SliderMultiplicator;

    public int SliderMultiplicatorValue
    {
        get { return SliderMultiplicator; }
    }

    [SerializeField]
    private int SliderAdd;

    public int sliderAdd{
        get{
            return SliderAdd;
        }
    }

    [SerializeField]
    private List<string> SliderTab;


    // public bool isPopulated = SliderTab.Count > 0;

    private float valeurSlider = -2.0f;

    public float ValeurSlider
    {
        get { return valeurSlider; }
    }

    public void OnSliderUpdated(SliderEventData eventData)
    {
        valeurSlider = eventData.NewValue;
        if (textMesh == null)
        {
            textMesh = GetComponent<TextMeshPro>();
        }

        if (textMesh != null)
        {
            textMesh.text = $"{((SliderMultiplicator*valeurSlider)+SliderAdd):F2}";
        }
        if (SliderTab.Count > 0)
        {
            // print(SliderTab[(int)(valeurSlider*SliderMultiplicator)]);
            textMesh.text = SliderTab[(int)(0.01+valeurSlider*SliderMultiplicator)];
        }
    }
}

