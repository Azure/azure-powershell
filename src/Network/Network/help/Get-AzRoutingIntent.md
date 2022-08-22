---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-azroutingintent
schema: 2.0.0
---

# Get-AzRoutingIntent

## SYNOPSIS
Retrieves a routing intent resource associated with a VirtualHub.

## SYNTAX

### ByRoutingIntentName (Default)
```powershell
Get-AzRoutingIntent -ResourceGroupName <String> -ParentResourceName <String> -Name <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubObject
```powershell
Get-AzRoutingIntent -Name <String> -VirtualHub <PSVirtualHub> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByRoutingIntentResourceId
```powershell
Get-AzRoutingIntent -ResourceId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified routing intent that is associated with the specified virtual hub.

## EXAMPLES

### Example 1

```powershell
New-AzVirtualWan -ResourceGroupName "testRg" -Name "testWan" -Location "westcentralus" -VirtualWANType "Standard" -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
$virtualWan = Get-AzVirtualWan -ResourceGroupName "testRg" -Name "testWan"

New-AzVirtualHub -ResourceGroupName "testRg" -Name "testHub" -Location "westcentralus" -AddressPrefix "10.0.0.0/16" -VirtualWan $virtualWan
$virtualHub = Get-AzVirtualHub -ResourceGroupName "testRg" -Name "testHub"

$fwIp = New-AzFirewallHubPublicIpAddress -Count 1
$hubIpAddresses = New-AzFirewallHubIpAddress -PublicIP $fwIp

New-AzFirewall -Name "testFirewall" -ResourceGroupName "testRg" -Location "westcentralus" -Sku AZFW_Hub -VirtualHubId $virtualHub.Id -HubIPAddress $hubIpAddresses
$firewall = Get-AzFirewall -Name "testFirewall" -ResourceGroupName "testRg"

$policy1 = New-AzRoutingPolicy -Name "PrivateTraffic" -Destination @("PrivateTraffic") -NextHop $firewall.Id
$policy2 = New-AzRoutingPolicy -Name "PublicTraffic" -Destination @("Internet") -NextHop $firewall.Id

New-AzRoutingIntent -ResourceGroupName "testRg" -VirtualHubName "testHub" -Name "testRoutingIntent" -RoutingPolicy @($policy1, $policy2)
Get-AzRoutingIntent -ResourceGroupName "testRg" -VirtualHubName "testHub" -Name "testRoutingIntent"
```

```output
ProvisioningState   : Succeeded
RoutingPolicies     : {PrivateTraffic, PublicTraffic}
RoutingPoliciesText : [
                        {
                          "Name": "PrivateTraffic",
                          "DestinationType": "TrafficType",
                          "Destinations": [
                            "PrivateTraffic"
                          ],
                          "NextHopType": "ResourceId",
                          "NextHop": "/subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/azureFirewalls/testFirewall"
                        },
                        {
                          "Name": "PublicTraffic",
                          "DestinationType": "TrafficType",
                          "Destinations": [
                            "Internet"
                          ],
                          "NextHopType": "ResourceId",
                          "NextHop": "/subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/azureFirewalls/testFirewall"
                        }
                      ]
Name                : testRoutingIntent
Etag                : W/"etag"
Id                  : /subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/testHub/routingIntent/testRoutingIntent

```

This command gets the routing intent of the virtual hub.

### Example 2

```powershell
$rgName = "testRg"
$virtualHubName = "testHub"
Get-AzRoutingIntent -Name $riName -VirtualHub $virtualHub
```

```output
ProvisioningState   : Succeeded
RoutingPolicies     : {PrivateTraffic, PublicTraffic}
RoutingPoliciesText : [
                        {
                          "Name": "PrivateTraffic",
                          "DestinationType": "TrafficType",
                          "Destinations": [
                            "PrivateTraffic"
                          ],
                          "NextHopType": "ResourceId",
                          "NextHop": "/subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/azureFirewalls/testFirewall"
                        },
                        {
                          "Name": "PublicTraffic",
                          "DestinationType": "TrafficType",
                          "Destinations": [
                            "Internet"
                          ],
                          "NextHopType": "ResourceId",
                          "NextHop": "/subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/azureFirewalls/testFirewall"
                        }
                      ]
Name                : testRoutingIntent
Etag                : W/"etag"
Id                  : /subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/testHub/routingIntent/testRoutingIntent

```

This command get the routing intent in the specified VirtualHub.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
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
Type: IAzureContextContainer
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
Type: String
Parameter Sets: ByRoutingIntentName, ByVirtualHubObject
Aliases: ResourceName, RoutingIntentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
The parent virtual hub object of this resource.

```yaml
Type: PSVirtualHub
Parameter Sets: ByVirtualHubObject
Aliases: ParentVirtualHub, VirtualHub

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParentResourceName
The parent resource name.

```yaml
Type: String
Parameter Sets: ByRoutingIntentName
Aliases: VirtualHubName, ParentVirtualHubName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ByRoutingIntentName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the RoutingIntent resource to Get.

```yaml
Type: String
Parameter Sets: ByRoutingIntentResourceId
Aliases: RoutingIntentId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.Commands.Network.Models.PSVirtualHub

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRoutingIntent

## NOTES

## RELATED LINKS

[New-AzVHubRoute](./New-AzVHubRoute.md)

[New-AzRoutingIntent](./New-AzRoutingIntent.md)

[Set-AzRoutingIntent](./Set-AzRoutingIntent.md)

[Remove-AzRoutingIntent](./Remove-AzRoutingIntent.md)