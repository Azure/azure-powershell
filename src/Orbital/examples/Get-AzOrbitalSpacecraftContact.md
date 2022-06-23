### Example 1: List the specified contact in a specified resource group.
```powershell
Get-AzOrbitalSpacecraftContact -ResourceGroupName azpstest-gp -SpacecraftName azps-orbitalspacecraft
```

```output
Name                 GroundStationName Status    ReservationStartTime     ReservationEndTime     ResourceGroupName
----                 ----------------- ------    --------------------     ------------------     -----------------
azps-orbital-contact KSAT_SVALBARD     scheduled 2022-06-23 09:13:05 AM   2022-06-24 09:13:10 AM azpstest-gp
```

List the specified contact in a specified resource group.

### Example 2: Get the specified contact.
```powershell
Get-AzOrbitalSpacecraftContact -Name azps-orbital-contact -ResourceGroupName azpstest-gp -SpacecraftName azps-orbitalspacecraft
```

```output
Name                 GroundStationName Status    ReservationStartTime     ReservationEndTime     ResourceGroupName
----                 ----------------- ------    --------------------     ------------------     -----------------
azps-orbital-contact KSAT_SVALBARD     scheduled 2022-06-23 09:13:05 AM   2022-06-24 09:13:10 AM azpstest-gp
```

Get the specified contact.