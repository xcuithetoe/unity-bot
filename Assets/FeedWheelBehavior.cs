using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedWheelBehavior : MonoBehaviour
{


    public int Torque ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void fixedUpdate()
    {
        WheelCollider wc = this.GetComponent<WheelCollider>() ;
        wc.motorTorque = Torque ;
        
    }
}
