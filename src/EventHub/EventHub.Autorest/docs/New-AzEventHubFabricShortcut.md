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

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

