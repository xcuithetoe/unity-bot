using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FRC.NetworkTables ;

public class EncoderPortBehavior : MonoBehaviour
{

    // wpk - Current implementation is super simpleandonly sets count values
    // Might have to implement more features once better understanding of behavior


    public int EncoderNum ;

    private NetworkTableEntry countEntry ;
    private NetworkTableEntry directionEntry ;
    private NetworkTableEntry initEntry ;
    private NetworkTableEntry periodEntry ;
    private NetworkTableEntry maxPeriodEntry ;
    private NetworkTableEntry resetEntry ;
    private NetworkTableEntry samplesToAverageEntry ;
    private NetworkTableEntry reverseDirectionEntry ;


    // Start is called before the first frame update
    void Start()
    {

        string tableName = $"/sim/Encoder/Encoder{EncoderNum}" ;

        countEntry = NetworkTablesManager.Instance.GetEntry( $"{tableName}/Count" ) ;
        directionEntry = NetworkTablesManager.Instance.GetEntry( $"{tableName}/Direction") ;
        initEntry = NetworkTablesManager.Instance.GetEntry( $"{tableName}/Initialized" ) ;
        periodEntry = NetworkTablesManager.Instance.GetEntry( $"{tableName}/Period" ) ;
        maxPeriodEntry = NetworkTablesManager.Instance.GetEntry( $"{tableName}/MaxPeriod" ) ;
        resetEntry = NetworkTablesManager.Instance.GetEntry( $"{tableName}/Reset" ) ;
        samplesToAverageEntry = NetworkTablesManager.Instance.GetEntry( $"{tableName}/SamplesToAverage") ;
        reverseDirectionEntry = NetworkTablesManager.Instance.GetEntry( $"{tableName}/ReverseDirection") ;

    }



    public void SetCounts( double counts) {
        countEntry.SetDouble(counts) ;
    }

}
