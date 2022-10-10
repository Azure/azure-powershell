---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/remove-azapplicationgatewaylistener
schema: 2.0.0
---

# Remove-AzApplicationGatewayListener

## SYNOPSIS
Removes a TCP\TLS listener from an application gateway.

## SYNTAX

```
Remove-AzApplicationGatewayListener -Name <String> -ApplicationGateway <PSApplicationGateway>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzApplicationGatewayListener** cmdlet removes a TCP\TLS listener from an Azure application gateway.

## EXAMPLES

### Example 1: Remove an application gateway TCP\TLS listener
```powershell
$AppGw = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
Remove-AzApplicationGatewayListener -ApplicationGateway $AppGw -Name "Listener02"
Set-AzApplicationGateway -ApplicationGateway $AppGW
```

The first command gets an application gateway and stores it in the $AppGw variable.
The second command removes the TCP\TLS listener named Listener02 from the application gateway stored in $AppGw.
The last command updates the application gateway.


## PARAMETERS

### -ApplicationGateway
The applicationGateway

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGateway
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the application gateway listener

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## NOTES

## RELATED LINKS

[Add-AzApplicationGatewayListener](./Add-AzApplicationGatewayListener.md)

[Get-AzApplicationGatewayListener](./Get-AzApplicationGatewayListener.md)

[New-AzApplicationGatewayListener](./New-AzApplicationGatewayListener.md)

[Set-AzApplicationGatewayListener](./Set-AzApplicationGatewayListener.md)