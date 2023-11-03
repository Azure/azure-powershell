### Example 1: Check the availability of a Kusto database name which is in use
```powershell
Test-AzKustoDatabaseNameAvailability -ResourceGroupName testrg -ClusterName testnewkustocluster -Name mykustodatabase -Type Microsoft.Kusto/Clusters/Databases
```

```output
Message                                                                                                          Name            NameAvailable Reason
-------                                                                                                          ----            ------------- ------
Database mykustodatabase already exists in cluster testnewkustocluster. Please select a different database name. mykustodatabase False
```

The above command returns whether or not a Kusto database named "mykustodatabase" exists in the "testnewkustocluster" cluster.

### Example 2: Check the availability of a Kusto database name which is not in use
```powershell
Test-AzKustoDatabaseNameAvailability -ResourceGroupName testrg -ClusterName testnewkustocluster -Name mykustodatabase2 -Type Microsoft.Kusto/Clusters/Databases
```

```output
Message Name             NameAvailable Reason
------- ----             ------------- ------
        mykustodatabase2 True
```

The above command returns whether or not a Kusto database named "mykustodatabase2" exists in the "testnewkustocluster" cluster.
