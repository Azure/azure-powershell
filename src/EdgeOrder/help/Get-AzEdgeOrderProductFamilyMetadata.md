---
external help file:
Module Name: Az.EdgeOrder
online version: https://docs.microsoft.com/powershell/module/az.edgeorder/get-azedgeorderproductfamilymetadata
schema: 2.0.0
---

# Get-AzEdgeOrderProductFamilyMetadata

## SYNOPSIS
This method provides the list of product families metadata for the given subscription.

## SYNTAX

```
Get-AzEdgeOrderProductFamilyMetadata [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This method provides the list of product families metadata for the given subscription.

## EXAMPLES

### Example 1: Gets available product families on procured subscription
```powershell
$productFamilyMeta = Get-AzEdgeOrderProductFamilyMetadata -SubscriptionId SubscriptionId
$productFamilyMeta.HierarchyInformation
```

```output
ConfigurationName ProductFamilyName ProductLineName ProductName
----------------- ----------------- --------------- -----------
                  azurestackedge
                  azurestackhub
```

This command gets product families available on procured subscription.

Make sure registerProvider on Microsoft.EdgeOrder is done before running this command.

To get details of any family use Get-AzEdgeOrderProductFamily command

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductFamiliesMetadataDetails

## NOTES

ALIASES

## RELATED LINKS

