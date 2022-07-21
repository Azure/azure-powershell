---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/get-azoperationalinsightstable
schema: 2.0.0
---

# Get-AzOperationalInsightsTable

## SYNOPSIS
Get or list tables for workspace.

## SYNTAX

```
Get-AzOperationalInsightsTable [-ResourceGroupName] <String> [-WorkspaceName] <String> [[-TableName] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get or list tables for a workspace, list tables under workspace when "-TableName" was not provided.

## EXAMPLES

### Example 1: Get all tables for a workspace
```powershell
Get-AzOperationalInsightsTable -ResourceGroupName "ContosoResourceGroup" -WorkspaceName "ContosoWorkspace"
```

This command gets all of the tables associated with a workspace.

### Example 2: Get a specific table by name
```powershell
Get-AzOperationalInsightsTable -ResourceGroupName "ContosoResourceGroup" -WorkspaceName "ContosoWorkspace" -tableName "ContosoSavedTableName"
```

This command gets a specific table by its name.

## PARAMETERS

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
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TableName
The table name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace that contains the table.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSTable

## NOTES

## RELATED LINKS
