### Example 1: Creates an association between a AzureStackHCI cluster and Automanage configuration profile
```powershell
New-AzAutomanageConfigProfileHciAssignment -ResourceGroupName automangerg -ClusterName aglinuxcluster -ConfigurationProfile "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction"
```

```output
Name    ResourceGroupName ManagedBy Status  TargetId
----    ----------------- --------- ------  --------
default automangerg                 Unknown /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/automangerg/providers/Microsoft.AzureStackHci/clusters/aglinuxcluster
```

This command creates an association between a AzureStackHCI cluster and Automanage configuration profile.