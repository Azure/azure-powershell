---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmServiceFabricNodes

## SYNOPSIS
Remove nodes from the specific node type

## SYNTAX

```
Remove-AzureRmServiceFabricNodes -Number <Int32> [-NodeTypeName <String>] [-ClusterName] <String>
 [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmServiceFabricNodes** can remove nodes from specific node type 

## EXAMPLES

### Example 1
```
PS c:> Remove-AzureRmServiceFabricNodes -ResourceGroupName myResourceGroup -ClusterName myCluster -NumberOfNodesToRemove 2	-NodeTypeName n1
```

This command will remove 2 nodes from the node type n1

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
Node type name

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Number
Number of nodes to remove```yaml
Type: Int32
Parameter Sets: (All)
Aliases: NumberOfNodesToRemove

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

### System.Int32
System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

