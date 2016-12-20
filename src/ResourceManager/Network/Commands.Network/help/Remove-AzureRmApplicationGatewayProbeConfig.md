---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: C5D49E3A-8A75-40D5-BD1E-4ECC467B4F5D
online version: 
schema: 2.0.0
---

# Remove-AzureRmApplicationGatewayProbeConfig

## SYNOPSIS
Removes a health probe from an existing application gateway.

## SYNTAX

```
Remove-AzureRmApplicationGatewayProbeConfig -Name <String> -ApplicationGateway <PSApplicationGateway>
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmApplicationGatewayProbeConfig** cmdlet removes a heath probe from an existing application gateway.

## EXAMPLES

### Example 1: Remove a health probe from an existing application gateway
```
PS C:\>$Gateway = Remove-AzureRmApplicationGatewayProbeConfig -ApplicationGateway Gateway -Name "Probe04"
```

This command removes the health probe named Probe04 from the application gateway named Gateway.

## PARAMETERS

### -Name
Specifies the name of the probe for which this cmdlet removes.

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

### -ApplicationGateway
Specifies the application gateway to which this cmdlet removes a probe.

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

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Remove a probe from an existing application gateway](https://azure.microsoft.com/en-us/documentation/articles/application-gateway-create-probe-ps/#remove-a-probe-from-an-existing-application-gateway)

[Add-AzureRmApplicationGatewayProbeConfig](./Add-AzureRmApplicationGatewayProbeConfig.md)

[Get-AzureRmApplicationGatewayProbeConfig](./Get-AzureRmApplicationGatewayProbeConfig.md)

[New-AzureRmApplicationGatewayProbeConfig](./New-AzureRmApplicationGatewayProbeConfig.md)

[Set-AzureRmApplicationGatewayProbeConfig](./Set-AzureRmApplicationGatewayProbeConfig.md)


