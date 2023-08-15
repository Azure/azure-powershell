---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/add-azroutingpolicy
schema: 2.0.0
---

# Add-AzRoutingPolicy

## SYNOPSIS
Add a Routing Policy to the Routing Intent object.

## SYNTAX

```
Add-AzRoutingPolicy -RoutingIntent <PSRoutingIntent> -Destination <String[]> -NextHop <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzRoutingPolicy** cmdlet adds a RoutingPolicy to a RoutingIntent resource. This will only return an updated in-memory routing intent resource. Please use the [Set-AzRoutingIntent](./Set-AzRoutingIntent.md) cmdlet to update the actual resource and ensure that the policies take effect.

## EXAMPLES

### Example 1
```powershell
$rgName = "testRg"
$firewallName = "testFirewall"
$firewall = Get-AzFirewall -Name $firewallName -ResourceGroupName $rgName
$routingIntent = Get-AzRoutingIntent -Name "routingIntent1" -HubName "hub1" -ResourceGroupName $rgName
Add-AzRoutingPolicy -Name "PublicTraffic" -RoutingIntent $routingIntent -Destination @("Internet") -NextHop $firewall.Id 
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

### -Destination
The list of destinations.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the routing policy 

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

### -NextHop
Id of the next hop resource.

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

### -RoutingIntent
The routing intent resource to which this rouing policy has to be added. 

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRoutingIntent
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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

### System.String

### Microsoft.Azure.Commands.Network.Models.PSRoutingIntent

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRoutingIntent

## NOTES

## RELATED LINKS

[Get-AzRoutingIntent](./Get-AzRoutingIntent.md)

[Get-AzRoutingPolicy](./Get-AzRoutingPolicy.md)

[New-AzRoutingPolicy](./New-AzRoutingPolicy.md)

[Remove-AzRoutingIntent](./Remove-AzRoutingIntent.md)

[Remove-AzRoutingPolicy](./Remove-AzRoutingPolicy.md)

[Set-AzRoutingIntent](./Set-AzRoutingIntent.md)

[Set-AzRoutingPolicy](./Set-AzRoutingPolicy.md)