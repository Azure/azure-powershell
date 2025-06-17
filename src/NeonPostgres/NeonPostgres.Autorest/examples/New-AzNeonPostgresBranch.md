### Example 1: Create a new branch within a Neon Postgres database

```powershell
New-AzNeonPostgresBranch -Name "test-branch" -OrganizationName "NeonDemoOrgPS1" -ProjectName "dawn-breeze-86932057" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Attribute                    : {{
                                 "name": "logicalSize",
                                 "value": "30785536"
                               }, {
                                 "name": "cpuUsedSec",
                                 "value": "0"
                               }, {
                                 "name": "computeTimeSeconds",
                                 "value": "0"
                               }, {
                                 "name": "activeTimeSeconds",
                                 "value": "0"
                               }…}
CreatedAt                    : May 12, 2025 8:02 AM
Database                     : 
DatabaseName                 : 
Endpoint                     : 
EntityId                     : br-damp-bird-a82olmcu
EntityName                   : main
Id                           : 
Name                         : 
ParentId                     : 
ProjectId                    : dawn-breeze-86932057
ProvisioningState            : Succeeded
ResourceGroupName            : 
Role                         : 
RoleName                     : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : 
```

Create a new branch within a Neon Postgres database.