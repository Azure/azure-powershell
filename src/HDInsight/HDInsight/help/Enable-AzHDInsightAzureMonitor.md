---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://docs.microsoft.com/powershell/module/az.hdinsight/enable-azhdinsightazuremonitor
schema: 2.0.0
---

# Enable-AzHDInsightAzureMonitor

## SYNOPSIS
Enables Azure Monitor in a specified HDInsight cluster.

## SYNTAX

### EnableByNameParameterSet (Default)
```
Enable-AzHDInsightAzureMonitor [[-ResourceGroupName] <String>] [-ClusterName] <String> [-WorkspaceId] <String>
 [-PrimaryKey] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### EnableByResourceIdParameterSet
```
Enable-AzHDInsightAzureMonitor [-ResourceId] <String> [-WorkspaceId] <String> [-PrimaryKey] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### EnableByInputObjectParameterSet
```
Enable-AzHDInsightAzureMonitor [-InputObject] <AzureHDInsightCluster> [-WorkspaceId] <String>
 [-PrimaryKey] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet **Enable-AzHDInsightAzureMonitor** enables Azure Monitor in a specified HDInsight cluster.

## EXAMPLES

### Example 1
```powershell
PS C:\> # Cluster info
PS C:\> $clusterName = "your-hadoop-001"
PS C:\> $resourceGroupName = "Group"
PS C:\> $workspaceId = "your-workspace-id"
PS C:\> $primaryKey = "your-primary-key"
PS C:\> Enable-AzHDInsightAzureMonitor -ClusterName $clusterName -ResourceGroup $resourceGroupName -WorkspaceId $workspaceId -PrimaryKey $primaryKey
```

This cmdlet enables the azure monitor in a specified HDInsight cluster.

### Example 2
```powershell
PS C:\> # Cluster info
PS C:\> $clusterName = "your-hadoop-001"
PS C:\> $cluster=Get-AzHDInsightCluster -ClusterName $clusterName
PS C:\> $workspaceId = "your-workspace-id"
PS C:\> $primaryKey = "your-primary-key"
PS C:\> $cluster | Enable-AzHDInsightAzureMonitor -WorkspaceId $workspaceId -PrimaryKey $primaryKey
```

This cmdlet enables the azure monitor in a specified HDInsight cluster with pipeline.

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

[Disable-AzHDInsightAzureMonitor](./Disable-AzHDInsightAzureMonitor.md)
[Get-AzHDInsightAzureMonitor](./Get-AzHDInsightAzureMonitor.md)
