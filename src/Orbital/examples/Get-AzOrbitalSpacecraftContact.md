### Example 1: Get the specified contact.
```powershell
Get-AzOrbitalSpacecraftContact -Name azps-orbital-contact -ResourceGroupName azpstest-gp -SpacecraftName AQUA
```

```output
Name                 GroundStationName Status    ReservationStartTime     ReservationEndTime     ResourceGroupName
----                 ----------------- ------    --------------------     ------------------     -----------------
azps-orbital-contact KSAT_SVALBARD     scheduled 2022-06-23 09:13:05 AM   2022-06-24 09:13:10 AM azpstest-gp
```

Get the specified contact.