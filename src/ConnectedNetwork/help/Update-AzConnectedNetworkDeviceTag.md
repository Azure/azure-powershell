---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://docs.microsoft.com/powershell/module/az.connectednetwork/update-azconnectednetworkdevicetag
schema: 2.0.0
---

# Update-AzConnectedNetworkDeviceTag

## SYNOPSIS
Updates device tags.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzConnectedNetworkDeviceTag -DeviceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzConnectedNetworkDeviceTag -InputObject <IConnectedNetworkIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates device tags.

## EXAMPLES

### Example 1: Update-AzConnectedNetworkDeviceTag via Resource name and Device name
```powershell
PS C:\> $tags = @{ NewTag = "NewTagValue"}
PS C:\> Update-AzConnectedNetworkDeviceTag -DeviceName "myMecDevice" -ResourceGroupName "myResources" -Tag $tags


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

Creating an identity with field NewTag and value NewTagValue.
Updating the tag of device with resource name myMecDevice in resource group myResources.

### Example 2: Update-AzConnectedNetworkDeviceTag via Identity
```powershell
PS C:\> $tags = @{ NewTag1 = "NewTagValue1"}
PS C:\> $mecDevice = @{ DeviceName = "myMecDevice1"; Location = "eastus"; ResourceGroupName = "myResources"; SubscriptionId = "xxxxx-00000-xxxxx-00000"}
PS C:\> Update-AzConnectedNetworkDeviceTag -InputObject $mecDevice -Tag $tags

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

Creating an identity with field NewTag1 and value NewTagValue1.
Creating another identity with device name myMecDevice1, resource group myResources, location eastus and specified subscription.
Updating the tag of device using identity.

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

### -DeviceName
The name of the device resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IDevice

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

