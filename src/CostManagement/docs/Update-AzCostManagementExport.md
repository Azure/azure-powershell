---
external help file:
Module Name: Az.Cost
online version: https://docs.microsoft.com/en-us/powershell/module/az.cost/update-azcostmanagementexport
schema: 2.0.0
---

# Update-AzCostManagementExport

## SYNOPSIS
The operation to create or update a export.
Update operation requires latest eTag to be set in the request.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzCostManagementExport -Name <String> -Scope <String> [-ConfigurationColumn <String[]>]
 [-DatasetAggregation <Hashtable>] [-DatasetFilter <IQueryFilter>] [-DatasetGranularity <GranularityType>]
 [-DatasetGrouping <IQueryGrouping[]>] [-DefinitionTimeframe <TimeframeType>] [-DefinitionType <ExportType>]
 [-DestinationContainer <String>] [-DestinationResourceId <String>] [-DestinationRootFolderPath <String>]
 [-Format <FormatType>] [-RecurrencePeriodFrom <DateTime>] [-RecurrencePeriodTo <DateTime>]
 [-ScheduleRecurrence <RecurrenceType>] [-ScheduleStatus <StatusType>] [-TimePeriodFrom <DateTime>]
 [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzCostManagementExport -InputObject <ICostIdentity> [-ConfigurationColumn <String[]>]
 [-DatasetAggregation <Hashtable>] [-DatasetFilter <IQueryFilter>] [-DatasetGranularity <GranularityType>]
 [-DatasetGrouping <IQueryGrouping[]>] [-DefinitionTimeframe <TimeframeType>] [-DefinitionType <ExportType>]
 [-DestinationContainer <String>] [-DestinationResourceId <String>] [-DestinationRootFolderPath <String>]
 [-Format <FormatType>] [-RecurrencePeriodFrom <DateTime>] [-RecurrencePeriodTo <DateTime>]
 [-ScheduleRecurrence <RecurrenceType>] [-ScheduleStatus <StatusType>] [-TimePeriodFrom <DateTime>]
 [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a export.
Update operation requires latest eTag to be set in the request.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

## EXAMPLES

### Example 1: Update a cost management export by name
```powershell
PS C:\> Update-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name exportinfo-ps-t -RecurrencePeriodFrom (Get-Date).ToString()

```

This command updates a cost management export by name.

### Example 2: Update a cost management export by object
```powershell
PS C:\> $export = Get-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name exportinfo-ps-t
PS C:\> Update-AzCostManagementExport -InputObject $export -RecurrencePeriodFrom (Get-Date).ToString()

{{ Add output here }}
```

This command updates a cost management export by object.

## PARAMETERS

### -ConfigurationColumn
Array of column names to be included in the query.
Any valid query column name is allowed.
If not provided, then query includes all columns.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasetAggregation
Dictionary of aggregation expression to use in the query.
The key of each item in the dictionary is the alias for the aggregated column.
Query can have up to 2 aggregation clauses.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasetFilter
Has filter expression to use in the query.
To construct, see NOTES section for DATASETFILTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20191101.IQueryFilter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasetGranularity
The granularity of rows in the query.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.GranularityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasetGrouping
Array of group by expression to use in the query.
Query can have up to 2 group by clauses.
To construct, see NOTES section for DATASETGROUPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20191101.IQueryGrouping[]
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

### -DefinitionTimeframe
The time frame for pulling data for the query.
If custom, then a specific time period must be provided.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.TimeframeType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefinitionType
The type of the query.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.ExportType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationContainer
The name of the container where exports will be uploaded.

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

### -DestinationResourceId
The resource id of the storage account where exports will be delivered.

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

### -DestinationRootFolderPath
The name of the directory where exports will be uploaded.

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

### -Format
The format of the export being delivered.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.FormatType
Parameter Sets: (All)
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.ICostIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Export Name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ExportName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecurrencePeriodFrom
The start date of recurrence.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecurrencePeriodTo
The end date of recurrence.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleRecurrence
The schedule recurrence.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.RecurrenceType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleStatus
The status of the schedule.
Whether active or not.
If inactive, the export's scheduled execution is paused.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.StatusType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope associated with query and export operations.
This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, '/providers/Microsoft.Management/managementGroups/{managementGroupId} for Management Group scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.

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

### -TimePeriodFrom
The start date to pull data from.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimePeriodTo
The end date to pull data to.

```yaml
Type: System.DateTime
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

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.ICostIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20191101.IExport

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DATASETFILTER <IQueryFilter>: Has filter expression to use in the query.
  - `[And <IQueryFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
  - `[Dimension <IQueryComparisonExpression>]`: Has comparison expression for a dimension
    - `Name <String>`: The name of the column to use in comparison.
    - `Operator <OperatorType>`: The operator to use for comparison.
    - `Value <String[]>`: Array of values to use for comparison
  - `[Not <IQueryFilter>]`: The logical "NOT" expression.
  - `[Or <IQueryFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
  - `[Tag <IQueryComparisonExpression>]`: Has comparison expression for a tag

DATASETGROUPING <IQueryGrouping[]>: Array of group by expression to use in the query. Query can have up to 2 group by clauses.
  - `Name <String>`: The name of the column to group.
  - `Type <QueryColumnType>`: Has type of the column to group.

INPUTOBJECT <ICostIdentity>: Identity Parameter
  - `[AlertId <String>]`: Alert ID
  - `[ExportName <String>]`: Export Name.
  - `[ExternalCloudProviderId <String>]`: This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.
  - `[ExternalCloudProviderType <ExternalCloudProviderType?>]`: The external cloud provider type associated with dimension/query operations. This includes 'externalSubscriptions' for linked account and 'externalBillingAccounts' for consolidated account.
  - `[Id <String>]`: Resource identity path
  - `[Scope <String>]`: The scope associated with view operations. This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, 'providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for External Billing Account scope and 'providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for External Subscription scope.
  - `[ViewName <String>]`: View name

## RELATED LINKS

