---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/update-azoperationalinsightsdataexport
schema: 2.0.0
---

# Update-AzOperationalInsightsDataExport

## SYNOPSIS
Update data export.

## SYNTAX

### UpdateByNameParameterSet (Default)
```
Update-AzOperationalInsightsDataExport -ResourceGroupName <String> -WorkspaceName <String>
 [-DataExportName <String>] [-TableName <String[]>] [-DestinationResourceId <String>] [-EventHubName <String>]
 [-Enable <Boolean>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByResourceIdParameterSet
```
Update-AzOperationalInsightsDataExport -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByInputObjectParameterSet
```
Update-AzOperationalInsightsDataExport -InputDataExport <PSDataExport>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a data export.

## EXAMPLES

### Example 1
```powershell
Update-AzOperationalInsightsDataExport -ResourceGroupName "rg-name" -WorkspaceName "workspace-name" -DataExportName "dataExportName" -TableName "table_name" -Enable $true
```

```output
Name             : {dataExportName}
Id               : /subscriptions/{subscription}/resourcegroups/{rg-name}/providers/microsoft.operationalinsights/workspaces/{workspace-name}/dataexports/{dataExportName}
Type             : Microsoft.OperationalInsights/workspaces/export
DataExportId     : {GUID}
TableNames       : {table_name}
ResourceId       : /subscriptions/{resource_subscription}/resourceGroups/{resource_rg}/providers/Microsoft.Storage/storageAc
                   counts/{storage_name}
DataExportType   : StorageAccount
EventHubName     :
Enable           : true
CreatedDate      : 
LastModifiedDate :
```

Updates a workspace's Data export.

## PARAMETERS

### -DataExportName
The data export name.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -DestinationResourceId
The destination resource ID. This can be copied from the Properties entry of the destination resource in Azure.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enable
Active when enabled.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: UpdateByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventHubName
Optional.
Allows to define an Event Hub name.
Not applicable when destination is Storage Account.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputDataExport
Specifies the DataExport to be updated.

```yaml
Type: Microsoft.Azure.Commands.OperationalInsights.Models.PSDataExport
Parameter Sets: UpdateByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The destination resource ID.
This can be copied from the Properties entry of the destination resource in Azure.

```yaml
Type: System.String
Parameter Sets: UpdateByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TableName
An array of tables to export, for example: ["Heartbeat, SecurityEvent"].

```yaml
Type: System.String[]
Parameter Sets: UpdateByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace that will contain the storage insight.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet
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

### System.String

### Microsoft.Azure.Commands.OperationalInsights.Models.PSDataExport

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSDataExport

## NOTES

## RELATED LINKS
