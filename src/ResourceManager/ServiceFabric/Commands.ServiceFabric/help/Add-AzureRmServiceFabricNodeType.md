---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# Add-AzureRmServiceFabricNodeType

## SYNOPSIS
Add a node type to the existing cluster

## SYNTAX

```
Add-AzureRmServiceFabricNodeType [-Sku <String>] [-Tier <String>] -Capacity <Int32> -VmUserName <String>
 -VmPassword <String> -NodeTypeName <String> [-ClusterName] <String> [-ResourceGroupName] <String>
 [<CommonParameters>]
```

## DESCRIPTION
Add a new node type to the cluster 

## EXAMPLES

### Example 1
```
PS C:\> Add-AzureRmServiceFabricNodeType -ResourceGroupName myResourceGroup -ClusterName myCluster -NodeTypeName n2 -Capacity 5 -VmUserName adminName -VmPassword User@123
```

This command will add a new node type n2 with capacity with 5, and the vm admin username is adminName password is User@123

## PARAMETERS

### -Capacity
Capacity

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -Sku
The sku name

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

### -Tier
Tier

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

### -VmPassword
The password of login to the Vm

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

### -VmUserName
The user name for login to Vm

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.Int32

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

