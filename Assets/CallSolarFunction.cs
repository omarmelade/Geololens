using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;

public class CallSolarFunction : MonoBehaviour
{

    public TextMeshPro textMesh;
    public PinchSlider sliderHStart;
    public PinchSlider sliderHEnd;
    public PinchSlider sliderM;
 
    public void calculate(){
        float hStart = sliderHStart.SliderValue;
        float hEnd = sliderHEnd.SliderValue;
        float m = sliderM.SliderValue;

        if (hStart >= 0.0f && hEnd >=0.0 && m >=0.0f){

                ShowCustomSliderValue hstart = sliderHStart.GetComponentInChildren<ShowCustomSliderValue>();
                ShowCustomSliderValue hend = sliderHEnd.GetComponentInChildren<ShowCustomSliderValue>();
                ShowCustomSliderValue mValue = sliderM.GetComponentInChildren<ShowCustomSliderValue>();

                int valueHStart = (int)((hstart.ValeurSlider * hstart.SliderMultiplicatorValue) + hstart.sliderAdd);
                int valueHEnd = (int)((hend.ValeurSlider * hend.SliderMultiplicatorValue) + hend.sliderAdd);
                int valueM = (int)(mValue.ValeurSlider * mValue.SliderMultiplicatorValue + mValue.sliderAdd);

                SolarPanelPowerDelivery solarPanelPowerDelivery = GetComponent<SolarPanelPowerDelivery>();
                double res = solarPanelPowerDelivery.ProducedPowerPerRangeHour(1,350,valueHStart,valueHEnd,valueM);
                textMesh.text = res.ToString();
        }
    }
}
