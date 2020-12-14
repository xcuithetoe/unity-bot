using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRC.NetworkTables ;


public class SolenoidBehavior : MonoBehaviour
{

    public SolenoidPortBehavior SolenoidPort ;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public bool PressureFromOpenPort() {
        return SolenoidPort.ForwardSideOn() ;
    }

    public bool PressureFromClosePort() {
        return SolenoidPort.ReverseSideOn() ;
    }



}
