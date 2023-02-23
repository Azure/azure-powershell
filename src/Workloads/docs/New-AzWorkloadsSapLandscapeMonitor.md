---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/new-azworkloadssaplandscapemonitor
schema: 2.0.0
---

# New-AzWorkloadsSapLandscapeMonitor

## SYNOPSIS
Creates a SAP Landscape Monitor Dashboard for the specified subscription, resource group, and resource name.

## SYNTAX

### CreateExpanded (Default)
```
New-AzWorkloadsSapLandscapeMonitor -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-GroupingLandscape <ISapLandscapeMonitorSidMapping[]>]
 [-GroupingSapApplication <ISapLandscapeMonitorSidMapping[]>]
 [-TopMetricsThreshold <ISapLandscapeMonitorMetricThresholds[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzWorkloadsSapLandscapeMonitor -MonitorName <String> -ResourceGroupName <String>
 -SapLandscapeMonitorParameter <ISapLandscapeMonitor> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzWorkloadsSapLandscapeMonitor -InputObject <IWorkloadsIdentity>
 -SapLandscapeMonitorParameter <ISapLandscapeMonitor> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzWorkloadsSapLandscapeMonitor -InputObject <IWorkloadsIdentity>
 [-GroupingLandscape <ISapLandscapeMonitorSidMapping[]>]
 [-GroupingSapApplication <ISapLandscapeMonitorSidMapping[]>]
 [-TopMetricsThreshold <ISapLandscapeMonitorMetricThresholds[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a SAP Landscape Monitor Dashboard for the specified subscription, resource group, and resource name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -GroupingLandscape
Gets or sets the list of landscape to SID mappings.
To construct, see NOTES section for GROUPINGLANDSCAPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapLandscapeMonitorSidMapping[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupingSapApplication
Gets or sets the list of Sap Applications to SID mappings.
To construct, see NOTES section for GROUPINGSAPAPPLICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapLandscapeMonitorSidMapping[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Name of the SAP monitor resource.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SapLandscapeMonitorParameter
configuration associated with SAP Landscape Monitor Dashboard.
To construct, see NOTES section for SAPLANDSCAPEMONITORPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapLandscapeMonitor
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopMetricsThreshold
Gets or sets the list Top Metric Thresholds for SAP Landscape Monitor Dashboard
To construct, see NOTES section for TOPMETRICSTHRESHOLD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapLandscapeMonitorMetricThresholds[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapLandscapeMonitor

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapLandscapeMonitor

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`GROUPINGLANDSCAPE <ISapLandscapeMonitorSidMapping[]>`: Gets or sets the list of landscape to SID mappings.
  - `[Name <String>]`: Gets or sets the name of the grouping.
  - `[TopSid <String[]>]`: Gets or sets the list of SID's.

`GROUPINGSAPAPPLICATION <ISapLandscapeMonitorSidMapping[]>`: Gets or sets the list of Sap Applications to SID mappings.
  - `[Name <String>]`: Gets or sets the name of the grouping.
  - `[TopSid <String[]>]`: Gets or sets the list of SID's.

`INPUTOBJECT <IWorkloadsIdentity>`: Identity Parameter
  - `[ApplicationInstanceName <String>]`: The name of SAP Application Server instance resource.
  - `[CentralInstanceName <String>]`: Central Services Instance resource name string modeled as parameter for auto generation to work correctly.
  - `[DatabaseInstanceName <String>]`: Database resource name string modeled as parameter for auto generation to work correctly.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[MonitorName <String>]`: Name of the SAP monitor resource.
  - `[ProviderInstanceName <String>]`: Name of the provider instance.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SapVirtualInstanceName <String>]`: The name of the Virtual Instances for SAP solutions resource
  - `[SubscriptionId <String>]`: The ID of the target subscription.

`SAPLANDSCAPEMONITORPARAMETER <ISapLandscapeMonitor>`: configuration associated with SAP Landscape Monitor Dashboard.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[GroupingLandscape <ISapLandscapeMonitorSidMapping[]>]`: Gets or sets the list of landscape to SID mappings.
    - `[Name <String>]`: Gets or sets the name of the grouping.
    - `[TopSid <String[]>]`: Gets or sets the list of SID's.
  - `[GroupingSapApplication <ISapLandscapeMonitorSidMapping[]>]`: Gets or sets the list of Sap Applications to SID mappings.
  - `[TopMetricsThreshold <ISapLandscapeMonitorMetricThresholds[]>]`: Gets or sets the list Top Metric Thresholds for SAP Landscape Monitor Dashboard
    - `[Green <Single?>]`: Gets or sets the threshold value for Green.
    - `[Name <String>]`: Gets or sets the name of the threshold.
    - `[Red <Single?>]`: Gets or sets the threshold value for Red.
    - `[Yellow <Single?>]`: Gets or sets the threshold value for Yellow.

`TOPMETRICSTHRESHOLD <ISapLandscapeMonitorMetricThresholds[]>`: Gets or sets the list Top Metric Thresholds for SAP Landscape Monitor Dashboard
  - `[Green <Single?>]`: Gets or sets the threshold value for Green.
  - `[Name <String>]`: Gets or sets the name of the threshold.
  - `[Red <Single?>]`: Gets or sets the threshold value for Red.
  - `[Yellow <Single?>]`: Gets or sets the threshold value for Yellow.

## RELATED LINKS

