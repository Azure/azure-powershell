---
external help file: Az.EventHub-help.xml
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/get-azeventhubfabricshortcut
schema: 2.0.0
---

# Get-AzEventHubFabricShortcut

## SYNOPSIS
Gets a Microsoft Fabric shortcut.

## SYNTAX

### List (Default)
```
Get-AzEventHubFabricShortcut -EventHubName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityNamespace
```
Get-AzEventHubFabricShortcut -EventHubName <String> -Name <String> -NamespaceInputObject <IEventHubIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzEventHubFabricShortcut -EventHubName <String> -Name <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityEventhub
```
Get-AzEventHubFabricShortcut -Name <String> -EventhubInputObject <IEventHubIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEventHubFabricShortcut -InputObject <IEventHubIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Microsoft Fabric shortcut.

## EXAMPLES

### Example 1: Get a Fabric shortcut on an EventHub entity
```powershell
Get-AzEventHubFabricShortcut -ResourceGroupName contoso-rg -NamespaceName contoso-eventhub -EventHubName orders -Name orders-shortcut
```

```output
ConfigurationArtifactId        : 33333333-3333-3333-3333-333333333333
ConfigurationArtifactName      : orders-eventstream
ConfigurationPremiumCapacityId : 44444444-4444-4444-4444-444444444444
ConfigurationTenantId          : 11111111-1111-1111-1111-111111111111
ConfigurationWorkspaceId       : 22222222-2222-2222-2222-222222222222
ConfigurationWorkspaceName     : contoso-workspace
CreatedAt                      : 7/1/2026 12:00:00 PM
Id                             : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.EventHub/namespaces/contoso-eventhub/eventhubs/orders/fabricShortcuts/orders-shortcut
Location                       : southcentralus
ModifiedAt                     : 7/1/2026 12:05:00 PM
Name                           : orders-shortcut
ShortcutStatus                 : Approved
ShortcutType                   : Entity
StatusDescription              : Approved by the Event Hubs owner
Type                           : Microsoft.EventHub/namespaces/eventhubs/fabricShortcuts
```

Gets the Fabric shortcut `orders-shortcut` on the EventHub entity `orders` in namespace `contoso-eventhub`.

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

### -EventhubInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: GetViaIdentityEventhub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EventHubName
The Event Hub name

```yaml
Type: System.String
Parameter Sets: List, GetViaIdentityNamespace, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Microsoft Fabric shortcut name.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityNamespace, Get, GetViaIdentityEventhub
Aliases: FabricShortcutName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: GetViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The Namespace name

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IFabricShortcut

## NOTES

## RELATED LINKS
