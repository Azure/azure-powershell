### Example 1: Delete an existing Kusto ManagedPrivateEndpoint by name
```powershell
Remove-AzKustoManagedPrivateEndpoint -ClusterName "mycluster" -ResourceGroupName "testrg" -Name "ManagedPrivateEndpointName"
```

The above command deletes the Kusto ManagedPrivateEndpoint named "ManagedPrivateEndpointName" in the cluster "mycluster" found in the resource group "testrg".