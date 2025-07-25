### Example 1: Updates a Relay namespace
```powershell
Update-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01 -Tag @{'k'='v'}
```

```output
Name             ResourceGroupName Location Status     SkuName  ServiceBusEndpoint
----             ----------------- -------- ------     -------  ------------------
namespace-pwsh01 lucas-relay-rg    East US  Activating Standard https://namespace-pwsh01.servicebus.windows.net:443/
```

This cmdlet updates a Relay namespace.

### Example 2: Updates a Relay namespace by pipeline
```powershell
Get-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01 | Update-AzRelayNamespace -Tag @{'k'='v'}
```

```output
Name             ResourceGroupName Location Status     SkuName  ServiceBusEndpoint
----             ----------------- -------- ------     -------  ------------------
namespace-pwsh01 lucas-relay-rg    East US  Activating Standard https://namespace-pwsh01.servicebus.windows.net:443/
```

This cmdlet updates a Relay namespace by pipeline.