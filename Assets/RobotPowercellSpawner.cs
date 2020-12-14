using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPowercellSpawner : MonoBehaviour
{
 
    public GameObject thePrefab ;

    private float lastButton = 0.0f ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentValue = Input.GetAxis("TriangleButton") ;
        if (currentValue > 0.0f  && lastButton == 0.0f ){

            Vector3 instantiationPoint 
                = transform.TransformPoint( new Vector3( -0.307f, 0.1f, 0.304f )) ;

           Instantiate(thePrefab,instantiationPoint, Quaternion.identity);
        }
        lastButton = currentValue ;
        
    }
}
