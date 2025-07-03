### Example 1: Update the properties of an existing branch
```powershell
Update-AzNeonPostgresBranch -Name "br-damp-bird-a82olmcu" -OrganizationName "NeonDemoOrgPS1" -ProjectName "dawn-breeze-86932057" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000" -DatabaseName "updated-db" -EntityName "updated-entity" -ParentId "parent-branch-id" -RoleName "admin"
```


Update the properties of an existing branch within a Neon Postgres project.
