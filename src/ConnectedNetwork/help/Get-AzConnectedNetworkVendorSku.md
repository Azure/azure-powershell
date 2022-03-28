---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://docs.microsoft.com/powershell/module/az.connectednetwork/get-azconnectednetworkvendorsku
schema: 2.0.0
---

# Get-AzConnectedNetworkVendorSku

## SYNOPSIS
Gets information about the specified sku.

## SYNTAX

### List (Default)
```
Get-AzConnectedNetworkVendorSku -VendorName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzConnectedNetworkVendorSku -SkuName <String> -VendorName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedNetworkVendorSku -InputObject <IConnectedNetworkIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified sku.

## EXAMPLES

### Example 1: Get-AzConnectedNetworkVendorSku using Vendor name and Subscription Id
```powershell
PS C:\> Get-AzConnectedNetworkVendorSku -VendorName myVendor -SubscriptionId xxxxx-22222-xxxxx-22222

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

### -SkuName
The name of the sku.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IVendorSku

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IConnectedNetworkIdentity>: Identity Parameter
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

