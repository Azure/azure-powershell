### Example 1: Creates an association between a VM and Automanage configuration profile
```powershell
New-AzAutomanageConfigProfileAssignment -ResourceGroupName automangerg -VMName aglinuxvm -ConfigurationProfile "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction"
```

```output
Name    ResourceGroupName ManagedBy Status  TargetId
----    ----------------- --------- ------  --------
default automangerg                 Unknown /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/automangerg/providers/Microsoft.Compute/virtualMachines/aglinuxvm
```

This command creates an association between a VM and Automanage configuration profile.