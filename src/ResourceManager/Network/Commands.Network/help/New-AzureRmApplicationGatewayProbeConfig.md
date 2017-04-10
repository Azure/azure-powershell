---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 3D94518E-8369-437F-85BD-48AA127DBE24
online version: 
schema: 2.0.0
---

# New-AzureRmApplicationGatewayProbeConfig

## SYNOPSIS
Creates a health probe.

## SYNTAX

```
New-AzureRmApplicationGatewayProbeConfig -Name <String> -Protocol <String> -HostName <String> -Path <String>
 -Interval <UInt32> -Timeout <UInt32> -UnhealthyThreshold <UInt32> [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmApplicationGatewayProbeConfig** cmdlet creates a health probe.

## EXAMPLES

### Example1: Create a health probe
```
PS C:\>New-AzureRmApplicationGatewayProbeConfig -Name "Probe03" -Protocol Http -HostName "contoso.com" -Path "/path/custompath.htm" -Interval 30 -Timeout 120 -UnhealthyThreshold 8
```

This command creates a health probe named Probe03, with HTTP protocol, a 30 second interval, timeout of 120 seconds, and an unhealthy threshold of 8 retries.

## PARAMETERS

### -HostName
Specifies the host name that this cmdlet sends the probe.

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

### -Interval
Specifies the probe interval in seconds.
This is the time interval between two consecutive probes.
This value is between 1 second and 86400 seconds.

```yaml
Type: UInt32
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the probe.

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

### -Path
Specifies the relative path of probe.
Valid paths start with the slash character (/).
The probe is sent to \<Protocol\>://\<host\>:\<port\>\<path\>.

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

### -Protocol
Specifies the protocol used to send probe.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: Http, Https

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timeout
Specifies the probe timeout in seconds.
This cmdlet marks the probe as failed if a valid response is not received with this timeout period.
Valid values are between 1 second and 86400 seconds.

```yaml
Type: UInt32
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnhealthyThreshold
Specifies the probe retry count.
The backend server is marked down after consecutive probe failure count reaches the unhealthy threshold.
Valid values are between 1 second and 20 seconds.

```yaml
Type: UInt32
Parameter Sets: (All)
Aliases: 

Required: True
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

[Create custom probe for Application Gateway using PowerShell for Azure Resource Manager](https://azure.microsoft.com/en-us/documentation/articles/application-gateway-create-probe-ps/#)

[Add-AzureRmApplicationGatewayProbeConfig](./Add-AzureRmApplicationGatewayProbeConfig.md)

[Get-AzureRmApplicationGatewayProbeConfig](./Get-AzureRmApplicationGatewayProbeConfig.md)

[Remove-AzureRmApplicationGatewayProbeConfig](./Remove-AzureRmApplicationGatewayProbeConfig.md)

[Set-AzureRmApplicationGatewayProbeConfig](./Set-AzureRmApplicationGatewayProbeConfig.md)


