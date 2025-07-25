### Example 1: Create trunked network
```powershell
New-AzNetworkCloudTrunkedNetwork -Name trunkedNetworkName -ResourceGroupName trunkedNetworkRg -SubscriptionId subscriptionId -ExtendedLocationName extendedLocationName -ExtendedLocationType "CustomLocation" -Location location -Vlan vlans -IsolationDomainId isolationDomainId -InterfaceName interfaceName -Tag @{ tag = "tag" }
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity>
```

This command creates a trunked network.
