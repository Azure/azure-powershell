### Example 1: Approve an Event Hub Namespace Private Endpoint Connection
```powershell
Approve-AzEventHubPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
```

```output
ConnectionState              : Approved
Description                  :
Id                           : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/privateEndpointConnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : {resourceGroup}
```

Approves private endpoint connection `00000000000` on EventHub namespace `myNamespace`.

### Example 2: Approve an Event Hub Namespace Private Endpoint Connection using InputObject
```powershell
$privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName {resourceGroup} -NamespaceName {namespace} -Name 00000000000
Approve-AzEventHubPrivateEndpointConnection -InputObject $privateEndpoint
```

```output
ConnectionState              : Approved
Description                  :
Id                           : /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.EventHub/namespaces/{namespace}/privateEndpointC
                               onnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : {resourceGroup}
```

Approves private endpoint connection `00000000000` on EventHub namespace `myNamespace` using InputObject parameter set.
