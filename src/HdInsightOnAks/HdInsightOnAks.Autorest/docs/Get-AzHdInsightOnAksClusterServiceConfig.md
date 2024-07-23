---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/get-azhdinsightonaksclusterserviceconfig
schema: 2.0.0
---

# Get-AzHdInsightOnAksClusterServiceConfig

## SYNOPSIS
Lists the config dump of all services running in cluster.

## SYNTAX

```
Get-AzHdInsightOnAksClusterServiceConfig -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the config dump of all services running in cluster.

## EXAMPLES

### Example 1: Lists the config dump of all services running in cluster.
```powershell
$clusterResourceGroupName = "your-resourceGroup"
$clusterpoolName = "your-clusterpool"
$clusterName = "your-clustername"
Get-AzHdInsightOnAksClusterServiceConfig -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName
```

```output
ComponentName : flink-configs
Content       :
CustomKey     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesCustomKe
                ys
DefaultKey    : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesDefaultK
                eys
FileName      : flink-conf.yaml
Path          :
ServiceName   : flink-operator
Type          : key-value

ComponentName : flink-configs
Content       :
CustomKey     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesCustomKe
                ys
DefaultKey    : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesDefaultK
                eys
FileName      : log4j-console.properties
Path          :
ServiceName   : flink-operator
Type          : key-value

ComponentName : hadoop-configs
Content       :
CustomKey     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesCustomKe
                ys
DefaultKey    : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesDefaultK
                eys
FileName      : core-site.xml
Path          :
ServiceName   : flink-operator
Type          : key-value

ComponentName : flink-client-configs
Content       :
CustomKey     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesCustomKe
                ys
DefaultKey    : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesDefaultK
                eys
FileName      : flink-conf.yaml
Path          :
ServiceName   : flink-operator
Type          : key-value
```

Lists the config dump of all services running in a flink cluster.

## PARAMETERS

### -ClusterName
The name of the HDInsight cluster.

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

### -ClusterPoolName
The name of the cluster pool.

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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IServiceConfigResult

## NOTES

## RELATED LINKS

