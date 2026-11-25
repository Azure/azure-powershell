---
external help file: Az.Relay-help.xml
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/get-azrelayclusternamespace
schema: 2.0.0
---

# Get-AzRelayClusterNamespace

## SYNOPSIS
Lists Relay namespace resource IDs assigned to a Relay cluster.

## SYNTAX

```
Get-AzRelayClusterNamespace -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists Relay namespace resource IDs assigned to a Relay cluster.

## EXAMPLES

### Example 1: List the namespaces assigned to a Relay dedicated cluster
```powershell
Get-AzRelayClusterNamespace -ResourceGroupName lucas-relay-rg -ClusterName relaycluster01
```

```output
Id
--
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace-pwsh01
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace-pwsh02
```

The cmdlet lists the Relay namespaces currently assigned to the specified dedicated cluster.

## PARAMETERS

### -ClusterName
The name of the Relay cluster.

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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IRelayNamespaceIdListResult

## NOTES

## RELATED LINKS
