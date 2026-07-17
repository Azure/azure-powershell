---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/new-azfrontdoorcdnruleset
schema: 2.0.0
---

# New-AzFrontDoorCdnRuleSet

## SYNOPSIS
Create or create a batch rule set within the specified profile along with the rules associate to it.

## SYNTAX

### CreateExpanded (Default)
```
New-AzFrontDoorCdnRuleSet -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-BatchMode] [-Rule <IBatchRuleProperties[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzFrontDoorCdnRuleSet -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -Resource <IRuleSet> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityProfile
```
New-AzFrontDoorCdnRuleSet -Name <String> -ProfileInputObject <ICdnIdentity> -Resource <IRuleSet>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityProfileExpanded
```
New-AzFrontDoorCdnRuleSet -Name <String> -ProfileInputObject <ICdnIdentity> [-BatchMode]
 [-Rule <IBatchRuleProperties[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFrontDoorCdnRuleSet -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFrontDoorCdnRuleSet -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or create a batch rule set within the specified profile along with the rules associate to it.

## EXAMPLES

### Example 1: Create an AzureFrontDoor rule set under the AzureFrontDoor profile
```powershell
New-AzFrontDoorCdnRuleSet -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001
```

```output
Name       ResourceGroupName
----       -----------------
ruleset001 testps-rg-da16jm
```

Create an AzureFrontDoor rule set under the AzureFrontDoor profile

## PARAMETERS

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

### -BatchMode
Indicates whether rule set is in batch mode.
When batch mode is enabled, rules will be processed in a batch along with the rule set.When batch mode is disabled, rules would need to be processed independently.This property can only be set during rule set creation and cannot be updated later.For switching modes, a new rule set needs to be created with the desired mode and rules need to be migrated to the new rule set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
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

### -Name
Name of the rule set under the profile which is unique globally.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RuleSetName

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

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: CreateViaIdentityProfile, CreateViaIdentityProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium or CDN profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Friendly RuleSet name mapping to the any RuleSet or secret related information.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IRuleSet
Parameter Sets: Create, CreateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
A list of rules that are part of this rule set provided the rule set is in batch mode.This property will be ignored if the rule set is not in batch mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IBatchRuleProperties[]
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IRuleSet

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IRuleSet

## NOTES

## RELATED LINKS

