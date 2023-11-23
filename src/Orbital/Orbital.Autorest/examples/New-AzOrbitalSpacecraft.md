### Example 1: Creates or updates a spacecraft resource.
```powershell
$linkObject = New-AzOrbitalSpacecraftLinkObject -BandwidthMHz 15 -CenterFrequencyMHz 8160 -Direction 'Downlink' -Name spacecraftlink -Polarization 'RHCP'

New-AzOrbitalSpacecraft -Name AQUA -ResourceGroupName azpstest-gp -Location westus2 -Link $linkObject -NoradId 27424 -TitleLine "AQUA" -TleLine1 "1 27424U 02022A   23128.13172751  .00001518  00000+0  34030-3 0  9995" -TleLine2 "2 27424  98.2850  72.6931 0000969  56.1431 359.6436 14.58017750117525"
```

```output
Name Location NoradId TitleLine ResourceGroupName
---- -------- ------- --------- -----------------
AQUA westus2  27424   AQUA      azpstest-gp
```

Creates or updates a spacecraft resource. Get an up-to-date Two-Line Element (TLE) for spacecraft by checking CelesTrak.