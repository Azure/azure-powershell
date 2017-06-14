---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 0CD03BF8-8DB6-44BC-91F0-D863949DBD17
online version: 
schema: 2.0.0
---

# Get-AzureRmPublicIpAddress

## SYNOPSIS
Gets a public IP address.

## SYNTAX

### NoExpand
```
Get-AzureRmPublicIpAddress [-Name <String>] [-ResourceGroupName <String>] [<CommonParameters>]
```

### Expand
```
Get-AzureRmPublicIpAddress -Name <String> -ResourceGroupName <String> -ExpandResource <String>
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmPublicIPAddress** cmdlet gets one or more public IP addresses in a resource group.

## EXAMPLES

### 1: Get a public IP resource
```
$publicIp = Get-AzureRmPublicIpAddress -Name $publicIpName -ResourceGroupName $rgName $publicIp
```

This command gets a public IP address resource with name $publicIPName in the resource group $rgName.

## PARAMETERS

### -ExpandResource
```yaml
Type: String
Parameter Sets: Expand
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the public IP address that this cmdlet gets.

```yaml
Type: String
Parameter Sets: NoExpand
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Expand
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the public IP address that this cmdlet gets.

```yaml
Type: String
Parameter Sets: NoExpand
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Expand
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[New-AzureRmPublicIpAddress](./New-AzureRmPublicIpAddress.md)

[Remove-AzureRmPublicIpAddress](./Remove-AzureRmPublicIpAddress.md)

[Set-AzureRmPublicIpAddress](./Set-AzureRmPublicIpAddress.md)


