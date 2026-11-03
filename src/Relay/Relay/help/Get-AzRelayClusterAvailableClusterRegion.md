---
external help file: Az.Relay-help.xml
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/get-azrelayclusteravailableclusterregion
schema: 2.0.0
---

# Get-AzRelayClusterAvailableClusterRegion

## SYNOPSIS
Lists regions containing available pre-provisioned Relay clusters.

## SYNTAX

```
Get-AzRelayClusterAvailableClusterRegion [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists regions containing available pre-provisioned Relay clusters.

## EXAMPLES

### Example 1: List regions with available Relay dedicated cluster capacity
```powershell
Get-AzRelayClusterAvailableClusterRegion
```

```output
Location
--------
East US
West US
North Europe
```

The cmdlet lists the regions that currently have capacity available for creating a Relay dedicated cluster.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IAvailableRelayClustersList

## NOTES

## RELATED LINKS
