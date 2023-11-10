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

## Version 4.2.0
* Added cmdlets:
    - `Get-AzWvdAppAttachPackage`
    - `Import-AzWvdAppAttachPackageInfo`
    - `New-AzWvdAppAttachPackage`
    - `Remove-AzWvdAppAttachPackage`
    - `Update-AzWvdAppAttachPackage`
* Added Private Link Cmdlets
    - `Get-AzWvdPrivateEndpointConnection`
    - `Get-AzWvdPrivateLinkResource`
    - `Remove-AzWvdPrivateEndpointConnection`
* Added Scaling Plan Personal Schedule cmdlets
    - `Get-AzWvdScalingPlanPersonalSchedule`
    - `New-AzWvdScalingPlanPersonalSchedule`
    - `Remove-AzWvdScalingPlanPersonalSchedule`
    - `Update-AzWvdScalingPlanPersonalSchedule`
* Added Scaling Plan Pooled Schedule cmdlets
    - `Get-AzWvdScalingPlanPooledSchedule`
    - `New-AzWvdScalingPlanPooledSchedule`
    - `Remove-AzWvdScalingPlanPooledSchedule`
    - `Update-AzWvdScalingPlanPooledSchedule`
* Updated rampDownCapacityThresholdPct minimum value from 0 to 1 on ScalingPlanPooledSchedule cmdlets
* Added showInFeed property to ApplicationGroups

## Version 4.0.0
* Upgraded API version to 2022-09-09
* Added cmdlet:
    - `Get-AzWvdScalingPlanPooledSchedule`
    - `New-AzWvdScalingPlanPooledSchedule`
    - `Remove-AzWvdScalingPlanPooledSchedule`
    - `Update-AzWvdScalingPlanPooledSchedule`
* Added parameters `pageSize`, `isDescending` and `initialSkip` to:
    - `Get-AzWvdApplication`
    - `Get-AzWvdApplicationGroup`
    - `Get-AzWvdDesktop`
    - `Get-AzWvdHostPool`
    - `Get-AzWvdMsixPackage`
    - `Get-AzWvdScalingPlan`
    - `Get-AzWvdSessionHost`
    - `Get-AzWvdStartMenuItem`
    - `Get-AzWvdUserSession`
    - `Get-AzWvdWorkspace`
* Added parameters `AgentUpdateMaintenanceWindow`, `AgentUpdateMaintenanceWindowTimeZone`, `AgentUpdateType`, `AgentUpdateUseSessionHostLocalTime` to:
    - `New-AzWvdHostPool`
    - `Update-AzWvdHostPool`
* Added parameter `FriendlyName` to:
    - `New-AzWvdHostPool`
    - `Update-AzWvdHostPool`
    - `Update-AzWvdSessionHost`

## Version 3.1.1
* Corrected parameter description of `-Force` in `Remove-AzWvdUserSession`.

## Version 3.1.0
* Upgraded api version to 2021-07-12.

## Version 3.0.0
* Upgraded api version to 2021-02-01-preview.

## Version 2.1.1
* Added StartVMOnConnect property to hostpool.

## Version 2.1.0
* Added StartVMOnConnect property to hostpool.

## Version 2.0.1
* Added new MSIX Package cmdlets and updated Applications cmdlets.

## Version 2.0.0
* Require Location property for creating top level arm objects.
* Made `ApplicationGroupType` required for `New-AzWvdApplicationGroup`.
* Made `HostPoolArmPath` required for `New-AzWvdApplicationGroup`.
* Added `PreferredAppGroupType` for `New-AzWvdHostPool`.

## Version 1.0.0
* General availability of `Az.DesktopVirtualization` module.

## 0.1.0
* The first preview release
