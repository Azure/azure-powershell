---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://docs.microsoft.com/powershell/module/az.connectednetwork/get-azconnectednetworkvendorfunction
schema: 2.0.0
---

# Get-AzConnectedNetworkVendorFunction

## SYNOPSIS
Gets information about the specified vendor network function.

## SYNTAX

### List (Default)
```
Get-AzConnectedNetworkVendorFunction -LocationName <String> -VendorName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedNetworkVendorFunction -LocationName <String> -ServiceKey <String> -VendorName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedNetworkVendorFunction -InputObject <IConnectedNetworkIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified vendor network function.

## EXAMPLES

### Example 1: Get-AzConnectedNetworkVendorFunction via Location Name, Service Key and Subscription
```powershell
Get-AzConnectedNetworkVendorFunction -LocationName centraluseuap -ServiceKey 1234-abcd-4321-dcba -SubscriptionId xxxx-3333-xxxx-3333 -VendorName myVendor
```

```output
Id                                 : /subscriptions/xxxx-3333-xxxx-3333/providers/Microsoft.HybridNetwork/locations/centraluseuap/vendors/myVendor/networkfunctions/1b69005b-9168-4d74-a371-d4c4f6a521d
                                     0
Name                               : 1234-abcd-4321-dcba
NetworkFunctionVendorConfiguration : {Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.SshPublicKey}
ProvisioningState                  : Succeeded
ResourceGroupName                  :
SkuName                            : mySku
SkuType                            : EvolvedPacketCore
SystemDataCreatedAt                : 11/25/2021 2:04:28 PM
SystemDataCreatedBy                : xxxxx-11111-xxxxx-11111
SystemDataCreatedByType            : Application
SystemDataLastModifiedAt           : 11/25/2021 2:04:28 PM
SystemDataLastModifiedBy           : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType       : Application
Type                               : microsoft.hybridnetwork/locations/vendors/networkfunctions
VendorProvisioningState            : NotProvisioned

```

Getting the information of a vendor network function with service key 1234-abcd-4321-dcba, vendor name myVendor, location centraluseuap and subscription.
Service key can be obtained when getting details of network funcrtion or when creating a network function.

### Example 2: Get-AzConnectedNetworkVendorFunction via Identity
```powershell
$vendorNF = @{ ServiceKey = "1234-abcd-4321-dcba"; VendorName = "myVendor"; LocationName = "centraluseuap"; SubscriptionId = "xxxx-3333-xxxx-3333"}
Get-AzConnectedNetworkVendorFunction -InputObject $vendorNF
```

```output
Id                                 : /subscriptions/xxxx-3333-xxxx-3333/providers/Microsoft.HybridNetwork/locations/centraluseuap/vendors/myVendor/networkfunctions/1b69005b-9168-4d74-a371-d4c4f6a521d
                                     0
Name                               : 1234-abcd-4321-dcba
NetworkFunctionVendorConfiguration : {Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.SshPublicKey}
ProvisioningState                  : Succeeded
ResourceGroupName                  :
SkuName                            : mySku
SkuType                            : EvolvedPacketCore
SystemDataCreatedAt                : 11/25/2021 2:04:44 PM
SystemDataCreatedBy                : xxxxx-11111-xxxxx-11111
SystemDataCreatedByType            : Application
SystemDataLastModifiedAt           : 11/25/2021 2:36:28 PM
SystemDataLastModifiedBy           : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType       : Application
Type                               : microsoft.hybridnetwork/locations/vendors/networkfunctions
VendorProvisioningState            : Provisioned

```

Creating a identity with service key 1234-abcd-4321-dcba, vendor name myVendor, location centraluseuap and subscription.
Getting the information of a vendor network function using this identity.

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

### -Filter
The filter to apply on the operation.
The properties you can use for eq (equals) are: skuType, skuName and vendorProvisioningState.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

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

### -LocationName
The Azure region where the network function resource was created by the customer.

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

### -ServiceKey
The GUID for the vendor network function.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IVendorNetworkFunction

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

