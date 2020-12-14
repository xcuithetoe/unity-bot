using System ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRC.NetworkTables ;



public class DriverStationBehavior : MonoBehaviour
{

    private NetworkTableInstance ntInstance ;

    private NetworkTableEntry enabledEntry ;
    private NetworkTableEntry teleopEntry ;
    private NetworkTableEntry autonomousEntry ;
    private NetworkTableEntry testingEntry ;
    private NetworkTableEntry estopEntry ;

    public string EnabledNTEntryName ;
    public string TeleopNTEntryName ;
    public string AutoNTEntryName ;
    public string TestingNTEntryName ;

    public UnityEngine.UI.Button EnabledButton ;
    public UnityEngine.UI.Button TeleopButton ;
    public UnityEngine.UI.Button AutonomousButton ;
    public UnityEngine.UI.Button TestingButton ;

    // Start is called before the first frame update
    void Start()
    {
        ntInstance = NetworkTablesManager.Instance ;

        try {
            enabledEntry = ntInstance.GetEntry(EnabledNTEntryName) ;
            teleopEntry = ntInstance.GetEntry(TeleopNTEntryName) ;
            autonomousEntry = ntInstance.GetEntry(AutoNTEntryName) ;
            testingEntry = ntInstance.GetEntry(TestingNTEntryName) ;

            enabledEntry.SetBoolean(false) ;

        } catch ( Exception ex ) {
            Debug.Log("exception encountered " + ex.ToString()) ;
        }
    }


    private void Update() {

        bool localEnable = enabledEntry.GetBoolean( false) ;
        bool localTeleop = teleopEntry.GetBoolean( false) ;
        bool localAutonomous = autonomousEntry.GetBoolean( false) ;
        bool localTesting = testingEntry.GetBoolean( false) ;

        var colors = EnabledButton.colors;
        UnityEngine.UI.Text textComponent = EnabledButton.GetComponentInChildren<UnityEngine.UI.Text>();
        if ( localEnable ) {
            colors.normalColor = Color.red ;
            textComponent.text = "Disable" ;
        } else {
            colors.normalColor = Color.green;
            textComponent.text = "Enable" ;
        }
        EnabledButton.colors = colors;

        colors = TeleopButton.colors ;
        if ( localTeleop ) {
            colors.normalColor = Color.green ;
        } else {
            colors.normalColor = Color.gray;
        }
        TeleopButton.colors = colors;

        colors = AutonomousButton.colors ;
        if ( localAutonomous ) {
            colors.normalColor = Color.green ;
        } else {
            colors.normalColor = Color.gray;
        }
        AutonomousButton.colors = colors;

        colors = TestingButton.colors ;
        if ( localTesting ) {
            colors.normalColor = Color.green ;
        } else {
            colors.normalColor = Color.gray;
        }
        TestingButton.colors = colors;

    }




    public void GotoDisabled() {
        bool localEnable = enabledEntry.GetBoolean( false) ;
        enabledEntry.SetBoolean( !localEnable ) ;
    }


    public void GotoTeleop() {
        teleopEntry.SetBoolean( true ) ;
    }


    public void GotoAutonomous() {
       autonomousEntry.SetBoolean( true ) ;
    }

    public void GotoTesting() {
        testingEntry.SetBoolean( true ) ;
    }



}
