---
external help file: Az.Dashboard-help.xml
Module Name: Az.Dashboard
online version: https://learn.microsoft.com/powershell/module/az.dashboard/update-azgrafana
schema: 2.0.0
---

# Update-AzGrafana

## SYNOPSIS
Update a workspace for Grafana resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzGrafana -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-ApiKey <ApiKey>]
 [-DeterministicOutboundIP <DeterministicOutboundIP>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>]
 [-MonitorWorkspaceIntegration <IAzureMonitorWorkspaceIntegration[]>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-Tag <Hashtable>] [-ZoneRedundancy <ZoneRedundancy>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzGrafana -InputObject <IDashboardIdentity> [-ApiKey <ApiKey>]
 [-DeterministicOutboundIP <DeterministicOutboundIP>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>]
 [-MonitorWorkspaceIntegration <IAzureMonitorWorkspaceIntegration[]>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-Tag <Hashtable>] [-ZoneRedundancy <ZoneRedundancy>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a workspace for Grafana resource.

## EXAMPLES

### Example 1: Update a workspace for Grafana resource.
```powershell
Update-AzGrafana -GrafanaName azpstest-grafana -ResourceGroupName azpstest-gp -ApiKey Enabled -DeterministicOutboundIP 'Enabled' -IdentityType 'SystemAssigned' -PublicNetworkAccess 'Enabled' -ZoneRedundancy 'Enabled' -Tag @{"Environment"="Dev"}
```

```output
Location Name             ResourceGroupName
-------- ----             -----------------
eastus   azpstest-grafana azpstest-gp
```

Update a workspace for Grafana resource.

### Example 2: Update a workspace for Grafana resource.
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp -GrafanaName azpstest-grafana | Update-AzGrafana -ApiKey Enabled -DeterministicOutboundIP 'Enabled' -IdentityType 'SystemAssigned' -PublicNetworkAccess 'Enabled' -ZoneRedundancy 'Enabled' -Tag @{"Environment"="Dev"}
```

```output
Location Name             ResourceGroupName
-------- ----             -----------------
eastus   azpstest-grafana azpstest-gp
```

Update a workspace for Grafana resource.

## PARAMETERS

### -ApiKey
The api key setting of the Grafana instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.ApiKey
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

### -DeterministicOutboundIP
Whether a Grafana instance uses deterministic outbound IPs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.DeterministicOutboundIP
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorWorkspaceIntegration
The MonitorWorkspaceIntegration of Azure Managed Grafana.
To construct, see NOTES section for MONITORWORKSPACEINTEGRATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.Api20220801.IAzureMonitorWorkspaceIntegration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The workspace name of Azure Managed Grafana.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: GrafanaName

Required: True
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

### -PublicNetworkAccess
Indicate the state for enable or disable traffic over the public interface.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.PublicNetworkAccess
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The new tags of the grafana resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneRedundancy
The zone redundancy setting of the Grafana instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.ZoneRedundancy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.Api20220801.IManagedGrafana

## NOTES

## RELATED LINKS
