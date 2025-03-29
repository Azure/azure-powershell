---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzFrontDoorCdnProfileLogScrubbingObject
schema: 2.0.0
---

# New-AzFrontDoorCdnProfileLogScrubbingObject

## SYNOPSIS
Create an in-memory object for ProfileLogScrubbing.

## SYNTAX

```
New-AzFrontDoorCdnProfileLogScrubbingObject [-ScrubbingRule <IProfileScrubbingRules[]>]
 [-State <ProfileScrubbingState>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ProfileLogScrubbing.

## EXAMPLES

### Example 1: Create an in-memory object for ProfileUpgradeParameters, for two LogScrubbingRules
```powershell
$scrubbingRule1 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Enabled
$scrubbingRule2 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestUri -State Enabled
New-AzFrontDoorCdnProfileLogScrubbingObject -ScrubbingRule @($scrubbingRule1, $scrubbingRule2) -State Enabled
```

```output
State
-----
Enabled
```

Create an in-memory object for ProfileUpgradeParameters, for two LogScrubbingRules

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

### -ScrubbingRule
List of log scrubbing rules applied to the Azure Front Door profile logs.
To construct, see NOTES section for SCRUBBINGRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IProfileScrubbingRules[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ProfileScrubbingState
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ProfileLogScrubbing

## NOTES

## RELATED LINKS
