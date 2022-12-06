---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azapplicationgatewaybackendsetting
schema: 2.0.0
---

# New-AzApplicationGatewayBackendSetting

## SYNOPSIS
Creates back-end TCP\TLS setting for an application gateway.

## SYNTAX

```
New-AzApplicationGatewayBackendSetting -Name <String> -Port <Int32> -Protocol <String> [-Timeout <Int32>]
 [-ProbeId <String>] [-Probe <PSApplicationGatewayProbe>]
 [-TrustedRootCertificate <PSApplicationGatewayTrustedRootCertificate[]>] [-PickHostNameFromBackendAddress]
 [-HostName <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzApplicationGatewayBackendSetting cmdlet creates back-end TCP\TLS settings for an application gateway.
Back-end settings are applied to all back-end servers in a pool.

## EXAMPLES

### Example 1: Create back-end TCP\TLS settings
```powershell
$Setting = New-AzApplicationGatewayBackendSetting -Name "Setting01" -Port 80 -Protocol Tcp
```

This command creates back-end settings named Setting01 on port 80, using the Tcp protocol
The settings are stored in the $Setting variable.

## PARAMETERS

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayBackendSettings

## NOTES

## RELATED LINKS

[Add-AzApplicationGatewayBackendSetting](./Add-AzApplicationGatewayBackendSetting.md)

[Get-AzApplicationGatewayBackendSetting](./Get-AzApplicationGatewayBackendSetting.md)

[Remove-AzApplicationGatewayBackendSetting](./Remove-AzApplicationGatewayBackendSetting.md)

[Set-AzApplicationGatewayBackendSetting](./Set-AzApplicationGatewayBackendSetting.md)