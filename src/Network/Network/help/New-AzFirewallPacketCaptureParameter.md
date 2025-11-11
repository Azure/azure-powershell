---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azfirewallpacketcaptureparameter
schema: 2.0.0
---

# New-AzFirewallPacketCaptureParameter

## SYNOPSIS
Create a Packet Capture Parameter for Azure Firewall

## SYNTAX

```
New-AzFirewallPacketCaptureParameter [-DurationInSeconds <UInt32>] [-NumberOfPacketsToCapture <UInt32>]
 [-SasUrl <String>] [-FileName <String>] [-Protocol <String>] [-Flag <String[]>]
 [-Filter <PSAzureFirewallPacketCaptureRule[]>] -Operation <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Packet Capture Parameter for Azure Firewall. The operation parameter is mandatory. All other parameters are only mandatory for Start operations and can be omitted for Status and Stop packet capture operations

## EXAMPLES

### Example 1: Configuring Azure Firewall Packet Capture with Advanced Rules and Parameters for start operation
```powershell
$filter1 = New-AzFirewallPacketCaptureRule -Source "10.0.0.2","192.123.12.1" -Destination "172.32.1.2" -DestinationPort "80","443"
$filter2 = New-AzFirewallPacketCaptureRule -Source "10.0.0.5" -Destination "172.20.10.2" -DestinationPort "80","443"
# Create the firewall packet capture parameters
$Params = New-AzFirewallPacketCaptureParameter  -DurationInSeconds 300 -NumberOfPacketsToCapture 5000 -SASUrl "ValidSasUrl" -Filename "AzFwPacketCapture" -Flag "Syn","Ack" -Protocol "Any" -Filter $Filter1, $Filter2 -Operation "Start"
```

This creates the parameters used for starting a packet capture on the azure firewall

### Example 2: Configuring Azure Firewall Packet Capture for status operation
```powershell
# Create the firewall packet capture parameters to check Status operation
$Params = New-AzFirewallPacketCaptureParameter -Operation "Status"
```

This creates the parameters used for getting the status of a packet capture operation on the azure firewall

### Example 3: Configuring Azure Firewall Packet Capture for stop operation
```powershell
# Create the firewall packet capture parameters to check Status operation
$Params = New-AzFirewallPacketCaptureParameter -Operation "Stop"
```

This creates the parameters used for stopping a packet capture operation on the azure firewall 

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

### -DurationInSeconds
The intended durations of packet capture in seconds

```yaml
Type: System.Nullable`1[System.UInt32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileName
Name of packet capture file

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

### -Filter
The list of filters to capture

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPacketCaptureRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Flag
The list of tcp-flags to capture

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NumberOfPacketsToCapture
The intended number of packets to capture

```yaml
Type: System.Nullable`1[System.UInt32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Operation
The packet capture operation to run

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Start, Status, Stop

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
The Protocols to capture

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Any, TCP, UDP, ICMP

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SasUrl
Upload capture storage container SASURL with write and delete permissions

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

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPacketCaptureParameters

## NOTES

## RELATED LINKS
