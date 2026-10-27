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
* Restored the `ExtendedLocationName` parameter name.
* Removed `InputObject` from `Get-AzAksArcNodepool` and `New-AzAksArcNodepool`.
* Restricted `New-AzAksArcCluster` parameters `VnetId` and `EnableAzureHybridBenefit` to `CreateExpanded`; delegated network validation to the webhook.
* Fixed JSON parameter sets in `New-AzAksArcVirtualNetwork`.
* Added `ClusterName`, `ResourceGroupName` and `SubscriptionId` to `Remove-AzAksArcNodepool` parameter set `Delete`; fixed `InputObject` handling.
* Made `Update-AzAksArcCluster -SubscriptionId` mandatory, enabled autoscaling parameters in all sets, and fixed early exit after nodepool updates.
* Updated `Update-AzAksArcNodepool`:
    - Added `ClusterName`, `ResourceGroupName`, `SubscriptionId` and `Name` to `UpdateExpanded`.
    - Removed `AutoScaling`; renamed `CreateViaIdentityExpanded` to `UpdateViaIdentityExpanded`.
    - Added `MaxPod`, `OSSku` and `OSType`; fixed `InputObject` handling.

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
