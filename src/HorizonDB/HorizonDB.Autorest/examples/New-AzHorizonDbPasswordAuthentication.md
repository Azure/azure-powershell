### Example 1: Configure password authentication
```powershell
$password = Read-Host -Prompt 'Enter the administrator password' -AsSecureString
New-AzHorizonDbPasswordAuthentication -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -AdministratorLogin 'adminlogin1' -AdministratorLoginPassword $password -State 'Enabled' | Format-List -Property Name, AdministratorLogin, State, ProvisioningState
```

```output
Name               : passwordMethod
AdministratorLogin : adminlogin1
State              : Enabled
ProvisioningState  : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
