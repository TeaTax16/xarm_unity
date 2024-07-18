// Copyright 2019-2021 Robotec.ai.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using UnityEngine;
using ROS2;
using geometry_msgs.msg;

namespace ROS2
{

/// <summary>
/// An example class provided for testing of basic ROS2 communication
/// </summary>
[RequireComponent(typeof(ROS2UnityComponent))]
public class ROS2ListenerExample : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<geometry_msgs.msg.TwistStamped> twiststamped_sub;

    void Start()
    {
        ros2Unity = GetComponent<ROS2UnityComponent>();
    }

    void Update()
    {
        if (ros2Node == null && ros2Unity.Ok())
        {
            ros2Node = ros2Unity.CreateNode("ROS2UnityListenerNode");
            twiststamped_sub = ros2Node.CreateSubscription<TwistStamped>(
              "/servo_server/delta_twist_cmds", msg => Debug.Log("Twist Stamped: " + msg.Twist.Linear.X + ", " + msg.Twist.Linear.Y + ", "+ msg.Twist.Linear.Z));
        }
    }
}

}  // namespace ROS2
