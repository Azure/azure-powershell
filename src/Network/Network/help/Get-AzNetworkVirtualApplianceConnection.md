---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkvirtualapplianceconnection
schema: 2.0.0
---

# Get-AzNetworkVirtualApplianceConnection

## SYNOPSIS
Get or List Network Virtual Appliances connections connected to a Network Virtual Appliance.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Get-AzNetworkVirtualApplianceConnection -ResourceGroupName <String> -VirtualApplianceName <String>
 [-Name <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceObjectParameterSet
```
Get-AzNetworkVirtualApplianceConnection -VirtualAppliance <PSNetworkVirtualAppliance> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzNetworkVirtualApplianceConnection -VirtualApplianceResourceId <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzNetworkVirtualApplianceConnection commands gets or lists connections connected to a Network Virtual Appliance.

## EXAMPLES

### Example 1

```powershell
Get-AzNetworkVirtualApplianceConnection -ResourceGroupName testrg -VirtualApplianceName nva
```

```output
Name                   : defaultConnection
ProvisioningState      : Succeeded
PropagateStaticRoutes  : False
EnableInternetSecurity : False
BgpPeerAddress         : []
Asn                    : 65222
TunnelIdentifier       : 0
RoutingConfiguration   : {
                           "AssociatedRouteTable": {
                             "Id":"/subscriptions/{subid}/resourceGroups/{resource-group-name}/providers/Microsoft.Network/virtualHubs/{hub-name}//hubRouteTables/defaultRouteTable"
                           },
                           "PropagatedRouteTables": {
                             "Labels": [],
                             "Ids": [
                               {
                                 "Id": "/subscriptions/{subid}/resourceGroups/{resource-group-name}/providers/Microsoft.Network/virtualHubs/{hub-name}//hubRouteTables/defaultRouteTable"
                               }
                             ]
                           },
                           "InboundRouteMap": {},
                           "OutboundRouteMap": {}
                         }
```

The above will gets the connection from "testRG" resource group using Resource group and Parent NVA name

### Example 2

```powershell
$nva = Get-AzNetworkVirtualAppliance -ResourceGroupName testrg -Name nva
Get-AzNetworkVirtualApplianceConnection -VirtualAppliance $nva
```

```output
Name                   : defaultConnection
ProvisioningState      : Succeeded
PropagateStaticRoutes  : False
EnableInternetSecurity : False
BgpPeerAddress         : []
Asn                    : 65222
TunnelIdentifier       : 0
RoutingConfiguration   : {
                           "AssociatedRouteTable": {
                             "Id":"/subscriptions/{subid}/resourceGroups/{resource-group-name}/providers/Microsoft.Network/virtualHubs/{hub-name}//hubRouteTables/defaultRouteTable"
                           },
                           "PropagatedRouteTables": {
                             "Labels": [],
                             "Ids": [
                               {
                                 "Id": "/subscriptions/{subid}/resourceGroups/{resource-group-name}/providers/Microsoft.Network/virtualHubs/{hub-name}//hubRouteTables/defaultRouteTable"
                               }
                             ]
                           },
                           "InboundRouteMap": {},
                           "OutboundRouteMap": {}
                         }
```

This cmdlet gets the NVA connection using Network Virtual Appliance object.

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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, NetworkVirtualApplianceConnectionName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualAppliance
The parent Network Virtual Appliance for this connection.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualAppliance
Parameter Sets: ResourceObjectParameterSet
Aliases: ParentNva, NetworkVirtualAppliance

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualApplianceName
The parent virtual appliance resource name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases: ParentNvaName, NetworkVirtualApplianceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualApplianceResourceId
The resource id of the parent Network Virtual Appliance for this connection.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases: ParentNvaId, NetworkVirtualApplianceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualAppliance

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualApplianceConnection

## NOTES

## RELATED LINKS
