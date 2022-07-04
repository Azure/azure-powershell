---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/remove-azexpressrouteportauthorization
schema: 2.0.0
---

# Remove-AzExpressRoutePortAuthorization

## SYNOPSIS
Removes an existing ExpressRoutePort authorization.

## SYNTAX

```
Remove-AzExpressRoutePortAuthorization -Name <String> -ExpressRoutePortObject <PSExpressRoutePort> [-Force]
 [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzExpressRoutePortAuthorization** cmdlet removes an authorization assigned to an ExpressRoutePort.

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
Remove-AzExpressRoutePortAuthorization -Name "ContosoPortAuthorization" -ExpressRoutePortObject $ERPort
```

```output
Confirm
Are you sure you want to remove resource 'ContosoPortAuthorization'
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): y
```

This example removes an authorization from an ExpressRoutePort. The first command uses
the **Get-AzExpressRoutePort** cmdlet to create an object reference to an ExpressRoutePort
named ContosoPort and stores the result in the variable named $ERPort.
The second command removes the ExpressRoutePort authorization ContosoPortAuthorization from
the ContosoPort.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Force
Do not ask for confirmation if you want to delete resource

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the ExpressRoutePort authorization that this cmdlet removes.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object representing the item with which you are working. By default, this cmdlet does not generate any output.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzExpressRoutePortAuthorization](./Get-AzExpressRoutePortAuthorization.md)

[Add-AzExpressRoutePortAuthorization](./Add-AzExpressRoutePortAuthorization.md)
