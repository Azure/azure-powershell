### Example 1: Create a NIC object for test migration.
```powershell
New-AzMigrateTestNicMapping -NicID a2399354-653a-464e-a567-d30ef5467a31 -TestNicSubnet subnet1
```

```output
IsPrimaryNic IsSelectedForMigration NicId                                TargetNicName TargetStaticIPAddress TargetSubnetName TestStaticIPAddress TestSubnetName
------------ ---------------------- -----                                ------------- --------------------- ---------------- ------------------- --------------
                                    a2399354-653a-464e-a567-d30ef5467a31                                                                          subnet1
```

Creates a NIC object for test migration.
