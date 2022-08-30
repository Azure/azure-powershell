### Example 1: Create a new database
```powershell
New-AzKustoDatabase -ResourceGroupName testrg -ClusterName testnewkustocluster -Name mykustodatabase -Kind ReadWrite -Location 'East US'
```

```output
Kind      Location Name                                Type
----      -------- ----                                ----
ReadWrite East US  testnewkustocluster/mykustodatabase Microsoft.Kusto/Clusters/Databases
```

The above command creates a new datebase named "mykustodatabase" in the resource group "testrg".
