using System;
using RosMessageTypes.Geometry;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using Unity.Robotics.UrdfImporter;
using UnityEngine;
using JointStates = RosMessageTypes.Sensor.JointStateMsg;

using System.Collections;

public class SourceDestinationPublisher : MonoBehaviour
{
    const int k_NumRobotJoints = 6;

    public static readonly string[] LinkNames =
        { "/joint1", "/joint2", "/joint3", "/joint4", "/joint5", "/joint6"};

    // Variables required for ROS communication
    [SerializeField]
    string m_TopicName = "/joint_states";

    [SerializeField] private ArticulationBody[] robotJoints = new ArticulationBody[k_NumRobotJoints];
    
    //[SerializeField]
    //GameObject m_Target;
    //[SerializeField]
    //GameObject m_TargetPlacement;
    
    readonly Quaternion m_PickOrientation = Quaternion.Euler(90, 90, 0);

    // Robot Joints
    UrdfJointRevolute[] m_JointArticulationBodies;

    // ROS Connector
    ROSConnection m_Ros;

    void Start()
    {
        // Get ROS connection static instance
        m_Ros = ROSConnection.GetOrCreateInstance();
        // Subscribe to joint_state topic
        m_Ros.Subscribe<JointStates>(m_TopicName, getMessageJointState);
        m_JointArticulationBodies = new UrdfJointRevolute[k_NumRobotJoints];     
        

    void getMessageJointState(JointStates jointPosMsg)
    {
       StartCoroutine(SetJointValues(jointPosMsg));
    }
    
    IEnumerator SetJointValues(JointStates message)
    {

        for (int i = 0; i < message.name.Length; i++)
        {
           
            var joint1XDrive = robotJoints[i].xDrive;
            float jointAngle = (float)(message.position[i]) * Mathf.Rad2Deg;            
            joint1XDrive.target = jointAngle;
            robotJoints[i].xDrive = joint1XDrive;            
        }
 
        yield return new WaitForSeconds(0.5f);
    }
}
}
