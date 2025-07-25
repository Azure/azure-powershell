---
external help file:
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/reset-azpaloaltonetworkslocalrulecounter
schema: 2.0.0
---

# Reset-AzPaloAltoNetworksLocalRuleCounter

## SYNOPSIS
Reset counters

## SYNTAX

### Reset (Default)
```
Reset-AzPaloAltoNetworksLocalRuleCounter -LocalRulestackName <String> -Priority <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-FirewallName <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResetViaIdentity
```
Reset-AzPaloAltoNetworksLocalRuleCounter -InputObject <IPaloAltoNetworksIdentity> [-FirewallName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResetViaIdentityLocalRulestack
```
Reset-AzPaloAltoNetworksLocalRuleCounter -LocalRulestackInputObject <IPaloAltoNetworksIdentity>
 -Priority <String> [-FirewallName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Reset counters

## EXAMPLES

### Example 1: Reset counters.
```powershell
Reset-AzPaloAltoNetworksLocalRuleCounter -LocalRulestackName azps-panlr -ResourceGroupName azps_test_group_pan -Priority 1
```

```output
FirewallName Priority RuleListName RuleName                RuleStackName
------------ -------- ------------ --------                -------------
             1        azps-ruler   cloud-ngfw-default-rule azps-panlr
```

Reset counters.

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

### -FirewallName
.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
Parameter Sets: ResetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocalRulestackInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
Parameter Sets: ResetViaIdentityLocalRulestack
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocalRulestackName
LocalRulestack resource name

```yaml
Type: System.String
Parameter Sets: Reset
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Priority
Local Rule priority

```yaml
Type: System.String
Parameter Sets: Reset, ResetViaIdentityLocalRulestack
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
Parameter Sets: Reset
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Reset
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IRuleCounterReset

## NOTES

## RELATED LINKS

