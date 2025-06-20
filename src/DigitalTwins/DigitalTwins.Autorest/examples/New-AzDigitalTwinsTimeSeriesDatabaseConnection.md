### Example 1: Create a time series database connection.
```powershell
New-AzDigitalTwinsTimeSeriesDatabaseConnection -Name azps-tsdc -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -AdxDatabaseName "azpsadec1database" -AdxEndpointUri "https://azpsdataexplorer.eastus.kusto.windows.net" -AdxResourceId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.Kusto/clusters/azpsdataexplorer" -AdxTableName "azpsadec1database-table" -EventHubEndpointUri "sb://azps-eventhubs.servicebus.windows.net/" -EventHubEntityPath "azps-eventhubs" -EventHubNamespaceResourceId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.EventHub/namespaces/azps-eventhubs"
```

```output
Name      ConnectionType    ProvisioningState ResourceGroupName
----      --------------    ----------------- -----------------
azps-tsdc AzureDataExplorer Succeed            azps_test_group
```

Create a time series database connection.