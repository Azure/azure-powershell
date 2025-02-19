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
New-AzFirewallPacketCaptureParameter -DurationInSeconds <UInt32> -NumberOfPacketsToCapture <UInt32>
 -SasUrl <String> -FileName <String> [-Protocol <String>] [-Flag <String[]>]
 -Filter <PSAzureFirewallPacketCaptureRule[]> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Packet Capture Parameter for Azure Firewall

## EXAMPLES

### Example 1: Configuring Azure Firewall Packet Capture with Advanced Rules and Parameters
```
$filter1 = New-AzFirewallPacketCaptureRule -Source "10.0.0.2","192.123.12.1" -Destination "172.32.1.2" -DestinationPort "80","443"
$filter2 = New-AzFirewallPacketCaptureRule -Source "10.0.0.5" -Destination "172.20.10.2" -DestinationPort "80","443"

# Create the firewall packet capture parameters
New-AzFirewallPacketCaptureParameter  -DurationInSeconds 300 -NumberOfPacketsToCapture 5000 -SASUrl "ValidSasUrl" -Filename "AzFwPacketCapture" -Flag "Syn","Ack" -Protocol "Any" -Filter $Filter1, $Filter2
```

This creates the parameter for packet capture request with a set of rules.

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
Type: System.UInt32
Parameter Sets: (All)
Aliases:

Required: True
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

Required: True
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

Required: True
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
Type: System.UInt32
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPacketCaptureParameters

## NOTES

## RELATED LINKS
