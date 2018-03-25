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

## Version 0.17.1
* Fix issue with Default Resource Group in CloudShell

## Version 0.17.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for Update-AzureRmMlCommitmentPlan

## Version 0.16.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
    
## Version 0.15.7

## Version 0.15.6

## Version 0.15.4

## Version 0.15.3

## Version 0.15.2

## Version 0.15.1

## Version 0.15.0

## Version 0.14.1

## Version 0.14.0
* Consume new version of Azure Machine Learning .Net SDK and add a new cmdlet
    - Add-AzureRmMlWebServiceRegionalProperty 
* Minor wording fixes in help text.

## Version 0.13.0

## Version 0.12.0

## Version 0.11.4

## Version 0.11.3

## Version 0.11.2
* Serialization and deserialization improvements for all cmdlets

## Version 0.11.1
* Add support for Azure Machine Learning Committment Plans
    - Get-AzureRmMLCommitmentAssociation
    - Get-AzureRmMLCommitmentPlan
    - Get-AzureRmMLCommitmentPlanUsageHistory
    - Move-AzureRmMLCommitmentAssociation
    - New-AzureRmMLCommitmentPlan
    - Remove-AzureRmMLCommitmentPlan
    - Update-AzureRmMLCommitmentPlan
