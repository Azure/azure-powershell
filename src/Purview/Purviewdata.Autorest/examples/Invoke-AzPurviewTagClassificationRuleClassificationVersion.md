### Example 1: Set Classification Action on specific rule version
```powershell
PS C:\> Invoke-AzPurviewTagClassificationRuleClassificationVersion -Endpoint 'https://parv-brs-2.purview.azure.com/' -ClassificationRuleName 'ClassificationRule2' -ClassificationRuleVersion 1 -Action 'Delete'

EndTime ScanResultId StartTime Status
------- ------------ --------- ------
                               Accepted
```

Set Classification Action on specific rule version

