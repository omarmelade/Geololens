using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;

using UnityEngine;

public class pinnedObject : MonoBehaviour
{

    public GameObject[] pins;
    private bool isPinned = false;
    private GameObject firstPin;
    public GameObject FirstPin{
        get => firstPin;
        set => firstPin = value;
    }
    private bool isPinnedTwice = false;

    void Awake(){
        GetComponent<PivotConstraint>().enabled = false;
        GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().enabled = false;
        GetComponent<Microsoft.MixedReality.Toolkit.UI.FixedDistanceConstraint>().enabled = false;
        GetComponent<Microsoft.MixedReality.Toolkit.UI.RotationAxisConstraint>().enabled = false;

    }

    public void Pin(GameObject pin)
    {
        if (!isPinned)
        {
            firstPin = pin;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().enabled = true;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.FixedDistanceConstraint>().enabled = true;
            GetComponent<PivotConstraint>().constraintPoint = pin;
            GetComponent<PivotConstraint>().enabled = true;
            print("Premier pin");
            isPinned = true;
        }
        else if (!isPinnedTwice)
        {
            GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().ConstraintOnMovement = (AxisFlags) 7;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.RotationAxisConstraint>().enabled = true;
            GetComponent<PivotConstraint>().enabled = false;
            print("Deuxième pin");
            isPinnedTwice = true;
        }
    }
}
