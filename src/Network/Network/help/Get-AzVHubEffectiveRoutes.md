---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azvhubeffectiveroutes

schema: 2.0.0
---

# Get-AzVHubEffectiveRoutes

## SYNOPSIS
Retrieves the effective routes of a virtual hub resource

## SYNTAX

### ByVirtualHubName (Default)
```
Get-AzVHubEffectiveRoutes -ResourceGroupName <String> -VirtualHubName <String> -ResourceId <String> -VirtualWanResourceType <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByVirtualHubObject
```
Get-AzVHubEffectiveRoutes -VirtualHub <PSVirtualHub> -ResourceId <String> -VirtualWanResourceType <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByVirtualHubResourceId
```
Get-AzVHubEffectiveRoutes -VirtualHubResourceId <String> -ResourceId <String> -VirtualWanResourceType <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the effective routes of the given virtual hub resource

## EXAMPLES

### Example 1

```powershell
New-AzVirtualWan -ResourceGroupName "testRg" -Name "testWan" -Location "westcentralus" -VirtualWANType "Standard" -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
$virtualWan = Get-AzVirtualWan -ResourceGroupName "testRg" -Name "testWan"
New-AzVirtualHub -ResourceGroupName "testRg" -Name "testHub" -Location "westcentralus" -AddressPrefix "10.0.0.0/16" -VirtualWan $virtualWan
$virtualHub = Get-AzVirtualHub -ResourceGroupName "testRg" -Name "testHub"
$hubRouteTableId = "/subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/testHub/hubRouteTables/defaultRouteTable"
Get-AzVHubEffectiveRoutes -VirtualHub $virtualHub -ResourceId $hubRouteTableId -VirtualWanResourceType "RouteTable"
``` 

```output
Name                   : testRouteTable
Id                     : /subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/testHub/hubRouteTables/testRouteTable
ProvisioningState      : Succeeded
Labels                 : {testLabel}
Routes                 : [
                           {
                             "Name": "private-traffic",
                             "DestinationType": "CIDR",
                             "Destinations": [
                               "10.30.0.0/16",
                               "10.40.0.0/16"
                             ],
                             "NextHopType": "ResourceId",
                             "NextHop": "/subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/azureFirewalls/testFirewall"
                           }
                         ]
AssociatedConnections  : []
PropagatingConnections : []
```

This command gets the effective routes of the virtual hub default route table.

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

### -ResourceId
The resource id of a virtual wan resource.

```yaml
Type: System.String

Required: True
Accept pipeline input: False (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHub
The parent resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualHub
Parameter Sets: ByVirtualHubObject
Aliases: ParentObject, ParentVirtualHub

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualHubName
The virtual hub resource name.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubName
Aliases: VirtualHubName, ParentVirtualHubName, ParentResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubResourceId
The virtual hub resource id.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubResourceId
Aliases: VirtualHubId, ParentVirtualHubId

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualWanResourceType
The virtual wan resource type.

```yaml
Type: System.String

Required: True
Accept pipeline input: False (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualHub

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualHubEffectiveRouteList

## NOTES

## RELATED LINKS
