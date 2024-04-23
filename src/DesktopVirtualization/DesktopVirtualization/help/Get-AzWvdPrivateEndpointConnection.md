---
external help file: Az.DesktopVirtualization-help.xml
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/get-azwvdprivateendpointconnection
schema: 2.0.0
---

# Get-AzWvdPrivateEndpointConnection

## SYNOPSIS
Get a private endpoint connection.

## SYNTAX

### List (Default)
```
Get-AzWvdPrivateEndpointConnection -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get1
```
Get-AzWvdPrivateEndpointConnection -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -HostPoolName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzWvdPrivateEndpointConnection -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzWvdPrivateEndpointConnection -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -HostPoolName <String> [-InitialSkip <Int32>] [-IsDescending] [-PageSize <Int32>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzWvdPrivateEndpointConnection -InputObject <IDesktopVirtualizationIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWvdPrivateEndpointConnection -InputObject <IDesktopVirtualizationIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a private endpoint connection.

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
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostPoolName
The name of the host pool within the specified resource group

```yaml
Type: System.String
Parameter Sets: Get1, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitialSkip
Initial number of items to skip.

```yaml
Type: System.Int32
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: GetViaIdentity1, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsDescending
Indicates whether the collection is descending.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the private endpoint connection associated with the Azure resource

```yaml
Type: System.String
Parameter Sets: Get1, Get
Aliases: PrivateEndpointConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageSize
Number of items per page.

```yaml
Type: System.Int32
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get1, Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get1, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20230905.IPrivateEndpointConnectionWithSystemData

## NOTES

## RELATED LINKS
