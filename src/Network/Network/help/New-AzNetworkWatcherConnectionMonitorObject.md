---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkwatcherconnectionmonitorobject
schema: 2.0.0
---

# New-AzNetworkWatcherConnectionMonitorObject

## SYNOPSIS
Create a connection monitor V2 object.

## SYNTAX

### SetByResource
```
New-AzNetworkWatcherConnectionMonitorObject -NetworkWatcher <PSNetworkWatcher> -Name <String>
 [-TestGroup <PSNetworkWatcherConnectionMonitorTestGroupObject[]>]
 [-Output <PSNetworkWatcherConnectionMonitorOutputObject[]>] [-Note <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByName
```
New-AzNetworkWatcherConnectionMonitorObject -NetworkWatcherName <String> -ResourceGroupName <String>
 -Name <String> [-TestGroup <PSNetworkWatcherConnectionMonitorTestGroupObject[]>]
 [-Output <PSNetworkWatcherConnectionMonitorOutputObject[]>] [-Note <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByLocation
```
New-AzNetworkWatcherConnectionMonitorObject -Location <String> -Name <String>
 [-TestGroup <PSNetworkWatcherConnectionMonitorTestGroupObject[]>]
 [-Output <PSNetworkWatcherConnectionMonitorOutputObject[]>] [-Note <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzNetworkWatcherConnectionMonitorObject cmdlet creates a connection monitor V2 object.

## EXAMPLES

### Example 1
```powershell
PS> $cmtest = New-AzNetworkWatcherConnectionMonitorObject -Location westcentralus -Name cmV2test -TestGroup $testGroup1, $testGroup2 -Tag @{"name" = "value"}
PS> $cmtest
```

NetworkWatcherName : NetworkWatcher_westcentralus
ResourceGroupName  : NetworkWatcherRG
Name               : cmV2test
TestGroups         : [
                       {
                         "Name": "testGroup1",
                         "Disable": false,
                         "TestConfigurations": [
                           {
                             "Name": "tcpTC",
                             "TestFrequencySec": 60,
                             "ProtocolConfiguration": {
                               "Port": 80,
                               "DisableTraceRoute": false
                             },
                             "SuccessThreshold": {
                               "ChecksFailedPercent": 20,
                               "RoundTripTimeMs": 5
                             }
                           },
                           {
                             "Name": "icmpTC",
                             "TestFrequencySec": 30,
                             "PreferredIPVersion": "IPv4",
                             "ProtocolConfiguration": {
                               "DisableTraceRoute": true
                             }
                           }
                         ],
                         "Sources": [
                           {
                             "Name": "MultiTierApp0(IrinaRGWestcentralus)",
                             "ResourceId": "/subscriptions/00000000-0000-0000-0000-00000000/resourceGroups/RGW
                     estcentralus/providers/Microsoft.Compute/virtualMachines/MultiTierApp0"
                           },
                           {
                             "Name": "NPM-CommonEUS(er-lab)",
                             "ResourceId": "/subscriptions/00000000-0000-0000-0000-00000000/resourceGroups/er-lab/p
                     roviders/Microsoft.OperationalInsights/workspaces/NPM-CommonEUS",
                             "Filter": {
                               "Type": "Include",
                               "Items": [
                                 {
                                   "Type": "AgentAddress",
                                   "Address": "SEA-Cust50-VM01"
                                 },
                                 {
                                   "Type": "AgentAddress",
                                   "Address": "WIN-P0HGNDO2S1B"
                                 }
                               ]
                             }
                           }
                         ],
                         "Destinations": [
                           {
                             "Name": "bingEndpoint",
                             "Address": "bing.com"
                           },
                           {
                             "Name": "googleEndpoint",
                             "Address": "google.com"
                           }
                         ]
                       },
                       {
                         "Name": "testGroup2",
                         "Disable": false,
                         "TestConfigurations": [
                           {
                             "Name": "httpTC",
                             "TestFrequencySec": 120,
                             "ProtocolConfiguration": {
                               "Port": 443,
                               "Method": "GET",
                               "RequestHeaders": [
                                 {
                                   "Name": "Allow",
                                   "Value": "GET"
                                 }
                               ],
                               "ValidStatusCodeRanges": [
                                 "2xx",
                                 "300-308"
                               ],
                               "PreferHTTPS": true
                             },
                             "SuccessThreshold": {
                               "ChecksFailedPercent": 20,
                               "RoundTripTimeMs": 30
                             }
                           }
                         ],
                         "Sources": [
                           {
                             "Name": "MultiTierApp0(IrinaRGWestcentralus)",
                             "ResourceId": "/subscriptions/00000000-0000-0000-0000-00000000/resourceGroups/IrinaRGW
                     estcentralus/providers/Microsoft.Compute/virtualMachines/MultiTierApp0"
                           }
                         ],
                         "Destinations": [
                           {
                             "Name": "googleEndpoint",
                             "Address": "google.com"
                           }
                         ]
                       }
                     ]
Outputs            : null
Notes              :
Tags               : {
                       "name": "value"
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

### -Location
Location of the network watcher.

```yaml
Type: System.String
Parameter Sets: SetByLocation
Aliases:

Required: True
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

### -NetworkWatcher
The network watcher resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSNetworkWatcher
Parameter Sets: SetByResource
Aliases:

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
Parameter Sets: SetByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Note
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
Describes a connection monitor output destinations.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorOutputObject[]
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
Parameter Sets: SetByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
A hashtable which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TestGroup
The list of test groups.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorTestGroupObject[]
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
