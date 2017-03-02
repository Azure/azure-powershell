---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmNetworkWatcherPacketCapture

## SYNOPSIS
Gets information and properties and status of a packet capture resource.

## SYNTAX

### SetByResource (Default)
```
Get-AzureRmNetworkWatcherPacketCapture -NetworkWatcher <PSNetworkWatcher> [-PacketCaptureName <String>]
 [<CommonParameters>]
```

### SetByName
```
Get-AzureRmNetworkWatcherPacketCapture -NetworkWatcherName <String> -ResourceGroupName <String>
 [-PacketCaptureName <String>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmNetworkWatcherPacketCapture gets the properties and status of a packet capture resource.

## EXAMPLES

### --- Example 1: Create a Packet Capture with multiple filters and retrieve its status ---
```
$nw = Get-AzurermResource | Where {$_.ResourceType -eq "Microsoft.Network/networkWatchers" -and $_.Location -eq "WestCentralUS" } 
$networkWatcher = Get-AzureRmNetworkWatcher -Name $nw.Name -ResourceGroupName $nw.ResourceGroupName 

$storageAccount = Get-AzureRmStorageAccount -ResourceGroupName contosoResourceGroup -Name contosostorage123

$filter1 = New-AzureRmPacketCaptureFilterConfig -Protocol TCP -RemoteIPAddress "1.1.1.1-255.255.255" -LocalIPAddress "10.0.0.3" -LocalPort "1-65535" -RemotePort "20;80;443"
$filter2 = New-AzureRmPacketCaptureFilterConfig -Protocol UDP 
New-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $networkWatcher -TargetVirtualMachineId $vm.Id -PacketCaptureName "PacketCaptureTest" -StorageAccountId $storageAccount.id -TimeLimitInSeconds 60 -Filters $filter1, $filter2

Get-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $networkWatcher -PacketCaptureName "PacketCaptureTest"
```

In this example we create a packet capture named "PacketCaptureTest" with multiple filters and a time limit. Once the session is complete, it will be saved to the specified storage account. 
We then call Get-AzureRmNetworkWatcherPacketCapture to retrieve the status of the capture session. 

Note: The Azure Network Watcher extension must be installed on the target virtual machine to create packet captures.

## PARAMETERS

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

### -PacketCaptureName
The packet capture name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkWatcher
System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSGetPacketCaptureResult

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, network, networking, network watcher, packet, capture, traffic

## RELATED LINKS

[New-AzureRmNetworkWatcherPacketCapture]()
[New-AzureRmPacketCaptureFilterConfig]()
[Remove-AzureRmNetworkWatcherPacketCapture]()
[Stop-AzureRmNetworkWatcherPacketCapture]()

[New-AzureRmNetworkWatcher]()
[Get-AzureRmNetworkWatcher]()
[Remove-AzureRmNetworkWatcher]()

[Test-AzureRmNetworkWatcherIPFlow]()
[Get-AzureRmNetworkWatcherNextHop]()
[Get-AzureRmNetworkWatcherSecurityGroupView]()
[Get-AzureRmNetworkWatcherTopology]()
[Start-AzureRmNetworkWatcherResourceTroubleshooting]()

