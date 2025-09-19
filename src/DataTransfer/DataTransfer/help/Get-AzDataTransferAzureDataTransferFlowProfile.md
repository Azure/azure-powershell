---
external help file: Az.DataTransfer-help.xml
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/get-azdatatransferazuredatatransferflowprofile
schema: 2.0.0
---

# Get-AzDataTransferAzureDataTransferFlowProfile

## SYNOPSIS
Retrieves a list of FlowProfile resources associated with a specified pipeline.

## SYNTAX

### ListExpanded (Default)
```
Get-AzDataTransferAzureDataTransferFlowProfile [-PipelineName <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### List
```
Get-AzDataTransferAzureDataTransferFlowProfile -Body <IListFlowProfilesRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonFilePath
```
Get-AzDataTransferAzureDataTransferFlowProfile -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonString
```
Get-AzDataTransferAzureDataTransferFlowProfile -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Retrieves a list of FlowProfile resources associated with a specified pipeline.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Body
Defines the required request body for retrieving FlowProfile information for a provided pipeline.

```yaml
Type: ADT.Models.IListFlowProfilesRequest
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PipelineName
The name of the pipeline for which to retrieve associated FlowProfiles.

```yaml
Type: System.String
Parameter Sets: ListExpanded
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

### ADT.Models.IListFlowProfilesRequest

## OUTPUTS

### ADT.Models.IFlowProfileMetadata

## NOTES

## RELATED LINKS
