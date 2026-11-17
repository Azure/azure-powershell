### Example 1: List authentication configurations for a cluster
```powershell
Get-AzHorizonDbAuthentication -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, State, ProvisioningState
```

```output
Name              : passwordMethod
State             : Disabled
ProvisioningState : Succeeded

Name              : microsoftEntra
State             : Disabled
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
