### Example 1: Create a new EventHub data connection
```powershell
New-AzSynapseKustoPoolDataConnection -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -DatabaseName testdatabase -Name eventhubdc -Location eastus2 -Kind EventHub -EventHubResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testrg/providers/Microsoft.EventHub/namespaces/testeventhubns/eventhubs/testeventhub" -DataFormat "JSON" -ConsumerGroup '$Default' -Compression "None" -TableName "Events" -MappingRuleName "EventsMapping"
```

```output
Kind     Location  Name
----     --------  ----
EventHub East US 2 testws/testkustopool/testdatabase/eventhubdc
```

The above command creates a new EventHub data connection named "eventhubdc" for the database "testdatabase" in the kusto pool "testkustopool".

### Example 2: Create a new EventGrid data connection
```powershell
New-AzSynapseKustoPoolDataConnection -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -DatabaseName testdatabase -Name eventgriddc -Location eastus2 -Kind EventGrid -EventHubResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testrg/providers/Microsoft.EventHub/namespaces/testeventhubns/eventhubs/testeventhub" -StorageAccountResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/teststorage" -DataFormat "JSON" -ConsumerGroup '$Default' -TableName "Events" -MappingRuleName "EventsMapping"
```

```output
Kind      Location  Name
----      --------  ----
EventGrid East US 2 testws/testkustopool/testdatabase/eventgriddc
```

The above command creates a new EventGrid data connection named "eventgriddc" for the database "testdatabase" in the kusto pool "testkustopool".

### Example 3: Create a new IotHub data connection
```powershell
New-AzSynapseKustoPoolDataConnection -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -DatabaseName testdatabase -Name iothubdc -Location eastus2 -Kind IotHub -IotHubResourceId "/subscriptions/051ddeca-1ed6-4d8b-ba6f-1ff561e5f3b3/resourceGroups/ywtest/providers/Microsoft.Devices/IotHubs/ywtestiothub" -SharedAccessPolicyName registryRead -DataFormat "JSON" -ConsumerGroup '$Default' -TableName "Events" -MappingRuleName "EventsMapping"
```

```output
Kind   Location  Name
----   --------  ----
IotHub East US 2 testws/testkustopool/testdatabase/iothubdc
```

The above command creates a new IotHub data connection named "iothubdc" for the database "testdatabase" in the kusto pool "testkustopool".