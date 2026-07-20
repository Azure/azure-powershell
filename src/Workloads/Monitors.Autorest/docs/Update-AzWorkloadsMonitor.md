---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/update-azworkloadsmonitor
schema: 2.0.0
---

# Update-AzWorkloadsMonitor

## SYNOPSIS
Update a SAP monitor for the specified subscription, resource group, and resource name.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWorkloadsMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AppLocation <String>] [-EnableSystemAssignedIdentity <Boolean?>] [-LogAnalyticsWorkspaceArmId <String>]
 [-ManagedResourceGroupName <String>] [-MonitorSubnet <String>] [-RoutingPreference <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-ZoneRedundancyPreference <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWorkloadsMonitor -InputObject <IMonitorsIdentity> [-AppLocation <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-LogAnalyticsWorkspaceArmId <String>]
 [-ManagedResourceGroupName <String>] [-MonitorSubnet <String>] [-RoutingPreference <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-ZoneRedundancyPreference <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a SAP monitor for the specified subscription, resource group, and resource name.

## EXAMPLES

### Example 1: Update AMS Monitor Instance
```powershell
Update-AzWorkloadsMonitor -MonitorName suha-160323-ams7 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -Tag @{name="tagValue"}
```

```output
Name             ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----             ----------------- ------------------------------------- --------    -----------------
suha-160323-ams7 suha-0802-rg1     mrg-16037                             eastus2euap Succeeded
```

Update AMS Monitor Instance

### Example 2: Update AMS Monitor Instance by Id
```powershell
Update-AzWorkloadsMonitor -InputObject "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/suha-160323-ams7" -Tag @{name="tagValue"}
```

```output

Name             ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----             ----------------- ------------------------------------- --------    -----------------
suha-160323-ams7 suha-0802-rg1     mrg-16037                             eastus2euap Succeeded
```

Update AMS Monitor Instance by Arm Id

## PARAMETERS

### -AppLocation
The SAP monitor resources will be deployed in the SAP monitoring region.
The subnet region should be same as the SAP monitoring region.

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

### -AsJob
Run the command as a job

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Monitors.Models.IMonitorsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LogAnalyticsWorkspaceArmId
The ARM ID of the Log Analytics Workspace that is used for SAP monitoring.

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

### -ManagedResourceGroupName
Managed resource group name

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

### -MonitorSubnet
The subnet which the SAP monitor will be deployed in

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

### -Name
Name of the SAP monitor resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: MonitorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -RoutingPreference
Sets the routing preference of the SAP monitor.
By default only RFC1918 traffic is routed to the customer VNET.

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
Resource tags.

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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneRedundancyPreference
Sets the preference for zone redundancy on resources created for the SAP monitor.
By default resources will be created which do not support zone redundancy.

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Monitors.Models.IMonitorsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Monitors.Models.IMonitor

## NOTES

## RELATED LINKS

