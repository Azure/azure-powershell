<!--
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

## Version 0.2.4
* Fix parameter sets issue for container registry and azure file volume mount
* Fix issue with Default Resource Group in CloudShell

## Version 0.2.3
* Apply Azure Container Instance SDK 2018-02-01
    - Support DNS name label

## Version 0.2.2
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 0.2.1
* Apply Azure Container Instance SDK 2017-10-01
    - Support container run-to-completion
    - Support Azure File volume mount
    - Support opening multiple ports for public IP

## Version 0.1.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
    
## Version 0.0.2

## Version 0.0.1
* Add PowerShell cmdlets for Azure Container Instance
    - New-AzureRmContainerGroup
    - Get-AzureRmContainerGroup
    - Remove-AzureRmContainerGroup
    - Get-AzureRmContainerInstanceLog
