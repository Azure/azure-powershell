### Example 1: List description of an existing time series database connection.
```powershell
Get-AzDigitalTwinsTimeSeriesDatabaseConnection -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance
```

```output
Name      ConnectionType    ProvisioningState ResourceGroupName
----      --------------    ----------------- -----------------
azps-tsdc AzureDataExplorer Succeed            azps_test_group
```

List description of an existing time series database connection.

### Example 2: Get the description of an existing time series database connection.
```powershell
Get-AzDigitalTwinsTimeSeriesDatabaseConnection -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -Name azps-tsdc
```

```output
Name      ConnectionType    ProvisioningState ResourceGroupName
----      --------------    ----------------- -----------------
azps-tsdc AzureDataExplorer Succeed            azps_test_group
```

Get the description of an existing time series database connection.