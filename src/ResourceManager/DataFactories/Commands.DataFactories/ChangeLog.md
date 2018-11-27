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
* Updated the Microsoft.DataTransfer.Gateway.Encryption version to 3.11.6898.1 for .NetStandard version.

## Version 5.0.3
* Updated to the latest version of the Azure ClientRuntime.

## Version 5.0.2
* Updated all help files to include full parameter types and correct input/output types.

## Version 5.0.1
* Fixed formatting of OutputType in help files

## Version 5.0.0
* Set minimum dependency of module to PowerShell 5.0
* Remove deprecated `Tags` alias from cmdlets
    - New-AzureRmDataFactory

## Version 4.2.2
* Updated to the latest version of the Azure ClientRuntime

## Version 4.2.1
* Fix issue with Default Resource Group in CloudShell

## Version 4.2.0
* Fix credential encryption issue that caused no meaningful error for some encryption operations
* Enable integration runtime to be shared across data factory

## Version 4.1.0
* Enabled Azure Key Vault support for all data store linked services
* Added license type property for Azure SSIS integration runtime
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmDataFactory

## Version 4.0.3
* Credential encryption functionality now works with both "Remote Access" enabled (Over Network) and "Remote Access" disabled (Local Machine).

## Version 4.0.1
* Fixed assembly loading issue that caused some cmdlets to fail when executing

## Version 4.0.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1

## Version 3.4.0

## Version 3.3.1

## Version 3.3.0

## Version 3.2.1

## Version 3.2.0

* Deprecate New-AzureRmDataFactoryGatewayKey
* Introduce gateway auth key feature by adding New-AzureRmDataFactoryGatewayAuthKey and Get-AzureRmDataFactoryGatewayAuthKey

## Version 3.1.0

## Version 3.0.1

## Version 3.0.0

## Version 2.8.0

## Version 2.7.0

## Version 2.6.0
* Fixed Get-AzureRmDataFactoryActivityWindow so it works for named pipeline and activity

## Version 2.5.0

## Version 2.4.0

## Version 2.3.0
