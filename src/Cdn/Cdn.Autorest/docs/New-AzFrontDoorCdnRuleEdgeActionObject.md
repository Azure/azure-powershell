---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azfrontdoorcdnruleedgeactionobject
schema: 2.0.0
---

# New-AzFrontDoorCdnRuleEdgeActionObject

## SYNOPSIS
Create an in-memory object for EdgeAction.

## SYNTAX

```
New-AzFrontDoorCdnRuleEdgeActionObject -ParameterInvocationPoint <String> -ParameterTypeName <String>
 [-ReferenceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EdgeAction.

## EXAMPLES

### Example 1: Create CdnRuleEdgeActionObject
```powershell
New-AzFrontDoorCdnRuleEdgeActionObject -ParameterInvocationPoint ClientRequest -ParameterTypeName DeliveryRuleUrlRedirectActionParameters -ReferenceId $id
```

Create CdnRuleEdgeActionObject

## PARAMETERS

### -ParameterInvocationPoint
Defines at which point in the request processing pipeline the edge action will be invoked.

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

### -ParameterTypeName


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

### -ReferenceId
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.EdgeAction

## NOTES

## RELATED LINKS

