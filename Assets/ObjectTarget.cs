using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTarget : MonoBehaviour
{

    public GameObject target;

    public void SetTarget(GameObject t)
    {
        target = t;
    }

    public GameObject GetTarget()
    {
        return target;
    }

}
