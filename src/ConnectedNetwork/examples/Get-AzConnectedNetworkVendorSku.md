### Example 1: Get-AzConnectedNetworkVendorSku using Vendor name and Subscription Id
```powershell
Get-AzConnectedNetworkVendorSku -VendorName myVendor -SubscriptionId xxxxx-22222-xxxxx-22222
```

```output
DeploymentMode                                          : PrivateEdgeZone
Id                                                      : /subscriptions/xxxxx-22222-xxxxx-22222/providers/Microsoft.HybridNetwork/vendors/myVendor/VendorSkus/mySku
ManagedApplicationParameter                             : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.VendorSkuPropertiesFormatManagedApplicationParameters
ManagedApplicationTemplate                              : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.VendorSkuPropertiesFormatManagedApplicationTemplate
Name                                                    : mySku
NetworkFunctionTemplateNetworkFunctionRoleConfiguration : {Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.SshPublicKey}
NetworkFunctionType                                     :
Preview                                                 : True
ProvisioningState                                       : Succeeded
ResourceGroupName                                       :
SkuType                                                 : EvolvedPacketCore
SystemDataCreatedAt                                     : 11/4/2020 3:35:33 PM
SystemDataCreatedBy                                     : user@microsoft.com
SystemDataCreatedByType                                 : User
SystemDataLastModifiedAt                                : 11/4/2020 3:43:58 PM
SystemDataLastModifiedBy                                : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType                            : Application
Type                                                    : Microsoft.HybridNetwork/vendors/VendorSkus

DeploymentMode                                          : PrivateEdgeZone
Id                                                      : /subscriptions/xxxxx-22222-xxxxx-22222/providers/Microsoft.HybridNetwork/vendors/myVendor/vendorskus/mySku_1
ManagedApplicationParameter                             : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.VendorSkuPropertiesFormatManagedApplicationParameters
ManagedApplicationTemplate                              : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.VendorSkuPropertiesFormatManagedApplicationTemplate
Name                                                    : mySku_1
NetworkFunctionTemplateNetworkFunctionRoleConfiguration : {Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.SshPublicKey}
NetworkFunctionType                                     :
Preview                                                 : True
ProvisioningState                                       : Failed
ResourceGroupName                                       :
SkuType                                                 : EvolvedPacketCore
SystemDataCreatedAt                                     : 11/11/2020 2:25:32 PM
SystemDataCreatedBy                                     : user@microsoft.com
SystemDataCreatedByType                                 : User
SystemDataLastModifiedAt                                : 11/11/2020 2:25:32 PM
SystemDataLastModifiedBy                                : user@microsoft.com
SystemDataLastModifiedByType                            : User
Type                                                    : Microsoft.HybridNetwork/vendors/vendorskus
```

Fetching all the sku of vendor myVendor in the given subscription.