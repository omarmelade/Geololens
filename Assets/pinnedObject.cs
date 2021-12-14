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

    }
    private void OnTriggerEnter(Collider other)
    {
        pins = GameObject.FindGameObjectsWithTag("Balise");
        foreach (GameObject pin in pins)
        {
            if (other.gameObject == pin)
            {
                GetComponent<RotationPointConstraint>().constraintPoint = pin.transform;
                GetComponent<RotationPointConstraint>().enabled = true;
                GetComponent<Microsoft.MixedReality.Toolkit.UI.MoveAxisConstraint>().enabled = true;
                isPinned = true;
            }
        }
        print("Object is pinned");
    }
}
