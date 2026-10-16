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
* Upgraded the Compute Fleet API from 2026-04-01-preview to 2026-08-01 (general availability).
* [Breaking change] Removed 'ZoneAllocationPolicyDistributionStrategy' and 'ZoneAllocationPolicyZonePreference' from 'New-AzComputeFleet', 'Set-AzComputeFleet', and 'Update-AzComputeFleet' to match the 2026-08-01 API.
    - Scripts using these parameters must be updated before upgrading. The 'Zone' parameter remains supported but does not replace the removed zone-allocation policy settings.
* Fixed module generation from newer TypeSpec specifications while retaining the existing generation toolchain.
* Updated Compute Fleet examples for API version 2026-08-01, including Launch mode creation, fleet identity input, and partial updates.

## Version 0.2.0

* Added support for 'Launch' mode in ComputeFleet.
    - New parameter, 'Mode' to specify 'Managed'/'Launch'.
    - New parameter, 'VMNamePrefix' to specify prefix for the virtual machines in Launch mode.
    - New cmdlet 'Get-AzCompouteFleetVirtualMachine' to list the virtual machines in Launch mode.
* Upgraded API version from 2024-11-01 to 2026-04-01-preview.

## Version 0.1.1
* Fixed module name in module metadata

## Version 0.1.0
* Upgraded nuget package to signed package.

## Version 0.1.0
* First preview release for module Az.ComputeFleet
