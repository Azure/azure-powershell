---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/update-aznetworkvirtualapplianceconnection
schema: 2.0.0
---

# Update-AzNetworkVirtualApplianceConnection

## SYNOPSIS
Update or Change a Network Virtual Appliance Connection resource.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Update-AzNetworkVirtualApplianceConnection -ResourceGroupName <String> -VirtualApplianceName <String>
 -Name <String> [-RoutingConfiguration <PSRoutingConfiguration>] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceObjectParameterSet
```
Update-AzNetworkVirtualApplianceConnection -VirtualAppliance <PSNetworkVirtualAppliance> -Name <String>
 [-RoutingConfiguration <PSRoutingConfiguration>] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Update-AzNetworkVirtualApplianceConnection -VirtualApplianceResourceId <String> -Name <String>
 [-RoutingConfiguration <PSRoutingConfiguration>] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Update-AzNetworkVirtualApplianceConnectiuon modifies a Network Virtual Appliance Connection resource.

## EXAMPLES

### Example 1
```powershell
$rt1 = Get-AzVHubRouteTable -ResourceGroupName testrg -VirtualHubName vhub1 -Name "noneRouteTable"  
$routingconfig = New-AzRoutingConfiguration -AssociatedRouteTable $rt1.Id -Label @("none") -Id @($rt1.Id)       
Update-AzNetworkVirtualApplianceConnection -ResourceGroupName testrg -VirtualApplianceName nva -Name defaultConnection -RoutingConfiguration $routingconfig
```

```output
Name                   : defaultConnection
ProvisioningState      : Succeeded
EnableInternetSecurity : False
BgpPeerAddress         : {10.2.112.5, 10.2.112.6}
Asn                    : 64512
TunnelIdentifier       : 0
RoutingConfiguration   : {
                           "AssociatedRouteTable": {
                             "Id": "/subscriptions/{subscriptionId}/resourceGroups/testrg/providers/Microsoft.Network/virtualHubs
                         /vhub1/hubRouteTables/noneRouteTable"
                           },
                           "PropagatedRouteTables": {
                             "Labels": [
                               "none"
                             ],
                             "Ids": [
                               {
                                 "Id": "/subscriptions/{subscriptionId}/resourceGroups/testrg/providers/Microsoft.Network/virtualHubs
                         /vhub1/hubRouteTables/noneRouteTable"
                               }
                             ]
                           },
                           "InboundRouteMap": {},
                           "OutboundRouteMap": {}
                         }
```

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

### -Force
Do not ask for confirmation if you want to overwrite a resource

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
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, NetworkVirtualApplianceConnectionName

Required: True
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

### -RoutingConfiguration
The routing configuration for this nva connection

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRoutingConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualAppliance
The parent Network Virtual Appliance object for this connection.

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
The parent Network Virtual Appliance name.

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

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualAppliance

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualApplianceConnection

## NOTES

## RELATED LINKS

[New-AzRoutingConfiguration](./New-AzRoutingConfiguration.md)

[Get-AzNetworkVirtualAppliance](./Get-AzNetworkVirtualAppliance.md)

[Get-AzNetworkVirtualApplianceConnection](./Get-AzNetworkVirtualApplianceConnection.md)

