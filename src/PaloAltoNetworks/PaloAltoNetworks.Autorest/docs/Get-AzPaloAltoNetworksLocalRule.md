---
external help file:
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/get-azpaloaltonetworkslocalrule
schema: 2.0.0
---

# Get-AzPaloAltoNetworksLocalRule

## SYNOPSIS
Get a LocalRulesResource

## SYNTAX

### List (Default)
```
Get-AzPaloAltoNetworksLocalRule -LocalRulestackName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPaloAltoNetworksLocalRule -LocalRulestackName <String> -Priority <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPaloAltoNetworksLocalRule -InputObject <IPaloAltoNetworksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityLocalRulestack
```
Get-AzPaloAltoNetworksLocalRule -LocalRulestackInputObject <IPaloAltoNetworksIdentity> -Priority <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a LocalRulesResource

## EXAMPLES

### Example 1: List LocalRulesResource by LocalRulestackName.
```powershell
Get-AzPaloAltoNetworksLocalRule -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr
```

```output
RuleName   RuleState Priority ResourceGroupName
--------   --------- -------- -----------------
azps-ruler ENABLED   1        azps_test_group_pan
```

List LocalRulesResource by LocalRulestackName.

### Example 2: Get a LocalRulesResource by priority.
```powershell
Get-AzPaloAltoNetworksLocalRule -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr -Priority 1
```

```output
RuleName   RuleState Priority ResourceGroupName
--------   --------- -------- -----------------
azps-ruler ENABLED   1        azps_test_group_pan
```

Get a LocalRulesResource by priority.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: GetViaIdentityLocalRulestack
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
Parameter Sets: Get, List
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
Parameter Sets: Get, GetViaIdentityLocalRulestack
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.ILocalRulesResource

## NOTES

## RELATED LINKS

