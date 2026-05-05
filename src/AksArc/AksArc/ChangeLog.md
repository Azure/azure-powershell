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

## Version 0.2.0
* Fixed commands and added autorest tests.
    - Undo ExtendedLocationName to CustomLocationID parameter rename in `src/AksArc/AksArc.Autorest/README.md`.
    - Get-AzAksArcNodepool
        - Removed `-InputObject` parameter.
    - New-AzAksArcCluster
        - Parameter `-VnetId` only available for `CreateExpanded` parameter set.
        - Parameter `-EnableAzureHybridBenefit` only available for `CreateExpanded` parameter set.
        - Removed redundant, complex logical network validation already done by webhook.
    - New-AzAksArcNodepool
        - Removed `-InputObject` parameter.
    - New-AzAksArcVirtualNetwork
        - Fixed `CreateViaJsonFilePath` and `CreateViaJsonString` parameter sets.
    - Remove-AzAksArcNodepool
        - Parameters `ClusterName`, `ResourceGroupName`, and `SubscriptionId` are part of `Delete` parameter set.
        - Add work-around for `InputObject` parameter.
    - Update-AzAksArcCluster
        - Parameter `SubscriptionId` is mandatory.
        - Parameters `MinCount`, `MaxCount`, and `EnableAutoScaling` are available for all parameter sets.
        - Removed `return` statemenet after only updating the nodepool.
    - Update-AzAksArcNodepool
        - Parameters `ClusterName`, `ResourceGroupName`, `SubscriptionId`, and `Name` are part of `UpdateExpanded` parameter set.
        - Removed `AutoScaling` parameter set.
        - Added `MaxPod`, `OSSku`, and `OSType` parameters.
        - Changed parameter set name from `CreateViaIdentityExpanded` to `UpdateViaIdentityExpanded`.
        - Add work-around for `InputObject` parameter.

## Version 0.1.4
* Fixed module name in module metadata

## Version 0.1.3
* Upgraded nuget package to signed package.

## Version 0.1.2
* Fixed bug where Remove-AzAksArcCluster would take a very long time to complete.
* Fixed issue where Update-AzAksArcCluster would error out when passing AdminGroupObjectID parameter.

## Version 0.1.1
* Fixed bug where `Invoke-AzAksArcClusterUpgrade` would throw false exception when kubernetes version is passed as a parameter. 
* Fixed bug where default nodepool labels and taints parameters would not work for `New-AzAksArcCluster` command.

## Version 0.1.0
* Added cmdlets for virtual networks
* Improved Error Checking
* Renamed Parameters to make more consistent with Azure CLI
* Added new cmdlet for upgrading clusters
* First preview release for module Az.AksArc
