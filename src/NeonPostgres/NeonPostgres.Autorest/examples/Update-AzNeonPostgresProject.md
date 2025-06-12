### Example 1: Update the properties of an existing Neon project resource within Azure
```powershell
Update-AzNeonPostgresProject -Name "dawn-breeze-86932057" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000" -BranchDatabaseName "updated-db" -BranchEntityName "updated-entity" -BranchParentId "parent-branch-id" -BranchRoleName "admin" -PgVersion 17 -RegionId "centraluseuap" -Storage 10240 -HistoryRetention 7
```

Update the properties of an existing Neon project resource within Azure.
