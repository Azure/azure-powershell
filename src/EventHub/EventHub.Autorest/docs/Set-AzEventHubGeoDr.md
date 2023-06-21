---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/set-azeventhubgeodr
schema: 2.0.0
---

# Set-AzEventHubGeoDr

## SYNOPSIS
GeoDR Failover

## SYNTAX

### FailoverExpanded (Default)
```
Set-AzEventHubGeoDr -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-MaximumGracePeriodInMin <Int32>] [-PrimaryLocation <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Failover
```
Set-AzEventHubGeoDr -NamespaceName <String> -ResourceGroupName <String> -Parameter <IFailOver>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
GeoDR Failover

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

### -MaximumGracePeriodInMin
Maximum time duration allowed complete data replication from primary to secondary.
Use maximumGracePeriodInMins = 0: For Unplanned Geo-Failover, which switches the role between primary and secondary immediately.
The data that is not being replicated yet will be discarded.
Use maximumGracePeriodInMins \> 0: For Planned Geo-Failover/DR Drill, continue replicating data until grace period expires.
Any data that is not replicated during the grace period will be discarded.
During the replication the namespace stops accepting any new publishing requests

```yaml
Type: System.Int32
Parameter Sets: FailoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The Namespace name

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

### -Parameter
.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202301Preview.IFailOver
Parameter Sets: Failover
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrimaryLocation
Query parameter for the new primary location after failover.

```yaml
Type: System.String
Parameter Sets: FailoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group within the azure subscription.

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
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202301Preview.IFailOver

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202301Preview.IEhNamespace

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PARAMETER <IFailOver>`: .
  - `[MaximumGracePeriodInMin <Int32?>]`: Maximum time duration allowed complete data replication from primary to secondary. Use maximumGracePeriodInMins = 0: For Unplanned Geo-Failover, which switches the role between primary and secondary immediately. The data that is not being replicated yet will be discarded. Use maximumGracePeriodInMins > 0: For Planned Geo-Failover/DR Drill, continue replicating data until grace period expires.  Any data that is not replicated during the grace period will be discarded. During the replication the namespace stops accepting any new publishing requests
  - `[PrimaryLocation <String>]`: Query parameter for the new primary location after failover.

## RELATED LINKS

