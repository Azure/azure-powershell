---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/get-azfrontdoorwafmanagedrulesetdefinition
schema: 2.0.0
---

# Get-AzFrontDoorWafManagedRuleSetDefinition

## SYNOPSIS
Lists all available managed rule sets.

## SYNTAX

```
Get-AzFrontDoorWafManagedRuleSetDefinition [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists all available managed rule sets.

## EXAMPLES

### Example 1
```powershell
Get-AzFrontDoorWafManagedRuleSetDefinition
```

```output
Location Name
-------- ----
         Microsoft_DefaultRuleSet_2.0
         Microsoft_DefaultRuleSet_2.1
         Microsoft_DefaultRuleSet_2.2
         Microsoft_BotManagerRuleSet_1.1
         Microsoft_HTTPDDoSRuleSet_1.0
         Microsoft_DefaultRuleSet_1.2
         Microsoft_DefaultRuleSet_1.1
         Microsoft_BotManagerRuleSet_1.0
         DefaultRuleSet_1.0
         DefaultRuleSet_preview-0.1
         BotProtection_preview-0.1
```

Get WAF managed rule set definitions.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleSetDefinition

## NOTES

## RELATED LINKS
