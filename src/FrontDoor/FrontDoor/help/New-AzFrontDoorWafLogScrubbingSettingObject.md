---
external help file: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.dll-Help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/new-azfrontdoorwaflogscrubbingsettingobject
schema: 2.0.0
---

# New-AzFrontDoorWafLogScrubbingSettingObject

## SYNOPSIS
Create LogScrubbingSetting object for Waf policy object

## SYNTAX

```
New-AzFrontDoorWafLogScrubbingSettingObject -ScrubbingRule <PSFrontDoorWafLogScrubbingRule[]> -State <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Create LogScrubbingSetting object for Waf policy object

## EXAMPLES

### Example 1
```powershell
$LogScrubbingRule = New-AzFrontDoorWafLogScrubbingRuleObject -MatchVariable "RequestHeaderNames" -SelectorMatchOperator "EqualsAny" -State "Enabled"
New-AzFrontDoorWafLogScrubbingSettingObject -State Enabled -ScrubbingRule @($LogScrubbingRule)
```

Need to create a LogScrubbingRule object before using.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScrubbingRule
List of log scrubbing rules applied to the Web Application Firewall logs.

```yaml
Type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafLogScrubbingRule[]
Parameter Sets: (All)
Aliases:

Required: True
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafLogScrubbingSetting

## NOTES

## RELATED LINKS
