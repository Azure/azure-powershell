---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongroupautomationrunbookreceiverobject
schema: 2.0.0
---

# New-AzActionGroupAutomationRunbookReceiverObject

## SYNOPSIS
Create an in-memory object for AutomationRunbookReceiver.

## SYNTAX

```
New-AzActionGroupAutomationRunbookReceiverObject -AutomationAccountId <String> -IsGlobalRunbook <Boolean>
 -RunbookName <String> -WebhookResourceId <String> [-Name <String>] [-ServiceUri <String>]
 [-UseCommonAlertSchema <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AutomationRunbookReceiver.

## EXAMPLES

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

## PARAMETERS

### -AutomationAccountId
The Azure automation account Id which holds this runbook and authenticate to Azure resource.

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

### -IsGlobalRunbook
Indicates whether this instance is global runbook.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Indicates name of the webhook.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunbookName
The name for this runbook.

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

### -ServiceUri
The URI where webhooks should be sent.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseCommonAlertSchema
Indicates whether to use common alert schema.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebhookResourceId
The resource id for webhook linked to this runbook.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.AutomationRunbookReceiver

## NOTES

## RELATED LINKS

