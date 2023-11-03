---
external help file:
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/get-azkustoclusteroutboundnetworkdependencyendpoint
schema: 2.0.0
---

# Get-AzKustoClusterOutboundNetworkDependencyEndpoint

## SYNOPSIS
Gets the network endpoints of all outbound dependencies of a Kusto cluster

## SYNTAX

```
Get-AzKustoClusterOutboundNetworkDependencyEndpoint -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the network endpoints of all outbound dependencies of a Kusto cluster

## EXAMPLES

### Example 1: List all Kusto ManagedPrivateEndpoint in a cluster
```powershell
Get-AzKustoClusterOutboundNetworkDependencyEndpoint -ClusterName "mycluster" -ResourceGroupName "testrg"
```

```output
Name                                     Type                                                          Etag
----                                     ----                                                          ----
mycluster/AzureActiveDirectory           Microsoft.Kusto/Clusters/OutboundNetworkDependenciesEndpoints
mycluster/AzureMonitor                   Microsoft.Kusto/Clusters/OutboundNetworkDependenciesEndpoints
mycluster/CertificateAuthority           Microsoft.Kusto/Clusters/OutboundNetworkDependenciesEndpoints
mycluster/AzureStorage                   Microsoft.Kusto/Clusters/OutboundNetworkDependenciesEndpoints
```

The above command returns all Kusto OutboundNetworkDependenciesEndpoints in the cluster "mycluster" found in the resource group "testrg".

## PARAMETERS

### -ClusterName
The name of the Kusto cluster.

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
The name of the resource group containing the Kusto cluster.

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
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20221229.IOutboundNetworkDependenciesEndpoint

## NOTES

ALIASES

## RELATED LINKS

