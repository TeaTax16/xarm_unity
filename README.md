# xarm_unity

## 1. Pre-Requisites
- ### 1.1 Complete Setup from [xarm_ros](https://github.com/TeaTax16/xarm_ros)
- ### 1.2 Install Unity Editor [v2021.1.7f1](https://unity.com/releases/editor/archive)

## 2. Setup Instructions
- ### 2.1 Clone the repository to a chosen location
- ### 2.2 Once downloaded, open the project through Unity Hub
  ROS TCP Connector and URDF Importer Packages should already be present
  
  Window -> Package Manager
  
  ![image](https://github.com/user-attachments/assets/d92ff06b-4072-4905-a5c8-ca48699b2742)
- ### 2.3 Load the SampleScene Save to open the environment
  Assets -> Scenes -> SampleScene

## 3. Setup ROS Settings 
- ### 3.1 Change Protocol to ROS 2
- ### 3.2 Set ROS IP Address to IP of ROS machine or localhost
  ![image](https://github.com/user-attachments/assets/abba5d7a-2282-4492-89ef-300296753193)

## 4. Server Connection
Once the server from the xarm_ros repo is running, press the Play button to enter the Game view.
If configured correctly, Unity should connect to ROS 2 automatically.

![image](https://github.com/user-attachments/assets/f36b3a5c-b193-48cc-b9b5-799d90ecf892)

Successful connection should have non-red arrows.

