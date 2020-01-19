---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject

## SYNOPSIS
Create a new protocol configuration for connection monitor V2.

## SYNTAX

### TCP
```
New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject [-TcpProtocol] -Port <Int16>
 [-DisableTraceRoute <Boolean>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### HTTP
```
New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject [-HttpProtocol] [-Port <Int16>]
 [-Method <String>] [-Path <String>]
 [-RequestHeader <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSHTTPHeader]>]
 [-ValidStatusCodeRange <System.Collections.Generic.List`1[System.String]>] [-PreferHTTPS <Boolean>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ICMP
```
New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject [-IcmpProtocol] [-DisableTraceRoute <Boolean>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject cmdlet creates a new protocol configuration for connection monitor V2.

## EXAMPLES

### Example 1
```powershell
PS C:\>$TcpProtocolConfiguration = New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject -TcpProtocol -Port 80 -DisableTraceRoute $false
```

Port              : 80
DisableTraceRoute : False

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

### -DisableTraceRoute
Disable traceRoute.

```yaml
Type: System.Boolean
Parameter Sets: TCP, ICMP
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpProtocol
The protocol.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: HTTP
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IcmpProtocol
The protocol.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ICMP
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Method
The method.

```yaml
Type: System.String
Parameter Sets: HTTP
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
The path.

```yaml
Type: System.String
Parameter Sets: HTTP
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
The port.

```yaml
Type: System.Nullable`1[System.Int16]
Parameter Sets: TCP
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.Nullable`1[System.Int16]
Parameter Sets: HTTP
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreferHTTPS
Whether to prefer HTTPS or not.

```yaml
Type: System.Boolean
Parameter Sets: HTTP
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestHeader
The request header.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSHTTPHeader]
Parameter Sets: HTTP
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TcpProtocol
The protocol.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: TCP
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidStatusCodeRange
The list of valid status code range.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: HTTP
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

### Microsoft.Azure.Commands.Network.Models.PSConnectionMonitorTcpConfiguration

### Microsoft.Azure.Commands.Network.Models.PSConnectionMonitorHttpConfiguration

### Microsoft.Azure.Commands.Network.Models.PSConnectionMonitorIcmpConfiguration

## NOTES

## RELATED LINKS
