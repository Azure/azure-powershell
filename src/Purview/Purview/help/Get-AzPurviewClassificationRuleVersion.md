---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/get-azpurviewclassificationruleversion
schema: 2.0.0
---

# Get-AzPurviewClassificationRuleVersion

## SYNOPSIS
Lists the rule versions of a classification rule

## SYNTAX

```
Get-AzPurviewClassificationRuleVersion -Endpoint <String> -ClassificationRuleName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Lists the rule versions of a classification rule

## EXAMPLES

### Example 1: Get all version of a custom classification rule
```powershell
Get-AzPurviewClassificationRuleVersion -Endpoint https://parv-brs-2.purview.azure.com -ClassificationRuleName 'ClassificationRule5'
```

```output
ClassificationAction   : Keep
ClassificationName     : ClassificationRule4
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "^col1$"
                         }, {
                           "kind": "Regex",
                           "pattern": "^col2$"
                         }}
CreatedAt              : 2/8/2022 10:04:55 PM
DataPattern            : {}
Description            : This is a rule2
Id                     : classificationrules/ClassificationRule5/versions/1
Kind                   : Custom
LastModifiedAt         : 2/8/2022 10:04:55 PM
MinimumPercentageMatch :
Name                   : ClassificationRule5
RuleStatus             : Enabled
Version                : 1

ClassificationAction   : Keep
ClassificationName     : ClassificationRule4
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "^col1$"
                         }, {
                           "kind": "Regex",
                           "pattern": "^col2$"
                         }}
CreatedAt              : 2/8/2022 10:04:55 PM
DataPattern            : {}
Description            : This is a rule2
Id                     : classificationrules/ClassificationRule5/versions/2
Kind                   : Custom
LastModifiedAt         : 2/14/2022 9:00:32 AM
MinimumPercentageMatch :
Name                   : ClassificationRule5
RuleStatus             : Enabled
Version                : 2
```

Get all version of a custom classification rule

## PARAMETERS

### -ClassificationRuleName
.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
