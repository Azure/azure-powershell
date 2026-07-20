### Example 1: Updates a contact.
```powershell
Update-AzOrbitalSpacecraftContact -Name azps-orbital-contact -ResourceGroupName azpstest-gp -SpacecraftName SwedenAQUASpacecraft -ContactProfileId "/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/azpstest-gp/providers/Microsoft.Orbital/contactProfiles/Sweden-contactprofile"
```

```output
Name                 GroundStationName Status    ReservationStartTime ReservationEndTime   ResourceGroupName
----                 ----------------- ------    -------------------- ------------------   -----------------
azps-orbital-contact Microsoft_Gavle   scheduled 5/10/2023 3:06:07 AM 5/10/2023 3:16:21 AM azpstest-gp
```

This command updates a contact.

