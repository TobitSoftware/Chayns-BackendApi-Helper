# Chayns Backend API Helper
The chayns backend api helper is dedicated to support you using the [backend api](https://github.com/TobitSoftware/chayns-backend) itself. <br>
It shortens and simplifies many features of the api and makes the usage much more cleaned up.

## Requirements
For using this project you will need the following prerequisites
+ Visual Studio
+ .NET Framework 4.6 or greater

## Dependencies
To use this Project you will need the following package from nuget.org
+ Newtonsoft.Json (>= 8.0.3)

## Getting started
To use this helper you will need to integrate it into your existing .NET Framework Project.<br>
You can integrate this Project directly into your solution or just reference the `Chayns.Backend.dll` file you can find in the `/bin/Release` folder.<br>
To create the file you need to open the solution. Change the build settings to `Release` and build the project, by pressing `F6`.

## How to use
### General
When you have added the helper you get the new functionality using the namespace `Chayns.Backend`.<br>
Using the helper you can shorten and simplify your requests to the chayns® backend api.<br>
The controllers are named equal to the endpoints of the api.

### Authentication
To authenticate your request you will need your secret and TappId (see the [chayns backend wiki](https://github.com/TobitSoftware/chayns-backend/wiki/Authorization)).<br>
You can find the Secret in the Tapp Administration in the TSPN and the TappId can be found in the JavaScript Frontend API.<br>
You can set default credentials for all of your requests, by calling
```CSHARP 
Chayns.Backend.Api.Credentials.Credentials.Initialize(new SecretCredentials("Secret", TappId));
```
You can also pass the credentials to every request by hand. The credentials manual set are always preferred.