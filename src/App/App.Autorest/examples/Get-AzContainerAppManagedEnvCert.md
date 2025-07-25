### Example 1: List the specified Certificate by env name.
```powershell
Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azps_test_group_app
```

```output
Name          Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          -------- ------              ----------------- -----------         ----------                               -----------------
azps-env-cert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com F61C9A8C53D0500F819463A66C5921AA09E1B787 azps_test_group_app
```

List the specified Certificate by env name.

### Example 2: Get the specified Certificate by name.
```powershell
Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-env-cert
```

```output
Name          Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          -------- ------              ----------------- -----------         ----------                               -----------------
azps-env-cert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com F61C9A8C53D0500F819463A66C5921AA09E1B787 azps_test_group_app
```

Get the specified Certificate by name.

### Example 3: Get the specified Certificate.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app
Get-AzContainerAppManagGet-AzContainerAppManagedEnvCert -ManagedEnvironmentInputObject $managedenv -Name azps-env-cert
```

```output
Name          Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          -------- ------              ----------------- -----------         ----------                               -----------------
azps-env-cert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com F61C9A8C53D0500F819463A66C5921AA09E1B787 azps_test_group_app
```

Get the specified Certificate.