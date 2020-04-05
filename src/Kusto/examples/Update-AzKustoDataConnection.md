### Example 1: Update a new EventHub data connection by name
```powershell
PS C:\> $dataConnectionProperties = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.EventHubDataConnection -Property @{Location="East US"; Kind="EventHub"; EventHubResourceId="/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub"; DataFormat="JSON"; ConsumerGroup='$Default'; Compression= "None"; TableName = "Events"; MappingRuleName = "EventsMapping1"}
PS C:\> Update-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" -DataConnectionName "mykustodataconnection" -Parameter $dataConnectionProperties

Kind     Location Name                                               Type
----     -------- ----                                               ----
EventHub East US  testnewkustocluster/mykustodatabase/mykustodataconnection Microsoft.Kusto/Clusters/Databases/DataConnections
```

The above command updates an existing EventHub data connection named "mykustodataconnection" for table "Events" in database "mykustodatabase" of the existing cluster "testnewkustocluster" found in the resource group "testrg".
