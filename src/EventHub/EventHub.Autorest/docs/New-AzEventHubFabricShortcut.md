---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/new-azeventhubfabricshortcut
schema: 2.0.0
---

# New-AzEventHubFabricShortcut

## SYNOPSIS
Create a Microsoft Fabric shortcut.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEventHubFabricShortcut -EventHubName <String> -Name <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ConfigurationArtifactId <String>]
 [-ConfigurationArtifactName <String>] [-ConfigurationLogAnalyticsResourceId <String>]
 [-ConfigurationPremiumCapacityId <String>] [-ConfigurationTenantId <String>]
 [-ConfigurationWorkspaceId <String>] [-ConfigurationWorkspaceName <String>] [-ShortcutStatus <String>]
 [-ShortcutType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityEventhub
```
New-AzEventHubFabricShortcut -EventhubInputObject <IEventHubIdentity> -Name <String>
 -Resource <IFabricShortcut> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityEventhubExpanded
```
New-AzEventHubFabricShortcut -EventhubInputObject <IEventHubIdentity> -Name <String>
 [-ConfigurationArtifactId <String>] [-ConfigurationArtifactName <String>]
 [-ConfigurationLogAnalyticsResourceId <String>] [-ConfigurationPremiumCapacityId <String>]
 [-ConfigurationTenantId <String>] [-ConfigurationWorkspaceId <String>] [-ConfigurationWorkspaceName <String>]
 [-ShortcutStatus <String>] [-ShortcutType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityNamespace
```
New-AzEventHubFabricShortcut -EventHubName <String> -Name <String> -NamespaceInputObject <IEventHubIdentity>
 -Resource <IFabricShortcut> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityNamespaceExpanded
```
New-AzEventHubFabricShortcut -EventHubName <String> -Name <String> -NamespaceInputObject <IEventHubIdentity>
 [-ConfigurationArtifactId <String>] [-ConfigurationArtifactName <String>]
 [-ConfigurationLogAnalyticsResourceId <String>] [-ConfigurationPremiumCapacityId <String>]
 [-ConfigurationTenantId <String>] [-ConfigurationWorkspaceId <String>] [-ConfigurationWorkspaceName <String>]
 [-ShortcutStatus <String>] [-ShortcutType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Microsoft Fabric shortcut.

## EXAMPLES

### Example 1: Create a Fabric shortcut on an EventHub entity
```powershell
New-AzEventHubFabricShortcut -ResourceGroupName contoso-rg -NamespaceName contoso-eventhub -EventHubName orders -Name orders-shortcut -ShortcutType Entity -ConfigurationArtifactId "33333333-3333-3333-3333-333333333333" -ConfigurationArtifactName "orders-eventstream" -ConfigurationPremiumCapacityId "44444444-4444-4444-4444-444444444444" -ConfigurationTenantId "11111111-1111-1111-1111-111111111111" -ConfigurationWorkspaceId "22222222-2222-2222-2222-222222222222" -ConfigurationWorkspaceName "contoso-workspace"
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
ModifiedAt                     : 7/1/2026 12:00:00 PM
Name                           : orders-shortcut
ShortcutStatus                 : Pending
ShortcutType                   : Entity
StatusDescription              : Pending approval
Type                           : Microsoft.EventHub/namespaces/eventhubs/fabricShortcuts
```

Creates a new Fabric shortcut `orders-shortcut` of type `Entity` on the EventHub entity `orders` in namespace `contoso-eventhub`.

## PARAMETERS

### -ConfigurationArtifactId
The Microsoft Fabric artifact ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEventhubExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationArtifactName
The Microsoft Fabric artifact name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEventhubExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationLogAnalyticsResourceId
The resource ID of the Log Analytics workspace.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEventhubExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationPremiumCapacityId
The Microsoft Fabric premium capacity ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEventhubExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationTenantId
The Microsoft Fabric tenant ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEventhubExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationWorkspaceId
The Microsoft Fabric workspace ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEventhubExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationWorkspaceName
The Microsoft Fabric workspace name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEventhubExpanded, CreateViaIdentityNamespaceExpanded
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
Parameter Sets: CreateViaIdentityEventhub, CreateViaIdentityEventhubExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityNamespace, CreateViaIdentityNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The Microsoft Fabric shortcut name.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateViaIdentityNamespace, CreateViaIdentityNamespaceExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
A Microsoft Fabric shortcut attached to an Event Hub.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IFabricShortcut
Parameter Sets: CreateViaIdentityEventhub, CreateViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShortcutStatus
The current shortcut status.
Only Pending can be supplied on create or update.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEventhubExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShortcutType
The type of the shortcut.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEventhubExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IFabricShortcut

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IFabricShortcut

## NOTES

## RELATED LINKS

