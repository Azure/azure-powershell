---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version:
schema: 2.0.0
---

# Get-AzAutomationHybridRunbookWorker

## SYNOPSIS
Gets a Hybrid Runbook Worker.

## SYNTAX

### ByAll (Default)
```
Get-AzAutomationHybridRunbookWorker [-HybridRunbookWorkerGroupName] <String> [-ResourceGroupName] <String>
 [-AutomationAccountName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByName
```
Get-AzAutomationHybridRunbookWorker [-Name] <String> [-HybridRunbookWorkerGroupName] <String>
 [-ResourceGroupName] <String> [-AutomationAccountName] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzAutomationHybridRunbookWorker** cmdlet gets a Hybrid Runbook Worker.

## EXAMPLES

### Example 1
```powershell
Get-AzAutomationHybridRunbookWorker -AutomationAccountName "Contoso17" -Name "RunbookWorkerName" -ResourceGroupName "ResourceGroup01"
```

## PARAMETERS

### -AutomationAccountName
The automation account name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HybridRunbookWorkerGroupName
The Hybrid Runbook Worker Group name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: WorkerGroup, RunbookWorkerGroup

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Hybrid Runbook Worker name

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: RunbookWorker, RunbookWorkerId

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.Automation.Models.HybridRunbookWorker

## NOTES

## RELATED LINKS
