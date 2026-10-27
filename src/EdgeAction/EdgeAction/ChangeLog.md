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
* General availability for module Az.EdgeAction
* Targeted version 0.2.0, retaining the module's pre-1.0 status.
* Updated EdgeAction cmdlets and help to the stable 2026-10-01 API.
    - Refreshed update parameters and documented tag replacement, clearing, and immutable-property behavior.
    - Version tag updates preserve the default version; use `Switch-AzEdgeActionVersionDefault` to change it.
    - Clarified the JSON parameter path for clearing tags on EdgeActions, versions, and execution filters when expanded parameters omit empty objects.
    - Expanded test coverage for asynchronous operations and resource responses.
    - Fixed test recording normalization compatibility with Windows PowerShell 5.1.
    - Clarified subscription selection for version code retrieval and default-version switching.

## Version 0.1.2
* Updated `Get-AzEdgeActionVersionCode` to decode the base64-encoded version code and save it as a zip file when `-OutputPath` is specified
* Clarified the behavior and help of `Switch-AzEdgeActionVersionDefault` for swapping the default version of an Edge Action

## Version 0.1.1
* Updated to API version 2025-12-01-preview
* Removed `Add-AzEdgeActionAttachment` cmdlet (operation no longer available in API)
* Removed `Remove-AzEdgeActionAttachment` cmdlet (operation no longer available in API)

## Version 0.1.0
* First preview release for module Az.EdgeAction
