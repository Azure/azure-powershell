---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://docs.microsoft.com/powershell/module/az.connectednetwork/update-azconnectednetworkfunctiontag
schema: 2.0.0
---

# Update-AzConnectedNetworkFunctionTag

## SYNOPSIS
Updates the tags for the network function resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzConnectedNetworkFunctionTag -NetworkFunctionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzConnectedNetworkFunctionTag -InputObject <IConnectedNetworkIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the tags for the network function resource.

## EXAMPLES

### Example 1: Update-AzConnectedNetworkFunctionTag
```powershell
$tags = @{ NewTag = "NewTagValue"}
Update-AzConnectedNetworkFunctionTag -NetworkFunctionName myNewVnf1 -ResourceGroupName myResources -Tag $tags
```

```output
Location    Name      Etag              ResourceGroupName
--------    ----      ----              -----------------
eastus2euap myNewVnf1 "sampleEtagValue" myResources
```

Creating an identity with field NewTag and value NewTagValue.
Updating the tag of NF with resource name myNewVnf1 in resource group myResources.

### Example 2: Update-AzConnectedNetworkFunctionTag
```powershell
$tags = @{ NewTag = "NewTagValue"}
$vnf = @{ NetworkFunctionName = "myVnf1"; ResourceGroupName = "myResources"; SubscriptionId = "00000000-0000-0000-0000-000000000000"}
Update-AzConnectedNetworkFunctionTag -InputObject $vnf -Tag $tags
```

```output
Location    Name      Etag                                   ResourceGroupName
--------    ----      ----                                   -----------------
eastus2euap myNewVnf1 "0000f211-0000-3300-0000-61a9edc70000" myResources
```

Creating an identity with field NewTag and value NewTagValue.
Creating an identity with NetworkFunctionName myVnf1, ResourceGroupName myResources and subscription.Updating the tag of NF specified in identity with the tags.

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkFunctionName
Resource name for the network function resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.INetworkFunction

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

