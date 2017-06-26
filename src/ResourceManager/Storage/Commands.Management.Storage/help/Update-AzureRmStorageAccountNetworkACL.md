---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
online version: 
schema: 2.0.0
---

# Update-AzureRmStorageAccountNetworkACL

## SYNOPSIS
Update the NetworkAcls property of a Storage Account

## SYNTAX

```
Update-AzureRmStorageAccountNetworkACL [-ResourceGroupName] <String> [-Name] <String>
 [-Bypass <PSNetWorkACLBypassEnum>] [-DefaultAction <PSNetWorkACLDefaultActionEnum>] [-IPRule <PSIpRule[]>]
 [-VirtualNetworkRule <PSVirtualNetworkRule[]>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzureRmStorageAccountNetworkACL** cmdlet updates the NetworkAcls property of a Storage Account

## EXAMPLES

### Example 1: Update all properties of NetworkACL, input Rules with JSON
```
PS C:\> Update-AzureRMStorageAccountNetworkACL -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount" -Bypass Logging,Metrics -DefaultAction Allow -IpRule (@{IPAddressOrRange="10.0.0.0/24";Action="allow"},@{IPAddressOrRange="28.2.0.0/16";Action="allow"})
    -VirtualNetworkRule (@{VirtualNetworkReourceId="/subscriptions/s1/resourceGroups/g1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1";Action="allow"},@{VirtualNetworkReourceId="/subscriptions/s1/resourceGroups/g1/providers/Microsoft.Network/virtualN
    etworks/vnet2/subnets/subnet2";Action="allow"})
```

This command update all properties of NetworkACL, input Rules with JSON.

### Example 2: Update Bypass property of NetworkACL
```
PS C:\> Update-AzureRMStorageAccountNetworkACL -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount" -Bypass AzureServices,Metrics
```

This command update Bypass property of NetworkACL (other properties won't change).

### Example 3: Clean up rules of NetworkACL of a Storage Account
```
PS C:\> Update-AzureRMStorageAccountNetworkACL -ResourceGroupName "myResourceGroup" -AccountName "myStorageAccount" -IpRule @() -VirtualNetworkRule @()
```

This command clean up rules of NetworkACL of a Storage Account (other properties not change).

## PARAMETERS

### -Bypass
The Bypass value to update to the NetworkAcls property of a Storage Account.
The allowed value are none or any combination of:
• Logging
• Metrics
• Azureservices

```yaml
Type: PSNetWorkACLBypassEnum
Parameter Sets: (All)
Aliases: 
Accepted values: None, Logging, Metrics, AzureServices

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultAction
The DefaultAction value to update to the NetworkAcls property of a Storage Account.
The allowed Options:
• Allow
• Deny

```yaml
Type: PSNetWorkACLDefaultActionEnum
Parameter Sets: (All)
Aliases: 
Accepted values: Deny, Allow

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPRule
The Array of IpRule objects to update to the NetworkAcls Property of a Storage Account.

```yaml
Type: PSIpRule[]
Parameter Sets: (All)
Aliases: 

Required: False
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

### -VirtualNetworkRule
The Array of VirtualNetworkRule objects to update to the NetworkAcls Property of a Storage Account.

```yaml
Type: PSVirtualNetworkRule[]
Parameter Sets: (All)
Aliases: 

Required: False
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

### Microsoft.Azure.Commands.Management.Storage.Models.PSNetworkACL

## NOTES

## RELATED LINKS

