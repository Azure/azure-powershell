---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Test-AzureRmNetworkWatcherConnectivity

## SYNOPSIS
Returns connectivity information for a specified source VM and a destination.

## SYNTAX

### SetByResource (Default)
```
Test-AzureRmNetworkWatcherConnectivity -NetworkWatcher <PSNetworkWatcher> -SourceId <String>
 [-SourcePort <Int32>] [-DestinationId <String>] [-DestinationAddress <String>] [-DestinationPort <Int32>]
```

### SetByName
```
Test-AzureRmNetworkWatcherConnectivity -NetworkWatcherName <String> -ResourceGroupName <String>
 -SourceId <String> [-SourcePort <Int32>] [-DestinationId <String>] [-DestinationAddress <String>]
 [-DestinationPort <Int32>]
```

## DESCRIPTION
The Test-AzureRmNetworkWatcherConnectivity cmdlet returns connectivity information for a specified source VM and a destination. If connectivity between the source and destination cannot be established, the cmdlet returns details about the issue.

## EXAMPLES

### ---------------  Example 1: Test Network Watcher Connectivity from a VM to a website  ---------------
@{paragraph=PS C:\\\>}
```
Test-AzureRmNetworkWatcherConnectivity -NetworkWatcherName NetworkWatcher -ResourceGroupName NetworkWatcherRG -SourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ContosoRG/providers/Microsoft.Compute/virtualMachines/MultiTierApp0" -DestinationAddress "bing.com" -DestinationPort 80


ConnectionStatus : Reachable
AvgLatencyInMs   : 4
MinLatencyInMs   : 2
MaxLatencyInMs   : 15
ProbesSent       : 15
ProbesFailed     : 0
Hops             : [
                     {
                       "Type": "Source",
                       "Id": "f8cff464-e13f-457f-a09e-4dcd53d38a85",
                       "Address": "10.1.1.4",
                       "ResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ContosoRG/provi                   iders/Microsoft.Network/networkInterfaces/appNic0/ipConfigurations/ipconfig1",
                       "NextHopIds": [
                         "1034b1bf-0b1b-4f0a-93b2-900477f45485"
                       ],
                       "Issues": []
                     },
                     {
                       "Type": "Internet",
                       "Id": "1034b1bf-0b1b-4f0a-93b2-900477f45485",
                       "Address": "13.107.21.200",
                       "ResourceId": "Internet",
                       "NextHopIds": [],
                       "Issues": []
                     }
                   ]
```

In this example we test connectivity from a VM in Azure to www.bing.com.

## PARAMETERS

### -DestinationAddress
The IP address or URI the resource to which a connection attempt will be made.

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

### -DestinationId
The ID of the resource to which a connection attempt will be made.

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

### -DestinationPort
Port on which check connectivity will be performed.

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

### -NetworkWatcher
The network watcher resource.

```yaml
Type: PSNetworkWatcher
Parameter Sets: SetByResource
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkWatcherName
The name of network watcher.

```yaml
Type: String
Parameter Sets: SetByName
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the network watcher resource group.

```yaml
Type: String
Parameter Sets: SetByName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SourceId
The ID of the resource from which a connectivity check will be initiated.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SourcePort
The source port from which a connectivity check will be performed.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkWatcher
System.String
System.Int32


## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSConnectivityInformation


## NOTES
Keywords: azure, azurerm, arm, resource, connectivity, management, manager, network, networking, network watcher

## RELATED LINKS
[New-AzureRmNetworkWatcher]()
[Get-AzureRmNetworkWatcher]()

[Get-AzureRmNetworkWatcherIPFlowVerify]()
[Get-AzureRmNetworkWatcherNextHop]()
[Get-AzureRmNetworkWatcherSecurityGroupView]()
[Get-AzureRmNetworkWatcherTopology]()
[Get-AzureRmNetworkWatcherTroubleshoot]()

[New-AzureRmNetworkWatcherPacketCapture]()
[New-AzureRmPacketCaptureFilter]()
[Get-AzureRmNetworkWatcherPacketCapture]()
[Remove-AzureRmNetworkWatcherPacketCapture]()
[Stop-AzureRmNetworkWatcherPacketCapture]()