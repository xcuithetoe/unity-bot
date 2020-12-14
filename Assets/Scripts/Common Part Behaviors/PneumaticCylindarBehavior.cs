using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PneumaticCylindarBehavior : MonoBehaviour
{

    public float StrokeLength ;

    public bool extended = false ;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        ConfigurableJoint j = this.GetComponent<ConfigurableJoint>() ;
        float desiredPosition = 0.0f ;
        if ( extended ) {
            desiredPosition = StrokeLength ;
        }
        j.targetPosition = new Vector3(0.0f, desiredPosition, 0.0f) ;
    }
}
