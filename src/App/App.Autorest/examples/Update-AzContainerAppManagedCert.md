### Example 1: Patches a managed certificate.
```powershell
Update-AzContainerAppManagedCert -EnvName azps-env -Name azps-managedcert -ResourceGroupName azps_test_group_app -Tag @{"abc"="123"}
```

```output
Name             SubjectName   Location ResourceGroupName   DomainControlValidation
----             -----------   -------- -----------------   -----------------------
azps-managedcert mycertweb.com East US  azps_test_group_app TXT
```

Patches a managed certificate.
Oly patching of tags is supported.