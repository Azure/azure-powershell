---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 91D58F60-F22A-454A-B04C-E5AEF33E9D06
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermfirewall
schema: 2.0.0
---

# Get-AzureRmFirewall

## SYNOPSIS
Get a Firewall in a resource group

## SYNTAX

```
Get-AzureRmFirewall [-ResourceGroupName <String>] [-Name <String>]
```

## DESCRIPTION
The **Get-AzureRmFirewall** cmdlet gets one or more Firewalls in a resource group.

## EXAMPLES

### 1:  Retrieve all Firewalls in a resource group
```
Get-AzureRmFirewall -ResourceGroupName rgName
```

This example retrieves all Firewalls in resource group "rgName".

### 2:  Retrieve a Firewall by name
```
Get-AzureRmFirewall -ResourceGroupName rgName -Name secGw
```

This example retrieves Firewall named "secGw" in resource group "rgName".

## PARAMETERS

### -Name
Specifies the name of the Firewall that this cmdlet gets.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that Firewall belongs to.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSFirewall

## NOTES

## RELATED LINKS

[New-AzureRmFirewall](./New-AzureRmFirewall.md)

[Remove-AzureRmFirewall](./Remove-AzureRmFirewall.md)

[Set-AzureRmFirewall](./Set-AzureRmFirewall.md)
