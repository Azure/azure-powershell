---
external help file: Az.EventHub-help.xml
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/invoke-azeventhubrejectfabricshortcut
schema: 2.0.0
---

# Invoke-AzEventHubRejectFabricShortcut

## SYNOPSIS
Rejects a Microsoft Fabric shortcut.

## SYNTAX

### Reject (Default)
```
Invoke-AzEventHubRejectFabricShortcut -EventHubName <String> -FabricShortcutName <String>
 -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

### RejectViaIdentityNamespace
```
Invoke-AzEventHubRejectFabricShortcut -EventHubName <String> -FabricShortcutName <String>
 -NamespaceInputObject <IEventHubIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### RejectViaIdentityEventhub
```
Invoke-AzEventHubRejectFabricShortcut -FabricShortcutName <String> -EventhubInputObject <IEventHubIdentity>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

### RejectViaIdentity
```
Invoke-AzEventHubRejectFabricShortcut -InputObject <IEventHubIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Rejects a Microsoft Fabric shortcut.

## EXAMPLES

### Example 1: Reject a Fabric shortcut on an EventHub entity
```powershell
Invoke-AzEventHubRejectFabricShortcut -ResourceGroupName contoso-rg -NamespaceName contoso-eventhub -EventHubName orders -FabricShortcutName orders-shortcut
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
ShortcutStatus             : Rejected
ShortcutType               : Entity
StatusDescription          : Rejected by the Event Hubs owner
Type                       : Microsoft.EventHub/namespaces/eventhubs/fabricShortcuts
```

Rejects the Fabric shortcut `orders-shortcut` on the EventHub entity `orders` in namespace `contoso-eventhub`, moving its status to `Rejected`.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Parameter Sets: RejectViaIdentityEventhub
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
Parameter Sets: Reject, RejectViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricShortcutName
The Microsoft Fabric shortcut name.

```yaml
Type: System.String
Parameter Sets: Reject, RejectViaIdentityNamespace, RejectViaIdentityEventhub
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
Parameter Sets: RejectViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: RejectViaIdentityNamespace
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
Parameter Sets: Reject
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
Parameter Sets: Reject
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
Parameter Sets: Reject
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
