### Example 1: Set Classification Action on specific rule version
```powershell
<<<<<<< HEAD
Invoke-AzPurviewTagClassificationRuleClassificationVersion -Endpoint 'https://parv-brs-2.purview.azure.com/' -ClassificationRuleName 'ClassificationRule2' -ClassificationRuleVersion 1 -Action 'Delete'
```

```output
=======
PS C:\> Invoke-AzPurviewTagClassificationRuleClassificationVersion -Endpoint 'https://parv-brs-2.purview.azure.com/' -ClassificationRuleName 'ClassificationRule2' -ClassificationRuleVersion 1 -Action 'Delete'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
EndTime ScanResultId StartTime Status
------- ------------ --------- ------
                               Accepted
```

Set Classification Action on specific rule version

