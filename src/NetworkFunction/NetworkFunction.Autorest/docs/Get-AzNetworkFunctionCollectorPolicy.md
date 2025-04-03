---
external help file:
Module Name: Az.NetworkFunction
online version: https://learn.microsoft.com/powershell/module/az.networkfunction/get-aznetworkfunctioncollectorpolicy
schema: 2.0.0
---

# Get-AzNetworkFunctionCollectorPolicy

## SYNOPSIS
Gets the collector policy in a specified Traffic Collector

## SYNTAX

### List (Default)
```
Get-AzNetworkFunctionCollectorPolicy -AzureTrafficCollectorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkFunctionCollectorPolicy -AzureTrafficCollectorName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFunctionCollectorPolicy -InputObject <INetworkFunctionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the collector policy in a specified Traffic Collector

## EXAMPLES

### Example 1: Get list of collector policies by atc name and resource group
```powershell
Get-AzNetworkFunctionCollectorPolicy -AzureTrafficCollectorName test -resourcegroupname test | Format-List
```

```output
Name              : cp1
Etag              : cf0336a2-7454-4aa4-add9-1de3e2291143
Id                : /subscriptions/subid/resourceGroups/test/providers/Microsoft.NetworkFunction/azureTrafficCollectors/test/collectorPolicies/cp1
Type              : Microsoft.NetworkFunction/azureTrafficCollectors/collectorPolicies
Properties        : {
                    "ingestionPolicy": {
                        "ingestionType": "IPFIX",
                        "ingestionSources": [
                            {
                            "resourceId": "/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/expressRouteCircuits/circuitName",
                            "sourceType": "Resource"
                            }
                        ]
                        },
                        "emissionPolicies": [
                        {
                            "emissionType": "IPFIX",
                            "emissionDestinations": [
                            {
                                "destinationType": "AzureMonitor"
                            }
                            ]
                        }
                        ],
                        "provisioningState": "Succeeded"
                    }
```

This cmdlet gets list of traffic collector policies by atc name and resource group.

## PARAMETERS

### -AzureTrafficCollectorName
Azure Traffic Collector name

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.INetworkFunctionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Collector Policy Name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CollectorPolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.INetworkFunctionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20221101.ICollectorPolicy

## NOTES

## RELATED LINKS

