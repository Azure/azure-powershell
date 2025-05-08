---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/new-azfrontdoorcdnrule
schema: 2.0.0
---

# New-AzFrontDoorCdnRule

## SYNOPSIS
create a new delivery rule within the specified rule set.

## SYNTAX

### CreateExpanded (Default)
```
New-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>] [-Action <IDeliveryRuleAction[]>] [-Condition <IDeliveryRuleCondition[]>]
 [-MatchProcessingBehavior <String>] [-Order <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityProfileExpanded
```
New-AzFrontDoorCdnRule -Name <String> -SetName <String> -ProfileInputObject <ICdnIdentity>
 [-Action <IDeliveryRuleAction[]>] [-Condition <IDeliveryRuleCondition[]>] [-MatchProcessingBehavior <String>]
 [-Order <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityProfile
```
New-AzFrontDoorCdnRule -Name <String> -SetName <String> -ProfileInputObject <ICdnIdentity> -Rule <IRule>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityRuleSetExpanded
```
New-AzFrontDoorCdnRule -Name <String> -RuleSetInputObject <ICdnIdentity> [-Action <IDeliveryRuleAction[]>]
 [-Condition <IDeliveryRuleCondition[]>] [-MatchProcessingBehavior <String>] [-Order <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityRuleSet
```
New-AzFrontDoorCdnRule -Name <String> -RuleSetInputObject <ICdnIdentity> -Rule <IRule>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
create a new delivery rule within the specified rule set.

## EXAMPLES

### Example 1: Creates an AzureFrontDoor delivery rule within the specified rule set
```powershell
$conditions = @(
    New-AzFrontDoorCdnRuleClientPortConditionObject -Name ClientPort -ParameterOperator Equal -ParameterMatchValue 80,81
    New-AzFrontDoorCdnRuleIsDeviceConditionObject -Name IsDevice -ParameterMatchValue Mobile
    New-AzFrontDoorCdnRuleSslProtocolConditionObject -Name SslProtocol -ParameterMatchValue TLSv1.2
);

       
$actions = @(
    New-AzFrontDoorCdnRuleRequestHeaderActionObject -Name ModifyRequestHeader -ParameterHeaderAction Append -ParameterHeaderName a1 -ParameterValue a1
    New-AzFrontDoorCdnRuleResponseHeaderActionObject -Name ModifyResponseHeader -ParameterHeaderAction Append -ParameterHeaderName a1 -ParameterValue a1
    New-AzFrontDoorCdnRuleUrlRedirectActionObject -Name UrlRedirect -ParameterRedirectType Moved -ParameterDestinationProtocol MatchRequest
);

New-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Name rule1 -Action $actions -Condition $conditions
```

```output
Name  ResourceGroupName
----  -----------------
rule1 testps-rg-da16jm
```

Creates an AzureFrontDoor delivery rule within the specified rule set

## PARAMETERS

### -Action
A list of actions that are executed when all the conditions of a rule are satisfied.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction[]
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityRuleSetExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityRuleSetExpanded
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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityRuleSetExpanded
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityRuleSetExpanded
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
Parameter Sets: CreateViaIdentityProfileExpanded, CreateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
Friendly Rules name mapping to the any Rules or secret related information.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IRule
Parameter Sets: CreateViaIdentityProfile, CreateViaIdentityRuleSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RuleSetInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: CreateViaIdentityRuleSetExpanded, CreateViaIdentityRuleSet
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityProfileExpanded, CreateViaIdentityProfile
Aliases: RuleSetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IRule

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IRule

## NOTES

## RELATED LINKS
