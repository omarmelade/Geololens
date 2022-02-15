using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System;
using Newtonsoft.Json.Linq;

[Serializable]
public struct RadiationByMonth
{
    public RadiationByMonth(int month)
    {
        _month = month;
        _tabMonthRadiation = new List<RadiationByHour>();
    }
    public int _month;
    public List<RadiationByHour> _tabMonthRadiation;
}

[Serializable]
public struct RadiationByHour
{
    public RadiationByHour(int time, double globalIrradiance)
    {
        _time = time;
        _globalIrradiance = globalIrradiance;
    }
    public int _time;
    public double _globalIrradiance;
}


public class SolarPanelPowerDelivery : MonoBehaviour
{


    private List<RadiationByMonth> tabRadiationByMonth = new List<RadiationByMonth>();
    // Start is called before the first frame update
    void Start()
    {   
        for(int i = 1; i <= 12; i++)
        {
            GetRadiationByMonth(i);
        }
        print("Production de 15H à 9H ( " + mod(15-9, 24) + "H ) : " + ProducedPowerPerRangeHour(1,350,9,15,2) );
        print("Production de 15H à 9H ( " + mod(15-9, 24) + "H ) : " + ProducedPowerPerRangeHour(1,350,9,15,8) );
    }

    // Update is called once per frame
    void Update()
    {}

    private void GetRadiationByMonth( int month )
    {
        
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format($"https://re.jrc.ec.europa.eu/api/DRcalc?lat=45.643&lon=5.871&month={month}&global=1&outputformat=json"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        JObject json  = JObject.Parse(jsonResponse);
        
        RadiationByMonth radiationByMonth = new RadiationByMonth(month);

        foreach (JObject item in json["outputs"]["daily_profile"])
        {
            int time = int.Parse(item["time"].ToObject<string>().Substring(0,2));
            double radiation = item["G(i)"].ToObject<double>();

            RadiationByHour rBH = new RadiationByHour(time, radiation);
            radiationByMonth._tabMonthRadiation.Add(rBH);
        }
        tabRadiationByMonth.Add(radiationByMonth);
    }

    // calculate the efficiency of solar panel
    // r = (Wc/(radiation*panelSize))/100
    private double Efficiency(double WattCrete, double radiation, double panelSize ){
        return (WattCrete/ (radiation*panelSize)) * 100;
    }
    
    // E = ( (Tp*1000) * r1 *h1 ) /1000
    private double ProducedPowerPerHour(double panelSize, double WattCrete, double radiation)
    {
        // double r = Efficiency(WattCrete, radiation, panelSize);
        double r = 0.14;
        double energy = ((panelSize * radiation) * r) / 1000;

        return energy;
    }
    
    public double ProducedPowerPerRangeHour(double panelSize, double WattCrete, int hourExposedStart, int hourExposedEnd, int month)
    {
        if (hourExposedStart > hourExposedEnd)
        {
            int tmp = hourExposedStart;
            hourExposedStart = hourExposedEnd;
            hourExposedEnd = tmp;
        }
        int Hrange = mod((hourExposedEnd - hourExposedStart), 24);
        double kwPerH = 0;
        for (int i = 1; i <= Hrange; i++)
        {
            double radiation = tabRadiationByMonth[month-1]._tabMonthRadiation[hourExposedStart+i]._globalIrradiance;
            kwPerH += ProducedPowerPerHour(panelSize, WattCrete, radiation);
            // print(radiation);
            // print(hourExposedStart+i +": "+ "kw :" + kwPerH);
        }
        return kwPerH;
    }

    public int mod(int x, int m) {
        return (x%m + m) % m;
    }


    // public void updateValHPlus(){
        

    //     valtxtX.SetText("");
    //     valtxtX.SetText("Heures : " + valtxtX.text);
    //     double valPower = ProducedPowerPerRangeHour(1.5, 350, (int)sliderVal, (int)sliderVal1, (int)sliderValM);
    //     valResTxt.SetText("Power Produced : " + valPower + " Kw/H");
    // }

}
