using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRC.NetworkTables ;


public class SolenoidPortBehavior : MonoBehaviour
{
    public int PCMNumber = 0 ;
    public int ForwardChannel ;
    public int ReverseChannel ;

    private NetworkTableEntry forwardPortEntry ;
    private NetworkTableEntry reversePortEntry ;

    // Start is called before the first frame update
    void Start()
    {
        string tableName = $"/sim/Solenoid/Module{PCMNumber}" ;
        forwardPortEntry = NetworkTablesManager.Instance.GetEntry( $"{tableName}/Channel{ForwardChannel}/SolenoidOutput" ) ;
        reversePortEntry = NetworkTablesManager.Instance.GetEntry( $"{tableName}/Channel{ReverseChannel}/SolenoidOutput" ) ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    // wpk check these names against real parts to make sure terminology is correct
    public bool ForwardSideOn() {
        return forwardPortEntry.GetBoolean( false ) ;
    }

    public bool ReverseSideOn() {
        return reversePortEntry.GetBoolean( false ) ;
    }

}
