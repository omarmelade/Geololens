using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinnedObject : MonoBehaviour
{
 private void OnTriggerEnter(Collider other)
    {
        print("Object is pinned");
    }
}
