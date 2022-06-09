# SaveServiceAPI
This service receives data then save in a local file. It should work accompany with project FormAppAngular. (https://github.com/annlee916/AngularFormApp)

## General information

IDE: VS2022
Target framework: .Net 6.0
Template: ASP.NET Core Web App, no Authentication type, no MVC

## Attention

For testing reason, Services Cors is added. 
If publish to publish, Services.Cors should be removed or modified.

## File description

Program.cs - main flow of the application
SaveService - function to save data into a single file.
GamaModel - structure of required data.
