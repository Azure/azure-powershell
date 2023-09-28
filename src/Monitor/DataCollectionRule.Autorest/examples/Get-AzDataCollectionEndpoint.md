### Example 1: {{ Add title here }}
```powershell
Get-AzDataCollectionEndpoint
```

```output
Etag                                   Kind Location Name                  ResourceGroupName
----                                   ---- -------- ----                  -----------------
"b9029ae7-0000-0100-0000-65016d2a0000"      eastus   myCollectionEndpoint  AMCS-TEST
"ba021b4b-0000-0100-0000-650170c20000"      eastus   myCollectionEndpoint2 AMCS-TEST
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzDataCollectionEndpoint -ResourceGroupName AMCS-TEST
```

```output
Etag                                   Kind Location Name                  ResourceGroupName
----                                   ---- -------- ----                  -----------------
"b9029ae7-0000-0100-0000-65016d2a0000"      eastus   myCollectionEndpoint  AMCS-TEST
"ba021b4b-0000-0100-0000-650170c20000"      eastus   myCollectionEndpoint2 AMCS-TEST
```

{{ Add description here }}

### Example 3: {{ Add title here }}
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

{{ Add description here }}
