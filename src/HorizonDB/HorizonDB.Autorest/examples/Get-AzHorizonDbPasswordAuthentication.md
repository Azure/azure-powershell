### Example 1: Get the password authentication configuration
```powershell
Get-AzHorizonDbPasswordAuthentication -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, AdministratorLogin, State, ProvisioningState
```

```output
Name               : passwordMethod
AdministratorLogin : adminlogin1
State              : Enabled
ProvisioningState  : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
