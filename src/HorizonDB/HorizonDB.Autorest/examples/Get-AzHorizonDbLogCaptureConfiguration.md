### Example 1: List log capture configurations
```powershell
Get-AzHorizonDbLogCaptureConfiguration -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, State, RetentionDay, ProvisioningState
```

```output
Name              : PostgreSqlServer
State             : Enabled
RetentionDay      : 14
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get the PostgreSQL server log capture configuration
```powershell
Get-AzHorizonDbLogCaptureConfiguration -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'PostgreSqlServer' | Format-List -Property Name, State, RetentionDay, ProvisioningState
```

```output
Name              : PostgreSqlServer
State             : Enabled
RetentionDay      : 14
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
