### Example 1: Create custom classification object
```powershell
$reg1 = New-AzPurviewRegexClassificationRulePatternObject -Pattern '^col1$'
$reg2 = New-AzPurviewRegexClassificationRulePatternObject -Pattern '^col2$'
$regexarr = @($reg1, $reg2)
$obj = New-AzPurviewCustomClassificationRuleObject -Kind 'Custom' -ClassificationName ClassificationRule4 -RuleStatus 'Enabled' -Description 'This is a rule2' -ColumnPattern $regexarr
New-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com -ClassificationRuleName ClassificationRule5 -Body $obj
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
Id                     : classificationrules/ClassificationRule5
Kind                   : Custom
LastModifiedAt         : 2/14/2022 9:00:32 AM
MinimumPercentageMatch :
Name                   : ClassificationRule5
RuleStatus             : Enabled
Version                : 2
```

Create custom classification object named 'ClassificationRule4'

