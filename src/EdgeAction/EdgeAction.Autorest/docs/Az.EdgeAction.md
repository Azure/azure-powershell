---
Module Name: Az.EdgeAction
Module Guid: 05dd8b44-af15-4480-95d5-3a230e07c171
Download Help Link: https://learn.microsoft.com/powershell/module/az.edgeaction
Help Version: 1.0.0.0
Locale: en-US
---

# Az.EdgeAction Module
## Description
Microsoft Azure PowerShell: EdgeAction cmdlets

## Az.EdgeAction Cmdlets
### [Deploy-AzEdgeActionVersionCode](Deploy-AzEdgeActionVersionCode.md)
Deploy Edge Action version code from a file.

### [Get-AzEdgeAction](Get-AzEdgeAction.md)
Get a EdgeAction

### [Get-AzEdgeActionExecutionFilter](Get-AzEdgeActionExecutionFilter.md)
Get a EdgeActionExecutionFilter

### [Get-AzEdgeActionVersion](Get-AzEdgeActionVersion.md)
Get a EdgeActionVersion

### [Get-AzEdgeActionVersionCode](Get-AzEdgeActionVersionCode.md)
Get Edge Action version code and optionally save to file.

### [New-AzEdgeAction](New-AzEdgeAction.md)
Create a EdgeAction

### [New-AzEdgeActionExecutionFilter](New-AzEdgeActionExecutionFilter.md)
Create a EdgeActionExecutionFilter

### [New-AzEdgeActionVersion](New-AzEdgeActionVersion.md)
Create a EdgeActionVersion

### [Remove-AzEdgeAction](Remove-AzEdgeAction.md)
Delete a EdgeAction

### [Remove-AzEdgeActionExecutionFilter](Remove-AzEdgeActionExecutionFilter.md)
Delete a EdgeActionExecutionFilter

### [Remove-AzEdgeActionVersion](Remove-AzEdgeActionVersion.md)
Delete a EdgeActionVersion

### [Switch-AzEdgeActionVersionDefault](Switch-AzEdgeActionVersionDefault.md)
Swap the default version for an Edge Action.

### [Update-AzEdgeAction](Update-AzEdgeAction.md)
Update the tags of an Edge Action.
Omitted tags are preserved, an empty tags object clears all tags, and supplied tags replace the entire tag collection.
Null tags are rejected.
Do not include sku in PATCH requests; any supplied sku, including null or the existing value, is rejected.

### [Update-AzEdgeActionExecutionFilter](Update-AzEdgeActionExecutionFilter.md)
Update the properties and tags of an Edge Action execution filter.
Omitted tags are preserved, an empty tags object clears all tags, and supplied tags replace the entire tag collection.
Null tags are rejected.

### [Update-AzEdgeActionVersion](Update-AzEdgeActionVersion.md)
Update the tags of an Edge Action version.
Omitted tags are preserved, an empty tags object clears all tags, and supplied tags replace the entire tag collection.
Null tags are rejected.
Version properties are not changed.
If deploymentType or isDefaultVersion is supplied, it must match the existing value; use swapDefault to change the default version.

