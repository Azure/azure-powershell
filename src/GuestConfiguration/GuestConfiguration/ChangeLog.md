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
* Converted Az.GuestConfiguration to generated module

## Version 0.10.8
* Support ARC machines

## Version 0.10.7
* Update references in .psd1 to use relative path

## Version 0.10.6
* Fixed the inconsistency of compliance status reporting when Policy is non-compliant due to parameter updates scenario.
* Quering data from PolicyInsights RP to get the updated compliance status.  

## Version 0.10.5
- Fixed cmdlets failure when a subscription has an incorrect format initiative definition for GuestConfiguration category.

## Version 0.10.4
* Fix cmdlets failure when an initiative definition in subscription does not have category set.

## Version 0.10.3
- Support Custom policy reports retrieval through the cmd-lets
- Add versioning information to the reports

## Version 0.10.2
- General bug fixes.
- Rename cmdlet Get-AzVMGuestPolicyReport to Get-AzVMGuestPolicyStatus to keep it consistent with the Azure portal and to avoid user confusion.

## Version 0.10.1
* Initial release of Az.GuestConfiguration module. Provides these two cmdlets.
  * Get-AzVMGuestPolicyStatus
    * Provides compliance status of a VM in a resource group, compliance reasons.
  * Get-AzVMGuestPolicyStatusHistory:
    * Provides historical compliance statuses of a VM in a resource group, for a maximum of past 14 days.
