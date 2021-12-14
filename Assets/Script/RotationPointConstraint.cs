using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;


public class RotationPointConstraint : TransformConstraint
{
    [SerializeField]
    [Tooltip("Constrain rotation about an axis")]
    public Transform constraintPoint;
    private Quaternion startObjectRotationPoint;

    public override TransformFlags ConstraintType => TransformFlags.Rotate;

    public override void Initialize(MixedRealityTransform worldPose)
        {
            base.Initialize(worldPose);
            print("initialize");
            startObjectRotationPoint = Quaternion.Inverse(constraintPoint.transform.rotation) * worldPose.Rotation;
        }

    public override void ApplyConstraint(ref MixedRealityTransform transform)
    {
        // Quaternion rotation = transform.Rotation * Quaternion.Inverse(constraintPoint.rotation);
        // Vector3 eulers = rotation.eulerAngles;

        // eulers.x = 0;
        // eulers.z = 0;

        // transform.Rotation = Quaternion.Euler(eulers) * constraintPoint.rotation;
        print("apply");
        Vector3 dir = constraintPoint.position - transform.Position;
        float angle = Mathf.Atan2(dir.z,dir.x) * Mathf.Rad2Deg;
        transform.Rotation = Quaternion.AngleAxis(angle, Vector3.up);

    }


}



