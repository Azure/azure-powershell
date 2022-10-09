### Example 1: Get information about a configuration profile assignment
```powershell
Get-AzAutomanageConfigProfileHciAssignment -ResourceGroupName automangerg -ClusterName aglinuxclusters
```

```output
Name    ResourceGroupName ManagedBy Status     TargetId
----    ----------------- --------- ------     --------
default automangerg                 Conformant /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/automangerg/providers/Microsoft.AzureStackHci/clusters/aglinuxclusters
```

This command gets information about a configuration profile assignment.