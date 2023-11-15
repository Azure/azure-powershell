### Example 1: Update-AzConnectedNetworkDeviceTag via Resource name and Device name
```powershell
$tags = @{ NewTag = "NewTagValue"}
Update-AzConnectedNetworkDeviceTag -DeviceName "myMecDevice" -ResourceGroupName "myResources" -Tag $tags
```

```output
DeviceType                   : AzureStackEdge
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/devices/myMecDevice
Location                     : eastus
Name                         : myMecDevice
NetworkFunction              :
ProvisioningState            : Succeeded
ResourceGroupName            : myResources
Status                       : NotRegistered
SystemDataCreatedAt          : 11/25/2021 4:47:45 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/25/2021 5:22:57 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20.TrackedResourceTags
Type                         : microsoft.hybridnetwork/devices
```

Creating an identity with field NewTag and value NewTagValue. Updating the tag of device with resource name myMecDevice in resource group myResources.

### Example 2: Update-AzConnectedNetworkDeviceTag via Identity
```powershell
$tags = @{ NewTag1 = "NewTagValue1"}
$mecDevice = @{ DeviceName = "myMecDevice1"; Location = "eastus"; ResourceGroupName = "myResources"; SubscriptionId = "xxxxx-00000-xxxxx-00000"}
Update-AzConnectedNetworkDeviceTag -InputObject $mecDevice -Tag $tags
```

```output
DeviceType                   : AzureStackEdge
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/devices/mec_2111_09
Location                     : eastus
Name                         : mec_2111_09
NetworkFunction              : {/subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/mrg-vmware_sdwan_edge_zones-20211124063650/providers/Microsoft.HybridNetwork/networkFunctions/Edge101}
ProvisioningState            : Succeeded
ResourceGroupName            : myResources
Status                       : Registered
SystemDataCreatedAt          : 11/23/2021 10:27:13 PM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/25/2021 5:53:12 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20.TrackedResourceTags
Type                         : microsoft.hybridnetwork/devices

```

Creating an identity with field NewTag1 and value NewTagValue1. Creating another identity with device name myMecDevice1, resource group myResources, location eastus and specified subscription. Updating the tag of device using identity.