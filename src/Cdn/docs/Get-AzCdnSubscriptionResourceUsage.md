---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/get-azcdnsubscriptionresourceusage
schema: 2.0.0
---

# Get-AzCdnSubscriptionResourceUsage

## SYNOPSIS
Check the quota and actual usage of the CDN profiles under the given subscription.

## SYNTAX

```
Get-AzCdnSubscriptionResourceUsage [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check the quota and actual usage of the CDN profiles under the given subscription.

## EXAMPLES

### Example 1: Get the quota and actual usage of the CDN profiles under the given subscription
```powershell
Get-AzCdnSubscriptionResourceUsage
```

```output
CurrentValue Limit ResourceType Unit
------------ ----- ------------ ----
13           25    profile      count
29           500   afdprofile   count
```

Get the quota and actual usage of the CDN profiles under the given subscription

## PARAMETERS

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

### -SubscriptionId
Azure Subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceUsage

## NOTES

ALIASES

## RELATED LINKS

