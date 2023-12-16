### Example 1: Get data collection endpoints by subscription ID
```powershell
Get-AzDataCollectionEndpoint
```

```output
Etag                                   Kind Location Name                  ResourceGroupName
----                                   ---- -------- ----                  -----------------
"b9029ae7-0000-0100-0000-65016d2a0000"      eastus   myCollectionEndpoint  AMCS-TEST
"ba021b4b-0000-0100-0000-650170c20000"      eastus   myCollectionEndpoint2 AMCS-TEST
```

This command lists all the data collection endpoints for the current subscription.

### Example 2: Get data collection endpoints for the given resource group
```powershell
Get-AzDataCollectionEndpoint -ResourceGroupName AMCS-TEST
```

```output
Etag                                   Kind Location Name                  ResourceGroupName
----                                   ---- -------- ----                  -----------------
"b9029ae7-0000-0100-0000-65016d2a0000"      eastus   myCollectionEndpoint  AMCS-TEST
"ba021b4b-0000-0100-0000-650170c20000"      eastus   myCollectionEndpoint2 AMCS-TEST
```

This command lists data collection endpoints for the given resource group.

### Example 3: Get a data collection endpoint
```powershell
Get-AzDataCollectionEndpoint -ResourceGroupName AMCS-TEST -Name myCollection
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

This command lists one (a list with a single element) data collection endpoint.
