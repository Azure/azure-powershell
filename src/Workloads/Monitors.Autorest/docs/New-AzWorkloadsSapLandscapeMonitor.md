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

```
New-AzWorkloadsSapLandscapeMonitor -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-GroupingLandscape <ISapLandscapeMonitorSidMapping[]>]
 [-GroupingSapApplication <ISapLandscapeMonitorSidMapping[]>]
 [-TopMetricsThreshold <ISapLandscapeMonitorMetricThresholds[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a SAP Landscape Monitor Dashboard for the specified subscription, resource group, and resource name.

## EXAMPLES

### Example 1: Create a new SAP Landscape Monitor
```powershell
New-AzWorkloadsSapLandscapeMonitor -MonitorName suha-0202-ams9 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -GroupingLandscape '{"name":"Prod","topSid":["SID1","SID2"]}' -GroupingSapApplication '{"name":"ERP1","topSid":["SID1","SID2"]}' -TopMetricsThreshold '{"name":"Instance Availability","green":90,"yellow":75,"red":50}'
```

```output
GroupingLandscape            : {{
                                 "name": "Prod",
                                 "topSid": [ "SID1", "SID2" ]
                               }}
GroupingSapApplication       : {{
                                 "name": "ERP1",
                                 "topSid": [ "SID1", "SID2" ]
                               }}
Id                           : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.
                               Workloads/monitors/suha-0202-ams9/sapLandscapeMonitor/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : suha-0802-rg1
SystemData                   : {
                                 "createdBy": "",
                                 "createdByType": "User",
                                 "createdAt": "2023-04-06T05:30:54.9427030Z",
                                 "lastModifiedBy": "",
                                 "lastModifiedByType": "User",
                                 "lastModifiedAt": "2023-04-06T05:31:18.7873209Z"
                               }
SystemDataCreatedAt          : 06-04-2023 05:30:54
SystemDataCreatedBy          : 
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 06-04-2023 05:31:18
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : User
TopMetricsThreshold          : {{
                                 "name": "Instance Availability",
                                 "green": 90,
                                 "yellow": 75,
                                 "red": 50
                               }}
Type                         : microsoft.workloads/monitors/saplandscapemonitor
```

Creates a new SAP landscape monitor

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

### -GroupingLandscape
Gets or sets the list of landscape to SID mappings.
To construct, see NOTES section for GROUPINGLANDSCAPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapLandscapeMonitorSidMapping[]
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorName
Name of the SAP monitor resource.

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

### -TopMetricsThreshold
Gets or sets the list Top Metric Thresholds for SAP Landscape Monitor Dashboard
To construct, see NOTES section for TOPMETRICSTHRESHOLD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapLandscapeMonitorMetricThresholds[]
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

`TOPMETRICSTHRESHOLD <ISapLandscapeMonitorMetricThresholds[]>`: Gets or sets the list Top Metric Thresholds for SAP Landscape Monitor Dashboard
  - `[Green <Single?>]`: Gets or sets the threshold value for Green.
  - `[Name <String>]`: Gets or sets the name of the threshold.
  - `[Red <Single?>]`: Gets or sets the threshold value for Red.
  - `[Yellow <Single?>]`: Gets or sets the threshold value for Yellow.

## RELATED LINKS

