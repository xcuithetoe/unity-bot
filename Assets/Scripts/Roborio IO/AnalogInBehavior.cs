using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FRC.NetworkTables   ;

public class AnalogInBehavior : MonoBehaviour
{


    public int AnalogInPortNumber ;
    private NetworkTableEntry voltageEntry ;


    // Start is called before the first frame update
    void Start()
    {
        string tableName = $"/sim/AnalogIn/AnalogIn{AnalogInPortNumber}" ;
        voltageEntry = NetworkTablesManager.Instance.GetEntry($"{tableName}/Voltage") ;
    }


    // set input to Roborio (its an output from the sim)
    public void setVoltage(float val) {
        voltageEntry.SetDouble((double)val) ;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
