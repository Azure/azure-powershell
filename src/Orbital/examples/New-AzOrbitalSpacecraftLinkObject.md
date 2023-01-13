### Example 1: Create a SpacecraftLink object for OrbitalSpacecraft.
```powershell
New-AzOrbitalSpacecraftLinkObject -BandwidthMHz 50 -CenterFrequencyMHz 50 -Direction 'uplink' -Name spacecraftlink -Polarization 'LHCP'
```

```output
BandwidthMHz CenterFrequencyMHz Direction Name           Polarization
------------ ------------------ --------- ----           ------------
50           50                 uplink    spacecraftlink LHCP
```

Create a SpacecraftLink object for OrbitalSpacecraft.