### Example 1: List all deleted workspaces for a given resource group
```powershell
Get-AzOperationalInsightsDeletedWorkspace -ResourceGroupName {RG-Name}

Name                            : {WS-Name1}
ResourceId                      : /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/microsoft.operationalinsights/workspaces/{WS-Name1}
ResourceGroupName               : {RG-Name}
Location                        : eastus2euap
Tags                            : {}
Sku                             : pergb2018
CapacityReservationLevel        :
LastSkuUpdate                   : Tue, 12 Jan 2021 11:25:15 GMT
retentionInDays                 : 30
CustomerId                      : 43eda0ea-004a-48e8-9c40-1219418083de
ProvisioningState               : Succeeded
PublicNetworkAccessForIngestion : Enabled
PublicNetworkAccessForQuery     : Enabled
PrivateLinkScopedResources      :
WorkspaceCapping                : Microsoft.Azure.Management.OperationalInsights.Models.WorkspaceCapping
CreatedDate                     : Tue, 12 Jan 2021 11:25:15 GMT
ModifiedDate                    : Wed, 19 Jan 2022 20:50:32 GMT
ForceCmkForQuery                :
WorkspaceFeatures               : Microsoft.Azure.Commands.OperationalInsights.Models.PSWorkspaceFeatures

Name                            : {WS-Name2}
ResourceId                      : /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/microsoft.operationalinsights/workspaces/{WS-Name2}
ResourceGroupName               : {RG-Name}
Location                        : eastus2euap
Tags                            : {}
Sku                             : pergb2018
CapacityReservationLevel        :
LastSkuUpdate                   : Tue, 12 Jan 2021 11:25:15 GMT
retentionInDays                 : 30
CustomerId                      : 43eda0ea-004a-48e8-9c40-1219418083de
ProvisioningState               : Succeeded
PublicNetworkAccessForIngestion : Enabled
PublicNetworkAccessForQuery     : Enabled
PrivateLinkScopedResources      :
WorkspaceCapping                : Microsoft.Azure.Management.OperationalInsights.Models.WorkspaceCapping
CreatedDate                     : Tue, 12 Jan 2021 11:25:15 GMT
ModifiedDate                    : Wed, 19 Jan 2022 20:50:32 GMT
ForceCmkForQuery                :
WorkspaceFeatures               : Microsoft.Azure.Commands.OperationalInsights.Models.PSWorkspaceFeatures
```

Get all deleted workspaces for a given resource group

### Example 2: Get a deleted workspace by resource group and name
```powershell
Get-AzOperationalInsightsDeletedWorkspace -ResourceGroupName {RG-Name} -Name {WS-Name1}

Name                            : {WS-Name1}
ResourceId                      : /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/microsoft.operationalinsights/workspaces/{WS-Name1}
ResourceGroupName               : {RG-Name}
Location                        : eastus2euap
Tags                            : {}
Sku                             : pergb2018
CapacityReservationLevel        :
LastSkuUpdate                   : Tue, 12 Jan 2021 11:25:15 GMT
retentionInDays                 : 30
CustomerId                      : 43eda0ea-004a-48e8-9c40-1219418083de
ProvisioningState               : Succeeded
PublicNetworkAccessForIngestion : Enabled
PublicNetworkAccessForQuery     : Enabled
PrivateLinkScopedResources      :
WorkspaceCapping                : Microsoft.Azure.Management.OperationalInsights.Models.WorkspaceCapping
CreatedDate                     : Tue, 12 Jan 2021 11:25:15 GMT
ModifiedDate                    : Wed, 19 Jan 2022 20:50:32 GMT
ForceCmkForQuery                :
WorkspaceFeatures               : Microsoft.Azure.Commands.OperationalInsights.Models.PSWorkspaceFeatures
```

Get a specific deleted workspace  by resource group and name
