---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-azapplicationgatewaybackendsetting
schema: 2.0.0
---

# Get-AzApplicationGatewayBackendSetting

## SYNOPSIS
Gets the back-end TCP\TLS settings of an application gateway.

## SYNTAX

```
Get-AzApplicationGatewayBackendSetting [-Name <String>] -ApplicationGateway <PSApplicationGateway>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzApplicationGatewayBackendSetting cmdlet gets the back-end TCP\TLS settings of an application gateway.

## EXAMPLES

### Example 1: Get back-end TCP\TLS settings by name
```powershell
$AppGw = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
$Settings  = Get-AzApplicationGatewayBackendSetting -Name "Settings01" -ApplicationGateway $AppGw
```

The first command gets the application gateway named ApplicationGateway01 in the resource group named ResourceGroup01, and stores it in the $AppGw variable.The second command gets the backend settings named Settings01 for $AppGw and stores the settings in the $Settings variable.

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

Required: False
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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayBackendSettings

## NOTES

## RELATED LINKS

[Add-AzApplicationGatewayBackendSetting](./Add-AzApplicationGatewayBackendSetting.md)

[New-AzApplicationGatewayBackendSetting](./New-AzApplicationGatewayBackendSetting.md)

[Remove-AzApplicationGatewayBackendSetting](./Remove-AzApplicationGatewayBackendSetting.md)

[Set-AzApplicationGatewayBackendSetting](./Set-AzApplicationGatewayBackendSetting.md)