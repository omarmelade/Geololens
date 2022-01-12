using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;

using UnityEngine;

public class pinnedObject : MonoBehaviour
{
    public List<GameObject> pins;
    private GameObject pivotPin;
    public GameObject PivotPin{
        get => pivotPin;
        set => pivotPin = value;
    }

    void Awake(){
        GetComponent<PivotConstraint>().enabled = false;
        GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().enabled = false;
        GetComponent<Microsoft.MixedReality.Toolkit.UI.FixedDistanceConstraint>().enabled = false;
        GetComponent<Microsoft.MixedReality.Toolkit.UI.RotationAxisConstraint>().enabled = false;

    }

    void Update(){
        if (Input.GetButtonDown("RemoveFirstPin"))
        {
            print("Tentative d'enlèvement de pin.");
            print(pins.Count);
            if(pins.Count > 0) {
                pins[0].GetComponent<pinObject>().RemovePin();
            }
            print(pins.Count);
        }
    }

    public void Pin(GameObject pin)
    {
        if (pins.Count == 0) //Si il n'y avait pas de pins
        {
            pivotPin = pin;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().enabled = true;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.FixedDistanceConstraint>().enabled = true;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.RotationAxisConstraint>().enabled = false;
            GetComponent<PivotConstraint>().constraintPoint = pin;
            GetComponent<PivotConstraint>().enabled = true;
            Vector3 dir = pin.transform.position - this.transform.position;
            GetComponent<PivotConstraint>().AngleAtStart = Mathf.Atan2(dir.z,dir.x) * Mathf.Rad2Deg;
        }
        else if (pins.Count == 1) //Si il y a déjà un pin pivot alors on fixe
        {
            GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().ConstraintOnMovement = (AxisFlags) 7;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.RotationAxisConstraint>().enabled = true;
            GetComponent<PivotConstraint>().enabled = false;
        }
        pins.Add(pin);
    }

    public void UnPin(GameObject pin)
    {
        pins.Remove(pin);
        if(pins.Count == 1){ //Si il n'en reste plus qu'un
            pivotPin = pins[0];
            GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().ConstraintOnMovement = (AxisFlags) 2;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().enabled = true;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.FixedDistanceConstraint>().enabled = true;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.RotationAxisConstraint>().enabled = false;
            GetComponent<PivotConstraint>().constraintPoint = pivotPin;
            GetComponent<PivotConstraint>().enabled = true;
            Vector3 dir = pivotPin.transform.position - this.transform.position;
            GetComponent<PivotConstraint>().AngleAtStart = Mathf.Atan2(dir.z,dir.x) * Mathf.Rad2Deg;
        }
        if(pins.Count == 0){ //Si il n'y en a plus
            GetComponent<PivotConstraint>().enabled = false;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().enabled = false;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.FixedDistanceConstraint>().enabled = false;
            GetComponent<Microsoft.MixedReality.Toolkit.UI.RotationAxisConstraint>().enabled = false;
        }
        Destroy(pin);
    }
}
