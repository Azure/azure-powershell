## EXAMPLES

### Example 1: Update an existing ManagedPrivateEndpoint
```powershell
PS C:\> Update-AzKustoManagedPrivateEndpoint -ResourceGroupName "testrg" -ClusterName "mycluster" -Name "ManagedPrivateEndpointName" -RequestMessage "Please Approve Managed Private Endpoint Request." -GroupId "blob" -PrivateLinkResourceId "/subscriptions/12345678-1234-1234-1234-123456789098/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/storageAccountTest"

Name                                                       Type
----                                                       ----
ManagedPrivateEndpointName                                 Microsoft.Kusto/Clusters/ManagedPrivateEndpoints
```

The above command updates the existing ManagedPrivateEndpoint named "ManagedPrivateEndpointName" in the cluster "mycluster".