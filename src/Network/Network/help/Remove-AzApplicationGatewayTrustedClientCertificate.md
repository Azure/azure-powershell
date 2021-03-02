---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/remove-azapplicationgatewaytrustedclientcertificate
schema: 2.0.0
---

# Remove-AzApplicationGatewayTrustedClientCertificate

## SYNOPSIS
Removes the trusted client CA certificate chain object from an application gateway.

## SYNTAX

```
Remove-AzApplicationGatewayTrustedClientCertificate -Name <String> -ApplicationGateway <PSApplicationGateway>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzApplicationGatewayTrustedClientCertificate** cmdlet removes the trusted client CA certificate chain object from an application gateway.

## EXAMPLES

### Example 1
```powershell
PS C:\> $gw = Get-AzApplicationGateway -Name $appgwName -ResourceGroupName $resgpName
PS C:\> $gw = Remove-AzApplicationGatewayTrustedClientCertificate -ApplicationGateway $gw -Name "TrustedClientCertificate01"
```

The first command gets an application gateway and stores it in the $gw variable. The second command removes the trusted client CA certificate chain named "TrustedClientCertificate01" from the application gateway stored in $gw.

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
The name of the trusted client CA certificate chain

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## NOTES

## RELATED LINKS

[New-AzApplicationGatewayTrustedClientCertificate](./New-AzApplicationGatewayTrustedClientCertificate.md)

[Add-AzApplicationGatewayTrustedClientCertificate](./Add-AzApplicationGatewayTrustedClientCertificate.md)

[Get-AzApplicationGatewayTrustedClientCertificate](./Get-AzApplicationGatewayTrustedClientCertificate.md)

[Set-AzApplicationGatewayTrustedClientCertificate](./Set-AzApplicationGatewayTrustedClientCertificate.md)