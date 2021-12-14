using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;


public class RotationPointConstraint : TransformConstraint
{
    [SerializeField]
    [Tooltip("Constrain rotation about an axis")]
    public GameObject constraintPoint;
    private float angleAtStart;

    public override TransformFlags ConstraintType => TransformFlags.Move;

    public override void Initialize(MixedRealityTransform worldPose)
    {
        base.Initialize(worldPose);
        Vector3 dir = constraintPoint.transform.position - this.transform.position;
        angleAtStart = Mathf.Atan2(dir.z,dir.x) * Mathf.Rad2Deg;
    }

    public override void ApplyConstraint(ref MixedRealityTransform transform)
    {
        // Quaternion rotation = transform.Rotation * Quaternion.Inverse(constraintPoint.rotation);
        // Vector3 eulers = rotation.eulerAngles;

        // eulers.x = 0;
        // eulers.z = 0;

        // transform.Rotation = Quaternion.Euler(eulers) * constraintPoint.rotation;

        /*
        Vector3 pos = transform.Position;
        pos.x -= constraintPoint.position.x;
        pos.z -= constraintPoint.position.z;

        Vector3 dir = transform.Position - constraintPoint.position;
        dir += angleAtStart;
        float angle = Mathf.Atan2(dir.z,dir.x) * Mathf.Rad2Deg;
        transform.Rotation = Quaternion.AngleAxis(angle, Vector3.up);
        */
        
        Vector3 dir = constraintPoint.transform.position - transform.Position;
        float angle = Mathf.Atan2(dir.z,dir.x) * Mathf.Rad2Deg;

        print(angle-angleAtStart);
        transform.Rotation = Quaternion.AngleAxis(-(angle-angleAtStart), Vector3.up);
        
    }


}



