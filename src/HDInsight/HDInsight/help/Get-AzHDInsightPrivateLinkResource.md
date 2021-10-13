---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://docs.microsoft.com/powershell/module/az.hdinsight/get-azhdinsightprivatelinkresource
schema: 2.0.0
---

# Get-AzHDInsightPrivateLinkResource

## SYNOPSIS
Gets the private link resources of the HDInsight cluster.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzHDInsightPrivateLinkResource [[-ResourceGroupName] <String>] [-ClusterName] <String>
 [[-PrivateLinkResourceName] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByClusterResourceIdParameterSet
```
Get-AzHDInsightPrivateLinkResource [-ClusterResourceId] <String> [[-PrivateLinkResourceName] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByClusterInputObjectParameterSet
```
Get-AzHDInsightPrivateLinkResource [-ClusterInputObject] <AzureHDInsightCluster>
 [[-PrivateLinkResourceName] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByPrivateLinkResourceIdParameterSet
```
Get-AzHDInsightPrivateLinkResource [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
This cmdlet **Get-AzHDInsightPrivateLinkResource** gets all the private link resource or a specifc private link resource if parameter `-PrivateLinkResourceName` is set of the HDInsight cluster.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzHDInsightPrivateLinkResource -ClusterName testcluster -ResourceGroupName testrg
```

This cmdlet will return all the private link resources of the HDInsight cluster.

### Example 2
```powershell
PS C:\> Get-AzHDInsightPrivateLinkResource -ClusterName testcluster -ResourceGroupName testrg -PrivateLinkResourceName "MyPrivateLinkResource"
```

This cmdlet will return the private link resource named "MyPrivateLinkResource" of the HDInsight cluster.

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

### -PrivateLinkResourceName
Gets or sets the name of the private link resources.

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
Gets or sets the private link resource id.

```yaml
Type: System.String
Parameter Sets: GetByPrivateLinkResourceIdParameterSet
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

### Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightPrivateLinkResource

## NOTES

## RELATED LINKS
