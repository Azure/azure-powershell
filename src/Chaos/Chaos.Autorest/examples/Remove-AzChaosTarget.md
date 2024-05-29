### Example 1: Delete a Target resource that extends a tracked regional resource.
```powershell
Remove-AzChaosTarget -Name microsoft-virtualmachine -ParentProviderNamespace Microsoft.Compute -ParentResourceName exampleVM -ParentResourceType virtualMachines -ResourceGroupName azps_test_group_chaos
```

Delete a Target resource that extends a tracked regional resource.