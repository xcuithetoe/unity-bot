using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB1013Behavior : MonoBehaviour {

    public AnalogInWSBehavior analogInPort;

    // The following numbers come from the part spec and quickstart guide
    // which can be found here:
    // https://www.maxbotix.com/ultrasonic_sensors/mb1013.htm?gclid=Cj0KCQiA5vb-BRCRARIsAJBKc6IDRhlfXZM_njHzEFqx-meI9Vxm2UCtf-60_10T7tbrd8krcAiB-yIaAi58EALw_wcB
    const float MaxRange = 5.0f; //in meters
    const float Vi = 5.0f / 1024.0f; // based on 5 Volts, formula from quick start quide (5.0V/1024)

    public bool DrawRay = false;

    public double distance = MaxRange ;

    public double EstimatedDistance{
        get { return distance; }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxRange, layerMask)) {
            distance = hit.distance ; 
            if (DrawRay) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }
            if (analogInPort) {
                // Multiply distance by 1000 to convert meters to millimeters
                float measuredVoltage = (hit.distance * 1000.0f * Vi) / MaxRange;
                analogInPort.setVoltage(measuredVoltage);
            }
        }
        else {
            distance = MaxRange ;
            float measuredVoltage = (MaxRange * 1000.0f * Vi) / MaxRange;
            analogInPort.setVoltage(measuredVoltage);
            if (DrawRay) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * MaxRange, Color.white);
            }
        }

    }
}
