---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafcustomrulegroupbyvariableobject
schema: 2.0.0
---

# New-AzFrontDoorWafCustomRuleGroupByVariableObject

## SYNOPSIS
Create an in-memory object for GroupByVariable.

## SYNTAX

```
New-AzFrontDoorWafCustomRuleGroupByVariableObject -VariableName <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for GroupByVariable.

## EXAMPLES

### Example 1
```powershell
New-AzFrontDoorWafCustomRuleGroupByVariableObject -VariableName SocketAddr
```

Create new WafCustomRuleGroupByVariableObject

## PARAMETERS

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VariableName
Describes the supported variable for group by.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.GroupByVariable

## NOTES

## RELATED LINKS
