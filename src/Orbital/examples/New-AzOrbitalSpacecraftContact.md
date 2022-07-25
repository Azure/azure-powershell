### Example 1: Creates a contact.
```powershell
$dateS = Get-Date -Day 22
$dateE = Get-Date -Day 23

New-AzOrbitalSpacecraftContact -Name azps-orbital-contact -ResourceGroupName azpstest-gp -SpacecraftName AQUA -ContactProfileId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.Orbital/contactProfiles/azps-orbital-contactprofile" -GroundStationName "WESTUS2_1" -ReservationStartTime $dateS -ReservationEndTime $dateE
```

```output
Name                 GroundStationName Status    ReservationStartTime     ReservationEndTime     ResourceGroupName
----                 ----------------- ------    --------------------     ------------------     -----------------
azps-orbital-contact WESTUS2_1         scheduled 2022-06-23 09:13:05 AM   2022-06-24 09:13:10 AM azpstest-gp
```

Creates a contact.