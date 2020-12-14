using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FRC.NetworkTables   ;

public class PWMBehavior : MonoBehaviour
{

    public int PWMPort ;
    private double pwmCommand = 0.0 ;

    private NetworkTableEntry pwmPortInstance ;


    // Start is called before the first frame update
    void Start()
    {
        string ntEntryName = $"/sim/PWM/PWM{PWMPort}/Speed" ;
        pwmPortInstance = NetworkTablesManager.Instance.GetEntry(ntEntryName) ;
        
    }

    public double GetPWMCommand() {
        return pwmCommand ;
    }

    void FixedUpdate()
    {
        pwmCommand = pwmPortInstance.GetDouble(0.0) ;
    }

}
