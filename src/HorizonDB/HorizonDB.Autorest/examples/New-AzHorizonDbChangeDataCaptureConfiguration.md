### Example 1: Configure change data capture for a database
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$body = @{
    properties = @{
        databaseName = 'sales'
        usageProfile = 'Mirroring'
        destinationResourceId = "/subscriptions/$subscriptionId/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/clusters/example-cluster/changeDataCaptureDestinations/fabric-mirroring"
        desiredState = 'Enabled'
    }
} | ConvertTo-Json -Depth 5

New-AzHorizonDbChangeDataCaptureConfiguration -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -ConfigurationName 'sales-database' -JsonString $body | Format-List -Property Name, DatabaseName, UsageProfile, DesiredState, EffectiveState, ProvisioningState
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
