### Example 1: Get-AzConnectedNetworkFunction via Resource group and Resource name
```powershell
Get-AzConnectedNetworkFunction -Name myVnf -ResourceGroupName myResources
```

```output
ContainerConfiguration       : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.NetworkFunctionPropertiesFormatNetworkFunctionContainerConfigurations
DeviceId                     : /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/devices/myMec
Etag                         : "0000a530-0000-3400-0000-615c10fa0000"
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/networkFunctions/myVnf
Location                     : centraluseuap
ManagedApplicationId         :
ManagedApplicationParameter  : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.NetworkFunctionPropertiesFormatManagedApplicationParameters
Name                         : myVnf
ProvisioningState            : Failed
ResourceGroupName            : myResources
ServiceKey                   : 397a7415-ec52-46b5-892b-f840ba491aab
SkuName                      : mySku1
SkuType                      : EvolvedPacketCore
SystemDataCreatedAt          : 10/5/2021 8:45:49 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/5/2021 8:46:49 AM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20.TrackedResourceTags
Type                         : microsoft.hybridnetwork/networkfunctions
UserConfiguration            : {hpehss}
VendorName                   : AffirmedVendor
VendorProvisioningState      : NotProvisioned

```

Getting information about the network function in resource group myResources with resource name myVnf.

### Example 2: Get-AzConnectedNetworkFunction via Identity
```powershell
$vnf = @{ NetworkFunctionName = "myVnf1"; ResourceGroupName = "myResources"; SubscriptionId = "xxxxx-00000-xxxxx-00000"}
Get-AzConnectedNetworkFunction -InputObject $vnf
```

```output
ContainerConfiguration       : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.NetworkFunctionPropertiesFormatNetworkFunctionContainerConfigurations
DeviceId                     : /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/devices/myMec1
Etag                         : "sampleEtagValue"
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/networkFunctions/myVnf1
Location                     : eastus
ManagedApplicationId         :
ManagedApplicationParameter  : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.NetworkFunctionPropertiesFormatManagedApplicationParameters
Name                         : myVnf1
ProvisioningState            : Succeeded
ResourceGroupName            : myResources
ServiceKey                   : aa11-bb22-cc33-dd44
SkuName                      : mySku
SkuType                      : EvolvedPacketCore
SystemDataCreatedAt          : 11/1/2021 11:13:57 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/15/2021 4:53:08 AM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20.TrackedResourceTags
Type                         : microsoft.hybridnetwork/networkfunctions
UserConfiguration            : {hpehss}
VendorName                   : AffirmedVendor
VendorProvisioningState      : Provisioned

```

Creating an identity with NetworkFunctionName myVnf1, ResourceGroupName myResources and subscription. Getting information about the network function using this identity.