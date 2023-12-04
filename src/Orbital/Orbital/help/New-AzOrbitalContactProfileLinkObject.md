---
external help file:
Module Name: Az.Orbital
online version: https://learn.microsoft.com/powershell/module/az.Orbital/new-AzOrbitalContactProfileLinkObject
schema: 2.0.0
---

# New-AzOrbitalContactProfileLinkObject

## SYNOPSIS
Create an in-memory object for ContactProfileLink.

## SYNTAX

```
New-AzOrbitalContactProfileLinkObject -Channel <IContactProfileLinkChannel[]> -Direction <Direction>
 -Name <String> -Polarization <Polarization> [-EirpdBw <Single>] [-GainOverTemperature <Single>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ContactProfileLink.

## EXAMPLES

### Example 1: Create a ContactProfileLink object.
```powershell
$linkChannel = New-AzOrbitalContactProfileLinkChannelObject -BandwidthMHz 0.036 -CenterFrequencyMHz 2106.4063 -EndPointIPAddress 10.0.1.0 -EndPointName AQUA_command -EndPointPort 4000 -EndPointProtocol TCP -Name channel1 -DecodingConfiguration na -DemodulationConfiguration na -EncodingConfiguration AQUA_CMD_CCSDS -ModulationConfiguration AQUA_UPLINK_BPSK

New-AzOrbitalContactProfileLinkObject -Channel $linkChannel -Direction uplink -Name RHCP_UL -Polarization RHCP -EirpdBw 45 -GainOverTemperature 0
```

```output
Direction EirpdBw GainOverTemperature Name    Polarization
--------- ------- ------------------- ----    ------------
uplink    45      0                   RHCP_UL RHCP
```

Create a ContactProfileLink object.

## PARAMETERS

### -Channel
Contact Profile Link Channel.
To construct, see NOTES section for CHANNEL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20221101.IContactProfileLinkChannel[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Direction
Direction (uplink or downlink).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Support.Direction
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EirpdBw
Effective Isotropic Radiated Power (EIRP) in dBW.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GainOverTemperature
Gain To Noise Temperature in db/K.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Link name.

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

### -Polarization
polarization.
eg (RHCP, LHCP).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Support.Polarization
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

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20221101.ContactProfileLink

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CHANNEL <IContactProfileLinkChannel[]>`: Contact Profile Link Channel.
  - `BandwidthMHz <Single>`: Bandwidth in MHz.
  - `CenterFrequencyMHz <Single>`: Center Frequency in MHz.
  - `EndPointIPAddress <String>`: IP Address (IPv4).
  - `EndPointName <String>`: Name of an end point.
  - `EndPointPort <String>`: TCP port to listen on to receive data.
  - `EndPointProtocol <Protocol>`: Protocol either UDP or TCP.
  - `Name <String>`: Channel name.
  - `[DecodingConfiguration <String>]`: Currently unused.
  - `[DemodulationConfiguration <String>]`: Copy of the modem configuration file such as Kratos QRadio or Kratos QuantumRx. Only valid for downlink directions. If provided, the modem connects to the customer endpoint and sends demodulated data instead of a VITA.49 stream.
  - `[EncodingConfiguration <String>]`: Currently unused.
  - `[ModulationConfiguration <String>]`: Copy of the modem configuration file such as Kratos QRadio. Only valid for uplink directions. If provided, the modem connects to the customer endpoint and accepts commands from the customer instead of a VITA.49 stream.

## RELATED LINKS

