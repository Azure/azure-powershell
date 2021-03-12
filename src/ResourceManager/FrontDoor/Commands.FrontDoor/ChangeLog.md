﻿<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Current Release
Microsoft Azure PowerShell - FrontDoor service cmdlets.

This module is outdated and will go out of support on 29 February 2024.

The Az.FrontDoor module has all the capabilities of AzureRM.FrontDoor and provides the following improvements:
* Az.FrontDoor takes advantage of greater security with token cache encryption and improved authentication.
* Availability in Azure Cloud Shell and on Linux and macOS.

We encourage you to start using the Az module as soon as possible to take advantage of these improvements.

[Update your scripts](https://aka.ms/azpsmigrate) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024. To automatically update your scripts, follow the [quickstart guide](https://aka.ms/azpsmigratequick).

## Version 0.1.1
* Add remove-AzureRmFrontDoorContent for cache purge

## Version 0.1.0
* PowerShell integration for Azure Front Door service