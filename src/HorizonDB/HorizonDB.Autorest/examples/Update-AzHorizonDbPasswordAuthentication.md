### Example 1: Reset the administrator password
```powershell
$password = Read-Host -Prompt 'Enter the new administrator password' -AsSecureString
Update-AzHorizonDbPasswordAuthentication -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -AdministratorLoginPassword $password | Format-List -Property Name, AdministratorLogin, State, ProvisioningState
```

```output
Name               : passwordMethod
AdministratorLogin : adminlogin1
State              : Enabled
ProvisioningState  : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Enable password authentication
```powershell
$password = Read-Host -Prompt 'Enter the administrator password' -AsSecureString
Update-AzHorizonDbPasswordAuthentication -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -State 'Enabled' -AdministratorLoginPassword $password | Format-List -Property Name, AdministratorLogin, State, ProvisioningState
```

```output
Name               : passwordMethod
AdministratorLogin : adminlogin1
State              : Enabled
ProvisioningState  : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Disable password authentication
```powershell
Update-AzHorizonDbPasswordAuthentication -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -State 'Disabled' | Format-List -Property Name, AdministratorLogin, State, ProvisioningState
```

```output
Name               : passwordMethod
AdministratorLogin : adminlogin1
State              : Disabled
ProvisioningState  : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
