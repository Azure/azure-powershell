### Example 1: Validate EventHub data connection parameters
```powershell
Invoke-AzKustoDataConnectionValidation -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" -DataConnectionName "myeventhubdc" -Location "East US" -Kind "EventHub" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -Compression "None" -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates EventHub data connection named "myeventhubdc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

### Example 2: Validate EventGrid data connection parameters
```powershell
Invoke-AzKustoDataConnectionValidation -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" -DataConnectionName "myeventgriddc" -Location "East US" -Kind "EventGrid" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub" -StorageAccountResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Storage/storageAccounts/mystorage" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates EventGrid data connection named "myeventgriddc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

### Example 3: Validate IotHub data connection parameters
```powershell
Invoke-AzKustoDataConnectionValidation -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" -DataConnectionName "myiothubdc" -Location "East US" -Kind "IotHub" -IotHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Devices/IotHubs/myiothub" -SharedAccessPolicyName "myiothubpolicy" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates IotHub data connection named "myiothubdc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

### Example 4: Validate EventHub data connection parameters via identity
```powershell
$database = Get-AzKustoDatabase -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" 
Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName "myeventhubdc" -Location "East US" -Kind "EventHub" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -Compression "None" -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates EventHub data connection named "myeventhubdc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

### Example 5: Validate EventGrid data connection parameters via identity
```powershell
$database = Get-AzKustoDatabase -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase"
Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName "myeventgriddc" -Location "East US" -Kind "EventGrid" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub" -StorageAccountResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Storage/storageAccounts/mystorage" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates EventGrid data connection named "myeventgriddc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

### Example 6: Validate IotHub data connection parameters via identity
```powershell
$database = Get-AzKustoDatabase -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" 
Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName "myiothubdc" -Location "East US" -Kind "IotHub" -IotHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Devices/IotHubs/myiothub" -SharedAccessPolicyName "myiothubpolicy" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates IotHub data connection named "myiothubdc" for the database "mykustodatabase" in the cluster "testnewkustocluster".