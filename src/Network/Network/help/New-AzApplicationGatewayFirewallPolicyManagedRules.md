---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azapplicationgatewayfirewallcondition
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallPolicyManagedRules

## SYNOPSIS
Create ManagedRules for the firewall policy.

## SYNTAX

```
New-AzApplicationGatewayFirewallPolicyManagedRules -ManagedRuleSet <PSApplicationGatewayFirewallManagedRuleSet[]> -Exclusions <PSApplicationGatewayFirewallPolicyExclusion[]>
[-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallPolicyManagedRules** creates a managed-rules for a firewall policy.

## EXAMPLES

### Example 1
```powershell
PS C:\> $condition = New-AzApplicationGatewayFirewallPolicyManagedRules -ManagedRuleSets $managedRuleSet -Exclusions $exclusion1,$exclusion2
```

The command creates managed rules a list of ManagedRuleSet with $managedRuleSet and an exclusion list with entries as $exclusion1, $exclusion2.

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

### -ManagedRuleSets
List of ManagedRuleSet to the ManagedRuleSets in managedRules for firewall policy.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallManagedRuleSet[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclusions
List of Exclusion to the Exclusions in managedRules for firewall policy.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallExclusion[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCondition

## NOTES

## RELATED LINKS
