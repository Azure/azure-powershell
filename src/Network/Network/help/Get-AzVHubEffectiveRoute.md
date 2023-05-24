---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azVHubEffectiveRoute
schema: 2.0.0
---

# Get-AzVHubEffectiveRoute

## SYNOPSIS
Retrieves the effective routes of a virtual hub resource

## SYNTAX

### ByVirtualHubName (Default)
```
Get-AzVHubEffectiveRoute -ResourceGroupName <String> -VirtualHubName <String> [-ResourceId <String>]
 [-VirtualWanResourceType <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByVirtualHubObject
```
Get-AzVHubEffectiveRoute -VirtualHubObject <PSVirtualHub> [-ResourceId <String>]
 [-VirtualWanResourceType <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByVirtualHubResourceId
```
Get-AzVHubEffectiveRoute -VirtualHubResourceId <String> [-ResourceId <String>]
 [-VirtualWanResourceType <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
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
Get-AzVHubEffectiveRoute -VirtualHubObject $virtualHub -ResourceId $hubRouteTableId -VirtualWanResourceType "RouteTable"
```

```output
Value : [
          {
            "AddressPrefixes": [
              "10.2.0.0/16"
            ],
            "NextHops": [
              "/subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/virtu
        alHubs/testHub/hubVirtualNetworkConnections/testConnection"
            ],
            "NextHopType": "Virtual Network Connection",
            "RouteOrigin": "/subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.
        Network/virtualHubs/testHub/hubVirtualNetworkConnections/testConnection"
          }
        ]
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

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of a virtual wan resource.

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

### -VirtualHubName
The virtual hub resource name.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubName
Aliases: ParentVirtualHubName, ParentResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubObject
The parent resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualHub
Parameter Sets: ByVirtualHubObject
Aliases: ParentObject, ParentVirtualHub

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualHubResourceId
The virtual hub resource id.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubResourceId
Aliases: VirtualHubId, ParentVirtualHubId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualWanResourceType
The virtual wan resource type.

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

### Microsoft.Azure.Commands.Network.Models.PSVirtualHub

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualHubEffectiveRouteList

## NOTES

## RELATED LINKS
