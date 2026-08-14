---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azfirewallpolicykubelabelselector
schema: 2.0.0
---

# New-AzFirewallPolicyKubeLabelSelector

## SYNOPSIS
Creates an in-memory Kubernetes label selector for use in a Kube Selector Group.

## SYNTAX

```
New-AzFirewallPolicyKubeLabelSelector [-MatchLabel <Hashtable>]
 [-MatchExpression <PSLabelSelectorExpression[]>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzFirewallPolicyKubeLabelSelector** cmdlet creates an in-memory Kubernetes label selector, composed of match labels and/or match expressions, for use as a pod or namespace selector in a Kube Selector Group.

## EXAMPLES

### Example 1
```powershell
$expression = New-AzFirewallPolicyLabelSelectorExpression -Key "tier" -Operator In -Value "frontend"
New-AzFirewallPolicyKubeLabelSelector -MatchLabel @{ app = "web"; env = "prod" } -MatchExpression $expression
```

This example builds a label selector matching resources labeled app=web and env=prod with tier in (frontend).

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

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

### -MatchExpression
A list of label selector requirements.
All requirements are ANDed.

```yaml
Type: PSLabelSelectorExpression[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchLabel
A map of {key,value} label pairs.
All pairs are ANDed.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
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

### Microsoft.Azure.Commands.Network.Models.PSKubeLabelSelector

## NOTES

## RELATED LINKS
