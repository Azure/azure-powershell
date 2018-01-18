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
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 0.6.1
* Remove validate set of location into dynamic lookup so that all clouds are supported.

## Version 0.5.0
* Fixed Synchronize-AzureAsInstance command to work with new AsAzure REST API for sync
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
    
## Version 0.4.7

## Version 0.4.6
* Added a new dataplane commandlet to allow synchronization of databases from read-write instance to read-only instances 
    - Included help file for the commandlet
    - Added in-memory tests and a scenario test (only live)
* Fixed bugs in Add-AzureAsAccount commandlet 

## Version 0.4.4

## Version 0.4.3
* Fixed bug in Set-AzureRmAnalysisServciesServer
    - When admin was not provided, the admin will be removed.
* Added BackupBlobContainerUri in New-AzureRmAnalysisServicesServer and Set-AzureRmAnalysisServicesServer
    - Enable to set/disable backup blob container for backup/restore Azure Analysis Services Server
* Updated Sku lookup in New-AzureRmAnalysisServicesServer and Set-AzureRmAnalysisServicesServer
    - Changed hard coded Sku into dynamic lookup.
* Add-AzureAnalysisServicesAccount to support login with Service Principal

## Version 0.4.2

## Version 0.4.1
* Add new dataplane API
    - Introduced API to fetch AS server log, Export-AzureAnalysisServicesInstanceLog

## Version 0.4.0
* New SKUs added: B1, B2, S0
* Scale up/down support added

## Version 0.3.1

## Version 0.3.0

## Version 0.2.0

## Version 0.1.0

## Version 0.0.4
* Added State property in additional to ProvisioningState
    - All the cmdlet returning AnalysisService would have a new property 'State' used outside of provisioing.
    - The 'State' is intended to check status outside of provisioning, while 'ProvisioningState' is intended to check status related to Provisioning.
    - ProvisioningState and State are same in service side at this moment, the service side would differenciate ProvisioningState and State in future

## Version 0.0.3
* Added two new dataplane APIs in a separate module Azure.AnalysisServices.psd1
    - This introduces two new APIs that enable customers to login to Azure Analysis Services servers and issue a restart command.

## Version 0.0.2
* Fixed bug in Get-AzureRMAnalysisServicesServer
    - When this command was run against some resources, it would fail with a null reference exception.
