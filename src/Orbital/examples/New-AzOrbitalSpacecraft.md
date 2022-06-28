### Example 1: Creates or updates a spacecraft resource.
```powershell
$linkObject = New-AzOrbitalSpacecraftLinkObject -BandwidthMHz 50 -CenterFrequencyMHz 50 -Direction 'uplink' -Name spacecraftlink -Polarization 'LHCP'

New-AzOrbitalSpacecraft -Name azps-orbitalspacecraft -ResourceGroupName azpstest-gp -Location westus2 -Link $linkObject -NoradId 12345 -TitleLine "ISS (ZARYA)" -TleLine1 "1 25544U 98067A   08264.51782528 -.00002182  00000-0 -11606-4 0  2927" -TleLine2 "2 25544  51.6416 247.4627 0006703 130.5360 325.0288 15.72125391563537"
```

```output
Name                   Location NoradId TitleLine   ResourceGroupName
----                   -------- ------- ---------   -----------------
azps-orbitalspacecraft eastus   12345   ISS (ZARYA) azpstest-gp
```

Creates or updates a spacecraft resource.