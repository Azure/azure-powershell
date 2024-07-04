### Example 1: Check the feasibility of given profile which is going to be migrated
```powershell
Test-AzCdnProfileMigrationCompatiability  -ProfileName cli-test-profile -ResourceGroupName cli-test-rg
```

```output
CanMigrate DefaultSku              Error
---------- ----------              -----
True       Standard_AzureFrontDoor {}
```

check whether this profile can be migrated to AFDX
