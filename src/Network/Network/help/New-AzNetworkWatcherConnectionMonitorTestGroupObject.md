---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzNetworkWatcherConnectionMonitorTestGroupObject

## SYNOPSIS
Create a new test group for connection monitor V2.

## SYNTAX

```
New-AzNetworkWatcherConnectionMonitorTestGroupObject -Name <String>
 -TestConfiguration <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorTestConfigurationObject]>
 -Source <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorEndpointObject]>
 -Destination <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorEndpointObject]>
 [-Disable] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzNetworkWatcherConnectionMonitorTestGroupObject cmdlet creates a new test group for connection monitor V2.

## EXAMPLES

### Example 1
```powershell
PS C:\>$MySrcResourceId1 = "/subscriptions/96e68903-0a56-4819-9987-8d08ad6a1f99/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/iraVmTestSrc1"
PS C:\>$MyDstResourceId1 = "/subscriptions/96e68903-0a56-4819-9987-8d08ad6a1f99/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/iraVmTestDst1"
PS C:\>$SrcEndpointFilterItem1 =New-AzNetworkWatcherConnectionMonitorEndpointFilterItemObject -Type "AgentAddress" -Address "10.127.0.1"
PS C:\>$DstEndpointFilterItem1 =New-AzNetworkWatcherConnectionMonitorEndpointFilterItemObject -Type "AgentAddress" -Address "10.50.0.1"
PS C:\>$SourceEndpointObject1 = New-AzNetworkWatcherConnectionMonitorEndPointObject -ResourceId $MySrcResourceId1 -FilterType Include -FilterItem $SrcEndpointFilterItem1
PS C:\>$DestinationEndpointObject1 = New-AzNetworkWatcherConnectionMonitorEndPointObject  -ResourceId $MyDstResourceId1 -FilterType Include -FilterItem $DstEndpointFilterItem1
PS C:\>$TcpProtocolConfiguration = New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject -TcpProtocol -Port 80 -DisableTraceRoute $false 
PS C:\>$TcpTestConfiguration = New-AzNetworkWatcherConnectionMonitorTestConfigurationObject -Name MyTcpTestConfig -TestFrequencySec 40 -ProtocolConfiguration $TcpProtocolConfiguration -SuccessThresholdChecksFailedPercent 10 -SuccessThresholdRoundTripTimeMs 10 -PreferredIPVersion IPv4
PS C:\> New-AzNetworkWatcherConnectionMonitorTestGroupObject -Name MyTcpTestGroup -TestConfiguration $TcpTestConfiguration -Source @($SourceEndpointObject1) -Destination @($DestinationEndpointObject1)
$TcpTestGroup 
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


Name                   : MyTcpTestGroup
Disable                : False
TestConfigurations     : {MyTcpTestConfig}
Sources                : {iraVmTestSrc1(MyResourceGroup)}
Destinations           : {iraVmTestDst1(MyResourceGroup)}
TestConfigurationsText : [
                           {
                             "Name": "MyTcpTestConfig",
                             "TestFrequencySec": 40,
                             "Protocol": "TCP",
                             "PreferredIPVersion": "IPv4",
                             "TcpConfiguration": {
                               "Port": 80,
                               "DisableTraceRoute": false
                             },
                             "SuccessThreshold": {
                               "ChecksFailedPercent": 10,
                               "RoundTripTimeMs": 10
                             }
                           }
                         ]
SourcesText            : [
                           {
                             "Name": "iraVmTestSrc1(MyResourceGroup)",
                             "ResourceId": "/subscriptions/96e68903-0a56-4819-9987-8d08ad6a1f99/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/iraVmTestSrc1",
                             "Filter": {
                               "Type": "Include",
                               "Items": [
                                 {
                                   "Type": "AgentAddress",
                                   "Address": "10.127.0.1"
                                 }
                               ]
                             }
                           }
                         ]
DestinationsText       : [
                           {
                             "Name": "iraVmTestDst1(MyResourceGroup)",
                             "ResourceId": "/subscriptions/96e68903-0a56-4819-9987-8d08ad6a1f99/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/iraVmTestDst1",
                             "Filter": {
                               "Type": "Include",
                               "Items": [
                                 {
                                   "Type": "AgentAddress",
                                   "Address": "10.50.0.1"
                                 }
                               ]
                             }
                           }
                         ]


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

### -Destination
The list of destination endpoints.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorEndpointObject]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disable
The disable flag.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The test group name.

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

### -Source
The list of source endpoints.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorEndpointObject]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TestConfiguration
The list of test configuration.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorTestConfigurationObject]
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

### Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorTestGroupObject

## NOTES

## RELATED LINKS
