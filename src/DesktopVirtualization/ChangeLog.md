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
* Added Private Link Cmdlets
    - Get-AzWvdPrivateEndpointConnection
    - Get-AzWvdPrivateLinkResource
    - Remove-AzWvdPrivateEndpointConnection
    - Remove-AzWvdPrivateLinkResource
* Added Scaling Plan Personal Schedule cmdlets
    - Get-AzWvdScalingPlanPersonalSchedule
    - New-AzWvdScalingPlanPersonalSchedule
    - Remove-AzWvdScalingPlanPersonalSchedule
    - Update-AzWvdScalingPlanPersonalSchedule
* Added Scaling Plan Pooled Schedule cmdlets
    - Get-AzWvdScalingPlanPooledSchedule
    - New-AzWvdScalingPlanPooledSchedule
    - Remove-AzWvdScalingPlanPooledSchedule
    - Update-AzWvdScalingPlanPooledSchedule
* Updated rampDownCapacityThresholdPct minimum value from 0 to 1 on ScalingPlanPooledSchedule cmdlets
* Added showInFeed property to ApplicationGroups
