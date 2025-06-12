### Example 1: List all Neon projects associated with a specific Neon organization

```powershell
Get-AzNeonPostgresProject -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Attribute                                   : 
BranchAttribute                             : 
BranchCreatedAt                             : 
BranchDatabase                              : 
BranchDatabaseName                          : 
BranchEndpoint                              : 
BranchEntityId                              : 
BranchEntityName                            : 
BranchParentId                              : 
BranchProjectId                             : 
BranchProvisioningState                     : 
BranchRole                                  : 
BranchRoleName                              : 
CreatedAt                                   : May 12, 2025 8:02 AM
Database                                    : 
DefaultEndpointSettingAutoscalingLimitMaxCu : 0
DefaultEndpointSettingAutoscalingLimitMinCu : 0
Endpoint                                    : 
EntityId                                    : dawn-breeze-86932057
EntityName                                  : NeonDemoOrgPS1-project
HistoryRetention                            : 0
Id                                          : 
Name                                        : 
PgVersion                                   : 17
ProvisioningState                           : Succeeded
RegionId                                    : eastus2
ResourceGroupName                           : 
Role                                        : 
Storage                                     : 30785536
SystemDataCreatedAt                         : 
SystemDataCreatedBy                         : 
SystemDataCreatedByType                     : 
SystemDataLastModifiedAt                    : 
SystemDataLastModifiedBy                    : 
SystemDataLastModifiedByType                : 
Type                                        : 
```

List all Neon projects associated with a specific Neon organization

### Example 2: Get Neon projects associated with a specific Neon organization

```powershell
Get-AzNeonPostgresProject -ProjectName "dawn-breeze-86932056" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Attribute                                   : 
BranchAttribute                             : 
BranchCreatedAt                             : 
BranchDatabase                              : 
BranchDatabaseName                          : 
BranchEndpoint                              : 
BranchEntityId                              : 
BranchEntityName                            : 
BranchParentId                              : 
BranchProjectId                             : 
BranchProvisioningState                     : 
BranchRole                                  : 
BranchRoleName                              : 
CreatedAt                                   : May 12, 2025 8:02 AM
Database                                    : 
DefaultEndpointSettingAutoscalingLimitMaxCu : 0
DefaultEndpointSettingAutoscalingLimitMinCu : 0
Endpoint                                    : 
EntityId                                    : dawn-breeze-86932057
EntityName                                  : NeonDemoOrgPS1-project
HistoryRetention                            : 0
Id                                          : 
Name                                        : 
PgVersion                                   : 17
ProvisioningState                           : Succeeded
RegionId                                    : eastus2
ResourceGroupName                           : 
Role                                        : 
Storage                                     : 30785536
SystemDataCreatedAt                         : 
SystemDataCreatedBy                         : 
SystemDataCreatedByType                     : 
SystemDataLastModifiedAt                    : 
SystemDataLastModifiedBy                    : 
SystemDataLastModifiedByType                : 
Type                                        : 
```

Get Neon projects associated with a specific Neon organization
