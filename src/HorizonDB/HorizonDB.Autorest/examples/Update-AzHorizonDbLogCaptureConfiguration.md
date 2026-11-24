### Example 1: Disable PostgreSQL server log capture
```powershell
Update-AzHorizonDbLogCaptureConfiguration -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'PostgreSqlServer' -State 'Disabled' | Format-List -Property Name, State, RetentionDay, ProvisioningState
```

```output
Name              : PostgreSqlServer
State             : Disabled
RetentionDay      : 14
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
