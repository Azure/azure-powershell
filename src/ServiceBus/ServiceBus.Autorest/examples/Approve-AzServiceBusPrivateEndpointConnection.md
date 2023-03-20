### Example 1: Approve a ServiceBus Namespace Private Endpoint Connection
```powershell
Approve-AzServiceBusPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
```

```output
ConnectionState              : Approved
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/privateEndpointConnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Network/privateEndpoints/privateEndpointName
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Approves private endpoint connection `00000000000` on ServiceBus namespace `myNamespace`.

### Example 2: Approve a ServiceBus Namespace Private Endpoint Connection using InputObject
```powershell
$privateEndpoint = Get-AzServiceBusPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
Approve-AzServiceBusPrivateEndpointConnection -InputObject $privateEndpoint
```

```output
ConnectionState              : Approved
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/privateEndpointC
                               onnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Network/privateEndpoints/privateEndpointName
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Approves private endpoint connection `00000000000` on ServiceBus namespace `myNamespace` using InputObject parameter set.
