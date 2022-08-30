---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version:
schema: 2.0.0
---

# New-AzAutomationHybridRunbookWorker

## SYNOPSIS
Create a Runbook Worker.

## SYNTAX

```
New-AzAutomationHybridRunbookWorker [-Name] <String> [-HybridRunbookWorkerGroupName] <String>
 -VmResourceId <String> [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzAutomationHybridRunbookWorker** cmdlet creates a Runbook Worker.

## EXAMPLES

### Example 1
```powershell
New-AzAutomationHybridRunbookWorker -AutomationAccountName "Contoso17" -Name "RunbookWorkerName" -HybridRunbookWorkerGroupName "RunbookWorkerGroupName" -VmResourceId "VmResourceId" -ResourceGroupName "ResourceGroup01"
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
The hybrid runbook worker group name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RunbookWorkerGroup, WorkerGroup

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
Parameter Sets: (All)
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

### -VmResourceId
The resource id of the vm to be added to the hybrid worker group

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VMId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
