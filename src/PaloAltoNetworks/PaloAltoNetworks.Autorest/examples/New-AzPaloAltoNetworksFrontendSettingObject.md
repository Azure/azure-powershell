### Example 1: Create an in-memory object for FrontendSetting.
```powershell
New-AzPaloAltoNetworksFrontendSettingObject -BackendConfigurationPort "80" -FrontendConfigurationPort "80" -Name "azps-panfs" -Protocol 'TCP' -Address "20.22.91.251" -BackendConfigurationAddress1 "20.22.32.136" -BackendConfigurationAddressResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/mj-liftr-integration/providers/Microsoft.Network/publicIPAddresses/mj-liftr-integration-frontendSettingIp2" -FrontendConfigurationAddressResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/mj-liftr-integration/providers/Microsoft.Network/publicIPAddresses/mj-liftr-integration-frontendSettingIp1"
```

```output
Name       Protocol
----       --------
azps-panfs TCP
```

Create an in-memory object for FrontendSetting.