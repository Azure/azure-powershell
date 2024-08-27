---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://learn.microsoft.com/powershell/module/az.hdinsight/enable-azhdinsightazuremonitoragent
schema: 2.0.0
---

# Enable-AzHDInsightAzureMonitorAgent

## SYNOPSIS
Enables Azure Monitor Agent in a specified HDInsight cluster.

## SYNTAX

### EnableByNameParameterSet (Default)
```
Enable-AzHDInsightAzureMonitorAgent [-PassThru] [[-ResourceGroupName] <String>] [-ClusterName] <String>
 [-WorkspaceId] <String> [-PrimaryKey] <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### EnableByResourceIdParameterSet
```
Enable-AzHDInsightAzureMonitorAgent [-PassThru] [-ResourceId] <String> [-WorkspaceId] <String>
 [-PrimaryKey] <String> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### EnableByInputObjectParameterSet
```
Enable-AzHDInsightAzureMonitorAgent [-PassThru] [-InputObject] <AzureHDInsightCluster> [-WorkspaceId] <String>
 [-PrimaryKey] <String> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet **Enable-AzHDInsightAzureMonitorAgent** enables Azure Monitor Agent in a specified HDInsight cluster.

## EXAMPLES

### Example 1
```powershell
# Cluster info
$clusterName = "your-hadoop-001"
$resourceGroupName = "Group"
$workspaceId = "your-workspace-id"
$primaryKey = "your-primary-key"
Enable-AzHDInsightAzureMonitorAgent -ClusterName $clusterName -ResourceGroupName $resourceGroupName -WorkspaceId $workspaceId -PrimaryKey $primaryKey
```

This cmdlet enables the azure monitor in a specified HDInsight cluster.

### Example 2
```powershell
# Cluster info
$clusterName = "your-hadoop-001"
$cluster=Get-AzHDInsightCluster -ClusterName $clusterName
$workspaceId = "your-workspace-id"
$primaryKey = "your-primary-key"
$cluster | Enable-AzHDInsightAzureMonitorAgent -WorkspaceId $workspaceId -PrimaryKey $primaryKey
```

This cmdlet enables the azure monitor agent in a specified HDInsight cluster with pipeline.

## PARAMETERS

### -ClusterName
Gets or sets the name of the cluster.

```yaml
Type: System.String
Parameter Sets: EnableByNameParameterSet
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
Parameter Sets: EnableByInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Return the result of the operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryKey
Gets to sets the primary key of the Log Analytics workspace.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
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
Parameter Sets: EnableByNameParameterSet
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
Parameter Sets: EnableByResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceId
Gets or sets the ID of the Log Analytics workspace.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
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

### System.String

### Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Disable-AzHDInsightAzureMonitorAgent](./Disable-AzHDInsightAzureMonitorAgent.md)
[Get-AzHDInsightAzureMonitorAgent](./Get-AzHDInsightAzureMonitorAgent.md)
