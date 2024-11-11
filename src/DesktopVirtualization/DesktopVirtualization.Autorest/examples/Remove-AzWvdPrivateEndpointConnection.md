### Example 1: Remove the Private Endpoint Connection between the Private Endpoint and Windows Virtual Desktop HostPool by WVD Private Endpoint Connection Name and HostPoolName

```powershell
Remove-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -Name WvdPrivateEndpointConnectionName -HostpoolName HostPoolName
```

```output
<none>
```

This command removes the Private Endpoint Connection to the Windows Virtual Desktop HostPool in a Resource Group. It does not delete the Private Endpoint. Customers will need to separately delete the Private Endpoint.


### Example 2: Remove the Private Endpoint Connection between the Private Endpoint and Windows Virtual Desktop Workspace by WVD Private Endpoint Connection Name and WorkspaceName

```powershell
Remove-AzWvdPrivateEndpointConnection -ResourceGroupName ResourceGroupName -Name WvdPrivateEndpointConnectionName -WorkspaceName WorkspaceName
```

```output
<none>
```

This command removes the Private Endpoint Connection to the Windows Virtual Desktop Workspace in a Resource Group. It does not delete the Private Endpoint. Customers will need to separately delete the Private Endpoint.

--------