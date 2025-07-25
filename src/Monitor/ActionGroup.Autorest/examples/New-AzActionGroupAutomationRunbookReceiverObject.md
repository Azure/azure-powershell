### Example 1: create action group automation runbook receiver
```powershell
New-AzActionGroupAutomationRunbookReceiverObject -AutomationAccountId "/subscriptions/187f412d-1758-44d9-b052-169e2564721d/resourceGroups/runbookTest/providers/Microsoft.Automation/automationAccounts/runbooktest" -RunbookName "sample runbook" -WebhookResourceId "/subscriptions/187f412d-1758-44d9-b052-169e2564721d/resourceGroups/runbookTest/providers/Microsoft.Automation/automationAccounts/runbooktest/webhooks/Alert1510184037084" -Name "testRunbook" -UseCommonAlertSchema $true -IsGlobalRunbook $false
```

```output
AutomationAccountId  : /subscriptions/187f412d-1758-44d9-b052-169e2564721d/resourceGroups/runbookTest/providers/Microsoft.Automation/a 
                       utomationAccounts/runbooktest
IsGlobalRunbook      : False
Name                 : testRunbook
RunbookName          : sample runbook
ServiceUri           : 
UseCommonAlertSchema : True
WebhookResourceId    : /subscriptions/187f412d-1758-44d9-b052-169e2564721d/resourceGroups/runbookTest/providers/Microsoft.Automation/a 
                       utomationAccounts/runbooktest/webhooks/Alert1510184037084
```

This command creates action group automation runbook receiver object.

