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

