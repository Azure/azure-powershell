### Example 1: List all Relay namespaces within the resource group
```powershell
Get-AzRelayNamespace -ResourceGroupName lucas-relay-rg
```

```output
Name             ResourceGroupName Location        Status SkuName  ServiceBusEndpoint
----             ----------------- --------        ------ -------  ------------------
lucasrelay       lucas-relay-rg    West Central US Active Standard https://lucasrelay.servicebus.windows.net:443/
namespace-pwsh01 lucas-relay-rg    East US         Active Standard https://namespace-pwsh01.servicebus.windows.net:443/
```

The cmdlet lists all Relay namespaces within the resource group.

### Example 2: Gets a description for the specified Relay namespace within the resource group
```powershell
Get-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01 | Format-List
```

```output
CreatedAt                    : 12/20/2022 3:20:46 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microso
                               ft.Relay/namespaces/namespace-pwsh01
Location                     : East US
MetricId                     : 9e223dbe-3399-4e19-88eb-0975f02ac87f:namespace-pwsh01
Name                         : namespace-pwsh01
PrivateEndpointConnection    : 
ProvisioningState            : Succeeded
PublicNetworkAccess          : 
ResourceGroupName            : lucas-relay-rg
ServiceBusEndpoint           : https://namespace-pwsh01.servicebus.windows.net:443/
SkuName                      : Standard
SkuTier                      : Standard
Status                       : Active
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
Type                         : Microsoft.Relay/Namespaces
UpdatedAt                    : 12/20/2022 3:21:28 AM
```

The cmdlet gets a description for the specified Relay namespace within the resource group.

### Example 3: Gets a description for the specified Relay namespace by pipeline
```powershell
$namespaces = Get-AzRelayNamespace -ResourceGroupName lucas-relay-rg 
$namespaces[0] | Get-AzRelayNamespace
```

```output
Name       ResourceGroupName Location        Status SkuName  ServiceBusEndpoint
----       ----------------- --------        ------ -------  ------------------
lucasrelay lucas-relay-rg    West Central US Active Standard https://lucasrelay.servicebus.windows.net:443/
```

The cmdlet gets a description for the specified Relay namespace by pipeline.