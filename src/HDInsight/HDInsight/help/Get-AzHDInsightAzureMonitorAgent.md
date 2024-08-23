---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://learn.microsoft.com/powershell/module/az.hdinsight/get-azhdinsightazuremonitoragent
schema: 2.0.0
---

# Get-AzHDInsightAzureMonitorAgent

## SYNOPSIS
Gets the azure monitor agent status of a specified HDInsight cluster.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzHDInsightAzureMonitorAgent [[-ResourceGroupName] <String>] [-ClusterName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzHDInsightAzureMonitorAgent [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByInputObjectParameterSet
```
Get-AzHDInsightAzureMonitorAgent [-InputObject] <AzureHDInsightCluster>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzHDInsightAzureMonitorAgent** cmdlet gets the azure monitor agent status of a specified HDInsight cluster.

## EXAMPLES

### Example 1
```powershell
# Cluster info
$clusterName = "your-hadoop-001"
$resourceGroupName = "Group"
Get-AzHDInsightAzureMonitorAgent -ClusterName $clusterName -ResourceGroupName $resourceGroupName
```

This cmdlet gets the azure monitor agent status of a specified HDInsight cluster.

### Example 2
```powershell
# Cluster info
$clusterName = "your-hadoop-001"
$cluster=Get-AzHDInsightCluster -ClusterName $clusterName
$cluster | Get-AzHDInsightAzureMonitorAgent
```

This cmdlet gets the azure monitor with pipeline.

## PARAMETERS

### -ClusterName
Gets or sets the name of the cluster.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Gets or sets the input object.

```yaml
Type: Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster
Parameter Sets: GetByInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Gets or sets the name of the resource group.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Gets or sets the resource id.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster

## OUTPUTS

### Microsoft.Azure.Commands.HDInsight.Models.Management.AzureHDInsightMonitoring

## NOTES

## RELATED LINKS

[Enable-AzHDInsightAzureMonitorAgent](./Enable-AzHDInsightAzureMonitorAgent.md)
[Disable-AzHDInsightAzureMonitorAgent](./Disable-AzHDInsightAzureMonitorAgent.md)
