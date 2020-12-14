using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System ;

using FRC.NetworkTables ;


public class NetworkTablesManager : MonoBehaviour
{
    
    private static bool instanceCreated = false ;
    public static NetworkTableInstance inst = null ;

    public string serverLocation ;


    // Start is called before the first frame update
    void Start()
    {     
    }


    static public NetworkTableInstance Instance {
        get {
            if ( !instanceCreated ) {
                inst = NetworkTableInstance.Default ;
                // wpk probably should make this a parameter
                NetworkTablesManager.inst.StartClient("192.168.68.109") ;
                //Debug.Log($"started network tables client at {serverLocation}") ;
            }

            return inst ;

        }
    }

}
