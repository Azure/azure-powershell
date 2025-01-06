---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/get-azworkloadssaplandscapemonitor
schema: 2.0.0
---

# Get-AzWorkloadsSapLandscapeMonitor

## SYNOPSIS
Gets configuration values for Single Pane Of Glass for SAP monitor for the specified subscription, resource group, and resource name.

## SYNTAX

### Get (Default)
```
Get-AzWorkloadsSapLandscapeMonitor -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWorkloadsSapLandscapeMonitor -InputObject <IWorkloadsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets configuration values for Single Pane Of Glass for SAP monitor for the specified subscription, resource group, and resource name.

## EXAMPLES

### Example 1: Get information about a SAP landscape monitor
```powershell
Get-AzWorkloadsSapLandscapeMonitor -MonitorName suha-0202-ams9 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c
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
                               }
SystemDataCreatedAt          : 06-04-2023 05:30:54
SystemDataCreatedByType      : User
SystemDataLastModifiedByType : User
TopMetricsThreshold          : {{
                                 "name": "Instance Availability",
                                 "green": 90,
                                 "yellow": 75,
                                 "red": 50
                               }}
Type                         : microsoft.workloads/monitors/saplandscapemonitor
```

Gets information about a specific SAP landscape monitor

### Example 2: Get information about a SAP landscape monitor by Id
```powershell
Get-AzWorkloadsSapLandscapeMonitor -InputObject "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0/providers/Microsoft.Workloads/monitors/suha-0202-ams9/sapLandscapeMonitor/default"
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
                               }
SystemDataCreatedAt          : 06-04-2023 05:30:54
SystemDataCreatedByType      : User
SystemDataLastModifiedByType : User
TopMetricsThreshold          : {{
                                 "name": "Instance Availability",
                                 "green": 90,
                                 "yellow": 75,
                                 "red": 50
                               }}
Type                         : microsoft.workloads/monitors/saplandscapemonitor
```

Gets information about a specific SAP landscape monitor by ArmId

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get
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
Parameter Sets: Get
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapLandscapeMonitor

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


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

## RELATED LINKS

