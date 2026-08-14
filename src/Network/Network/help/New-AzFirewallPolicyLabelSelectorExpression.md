---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Microsoft.Azure.PowerShell.Cmdlets.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azfirewallpolicylabelselectorexpression
schema: 2.0.0
---

# New-AzFirewallPolicyLabelSelectorExpression

## SYNOPSIS
Creates an in-memory label selector requirement (match expression).

## SYNTAX

```
New-AzFirewallPolicyLabelSelectorExpression -Key <String> -Operator <String> [-Value <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzFirewallPolicyLabelSelectorExpression** cmdlet creates an in-memory label selector requirement composed of a key, an operator (In, NotIn, Exists or DoesNotExist) and an optional set of values.

## EXAMPLES

### Example 1
```powershell
New-AzFirewallPolicyLabelSelectorExpression -Key "tier" -Operator In -Value "frontend","backend"
```

This example builds a match expression requiring the tier label to be in (frontend, backend).

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

### -Key
The label key that the selector applies to.

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

### -Operator
The operator that relates the key and values.
Valid values are In, NotIn, Exists and DoesNotExist.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: In, NotIn, Exists, DoesNotExist

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The values array.
Required when Operator is In or NotIn, and must be empty when Operator is Exists or DoesNotExist.

```yaml
Type: String[]
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

### Microsoft.Azure.Commands.Network.Models.PSLabelSelectorExpression

## NOTES

## RELATED LINKS
