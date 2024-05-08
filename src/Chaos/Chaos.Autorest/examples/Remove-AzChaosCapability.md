### Example 1: Delete a Capability that extends a Target resource.
```powershell
Remove-AzChaosCapability -Name Shutdown-1.0 -ParentProviderNamespace Microsoft.Compute -ParentResourceName exampleVM -ParentResourceType virtualMachines -ResourceGroupName azps_test_group_chaos -TargetName microsoft-virtualmachine
```

Delete a Capability that extends a Target resource.