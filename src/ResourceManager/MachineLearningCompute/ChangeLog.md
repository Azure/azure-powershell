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
* Add IncludeAllResources parameter to Remove-AzureRmMlOpCluster cmdlet
    - Using this switch parameter will remove all resources that were created with the cluster originally
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 0.3.1
* Add Set-AzureRmMlOpCluster
    - Update a cluster's agent count or SSL configuration
* Orchestrator properties are optional
    - The service will create a service principal if not provided, so the orchestrator
    properties are now optional

## Version 0.2.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
    
## Version 0.1.0
- Added initial set of cmdlets for MachineLearningCompute
    - Get-AzureRmMlOpCluster
    - Get-AzureRmMlOpClusterKey
    - New-AzureRmMlOpCluster
    - Remove-AzureRmMlOpCluster
    - Test-AzureRmMlOpClusterSystemServicesUpdateAvailability
    - Update-AzureRmMlOpClusterSystemService
