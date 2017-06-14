---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 84FDB0F7-E6DE-4E1B-BD71-89535EDC6AA1
online version: 
schema: 2.0.0
---

# Get-AzureRmEffectiveRouteTable

## SYNOPSIS
Gets the effective route table of a network interface.

## SYNTAX

```
Get-AzureRmEffectiveRouteTable -NetworkInterfaceName <String> [-ResourceGroupName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmEffectiveRouteTable** cmdlet returns the effective route table that is applied on a network interface.

## EXAMPLES

### Example 1: Get the effective route table on a network interface
```
PS C:\>Get-AzureRmEffectiveRouteTable -NetworkInterfaceName "MyNetworkInterface" -ResourceGroupName "MyResourceGroup"
```

This command gets the effective route table associated with network interface named MyNetworkInterface in the resource group named MyResourceGroup.

## PARAMETERS

### -NetworkInterfaceName
Specified the name of a network interface.

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
Specifies the resource group of a network interface.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmEffectiveNetworkSecurityGroup](./Get-AzureRmEffectiveNetworkSecurityGroup.md)


