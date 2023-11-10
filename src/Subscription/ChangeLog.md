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

## Version 0.11.0
* Invoke-AzSubscriptionAcceptOwnership:
    - Added alias `-DisplayName` to parameter `-SubscriptionName`.
* New-AzSubscriptionAlias:
    - Added alias `-DisplayName` to parameter `-SubscriptionName`.
* Rename-AzSubscription:
    - Changed parameter `-SubscriptionName` to required.
    - Added alias `-DisplayName` to parameter `-SubscriptionName`.
* Removed cmdlet `Update-AzSubscriptionPolicy`
* Get-AzSubscriptionAcceptOwnershipStatus
    - Updated parameter type of `SubscriptionId` from `string[]` to `string`.

## Version 0.10.1
* Removed the default value for the `New-AzSubscriptionAlias` cmdlet parameter `SubscriptionId`.
* Removed the default value for the `Get-AzSubscriptionAcceptOwnershipStatus` cmdlet parameter `SubscriptionId` and mark the parameter as mandatory.
* Removed the default value for the `Invoke-AzSubscriptionAcceptOwnership` cmdlet parameter `SubscriptionId` and mark the parameter as mandatory.

## Version 0.10.0
* Upgrade API version to 2021-10-01.

## Version 0.9.0
* Fixed `New-AzSubscriptionAlias` cmdlet to make the Workload parameter mandatory.

## Version 0.8.1
* Updated Microsoft.Azure.Management.Subscription .Net SDK version to 2.0.0

## Version 0.8.0
* Added new cmdlets `New-AzSubscriptionAlias`,`Get-AzSubscriptionAlias`,`Remove-AzSubscriptionAlias` and Removed cmdlet `New-AzSubscription`

## Version 0.7.3
* Added new cmdlet `Update-AzSubscription`

## Version 0.7.2
* Update references in .psd1 to use relative path
