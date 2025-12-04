---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwaflogscrubbingsettingobject
schema: 2.0.0
---

# New-AzFrontDoorWafLogScrubbingSettingObject

## SYNOPSIS
Create an in-memory object for PolicySettingsLogScrubbing.

## SYNTAX

```
New-AzFrontDoorWafLogScrubbingSettingObject [-ScrubbingRule <IWebApplicationFirewallScrubbingRules[]>]
 [-State <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PolicySettingsLogScrubbing.

## EXAMPLES

### Example 1: Create LogScrubbingSetting object for Waf policy object
```powershell
$LogScrubbingRule = New-AzFrontDoorWafLogScrubbingRuleObject -MatchVariable "RequestHeaderNames" -SelectorMatchOperator "EqualsAny" -State "Enabled"
New-AzFrontDoorWafLogScrubbingSettingObject -State Enabled -ScrubbingRule @($LogScrubbingRule)
```

Need to create a LogScrubbingRule object before using.

## PARAMETERS

### -ScrubbingRule
List of log scrubbing rules applied to the Web Application Firewall logs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IWebApplicationFirewallScrubbingRules[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
State of the log scrubbing config.
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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.PolicySettingsLogScrubbing

## NOTES

## RELATED LINKS

