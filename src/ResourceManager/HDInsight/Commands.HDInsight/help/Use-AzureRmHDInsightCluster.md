---
external help file: Microsoft.Azure.Commands.HDInsight.dll-Help.xml
ms.assetid: 92E876FE-AA7B-43AA-915F-D02AC5CEF0CA
online version: 
schema: 2.0.0
---

# Use-AzureRmHDInsightCluster

## SYNOPSIS
Selects a cluster to be used with the Invoke-RmAzureHDInsightHiveJob cmdlet.

## SYNTAX

```
Use-AzureRmHDInsightCluster [-ClusterName] <String> [-HttpCredential] <PSCredential>
 [-ResourceGroupName <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Use-AzureRmHDInsightCluster** cmdlet selects the Azure HDInsight cluster for the Invoke-AzureRmHDInsightHiveJob cmdlet to use to submit Hive jobs.

## EXAMPLES

### Example 1: Select a cluster for Hive query submission
```
PS C:\># Cluster info
PS C:\>$clusterName = "your-hadoop-001"
PS C:\>$clusterCreds = Get-Credential

PS C:\>Use-AzureRmHDInsightCluster `
            -ClusterName $clusterName `
            -ClusterCredential $clusterCreds
```

This command selects a cluster for a Hive query submission.

## PARAMETERS

### -ClusterName
Specifies the name of the cluster.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpCredential
Specifies the cluster login (HTTP) credentials for the cluster.

```yaml
Type: PSCredential
Parameter Sets: (All)
Aliases: ClusterCredential

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmHDInsightCluster](./Get-AzureRmHDInsightCluster.md)

[Remove-AzureRmHDInsightCluster](./Remove-AzureRmHDInsightCluster.md)


