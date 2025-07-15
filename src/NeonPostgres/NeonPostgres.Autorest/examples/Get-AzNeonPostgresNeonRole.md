### Example 1: List all roles and permissions associated with a specific branch
```powershell
Get-AzNeonPostgresNeonRole -BranchName "br-damp-bird-a82olmcu" -ProjectName "dawn-breeze-86932056" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Attribute                    : 
BranchId                     : br-damp-bird-a82olmcu
CreatedAt                    : May 12, 2025 8:02 AM
EntityId                     : 
EntityName                   : neondb_owner
Id                           : 
IsSuperUser                  : False
Name                         : 
Permission                   : 
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : 
```

List all roles and permissions associated with a specific branch