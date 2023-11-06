### Example 1: Get the specified Managed Certificate.
```powershell
Get-AzContainerAppManagedCert -EnvName azps-env -Name azps-managedcert -ResourceGroupName azps_test_group_app
```

```output
Name             SubjectName   Location ResourceGroupName   DomainControlValidation
----             -----------   -------- -----------------   -----------------------
azps-managedcert mycertweb.com East US  azps_test_group_app TXT
```

Get the specified Managed Certificate.

### Example 2: Get the specified Managed Certificate.
```powershell
Get-AzContainerAppManagedCert -EnvName azps-env -ResourceGroupName azps_test_group_app
```

```output
Name             SubjectName   Location ResourceGroupName   DomainControlValidation
----             -----------   -------- -----------------   -----------------------
azps-managedcert mycertweb.com East US  azps_test_group_app TXT
```

Get the specified Managed Certificate.