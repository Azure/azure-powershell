### Example 1: Get custom classification rule by name
```powershell
<<<<<<< HEAD
Get-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com/ -Name ClassificationRule1
```

```output
=======
PS C:\> Get-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com/ -Name ClassificationRule1

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ClassificationAction   : Keep
ClassificationName     : ClassificationName1
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "column1"
                         }}
CreatedAt              : 1/27/2022 4:36:25 AM
DataPattern            : {{
                           "kind": "Regex",
                           "pattern": "^\\d{5}$"
                         }}
Description            : This is a description
Id                     : classificationrules/ClassificationRule1
Kind                   : Custom
LastModifiedAt         : 1/27/2022 4:36:25 AM
MinimumPercentageMatch : 60
Name                   : ClassificationRule1
RuleStatus             : Enabled
Version                : 1
```

Get classification rule named Classification1

### Example 2: Get all custom classification rules
```powershell
<<<<<<< HEAD
Get-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com/
```

```output
=======
PS C:\> Get-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com/

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ClassificationAction   : Keep
ClassificationName     : ClassificationName1
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "column1"
                         }}
CreatedAt              : 1/27/2022 4:36:25 AM
DataPattern            : {{
                           "kind": "Regex",
                           "pattern": "^\\d{5}$"
                         }}
Description            : This is a description
Id                     : classificationrules/ClassificationRule1
Kind                   : Custom
LastModifiedAt         : 1/27/2022 4:36:25 AM
MinimumPercentageMatch : 60
Name                   : ClassificationRule1
RuleStatus             : Enabled
Version                : 1

ClassificationAction   : Keep
ClassificationName     : ClassificationName2
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "column2"
                         }}
CreatedAt              : 1/27/2022 4:37:09 AM
DataPattern            : {{
                           "kind": "Regex",
                           "pattern": "^\\d{6}$"
                         }}
Description            : This is description
Id                     : classificationrules/ClassificationRule2
Kind                   : Custom
LastModifiedAt         : 1/27/2022 4:37:09 AM
MinimumPercentageMatch : 60
Name                   : ClassificationRule2
RuleStatus             : Enabled
Version                : 1
```

Get all custom classification rules

