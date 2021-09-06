# Video Application Server Code Sample using C# and Airtel IQ Web Toolkit

This Application Server code sample in C# facilitates communication between your client application and Airtel IQ Video Server. The communication takes place with the help of a Rest API service known as Airtel IQ Server API that allows you to provision a video room on the Airtel IQ Server and create a token to access the video room.    

The Server APIs facilitate video communication by performing the following sequential tasks: 

* Create a virtual video room on the Video Server. 

* Fetch the Room ID after room creation. 

* Generate token to join a video session as a Moderator or a Participant. 



## 1. Getting Started 

### 1.1 Pre-Requisites 

### 1.1.1 Authorization Credentials 

Follow the steps given below to generate API Credentials required to access Airtel IQ: 

* [Access Airtel Video IQ Portal](https://cpaasportal.videoiq.airteliq.in/)

* Create your Project 

* Get the App ID and App Key generated against the Project. 

### 1.1.2 Clone Repository

* Clone this ``` git clone https://github.com/airteliq/Airtel-IQ-One-to-One-Video-Chat-Sample-Web-Application-C-Sharp-Server.git```

### 1.1.3. Get SSL Certificate 

Application Server must run on a secured Web Server hence use a valid SSL Certificate for your Domain and use it to configure your Web Service to make your domain accessible on HTTPS. 

Alternatively, you may also use a self-signed certificate to run this Application Server. Some of the websites that generate self-signed certificate are: 

https://letsencrypt.org/ 

https://www.sslchecker.com/csr/self_signed 

https://www.akadia.com/services/ssh_test_certificate.html 


### 1.1.4 Download Sample Client 


Clone or download any of the following client applications based on your requirement and language preference **<ins>within the cloned server repository and follow the instructions<ins>**:

* Web-based  

  * Javascript
 
      * [One to One video call](https://github.com/Airteliq/one-to-one-Video-Chat-Sample-Web-Application-Javascript-Client)
 
      * [Multiparty video call](https://github.com/Airteliq/Airteliq-IQ-One-to-One-Video-Chat-Sample-Web-Application-Javascript-Client.git)
 
  * Reactjs
 
      * [One to One video call](https://github.com/Airteliq/Airteliq-IQ-One-to-One-Video-Chat-Sample-Web-Application-Reactjs-Client)
 
  * Vuejs
 
      * [One to One video call](https://github.com/Airteliq/Airtel-IQ-One-to-One-Video-Chat-Sample-Web-Application-Vuejs-Client)
 
      * [Multiparty video call](https://github.com/Airteliq/Airtel-IQ-Multiparty-Video-Chat-Sample-Web-Application-Vuejs-Client)
  

## 1.2 Configure Application Server

* Before you can run this application, configure the service by editing `sample-csharp/appsettings.json` file to use your app ID and app key
``` 
"Airteliq": {
    "AIRTELIQ_API_URL": "https://api.airteliq.io/v1/",
    "AIRTELIQ_APP_ID": "YOUR_AIRTELIQ_APP_ID",
    "AIRTELIQ_APP_KEY": "YOUR_AIRTELIQ_APP_KEY"
}
```

 
## 1.3 Build and Run the server  

* To build a C# server,you require the latest version of Visual Studio. Get the latest version [here](https://visualstudio.microsoft.com/vs/community/)
* To run the server, open the solution file , that is ```Airteliq.sln```
* After running the solution file, click on the **<ins>green Start button<ins>** to run the server.
* The server should automatically open on https://localhost:5000/

 
## 2. Test 

* Open a browser and go to https://localhost:5000/. The browser should load the App. Go to -> Advanced -> Proceed to localhost
* Don't have a Room ID? Create here (create a new RoomID)
* Store the Room ID for future use or share
* Enter a username (e.g. test0) as a moderator
* Join and allow access to camera and microphone when prompted to start your first webRTC call through Airtel IQ
* Open another browser tab and enter https://localhost:5000/
* Enter the same roomID previously created and add a different username (test1) as a participant and click join
* Now, you should see your own video in both the tabs!


## 3. Know more about Server API 

A video Application Server communicates with Airtel IQ Video Service using Airteliq Server API, a Rest API Service used to provision and manage video rooms, create a token for client endpoints to join a session, and get post-session reports. 

This sample Application Server demonstrates only primitive usage of Server APIs, however it is worth noting that the capabilities of Airteliq Server APIs are not limited to provisioning a meeting room. Explore Airtel IQ Server APIs to utilize them in the best way to meet your workflow and business requirements. 

[Basics Understanding and Authentication](https://www.videoiq.airtel.in/developer/video/server-api/)   

[Latest Version of Server API Routes](https://www.videoiq.airtel.in/developer/video-api/server-api/) 

 

# 4. Support 

Airtel IQ provides a library of Documentations, How-to Guides, and Sample Codes to help software developers, interested in embedding RTC in their applications. 

Refer to the [Complete Developer’s Guide](https://www.videoiq.airtel.in/developer/video-api/client-api/) for more details. 

For any queries, you may also write to us at [support@videoiq.Airteliq.in](). 
