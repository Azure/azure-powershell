---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/get-azwvdprivateendpointconnection
Module Name: Az.DesktopVirtualization
ms.date: 07/29/2026
PlatyPS schema version: 2024-05-01
---

# Get-AzWvdPrivateEndpointConnection

## SYNOPSIS

Get a PrivateEndpointConnectionWithSystemData

## SYNTAX

### List (Default)

```
Get-AzWvdPrivateEndpointConnection -HostPoolName <string> -ResourceGroupName <string>
 [-SubscriptionId <string[]>] [-InitialSkip <int>] [-IsDescending] [-PageSize <int>]
 [-DefaultProfile <psobject>]
```

### Get

```
Get-AzWvdPrivateEndpointConnection -HostPoolName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1

```
Get-AzWvdPrivateEndpointConnection -Name <string> -ResourceGroupName <string>
 -WorkspaceName <string> [-SubscriptionId <string[]>] [-DefaultProfile <psobject>]
```

### GetViaIdentity

```
Get-AzWvdPrivateEndpointConnection -InputObject <IDesktopVirtualizationIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1

```
Get-AzWvdPrivateEndpointConnection -InputObject <IDesktopVirtualizationIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityHostPool

```
Get-AzWvdPrivateEndpointConnection -Name <string>
 -HostPoolInputObject <IDesktopVirtualizationIdentity> [-DefaultProfile <psobject>]
```

### GetViaIdentityWorkspace

```
Get-AzWvdPrivateEndpointConnection -Name <String>
 -WorkspaceInputObject <IDesktopVirtualizationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1

```
Get-AzWvdPrivateEndpointConnection -ResourceGroupName <string> -WorkspaceName <string>
 [-SubscriptionId <string[]>] [-DefaultProfile <psobject>]
```

## ALIASES

## DESCRIPTION

Get a PrivateEndpointConnectionWithSystemData

## EXAMPLES

### Example 1: Get a PrivateEndpointConnection by Workspace

```powershell
Get-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -workspaceName WorkspaceName -privateEndpointConnectionName privateName
```

```output
Name                                         PrivateEndpointId                                                                                                                           PrivateLinkServiceConnectionStateActionsRequired PrivateLinkServiceConnectionStateDescription PrivateLinkServiceConnectionStateStatus ProvisioningState
----                                         -----------------                                                                                                                           ------------------------------------------------ -------------------------------------------- --------------------------------------- -----------------
privateName1                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/WorkspaceName  None                                             Auto-approved                                Approved                                Succeeded
```

Gets a private endpoint connection from a Workspace.

### Example 1: List PrivateEndpointConnections by Workspace

```powershell
Get-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -workspaceName WorkspaceName
```

```output
Name                                         PrivateEndpointId                                                                                                                           PrivateLinkServiceConnectionStateActionsRequired PrivateLinkServiceConnectionStateDescription PrivateLinkServiceConnectionStateStatus ProvisioningState
----                                         -----------------                                                                                                                           ------------------------------------------------ -------------------------------------------- --------------------------------------- -----------------
privateName1                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/WorkspaceName None                                             Auto-approved                                Approved                                Succeeded
privateName2                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/WorkspaceName None                                             Auto-approved                                Approved                                Succeeded
```

Lists private endpoint connections from a Workspace.

### Example 3: Get a PrivateEndpointConnection by HostPool

```powershell
Get-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -HostPoolName hpName -privateEndpointConnectionName privateName
```

```output
Name                                         PrivateEndpointId                                                                                                                     PrivateLinkServiceConnectionStateActionsRequired PrivateLinkServiceConnectionStateDescription PrivateLinkServiceConnectionStateStatus ProvisioningState
----                                         -----------------                                                                                                                     ------------------------------------------------ -------------------------------------------- --------------------------------------- -----------------
privateName1                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/hpName  None                                             Auto-approved                                Approved                                Succeeded
```

Gets a private endpoint connection from a HostPool.

### Example 1: List PrivateEndpointConnections by HostPool

```powershell
Get-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -HostPoolName hpName
```

```output
Name                                         PrivateEndpointId                                                                                                                    PrivateLinkServiceConnectionStateActionsRequired PrivateLinkServiceConnectionStateDescription PrivateLinkServiceConnectionStateStatus ProvisioningState
----                                         -----------------                                                                                                                    ------------------------------------------------ -------------------------------------------- --------------------------------------- -----------------
privateName1                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/hpName None                                             Auto-approved                                Approved                                Succeeded
privateName2                                  /subscriptions/00000000-0000-0000-000000000000/resourceGroups/ResourceGroupName/providers/microsoft.network/privateendpoints/hpName None                                             Auto-approved                                Approved                                Succeeded
```

Lists private endpoint connections from a Hostpool.

## PARAMETERS

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
- Name: GetViaIdentityHostPool
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
- Name: List
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -InitialSkip

Initial number of items to skip.

```yaml
Type: System.Int32
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List
  Position: Named
  IsRequired: false
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
- Name: GetViaIdentity1
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: GetViaIdentity
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -IsDescending

Indicates whether the collection is descending.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
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
- Name: GetViaIdentityWorkspace
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: GetViaIdentityHostPool
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get1
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -PageSize

Number of items per page.

```yaml
Type: System.Int32
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List
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
- Name: List1
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: List
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get1
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get
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
Type: System.String[]
DefaultValue: (Get-AzContext).Subscription.Id
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List1
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: List
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get1
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get
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
- Name: GetViaIdentityWorkspace
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
- Name: List1
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get1
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IPrivateEndpointConnectionWithSystemData

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

