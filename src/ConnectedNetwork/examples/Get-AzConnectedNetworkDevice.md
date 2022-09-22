### Example 1: Get-AzConnectedNetworkDevice via Resource Group and Resource name
```powershell
Get-AzConnectedNetworkDevice -ResourceGroupName myResources -Name myMecDevice
```

```output
DeviceType                   : AzureStackEdge
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/devices/myMecDevice
Location                     : westcentralus
Name                         : myMecDevice
NetworkFunction              : {/subscriptions/xxxxx-00000-xxxxx-00000/resourcegroups/myResources/providers/Microsoft.HybridNetwork/networkFunctions/myVnf1}
ProvisioningState            : Succeeded
ResourceGroupName            : myResources
Status                       : Registered
SystemDataCreatedAt          : 11/25/2020 5:34:49 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/25/2020 5:58:38 AM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20.TrackedResourceTags
Type                         : Microsoft.HybridNetwork/devices

```

Getting information about the NFM device in resource group myResources with name myMecDevice.

### Example 2: Get-AzConnectedNetworkDevice via Identity
```powershell
$mecDevice = @{ DeviceName = "myMecDevice1"; Location = "eastus"; ResourceGroupName = "myResources"; SubscriptionId = "xxxxx-00000-xxxxx-00000"}
Get-AzConnectedNetworkDevice -InputObject $mecDevice
```

```output
DeviceType                   : AzureStackEdge
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/devices/myMecDevice1
Location                     : eastus
Name                         : myMecDevice1
NetworkFunction              : {/subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/mrg-vmware_sdwan_edge_zones-20211124063650/providers/Microsoft.HybridNetwork/networkFunctions/myEdge1}
ProvisioningState            : Succeeded
ResourceGroupName            : myResources
Status                       : Registered
SystemDataCreatedAt          : 11/23/2021 10:27:13 PM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/24/2021 7:42:41 AM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20.TrackedResourceTags
Type                         : microsoft.hybridnetwork/devices

```

Creating an identity with device name myMecDevice1, resource group myResources and the given subscription. Getting the information about the device using this identity.