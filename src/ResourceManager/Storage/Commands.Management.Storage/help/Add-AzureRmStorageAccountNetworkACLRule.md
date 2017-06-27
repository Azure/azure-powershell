---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
online version: 
schema: 2.0.0
---

# Add-AzureRmStorageAccountNetworkACLRule

## SYNOPSIS
 Add IpRules or VirtualNetworkRules to the NetworkAcls property of a Storage Account

## SYNTAX

### IpRuleObject
```
Add-AzureRmStorageAccountNetworkACLRule [-ResourceGroupName] <String> [-Name] <String> -IPRule <PSIpRule[]>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### NetworkRuleObject
```
Add-AzureRmStorageAccountNetworkACLRule [-ResourceGroupName] <String> [-Name] <String>
 -VirtualNetworkRule <PSVirtualNetworkRule[]> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IpRuleString
```
Add-AzureRmStorageAccountNetworkACLRule [-ResourceGroupName] <String> [-Name] <String>
 -IPAddressOrRange <String[]> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### NetWorkRuleString
```
Add-AzureRmStorageAccountNetworkACLRule [-ResourceGroupName] <String> [-Name] <String>
 -VirtualNetworkResourceId <String[]> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmStorageAccountNetworkACLRule** cmdlet adds IpRules or VirtualNetworkRules to the NetworkAcls property of a Storage Account

## EXAMPLES

### Example 1: Add several IpRules with IPAddressOrRange
```
PS C:\>Add-AzureRMStorageAccountNetworkAclRule -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount" -IPAddressOrRange "10.0.0.0/24","28.2.0.0/16"
```

This command add several IpRules with IPAddressOrRange.

### Example 2: Add a VirtualNetworkRule with VirtualNetworkResourceID
```
PS C:\>$subnet = Get-AzureRmVirtualNetwork -ResourceGroupName "myResourceGroup" -Name "myvirtualnetwork" | Get-AzureRmVirtualNetworkSubnetConfig
PS C:\>Add-AzureRMStorageAccountNetworkAclRule -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount" -VirtualNetworkResourceId $subnet[0].Id
```

This command add a VirtualNetworkRule with VirtualNetworkResourceID.

### Example 3: Add VirtualNetworkRules with VirtualNetworkRule Objects from another account
```
PS C:\> $networkacl = Get-AzureRMStorageAccountNetworkAcl -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount1"
PS C:\> Add-AzureRMStorageAccountNetworkAclRule -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount2" -VirtualNetworkRule $networkacl.VirtualNetworkRules
```

This command add VirtualNetworkRules with VirtualNetworkRule Objects from another account.

### Example 4: Add several IpRule with IpRule objects, input with JSON
```
PS C:\>Add-AzureRMStorageAccountNetworkAclRule -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount" -IPRule (@{IPAddressOrRange="10.0.0.0/24";Action="allow"},@{IPAddressOrRange="28.2.0.0/16";Action="allow"})
```

This command add several IpRule with IpRule objects, input with JSON.

## PARAMETERS

### -IPAddressOrRange
The Array of IpAddressOrRange, add IpRules with the input IpAddressOrRange and default Action Allow to NetworkAcls Property.

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
The Array of IpRule objects to add to the NetworkAcls Property.

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
The Array of VirtualNetworkResourceId, will add VirtualNetworkRule with input VirtualNetworkResourceId and default Action Allow to NetworkAcls Property.

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
The Array of VirtualNetworkRule objects to add to the NetworkAcls Property.

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

