---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/set-azroutingpolicy
schema: 2.0.0
---

# Set-AzRoutingPolicy

## SYNOPSIS
Updates the destinations or nexthop for the specified Routing Policy of a Routing Intent object.

## SYNTAX

### (Default)
```
Set-AzRoutingPolicy -RoutingIntent <PSRoutingIntent> -Name <String> [-Destination <String[]>] [-NextHop <String>] 
 [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzRoutingPolicy** cmdlet updates a RoutingPolicy of a RoutingIntent resource. This will only return an updated in-memory routing intent resource. Please use the [Set-AzRoutingIntent](./Set-AzRoutingIntent.md) cmdlet to update the actual resource and ensure that the policies take effect.

## EXAMPLES

### Example 1
```powershell
$rgName = "testRg"
$firewallName = "testFirewall"
$firewall = Get-AzFirewall -Name $firewallName -ResourceGroupName $rgName
$routingIntent = Get-AzRoutingIntent -Name "routingIntent1" -HubName "hub1" -ResourceGroupName $rgName
Set-AzRoutingPolicy -Name "PrivateTraffic" -RoutingIntent $routingIntent -Destination @("PrivateTraffic") -NextHop $firewall.Id 
```
```output
ProvisioningState   : Succeeded
RoutingPolicies     : {PrivateTraffic}
RoutingPoliciesText : [
                        {
                          "Name": "PrivateTraffic",
                          "DestinationType": "TrafficType",
                          "Destinations": [
                            "PrivateTraffic"
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
Name of the routing policy 

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NextHop
Id of the next hop resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Destination
The list of destinations.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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