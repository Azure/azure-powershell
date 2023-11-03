### Example 1: Create an in-memory object for NginxNetworkProfile
```powershell
New-AzNginxNetworkProfileObject -FrontEndIPConfiguration @{PublicIPAddress=@($publicIp)} -NetworkInterfaceConfiguration @{SubnetId='/subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/nginx-test-rg/providers/Microsoft.Network/virtualNetworks/nginx-test-vnet/subnets/default'}
```

```output
FrontEndIPConfiguration        NetworkInterfaceConfiguration
-----------------------        -----------------------------
{…                             {…
```

Create an in-memory object for NginxNetworkProfile.
