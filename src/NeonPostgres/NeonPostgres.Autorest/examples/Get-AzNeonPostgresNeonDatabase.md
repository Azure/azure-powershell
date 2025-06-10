### Example 1: List all Neon Postgres databases associated with a specific branch
```powershell
Get-AzNeonPostgresNeonDatabase -BranchName "br-damp-bird-a82olmcu" -OrganizationName "NeonDemoOrgPS1" -ProjectName "dawn-breeze-86932057" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
```

List all Neon Postgres databases associated with a specific branch.

### Example 2: Get Neon Postgres databases associated with a specific branch
```powershell
Get-AzNeonPostgresNeonDatabase -DatabaseName "neodb" -BranchName "br-damp-bird-a82olmcu" -OrganizationName "NeonDemoOrgPS1" -ProjectName "dawn-breeze-86932057" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
```

Get Neon Postgres databases associated with a specific branch.
