# Chatham Weather Dashboard Exam

<!-- TOC depthFrom:2 depthTo:6 withLinks:1 updateOnSave:1 orderedList:0 -->

- [Description](#description)
- [Solution](#solution)
- [Requirements](#requirements)
- [Usage](#usage)
	- [WebApi](#webapi)
	- [Forecast Dashboard Project](#forecast-dashboard-project)
	- [.Net Test Projects](#net-test-projects)
	- [Alternative .Net Projects usage](#alternative-net-projects-usage)
		- [Requirements](#requirements)
		- [Usage](#usage)

<!-- /TOC -->

## Description

The solutions in this repo look to solve the following:

> We would like you to build a small webapp for a weather dashboard. Your Webapp would hook into 2-3 of the public APIs provided by services like Forecast.io, WeatherBug,WeatherUnderground, etc. for weather related data and display the current and 7-day weather forecast from these different sources.

> Please feel free to pick technologies you are familiar with or prefer and you have complete creative control over how the dashboard looks and functions.  The only thing we ask, is that in addition to the code that you create unit tests around the code that you write.

## Solution

To solve the exam, the following solutions were created:

*  RestClientHelper:

A Helper for the REST calls we will be doing.
The created implementation reads the response asynchronously and uses gzip.

*  RestClientHelper.Tests:

Unit Tests for RestClientHelper

*  WeatherServices:

WebApi solution that wraps the other forecast services and provides a predictable response no matter which provider is used.

Uses Cache to save api calls, and has setup Cors to enable cross origin calls.

*  WeatherServices.Tests:

Unit Tests for WeatherServices

*  AngularFrontend:

AngularJs App that consumes the WeatherServices WebApi and displays the dashboard.

Created using the fountainjs generator.

Uses bootstrap-sass for the styles, bourbon bitters for the normalization and neat for the grid framework.

Also uses skycons angular library to show the animated weather icons

## Requirements

For the WebApi you need:

*  The [NetCore SDK](https://www.microsoft.com/net/core) according to your platform

For the AngularJs project you need:

*  [Node and NPM](https://docs.npmjs.com/getting-started/installing-node)
*  [Bower](https://bower.io/#install-bower)

## Usage

### WebApi

1.  Go to the the WeatherServices solution Root Folder
2.  Run the following commands

        dotnet restore
        dotnet build
        dotnet run

### Forecast Dashboard Project

1.  Go to the AngularFrontEnd solution Root Folder
2.  Run the following commands

        npm install
        bower install
        gulp build
        gulp serve

### .Net Test Projects

1.  Go to the root of the .Net Test Solution you want to test
2.  Run the following commands

        dotnet restore
        dotnet pack
        dotnet test

### Alternative .Net Projects usage for Windows users

#### Requirements

*  Visual Studio 2015 IDE with Update 3
*  NetCore for Visual Studio

#### Usage

*  Open the ChathamWeather.sln with one of the two mentioned editors
*  Run the WeatherServices Project or Run its tests

### TO-DO:

*  Increase Code Coverage in front and backend
*  Stop mapping the icon implementation on the backend and create an angular filter on the frontend to handle the icon implementation
*  Use breakpoints in the frontend to modify the grid on the mobile phone size
