---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzFrontDoorCdnProfileScrubbingRulesObject
schema: 2.0.0
---

# New-AzFrontDoorCdnProfileScrubbingRulesObject

## SYNOPSIS
Create an in-memory object for ProfileScrubbingRules.

## SYNTAX

```
New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable <ScrubbingRuleEntryMatchVariable>
 [-Selector <String>] [-State <ScrubbingRuleEntryState>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ProfileScrubbingRules.

## EXAMPLES

### Example 1: Create an in-memory object for ProfileScrubbingRules and the value of matchVariable is RequestIPAddress
```powershell
New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Enabled
```

```output
MatchVariable    Selector SelectorMatchOperator State
-------------    -------- --------------------- -----
RequestIPAddress          EqualsAny             Enabled
```

Create an in-memory object for ProfileScrubbingRules and the value of matchVariable is RequestIPAddress

### Example 2: Create an in-memory object for ProfileScrubbingRules and disbale the Scrubbing rule
```powershell
New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestUri -State Disabled
```

```output
MatchVariable Selector SelectorMatchOperator State
------------- -------- --------------------- -----
RequestUri             EqualsAny             Disabled
```

Create an in-memory object for ProfileScrubbingRules and disbale the Scrubbing rule

## PARAMETERS

### -MatchVariable
The variable to be scrubbed from the logs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ScrubbingRuleEntryMatchVariable
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -State
Defines the state of a log scrubbing rule.
Default value is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ScrubbingRuleEntryState
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ProfileScrubbingRules

## NOTES

## RELATED LINKS
