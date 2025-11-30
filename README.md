# IceBUTT Deployer
 A tool for easily sending audio from one computer to another in a local network or over the internet.
 <img src="images/logo.png" align="right"
     alt="IceBUTT Logo" width="120" height="178">
<br>
<br>
<br>
    
 # **Description**
This tool allows you to easily create a reliable and robust setup for streaming the audio of your computer to
another computer or more. 
I decided to call this set of programs and the configuration, IceBUTT.

On the sender computer it installs and configurates 2 programs, one called Icecast which is used to stream the 
audio that is then picked up by the reciever device, and the other BUTT, which is what "picks up" the audio 
from your computer and sends it to Icecast to be streamed.
On the reciever computer(s) it installs and configurates VLC to open and play that stream.

The deployed programs and configuration ensure that the connection is not lost and when an error occurs due to 
external factors (like a dropped internet connection) it will still keep trying to reconnect and resume streaming or 
playing. The bitrate, compression and other settings are configured so that the stream never cuts and keeps 
playing continuously even on flaky internet connections. Priority is an uninterrupted and smooth playing stream, 
not low latency and highest audio quality.
These settings can be changed through BUTT's settings window.

# **NOTES:**
IceBUTT Deployer has been tested to work with the following versions of each program:

   -Icecast 2.4.4
  
   -BUTT 1.45.0 Win64 Portable
  
   -VLC 3.0.21 (both 32 and 64 bit)
  
   -VBCable 2.1.5.8 64bit
  
<ins>**The zip file in the Releases contains the programs (Icecast, BUTT etc) prepackaged.**</ins>

You can replace the installer files in the "icebutt_software" folder with a newer version of these programs but it is 
not recommended since the behavior may be unexpected or outright not work.



 # **Preview:**
<img width="373" height="368" alt="image" src="https://github.com/user-attachments/assets/b7f21e7d-11af-4e49-918c-83db50eaa069" />
