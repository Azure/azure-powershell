---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# New-AzureRmApplicationGatewayRewriteRule

## SYNOPSIS
Creates a rewrite rule for an application gateway.

## SYNTAX

```
New-AzureRmApplicationGatewayRewriteRule -Name <String> -ActionSet <PSApplicationGatewayRewriteRuleActionSet>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
**The New-AzureRmApplicationGatewayRewriteRule** cmdlet creates a rewrite rule for an Azure application gateway.

## EXAMPLES

### Example 1 : Create a rewrite rule for an application gateway
```powershell
PS C:\>$rule = New-AzureRmApplicationGatewayRewriteRule -Name rule1 -ActionSet $action
```

This command creates a rewrite rule named rule1 and stores the result in the variable named $rule.

## PARAMETERS

### -ActionSet
ActionSet of the rewrite rule

```yaml
Type: PSApplicationGatewayRewriteRuleActionSet
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the RewriteRule

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayRewriteRule

## NOTES

## RELATED LINKS

