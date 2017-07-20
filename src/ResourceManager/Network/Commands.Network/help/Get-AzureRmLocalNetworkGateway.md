---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: F8756DA1-7BB9-4CD5-9D81-E11FF7A26125
online version: 
schema: 2.0.0
---

# Get-AzureRmLocalNetworkGateway

## SYNOPSIS
Gets a Local Network Gateway

## SYNTAX

```
Get-AzureRmLocalNetworkGateway [-Name <String>] -ResourceGroupName <String> [<CommonParameters>]
```

## DESCRIPTION
The Local Network Gateway is the object representing your VPN device On-Premises.

The **Get-AzureRmLocalNetworkGateway** cmdlet returns the object representing your on-prem gateway based on Name and Resource Group Name.

## EXAMPLES

### 1: Get a Local Network Gateway
```
Get-AzureRmLocalNetworkGateway -Name myLocalGW -ResourceGroupName myRG
```

Returns the object of the Local Network Gateway with the name "myLocalGW" within the resource group "myRG"

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

