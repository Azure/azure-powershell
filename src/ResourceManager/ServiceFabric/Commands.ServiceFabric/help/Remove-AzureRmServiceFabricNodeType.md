---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmServiceFabricNodeType

## SYNOPSIS
Remove a node type from the cluster

## SYNTAX

```
Remove-AzureRmServiceFabricNodeType -NodeTypeName <String> [-ClusterName] <String>
 [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmServiceFabricNodeType** can remove nodes from specific node type Remove a existing node type from the cluster, note, it can't remove primary node type

## EXAMPLES

### Example 1
```
PS c:> Remove-AzureRmServiceFabricNodeType -ResourceGroupName myResourceGroup -ClusterName myCluster -NodeTypeName n1
```

This command will remove node type n1 from the cluster

## PARAMETERS

### -ClusterName
Specifies the name of the cluster

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NodeTypeName
The node type name

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

