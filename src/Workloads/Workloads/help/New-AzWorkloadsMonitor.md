---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/new-azworkloadsmonitor
schema: 2.0.0
---

# New-AzWorkloadsMonitor

## SYNOPSIS
Creates a SAP monitor for the specified subscription, resource group, and resource name.

## SYNTAX

```
New-AzWorkloadsMonitor -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AppLocation <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-LogAnalyticsWorkspaceArmId <String>] [-ManagedResourceGroupName <String>] [-MonitorSubnet <String>]
 [-RoutingPreference <RoutingPreference>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>]
 [-ZoneRedundancyPreference <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a SAP monitor for the specified subscription, resource group, and resource name.

## EXAMPLES

### Example 1: Creates a SAP monitor for the specified subscription, resource group, and resource name
```powershell
New-AzWorkloadsMonitor -Name suha-160323-ams4 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -Location eastus2euap -AppLocation eastus -ManagedResourceGroupName mrg-1603234 -MonitorSubnet /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/e2e-portal-wlmonitor-do-not-delete/providers/Microsoft.Network/virtualNetworks/vnetpeeringtest/subnets/snet-1603-3 -RoutingPreference RouteAll -ZoneRedundancyPreference Disabled
```

```output
Name             ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----             ----------------- ------------------------------------- --------    -----------------
suha-160323-ams4 suha-0802-rg1     mrg-1603234                           eastus2euap Succeeded
```

This command creates a SAP monitor for the specified subscription, resource group, and resource name.

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

### -IdentityType
Type of manage identity

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.RoutingPreference
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
Parameter Sets: (All)
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
User assigned identities dictionary

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IMonitor

## NOTES

ALIASES

## RELATED LINKS

