### Example 1: Approve an Event Hub Namespace Private Endpoint Connection
```powershell
Approve-AzEventHubPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
```

```output
ConnectionState              : Approved
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/privateEndpointConnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Network/privateEndpoints/privateEndpointName
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Approves private endpoint connection `00000000000` on EventHub namespace `myNamespace`.

### Example 2: Approve an Event Hub Namespace Private Endpoint Connection using InputObject
```powershell
$privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
Approve-AzEventHubPrivateEndpointConnection -InputObject $privateEndpoint
```

```output
ConnectionState              : Approved
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/privateEndpointConnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Network/privateEndpoints/privateEndpointName
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Approves private endpoint connection `00000000000` on EventHub namespace `myNamespace` using InputObject parameter set.
