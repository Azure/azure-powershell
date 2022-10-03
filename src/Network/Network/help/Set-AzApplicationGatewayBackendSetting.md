---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/set-azapplicationgatewaybackendsetting
schema: 2.0.0
---

# Set-AzApplicationGatewayBackendSetting

## SYNOPSIS
Updates back-end TCP\TLS settings for an application gateway.

## SYNTAX

```
Set-AzApplicationGatewayBackendSetting -ApplicationGateway <PSApplicationGateway> -Name <String> -Port <Int32>
 -Protocol <String> [-Timeout <Int32>] [-ProbeId <String>] [-Probe <PSApplicationGatewayProbe>]
 [-TrustedRootCertificate <PSApplicationGatewayTrustedRootCertificate[]>] [-PickHostNameFromBackendAddress]
 [-HostName <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Set-AzApplicationGatewayBackendSetting cmdlet updates the back-end TCP\TLS settings for an Azure application gateway.
Back-end settings are applied to all back-end servers in a pool.

## EXAMPLES

### Example 1: Update the back-end TCP\TLS settings for an application gateway
```powershell
$AppGw = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
$AppGw = Set-AzApplicationGatewayBackendSetting -ApplicationGateway $AppGw -Name "Setting02" -Port 88 -Protocol "Tcp"
```

The first command gets the application gateway named ApplicationGateway01 that belongs to the resource group named ResourceGroup01 and stores it in the $AppGw variable.
The second command updates the Backend settings of the application gateway in the $AppGw variable to use port 88, the TCP protocol.

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

### -HostName
Sets host header to be sent to the backend servers.

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

### -PickHostNameFromBackendAddress
Flag if host header should be picked from the host name of the backend server.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
Port

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Probe
Application gateway Probe

```yaml
Type: PSApplicationGatewayProbe
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbeId
ID of the application gateway Probe

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

### -Protocol
Protocol

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: TCP, TLS

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timeout
Timeout.
Default value 30 seconds.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrustedRootCertificate
Application gateway Trusted Root Certificates

```yaml
Type: PSApplicationGatewayTrustedRootCertificate[]
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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## NOTES

## RELATED LINKS

[Add-AzApplicationGatewayBackendSetting](./Add-AzApplicationGatewayBackendSetting.md)

[Get-AzApplicationGatewayBackendSetting](./Get-AzApplicationGatewayBackendSetting.md)

[New-AzApplicationGatewayBackendSetting](./New-AzApplicationGatewayBackendSetting.md)

[Remove-AzApplicationGatewayBackendSetting](./Remove-AzApplicationGatewayBackendSetting.md)
