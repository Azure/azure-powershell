---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/get-azoperationalinsightsdataexport
schema: 2.0.0
---

# Get-AzOperationalInsightsDataExport

## SYNOPSIS
Get or list data exports for workspace.

## SYNTAX

### ListParameterSet (Default)
```
Get-AzOperationalInsightsDataExport [-ResourceGroupName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByNameParameterSet
```
Get-AzOperationalInsightsDataExport -ResourceGroupName <String> -WorkspaceName <String>
 [-DataExportName <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzOperationalInsightsDataExport -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a workspace's Data export by name or all existing workspace's data exports.

## EXAMPLES

### Example 1
```powershell
Get-AzOperationalInsightsDataExport -ResourceGroupName "rg-name" -WorkspaceName "workspace-name" -DataExportName "dataExportName"
```

```output
Name             : {dataExportName}
Id               : /subscriptions/{subscription}/resourcegroups/{rg-name}/providers/microsoft.operationalinsights/workspaces/{workspace-name}/dataexports/{dataExportName}
Type             : Microsoft.OperationalInsights/workspaces/export
DataExportId     : {GUID}
TableNames       : {tbl1,tbl2}
ResourceId       : /subscriptions/{resource_subscription}/resourceGroups/{resource_rg}/providers/Microsoft.Storage/storageAc
                   counts/{storage_name}
DataExportType   : StorageAccount
EventHubName     :
Enable           : True
CreatedDate      : 
LastModifiedDate :
```

Gets a workspace's Data export.

### Example 2
```powershell
Get-AzOperationalInsightsDataExport -ResourceGroupName "rg-name" -WorkspaceName "workspace-name"
```

Gets all workspace's Data exports.

## PARAMETERS

### -DataExportName
The data export name.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
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

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
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
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace that will contain the storage insight.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSDataExport

## NOTES

## RELATED LINKS
