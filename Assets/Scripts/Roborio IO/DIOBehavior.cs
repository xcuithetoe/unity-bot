using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FRC.NetworkTables   ;


public class DIOBehavior : MonoBehaviour
{

    private bool IsInput = true ;
    private bool output ;
    public int DIONumber ;

    private NetworkTableEntry valueEntry ;
    private NetworkTableEntry isInputEntry ;


    // Start is called before the first frame update
    void Start()
    {
        string tableName = $"/sim/DIO/DIO{DIONumber:D2}" ;
        valueEntry = NetworkTablesManager.Instance.GetEntry($"{tableName}/Value") ;
        isInputEntry = NetworkTablesManager.Instance.GetEntry($"{tableName}/Input") ;
        isInputEntry.SetBoolean( IsInput ) ;
    }


    // set input to Roborio
    public void setInput(bool val) {
        if ( IsInput ) {
            valueEntry.SetBoolean(val) ;
        } else {
            // should we through an exception?
        }
    }


    public bool getOutput() {
        if ( !IsInput ) {
            return output ;
        } else{
            // should we throw an exception?
            return false ;
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        IsInput = isInputEntry.GetBoolean( false ) ;
        if ( !IsInput ) {
            output = valueEntry.GetBoolean(false) ;
        }
    }
}
