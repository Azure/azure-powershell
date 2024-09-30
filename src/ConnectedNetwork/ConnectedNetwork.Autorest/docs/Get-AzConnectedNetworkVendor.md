---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/get-azconnectednetworkvendor
schema: 2.0.0
---

# Get-AzConnectedNetworkVendor

## SYNOPSIS
Gets information about the specified vendor.

## SYNTAX

### List (Default)
```
Get-AzConnectedNetworkVendor [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedNetworkVendor -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedNetworkVendor -InputObject <IConnectedNetworkIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified vendor.

## EXAMPLES

### Example 1: Get-AzConnectedNetworkVendor using vendor name
```powershell
Get-AzConnectedNetworkVendor -Name myVendor
```

```output
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/providers/Microsoft.HybridNetwork/vendors/myVendor
Name                         : myVendor
ProvisioningState            : Succeeded
ResourceGroupName            :
Sku                          :
SystemDataCreatedAt          : 9/7/2021 3:02:02 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/7/2021 3:02:03 AM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Type                         : microsoft.hybridnetwork/vendors

```

Getting information about the vendor with vendor name myVendor.

### Example 2: Get-AzConnectedNetworkVendor using Identity
```powershell
$vendor = @{ VendorName = "myVendor1"; SubscriptionId = "xxxxx-00000-xxxxx-00000"}
Get-AzConnectedNetworkVendor -InputObject $vendor
```

```output
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/providers/Microsoft.HybridNetwork/vendors/myVendor1
Name                         : myVendor1
ProvisioningState            : Succeeded
ResourceGroupName            :
Sku                          :
SystemDataCreatedAt          : 9/7/2021 3:02:02 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/7/2021 3:02:03 AM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Type                         : microsoft.hybridnetwork/vendors

```

Creating an identity with VendorName myVendor1 and the given subscription.
Getting information about the vendor using this identity.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Name
The name of the vendor.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: VendorName

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IConnectedNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IVendor

## NOTES

## RELATED LINKS

