<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
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
## Upcoming Release
* Enable function app creation for Functions V4 stacks [#15919]

## Version 3.1.0
* Added two additional app settings (WEBSITE_CONTENTSHARE and WEBSITE_CONTENTAZUREFILECONNECTIONSTRING) for Linux Consumption apps. [15124]
* Fixed bug with New-AzFunctionApp when created on Azure Gov. [13379]
* Added Az.Functions cmdlets need to support creating and copying app settings with empty values. [14511]

## Version 3.0.0
* Added support in function app creation for Python 3.9 and Node 14 function apps
* Removed support in function app creation for V2, Python 3.6, Node 8, and Node 10 function apps
* Updated IdentityID parameter from string to string array in Update-AzFunctionApp. This is to be consistent with New-AzFunctionApp which has the same parameter as a string array
* Updated FullyQualifiedErrorId for an invalid Functions version from FunctionsVersionIsInvalid to FunctionsVersionNotSupported 
* When creating a Node.js function app, if no runtime version is specified, the default runtime version is set to 14 instead of 12

## Version 2.0.0
* [Breaking Change] Removed `IncludeSlot` switch parameter from all but one parameter set of `Get-AzFunctionApp`. The cmdlet now supports retrieving deployment slots in the results when `-IncludeSlot` is specified. 
* Updated `New-AzFunctionApp`:
  - Fixed -DisableApplicationInsights so that no application insights project is created when this option is specified. [#12728]
  - [Breaking Change] Removed support to create PowerShell 6.2 function apps.
  - [Breaking Change] Changed the default runtime version in Functions version 3 on Windows for PowerShell function apps from 6.2 to 7.0 when the RuntimeVersion parameter is not specified.
  - [Breaking Change] Changed the default runtime version in Functions version 3 on Windows and Linux for Node function apps from 10 to 12 when the RuntimeVersion parameter is not specified.
  - [Breaking Change] Changed the default runtime version in Functions version 3 on Linux for Python function apps from 3.7 to 3.8 when the RuntimeVersion parameter is not specified.

## Version 1.0.2
* Removed the ability to create v2 Functions in regions that do not support it.
* Deprecated PowerShell 6.2. Added a warning for when a user creates a PowerShell 6.2 function app that advises them to create a PowerShell 7.0 function app instead.

## Version 1.0.1
* Added support to create PowerShell 7.0 and Java 11 function apps

## Version 1.0.0
* General availability of 'Az.Functions' module

## Version 0.0.3

## Version 0.0.2

## Version 0.0.1
* the first preview release

