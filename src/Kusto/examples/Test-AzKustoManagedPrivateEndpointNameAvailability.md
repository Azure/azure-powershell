### Example 1: Checks whether the ManagedPrivateEndpoint name is available in the given cluster
```powershell
PS C:\> Test-AzKustoManagedPrivateEndpointNameAvailability -ClusterName "mycluster" -ResourceGroupName "testrg" -Name "testmanagedprivateendpoint"

Message Name                       NameAvailable Reason
------- ----                       ------------- ------
        testmanagedprivateendpoint True
```

The above command returns whether or not a ManagedPrivateEndpoint name is available in the cluster named "mycluster" in resource group "testrg".