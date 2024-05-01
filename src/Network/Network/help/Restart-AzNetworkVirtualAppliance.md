---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/restart-aznetworkvirtualappliance
schema: 2.0.0
---

# Restart-AzNetworkVirtualAppliance

## SYNOPSIS
Restarts a virtual machine instance in the Network Virtual Appliance or all the instances in a Network Virtual Appliance.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Restart-AzNetworkVirtualAppliance [-ResourceGroupName] <String> [-Name ] <String> [[-InstanceId] <String[]>] [-DefaultProfile <IAzureContextContainer>]  [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Restart-AzNetworkVirtualAppliance -ResourceId <String> [-Name ] <String> [[-InstanceId] <String[]>] [-DefaultProfile <IAzureContextContainer>]  [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Restart-AzNetworkVirtualAppliance cmdlet restarts the virtual machine instances associated with a Network Virtual Appliance (NVA).This cmdlet can also be used to restart a specific virtual machine associates with the NVA by using the InstanceId parameter.

## EXAMPLES

### Example 1

```powershell
Restart-AzNetworkVirtualAppliance -ResourceGroupName testrg -Name nva
```

```output
Name                   : default
ProvisioningState      : Succeeded
PropagateStaticRoutes  : False
EnableInternetSecurity : False
BgpPeerAddress         : []
Asn                    : 65222
TunnelIdentifier       : 0
RoutingConfiguration   : {
                           "AssociatedRouteTable": {
                             "ResourceUri":"/subscriptions/{subid}/resourceGroups/{resource-group-name}/providers/Microsoft.Network/virtualHubs/{hub-name}//hubRouteTables/defaultRouteTable"
                           },
                           "PropagatedRouteTables": {
                             "Labels": [],
                             "Ids": [
                               {
                                 "ResourceUri": "/subscriptions/{subid}/resourceGroups/{resource-group-name}/providers/Microsoft.Network/virtualHubs/{hub-name}//hubRouteTables/defaultRouteTable"
                               }
                             ]
                           },
                           "InboundRouteMap": {
                             "ResourceUri": ""
                           },
                           "OutboundRouteMap": {
                             "ResourceUri": ""
                           }
                         }
```

This command restarts all the instances belonging to the NVA named nva that belongs to the resource group named testrg.


### Example 2

```powershell
Restart-AzNetworkVirtualAppliance -ResourceGroupName testrg -Name nva -InstanceId "1"
```

```output
Name                   : default
ProvisioningState      : Succeeded
PropagateStaticRoutes  : False
EnableInternetSecurity : False
BgpPeerAddress         : []
Asn                    : 65222
TunnelIdentifier       : 0
RoutingConfiguration   : {
                           "AssociatedRouteTable": {
                             "ResourceUri":"/subscriptions/{subid}/resourceGroups/{resource-group-name}/providers/Microsoft.Network/virtualHubs/{hub-name}//hubRouteTables/defaultRouteTable"
                           },
                           "PropagatedRouteTables": {
                             "Labels": [],
                             "Ids": [
                               {
                                 "ResourceUri": "/subscriptions/{subid}/resourceGroups/{resource-group-name}/providers/Microsoft.Network/virtualHubs/{hub-name}//hubRouteTables/defaultRouteTable"
                               }
                             ]
                           },
                           "InboundRouteMap": {
                             "ResourceUri": ""
                           },
                           "OutboundRouteMap": {
                             "ResourceUri": ""
                           }
                         }
```

This command restarts the instance with ID "1" of the NVA named nva that belongs to the resource group named testrg.

## PARAMETERS

### -AsJob
Run cmdlet in the background and return a Job to track progress
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

### -InstanceId
Specifies, as a string array, the ID of the instances that need restarted.
```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The Network Virtual Appliance resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VirtualApplianceName, NetworkVirtualApplianceName, NvaName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceId
The resource id of the Network Virtual Appliance for this .

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

### system.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualApplianceRestartOperationStatusResponse

## NOTES

## RELATED LINKS