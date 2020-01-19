---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzNetworkWatcherConnectionMonitorTestConfigurationObject

## SYNOPSIS
Create a new test configuration for connection monitor V2.

## SYNTAX

```
New-AzNetworkWatcherConnectionMonitorTestConfigurationObject [-Name <String>] -TestFrequencySec <Int32>
 -ProtocolConfiguration <PSNetworkWatcherConnectionMonitorProtocolConfiguration>
 [-SuccessThresholdChecksFailedPercent <Int32>] [-SuccessThresholdRoundTripTimeMs <Int32>]
 [-PreferredIPVersion <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The New-AzNetworkWatcherConnectionMonitorTestConfigurationObject cmdlet creates a new test configuration for connection monitor V2.

## EXAMPLES

### Example 1
```powershell
PS C:\>$TcpProtocolConfiguration = New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject -TcpProtocol -Port 80 -DisableTraceRoute $false 
PS C:\>$TcpTestConfiguration = New-AzNetworkWatcherConnectionMonitorTestConfigurationObject -Name MyTcpTestConfig -TestFrequencySec 40 -ProtocolConfiguration $TcpProtocolConfiguration
```

Name                  : MyTcpTestConfig
TestFrequencySec      : 40
Protocol              : TCP
PreferredIPVersion    : IPv4
HttpConfiguration     :
TcpConfiguration      : Microsoft.Azure.Commands.Network.Models.PSConnectionMonitorTcpConfiguration
IcmpConfiguration     :
SuccessThreshold      : Microsoft.Azure.Commands.Network.Models.PSConnectionMonitorSuccessThreshold
HttpConfigurationText : null
TcpConfigurationText  : {
                          "Port": 80,
                          "DisableTraceRoute": false
                        }
IcmpConfigurationText : null
SuccessThresholdText  : {
                          "ChecksFailedPercent": 10,
                          "RoundTripTimeMs": 10
                        }

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

### -Name
The test configuration name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreferredIPVersion
The preferred IP version.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtocolConfiguration
The protocol configuration.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorProtocolConfiguration
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuccessThresholdChecksFailedPercent
The percentage of failed check.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuccessThresholdRoundTripTimeMs
The round trip time in millisecond.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TestFrequencySec
The test frequency in seconds.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases: TestFrequency

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorTestConfigurationObject

## NOTES

## RELATED LINKS
