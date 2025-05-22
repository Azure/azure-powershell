---
external help file: Az.Orbital-help.xml
Module Name: Az.Orbital
online version: https://learn.microsoft.com/powershell/module/Az.Orbital/new-azorbitalcontactprofilelinkchannelobject
schema: 2.0.0
---

# New-AzOrbitalContactProfileLinkChannelObject

## SYNOPSIS
Create an in-memory object for ContactProfileLinkChannel.

## SYNTAX

```
New-AzOrbitalContactProfileLinkChannelObject -BandwidthMHz <Single> -CenterFrequencyMHz <Single>
 -EndPointIPAddress <String> -EndPointName <String> -EndPointPort <String> -EndPointProtocol <String>
 -Name <String> [-DecodingConfiguration <String>] [-DemodulationConfiguration <String>]
 [-EncodingConfiguration <String>] [-ModulationConfiguration <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ContactProfileLinkChannel.

## EXAMPLES

### Example 1: Create a ContactProfileLinkChannel object.
```powershell
New-AzOrbitalContactProfileLinkChannelObject -BandwidthMHz 0.036 -CenterFrequencyMHz 2106.4063 -EndPointIPAddress 10.0.1.0 -EndPointName AQUA_command -EndPointPort 4000 -EndPointProtocol TCP -Name channel1 -DecodingConfiguration na -DemodulationConfiguration na -EncodingConfiguration AQUA_CMD_CCSDS -ModulationConfiguration AQUA_UPLINK_BPSK
```

```output
BandwidthMHz CenterFrequencyMHz DecodingConfiguration DemodulationConfiguration EncodingConfiguration ModulationConfiguration Name
------------ ------------------ --------------------- ------------------------- --------------------- ----------------------- ----
0.036        2106.406           na                    na                        AQUA_CMD_CCSDS        AQUA_UPLINK_BPSK        channel1
```

Create a ContactProfileLinkChannel object.

## PARAMETERS

### -BandwidthMHz
Bandwidth in MHz.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CenterFrequencyMHz
Center Frequency in MHz.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecodingConfiguration
Currently unused.

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

### -DemodulationConfiguration
Copy of the modem configuration file such as Kratos QRadio or Kratos QuantumRx.
Only valid for downlink directions.
If provided, the modem connects to the customer endpoint and sends demodulated data instead of a VITA.49 stream.

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

### -EncodingConfiguration
Currently unused.

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

### -EndPointIPAddress
IP Address (IPv4).

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

### -EndPointName
Name of an end point.

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

### -EndPointPort
TCP port to listen on to receive data.

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

### -EndPointProtocol
Protocol either UDP or TCP.

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

### -ModulationConfiguration
Copy of the modem configuration file such as Kratos QRadio.
Only valid for uplink directions.
If provided, the modem connects to the customer endpoint and accepts commands from the customer instead of a VITA.49 stream.

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

### -Name
Channel name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.ContactProfileLinkChannel

## NOTES

## RELATED LINKS
