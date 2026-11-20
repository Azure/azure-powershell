### Example 1: Delete a change data capture configuration
```powershell
Remove-AzHorizonDbChangeDataCaptureConfiguration -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -ConfigurationName 'sales-database' -Confirm
```

Deletes the sales-database change data capture configuration after confirmation.

The HTTP 202 response has no body. This command produces no output unless PassThru is specified.
