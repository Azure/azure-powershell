### Example 1: Returns list of available contacts.
```powershell
$dateS = Get-Date -Day 9 -Month 5 -AsUTC
$dateE = Get-Date -Day 10 -Month 5 -AsUTC

Get-AzOrbitalAvailableSpacecraftContact -Name SwedenAQUASpacecraft -ResourceGroupName azpstest-gp -EndTime $dateE -StartTime $dateS -GroundStationName Microsoft_Gavle -ContactProfileId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.Orbital/contactProfiles/Sweden-contactprofile
```

```output
GroundStationName StartAzimuthDegree EndAzimuthDegree StartElevationDegree EndElevationDegree MaximumElevationDegree RxStartTime          RxEndTime
----------------- ------------------ ---------------- -------------------- ------------------ ---------------------- -----------          ---------
Microsoft_Gavle   13.77217           225.1679         4.999997             5.005328           44.586                 5/9/2023 2:24:07 AM  5/9/2023 2:35:15 AM
Microsoft_Gavle   8.178263           275.0042         4.999985             5.018794           14.834                 5/9/2023 4:02:13 AM  5/9/2023 4:10:34 AM
Microsoft_Gavle   4.437663           325.7795         4.999995             5.013724           6.46                   5/9/2023 5:40:23 AM  5/9/2023 5:44:10 AM
Microsoft_Gavle   22.93799           355.8058         5.000004             5.007165           5.71                   5/9/2023 7:16:26 AM  5/9/2023 7:19:06 AM
Microsoft_Gavle   73.33928           352.9607         5.000013             5.031366           11.955                 5/9/2023 8:49:49 AM  5/9/2023 8:57:12 AM
Microsoft_Gavle   123.3645           347.7329         4.999993             5.041272           33.262                 5/9/2023 10:24:39 AM 5/9/2023 10:35:21 AM
Microsoft_Gavle   173.6422           340.1027         4.999974             5.024394           61.188                 5/9/2023 12:01:46 PM 5/9/2023 12:13:15 PM
Microsoft_Gavle   231.5447           325.2475         4.999982             5.020995           14.006                 5/9/2023 1:42:01 PM  5/9/2023 1:50:22 PM
Microsoft_Gavle   30.4992            141.2818         5.000002             5.04285            18.785                 5/9/2023 11:50:46 PM 5/10/2023 12:00:14 AM
Microsoft_Gavle   18.08898           196.4807         4.999971             5.052687           82.019                 5/10/2023 1:28:09 AM 5/10/2023 1:39:43 AM
```

Returns list of available contacts.
A contact is available if the spacecraft is visible from the ground station for more than the minimum viable contact duration provided in the contact profile.