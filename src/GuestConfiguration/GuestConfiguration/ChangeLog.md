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

## Version 0.10.2
- General bug fixes.
- Rename cmdlet Get-AzVMGuestPolicyReport to Get-AzVMGuestPolicyStatus to keep it consistent with the Azure portal and to avoid user confusion.

## Version 0.10.1
* Initial release of Az.GuestConfiguration module. Provides these two cmdlets.
  * Get-AzVMGuestPolicyStatus
    * Provides compliance status of a VM in a resource group, compliance reasons.
  * Get-AzVMGuestPolicyStatusHistory:
    * Provides historical compliance statuses of a VM in a resource group, for a maximum of past 14 days.