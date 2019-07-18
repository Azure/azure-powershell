---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-aznetworkwatcherpacketcapture
schema: 2.0.0
---

# New-AzNetworkWatcherPacketCapture

## SYNOPSIS
Create and start a packet capture on the specified VM.

## SYNTAX

### Create (Default)
```
New-AzNetworkWatcherPacketCapture -Name <String> -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Parameter <IPacketCapture>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzNetworkWatcherPacketCapture -Name <String> -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -TargetResourceId <String> [-BytesToCapturePerPacket <Int32>]
 [-Filter <IPacketCaptureFilter[]>] [-StorageAccountId <String>] [-StorageFilePath <String>]
 [-StoragePathUri <String>] [-TimeLimitInSeconds <Int32>] [-TotalBytesPerSession <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzNetworkWatcherPacketCapture -InputObject <INetworkIdentity> -TargetResourceId <String>
 [-BytesToCapturePerPacket <Int32>] [-Filter <IPacketCaptureFilter[]>] [-StorageAccountId <String>]
 [-StorageFilePath <String>] [-StoragePathUri <String>] [-TimeLimitInSeconds <Int32>]
 [-TotalBytesPerSession <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzNetworkWatcherPacketCapture -InputObject <INetworkIdentity> [-Parameter <IPacketCapture>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create and start a packet capture on the specified VM.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BytesToCapturePerPacket
Number of bytes captured per packet, the remaining bytes are truncated.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Filter
A list of packet capture filters.
To construct, see NOTES section for FILTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the packet capture session.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: PacketCaptureName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkWatcherName
The name of the network watcher.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Parameters that define the create packet capture operation.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCapture
Parameter Sets: Create, CreateViaIdentity
Aliases: NetworkWatcher

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: Location

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StorageAccountId
The ID of the storage account to save the packet capture session.
Required if no local file path is provided.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StorageFilePath
A valid local path on the targeting VM.
Must include the name of the capture file (*.cap).
For linux virtual machine it must start with /var/captures.
Required if no storage ID is provided, otherwise optional.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: LocalFilePath

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StoragePathUri
The URI of the storage path to save the packet capture.
Must be a well-formed URI describing the location to save the packet capture.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: StoragePath

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceId
The ID of the targeted resource, only VM is currently supported.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: TargetVirtualMachineId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TimeLimitInSeconds
Maximum duration of the capture session in seconds.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TotalBytesPerSession
Maximum size of the capture output.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCapture

## OUTPUTS

### System.Boolean

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### FILTER <IPacketCaptureFilter[]>: A list of packet capture filters.
  - `[LocalIPAddress <String>]`: Local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range. "127.0.0.1;127.0.0.5"? for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
  - `[LocalPort <String>]`: Local port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
  - `[Protocol <PcProtocol?>]`: Protocol to be filtered on.
  - `[RemoteIPAddress <String>]`: Local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range. "127.0.0.1;127.0.0.5;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
  - `[RemotePort <String>]`: Remote port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.

#### PARAMETER <IPacketCapture>: Parameters that define the create packet capture operation.
  - `Target <String>`: The ID of the targeted resource, only VM is currently supported.
  - `[BytesToCapturePerPacket <Int32?>]`: Number of bytes captured per packet, the remaining bytes are truncated.
  - `[Filter <IPacketCaptureFilter[]>]`: A list of packet capture filters.
    - `[LocalIPAddress <String>]`: Local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range. "127.0.0.1;127.0.0.5"? for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
    - `[LocalPort <String>]`: Local port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
    - `[Protocol <PcProtocol?>]`: Protocol to be filtered on.
    - `[RemoteIPAddress <String>]`: Local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range. "127.0.0.1;127.0.0.5;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
    - `[RemotePort <String>]`: Remote port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
  - `[StorageLocationFilePath <String>]`: A valid local path on the targeting VM. Must include the name of the capture file (*.cap). For linux virtual machine it must start with /var/captures. Required if no storage ID is provided, otherwise optional.
  - `[StorageLocationStorageId <String>]`: The ID of the storage account to save the packet capture session. Required if no local file path is provided.
  - `[StorageLocationStoragePath <String>]`: The URI of the storage path to save the packet capture. Must be a well-formed URI describing the location to save the packet capture.
  - `[TimeLimitInSecond <Int32?>]`: Maximum duration of the capture session in seconds.
  - `[TotalBytesPerSession <Int32?>]`: Maximum size of the capture output.

## RELATED LINKS

