### Example 1: Reject an Event Hub Namespace Private Endpoint Connection
```powershell
Deny-AzEventHubPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
```

```output
ConnectionState              : Rejected
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/privateEndpointC
                               onnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Rejects private endpoint connection `00000000000` on EventHub namespace `myNamespace`.

### Example 2: Reject an Event Hub Namespace Private Endpoint Connection using InputObject
```powershell
$privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
Deny-AzEventHubPrivateEndpointConnection -InputObject $privateEndpoint
```

```output
ConnectionState              : Rejected
Description                  :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/privateEndpointC
                               onnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : myResourceGroup
```

Rejects private endpoint connection `00000000000` on EventHub namespace `myNamespace` using InputObject parameter set.