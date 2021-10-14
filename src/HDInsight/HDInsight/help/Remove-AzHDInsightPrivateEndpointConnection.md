---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://docs.microsoft.com/powershell/module/az.hdinsight/remove-azhdinsightprivateendpointconnection
schema: 2.0.0
---

# Remove-AzHDInsightPrivateEndpointConnection

## SYNOPSIS
Removes the specific private endpoint connection of the HDInsight cluster.

## SYNTAX

### RemoveByNameParameterSet (Default)
```
Remove-AzHDInsightPrivateEndpointConnection [[-ResourceGroupName] <String>] [-ClusterName] <String>
 [-PrivateEndpointConnectionName] <String> [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveByClusterResourceIdParameterSet
```
Remove-AzHDInsightPrivateEndpointConnection [-ClusterResourceId] <String>
 [-PrivateEndpointConnectionName] <String> [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveByClusterInputObjectParameterSet
```
Remove-AzHDInsightPrivateEndpointConnection [-ClusterInputObject] <AzureHDInsightCluster>
 [-PrivateEndpointConnectionName] <String> [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveByPrivateEndpointConnectionResourceIdParameterSet
```
Remove-AzHDInsightPrivateEndpointConnection [-ResourceId] <String> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet deletes **Remove-AzHDInsightPrivateEndpointConnection** the specific private endpoint connection of HDInsight cluster.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-AzHDInsightPrivateEndpointConnection -ClusterName testcluster -ResourceGroupName testrg -PrivateEndpointConnectionName "MyPrivateEndpointConncetion"
```

This cmdlet deletes the private endpoint connection "MyPrivateEndpointConnection" of the specific HDInsight cluster.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -ClusterInputObject
Gets or sets the cluster input object.

```yaml
Type: Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster
Parameter Sets: RemoveByClusterInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
Gets or sets the name of the cluster.

```yaml
Type: System.String
Parameter Sets: RemoveByNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterResourceId
Gets or sets the cluster resource id.

```yaml
Type: System.String
Parameter Sets: RemoveByClusterResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -PassThru
{{ Fill PassThru Description }}

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

### -PrivateEndpointConnectionName
Gets or sets the name of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: RemoveByNameParameterSet, RemoveByClusterResourceIdParameterSet, RemoveByClusterInputObjectParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Gets or sets the name of the resource group.

```yaml
Type: System.String
Parameter Sets: RemoveByNameParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Gets or sets the private endpoint connection resource id.

```yaml
Type: System.String
Parameter Sets: RemoveByPrivateEndpointConnectionResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightPrivateEndpointConnection

## NOTES

## RELATED LINKS
