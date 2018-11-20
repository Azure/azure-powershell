---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# Get-AzureRmApplicationGatewayRewriteRuleSet

## SYNOPSIS
Gets the rewrite rule set of an application gateway.

## SYNTAX

```
Get-AzureRmApplicationGatewayRewriteRuleSet [-Name <String>] -ApplicationGateway <PSApplicationGateway>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets the rewrite rule set of an application gateway.

## EXAMPLES

### Example 1 : Get a specific rewrite rule set
```
PS C:\>$AppGW = Get-AzureRmApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
PS C:\> $Rule = Get-AzureRmApplicationGatewayRewriteRuleSet -Name "RuleSet01" -ApplicationGateway $AppGW
```

The first command gets the Application Gateway named ApplicationGateway01 and stores the result in the variable named $AppGW.
The second command gets the rewrite rule set named RuleSet01 from the Application Gateway stored in the variable named $AppGW.
## PARAMETERS

### -ApplicationGateway
The applicationGateway

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGateway
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the application gateway RewriteRuleSet

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayRewriteRuleSet

## NOTES

## RELATED LINKS

[Add-AzureRmApplicationGatewayRewriteRuleSet](./Add-AzureRmApplicationGatewayRewriteRuleSet.md)

[New-AzureRmApplicationGatewayRewriteRuleSet](./New-AzureRmApplicationGatewayRewriteRuleSet.md)

[Remove-AzureRmApplicationGatewayRewriteRuleSet](./Remove-AzureRmApplicationGatewayRewriteRuleSet.md)

[Set-AzureRmApplicationGatewayRewriteRuleSet](./Set-AzureRmApplicationGatewayRewriteRuleSet.md)