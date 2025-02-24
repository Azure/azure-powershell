---
external help file:
Module Name: Az.NetworkFunction
online version: https://learn.microsoft.com/powershell/module/az.networkfunction/update-aznetworkfunctiontrafficcollectortag
schema: 2.0.0
---

# Update-AzNetworkFunctionTrafficCollectorTag

## SYNOPSIS
Updates the specified Azure Traffic Collector tags.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkFunctionTrafficCollectorTag -AzureTrafficCollectorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkFunctionTrafficCollectorTag -InputObject <INetworkFunctionIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the specified Azure Traffic Collector tags.

## EXAMPLES

### Example 1: Updates a traffic collector tag
```powershell
Update-AzNetworkFunctionTrafficCollectorTag -azuretrafficcollectorname atc -resourcegroupname rg1 | Format-List
```

```output
Name              : atc
Etag              : cf0336a2-7454-4aa4-add9-1de3e2291143
Id                : /subscriptions/subid/resourceGroups/rg1/providers/Microsoft.NetworkFunction/azureTrafficCollectors/atc
Type              : Microsoft.NetworkFunction/azureTrafficCollectors
Location          : West US
Tags              : {
                        "key1": "value1",
                        "key2": "value2"
                    }
Properties        : {
                        "collectorPolicies": [],
                        "provisioningState": "Succeeded"
                    }
```

This cmdlet updates a traffic collector tag.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20221101.IAzureTrafficCollector

## NOTES

## RELATED LINKS

