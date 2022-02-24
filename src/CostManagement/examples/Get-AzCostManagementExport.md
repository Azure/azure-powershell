### Example 1: Get all AzCostManagementExports by scope
```powershell
Get-AzCostManagementExport -Scope 'subscriptions/**********'
```

```output
ETag              Name                               Type
----              ----                               ----
"************" TestExport                         Microsoft.CostManagement/exports
"************" TestExport1                        Microsoft.CostManagement/exports
"************" TestExport2                        Microsoft.CostManagement/exports
```

Get all AzCostManagementExports by Scope

### Example 2: Get AzCostManagementExport by Name and scope
```powershell
Get-AzCostManagementExport -Name 'TestExport' -Scope 'subscriptions/**********'
```

```output
ETag              Name       Type
----              ----       ----
"************" TestExport Microsoft.CostManagement/exports
```

Get AzCostManagementExport by Name and scope

