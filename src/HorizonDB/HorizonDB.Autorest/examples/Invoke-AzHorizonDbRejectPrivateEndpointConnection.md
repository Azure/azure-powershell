### Example 1: Approve a private endpoint connection
```powershell
Invoke-AzHorizonDbRejectPrivateEndpointConnection -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PrivateEndpointConnectionName 'example-private-endpoint-connection' -PrivateLinkServiceConnectionStateStatus 'Approved' -PrivateLinkServiceConnectionStateDescription 'Approved for the production database network' | Format-List -Property Name, PrivateLinkServiceConnectionStateStatus, PrivateLinkServiceConnectionStateDescription, ProvisioningState
```

```output
Name                                         : example-private-endpoint-connection
PrivateLinkServiceConnectionStateStatus      : Approved
PrivateLinkServiceConnectionStateDescription : Approved for the production database network
ProvisioningState                            : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Reject a private endpoint connection
```powershell
Invoke-AzHorizonDbRejectPrivateEndpointConnection -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PrivateEndpointConnectionName 'example-private-endpoint-connection' -PrivateLinkServiceConnectionStateStatus 'Rejected' -PrivateLinkServiceConnectionStateDescription 'Connection is not authorized'
```

Rejects the specified private endpoint connection.

The supplied REST example includes an approval response only, so no rejection output is shown.
