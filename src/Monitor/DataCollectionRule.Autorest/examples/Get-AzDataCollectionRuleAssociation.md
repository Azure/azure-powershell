### Example 1: List data collection rule associations with specified resource URI
```powershell
Get-AzDataCollectionRuleAssociation -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01
```

```output
Etag                                   Name                           ResourceGroupName
----                                   ----                           -----------------
"d500d29e-0000-0100-0000-650d68490000" myCollectionRule1-association  amcs-test
"20017ecf-0000-0100-0000-651147350000" myCollectionRule2-association1 amcs-test
```

This command gets list of specific data collection rule associations with specified resource URI.

### Example 2: Get specific data collection rule association with specified resource URI and association name
```powershell
Get-AzDataCollectionRuleAssociation -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01 -AssociationName myCollectionRule2-association1
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

This command gets specific data collection rule association with specified resource URI.

### Example 3: Get specific data collection rule association with specified resource group
```powershell
Get-AzDataCollectionRuleAssociation -DataCollectionRuleName myCollectionRule1 -ResourceGroupName AMCS-Test
```

```output
DataCollectionEndpointId        : 
DataCollectionRuleId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.insights/datacollectionrules/mycollectionrule1
Description                     : 
Etag                            : 
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01/providers/microsof 
                                  t.insights/datacollectionruleassociations/mycollectionrule1-association
MetadataProvisionedBy           : 
MetadataProvisionedByResourceId : 
Name                            : mycollectionrule1-association
ProvisioningState               : 
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```

This command gets list of data collection rule association with specified data collection rule.

### Example 4: List data collection endpoint associations with specified data collection endpoint
```powershell
Get-AzDataCollectionRuleAssociation -DataCollectionEndpointName myCollectionEndpoint -ResourceGroupName AMCS-Test
```

```output
Etag                                   Name                        ResourceGroupName
----                                   ----                        -----------------
"21017484-0000-0100-0000-6511505c0000" configurationAccessEndpoint amcs-test
"210182a5-0000-0100-0000-6511520c0000" configurationAccessEndpoint azsecpack-rg
```

This command gets list of specific data collection rule associations with specified data collection endpoint.

