### Example 1: Rejects a ServiceBus Namespace Private Endpoint Connection
```powershell
Deny-AzServiceBusPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
```

```output
ConnectionState              : Rejected
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/privateEndpointConnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/{resourceGroup}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Rejects private endpoint connection `00000000000` on ServiceBus namespace `myNamespace`.

### Example 2: Rejects a ServiceBus Namespace Private Endpoint Connection using InputObject
```powershell
$privateEndpoint = Get-AzServiceBusPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
Deny-AzServiceBusPrivateEndpointConnection -InputObject $privateEndpoint
```

```output
ConnectionState              : Rejected
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/{resourceGroup}/providers/Microsoft.ServiceBus/namespaces/{namespace}/privateEndpointC
                               onnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/{resourceGroup}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Rejects private endpoint connection `00000000000` on ServiceBus namespace `myNamespace` using InputObject parameter set.
