### Example 1: Returns list of available contacts.
```powershell
$dateS = Get-Date -Day 22 -Month 7
$dateE = Get-Date -Day 23 -Month 7

Get-AzOrbitalAvailableSpacecraftContact -Name AQUA -ResourceGroupName azpstest-gp -EndTime $dateE -StartTime $dateS -GroundStationName WESTUS2_1 -ContactProfileId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.Orbital/contactProfiles/azps-orbital-contactprofile
```

```output
GroundStationName StartAzimuthDegree EndAzimuthDegree StartElevationDegree EndElevationDegree MaximumElevationDegree RxStartTime            RxEndTime
----------------- ------------------ ---------------- -------------------- ------------------ ---------------------- -----------            ---------
WESTUS2_1         33.65817           156.5579         10                   10                 29.905                 2022-07-22 09:14:48 AM 2022-07-22 09:23:09 AM
WESTUS2_1         358.0121           228.2359         10                   10                 35.335                 2022-07-22 10:52:26 AM 2022-07-22 11:01:04 AM
WESTUS2_1         141.8587           357.0999         10                   10                 46.502                 2022-07-22 08:23:26 AM 2022-07-22 08:32:32 AM
WESTUS2_1         215.2225           319.5766         10                   10                 22.735                 2022-07-22 10:02:11 AM 2022-07-22 10:09:42 AM
```

Returns list of available contacts.
A contact is available if the spacecraft is visible from the ground station for more than the minimum viable contact duration provided in the contact profile.