### Example 1: Update managed environment certificate.
```powershell
Update-AzContainerAppManagedEnvCert -EnvName azps-env -Name azps-env-cert -ResourceGroupName azps_test_group_app -Tag @{"abc"="123"}
```

```output
Name          Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          -------- ------              ----------------- -----------         ----------                               -----------------
azps-env-cert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com B3C038866E6ADBB2F33DFDBEF5C7FC71D339A943 azps_test_group_app
```

Update managed environment certificate.

### Example 2: Update managed environment certificate.
```powershell
$managedenvcert = Get-AzContainerAppManagedEnvCert -EnvName azps-env -Name azps-env-cert -ResourceGroupName azps_test_group_app

Update-AzContainerAppManagedEnvCert -InputObject $managedenvcert -Tag @{"abc"="123"}
```

```output
Name          Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          -------- ------              ----------------- -----------         ----------                               -----------------
azps-env-cert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com B3C038866E6ADBB2F33DFDBEF5C7FC71D339A943 azps_test_group_app
```

Update managed environment certificate.

### Example 3: Update managed environment certificate.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app

Update-AzContainerAppManagedEnvCert -ManagedEnvironmentInputObject $managedenv -Name azps-env-cert -Tag @{"abc"="123"}
```

```output
Name          Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          -------- ------              ----------------- -----------         ----------                               -----------------
azps-env-cert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com B3C038866E6ADBB2F33DFDBEF5C7FC71D339A943 azps_test_group_app
```

Update managed environment certificate.