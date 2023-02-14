### Example 1: Create custom classification object
```powershell
<<<<<<< HEAD
$reg1 = New-AzPurviewRegexClassificationRulePatternObject -Pattern '^col1$'
=======
PS C:\> $reg1 = New-AzPurviewRegexClassificationRulePatternObject -Pattern '^col1$'
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
$reg2 = New-AzPurviewRegexClassificationRulePatternObject -Pattern '^col2$'
$regexarr = @($reg1, $reg2)
$obj = New-AzPurviewCustomClassificationRuleObject -Kind 'Custom' -ClassificationName ClassificationRule4 -RuleStatus 'Enabled' -Description 'This is a rule2' -ColumnPattern $regexarr
New-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com -ClassificationRuleName ClassificationRule5 -Body $obj
<<<<<<< HEAD
```

```output
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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

