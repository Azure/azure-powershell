### Example 1: List status by project name.
```powershell
Get-AzMigrateServerMigrationStatus -ResourceGroupName cbtpvtrg -ProjectName migpvt
```

```output
Appliance Server      State                      Progress TimeElapsed TimeRemaining UploadSpeed Health LastSync               Datastore
--------- ------      -----                      -------- ----------- ------------- ----------- ------ --------               ---------
migpvt    CVM-Win2019 DeltaReplication Completed -        -           -             -           Normal 12/7/2023, 11:18:07 AM Shared_1TB, datastore1
migpvt    CVM-Win2022 DeltaReplication Completed -        -           -             -           Normal 12/7/2023, 10:41:42 AM datastore1




To resolve the health issue use the command
Get-AzMigrateServerMigrationStatus -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Health
```

Get by project name.

### Example 2: List status by machine name.
```powershell
Get-AzMigrateServerMigrationStatus -ProjectName "migpvt-ecyproj" -ResourceGroupName "cbtprivatestamprg" -MachineName "CVM-Win2019"
```

```output
Server CVM-Win2019 is currently healthy.

Appliance Server      State                      Progress TimeElapsed TimeRemaining UploadSpeed LastSync               Datastore
--------- ------      -----                      -------- ----------- ------------- ----------- --------               ---------
migpvt    CVM-Win2019 DeltaReplication Completed -        -           -             -           12/7/2023, 11:18:07 AM Shared_1TB, datastore1



Disk        State                      Progress TimeElapsed TimeRemaining UploadSpeed Datastore
----        -----                      -------- ----------- ------------- ----------- ---------
TestVM      DeltaReplication Completed -        -           -             -           Shared_1TB
CVM-Win2019 DeltaReplication Completed -        -           -             -           datastore1
```

Get by machine name.

### Example 2: List status by appliance name.
```powershell
Get-AzMigrateServerMigrationStatus -ProjectName "migpvt-ecyproj" -ResourceGroupName "cbtprivatestamprg" -ApplianceName "migpvt"
```

```output
Server      State                      Progress TimeElapsed TimeRemaining UploadSpeed Health LastSync               Datastore
------      -----                      -------- ----------- ------------- ----------- ------ --------               ---------
CVM-Win2019 DeltaReplication Completed -        -           -             -           Normal 12/7/2023, 11:18:07 AM Shared_1TB, datastore1
CVM-Win2022 DeltaReplication Completed -        -           -             -           Normal 12/7/2023, 10:41:42 AM datastore1


To resolve the health issue use the command
Get-AzMigrateServerMigrationStatus -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Health
```

Get by appliance name.