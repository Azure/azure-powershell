### Example 1: List all branches resources within a specified project in Neon Postgres
```powershell
Get-AzNeonPostgresBranch -ProjectName "dawn-breeze-86932056" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Attribute                    : {{
                                 "name": "createdAt",
                                 "value": "May 12, 2025 8:02 AM"
                               }, {
                                 "name": "logicalSize",
                                 "value": "30785536"
                               }, {
                                 "name": "cpuUsedSec",
                                 "value": "0"
                               }, {
                                 "name": "computeTimeSeconds",
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
ProvisioningState            : idle
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

List all branches resources within a specified project in Neon Postgres

### Example 2: Get Branch resource details within a specified project in Neon Postgres
```powershell
Get-AzNeonPostgresBranch -Name "br-damp-bird-a82olmcu" -ProjectName "dawn-breeze-86932056" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
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

Get Branch resource details within a specified project in Neon Postgres
