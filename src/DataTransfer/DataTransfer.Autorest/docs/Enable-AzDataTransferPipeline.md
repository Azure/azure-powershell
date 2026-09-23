---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/enable-azdatatransferpipeline
schema: 2.0.0
---

# Enable-AzDataTransferPipeline

## SYNOPSIS
Enables an Azure Data Transfer pipeline.

## SYNTAX

```
Enable-AzDataTransferPipeline -PipelineName <String> -ResourceGroupName <String> [-AsJob]
 [-DefaultProfile <PSObject>] [-Justification <String>] [-NoWait] [-SubscriptionId <String>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Enable-AzDataTransferPipeline cmdlet enables a previously disabled Azure Data Transfer pipeline.
This allows new connections and flows to be created within the pipeline.

## EXAMPLES

### Example 1: Enable a pipeline
```powershell
Enable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01"
```

Enables the pipeline named "Pipeline01" in the "ResourceGroup01" resource group.

### Example 2: Enable a pipeline with justification
```powershell
Enable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -Justification "Re-enabling after maintenance"
```

Enables the pipeline with a business justification.

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

### -Justification
Business justification for enabling the pipeline

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
The name of the pipeline to enable

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

