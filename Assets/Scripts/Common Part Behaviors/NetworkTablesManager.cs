using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System ;

using FRC.NetworkTables ;


public class NetworkTablesManager : MonoBehaviour
{
    
    private static bool instanceCreated = false ;
    public static NetworkTableInstance inst = null ;


    // Start is called before the first frame update
    void Start()
    {     
    }


    static public NetworkTableInstance Instance {
        get {
            if ( !instanceCreated ) {
                inst = NetworkTableInstance.Default ;
                // wpk probably should make this a parameter
                //NetworkTablesManager.inst.StartClient("192.168.68.100");
                NetworkTablesManager.inst.StartClient("127.0.0.1");
                //                NetworkTablesManager.inst.StartClient(serverLocation);
                //Debug.Log($"started network tables client at {serverLocation}") ;
            }

            return inst ;

        }
    }

}
