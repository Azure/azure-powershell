### Example 1: Rejects an Event Hub Namespace Private Endpoint Connection
```powershell
Deny-AzEventHubPrivateEndpointConnection -ResourceGroupName {resourceGroup} -NamespaceName {namespace} -Name 00000000000
```

```output
ConnectionState              : Rejected
Description                  :
Id                           : /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.EventHub/namespaces/{namespace}/privateEndpointC
                               onnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : {resourceGroup}
```

### Example 2: Rejects an Event Hub Namespace Private Endpoint Connection using InputObject
```powershell
$privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName {resourceGroup} -NamespaceName {namespace} -Name 00000000000

Deny-AzEventHubPrivateEndpointConnection -InputObject $privateEndpoint
```

```output
ConnectionState              : Rejected
Description                  :
Id                           : /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.EventHub/namespaces/{namespace}/privateEndpointC
                               onnections/00000000000
Location                     : Australia East
Name                         : 00000000000
PrivateEndpointId            : /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
ProvisioningState            : Succeeded
ResourceGroupName            : {resourceGroup}
```

