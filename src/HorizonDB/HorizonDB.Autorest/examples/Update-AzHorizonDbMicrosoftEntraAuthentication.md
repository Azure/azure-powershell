### Example 1: Enable Microsoft Entra authentication
```powershell
Update-AzHorizonDbMicrosoftEntraAuthentication -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -State 'Enabled' | Format-List -Property Name, State, ProvisioningState
```

```output
Name              : microsoftEntra
State             : Enabled
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Disable Microsoft Entra authentication
```powershell
Update-AzHorizonDbMicrosoftEntraAuthentication -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -State 'Disabled' | Format-List -Property Name, State, ProvisioningState
```

```output
Name              : microsoftEntra
State             : Disabled
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
