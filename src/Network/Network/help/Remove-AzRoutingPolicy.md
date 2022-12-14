---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/remove-azroutingpolicy
schema: 2.0.0
---

# Remove-AzRoutingPolicy

## SYNOPSIS
Removes the specified routing policy from a routing intent resource associated with a VirtualHub.

## SYNTAX

### ByRoutingIntentObject
```powershell
Remove-AzRoutingPolicy -Name <String> -RoutingIntent <PSRoutingIntent> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Removes the specified routing Policy that is associated with the specified routing intent object and returns an in-memory routing intent object which can be piped to [Set-AzRoutingIntent](./Set-AzRoutingIntent.md) to update the actual routing intent resource.

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
$routingIntent = Get-AzRoutingIntent -ResourceGroupName "testRg" -VirtualHubName "testHub" -Name "testRoutingIntent"

Remove-AzRoutingPolicy -Name "PrivateTraffic" -RoutingIntent $routingIntent
Set-AzRoutingIntent -InputObject $routingIntent
```

```output
ProvisioningState   : Succeeded
RoutingPolicies     : {PublicTraffic}
RoutingPoliciesText : [
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
Name                : routingIntent1
Etag                : W/"etag"
Id                  : /subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/hub1/routingIntent/routingIntent1

```

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
The policy name.

```yaml
Type: String
Parameter Sets: ByRoutingPolicyName, ByVirtualHubObject
Aliases: ResourceName, RoutingPolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingIntent
The routing intent object from which this rouing policy has to be removed. 

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRoutingIntent
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.Commands.Network.Models.PSRoutingIntent

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRoutingIntent

## NOTES

## RELATED LINKS

[Add-AzRoutingPolicy](./Add-AzRoutingPolicy.md)

[Get-AzRoutingIntent](./Get-AzRoutingIntent.md)

[Get-AzRoutingPolicy](./Get-AzRoutingPolicy.md)

[New-AzRoutingIntent](./New-AzRoutingIntent.md)

[New-AzRoutingPolicy](./New-AzRoutingPolicy.md)

[Remove-AzRoutingIntent](./Remove-AzRoutingIntent.md)

[Set-AzRoutingIntent](./Set-AzRoutingIntent.md)

[Set-AzRoutingPolicy](./Set-AzRoutingPolicy.md)