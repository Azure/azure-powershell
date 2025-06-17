### Example 1: List all Neon Postgres databases associated with a specific branch
```powershell
Get-AzNeonPostgresNeonDatabase -BranchName "br-damp-bird-a82olmcu" -OrganizationName "NeonDemoOrgPS1" -ProjectName "dawn-breeze-86932057" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Attribute                    : 
BranchId                     : br-damp-bird-a82olmcu
CreatedAt                    : May 12, 2025 8:02 AM
EntityId                     : 1685451
EntityName                   : neondb
Id                           : 
Name                         : 
OwnerName                    : neondb_owner
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : 
```

List all Neon Postgres databases associated with a specific branch.
