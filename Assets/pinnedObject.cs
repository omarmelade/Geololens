using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;

using UnityEngine;

public class pinnedObject : MonoBehaviour
{

    public GameObject[] pins;
    private bool isPinned = false;
    private bool isPinnedTwice = false;

    void Awake(){
        GetComponent<RotationPointConstraint>().enabled = false;
        GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().enabled = false;
        GetComponent<Microsoft.MixedReality.Toolkit.UI.FixedDistanceConstraint>().enabled = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        pins = GameObject.FindGameObjectsWithTag("Balise");
        foreach (GameObject pin in pins)
        {
            if (other.gameObject == pin)
            {
                GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().enabled = true;
                GetComponent<Microsoft.MixedReality.Toolkit.UI.FixedDistanceConstraint>().enabled = true;
                GetComponent<RotationPointConstraint>().constraintPoint = pin;
                GetComponent<RotationPointConstraint>().enabled = true;
                isPinned = true;
            }
        }
        print("Object is pinned");
    }
}
