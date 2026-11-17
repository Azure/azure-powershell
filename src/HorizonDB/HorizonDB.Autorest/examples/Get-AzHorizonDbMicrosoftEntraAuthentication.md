### Example 1: Get the Microsoft Entra authentication configuration
```powershell
Get-AzHorizonDbMicrosoftEntraAuthentication -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, State, ProvisioningState
```

```output
Name              : microsoftEntra
State             : Enabled
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
