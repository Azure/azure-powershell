### Example 1: Update an existing EventHub data connection
```powershell
PS C:\> Update-AzSynapseKustoPoolDataConnection -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -DatabaseName "mykustodatabase" -DataConnectionName "myeventhubdc" -Location "East US" -Kind "EventHub" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubs/eventhubs/myeventhub" -DataFormat "JSON" -ConsumerGroup '$Default' -Compression "None" -TableName "Events" -MappingRuleName "NewEventsMapping"

Kind     Location Name                                              Type
----     -------- ----                                              ----
EventHub East US  testws/testkustopool/mykustodatabase/myeventhubdc Microsoft.Synapse/workspaces/kustoPools/Databases/DataConnections
```

The above command updates the existing EventHub data connection named "myeventhubdc" for the database "mykustodatabase" in the workspace "testws".

### Example 2: Update an existing EventGrid data connection
```powershell
PS C:\> Update-AzSynapseKustoPoolDataConnection -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -DatabaseName "mykustodatabase" -DataConnectionName "myeventgriddc" -Location "East US" -Kind "EventGrid" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubs/eventhubs/myeventhub" -StorageAccountResourceId $storageAccountResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Storage/storageAccounts/mystorage" -DataFormat "JSON" -ConsumerGroup '$Default' -TableName "Events" -MappingRuleName "NewEventsMapping"

Kind      Location Name                                               Type
----      -------- ----                                               ----
EventGrid East US  testws/testkustopool/mykustodatabase/myeventgriddc Microsoft.Synapse/workspaces/kustoPools/Databases/DataConnections
```

The above command updates the existing EventGrid data connection named "myeventgriddc" for the database "mykustodatabase" in the workspace "testws".

### Example 3: Update an existing IotHub data connection
```powershell
PS C:\> Update-AzSynapseKustoPoolDataConnection -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -DatabaseName "mykustodatabase" -DataConnectionName "myiothubdc" -Location "East US" -Kind "IotHub" -IotHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Devices/IotHubs/myiothub" -SharedAccessPolicyName "myiothubpolicy" -DataFormat "JSON" -ConsumerGroup '$Default' -TableName "Events" -MappingRuleName "NewEventsMapping"

Kind      Location Name                                         Type
----      -------- ----                                         ----
IotHub    East US  testws/testkustopool/mykustodatabase/myiothubdc Microsoft.Synapse/workspaces/kustoPools/Databases/DataConnections
```

The above command updates the existing IotHub data connection named "myiothubdc" for the database "mykustodatabase" in the workspace "testws".

### Example 4: Update an existing EventHub data connection via identity
```powershell
PS C:\> $dataConnection   Get-AzSynapseKustoPoolDataConnection -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -DatabaseName "mykustodatabase" -DataConnectionName "myeventhubdc" 
PS C:\> Update-AzSynapseKustoPoolDataConnection -InputObject $dataConnection -Location "East US" -Kind "EventHub" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub" -DataFormat "JSON" -ConsumerGroup '$Default' -Compression "None" -TableName "Events" -MappingRuleName "NewEventsMapping"

Kind     Location Name                                              Type
----     -------- ----                                              ----
EventHub East US  testws/testkustopool/mykustodatabase/myeventhubdc Microsoft.Synapse/workspaces/kustoPools/Databases/DataConnections
```

The above command updates the existing EventHub data connection named "myeventhubdc" for the database "mykustodatabase" in the workspace "testws".

### Example 5: Update an existing EventGrid data connection via identity
```powershell
PS C:\> $dataConnection   Get-AzSynapseKustoPoolDataConnection -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -DatabaseName "mykustodatabase" -DataConnectionName "myeventgriddc" 
PS C:\> Update-AzSynapseKustoPoolDataConnection -InputObject $dataConnection -Location "East US" -Kind "EventGrid" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub" -StorageAccountResourceId $storageAccountResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Storage/storageAccounts/mystorage" -DataFormat "JSON" -ConsumerGroup '$Default' -TableName "Events" -MappingRuleName "NewEventsMapping"

Kind      Location Name                                               Type
----      -------- ----                                               ----
EventGrid East US  testws/testkustopool/mykustodatabase/myeventgriddc Microsoft.Synapse/workspaces/kustoPools/Databases/DataConnections
```

The above command updates the existing EventGrid data connection named "myeventgriddc" for the database "mykustodatabase" in the workspace "testws".

### Example 6: Update an existing IotHub data connection via identity
```powershell
PS C:\> $dataConnection   Get-AzSynapseKustoPoolDataConnection -ResourceGroupName "testrg" -WorkspaceName "testws" -DatabaseName "mykustodatabase" -DataConnectionName "myiothubdc" 
PS C:\> Update-AzSynapseKustoPoolDataConnection -InputObject $dataConnection -Location "East US" -Kind "IotHub" -IotHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Devices/IotHubs/myiothub" -SharedAccessPolicyName "myiothubpolicy" -DataFormat "JSON" -ConsumerGroup '$Default' -TableName "Events" -MappingRuleName "NewEventsMapping"

Kind      Location Name                                         Type
----      -------- ----                                         ----
IotHub East US  testws/testkustopool/mykustodatabase/myiothubdc Microsoft.Synapse/workspaces/kustoPools/Databases/DataConnections
```

The above command updates the existing IotHub data connection named "myiothubdc" for the database "mykustodatabase" in the workspace "testws".