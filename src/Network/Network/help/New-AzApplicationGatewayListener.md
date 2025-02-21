---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewaylistener
schema: 2.0.0
---

# New-AzApplicationGatewayListener

## SYNOPSIS
Creates an TCP\TLS listener for an application gateway.

## SYNTAX

### SetByResource (Default)
```
New-AzApplicationGatewayListener -Name <String>
 [-FrontendIPConfiguration <PSApplicationGatewayFrontendIPConfiguration>]
 [-FrontendPort <PSApplicationGatewayFrontendPort>] [-SslCertificate <PSApplicationGatewaySslCertificate>]
 [-SslProfile <PSApplicationGatewaySslProfile>] -Protocol <String> [-HostNames <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SetByResourceId
```
New-AzApplicationGatewayListener -Name <String> [-FrontendIPConfigurationId <String>]
 [-FrontendPortId <String>] [-SslCertificateId <String>] [-SslProfileId <String>] -Protocol <String>
 [-HostNames <String[]>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayListener** cmdlet creates an TCP\TLS listener for an Azure application gateway.

## EXAMPLES

### Example 1: Create an TCP listener
```powershell
$Listener = New-AzApplicationGatewayListener -Name "Listener01" -Protocol "Tcp" -FrontendIpConfiguration $FIp01 -FrontendPort $FP01
```

This command creates an Tcp listener named Listener01 and stores the result in the variable named $Listener.

### Example 2: Create an TLS listener with SSL
```powershell
$Listener = New-AzApplicationGatewayListener -Name "Listener01" -Protocol "Tls" -FrontendIpConfiguration $FIp01 -FrontendPort $FP01 -SslCertificate $SSLCert01
```

This command creates an Tls listener that uses SSL offload and provides the SSL certificate in the $SSLCert01 variable.
The command stores the result in the variable named $Listener.

## PARAMETERS

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

### -FrontendIPConfiguration
Application gateway FrontendIPConfiguration

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFrontendIPConfiguration
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontendIPConfigurationId
ID of the application gateway FrontendIPConfiguration

```yaml
Type: System.String
Parameter Sets: SetByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontendPort
Application gateway FrontendPort

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFrontendPort
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontendPortId
ID of the application gateway FrontendPort

```yaml
Type: System.String
Parameter Sets: SetByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostNames
Host names

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Listener

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

### -Protocol
Protocol

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: TCP, TLS

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SslCertificate
Application gateway SslCertificate

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewaySslCertificate
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SslCertificateId
ID of the application gateway SslCertificate

```yaml
Type: System.String
Parameter Sets: SetByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SslProfile
SslProfile

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewaySslProfile
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SslProfileId
SslProfileId

```yaml
Type: System.String
Parameter Sets: SetByResourceId
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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayListener

## NOTES

## RELATED LINKS

[Add-AzApplicationGatewayListener](./Add-AzApplicationGatewayListener.md)

[Get-AzApplicationGatewayListener](./Get-AzApplicationGatewayListener.md)

[Remove-AzApplicationGatewayListener](./Remove-AzApplicationGatewayListener.md)

[Set-AzApplicationGatewayListener](./Set-AzApplicationGatewayListener.md)