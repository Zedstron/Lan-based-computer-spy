# Lan-based-computer-spy
A C# based server and client project written to achieve stealth monitoring of any windows based machine in a local area network (LAN). one can simply remotely control a computer over lan without letting user know
This was my hobby project so for the learning of others i uploaded this work to Git however this is not being maintained, but you are welcomed if you make any change, remove bug or add an extra feature you can create a pull request ofcourse

# Features
There are many features in project some of them worth mentioning are following
- Command Prompt Access
- Realtime Logs of Active Window
- Realtime Keylogs
- Taskmanager Access
- Filemanager Access
- Realtime Desktop Stream
  - Take Screenshot
  - Record Video
  - Image Compression & Quality Control
- Realtime Camera Stream
  - Take Screenshot
  - Record Video
  - Image Compression & Quality Control
- Realtime Microphone Stream
- Exception Logging
- Notification Sender
- Clipboard Hook
- Chat with Victim
- Agent Control
  - Option to make Auto Start Entry
  - self Destruct Option
- Bandwidth & Communication Status
- Remote Browsers Control
  - Saved Passwords Viewer
  - Open URL Option
  - View History Option

# Project Architecture
The project is divided into two sub projcts one is handling server side stuff so named as **RemoteAdministrationServer** and the client side which is acting has data collection agent in this project is named as **RemoteAdministrationClient** other sub class libraries projects are following

- AviFile (deals with video recording of Desktop and Webcam)
- NetworkInterfaceEye (deals with network information and statistics)

# Running the Project
You need to open the client project in visual studio and follow the following steps
- Open the file **RemoteClient.cs** in Core folder
- Find the function **GetIpAddress()** and go to its body
- Replace the computer name "ZED" with your computer name, in which you will execute server executeable
- Good to go, deploy the client executeable along all dll's in the victim's computer
- Execute the server's executeable in your server computer in typical case your own computer
- A small window will appear choose your target from there just in case if you have multiple targets and start controlling,


# Ethical Note
The project was developed just for education purpose only and to demonstrate the power of programming language along networking, use at your own responsibility if any thing happens undesireable either with your data, software or hardware then i will not held responsible for this. Also i am not responsible for any of the illegal or non ethical usage of this work.

# References
- Icons taken from https://iconarchive.com/
- Browsers code adopted from [this](https://github.com/jabiel/BrowserPass/tree/master/BrowserPass "this") repository
