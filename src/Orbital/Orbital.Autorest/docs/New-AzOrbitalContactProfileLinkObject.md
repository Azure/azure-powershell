---
external help file:
Module Name: Az.Orbital
online version: https://learn.microsoft.com/powershell/module/Az.Orbital/new-azorbitalcontactprofilelinkobject
schema: 2.0.0
---

# New-AzOrbitalContactProfileLinkObject

## SYNOPSIS
Create an in-memory object for ContactProfileLink.

## SYNTAX

```
New-AzOrbitalContactProfileLinkObject -Channel <IContactProfileLinkChannel[]> -Direction <String>
 -Name <String> -Polarization <String> [-EirpdBw <Single>] [-GainOverTemperature <Single>]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.IContactProfileLinkChannel[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Direction
Direction (Uplink or Downlink).

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

### -EirpdBw
Effective Isotropic Radiated Power (EIRP) in dBW.
It is the required EIRP by the customer.
Not used yet.

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
Gain to noise temperature in db/K.
It is the required G/T by the customer.
Not used yet.

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
Polarization.
e.g.
(RHCP, LHCP).

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

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.ContactProfileLink

## NOTES

## RELATED LINKS

