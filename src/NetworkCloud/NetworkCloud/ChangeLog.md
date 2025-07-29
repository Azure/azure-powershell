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
* Removed parameters `-IdentityType`  for below commands to support for new Managed Identity setting. And `-IdentityUserAssignedIdentity` is renamed to `-UserAssignedIdentity`. `EnableSystemAssignedIdentity` is used to enable/disable system-assigned identities.
  * Cmdlet `New-AzNetworkCloudCluster`
  * Cmdlet `New-AzNetworkCloudClusterManager`
  * Cmdlet `Update-AzNetworkCloudCluster`
  * Cmdlet `Update-AzNetworkCloudClusterManager`
* Introduced various new features by upgrading code generator. Please see details [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).
* Upgraded API version to 2025-02-01

## Version 1.1.0
* Upgraded nuget package to signed package.
* Upgraded API version to 2024-07-01

## Version 1.0.2
* Fixed secrets exposure in example documentation.

## Version 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.0.0
* General availability of 'Az.NetworkCloud' module

## Version 0.1.0
* First preview release for module Az.NetworkCloud

