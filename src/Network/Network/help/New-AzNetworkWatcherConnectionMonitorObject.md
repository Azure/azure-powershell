---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzNetworkWatcherConnectionMonitorObject

## SYNOPSIS
Create a connection monitor V2 object.

## SYNTAX

```
New-AzNetworkWatcherConnectionMonitorObject -NetworkWatcherName <String> -ResourceGroupName <String>
 -Name <String>
 [-TestGroup <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorTestGroupObject]>]
 [-Output <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorOutputObject]>]
 [-Notes <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzNetworkWatcherConnectionMonitorObject cmdlet creates a connection monitor V2 object.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzNetworkWatcherConnectionMonitorObject -NetworkWatcherName NetworkWatcher_centraluseuap -ResourceGroupName NetworkWatcherRG  -Name MyCMv2 -TestGroup   $TcpTestGroup -Notes "This is my notes for CMv2"
```

NetworkWatcherName : NetworkWatcher_centraluseuap
ResourceGroupName  : NetworkWatcherRG
Name               : MyCMv2
TestGroup          : {MyTcpTestGroup}
Output             :
Notes              : This is my notes for CMv2
TestGroupText      : [
                       {
                         "Name": "MyTcpTestGroup",
                         "Disable": false,
                         "TestConfigurations": [
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
                         ],
                         "Sources": [
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
                         ],
                         "Destinations": [
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
                       }
                     ]
OutputText         : null

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
The connection monitor name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ConnectionMonitorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkWatcherName
The name of network watcher.

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

### -Notes
Notes associated with connection monitor.

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

### -Output
The connection monitor output.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorOutputObject]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the network watcher resource group.

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

### -TestGroup
The list of test group.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorTestGroupObject]
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorObject

## NOTES

## RELATED LINKS
