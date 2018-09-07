---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 95731734-EDCA-432A-A7BF-94D1E3725FB2
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/start-azurermapplicationgateway
schema: 2.0.0
---

# Start-AzureRmApplicationGateway

## SYNOPSIS
Starts an application gateway.

## SYNTAX

```
Start-AzureRmApplicationGateway -ApplicationGateway <PSApplicationGateway>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzureRmApplicationGateway** cmdlet starts an Azure application gateway

## EXAMPLES

### Example1: Start an application gateway
```
PS C:\>$AppGw = Start-AzureRmApplicationGateway -ApplicationGateway $AppGw
```

This command starts the application gateway stored in the $AppGw variable.

## PARAMETERS

### -ApplicationGateway
Specifies the application gateway that this cmdlet starts.

```yaml
Type: PSApplicationGateway
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## NOTES

## RELATED LINKS

[Stop-AzureRmApplicationGateway](./Stop-AzureRmApplicationGateway.md)


