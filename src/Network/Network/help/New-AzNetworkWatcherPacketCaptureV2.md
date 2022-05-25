---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzNetworkWatcherPacketCaptureV2

## SYNOPSIS
V2 Version of Packet Capture Cmdlet which creates a new packet capture resource and starts a packet capture session on a VM, VMSS or few instances of VMSS.

## SYNTAX

### SetByResource (Default)
```
New-AzNetworkWatcherPacketCaptureV2 -NetworkWatcher <PSNetworkWatcher> -PacketCaptureName <String>
 -TargetId <String> [-StorageAccountId <String>] [-StoragePath <String>] [-LocalFilePath <String>]
 [-BytesToCapturePerPacket <Int32>] [-TotalBytesPerSession <Int32>] [-TimeLimitInSeconds <Int32>]
 [-Scope <PSPacketCaptureMachineScope>] [-TargetType <String>] [-Filter <PSPacketCaptureFilter[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByName
```
New-AzNetworkWatcherPacketCaptureV2 -NetworkWatcherName <String> -ResourceGroupName <String>
 -PacketCaptureName <String> -TargetId <String> [-StorageAccountId <String>] [-StoragePath <String>]
 [-LocalFilePath <String>] [-BytesToCapturePerPacket <Int32>] [-TotalBytesPerSession <Int32>]
 [-TimeLimitInSeconds <Int32>] [-Scope <PSPacketCaptureMachineScope>] [-TargetType <String>]
 [-Filter <PSPacketCaptureFilter[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByLocation
```
New-AzNetworkWatcherPacketCaptureV2 -Location <String> -PacketCaptureName <String> -TargetId <String>
 [-StorageAccountId <String>] [-StoragePath <String>] [-LocalFilePath <String>]
 [-BytesToCapturePerPacket <Int32>] [-TotalBytesPerSession <Int32>] [-TimeLimitInSeconds <Int32>]
 [-Scope <PSPacketCaptureMachineScope>] [-TargetType <String>] [-Filter <PSPacketCaptureFilter[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzNetworkWatcherPacketCaptureV2 cmdlet creates a new packet capture resource and starts a packet capture session on a VM, VMSS or few instances of VMSS.
The length of the Packet Capture sessions can be configured via a time constraint or a size constraint. The amount of data captured for each packet can also be configured.
Filters can be applied to a given packet capture session, allowing you to customize the type of packets captured. Filters can restrict packets on local and remote IP addresses & address ranges, local and remote ports & port ranges, and the session level protocol to be captured. Filters are composable, and multiple filters can be applied to provide you with granularity of capture.

## EXAMPLES

### Example 1: Create a Packet Capture on a VM
```
$nw = Get-AzResource | Where {$_.ResourceType -eq "Microsoft.Network/networkWatchers" -and $_.Location -eq "WestCentralUS" } 
$networkWatcher = Get-AzNetworkWatcher -Name $nw.Name -ResourceGroupName $nw.ResourceGroupName 

$storageAccount = Get-AzStorageAccount -ResourceGroupName contosoResourceGroup -Name contosostorage123

$filter1 = New-AzPacketCaptureFilterConfig -Protocol TCP -RemoteIPAddress "1.1.1.1-255.255.255" -LocalIPAddress "10.0.0.3" -LocalPort "1-65535" -RemotePort "20;80;443"
$filter2 = New-AzPacketCaptureFilterConfig -Protocol UDP 
New-AzNetworkWatcherPacketCaptureV2 -NetworkWatcher $networkWatcher -TargetId $vm.Id -TargetType "azurevm" -PacketCaptureName "PacketCaptureTest" -StorageAccountId $storageAccount.id -TimeLimitInSeconds 60 -Filter $filter1, $filter2
```

In this example we create a packet capture named "PacketCaptureTest" with multiple filters and a time limit. Once the session is complete, it will be saved to the specified storage account. 
Note: The Azure Network Watcher extension must be installed on the target virtual machine to create packet captures.

### Example 2: Create a Packet Capture on a VMSS
```
$nw = Get-AzResource | Where {$_.ResourceType -eq "Microsoft.Network/networkWatchers" -and $_.Location -eq "WestCentralUS" } 
$networkWatcher = Get-AzNetworkWatcher -Name $nw.Name -ResourceGroupName $nw.ResourceGroupName 

$storageAccount = Get-AzStorageAccount -ResourceGroupName contosoResourceGroup -Name contosostorage123

$filter1 = New-AzPacketCaptureFilterConfig -Protocol TCP -RemoteIPAddress "1.1.1.1-255.255.255" -LocalIPAddress "10.0.0.3" -LocalPort "1-65535" -RemotePort "20;80;443"
$filter2 = New-AzPacketCaptureFilterConfig -Protocol UDP 
New-AzNetworkWatcherPacketCaptureV2 -NetworkWatcher $networkWatcher -TargetId $vmss.Id -TargetType "azurevmss" -PacketCaptureName "PacketCaptureTest" -StorageAccountId $storageAccount.id -TimeLimitInSeconds 60 -Filter $filter1, $filter2
```

In this example we create a packet capture named "PacketCaptureTest" with multiple filters and a time limit. Once the session is complete, it will be saved to the specified storage account. 
Note: The Azure Network Watcher extension must be installed on the target virtual machine scale set and all the respective instances adhering to the latest vmss model, to create packet captures.

### Example 3: Create a Packet Capture on few Instances of VMSS
```
$nw = Get-AzResource | Where {$_.ResourceType -eq "Microsoft.Network/networkWatchers" -and $_.Location -eq "WestCentralUS" } 
$networkWatcher = Get-AzNetworkWatcher -Name $nw.Name -ResourceGroupName $nw.ResourceGroupName 

$storageAccount = Get-AzStorageAccount -ResourceGroupName contosoResourceGroup -Name contosostorage123

$filter1 = New-AzPacketCaptureFilterConfig -Protocol TCP -RemoteIPAddress "1.1.1.1-255.255.255" -LocalIPAddress "10.0.0.3" -LocalPort "1-65535" -RemotePort "20;80;443"
$filter2 = New-AzPacketCaptureFilterConfig -Protocol UDP 

$instance1 = $vmssInstance1.Name
$instance2 = $vmssInstance2.Name
$scope = New-AzPacketCaptureScopeConfig -Include $instance1, $instance2

New-AzNetworkWatcherPacketCaptureV2 -NetworkWatcher $networkWatcher -TargetId $vmss.Id -TargetType "azurevmss" -Scope $scope -PacketCaptureName "PacketCaptureTest" -StorageAccountId $storageAccount.id -TimeLimitInSeconds 60 -Filter $filter1, $filter2
```

In this example we create a packet capture named "PacketCaptureTest" with multiple filters and a time limit. Once the session is complete, it will be saved to the specified storage account. 
Note: The Azure Network Watcher extension must be installed on the target virtual machine scale set and on the respective instances in include scope adhering to the latest vmss model, to create packet captures.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -BytesToCapturePerPacket
Bytes to capture per packet.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -Filter
Filters for packet capture session.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSPacketCaptureFilter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalFilePath
Local file path.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -NetworkWatcher
The network watcher resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSNetworkWatcher
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
Type: System.String
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
Scope of VMSS Instances to be Included or Excluded.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSPacketCaptureMachineScope
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountId
Storage account Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StoragePath
Storage path.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetId
The target virtual machine ID or virtual machine scale set ID

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetType
Target Type of the Resource.

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

### -TimeLimitInSeconds
Time limit in seconds.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TotalBytesPerSession
Total bytes per session.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Network.Models.PSNetworkWatcher

### System.String

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSPacketCaptureResult

## NOTES

## RELATED LINKS
