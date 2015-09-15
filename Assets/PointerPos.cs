using UnityEngine;
using Windows.Kinect;
using System.Collections;
using System.Collections.Generic;

public class PointerPos : MonoBehaviour {

    private KinectSensor kinectSensor;
    private ColorSpacePoint colorSpacePoint;

    public GameObject BodySourceManager;
    private BodySourceManager _BodyManager;

    void Start()
    {
        kinectSensor = KinectSensor.GetDefault();
    }

    // Update is called once per frame
    void Update () {
        if (BodySourceManager == null)
        {
            return;
        }

        _BodyManager = BodySourceManager.GetComponent<BodySourceManager>();
        if (_BodyManager == null)
        {
            return;
        }

        Windows.Kinect.Body[] data = _BodyManager.GetData();
        if (data == null)
        {
            return;
        }

        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                CameraSpacePoint cameraSpacePoint = body.Joints[Windows.Kinect.JointType.HandLeft].Position;
                colorSpacePoint = kinectSensor.CoordinateMapper.MapCameraPointToColorSpace(cameraSpacePoint);
            }
        }
    }
}
