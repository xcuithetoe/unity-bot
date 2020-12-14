using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRC.NetworkTables ;


public class GameControllerInterface : MonoBehaviour 
{

    public int JoystickNumber ;

    // wpk need to get rid of hard coded values at some point.

    const int NumAxes = 8 ;
    const int NumButtons = 9 ;

    public string[] AxisName = new string[NumAxes];
    public string[] ButtonName = new string[NumButtons] ;

    private NetworkTableEntry[] axisEntries = new NetworkTableEntry[NumAxes] ;
    private NetworkTableEntry[] buttonEntries = new NetworkTableEntry[NumButtons] ;

    private NetworkTableInstance ntInstance ;


    // Start is called before the first frame update
    void Start()
    {
        ntInstance = NetworkTablesManager.Instance ;
        for( int i = 0; i < AxisName.Length; i++) {
            if ( AxisName[i].Trim() != "" ) {
                string entryName = $"/sim/Joysticks/Joystick{JoystickNumber}/Axis{i}" ;
                axisEntries[i] = ntInstance.GetEntry(entryName) ;
                axisEntries[i].ForceSetDouble(0.0) ;
            }
        }

        for( int i = 0; i < ButtonName.Length; i++) {
            if ( ButtonName[i].Trim() != "" ) {
                string entryName = $"/sim/Joysticks/Joystick{JoystickNumber}/Button{i}" ;
                buttonEntries[i] = ntInstance.GetEntry(entryName) ;
            }
        }

    }


    void FixedUpdate() {

        for( int i = 0; i < AxisName.Length; i++) {
            if ( AxisName[i].Trim() != "" ) {
                axisEntries[i].SetDouble(Input.GetAxis(AxisName[i]) ) ;
            }
        }

        for( int i = 0; i < ButtonName.Length; i++) {
            if ( ButtonName[i].Trim() != "" ) {
                buttonEntries[i].SetDouble( Input.GetAxis(ButtonName[i])) ;
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
