---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# Remove-AzureRmApplicationGatewayRewriteRuleSet

## SYNOPSIS
Removes a rewrite rule set from an application gateway.

## SYNTAX

```
Remove-AzureRmApplicationGatewayRewriteRuleSet -Name <String> -ApplicationGateway <PSApplicationGateway>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmApplicationGatewayRewriteRuleSet** cmdlet removes a rewrite rule set from an Azure application gateway.

## EXAMPLES

### Example 1
```powershell
PS C:\>$AppGw = Get-AzureRmApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
PS C:\> Remove-AzureRmApplicationGatewayRewriteRuleSet -ApplicationGateway $AppGw -Name "RuleSet02"
```

The first command gets an application gateway and stores it in the $AppGw variable.
The second command removes the rewrite rule set named RuleSet02 from the application gateway stored in $AppGw.


## PARAMETERS

### -ApplicationGateway
The applicationGateway

```yaml
Type: PSApplicationGateway
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
The name of the application gateway RewriteRuleSet

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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayRewriteRuleSet

## NOTES

## RELATED LINKS
[Add-AzureRmApplicationGatewayRewriteRuleSet](./Add-AzureRmApplicationGatewayRewriteRuleSet.md)

[Get-AzureRmApplicationGatewayRewriteRuleSet](./Get-AzureRmApplicationGatewayRewriteRuleSet.md)

[New-AzureRmApplicationGatewayRewriteRuleSet](./New-AzureRmApplicationGatewayRewriteRuleSet.md)

[Set-AzureRmApplicationGatewayRewriteRuleSet](./Set-AzureRmApplicationGatewayRewriteRuleSet.md)