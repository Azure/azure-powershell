---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/remove-azpurviewclassificationrule
schema: 2.0.0
---

# Remove-AzPurviewClassificationRule

## SYNOPSIS
Deletes a classification rule

## SYNTAX

```
Remove-AzPurviewClassificationRule -Endpoint <String> -Name <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deletes a classification rule

## EXAMPLES

### Example 1: Delete custom classification rule by name
```powershell
Remove-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com -ClassificationRuleName 'RuleDUmmy'
```

```output
ClassificationAction   : Keep
ClassificationName     : MICROSOFT.GOVERNMENT.AUSTRALIA.DRIVERS_LICENSE_NUMBER
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "Column1"
                         }, {
                           "kind": "Regex",
                           "pattern": "Column2"
                         }}
CreatedAt              : 2/3/2022 11:28:58 AM
DataPattern            : {}
Description            : Description
Id                     : classificationrules/RuleDUmmy
Kind                   : Custom
LastModifiedAt         : 2/3/2022 11:28:58 AM
MinimumPercentageMatch :
Name                   : RuleDUmmy
RuleStatus             : Enabled
Version                : 1
```

Delete custom classification rule named 'ClassificationRule4'

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The scanning endpoint of your purview account.
Example: https://{accountName}.purview.azure.com

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

### -Name
.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClassificationRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IClassificationRule

## NOTES

## RELATED LINKS

