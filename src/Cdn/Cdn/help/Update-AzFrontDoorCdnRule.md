---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/update-azfrontdoorcdnrule
schema: 2.0.0
---

# Update-AzFrontDoorCdnRule

## SYNOPSIS
Update an existing delivery rule within a rule set.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>] [-Action <IDeliveryRuleAction[]>] [-Condition <IDeliveryRuleCondition[]>]
 [-MatchProcessingBehavior <String>] [-Order <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityRuleSetExpanded
```
Update-AzFrontDoorCdnRule -Name <String> -RuleSetInputObject <ICdnIdentity> [-Action <IDeliveryRuleAction[]>]
 [-Condition <IDeliveryRuleCondition[]>] [-MatchProcessingBehavior <String>] [-Order <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityRuleSet
```
Update-AzFrontDoorCdnRule -Name <String> -RuleSetInputObject <ICdnIdentity>
 -RuleUpdateProperty <IRuleUpdateParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityProfileExpanded
```
Update-AzFrontDoorCdnRule -Name <String> -SetName <String> -ProfileInputObject <ICdnIdentity>
 [-Action <IDeliveryRuleAction[]>] [-Condition <IDeliveryRuleCondition[]>] [-MatchProcessingBehavior <String>]
 [-Order <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityProfile
```
Update-AzFrontDoorCdnRule -Name <String> -SetName <String> -ProfileInputObject <ICdnIdentity>
 -RuleUpdateProperty <IRuleUpdateParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFrontDoorCdnRule -InputObject <ICdnIdentity> [-Action <IDeliveryRuleAction[]>]
 [-Condition <IDeliveryRuleCondition[]>] [-MatchProcessingBehavior <String>] [-Order <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update an existing delivery rule within a rule set.

## EXAMPLES

### Example 1: Update an AzureFrontDoor delivery rule within the specified rule set
```powershell
Update-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Name rule1 -Order 99
```

```output
Name  ResourceGroupName
----  -----------------
rule1 testps-rg-da16jm
```

Update an AzureFrontDoor delivery rule within the specified rule set

### Example 2: Update an AzureFrontDoor delivery rule within the specified rule set via identity
```powershell
Get-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Name rule1 | Update-AzFrontDoorCdnRule -Order 99
```

```output
Name  ResourceGroupName
----  -----------------
rule1 testps-rg-da16jm
```

Update an AzureFrontDoor delivery rule within the specified rule set via identity

## PARAMETERS

### -Action
A list of actions that are executed when all the conditions of a rule are satisfied.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityRuleSetExpanded, UpdateViaIdentityProfileExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Condition
A list of conditions that must be matched for the actions to be executed

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityRuleSetExpanded, UpdateViaIdentityProfileExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchProcessingBehavior
If this rule is a match should the rules engine continue running the remaining rules or stop.
If not present, defaults to Continue.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityRuleSetExpanded, UpdateViaIdentityProfileExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the delivery rule which is unique within the endpoint.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityRuleSetExpanded, UpdateViaIdentityRuleSet, UpdateViaIdentityProfileExpanded, UpdateViaIdentityProfile
Aliases: RuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Order
The order in which the rules are applied for the endpoint.
Possible values {0,1,2,3,………}.
A rule with a lesser order will be applied before a rule with a greater order.
Rule with order 0 is a special rule.
It does not require any condition and actions listed in it will always be applied.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityRuleSetExpanded, UpdateViaIdentityProfileExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityProfileExpanded, UpdateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleSetInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityRuleSetExpanded, UpdateViaIdentityRuleSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RuleUpdateProperty
The domain JSON object required for domain creation or update.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IRuleUpdateParameters
Parameter Sets: UpdateViaIdentityRuleSet, UpdateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SetName
Name of the rule set under the profile.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityProfileExpanded, UpdateViaIdentityProfile
Aliases: RuleSetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IRuleUpdateParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IRule

## NOTES

## RELATED LINKS
