using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapBehavior : MonoBehaviour
{

    public GameObject InnerFrame ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( InnerFrame) {
            HingeJoint hj = GetComponent<HingeJoint>() ;
            float angle = 0.0f ;
            if ( InnerFrame.transform.rotation.eulerAngles.x > 30.0) {
//                angle = InnerFrame.transform.rotation.eulerAngles.x;
                angle = 45;
            }
            JointSpring hingeSpring = hj.spring;
            hingeSpring.targetPosition = angle;
            hj.spring = hingeSpring;
        }
        
    }
}
