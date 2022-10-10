---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/remove-azapplicationgatewaybackendsetting
schema: 2.0.0
---

# Remove-AzApplicationGatewayBackendSetting

## SYNOPSIS
Removes back-end TCP\TLS settings from an application gateway.

## SYNTAX

```
Remove-AzApplicationGatewayBackendSetting -Name <String> -ApplicationGateway <PSApplicationGateway>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzApplicationGatewayBackendSetting cmdlet removes back-end TCP\TLS settings from an Azure application gateway.

## EXAMPLES

### Example 1: Remove back-end TCP\TLS settings from an application gateway
```powershell
$AppGw = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
Remove-AzApplicationGatewayBackendSetting -ApplicationGateway $AppGw -Name "BackEndSetting02"
Set-AzApplicationGateway -ApplicationGateway $AppGW
```

The first command gets an application gateway named ApplicationGateway01 that belongs to the resource group named ResourceGroup01 and stores it in the $AppGw variable.
The second command removes the back-end TCP\TLS setting named BackEndSetting02 from the application gateway stored in $AppGw. Finally, the third command updates the application gateway.

## PARAMETERS

### -ApplicationGateway
The applicationGateway

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
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the backend settings

```yaml
Type: String
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

[Add-AzApplicationGatewayBackendSetting](./Add-AzApplicationGatewayBackendSetting.md)

[New-AzApplicationGatewayBackendSetting](./New-AzApplicationGatewayBackendSetting.md)

[Get-AzApplicationGatewayBackendSetting](./Get-AzApplicationGatewayBackendSetting.md)

[Set-AzApplicationGatewayBackendSetting](./Set-AzApplicationGatewayBackendSetting.md)