# FinalPicoUnity
Stage 6 of SUTD Capstone 45 Pico Musical Engineering Installation project.<br/>
Refer to the following [link](https://youtu.be/EubplCl5Q8s) for a demo.

Unity directly reads the corresponding text file and sends the notes to play to an Arduino via Serial communication.

Bluetooth communication between Unity and Arduino: https://assetstore.unity.com/packages/tools/network/bluetooth-le-for-ios-tvos-and-android-26661
This plugin only works for Android and iOS devices and not PC.

A real-time firebase database was added to track the popularity statistics of each song. An snapshot is seen below:

![image](https://user-images.githubusercontent.com/23626462/63004160-50c12b80-beac-11e9-93b2-375b1c245f4f.png)

The Arduino script requires you to set up an electronic circuit with 25 LEDs/solenoids/etc as shown in the video. Ensure they are wired to the corresponding pin numbers as in the Arduino file. An Arduino MEGA was used for this project as it has enough number of pin holes.

2 octaves, fully chromatic scale is used to form 25 notes as shown below.
<img width="436" alt="midirange" src="https://user-images.githubusercontent.com/23626462/61297441-d77fdb80-a80e-11e9-857d-ced140331160.PNG">

Steps for uploading Arduino:
1. Wire the Arduino circuit containing HM10 Bluetooth module and solenoids.
2. Connect to your Arduino and upload the sketch in Arduino folder. 
3. If you run into TimeOut error, try the following:
  a. Ensure RXTX is disconnected during upload
  b. Ensure you have set the COM Port under Tools
  b. Click the reset button on the Arduino.

## Deployment
A current version has already been deployed under the `Build` folder. If further changes are made to the Unity file, 

### Steps for deploying on Android devices [Windows PC is needed]:
1. Open the Jukebox project under Build folder in Android Studio.
2. Ensure the following changes are made in the Manifest file: </br>
  `<application android:isGame="false">` </br>
    `<activity`  </br>
      `android:launchMode="singleTop"`  </br>
      `android:clearTaskOnLaunch="false" android:alwaysRetainTaskState="true">` </br>
    `</activity>` </br>
  `</application>`
3. Enable USB Debugging options in your Android device, connect device to computer and Run App on your device.
4. Unplug your device if you wish. You will need to enable Bluetooth beofre you run the App.

### Steps for deploying on  iOS devices [Mac PC is needed]:
1. [to be updated]

### To test your electronic circuit:
For testing purposes a "Test Scale" has been added under `Assets > Scripts > txt`.
1. Set up the 25 solenoids to your Arduino MEGA. It should look something like below:
![img](https://user-images.githubusercontent.com/23626462/61359978-14e87580-a8b0-11e9-82e7-bcc2f16c1cfd.jpg)
2. In the app, run the first item in the playlist "Test Scale". It should play the full chromatic scale of 25 notes.

## Customisations
You will need Unity to make changes to the App Interface.

### To open the Unity Editor:
1. Install Unity Hub and create an account: https://docs.unity3d.com/Manual/GettingStartedInstallingHub.html
2. Download any version of 2019. You must check the boxes for Android/iOS APK packages depending on what device you wish to deploy to. This may take a while.
3. Open the project folder in Unity Hub.

### To add new songs to the playlist:
1. Run Part 1 of https://github.com/ValereneGoh/MiditoArduino to convert midi files into interpretable text file formats.
2. Add the text file to the folder under Assets > Scripts > txt.
3. Open Unity and manually create a new CD player and holder for the new song via the Prefab folder.

### To change the tempo of the overall installation:
1. Edit line 244 of the DropZone.cs in `Assets > Scripts`.

### About the project:
This repository constitutes the software aspect of Capstone 45's project. It is a running App built using Unity that controls the songs to be played on the machine through a user interface on the front-end and electronic components (solenoids and motors) on the back-end via Bluetooth. Below are some video demonstrations of the final project, when integrated with the entire hardware structure.
https://youtu.be/0JXisI0RaLA
https://youtu.be/vKBauMuSYiw
https://youtu.be/fZi4IeVtsKo
https://youtu.be/vFjGHLuBx78

There six iterations of the Unity App done on my Github over the course of 3 months. Below is a summary of them with their links attached.

Stage 1 ([MiditoArduino](https://github.com/ValereneGoh/MiditoArduino)): 
- Preprocessing script for getting interpretable music format (used for all subsequent stages)
- Main script with simple playlist UI (made with Tkinter library), serial communication between Python and Arduino.

Stage 2 ([UnitytoPythontoArduino](https://github.com/ValereneGoh/UnitytoPythontoArduino)): 
- Unity playlist UI replaces Tkinter UI in Main script of Stage 1, serial communication between Unity and Python, Python and Arduino.

Stage 3 ([UnitytoArduino](https://github.com/ValereneGoh/UnitytoArduino)):
- Python proxy is removed from previous iteration, so Unity playlist UI directly communicates with Arduino serially.

Stage 4 ([UnityBluetoothtoArduino](https://github.com/ValereneGoh/UnityBluetoothtoArduino)):
- Unity communicates with Arduino via Bluetooth instead of serially. (wired --> wireless)

Stage 5 ([UnityFirebaseBluetoothtoArduino](https://github.com/ValereneGoh/UnityFirebaseBluetoothtoArduino)):
- Firebase database was added to collate popularity statistics of each song in real time.

Stage 6 ([FinalPicoUnity](https://github.com/ValereneGoh/FinalPicoUnity)):
- Animations and motor integration for the wheel was added into App logic.

### References:
- Creating the Firebase implementation takes reference from: https://www.youtube.com/watch?v=Fz0Sl4tW5O0&t=588s
- Creating the scrolling interface in Unity takes reference from: https://www.youtube.com/watch?v=9B7ahj1kaYs
- Creating the drag-and-drop feature in Unity takes reference from: https://www.youtube.com/watch?v=bMuYUOIAdnc
