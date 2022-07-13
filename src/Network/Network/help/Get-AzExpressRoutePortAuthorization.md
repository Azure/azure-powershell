---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-azexpressrouteportauthorization
schema: 2.0.0
---

# Get-AzExpressRoutePortAuthorization

## SYNOPSIS
Gets information about ExpressRoutePort authorizations.

## SYNTAX

```
Get-AzExpressRoutePortAuthorization [-Name <String>] -ExpressRoutePortObject <PSExpressRoutePort>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRoutePortAuthorization** cmdlet gets information about the
authorizations assigned to an ExpressRoutePort.  The owner of an ExpressRoutePort
can create these authorizations which generate an authorization key that can be 
used by a ExpressRoute circuit owner to create the circuit on the ExpressRoutePort 
(with a different owner). Only one circuit can be created with one ExpressRoutePort
authorization. Authorization keys, as well as other information about 
the authorization, can be viewed at any time by running
**Get-AzExpressRoutePortAuthorization**.

## EXAMPLES

### Example 1
```powershell
$ERPort = Get-AzExpressRoutePort -Name "ContosoPort" -ResourceGroupName "ContosoResourceGroup"
```

```output
Name                       : ContosoPort
ResourceGroupName          : ContosoResourceGroup
Location                   : westcentralus
Id                         : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/ContosoResourceGroup/pr
                             oviders/Microsoft.Network/expressRoutePorts/ContosoPort
Etag                       : W/"cf987288-013e-40bf-a2aa-b29d017e7b7f"
ResourceGuid               : 4c0e5cdb-79e1-4cb8-a430-0ce9b24472ca
ProvisioningState          : Succeeded
PeeringLocation            : Area51-ERDirect
BandwidthInGbps            : 100
ProvisionedBandwidthInGbps : 0
Encapsulation              : QinQ
Mtu                        : 1500
EtherType                  : 0x8100
AllocationDate             : Thursday, March 31, 2022
Identity                   : null
Links                      : [
                               {
                                 "Name": "link1",
                                 "Etag": "W/\"cf987288-013e-40bf-a2aa-b29d017e7b7f\"",
                                 "Id": "/subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/ContosoResou
                             rceGroup/providers/Microsoft.Network/expressRoutePorts/ContosoPort/links/link1",
                                 "RouterName": "a51-test-06gmr-cis-3",
                                 "InterfaceName": "HundredGigE15/15/19",
                                 "PatchPanelId": "PP:0123:1110201 - Port 42",
                                 "RackId": "A51 02050-0123-L",
                                 "ConnectorType": "LC",
                                 "AdminState": "Disabled",
                                 "ProvisioningState": "Succeeded",
                                 "MacSecConfig": {
                                   "SciState": "Disabled",
                                   "Cipher": "GcmAes128"
                                 }
                               },
                               {
                                 "Name": "link2",
                                 "Etag": "W/\"cf987288-013e-40bf-a2aa-b29d017e7b7f\"",
                                 "Id": "/subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/ContosoResou
                             rceGroup/providers/Microsoft.Network/expressRoutePorts/ContosoPort/links/link2",
                                 "RouterName": "a51-test-06gmr-cis-4",
                                 "InterfaceName": "HundredGigE15/15/19",
                                 "PatchPanelId": "2050:0124:1110854 - Port 42",
                                 "RackId": "A51 02050-0124-L",
                                 "ConnectorType": "LC",
                                 "AdminState": "Disabled",
                                 "ProvisioningState": "Succeeded",
                                 "MacSecConfig": {
                                   "SciState": "Disabled",
                                   "Cipher": "GcmAes128"
                                 }
                               }
                             ]
Circuits                   : []
```

```powershell
Get-AzExpressRoutePortAuthorization -ExpressRoutePortObject $ERPort
```

```output
Name                   : ContosoPortAuthorization
Id                     : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/ContosoResourceGroup/provid
                         ers/Microsoft.Network/expressRoutePorts/ContosoPort/authorizations/ContosoPortAuthorization
Etag                   : W/"36ccc199-c371-4d19-88cc-90d51bfe7ea9"
AuthorizationKey       : 10d01cd7-0b67-4c44-88ca-51e7effa452d
AuthorizationUseStatus : Available
ProvisioningState      : Succeeded
CircuitResourceUri     :
```

These commands return information about all the ExpressRoute authorizations associated with an
ExpressRoutePort. The first command uses the **Get-AzExpressRoutePort** cmdlet to
create an object reference a ExpressRoutePort named ContosoPort; that object reference is stored in the
variable $ERPort. The second command then uses that object reference and the
**Get-AzExpressRoutePortAuthorization** cmdlet to return information about the
authorizations associated with ContosoPort. You can also specify the name of the authorization
with this command to a specific authorization associated with ContosoPort.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRoutePortObject
The ExpressRoutePort Object

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the name of the ExpressRoutePort authorization that this cmdlet gets.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePortAuthorization

## NOTES

## RELATED LINKS

[Add-AzExpressRoutePortAuthorization](./Add-AzExpressRoutePortAuthorization.md)

[Remove-AzExpressRoutePortAuthorization](./Remove-AzExpressRoutePortAuthorization.md)
