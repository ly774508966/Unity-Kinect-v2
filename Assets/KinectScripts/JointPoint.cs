using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class JointPoint : MonoBehaviour {

    public GameObject BodySourceManager;
    public JointType TrackedJoint;
    private BodySourceManager bodyManager;
    private Body[] bodies;
    public GameObject attachObject;

    // Use this for initialization
    void Start () {
	    if(BodySourceManager == null)
        {
            Debug.Log("Attach Body Source Manager");
        }
        else
        {
            bodyManager = BodySourceManager.GetComponent<BodySourceManager>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(bodyManager == null)
        {
            return;
        }
        bodies = bodyManager.GetData();

        if(bodies == null)
        {
            return;
        }
        foreach(var body in bodies)
        {
            if(body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                //Object Position
                var pos = body.Joints[TrackedJoint].Position;
                attachObject.transform.position = new Vector3(pos.X * 10, pos.Y * 10, pos.Z * 10);

                //Object Orientation
                var orientation = body.JointOrientations[TrackedJoint].Orientation;
                attachObject.transform.rotation = new Quaternion(orientation.X, orientation.Y, orientation.Z, 
                    orientation.W);

                /*//Object Orientation
                var orientation = body.JointOrientations[TrackedJoint].Orientation;
                attachObject.transform.localRotation = new Quaternion(orientation.X, orientation.Y, orientation.Z,
                    orientation.W);*/

                /*//Object Orientation
                var orientation = body.JointOrientations[TrackedJoint].Orientation;
                attachObject.transform.localRotation = Quaternion.Euler( -90f, 0f, 0f ) * new Quaternion(orientation.X, 
                orientation.Y, orientation.Z, orientation.W);*/
            }
        }

	}
}
