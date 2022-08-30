---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://docs.microsoft.com/powershell/module/az.connectednetwork/get-azconnectednetworkvendorskupreview
schema: 2.0.0
---

# Get-AzConnectedNetworkVendorSkuPreview

## SYNOPSIS
Gets the preview information of a vendor sku.

## SYNTAX

### List (Default)
```
Get-AzConnectedNetworkVendorSkuPreview -SkuName <String> -VendorName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedNetworkVendorSkuPreview -PreviewSubscription <String> -SkuName <String> -VendorName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedNetworkVendorSkuPreview -InputObject <IConnectedNetworkIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the preview information of a vendor sku.

## EXAMPLES

### Example 1: Get-AzConnectedNetworkVendorSkuPreview using sku name, vendor name and preview subscription
```powershell
Get-AzConnectedNetworkVendorSkuPreview -SkuName mySku -VendorName myVendor -PreviewSubscription xxxxx-22222-xxxxx-22222
```

```output
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/providers/Microsoft.HybridNetwork/vendors/myVendor/vendorSkus/mySku/previewSubscriptions/xxxxx-22222-xxxxx-22222
Name                         : xxxxx-22222-xxxxx-22222
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 11/24/2021 4:41:22 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/24/2021 4:41:22 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.hybridnetwork/vendors/vendorskus/previewsubscriptions

```

Getting the preview information of a vendor sku mySku with vendor myVendor for the specified subscription.

### Example 2: Get-AzConnectedNetworkVendorSkuPreview via Identity
```powershell
$skuPreview = @{ SkuName = "mySku";  VendorName = "myVendor"; PreviewSubscription = "xxxxx-22222-xxxxx-22222"; SubscriptionId = "xxxxx-00000-xxxxx-00000"}
Get-AzConnectedNetworkVendorSkuPreview -InputObject $skuPreview
```

```output
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/providers/Microsoft.HybridNetwork/vendors/myVendor/vendorSkus/mySku/previewSubscriptions/xxxxx-22222-xxxxx-22222
Name                         : xxxxx-22222-xxxxx-22222
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 11/24/2021 4:41:22 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/24/2021 4:41:22 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.hybridnetwork/vendors/vendorskus/previewsubscriptions

```

Creating a identity with SkuName mySku, VendorName myVendor, preview subscription and subscription id.
Getting the preview information of this vendor sku using this identity.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IConnectedNetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PreviewSubscription
Preview subscription ID.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The name of the vendor sku.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VendorName
The name of the vendor.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IConnectedNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IPreviewSubscription

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IConnectedNetworkIdentity>`: Identity Parameter
  - `[DeviceName <String>]`: The name of the device resource.
  - `[Id <String>]`: Resource identity path
  - `[LocationName <String>]`: The Azure region where the network function resource was created by the customer.
  - `[NetworkFunctionName <String>]`: The name of the network function.
  - `[PreviewSubscription <String>]`: Preview subscription ID.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RoleInstanceName <String>]`: The name of the role instance of the vendor network function.
  - `[ServiceKey <String>]`: The GUID for the vendor network function.
  - `[SkuName <String>]`: The name of the sku.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VendorName <String>]`: The name of the vendor.
  - `[VendorSkuName <String>]`: The name of the network function sku.

## RELATED LINKS

