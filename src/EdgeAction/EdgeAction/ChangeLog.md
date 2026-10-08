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
* Updated EdgeAction cmdlets and help to the stable 2026-10-01 API.
    - Refreshed update parameters and documented tag replacement, clearing, and immutable-property behavior.
* Relocated EdgeAction scenario test tooling to the module directory; cmdlet behavior is unchanged.
    - Shared settings now default to Azure public cloud, with explicit Brazilus overrides and environment endpoint validation.
    - Clarified test-runner setup guidance and invocation from different working directories.
    - Generation and test tooling report major step starts and successful completions; generation also displays the configured specification input.
    - Fixed Pester discovery for the artifact test harness by isolating the selected 4.10.1 installation in a temporary module search root.

## Version 0.1.2
* Updated `Get-AzEdgeActionVersionCode` to decode the base64-encoded version code and save it as a zip file when `-OutputPath` is specified
* Clarified the behavior and help of `Switch-AzEdgeActionVersionDefault` for swapping the default version of an Edge Action

## Version 0.1.1
* Updated to API version 2025-12-01-preview
* Removed `Add-AzEdgeActionAttachment` cmdlet (operation no longer available in API)
* Removed `Remove-AzEdgeActionAttachment` cmdlet (operation no longer available in API)

## Version 0.1.0
* First preview release for module Az.EdgeAction
