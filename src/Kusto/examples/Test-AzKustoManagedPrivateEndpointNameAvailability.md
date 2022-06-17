### Example 1: Checks whether the ManagedPrivateEndpoint name is available in the given cluster
```powershell
Test-AzKustoManagedPrivateEndpointNameAvailability -ClusterName "mycluster" -ResourceGroupName "testrg" -Name "testmanagedprivateendpoint"
```

```output
Message Name                       NameAvailable Reason
------- ----                       ------------- ------
        testmanagedprivateendpoint True
```

The above command returns whether or not a ManagedPrivateEndpoint name is available in the cluster named "mycluster" in resource group "testrg".