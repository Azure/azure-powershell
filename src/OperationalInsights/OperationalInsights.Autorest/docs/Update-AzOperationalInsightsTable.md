---
external help file:
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/update-azoperationalinsightstable
schema: 2.0.0
---

# Update-AzOperationalInsightsTable

## SYNOPSIS
Update a Log Analytics workspace table.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzOperationalInsightsTable -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-Plan <TablePlanEnum>] [-RestoredLogsSourceTable <String>]
 [-RetentionInDay <Int32>] [-SchemaColumn <IColumn[]>] [-SchemaDescription <String>]
 [-SchemaDisplayName <String>] [-SchemaName <String>] [-TotalRetentionInDay <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzOperationalInsightsTable -InputObject <IOperationalInsightsIdentity> [-Plan <TablePlanEnum>]
 [-RestoredLogsSourceTable <String>] [-RetentionInDay <Int32>] [-SchemaColumn <IColumn[]>]
 [-SchemaDescription <String>] [-SchemaDisplayName <String>] [-SchemaName <String>]
 [-TotalRetentionInDay <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a Log Analytics workspace table.

## EXAMPLES

### Example 1: Update table's retention 
```powershell
PS C:\> Update-AzOperationalInsightsTable -ResourceGroupName {RG-name} -WorkspaceName {WS-name} -Name {TableName_CL} -RetentionInDay 40

Name             ResourceGroupName
----             -----------------
dabenhamKuku1_CL
```

Update of custom table retention

### Example 2: Update a default table will not work at first try 
```powershell
PS C:\> Update-AzOperationalInsightsTable -ResourceGroupName {RG-name} -WorkspaceName {WS-name} -Name Heartbeat -RetentionInDay 40

Update-AzOperationalInsightsTable_UpdateExpanded: 'Patch' cannot be used for table creation - Heartbeat. Use 'Put' instead.

PS C:\>$tempTable = New-AzOperationalInsightsTable -ResourceGroupName {RG-name} -WorkspaceName {WS-name} -Name Heartbeat -RetentionInDay 50 
PS C:\>$tempTable
Name      ResourceGroupName
----      -----------------
Heartbeat

$tempTable.RetentionInDay
50

PS C:\>$tempTable = Update-AzOperationalInsightsTable -ResourceGroupName {RG-name} -WorkspaceName {WS-name} -Name Heartbeat -RetentionInDay 30
PS C:\>$tempTable
Name      ResourceGroupName
----      -----------------
Heartbeat

$tempTable.RetentionInDay
30
```

To update a default table for the first time, please use New-AzOperationalInsightsTable as you would use Update-AzOperationalInsightsTable.

After the using New-AzOperationalInsightsTable for the first time, you can use Update-AzOperationalInsightsTable normally

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.IOperationalInsightsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the table.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: TableName

Required: True
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

### -Plan
Instruct the system how to handle and charge the logs ingested to this table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Support.TablePlanEnum
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoredLogsSourceTable
The table to restore data from.

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

### -RetentionInDay
The table retention in days, between 4 and 730.
Setting this property to -1 will default to the workspace retention.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaColumn
A list of table custom columns.
To construct, see NOTES section for SCHEMACOLUMN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.Api20211201Preview.IColumn[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaDescription
Table description.

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

### -SchemaDisplayName
Table display name.

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

### -SchemaName
Table name.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TotalRetentionInDay
The table total retention in days, between 4 and 2555.
Setting this property to -1 will default to table retention.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.IOperationalInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.Api20211201Preview.ITable

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IOperationalInsightsIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[TableName <String>]`: The name of the table.
  - `[WorkspaceName <String>]`: The name of the workspace.

SCHEMACOLUMN <IColumn[]>: A list of table custom columns.
  - `[DataTypeHint <ColumnDataTypeHintEnum?>]`: Column data type logical hint.
  - `[Description <String>]`: Column description.
  - `[DisplayName <String>]`: Column display name.
  - `[Name <String>]`: Column name.
  - `[Type <ColumnTypeEnum?>]`: Column data type.

## RELATED LINKS

