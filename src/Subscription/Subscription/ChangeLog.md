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
* upgraded nuget package to signed package.

## Version 0.11.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.11.0

### Issue summary

When the PowerShell module Version 0.10.0 of the Az.Subscription got released, it was reported that there were significant number of breaking changes related to mismatch of parameters that got added to the module. Our public facing help document also depicted the older version of the module and hence there was a discrepancy.

#### Why did this happen?

The latest module that got auto generated from Swagger resulted not only in changing certain parameter names, but also introducing new parameters which we did not support in the past. Additionally, our public help facing document was still displaying the module with older cmdlet parameters that was a cause of confusion.

#### How did we remedy?

We did a hotfix for this issue and created a new release 0.11.0. Most of the changes made, reflect parity with the public Swagger and we have now fixed the parameters issue.  Features of the new release mentioned below:

1. `New-AzSubscriptionAlias` now supports additional input "ManagementGroup" to associate the subscription with, additional owner and tenant for the subscription.
1. The parameter `SubscriptionName` has been changed to `DisplayName`. However, `SubscriptionName` is still available as an alias parameter for `DisplayName`.
1. `Updated-AzSubscription` cmdlet which was used for cancel, enable, and rename operations is replaced with new separate cmdlets to directly reflect actions: `Disable-AzSubscription`, `Enable-AzSubscription`, and `Rename-AzSubscription`.
1. New cmdlets (`Get-AzSubscriptionAcceptOwnershipStatus` & `Invoke-AzSubscriptionAcceptOwnership`) are introduced to handle / to work with invitation model - to get the status and to accept the invitation for new subscription creation.
1. Public documentation updated for PowerShell version for create subscription flow as 0.9.0.

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
