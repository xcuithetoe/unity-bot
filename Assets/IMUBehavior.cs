using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMUBehavior : MonoBehaviour {


    //public float updateFreq = 2.0f;

    public Vector3 angVel;
    public Vector3 angAccel;

    public Vector3 linVel;
    public Vector3 linAccel;


    private Vector3 lastPos;
    private Vector3 lastAng;
    private Vector3 lastLinVel;
    private Vector3 lastAngVel;

    public float timer = 0.0f;


    // Start is called before the first frame update
    void Start() {
        linVel = Vector3.zero;
        angVel = Vector3.zero;

        linAccel = Vector3.zero;
        angAccel = Vector3.zero;

        lastPos = this.transform.position;

    }

    // void Update() {
    //     Debug.Log("update called") ;
    // }



    // Update is called once per frame
    void FixedUpdate() {

        timer = Time.deltaTime;

        lastLinVel = linVel;
        lastAngVel = angVel;

        var lastPosInv = transform.InverseTransformPoint(lastPos);

        float dy= (0.0f - lastPosInv.y);

        // wpk not clear to me why I had to divide by 2.0. Do we need to do that for angular values as well?
        linVel.x = (0 - lastPosInv.x) / timer / 2.0f ;
        linVel.y = (0 - lastPosInv.y) / timer / 2.0f;
        linVel.z = (0 - lastPosInv.z) / timer / 2.0f;

        var deltaX = Mathf.Abs((transform.rotation.eulerAngles).x) - lastAng.x;
        if (Mathf.Abs(deltaX) < 180 && deltaX > -180)
            angVel.x = deltaX / timer;
        else {
            if (deltaX > 180)
                angVel.x = (360 - deltaX) / timer;
            else
                angVel.x = (360 + deltaX) / timer;
        }

        var deltaY = Mathf.Abs((transform.rotation.eulerAngles).y) - lastAng.y;
        if (Mathf.Abs(deltaY) < 180 && deltaY > -180)
            angVel.y = deltaY / timer;
        else {
            if (deltaY > 180)
                angVel.y = (360 - deltaY) / timer;
            else
                angVel.y = (360 - deltaY) / timer;
        }

        var deltaZ = Mathf.Abs((transform.rotation.eulerAngles).z) - lastAng.z;
        if (Mathf.Abs(deltaZ) < 180 && deltaZ > -180)
            angVel.z = deltaZ / timer;
        else {
            if (deltaZ > 180)
                angVel.z = (360 - deltaZ) / timer;
            else
                angVel.z = (360 + deltaZ) / timer;
        }

        linAccel.x = (linVel.x - lastLinVel.x) / timer ;
        linAccel.y = (linVel.y - lastLinVel.y) / timer ;
        linAccel.z = (linVel.z - lastLinVel.z) / timer ;


        angAccel.x = ((angVel.x - lastAngVel.x) / timer) / 9.81f;
        angAccel.y = ((angVel.y - lastAngVel.y) / timer) / 9.81f;
        angAccel.z = ((angVel.z - lastAngVel.z) / timer) / 9.81f;

        lastPos = transform.position;

        lastAng.x = Mathf.Abs((transform.rotation.eulerAngles).x);
        lastAng.y = Mathf.Abs((transform.rotation.eulerAngles).y);
        lastAng.z = Mathf.Abs((transform.rotation.eulerAngles).z);


    }
}
