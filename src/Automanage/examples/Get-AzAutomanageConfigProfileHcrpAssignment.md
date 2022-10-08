### Example 1: Get information about a configuration profile assignment
```powershell
Get-AzAutomanageConfigProfileHcrpAssignment -ResourceGroupName automangerg -MachineName aglinuxmachines
```

```output
Name    ResourceGroupName ManagedBy Status     TargetId
----    ----------------- --------- ------     --------
default automangerg                 Conformant /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/automangerg/providers/Microsoft.HybridCompute/machines/aglinuxmachines
```

This command gets information about a configuration profile assignment.

