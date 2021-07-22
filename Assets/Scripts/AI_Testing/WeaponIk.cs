using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIk : MonoBehaviour
{
    public Transform targetTransform;
    public Transform aimTransform;
    public Transform bone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = targetTransform.position;
        AimAtTarget(bone, targetPosition);
    }
    private void AimAtTarget(Transform bone, Vector3 targetPosition)
    {
        Transform aim = aimTransform.Find("RaycastOrigin").GetComponent<Transform>();
        Vector3 aimDirection = aim.forward;
        Vector3 targetDirection = targetPosition - aim.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        bone.rotation = aimTowards * bone.rotation;

    }
}
