---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallpolicyexclusionmanagedrule
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallPolicyExclusionManagedRule

## SYNOPSIS
Creates an exclusionManagedRule entry for ExclusionManagedRuleGroup entry.

## SYNTAX

```
New-AzApplicationGatewayFirewallPolicyExclusionManagedRule -RuleId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallPolicyExclusionManagedRule** creates an exclusion rule entry.

## EXAMPLES

### Example 1
```powershell
$ruleOverrideEntry = New-AzApplicationGatewayFirewallPolicyExclusionManagedRule -RuleId $ruleId
```

Creates an exclusion rule Entry with RuleId as $ruleId.

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

### -RuleId
Specify the RuleId in exclusion rule entry.

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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicyExclusionManagedRule

## NOTES

## RELATED LINKS
