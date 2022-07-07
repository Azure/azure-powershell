### Example 1: Creates or updates a spacecraft resource.
```powershell
$linkObject = New-AzOrbitalSpacecraftLinkObject -BandwidthMHz 15 -CenterFrequencyMHz 8160 -Direction 'Downlink' -Name spacecraftlink -Polarization 'RHCP'

New-AzOrbitalSpacecraft -Name azps-orbitalspacecraft -ResourceGroupName azpstest-gp -Location westus2 -Link $linkObject -NoradId 27424 -TitleLine "AQUA" -TleLine1 "1 27424U 02022A   21259.45143715  .00000131  00000-0  39210-4 0  9998" -TleLine2 "2 27424  98.2138 199.4906 0001886  51.3958  60.0011 14.57112434 30322"
```

```output
Name                   Location NoradId TitleLine ResourceGroupName
----                   -------- ------- --------- -----------------
azps-orbitalspacecraft westus2  27424   AQUA      azpstest-gp
```

Creates or updates a spacecraft resource.