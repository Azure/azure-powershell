### Example 1: Get the specified contact in a specified Name.
```powershell
Get-AzOrbitalSpacecraftContact -Name contact-05-09-2023-07:09:41 -ResourceGroupName azpstest-gp -SpacecraftName SwedenAQUASpacecraft
```

```output
Name                        GroundStationName Status    ReservationStartTime ReservationEndTime  ResourceGroupName
----                        ----------------- ------    -------------------- ------------------  -----------------
contact-05-09-2023-07:09:41 Microsoft_Gavle   scheduled 5/9/2023 7:09:41 AM  5/9/2023 7:12:33 AM azpstest-gp
```

Get the specified contact in a specified Name.

### Example 2: List the specified spacecraft contact in specified spacecraft.
```powershell
Get-AzOrbitalSpacecraftContact -ResourceGroupName azpstest-gp -SpacecraftName SwedenAQUASpacecraft
```

```output
Name                        GroundStationName Status    ReservationStartTime ReservationEndTime   ResourceGroupName
----                        ----------------- ------    -------------------- ------------------   -----------------
contact-05-08-2023-03:12:51 Microsoft_Gavle   scheduled 5/8/2023 3:12:51 AM  5/8/2023 3:22:33 AM  azpstest-gp
contact-05-10-2023-01:22:06 Microsoft_Gavle   scheduled 5/10/2023 1:22:06 AM 5/10/2023 1:33:43 AM azpstest-gp
contact-05-09-2023-03:55:36 Microsoft_Gavle   scheduled 5/9/2023 3:55:36 AM  5/9/2023 4:03:46 AM  azpstest-gp
contact-05-09-2023-05:33:49 Microsoft_Gavle   scheduled 5/9/2023 5:33:49 AM  5/9/2023 5:37:20 AM  azpstest-gp
contact-05-09-2023-00:39:33 Microsoft_Gavle   scheduled 5/9/2023 12:39:33 AM 5/9/2023 12:50:53 AM azpstest-gp
contact-05-09-2023-08:43:07 Microsoft_Gavle   scheduled 5/9/2023 8:43:07 AM  5/9/2023 8:50:44 AM  azpstest-gp
contact-05-10-2023-04:38:23 Microsoft_Gavle   scheduled 5/10/2023 4:38:23 AM 5/10/2023 4:44:39 AM azpstest-gp
contact-05-10-2023-03:00:09 Microsoft_Gavle   scheduled 5/10/2023 3:00:09 AM 5/10/2023 3:10:15 AM azpstest-gp
contact-05-09-2023-02:17:26 Microsoft_Gavle   scheduled 5/9/2023 2:17:26 AM  5/9/2023 2:28:31 AM  azpstest-gp
contact-05-09-2023-13:35:52 Microsoft_Gavle   scheduled 5/9/2023 1:35:52 PM  5/9/2023 1:43:57 PM  azpstest-gp
contact-05-09-2023-23:44:37 Microsoft_Gavle   scheduled 5/9/2023 11:44:37 PM 5/9/2023 11:54:23 PM azpstest-gp
contact-05-08-2023-11:12:43 Microsoft_Gavle   scheduled 5/8/2023 11:12:43 AM 5/8/2023 11:24:16 AM azpstest-gp
contact-05-09-2023-11:55:23 Microsoft_Gavle   scheduled 5/9/2023 11:55:23 AM 5/9/2023 12:06:52 PM azpstest-gp
contact-05-08-2023-12:51:37 Microsoft_Gavle   scheduled 5/8/2023 12:51:37 PM 5/8/2023 1:01:53 PM  azpstest-gp
contact-05-08-2023-08:02:19 Microsoft_Gavle   scheduled 5/8/2023 8:02:19 AM  5/8/2023 8:07:57 AM  azpstest-gp
contact-05-09-2023-07:09:41 Microsoft_Gavle   scheduled 5/9/2023 7:09:41 AM  5/9/2023 7:12:33 AM  azpstest-gp
contact-05-10-2023-06:16:21 Microsoft_Gavle   scheduled 5/10/2023 6:16:21 AM 5/10/2023 6:18:01 AM azpstest-gp
contact-05-09-2023-10:18:06 Microsoft_Gavle   scheduled 5/9/2023 10:18:06 AM 5/9/2023 10:28:55 AM azpstest-gp
contact-05-08-2023-23:02:44 Microsoft_Gavle   scheduled 5/8/2023 11:02:44 PM 5/8/2023 11:09:47 PM azpstest-gp
contact-05-08-2023-09:36:30 Microsoft_Gavle   scheduled 5/8/2023 9:36:30 AM  5/8/2023 9:46:11 AM  azpstest-gp
```

Gets the specified spacecraft contact in a specified resource group and specified spacecraft.