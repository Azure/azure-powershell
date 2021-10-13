---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://docs.microsoft.com/powershell/module/az.hdinsight/get-azhdinsightprivateendpointconnection
schema: 2.0.0
---

# Get-AzHDInsightPrivateEndpointConnection

## SYNOPSIS
Gets the private endpoint connections of the HDInsight cluster.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzHDInsightPrivateEndpointConnection [[-ResourceGroupName] <String>] [-ClusterName] <String>
 [[-PrivateEndpointConnectionName] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByClusterResourceIdParameterSet
```
Get-AzHDInsightPrivateEndpointConnection [-ClusterResourceId] <String>
 [[-PrivateEndpointConnectionName] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByClusterInputObjectParameterSet
```
Get-AzHDInsightPrivateEndpointConnection [-ClusterInputObject] <AzureHDInsightCluster>
 [[-PrivateEndpointConnectionName] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByPrivateEndpointConnectionResourceIdParameterSet
```
Get-AzHDInsightPrivateEndpointConnection [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzHDInsightPrivateEndpointConnection** gets the private endpoint connections or a specific private endpoint connection if the `-PrivateEndpointConnectionName` is set.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzHDInsightPrivateEndpointConnection -ClusterName testcluster -ResourceGroupName testrg
```

This cmdlet will return all the private endpoint connections of the HDInsight cluster.

### Example 2
```powershell
PS C:\> Get-AzHDInsightPrivateEndpointConnection -ClusterName testcluster -ResourceGroupName testrg -PrivateEndpointConnectionName "MyPrivateEndpointConnection"
```

This cmdlet will return the private endpoint connection named "MyPrivateEndpointConnection" of the HDInsight cluster.

## PARAMETERS

### -ClusterInputObject
Gets or sets the cluster input object.

```yaml
Type: Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster
Parameter Sets: GetByClusterInputObjectParameterSet
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
Parameter Sets: GetByNameParameterSet
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
Parameter Sets: GetByClusterResourceIdParameterSet
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

### -PrivateEndpointConnectionName
Gets or sets the name of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet, GetByClusterResourceIdParameterSet, GetByClusterInputObjectParameterSet
Aliases:

Required: False
Position: 2
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
Gets or sets the private endpoint connection resource id.

```yaml
Type: System.String
Parameter Sets: GetByPrivateEndpointConnectionResourceIdParameterSet
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

### Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightPrivateEndpointConnection

## NOTES

## RELATED LINKS
