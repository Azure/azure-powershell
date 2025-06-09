### Example 1: Create a new Neon project resource within Azure

```powershell
New-AzNeonPostgresProject -Name "test-project" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000" -BranchDatabaseName "sampledb" -BranchEntityName "sample-entity" -BranchParentId "dawn-breeze-86932057" -BranchRoleName "readonly"
```

```output
```

Create a new Neon project resource within Azure.