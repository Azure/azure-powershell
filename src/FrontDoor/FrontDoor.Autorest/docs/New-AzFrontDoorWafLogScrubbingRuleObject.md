---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwaflogscrubbingruleobject
schema: 2.0.0
---

# New-AzFrontDoorWafLogScrubbingRuleObject

## SYNOPSIS
Create an in-memory object for WebApplicationFirewallScrubbingRules.

## SYNTAX

```
New-AzFrontDoorWafLogScrubbingRuleObject -MatchVariable <String> -SelectorMatchOperator <String>
 [-Selector <String>] [-State <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WebApplicationFirewallScrubbingRules.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -MatchVariable
The variable to be scrubbed from the logs.

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

### -Selector
When matchVariable is a collection, operator used to specify which elements in the collection this rule applies to.

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

### -SelectorMatchOperator
When matchVariable is a collection, operate on the selector to specify which elements in the collection this rule applies to.

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

### -State
Defines the state of log scrubbing rule.
Default value is Enabled.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.WebApplicationFirewallScrubbingRules

## NOTES

## RELATED LINKS

