### Example 1: Create a SpacecraftLink object for OrbitalSpacecraft.
```powershell
New-AzOrbitalSpacecraftLinkObject -BandwidthMHz 50 -CenterFrequencyMHz 50 -Direction 'Uplink' -Name spacecraftlink -Polarization 'LHCP'
```

```output
BandwidthMHz CenterFrequencyMHz Direction Name           Polarization
------------ ------------------ --------- ----           ------------
50           50                 Uplink    spacecraftlink LHCP
```

Create a SpacecraftLink object for OrbitalSpacecraft.