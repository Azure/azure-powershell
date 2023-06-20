### Example 1: Creates a contact.
```powershell
$dateS = Get-Date -Year 2023 -Month 5 -Day 10 -Hour 11 -Minute 06 -Second 07
$dateE = Get-Date -Year 2023 -Month 5 -Day 10 -Hour 11 -Minute 16 -Second 21

New-AzOrbitalSpacecraftContact -Name azps-orbital-contact -ResourceGroupName azpstest-gp -SpacecraftName SwedenAQUASpacecraft -ContactProfileId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.Orbital/contactProfiles/Sweden-contactprofile" -GroundStationName "Microsoft_Gavle" -ReservationStartTime $dateS -ReservationEndTime $dateE
```

```output
Name                 GroundStationName Status    ReservationStartTime ReservationEndTime   ResourceGroupName
----                 ----------------- ------    -------------------- ------------------   -----------------
azps-orbital-contact Microsoft_Gavle   scheduled 5/10/2023 3:06:07 AM 5/10/2023 3:16:21 AM azpstest-gp
```

Creates a contact.