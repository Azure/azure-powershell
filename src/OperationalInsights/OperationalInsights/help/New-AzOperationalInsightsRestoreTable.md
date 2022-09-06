---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/Create-AzOperationalInsightsRestoreTable
schema: 2.0.0
---

# New-AzOperationalInsightsRestoreTable

## SYNOPSIS
Create a new Restore table

## SYNTAX

```
New-AzOperationalInsightsRestoreTable [-ResourceGroupName] <String> [-WorkspaceName] <String>
 [-TableName] <String> -StartRestoreTime <String> -EndRestoreTime <String> -SourceTable <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Restore table

## EXAMPLES

### Example 1
```powershell
New-AzOperationalInsightsRestoreTable -ResourceGroupName RG-NAME -WorkspaceName WORKSPACE-NAME -TableName TABLE-NAME -StartRestoreTime "05-25-2022 12:26:36" -EndRestoreTime "05-28-2022 12:26:36" -SourceTable "Usage"
```

```output
TableName            : TABLE-NAME
ResourceId           : /subscriptions/SUBSCRIPTION-ID/resourcegroups/RG-NAME/providers/Microsoft.OperationalInsights/workspaces/WORKSPACE-NAME/tables/TABLE-NAME
RetentionInDays      :
TotalRetentionInDays :
Plan                 : Analytics
Description          :
Schema               : Microsoft.Azure.Management.OperationalInsights.Models.Schema
ProvisioningState    : Succeeded
ResourceGroupName    : RG-NAME
WorkspaceName        : WORKSPACE-NAME
```

Create a Restore table

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -EndRestoreTime
The timestamp to end the restore by (UTC).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -SourceTable
The table to restore data from.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StartRestoreTime
The timestamp to start the restore from (UTC).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TableName
The table name.
For Restore table the name should end with '_RST'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace that will contain the storage insight.

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

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSTable

## NOTES

## RELATED LINKS
