### Example 1: Create endpoint
```powershell
New-AzDataCollectionEndpoint -Name myCollectionEndpoint -ResourceGroupName AMCS-TEST -Location eastus -NetworkAclsPublicNetworkAccess Enabled
```

```output
ConfigurationAccessEndpoint         : https://mycollectionendpoint-bthd.eastus-1.handler.control.monitor.azure.com
Description                         : 
Etag                                : "b9029ae7-0000-0100-0000-65016d2a0000"
FailoverConfigurationActiveLocation : 
FailoverConfigurationLocation       : 
Id                                  : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint  
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : 
IdentityUserAssignedIdentity        : {
                                      }
ImmutableId                         : dce-014e59a439e04f44af4b97b16b7614df
Kind                                : 
Location                            : eastus
LogIngestionEndpoint                : https://mycollectionendpoint-bthd.eastus-1.ingest.monitor.azure.com
MetadataProvisionedBy               : 
MetadataProvisionedByResourceId     : 
MetricIngestionEndpoint             : https://mycollectionendpoint-bthd.eastus-1.metrics.ingest.monitor.azure.com
Name                                : myCollectionEndpoint
NetworkAclsPublicNetworkAccess      : Enabled
PrivateLinkScopedResource           : 
ProvisioningState                   : Succeeded
ResourceGroupName                   : AMCS-TEST
SystemDataCreatedAt                 : 9/13/2023 8:04:55 AM
SystemDataCreatedBy                 : v-jiaji@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 9/13/2023 8:04:55 AM
SystemDataLastModifiedBy            : v-jiaji@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : Microsoft.Insights/dataCollectionEndpoints
```

This command creates the endpiont with given values.

### Example 2: Create enpoint with json file
```powershell
New-AzDataCollectionEndpoint -Name myCollectionEndpoint2 -ResourceGroupName AMCS-TEST -JsonFilePath .\test\jsonfile\endpointTest1.json
# Note: content of .\test\jsonfile\endpointTest1.json
#{
#     "location": "eastus",
#     "properties": {
#         "networkAcls": {
#             "publicNetworkAccess": "Enabled"
#             }
#         }
# }
```

```output
ConfigurationAccessEndpoint         : https://mycollectionendpoint2-0e77.eastus-1.handler.control.monitor.azure.com
Description                         : 
Etag                                : "ba021b4b-0000-0100-0000-650170c20000"
FailoverConfigurationActiveLocation : 
FailoverConfigurationLocation       : 
Id                                  : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint2
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : 
IdentityUserAssignedIdentity        : {
                                      }
ImmutableId                         : dce-ab8aec1ea24a41c0a175a5692c173b76
Kind                                : 
Location                            : eastus
LogIngestionEndpoint                : https://mycollectionendpoint2-0e77.eastus-1.ingest.monitor.azure.com
MetadataProvisionedBy               : 
MetadataProvisionedByResourceId     : 
MetricIngestionEndpoint             : https://mycollectionendpoint2-0e77.eastus-1.metrics.ingest.monitor.azure.com
Name                                : myCollectionEndpoint2
NetworkAclsPublicNetworkAccess      : Enabled
PrivateLinkScopedResource           : 
ProvisioningState                   : Succeeded
ResourceGroupName                   : AMCS-TEST
SystemDataCreatedAt                 : 9/13/2023 8:20:16 AM
SystemDataCreatedBy                 : v-jiaji@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 9/13/2023 8:20:16 AM
SystemDataLastModifiedBy            : v-jiaji@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : Microsoft.Insights/dataCollectionEndpoints
```

This command creates enpoint with given json file path.
