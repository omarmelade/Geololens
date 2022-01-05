using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;


public class PivotConstraint : TransformConstraint
{
    [SerializeField]
    [Tooltip("Constrain rotation about an axis")]
    public GameObject constraintPoint;
    private float angleAtStart;
    public float AngleAtStart{
        get => angleAtStart;
        set => angleAtStart = value;
    }

    public override TransformFlags ConstraintType => TransformFlags.Move;

    public override void Initialize(MixedRealityTransform worldPose)
    {
        base.Initialize(worldPose);
        constraintPoint = GetComponent<pinnedObject>().PivotPin;
    }

    public override void ApplyConstraint(ref MixedRealityTransform transform)
    {        
        Vector3 dir = constraintPoint.transform.position - transform.Position;
        float angle = Mathf.Atan2(dir.z,dir.x) * Mathf.Rad2Deg;
        transform.Rotation = Quaternion.AngleAxis(-(angle-angleAtStart), Vector3.up);
    }

}



