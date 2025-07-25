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