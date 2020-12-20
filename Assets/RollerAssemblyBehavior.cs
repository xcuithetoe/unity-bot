using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerAssemblyBehavior : MonoBehaviour
{

    public Rigidbody supportFrame ;

    void Awake() {

    }

    // Start is called before the first frame update
    void Start()
    {
        HingeJoint joint = GetComponent<HingeJoint>();
        if (joint) {
            if ( supportFrame) {
                joint.connectedBody = supportFrame ;
            }
            joint.connectedAnchor = new Vector3(-0.4f, 0.1f, 0.0f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // HingeJoint joint = GetComponent<HingeJoint>();
        // if (joint && !joint.autoConfigureConnectedAnchor) {
        //     Debug.Log(joint.connectedAnchor) ;
        //     joint.autoConfigureConnectedAnchor = true;
        // }

    }
}
