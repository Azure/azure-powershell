---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/approve-azeventhubfabricshortcut
schema: 2.0.0
---

# Approve-AzEventHubFabricShortcut

## SYNOPSIS
Approves a Microsoft Fabric shortcut.

## SYNTAX

### Approve (Default)
```
Approve-AzEventHubFabricShortcut -EventHubName <String> -Name <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ApproveViaIdentity
```
Approve-AzEventHubFabricShortcut -InputObject <IEventHubIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ApproveViaIdentityEventhub
```
Approve-AzEventHubFabricShortcut -EventhubInputObject <IEventHubIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApproveViaIdentityNamespace
```
Approve-AzEventHubFabricShortcut -EventHubName <String> -Name <String>
 -NamespaceInputObject <IEventHubIdentity> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Approves a Microsoft Fabric shortcut.

## EXAMPLES

### Example 1: Approve a Fabric shortcut on an EventHub entity
```powershell
Approve-AzEventHubFabricShortcut -ResourceGroupName contoso-rg -NamespaceName contoso-eventhub -EventHubName orders -Name orders-shortcut
```

```output
ConfigurationArtifactId    : 33333333-3333-3333-3333-333333333333
ConfigurationArtifactName  : orders-eventstream
ConfigurationTenantId      : 11111111-1111-1111-1111-111111111111
ConfigurationWorkspaceId   : 22222222-2222-2222-2222-222222222222
ConfigurationWorkspaceName : contoso-workspace
CreatedAt                  : 7/1/2026 12:00:00 PM
Id                         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.EventHub/namespaces/contoso-eventhub/eventhubs/orders/fabricShortcuts/orders-shortcut
Location                   : southcentralus
ModifiedAt                 : 7/1/2026 12:05:00 PM
Name                       : orders-shortcut
ShortcutStatus             : Approved
ShortcutType               : Entity
StatusDescription          : Approved by the Event Hubs owner
Type                       : Microsoft.EventHub/namespaces/eventhubs/fabricShortcuts
```

Approves the Fabric shortcut `orders-shortcut` on the EventHub entity `orders` in namespace `contoso-eventhub`, moving its status to `Approved`.

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
Parameter Sets: ApproveViaIdentityEventhub
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
Parameter Sets: Approve, ApproveViaIdentityNamespace
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
Parameter Sets: ApproveViaIdentity
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
Parameter Sets: Approve, ApproveViaIdentityEventhub, ApproveViaIdentityNamespace
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
Parameter Sets: ApproveViaIdentityNamespace
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
Parameter Sets: Approve
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
Parameter Sets: Approve
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
Type: System.String
Parameter Sets: Approve
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
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

