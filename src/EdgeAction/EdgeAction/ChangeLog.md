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
* Updated to stable API 2026-10-01; module remains pre-1.0 at 0.2.0.
* Updated parameters and documented tag replacement, JSON-based clearing and immutable properties.
* Preserved default versions during tag updates; use `Switch-AzEdgeActionVersionDefault` to switch.
* Clarified subscription selection for code retrieval and default-version switching.
* Expanded asynchronous operation tests and fixed Windows PowerShell 5.1 recording compatibility.

## Version 0.1.2
* Updated `Get-AzEdgeActionVersionCode` to decode the base64-encoded version code and save it as a zip file when `-OutputPath` is specified
* Clarified the behavior and help of `Switch-AzEdgeActionVersionDefault` for swapping the default version of an Edge Action

## Version 0.1.1
* Updated to API version 2025-12-01-preview
* Removed `Add-AzEdgeActionAttachment` cmdlet (operation no longer available in API)
* Removed `Remove-AzEdgeActionAttachment` cmdlet (operation no longer available in API)

## Version 0.1.0
* First preview release for module Az.EdgeAction
