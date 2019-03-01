---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# Set-AzApplicationGatewayFirewallPolicy

## SYNOPSIS
Updates an application gateway firewall policy.

## SYNTAX

```
Set-AzApplicationGatewayFirewallPolicy
 -ApplicationGatewayFirewallPolicy <PSApplicationGatewayWebApplicationFirewallPolicy> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzApplicationGatewayFirewallPolicy** cmdlet updates an Azure application gateway firewall policy.

## EXAMPLES

### Example 1
```powershell
PS C:\> $UpdatedAppGwFirewallPolicy = Set-AzApplicationGatewayFirewallPolicy -ApplicationGateway $AppGwFirewallPolicy
```

This command updates the application gateway firewall policy with settings in the $AppGwFirewallPolicy variable and stores the updated gateway in the $UpdatedAppGwFirewallPolicy variable.

## PARAMETERS

### -ApplicationGatewayFirewallPolicy
The applicationGatewayFirewallPolicy

```yaml
Type: PSApplicationGatewayWebApplicationFirewallPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayWebApplicationFirewallPolicy

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayWebApplicationFirewallPolicy

## NOTES

## RELATED LINKS
