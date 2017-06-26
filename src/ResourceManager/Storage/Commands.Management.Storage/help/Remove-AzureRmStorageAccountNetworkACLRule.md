---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmStorageAccountNetworkACLRule

## SYNOPSIS
Remove IpRules or VirtualNetworkRules from the NetworkAcls property of a Storage Account

## SYNTAX

### IpRuleObject
```
Remove-AzureRmStorageAccountNetworkACLRule [-ResourceGroupName] <String> [-Name] <String> -IPRule <PSIpRule[]>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### NetworkRuleObject
```
Remove-AzureRmStorageAccountNetworkACLRule [-ResourceGroupName] <String> [-Name] <String>
 -VirtualNetworkRule <PSVirtualNetworkRule[]> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IpRuleString
```
Remove-AzureRmStorageAccountNetworkACLRule [-ResourceGroupName] <String> [-Name] <String>
 -IPAddressOrRange <String[]> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### NetWorkRuleString
```
Remove-AzureRmStorageAccountNetworkACLRule [-ResourceGroupName] <String> [-Name] <String>
 -VirtualNetworkResourceId <String[]> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmStorageAccountNetworkACLRule** cmdlet removes IpRules or VirtualNetworkRules from the NetworkAcls property of a Storage Account

## EXAMPLES

### Example 1: Remove several IpRules with IPAddressOrRange
```
PS C:\>Remove-AzureRMStorageAccountNetworkAclRule -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount" -IPAddressOrRange "10.0.0.0/24,28.1.0.0/16"
```

This command remove several IpRules with IPAddressOrRange.

### Example 2: Remove a VirtualNetworkRule with VirtualNetworkRule Object input with JSON
```
PS C:\>Remove-AzureRMStorageAccountNetworkAclRule -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount" -VirtualNetworkRules (@{VirtualNetworkReourceId="/subscriptions/s1/resourceGroups/g1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1";Action="allow"})
```

This command remove a VirtualNetworkRule with VirtualNetworkRule Object input with JSON.

### Example 3: Remove first IpRule with pipeline
```
PS C:\>(Get-AzureRmStorageAccountNetworkACL -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount").IpRules[0] | Remove-AzureRMStorageAccountNetworkAclRule -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount"
```

This command remove first IpRule with pipeline.

### Example 4: Remove several VirtualNetworkRules with VirtualNetworkResourceID
```
PS C:\>Remove-AzureRMStorageAccountNetworkAclRule -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount" -VirtualNetworkResourceId "/subscriptions/s1/resourceGroups/g1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1","/subscriptions/s1/resourceGroups/g1/providers/Microsoft.Network/virtualNetworks/vnet2/subnets/subnet2"
```

This command remove several VirtualNetworkRules with VirtualNetworkResourceID.

## PARAMETERS

### -IPAddressOrRange
The Array of IpAddressOrRange, will remove IpRule with same IpAddressOrRange from the NetworkAcls Property.

```yaml
Type: String[]
Parameter Sets: IpRuleString
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPRule
The Array of IpRule objects to remove from the NetworkAcls Property.

```yaml
Type: PSIpRule[]
Parameter Sets: IpRuleObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the name of the Storage account.

```yaml
Type: String
Parameter Sets: (All)
Aliases: StorageAccountName, AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group contains the Storage account.

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

### -VirtualNetworkResourceId
The Array of VirtualNetworkResourceId, will remove VirtualNetworkRule with same VirtualNetworkResourceId from the NetworkAcls Property.

```yaml
Type: String[]
Parameter Sets: NetWorkRuleString
Aliases: SubnetId, VirtualNetworkId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkRule
The Array of VirtualNetworkRule objects to remove from the NetworkAcls Property.

```yaml
Type: PSVirtualNetworkRule[]
Parameter Sets: NetworkRuleObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Commands.Management.Storage.Models.PSIpRule[]
Microsoft.Azure.Commands.Management.Storage.Models.PSVirtualNetworkRule[]

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSVirtualNetworkRule
Microsoft.Azure.Commands.Management.Storage.Models.PSIpRule

## NOTES

## RELATED LINKS

