---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/export-azresourcegrouptemplate
schema: 2.0.0
---

# Export-AzResourceGroupTemplate

## SYNOPSIS
Captures the specified resource group as a template.

## SYNTAX

### ExportSubscriptionIdViaHost (Default)
```
Export-AzResourceGroupTemplate -ResourceGroupName <String> [-Parameters <IExportTemplateRequest>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ExportExpanded
```
Export-AzResourceGroupTemplate -ResourceGroupName <String> -SubscriptionId <String> [-Options <String>]
 [-Resources <String[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Export
```
Export-AzResourceGroupTemplate -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameters <IExportTemplateRequest>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ExportSubscriptionIdViaHostExpanded
```
Export-AzResourceGroupTemplate -ResourceGroupName <String> [-Options <String>] [-Resources <String[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Captures the specified resource group as a template.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Options
The export template options.
Supported values include 'IncludeParameterDefaultValue', 'IncludeComments' or 'IncludeParameterDefaultValue, IncludeComments

```yaml
Type: System.String
Parameter Sets: ExportExpanded, ExportSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Export resource group template request parameters.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IExportTemplateRequest
Parameter Sets: ExportSubscriptionIdViaHost, Export
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to export as a template.

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

### -Resources
The IDs of the resources.
The only supported string currently is '*' (all resources).
Future updates will support exporting specific resources.

```yaml
Type: System.String[]
Parameter Sets: ExportExpanded, ExportSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: ExportExpanded, Export
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IResourceGroupExportResult
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/export-azresourcegrouptemplate](https://docs.microsoft.com/en-us/powershell/module/az.resources/export-azresourcegrouptemplate)

