---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 9CBF592E-734B-4A0C-A45D-358C226D08C7
online version: 
schema: 2.0.0
---

# Get-AzureRmVirtualNetworkGateway

## SYNOPSIS
Gets a Virtual Network Gateway

## SYNTAX

```
Get-AzureRmVirtualNetworkGateway [-Name <String>] -ResourceGroupName <String> [<CommonParameters>]
```

## DESCRIPTION
The Virtual Network Gateway is the object representing your gateway in Azure.

The **Get-AzureRmVirtualNetworkGateway** cmdlet returns the object of your gateway in Azure based on Name and Resource Group Name.

## EXAMPLES

### 1: Get a Virtual Network Gateway
```
Get-AzureRmVirtualNetworkGateway -Name myGateway -ResourceGroupName myRG
```

Returns the object of the Virtual Network Gateway with the name "myGateway" within the resource group "myRG"

## PARAMETERS

### -Name
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

