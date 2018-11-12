---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermapplicationgatewayhttplistenercustomerror
schema: 2.0.0
---

# Get-AzureRmApplicationGatewayHttpListenerCustomError

## SYNOPSIS
Gets custom error(s) from a http listener of an application gateway.

## SYNTAX

```
Get-AzureRmApplicationGatewayHttpListenerCustomError [-StatusCode <String>]
 -HttpListener <PSApplicationGatewayHttpListener> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmApplicationGatewayCustomError** cmdlet gets custom error(s) from a http listener of an application gateway.

## EXAMPLES

### Example 1: Gets a custom error in a http listener
```powershell
PS C:\> $ce = Get-AzureRmApplicationGatewayCustomError -HttpListener $listener01 -StatusCode HttpStatus502
```

This command gets and returns the custom error of http status code 502 from the http listener $listener01.

### Example 2: Gets the list of all custom errors in a http listener
```powershell
PS C:\> $ces = Get-AzureRmApplicationGatewayCustomError -HttpListener $listener01
```

This command gets and returns the list of all custom errors from the http listener $listener01.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -HttpListener
The Application Gateway Http Listener

```yaml
Type: PSApplicationGatewayHttpListener
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StatusCode
Status code of the application gateway customer error.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayHttpListener

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayCustomError

## NOTES

## RELATED LINKS
