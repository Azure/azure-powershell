---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://docs.microsoft.com/powershell/module/az.hdinsight/set-azhdinsightprivateendpointconnection
schema: 2.0.0
---

# Set-AzHDInsightPrivateEndpointConnection

## SYNOPSIS
Sets the specific private endpoint connection status: Aproved or Rejected.

## SYNTAX

### SetByNameParameterSet (Default)
```
Set-AzHDInsightPrivateEndpointConnection [[-ResourceGroupName] <String>] [-ClusterName] <String>
 [-PrivateEndpointConnectionName] <String> [-PrivateLinkServiceConnectionState] <String>
 [[-Description] <String>] [[-ActionsRequired] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### SetByClusterResourceIdParameterSet
```
Set-AzHDInsightPrivateEndpointConnection [-ClusterResourceId] <String>
 [-PrivateEndpointConnectionName] <String> [-PrivateLinkServiceConnectionState] <String>
 [[-Description] <String>] [[-ActionsRequired] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### SetByClusterInputObjectParameterSet
```
Set-AzHDInsightPrivateEndpointConnection [-ClusterInputObject] <AzureHDInsightCluster>
 [-PrivateEndpointConnectionName] <String> [-PrivateLinkServiceConnectionState] <String>
 [[-Description] <String>] [[-ActionsRequired] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### SetByPrivateEndpointConnectionResourceIdParameterSet
```
Set-AzHDInsightPrivateEndpointConnection [-ResourceId] <String> [-PrivateLinkServiceConnectionState] <String>
 [[-Description] <String>] [[-ActionsRequired] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
This cmdlet **Set-AzHDInsightPrivateEndpointConnection** sets the private endpoint connection status: Approved or Rejected.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-AzHDInsightPrivateEndpointConnection -ClusterName testcluster -ResourceGroupName testrg -PrivateEndpointConnectionName "MyPrivateEndpointConnection" -PrivateLinkServiceConnectionState "Rejected"
```

This cmdlet rejects the private endpoint connection by setting its status to "Rejected".

## PARAMETERS

### -ActionsRequired
Gets or sets the actions required when setting the connection status of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterInputObject
Gets or sets the cluster input object.

```yaml
Type: Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster
Parameter Sets: SetByClusterInputObjectParameterSet
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
Parameter Sets: SetByNameParameterSet
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
Parameter Sets: SetByClusterResourceIdParameterSet
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

### -Description
Gets or sets the description when setting the connection status of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateEndpointConnectionName
Gets or sets the name of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: SetByNameParameterSet, SetByClusterResourceIdParameterSet, SetByClusterInputObjectParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionState
Gets or sets the connection status of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Approved, Rejected

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
Parameter Sets: SetByNameParameterSet
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
Parameter Sets: SetByPrivateEndpointConnectionResourceIdParameterSet
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
