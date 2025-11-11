---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallpolicyexception
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallPolicyException

## SYNOPSIS
Creates an exception on the Firewall Policy

## SYNTAX

```
New-AzApplicationGatewayFirewallPolicyException -MatchVariable <String> -Value <String[]>
 -ValueMatchOperator <String> [-SelectorMatchOperator <String>] [-Selector <String>]
 [-ExceptionManagedRuleSet <PSApplicationGatewayFirewallPolicyExclusionManagedRuleSet[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallPolicyException** cmdlet creates a new exception rule list for the firewall policy.

## EXAMPLES

### Example 1
```powershell
$exceptionEntry = New-AzApplicationGatewayFirewallPolicyException -MatchVariable "RequestURI" -Value "hey","hi" -ValueMatchOperator "Contains"
```

This command creates a new exception-entry for the variable named RequestURI with the ValueMatchOperator as Contains and Match Values as hey and hi. The exception entry is saved in $exceptionEntry.

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

### -ExceptionManagedRuleSet
The managed rule sets that are associated with the exception.


```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicyExclusionManagedRuleSet[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchVariable
The variable on which we evaluate the exception condition.


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: RequestURI, RemoteAddr, RequestHeader

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Selector
When the matchVariable points to a key-value pair (e.g, RequestHeader), this identifies the key.


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

### -SelectorMatchOperator
When the matchVariable points to a key-value pair (e.g, RequestHeader), this operates on the selector.


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Equals, Contains, StartsWith, EndsWith

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Allowed values for the matchVariable.


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueMatchOperator
Operates on the allowed values for the matchVariable.


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Equals, Contains, StartsWith, EndsWith, IPMatch

Required: True
Position: Named
Default value: None
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### None
## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicyException
## NOTES

## RELATED LINKS
