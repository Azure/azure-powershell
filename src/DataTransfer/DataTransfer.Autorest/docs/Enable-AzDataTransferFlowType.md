---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/enable-azdatatransferflowtype
schema: 2.0.0
---

# Enable-AzDataTransferFlowType

## SYNOPSIS
Enables Azure Data Transfer flow types.

## SYNTAX

```
Enable-AzDataTransferFlowType -FlowType <String[]> -PipelineName <String> -ResourceGroupName <String> [-AsJob]
 [-DefaultProfile <PSObject>] [-Justification <String>] [-NoWait] [-SubscriptionId <String>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Enable-AzDataTransferFlowType cmdlet enables previously disabled flow types within an Azure Data Transfer pipeline.
This allows new flows of the specified types to be created and existing flows of those types to resume operations.

## EXAMPLES

### Example 1: Enable a single flow type
```powershell
Enable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType "FlowType01"
```

Enables the "FlowType01" flow type.

### Example 2: Enable multiple flow types
```powershell
Enable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType @("FlowType01", "FlowType02")
```

Enables both "FlowType01" and "FlowType02" flow types.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlowType
One or more flow type names to enable

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Justification
Business justification for enabling the flow types

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

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PipelineName
The name of the pipeline containing the flow types

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

### -ResourceGroupName
The name of the resource group

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

### -SubscriptionId
The ID of the target subscription

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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

## OUTPUTS

### ADT.Models.IPipeline

## NOTES

## RELATED LINKS

