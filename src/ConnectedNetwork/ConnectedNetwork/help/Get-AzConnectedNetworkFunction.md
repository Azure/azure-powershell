---
external help file: Az.ConnectedNetwork-help.xml
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/get-azconnectednetworkfunction
schema: 2.0.0
---

# Get-AzConnectedNetworkFunction

## SYNOPSIS
Gets information about the specified network function resource.

## SYNTAX

### List (Default)
```
Get-AzConnectedNetworkFunction [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedNetworkFunction -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzConnectedNetworkFunction -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedNetworkFunction -InputObject <IConnectedNetworkIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified network function resource.

## EXAMPLES

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

Creating an identity with NetworkFunctionName myVnf1, ResourceGroupName myResources and subscription.
Getting information about the network function using this identity.

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
The name of the network function resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NetworkFunctionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.INetworkFunction

## NOTES

## RELATED LINKS
