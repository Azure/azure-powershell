### Example 1: List the specified Certificate by connected env name.
```powershell
Get-AzContainerAppConnectedEnvCert -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app
```

```output
Name                  Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----                  -------- ------              ----------------- -----------         ----------                               -----------------
azps-connectedenvcert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com F61C9A8C53D0500F819463A66C5921AA09E1B787 azps_test_group_app
```

List the specified Certificate by connected env name.

### Example 2: Get the specified Certificate by name.
```powershell
Get-AzContainerAppConnectedEnvCert -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvcert
```

```output
Name                  Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----                  -------- ------              ----------------- -----------         ----------                               -----------------
azps-connectedenvcert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com F61C9A8C53D0500F819463A66C5921AA09E1B787 azps_test_group_app
```

Get the specified Certificate by name.

### Example 3: Get the specified Certificate.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv
Get-AzContainerAppConnectedEnvCert -ConnectedEnvironmentInputObject $connectedenv -Name azps-connectedenvcert
```

```output
Name                  Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----                  -------- ------              ----------------- -----------         ----------                               -----------------
azps-connectedenvcert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com F61C9A8C53D0500F819463A66C5921AA09E1B787 azps_test_group_app
```

Get the specified Certificate.