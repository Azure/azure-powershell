---
external help file:
Module Name: Az.WorkloadMonitorApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.workloadmonitorapi/get-azworkloadmonitorapihealthmonitor
schema: 2.0.0
---

# Get-AzWorkloadMonitorApiHealthMonitor

## SYNOPSIS
Get the current health status of a monitor of a virtual machine.
Optional parameter: $expand (retrieve the monitor's evidence and configuration).

## SYNTAX

### List (Default)
```
Get-AzWorkloadMonitorApiHealthMonitor -ProviderName <String> -ResourceCollectionName <String>
 -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String[]>] [-Expand <String>]
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzWorkloadMonitorApiHealthMonitor -MonitorId <String> -ProviderName <String>
 -ResourceCollectionName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWorkloadMonitorApiHealthMonitor -InputObject <IWorkloadMonitorApiIdentity> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the current health status of a monitor of a virtual machine.
Optional parameter: $expand (retrieve the monitor's evidence and configuration).

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

### -Expand
Optionally expand the monitor’s evidence and/or configuration.
Example: $expand=evidence,configuration.

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

### -Filter
Optionally filter by monitor name.
Example: $filter=monitorName eq 'logical-disks|C:|disk-free-space-mb.'

```yaml
Type: System.String
Parameter Sets: List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WorkloadMonitorApi.Models.IWorkloadMonitorApiIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorId
The monitor Id of the virtual machine.

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

### -ProviderName
The provider name (ex: Microsoft.Compute for virtual machines).

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceCollectionName
The resource collection name (ex: virtualMachines for virtual machines).

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the virtual machine.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id of the virtual machine.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.WorkloadMonitorApi.Models.IWorkloadMonitorApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WorkloadMonitorApi.Models.Api20200113Preview.IHealthMonitor

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IWorkloadMonitorApiIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[MonitorId <String>]`: The monitor Id of the virtual machine.
  - `[ProviderName <String>]`: The provider name (ex: Microsoft.Compute for virtual machines).
  - `[ResourceCollectionName <String>]`: The resource collection name (ex: virtualMachines for virtual machines).
  - `[ResourceGroupName <String>]`: The resource group of the virtual machine.
  - `[ResourceName <String>]`: The name of the virtual machine.
  - `[SubscriptionId <String>]`: The subscription Id of the virtual machine.
  - `[TimestampUnix <String>]`: The timestamp of the state change (unix format).

## RELATED LINKS

