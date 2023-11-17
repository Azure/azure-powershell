---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzCdnOriginGroupOverrideActionObject
schema: 2.0.0
---

# New-AzCdnOriginGroupOverrideActionObject

## SYNOPSIS
Create an in-memory object for OriginGroupOverrideAction.

## SYNTAX

```
New-AzCdnOriginGroupOverrideActionObject -Name <DeliveryRuleAction> [-OriginGroupId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for OriginGroupOverrideAction.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN OriginGroupOverrideAction
```powershell
New-AzCdnOriginGroupOverrideActionObject -Name OriginGroupOverride -OriginGroupId 001
```

```output
Name
----
OriginGroupOverride
```

Create an in-memory object for AzureCDN OriginGroupOverrideAction

## PARAMETERS

### -Name
The name of the action for the delivery rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeliveryRuleAction
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OriginGroupId
Resource ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.OriginGroupOverrideAction

## NOTES

ALIASES

## RELATED LINKS

