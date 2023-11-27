### Example 1: Delete an existing Kusto PrivateEndpointConnection by name
```powershell
Remove-AzKustoPrivateEndpointConnection -ClusterName "mycluster" -ResourceGroupName "testrg" -Name "testprivateconnection-12345678-1234-1234-1234-123456789098"
```

The above command deletes the Kusto PrivateEndpointConnection named "testprivateconnection-12345678-1234-1234-1234-123456789098" in the cluster "mycluster" found in the resource group "testrg".	