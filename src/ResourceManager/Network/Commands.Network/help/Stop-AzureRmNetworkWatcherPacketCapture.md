---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Stop-AzureRmNetworkWatcherPacketCapture

## SYNOPSIS
Stops a running packet capture session

## SYNTAX

### SetByResource (Default)
```
Stop-AzureRmNetworkWatcherPacketCapture -NetworkWatcher <PSNetworkWatcher> -PacketCaptureName <String>
 [-WhatIf] [-Confirm]
```

### SetByName
```
Stop-AzureRmNetworkWatcherPacketCapture -NetworkWatcherName <String> -ResourceGroupName <String>
 -PacketCaptureName <String> [-WhatIf] [-Confirm]
```

## DESCRIPTION
The Stop-AzureRmNetworkWatcherPacketCapture stops a running packet capture session. After the session is stopped, the packet capture file is uploaded to storage and/or saved locally on the VM depending on its configuration.

## EXAMPLES

### --- Example 1: Stop a packet capture session ---
```
Stop-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $networkWatcher -PacketCaptureName "PacketCaptureTest"
```
In this example we stop a running packet capture session named "PacketCaptureTest". After the session is stopped, the packet capture file is uploaded to storage and/or saved locally on the VM depending on its configuration.

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

Required: True
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
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkWatcher
System.String

## OUTPUTS

### System.Boolean

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, network, networking, network watcher, packet, capture, traffic

## RELATED LINKS
[New-AzureRmNetworkWatcherPacketCapture]()
[New-AzureRmPacketCaptureFilterConfig]()
[Get-AzureRmNetworkWatcherPacketCapture]()
[Remove-AzureRmNetworkWatcherPacketCapture]()

[New-AzureRmNetworkWatcher]()
[Get-AzureRmNetworkWatcher]()
[Remove-AzureRmNetworkWatcher]()

[Test-AzureRmNetworkWatcherIPFlow]()
[Get-AzureRmNetworkWatcherNextHop]()
[Get-AzureRmNetworkWatcherSecurityGroupView]()
[Get-AzureRmNetworkWatcherTopology]()
[Start-AzureRmNetworkWatcherResourceTroubleshooting]()
