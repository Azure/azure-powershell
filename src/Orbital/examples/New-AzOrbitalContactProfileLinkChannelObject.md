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