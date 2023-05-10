---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azvhubinboundroutes

schema: 2.0.0
---

# Get-AzVHubInboundRoutes

## SYNOPSIS
Retrieves the inbound routes of a virtual hub connection

## SYNTAX

### ByVirtualHubName (Default)
```
Get-AzVHubInboundRoutes -ResourceGroupName <String> -VirtualHubName <String> -ResourceUri <String> -VirtualWanConnectionType <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByVirtualHubObject
```
Get-AzVHubInboundRoutes -VirtualHub <PSVirtualHub> -ResourceUri <String> -VirtualWanConnectionType <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByVirtualHubResourceId
```
Get-AzVHubInboundRoutes -VirtualHubResourceId <String> -ResourceUri <String> -VirtualWanConnectionType <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the inbound routes of the given virtual hub connection

## EXAMPLES

### Example 1

```powershell
New-AzVirtualWan -ResourceGroupName "testRg" -Name "testWan" -Location "westcentralus" -VirtualWANType "Standard" -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
$virtualWan = Get-AzVirtualWan -ResourceGroupName "testRg" -Name "testWan"
New-AzVirtualHub -ResourceGroupName "testRg" -Name "testHub" -Location "westcentralus" -AddressPrefix "10.0.0.0/16" -VirtualWan $virtualWan
$virtualHub = Get-AzVirtualHub -ResourceGroupName "testRg" -Name "testHub"
$hubRouteTableId = "/subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/testHub/hubRouteTables/defaultRouteTable"
Get-AzVHubRouteTable -VirtualHub $virtualHub -ResourceId $hubRouteTableId -VirtualWanResourceType "RouteTable"
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

This command gets the inbound routes of the virtual hub spoke vnet connection.

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
