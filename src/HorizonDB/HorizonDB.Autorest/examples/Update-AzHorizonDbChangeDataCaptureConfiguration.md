### Example 1: Disable a change data capture configuration
```powershell
Update-AzHorizonDbChangeDataCaptureConfiguration -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -ConfigurationName 'sales-database' -DesiredState 'Disabled' | Format-List -Property Name, DatabaseName, UsageProfile, DesiredState, EffectiveState, ProvisioningState
```

```output
Name              : sales-database
DatabaseName      : sales
UsageProfile      : Mirroring
DesiredState      : Disabled
EffectiveState    : Disabled
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
