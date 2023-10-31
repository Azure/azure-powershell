### Example 1: Create data collection rule association with specified data collection rule
```powershell
New-AzDataCollectionRuleAssociation -AssociationName myCollectionRule2-association1 -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01 -DataCollectionRuleId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule2
```

```output
DataCollectionEndpointId        : 
DataCollectionRuleId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule2
Description                     : 
Etag                            : "20017ecf-0000-0100-0000-651147350000"
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01/providers/Microsof 
                                  t.Insights/dataCollectionRuleAssociations/myCollectionRule2-association1
MetadataProvisionedBy           : 
MetadataProvisionedByResourceId : 
Name                            : myCollectionRule2-association1
ProvisioningState               : 
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 9/25/2023 8:39:15 AM
SystemDataCreatedBy             : v-jiaji@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/25/2023 8:39:15 AM
SystemDataLastModifiedBy        : v-jiaji@microsoft.com
SystemDataLastModifiedByType    : User
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```

This command creates data collection rule association with specified data collection rule.

### Example 2: Create data collection endpoint association with specified data collection endpoint
```powershell
New-AzDataCollectionRuleAssociation -AssociationName configurationAccessEndpoint -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01 -DataCollectionEndpointId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint
```

```output
DataCollectionEndpointId        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint      
DataCollectionRuleId            : 
Description                     : 
Etag                            : "21017484-0000-0100-0000-6511505c0000"
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01/providers/Microsof 
                                  t.Insights/dataCollectionRuleAssociations/configurationAccessEndpoint
MetadataProvisionedBy           : 
MetadataProvisionedByResourceId : 
Name                            : configurationAccessEndpoint
ProvisioningState               : 
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 9/25/2023 9:18:20 AM
SystemDataCreatedBy             : v-jiaji@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/25/2023 9:18:20 AM
SystemDataLastModifiedBy        : v-jiaji@microsoft.com
SystemDataLastModifiedByType    : User
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```

This command creates specific data collection endpoint association with specified data collection endpoint.

