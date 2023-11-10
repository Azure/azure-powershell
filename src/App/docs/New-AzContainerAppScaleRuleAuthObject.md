---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappscaleruleauthobject
schema: 2.0.0
---

# New-AzContainerAppScaleRuleAuthObject

## SYNOPSIS
Create an in-memory object for ScaleRuleAuth.

## SYNTAX

```
New-AzContainerAppScaleRuleAuthObject [-SecretRef <String>] [-TriggerParameter <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ScaleRuleAuth.

## EXAMPLES

### Example 1: Create a ScaleRuleAuth object for ScaleRule.
```powershell
New-AzContainerAppScaleRuleAuthObject -SecretRef "redis-secret" -TriggerParameter "TriggerParameter"
```

```output
SecretRef    TriggerParameter
---------    ----------------
redis-secret TriggerParameter
```

Create a ScaleRuleAuth object for ScaleRule.

## PARAMETERS

### -SecretRef
Name of the secret from which to pull the auth params.

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

### -TriggerParameter
Trigger Parameter that uses the secret.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.ScaleRuleAuth

## NOTES

## RELATED LINKS

