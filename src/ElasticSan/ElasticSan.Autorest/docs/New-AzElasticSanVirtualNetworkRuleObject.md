---
external help file:
Module Name: Az.ElasticSan
online version: https://learn.microsoft.com/powershell/module/Az.ElasticSan/new-azelasticsanvirtualnetworkruleobject
schema: 2.0.0
---

# New-AzElasticSanVirtualNetworkRuleObject

## SYNOPSIS
Create an in-memory object for VirtualNetworkRule.

## SYNTAX

```
New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId <String> [-Action <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VirtualNetworkRule.

## EXAMPLES

### Example 1: Create a virtual network rule object 
```powershell
New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1
```

This command creates a new virtual network rule object using the virtual network resource Id.

## PARAMETERS

### -Action
The action of virtual network rule.

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

### -VirtualNetworkResourceId
Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.VirtualNetworkRule

## NOTES

## RELATED LINKS

