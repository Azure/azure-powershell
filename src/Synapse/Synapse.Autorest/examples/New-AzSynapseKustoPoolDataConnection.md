### Example 1: Create a new EventHub data connection
```powershell
PS C:\> New-AzSynapseKustoPoolDataConnection -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -DatabaseName "mykustodatabase" -DataConnectionName "myeventhubdc" -Location "East US" -Kind "EventHub" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubs/eventhubs/myeventhub" -DataFormat "JSON" -ConsumerGroup '$Default' -Compression "None" -TableName "Events" -MappingRuleName "EventsMapping"

Kind     Location  Name                                              Type
----     --------  ----                                              ----
EventHub East US   testws/testkustopool/mykustodatabase/myeventhubdc Microsoft.Synapse/workspaces/kustoPools/Databases/DataConnections
```

The above command creates a new EventHub data connection named "myeventhubdc" for the kusto database "mykustodatabase" in the workspace "testws" found in resource group "testrg".

### Example 2: Create a new EventGrid data connection
```powershell
PS C:\> New-AzSynapseKustoPoolDataConnection -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -DatabaseName "mykustodatabase" -DataConnectionName "myeventgriddc" -Location "East US" -Kind "EventGrid" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubs/eventhubs/myeventhub" -StorageAccountResourceId $storageAccountResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Storage/storageAccounts/mystorage" -DataFormat "JSON" -ConsumerGroup '$Default' -TableName "Events" -MappingRuleName "EventsMapping" -IgnoreFirstRecord "false" -BlobStorageEventType "Microsoft.Storage.BlobRenamed"

Kind      Location  Name                                               Type
----      --------  ----                                               ----
EventGrid East US   testws/testkustopool/mykustodatabase/myeventgriddc Microsoft.Synapse/workspaces/kustoPools/Databases/DataConnections
```

The above command creates a new EventGrid data connection named "myeventgriddc" for the kusto database "mykustodatabase" in the workspace "testws" found in resource group "testrg".

### Example 3: Create a new IotHub data connection
```powershell
PS C:\> New-AzSynapseKustoPoolDataConnection -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -DatabaseName "mykustodatabase" -DataConnectionName "myiothubdc" -Location "East US" -Kind "IotHub" -IotHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Devices/IotHubs/myiothub" -SharedAccessPolicyName "myiothubpolicy" -DataFormat "JSON" -ConsumerGroup '$Default' -TableName "Events" -MappingRuleName "EventsMapping"

Kind   Location  Name										     Type
----   --------  ----                                            ----
IotHub East US   testws/testkustopool/mykustodatabase/myiothubdc Microsoft.Synapse/workspaces/kustoPools/Databases/DataConnections
```

The above command creates a new IotHub data connection named "myiothubdc" for the kusto database "mykustodatabase" in the workspace "testws" found in resource group "testrg".

