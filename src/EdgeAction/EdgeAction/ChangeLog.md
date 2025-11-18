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

## Version 0.1.0
* First preview release for module Az.EdgeAction
* Support for Azure Edge Actions API version 2025-09-01-preview
* EdgeAction module created as top-level module (not under CDN)
* New cmdlets:
    - `New-AzEdgeAction` - Create edge action
    - `Get-AzEdgeAction` - Get edge action(s)
    - `Update-AzEdgeAction` - Update edge action
    - `Remove-AzEdgeAction` - Delete edge action
    - `New-AzEdgeActionVersion` - Create edge action version
    - `Get-AzEdgeActionVersion` - Get edge action version(s)
    - `Update-AzEdgeActionVersion` - Update edge action version
    - `Remove-AzEdgeActionVersion` - Delete edge action version
    - `Switch-AzEdgeActionVersionDefault` - Swap default version
    - `Deploy-AzEdgeActionVersionCode` - Deploy version code with file support
    - `Get-AzEdgeActionVersionCode` - Get deployed version code
    - `Add-AzEdgeActionAttachment` - Add attachment to edge action
    - `Remove-AzEdgeActionAttachment` - Remove attachment from edge action
    - `New-AzEdgeActionExecutionFilter` - Create execution filter
    - `Get-AzEdgeActionExecutionFilter` - Get execution filter(s)
    - `Update-AzEdgeActionExecutionFilter` - Update execution filter
    - `Remove-AzEdgeActionExecutionFilter` - Delete execution filter
* Enhanced `Deploy-AzEdgeActionVersionCode` cmdlet with file-based deployment:
    - Deploy from JavaScript files (.js)
    - Deploy from ZIP archives (.zip)
    - Automatic zipping of JavaScript files when using zip deployment type
    - Auto-detection of deployment type from file extension
    - Automatic base64 encoding
    - Support for custom deployment names

