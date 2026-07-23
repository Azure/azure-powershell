---
external help file: Az.Workloads-help.xml
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/get-azworkloadsmonitor
schema: 2.0.0
---

# Get-AzWorkloadsMonitor

## SYNOPSIS
Gets properties of a SAP monitor for the specified subscription, resource group, and resource name.

## SYNTAX

### List (Default)
```
Get-AzWorkloadsMonitor [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzWorkloadsMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzWorkloadsMonitor -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWorkloadsMonitor -InputObject <IMonitorsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a SAP monitor for the specified subscription, resource group, and resource name.

## EXAMPLES

### EXAMPLE 1
```
Get-AzWorkloadsMonitor
```

### EXAMPLE 2
```
Get-AzWorkloadsMonitor -ResourceGroupName ad-ams-rg
```

### EXAMPLE 3
```
Get-AzWorkloadsMonitor -ResourceGroupName ad-ams-rg -Name ad-ams
```

### EXAMPLE 4
```
Get-AzWorkloadsMonitor -InputObject '/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/suha-1606-ams2'
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
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

```yaml
Type: IMonitorsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the SAP monitor resource.

```yaml
Type: String
Parameter Sets: Get
Aliases: MonitorName

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
Type: String
Parameter Sets: Get, List1
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
Type: String[]
Parameter Sets: List, Get, List1
Aliases:

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
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IMonitorsIdentity\>: Identity Parameter
  \[Id \<String\>\]: Resource identity path
  \[MonitorName \<String\>\]: Name of the SAP monitor resource.
  \[ProviderInstanceName \<String\>\]: Name of the provider instance.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.workloads/get-azworkloadsmonitor](https://learn.microsoft.com/powershell/module/az.workloads/get-azworkloadsmonitor)
