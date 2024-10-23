---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappjobscaleruleobject
schema: 2.0.0
---

# New-AzContainerAppJobScaleRuleObject

## SYNOPSIS
Create an in-memory object for JobScaleRule.

## SYNTAX

```
New-AzContainerAppJobScaleRuleObject [-Auth <IScaleRuleAuth[]>] [-Metadata <IAny>] [-Name <String>]
 [-Type <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for JobScaleRule.

## EXAMPLES

### Example 1: Create an in-memory object for JobScaleRule.
```powershell
$scaleRuleAuth = New-AzContainerAppScaleRuleAuthObject -SecretRef "redis-secret" -TriggerParameter "TriggerParameter"
New-AzContainerAppJobScaleRuleObject -Auth $scaleRuleAuth -Name azps-job-scale -Type azure-servicebus
```

```output
Name
----
azps-job-scale
```

Create an in-memory object for JobScaleRule.

## PARAMETERS

### -Auth
Authentication secrets for the scale rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IScaleRuleAuth[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
Metadata properties to describe the scale rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Scale Rule Name.

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

### -Type
Type of the scale rule
        eg: azure-servicebus, redis etc.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.JobScaleRule

## NOTES

## RELATED LINKS

