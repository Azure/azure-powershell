### Example 1: Deletes the specified Managed Certificate.
```powershell
Remove-AzContainerAppManagedCert -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-managedcert
```

Deletes the specified Managed Certificate.

### Example 2: Deletes the specified Managed Certificate.
```powershell
$managedcert = Get-AzContainerAppManagedCert -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-managedcert

Remove-AzContainerAppManagedCert -InputObject $managedcert
```

Deletes the specified Managed Certificate.