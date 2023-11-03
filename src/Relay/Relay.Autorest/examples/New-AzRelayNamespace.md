### Example 1: Creates a new Relay namespace
```powershell
New-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01 -Location eastus
```

```output
New-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01 -Location eastus

Name             ResourceGroupName Location Status SkuName  ServiceBusEndpoint
----             ----------------- -------- ------ -------  ------------------
namespace-pwsh01 lucas-relay-rg    East US  Active Standard https://namespace-pwsh01.servicebus.windows.net:443/
```

The cmdlet creates a new Relay namespace. Once created, the namespace resource manifest is immutable.