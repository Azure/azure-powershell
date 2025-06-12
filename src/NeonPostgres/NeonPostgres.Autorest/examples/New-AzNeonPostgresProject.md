### Example 1: Create a new Neon project resource within Azure

```powershell
New-AzNeonPostgresProject -Name "test-project" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000" -BranchDatabaseName "sampledb" -BranchEntityName "sample-entity" -BranchParentId "dawn-breeze-86932057" -BranchRoleName "readonly"
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

Create a new Neon project resource within Azure.