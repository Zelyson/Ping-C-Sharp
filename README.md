# Ping C#
This application is meant to test your home network, your network appliances or just for fun.

It does in no way shape or form encourage its use to  perform illegal activities such as denial of service attacks or illegal usage in combination with or without other programs and/or services.

## Usage
As this is an executable meant for cli usage, nothing will happen if you open the file from your file explorer. You have to open it directly from your command line.
Three arguments need to be passed in:
1. Ip adress
2. number of times pinged
3. timeout

Eg.:
```sh
ddos 192.168.178.1 5000 100
```
To ping endlessly use -1 in the second argument.

## Dependencies
You need to have the .NET SDK installed on your machine. 
To check, open cmd or any cli and type:

```sh
dotnet --info
```
If the information it returns contains a tab called: .NET SDKs installed, you are all set up. I however it returns an error such as `'dotnet --info' is not recognized as an internal or external command`, you need to install the .NET SKD. A download can be found here: https://dotnet.microsoft.com/download

## Build
Navigate to the folder containing the Program.cs file and open a command prompt here. then type:

```sh
dotnet publish -c Release -m
```
A new folder named *bin* will appear. In there, navigate to *Release* then to *net5.0* or *net6.0* depending on what version of .NET you have installed. In the *publish* folder you will find the Ping_C#.exe file, which is the program you just built.

-27.07.2021 
