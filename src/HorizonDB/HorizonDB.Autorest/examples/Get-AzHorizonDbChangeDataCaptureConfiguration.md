### Example 1: List change data capture configurations
```powershell
Get-AzHorizonDbChangeDataCaptureConfiguration -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, DatabaseName, UsageProfile, DesiredState, EffectiveState, ProvisioningState
```

```output
Name              : sales-database
DatabaseName      : sales
UsageProfile      : Mirroring
DesiredState      : Enabled
EffectiveState    : Enabled
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a change data capture configuration
```powershell
Get-AzHorizonDbChangeDataCaptureConfiguration -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -ConfigurationName 'sales-database' | Format-List -Property Name, DatabaseName, UsageProfile, DesiredState, EffectiveState, ProvisioningState
```

```output
Name              : sales-database
DatabaseName      : sales
UsageProfile      : Mirroring
DesiredState      : Enabled
EffectiveState    : Enabled
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
