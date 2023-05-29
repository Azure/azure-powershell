---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azfirewallpolicyapplicationrulecustomhttpHeader
schema: 2.0.0
---

# New-AzFirewallPolicyApplicationRuleCustomHttpHeader

## SYNOPSIS
Create a new Azure Firewall Policy Application Rule Custon HTTP Header

## SYNTAX

```
New-AzFirewallPolicyApplicationRuleCustomHttpHeader -HeaderName <String> -HeaderValue <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzFirewallPolicyApplicationRuleCustomHttpHeader** cmdlet creates a Custom HTTP Header for Application Rule.

## EXAMPLES

### Example 1
```powershell
$appRule = New-AzFirewallPolicyApplicationRule -Name "appRule" -SourceAddress "192.168.0.0/16" -TargetFqdn "*.contoso.com" -Protocol "https:443"

$headerToInsert = New-AzFirewallPolicyApplicationRuleCustomHttpHeader -HeaderName "Restrict-Access-To-Tenants" -HeaderValue "contoso.com,fabrikam.onmicrosoft.com"

$appRule.AddCustomHttpHeaderToInsert($headerToInsert)
```

This example creates an application rule and a custom HTTP header, then adds the header to the rule.

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

### -HeaderName
The description of the rule

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

### -HeaderValue
The description of the rule

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

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicyApplicationRuleCustomHttpHeader

## NOTES

## RELATED LINKS
