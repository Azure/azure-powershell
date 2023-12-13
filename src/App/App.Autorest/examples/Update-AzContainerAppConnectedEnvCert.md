### Example 1: Update certificate.
```powershell
Update-AzContainerAppConnectedEnvCert -Name azps-connectedenvcert -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Tag @{"abc"="123"}
```

```output
Name                  Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----                  -------- ------              ----------------- -----------         ----------                               -----------------
azps-connectedenvcert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com B3C038866E6ADBB2F33DFDBEF5C7FC71D339A943 azps_test_group_app
```

Update certificate.

### Example 2: Update certificate.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv
Update-AzContainerAppConnectedEnvCert -Name azps-connectedenvcert -ConnectedEnvironmentInputObject $connectedenv -Tag @{"abc"="123"}
```

```output
Name                  Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----                  -------- ------              ----------------- -----------         ----------                               -----------------
azps-connectedenvcert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com B3C038866E6ADBB2F33DFDBEF5C7FC71D339A943 azps_test_group_app
```

Update certificate.