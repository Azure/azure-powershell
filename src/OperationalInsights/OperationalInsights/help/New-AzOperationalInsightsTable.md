---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/Create-AzOperationalInsightsTable
schema: 2.0.0
---

# New-AzOperationalInsightsTable

## SYNOPSIS
Creates a custom log table

## SYNTAX

```
New-AzOperationalInsightsTable [-ResourceGroupName] <String> [-WorkspaceName] <String> [-TableName] <String>
 [[-RetentionInDays] <Int32>] [-TotalRetentionInDays <Int32>] [-Column <Hashtable>] [-Plan <String>]
 [-Description <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a custom log table

## EXAMPLES

### Example 1
```powershell
New-AzOperationalInsightsTable -ResourceGroupName RG-NAME -WorkspaceName WORKSPACE-NAME -TableName TABLE-NAME -RetentionInDays 25 -TotalRetentionInDays 30 -Column @{'ColName1' = 'string'; 'TimeGenerated' = 'DateTime'; 'ColName3' = 'int'}
```

```output
TableName            : TABLE-NAME
ResourceId           : /subscriptions/{subscriptionID}/resourcegroups/RG-NAME/providers/Microsoft.OperationalInsights/workspaces/WORKSPACE-NAME/tables/TABLE-NAME
RetentionInDays      : 25
TotalRetentionInDays : 30
Plan                 : Analytics
Description          :
Schema               : Microsoft.Azure.Management.OperationalInsights.Models.Schema
ProvisioningState    : Succeeded
ResourceGroupName    : RG-NAME
WorkspaceName        : WORKSPACE-NAME
```

Creates a custom log table with provided retention details and columns

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

### -Column
The table column passed as @{ ColName1 = Type; ColName2 = Type; ColName3 = Type}.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
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

### -Description
Search job Description.

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

### -Plan
Table plan can be 'Analytics' or 'Basic'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Analytics, Basic

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

### -RetentionInDays
The table retention in days, between 4 and 730.
Setting this property to -1 will default to the workspace retention

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
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

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TotalRetentionInDays
The table total retention in days, between 4 and 2555.
Setting this property to -1 will default to table retention.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
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

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSTable

## NOTES

## RELATED LINKS
