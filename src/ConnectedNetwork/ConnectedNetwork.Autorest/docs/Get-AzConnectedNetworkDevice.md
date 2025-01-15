---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/get-azconnectednetworkdevice
schema: 2.0.0
---

# Get-AzConnectedNetworkDevice

## SYNOPSIS
Gets information about the specified device.

## SYNTAX

### List (Default)
```
Get-AzConnectedNetworkDevice [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedNetworkDevice -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedNetworkDevice -InputObject <IConnectedNetworkIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzConnectedNetworkDevice -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified device.

## EXAMPLES

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

Creating an identity with device name myMecDevice1, resource group myResources and the given subscription.
Getting the information about the device using this identity.

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
The name of the device resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DeviceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IDevice

## NOTES

## RELATED LINKS

