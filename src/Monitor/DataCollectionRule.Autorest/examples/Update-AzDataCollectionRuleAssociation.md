### Example 1: Update specific data collection endpoint association with specified name and resource URI
```powershell
Update-AzDataCollectionRuleAssociation -AssociationName configurationAccessEndpoint -DataCollectionEndpointId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/Microsoft.Compute/virtualMachines/MonitorTestVM01 -Description "monitor test VM endpoint association"
```

```output
DataCollectionEndpointId        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint      
DataCollectionRuleId            : 
Description                     : monitor test VM endpoint association
Etag                            : "2101c8f4-0000-0100-0000-6511563b0000"
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/Microsoft.Compute/virtualMachines/MonitorTestVM01/providers/Microsof 
                                  t.Insights/dataCollectionRuleAssociations/configurationAccessEndpoint
MetadataProvisionedBy           : 
MetadataProvisionedByResourceId : 
Name                            : configurationAccessEndpoint
ProvisioningState               : 
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 9/25/2023 9:43:23 AM
SystemDataCreatedBy             : v-jiaji@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/25/2023 9:43:23 AM
SystemDataLastModifiedBy        : v-jiaji@microsoft.com
SystemDataLastModifiedByType    : User
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```

This command updates specific data collection endpoint association with specified data collection association name and resource URI

### Example 2: Update specific data collection rule association with specified data collection association name and resource URI
```powershell
Update-AzDataCollectionRuleAssociation -AssociationName myCollectionRule1-association -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/Microsoft.Compute/virtualMachines/MonitorTestVM01 -Description "new"
```

```output
DataCollectionEndpointId        : 
DataCollectionRuleId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule1
Description                     : new
Etag                            : "2201bb11-0000-0100-0000-651157920000"
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/Microsoft.Compute/virtualMachines/MonitorTestVM01/providers/Microsoft.Insights/dataCollectionRuleAssociations/myCollectionRule1-association 
MetadataProvisionedBy           : 
MetadataProvisionedByResourceId : 
Name                            : myCollectionRule1-association
ProvisioningState               : 
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 9/25/2023 9:49:06 AM
SystemDataCreatedBy             : v-jiaji@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/25/2023 9:49:06 AM
SystemDataLastModifiedBy        : v-jiaji@microsoft.com
SystemDataLastModifiedByType    : User
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```

This command updates specific data collection rule association with specified name and resource URI.

