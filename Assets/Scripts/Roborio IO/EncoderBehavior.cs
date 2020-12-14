using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FRC.NetworkTables ;


public class EncoderBehavior : MonoBehaviour
{

    public WheelCollider Wheel ;

    // public int EncoderNum ;

    public EncoderPortBehavior encoderPort ;

    public int CountsPerRevolotion = 4096 ;

    public double ZeroRPMTollerance = 0.01 ;

    private double counts = 0.0 ;

    // Should this be here or in encoder port?
    private double reverse = 1.0 ;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( Mathf.Abs(this.Wheel.rpm) > ZeroRPMTollerance ) {
            this.counts += reverse * CountsPerRevolotion * Time.deltaTime * (Wheel.rpm/60.0) ;
            encoderPort.SetCounts( counts ) ;
        } 

    }
}
