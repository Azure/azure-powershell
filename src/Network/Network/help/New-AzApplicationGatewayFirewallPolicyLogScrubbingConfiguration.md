---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallpolicylogscrubbingconfiguration
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallPolicyLogScrubbingConfiguration

## SYNOPSIS
Creates a log scrubbing configuration for firewall policy

## SYNTAX

```
New-AzApplicationGatewayFirewallPolicyLogScrubbingConfiguration -State <String>
 -ScrubbingRule <PSApplicationGatewayFirewallPolicyLogScrubbingRule[]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallPolicyLogScrubbingConfiguration** creates a log scrubbing configuration for firewall policy.

## EXAMPLES

### Example 1
```powershell
$logScrubbingRuleConfig = New-AzApplicationGatewayFirewallPolicyLogScrubbingConfiguration -State Enabled -ScrubbingRule $logScrubbingRule1
```

The command creates a log scrubbing rule configuration with state as enable, ScrubbingRule as $logScrubbingRule1.
The new log scrubbing rule configuration is stored to $logScrubbingRuleConfig.

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
The rules that are applied to the logs for scrubbing.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicyLogScrubbingRule[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
State of the log scrubbing config. Default value is Enabled.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Enabled, Disabled

Required: True
Position: Named
Default value: Enabled
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicySettings

## NOTES

## RELATED LINKS
