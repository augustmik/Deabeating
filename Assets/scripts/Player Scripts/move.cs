using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class move : MonoBehaviour
{
    float speed = 1.0f;
    private void Update()
    {
        Vector3 dir = Vector3.zero;

        // we assume that the device is held parallel to the ground
        // and the Home button is in the right hand

        // remap the device acceleration axis to game coordinates:
        // 1) XY plane of the device is mapped onto XZ plane
        // 2) rotated 90 degrees around Y axis
        dir.x = -Input.acceleration.y;
        dir.z = Input.acceleration.x;
        dir.y = Input.acceleration.z;

        // clamp acceleration vector to the unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        // Move object
        transform.Translate(dir * speed);
    }
}