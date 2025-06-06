---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version:
schema: 2.0.0
---

# Get-AzHDInsightClusterGatewayEntraUserInfo

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### GetByNameParameterSet
```
Get-AzHDInsightClusterGatewayEntraUserInfo [[-ResourceGroupName] <String>] [-ClusterName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzHDInsightClusterGatewayEntraUserInfo [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SetByInputObjectParameterSet
```
Get-AzHDInsightClusterGatewayEntraUserInfo [-DefaultProfile <IAzureContextContainer>]
 -InputObject <AzureHDInsightCluster> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ClusterName
Gets or sets the name of the cluster.

```yaml
Type: String
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
Type: IAzureContextContainer
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
Type: AzureHDInsightCluster
Parameter Sets: SetByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
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
Type: String
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
Type: String
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

### Microsoft.Azure.Management.HDInsight.Models.EntraUserInfo

## NOTES

## RELATED LINKS
