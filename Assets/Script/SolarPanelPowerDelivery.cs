using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System;

[Serializable]
public struct RadiationByMonth
{
    public List<RadiationByHour> monthRadiation;
}

[Serializable]
public struct RadiationByHour
{
    int month;
    int time;
    double globalIrradiance;
    double directIrradiance;
    double diffuseIrradiance;
}

public class SolarPanelPowerDelivery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        GetRadiationByMonth(2);
        print( ProducedPowerPerHour(1.6, 4.5, 320) );
    }

    // Update is called once per frame
    void Update()
    {}

    private void GetRadiationByMonth( int month )
    {

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format($"https://re.jrc.ec.europa.eu/api/DRcalc?lat=45&lon=8&month={month}&global=1&outputformat=json"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        string res = JsonUtility.ToJson(jsonResponse);
        print(res);
    }

    // calculate the efficiency of solar panel
    // r = (Wc/(radiation*panelSize))/100
    private double Efficiency(double WattCrete, double radiation, double panelSize ){
        return (WattCrete/ (radiation*panelSize))/100;
    }
    
    // E = ( (Tp*1000) * r1 *h1 ) /1000
    private double ProducedPowerPerHour(double panelSize, double hour, double WattCrete)
    {
        
        double radiation = 79.96; // for 15h
        double r = Efficiency(WattCrete, radiation, panelSize);
        double energy = ((panelSize * 1000) * r * hour) / 1000;
        return energy;
    }


    private void save()
    {
        string json = File.ReadAllText
    }

}
