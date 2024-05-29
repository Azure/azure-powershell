### Example 1: get all private link scope of a resource group
```powershell
Get-AzConnectedPrivateLinkScope -ResourceGroupName 'ytongtest'
```

```output
Id                           : /subscriptions/subcriptionid/resourceGroups/ytongtest/providers/M
                               icrosoft.HybridCompute/privateLinkScopes/myScope
Location                     : centraluseuap
Name                         : myScope
PrivateEndpointConnection    : {}
PrivateLinkScopeId           : scopeId
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : ytongtest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.HybridCompute/privateLinkScopes
```

get all private link scope of a resource group

### Example 2: get specific private link scope
```powershell
Get-AzConnectedPrivateLinkScope -ResourceGroupName 'ytongtest' -ScopeName 'myScope'
```

```output
Id                           : /subscriptions/********-****-****-****-**********/resourceGroups/ytongtest/providers/Microsoft.HybridCompute/privateLinkScopes/myScope
Location                     : centraluseuap
Name                         : myScope
PrivateEndpointConnection    : {}
PrivateLinkScopeId           : ********-****-****-****-**********
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : ytongtest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.HybridCompute/privateLinkScopes
```
get specific private link scope