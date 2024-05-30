---
external help file: Az.NetworkFunction-help.xml
Module Name: Az.NetworkFunction
online version: https://learn.microsoft.com/powershell/module/az.networkfunction/update-aznetworkfunctioncollectorpolicytag
schema: 2.0.0
---

# Update-AzNetworkFunctionCollectorPolicyTag

## SYNOPSIS
Updates the specified Collector Policy tags.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkFunctionCollectorPolicyTag -AzureTrafficCollectorName <String> -CollectorPolicyName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkFunctionCollectorPolicyTag -InputObject <INetworkFunctionIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the specified Collector Policy tags.

## EXAMPLES

### Example 1: Updates a traffic collector tag
```powershell
Update-AzNetworkFunctionCollectorPolicyTag -collectorpolicyname cp1 -azuretrafficcollectorname atc -resourcegroupname rg1 | Format-List
```

```output
Name              : cp1
Etag              : 72090554-7e3b-43f2-80ad-99a9020dcb11
Id                : /subscriptions/subid/resourceGroups/rg1/providers/Microsoft.NetworkFunction/azureTrafficCollectors/atc/collectorPolicies/cp1
Type              : Microsoft.NetworkFunction/azureTrafficCollectors/collectorPolicies
Location          : West US
Tags              : {
                        "key1": "value1",
                        "key2": "value2"
                    }
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

This cmdlet updates a collector policy tag.

## PARAMETERS

### -AzureTrafficCollectorName
Azure Traffic Collector name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CollectorPolicyName
Collector Policy Name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.INetworkFunctionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20221101.ICollectorPolicy

## NOTES

## RELATED LINKS
