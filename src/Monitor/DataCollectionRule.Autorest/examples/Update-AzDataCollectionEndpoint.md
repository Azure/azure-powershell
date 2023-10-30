### Example 1: Update tag for data collection endpoint
```powershell
Update-AzDataCollectionEndpoint -Name myCollectionEndpoint -ResourceGroupName AMCS-TEST -Tag @{"123"="abc"}
```

```output
ConfigurationAccessEndpoint         : https://mycollectionendpoint-yz4d.eastus-1.handler.control.monitor.azure.com
Description                         : 
Etag                                : "22014545-0000-0100-0000-65115a540000"
FailoverConfigurationActiveLocation : 
FailoverConfigurationLocation       : 
Id                                  : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint  
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : 
IdentityUserAssignedIdentity        : {
                                      }
ImmutableId                         : dce-8011fcc7985844938c3809e497420638
Kind                                : 
Location                            : eastus
LogIngestionEndpoint                : https://mycollectionendpoint-yz4d.eastus-1.ingest.monitor.azure.com
MetadataProvisionedBy               : 
MetadataProvisionedByResourceId     : 
MetricIngestionEndpoint             : https://mycollectionendpoint-yz4d.eastus-1.metrics.ingest.monitor.azure.com
Name                                : myCollectionEndpoint
NetworkAclsPublicNetworkAccess      : Enabled
PrivateLinkScopedResource           : 
ProvisioningState                   : Succeeded
ResourceGroupName                   : AMCS-TEST
SystemDataCreatedAt                 : 9/18/2023 2:37:19 AM
SystemDataCreatedBy                 : v-jiaji@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 9/25/2023 10:00:51 AM
SystemDataLastModifiedBy            : v-jiaji@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "123": "abc"
                                      }
Type                                : Microsoft.Insights/dataCollectionEndpoints
```

This command updates data collection endpoint.
