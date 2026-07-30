---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/remove-azwvdprivateendpointconnection
Module Name: Az.DesktopVirtualization
ms.date: 07/29/2026
PlatyPS schema version: 2024-05-01
---

# Remove-AzWvdPrivateEndpointConnection

## SYNOPSIS

Delete a PrivateEndpointConnectionWithSystemData

## SYNTAX

### Delete (Default)

```
Remove-AzWvdPrivateEndpointConnection -HostPoolName <string> -Name <string>
 -ResourceGroupName <string> [-SubscriptionId <string>] [-DefaultProfile <psobject>] [-PassThru]
 [-WhatIf] [-Confirm]
```

### Delete1

```
Remove-AzWvdPrivateEndpointConnection -Name <string> -ResourceGroupName <string>
 -WorkspaceName <string> [-SubscriptionId <string>] [-DefaultProfile <psobject>] [-PassThru]
 [-WhatIf] [-Confirm]
```

### DeleteViaIdentity

```
Remove-AzWvdPrivateEndpointConnection -InputObject <IDesktopVirtualizationIdentity>
 [-DefaultProfile <psobject>] [-PassThru] [-WhatIf] [-Confirm]
```

### DeleteViaIdentity1

```
Remove-AzWvdPrivateEndpointConnection -InputObject <IDesktopVirtualizationIdentity>
 [-DefaultProfile <psobject>] [-PassThru] [-WhatIf] [-Confirm]
```

### DeleteViaIdentityHostPool

```
Remove-AzWvdPrivateEndpointConnection -Name <string>
 -HostPoolInputObject <IDesktopVirtualizationIdentity> [-DefaultProfile <psobject>] [-PassThru]
 [-WhatIf] [-Confirm]
```

### DeleteViaIdentityWorkspace

```
Remove-AzWvdPrivateEndpointConnection -Name <string>
 -WorkspaceInputObject <IDesktopVirtualizationIdentity> [-DefaultProfile <psobject>] [-PassThru]
 [-WhatIf] [-Confirm]
```

## ALIASES

## DESCRIPTION

Delete a PrivateEndpointConnectionWithSystemData

## EXAMPLES

### Example 1: Remove the Private Endpoint Connection between the Private Endpoint and Azure Virtual Desktop HostPool by WVD Private Endpoint Connection Name and HostPoolName

```powershell
Remove-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -Name WvdPrivateEndpointConnectionName -HostpoolName HostPoolName
```

```output
<none>
```

This command removes the Private Endpoint Connection to the Azure Virtual Desktop HostPool in a Resource Group.
It does not delete the Private Endpoint.
Customers will need to separately delete the Private Endpoint.

### Example 2: Remove the Private Endpoint Connection between the Private Endpoint and Azure Virtual Desktop Workspace by WVD Private Endpoint Connection Name and WorkspaceName

```powershell
Remove-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -Name WvdPrivateEndpointConnectionName -WorkspaceName WorkspaceName
```

```output
<none>
```

This command removes the Private Endpoint Connection to the Azure Virtual Desktop Workspace in a Resource Group.
It does not delete the Private Endpoint.
Customers will need to separately delete the Private Endpoint.

--------

## PARAMETERS

### -Confirm

Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases:
- cf
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -DefaultProfile

The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
DefaultValue: None
SupportsWildcards: false
Aliases:
- AzureRMContext
- AzureCredential
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -HostPoolInputObject

Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: DeleteViaIdentityHostPool
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -HostPoolName

The name of the host pool within the specified resource group

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Delete
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -InputObject

Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: DeleteViaIdentity1
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: DeleteViaIdentity
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

The name parameter for private endpoint

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases:
- PrivateEndpointConnectionName
ParameterSets:
- Name: DeleteViaIdentityWorkspace
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: DeleteViaIdentityHostPool
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Delete1
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Delete
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -PassThru

Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ResourceGroupName

The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Delete1
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Delete
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -SubscriptionId

The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
DefaultValue: (Get-AzContext).Subscription.Id
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Delete1
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Delete
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WhatIf

Shows what would happen if the cmdlet runs.
The cmdlet is not run.
Runs the command in a mode that only reports what would happen without performing the actions.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases:
- wi
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WorkspaceInputObject

Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: DeleteViaIdentityWorkspace
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WorkspaceName

The name of the workspace

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Delete1
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

