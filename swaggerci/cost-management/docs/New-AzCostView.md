---
external help file:
Module Name: Az.Cost
online version: https://docs.microsoft.com/en-us/powershell/module/az.cost/new-azcostview
schema: 2.0.0
---

# New-AzCostView

## SYNOPSIS
The operation to create or update a view.
Update operation requires latest eTag to be set in the request.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

## SYNTAX

### CreateExpanded (Default)
```
New-AzCostView -Name <String> [-Scope <String>] [-Accumulated <AccumulatedType>] [-Chart <ChartType>]
 [-DisplayName <String>] [-ETag <String>] [-Kpi <IKpiProperties[]>] [-Metric <MetricType>]
 [-Pivot <IPivotProperties[]>] [-Query <IReportConfigDefinition>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create1
```
New-AzCostView -Name <String> -Scope <String> -Parameter <IView> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzCostView -Name <String> -Scope <String> [-Accumulated <AccumulatedType>] [-Chart <ChartType>]
 [-DisplayName <String>] [-ETag <String>] [-Kpi <IKpiProperties[]>] [-Metric <MetricType>]
 [-Pivot <IPivotProperties[]>] [-PropertiesScope <String>] [-Query <IReportConfigDefinition>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity1
```
New-AzCostView -InputObject <ICostIdentity> -Parameter <IView> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzCostView -InputObject <ICostIdentity> [-Scope <String>] [-Accumulated <AccumulatedType>]
 [-Chart <ChartType>] [-DisplayName <String>] [-ETag <String>] [-Kpi <IKpiProperties[]>]
 [-Metric <MetricType>] [-Pivot <IPivotProperties[]>] [-Query <IReportConfigDefinition>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a view.
Update operation requires latest eTag to be set in the request.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Accumulated
Show costs accumulated over time.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.AccumulatedType
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Chart
Chart type of the main view in Cost Analysis.
Required.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.ChartType
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
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

### -DisplayName
User input name of the view.
Required.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ETag
eTag of the resource.
To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
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
Parameter Sets: CreateViaIdentity1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kpi
List of KPIs to show in Cost Analysis UI.
To construct, see NOTES section for KPI properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IKpiProperties[]
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metric
Metric to use when displaying costs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.MetricType
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
View name

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded, CreateExpanded1
Aliases: ViewName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
States and configurations of Cost Analysis.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IView
Parameter Sets: Create1, CreateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Pivot
Configuration of 3 sub-views in the Cost Analysis UI.
To construct, see NOTES section for PIVOT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IPivotProperties[]
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesScope
Cost Management scope to save the view on.
This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, '/providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for ExternalBillingAccount scope, and '/providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for ExternalSubscription scope.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Query
Query body configuration.
Required.
To construct, see NOTES section for QUERY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IReportConfigDefinition
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope associated with view operations.
This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, 'providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for External Billing Account scope and 'providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for External Subscription scope.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IView

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.ICostIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IView

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ICostIdentity>: Identity Parameter
  - `[AlertId <String>]`: Alert ID
  - `[BillingAccountId <String>]`: Enrollment ID (Legacy BillingAccount ID)
  - `[BillingProfileId <String>]`: BillingProfile ID
  - `[ExportName <String>]`: Export Name.
  - `[ExternalCloudProviderId <String>]`: This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.
  - `[ExternalCloudProviderType <ExternalCloudProviderType?>]`: The external cloud provider type associated with dimension/query operations. This includes 'externalSubscriptions' for linked account and 'externalBillingAccounts' for consolidated account.
  - `[Id <String>]`: Resource identity path
  - `[OperationId <String>]`: The target operation Id.
  - `[Scope <String>]`: The scope associated with export operations. This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, '/providers/Microsoft.Management/managementGroups/{managementGroupId} for Management Group scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.
  - `[ViewName <String>]`: View name

KPI <IKpiProperties[]>: List of KPIs to show in Cost Analysis UI.
  - `[Enabled <Boolean?>]`: show the KPI in the UI?
  - `[Id <String>]`: ID of resource related to metric (budget).
  - `[Type <KpiType?>]`: KPI type (Forecast, Budget).

PARAMETER <IView>: States and configurations of Cost Analysis.
  - `[ETag <String>]`: eTag of the resource. To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not.
  - `[Accumulated <AccumulatedType?>]`: Show costs accumulated over time.
  - `[Chart <ChartType?>]`: Chart type of the main view in Cost Analysis. Required.
  - `[DisplayName <String>]`: User input name of the view. Required.
  - `[Kpi <IKpiProperties[]>]`: List of KPIs to show in Cost Analysis UI.
    - `[Enabled <Boolean?>]`: show the KPI in the UI?
    - `[Id <String>]`: ID of resource related to metric (budget).
    - `[Type <KpiType?>]`: KPI type (Forecast, Budget).
  - `[Metric <MetricType?>]`: Metric to use when displaying costs.
  - `[Pivot <IPivotProperties[]>]`: Configuration of 3 sub-views in the Cost Analysis UI.
    - `[Name <String>]`: Data field to show in view.
    - `[Type <PivotType?>]`: Data type to show in view.
  - `[Query <IReportConfigDefinition>]`: Query body configuration. Required.
    - `Timeframe <ReportTimeframeType>`: The time frame for pulling data for the report. If custom, then a specific time period must be provided.
    - `[ConfigurationColumn <String[]>]`: Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report includes all columns.
    - `[DataSetAggregation <IReportConfigDatasetAggregation>]`: Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the aggregated column. Report can have up to 2 aggregation clauses.
      - `[(Any) <IReportConfigAggregation>]`: This indicates any property can be added to this object.
    - `[DataSetGranularity <ReportGranularityType?>]`: The granularity of rows in the report.
    - `[DataSetGrouping <IReportConfigGrouping[]>]`: Array of group by expression to use in the report. Report can have up to 2 group by clauses.
      - `Name <String>`: The name of the column to group. This version supports subscription lowest possible grain.
      - `Type <ReportConfigColumnType>`: Has type of the column to group.
    - `[DataSetSorting <IReportConfigSorting[]>]`: Array of order by expression to use in the report.
      - `Name <String>`: The name of the column to sort.
      - `[Direction <ReportConfigSortingType?>]`: Direction of sort.
    - `[DimensionName <String>]`: The name of the column to use in comparison.
    - `[DimensionOperator <OperatorType?>]`: The operator to use for comparison.
    - `[DimensionValue <String[]>]`: Array of values to use for comparison
    - `[FilterAnd <IReportConfigFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
      - `[And <IReportConfigFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
      - `[DimensionName <String>]`: The name of the column to use in comparison.
      - `[DimensionOperator <OperatorType?>]`: The operator to use for comparison.
      - `[DimensionValue <String[]>]`: Array of values to use for comparison
      - `[Or <IReportConfigFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
      - `[TagName <String>]`: The name of the column to use in comparison.
      - `[TagOperator <OperatorType?>]`: The operator to use for comparison.
      - `[TagValue <String[]>]`: Array of values to use for comparison
    - `[FilterOr <IReportConfigFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
    - `[IncludeMonetaryCommitment <Boolean?>]`: If true, report includes monetary commitment.
    - `[TagName <String>]`: The name of the column to use in comparison.
    - `[TagOperator <OperatorType?>]`: The operator to use for comparison.
    - `[TagValue <String[]>]`: Array of values to use for comparison
    - `[TimePeriodFrom <DateTime?>]`: The start date to pull data from.
    - `[TimePeriodTo <DateTime?>]`: The end date to pull data to.
  - `[Scope <String>]`: Cost Management scope to save the view on. This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, '/providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for ExternalBillingAccount scope, and '/providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for ExternalSubscription scope.

PIVOT <IPivotProperties[]>: Configuration of 3 sub-views in the Cost Analysis UI.
  - `[Name <String>]`: Data field to show in view.
  - `[Type <PivotType?>]`: Data type to show in view.

QUERY <IReportConfigDefinition>: Query body configuration. Required.
  - `Timeframe <ReportTimeframeType>`: The time frame for pulling data for the report. If custom, then a specific time period must be provided.
  - `[ConfigurationColumn <String[]>]`: Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report includes all columns.
  - `[DataSetAggregation <IReportConfigDatasetAggregation>]`: Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the aggregated column. Report can have up to 2 aggregation clauses.
    - `[(Any) <IReportConfigAggregation>]`: This indicates any property can be added to this object.
  - `[DataSetGranularity <ReportGranularityType?>]`: The granularity of rows in the report.
  - `[DataSetGrouping <IReportConfigGrouping[]>]`: Array of group by expression to use in the report. Report can have up to 2 group by clauses.
    - `Name <String>`: The name of the column to group. This version supports subscription lowest possible grain.
    - `Type <ReportConfigColumnType>`: Has type of the column to group.
  - `[DataSetSorting <IReportConfigSorting[]>]`: Array of order by expression to use in the report.
    - `Name <String>`: The name of the column to sort.
    - `[Direction <ReportConfigSortingType?>]`: Direction of sort.
  - `[DimensionName <String>]`: The name of the column to use in comparison.
  - `[DimensionOperator <OperatorType?>]`: The operator to use for comparison.
  - `[DimensionValue <String[]>]`: Array of values to use for comparison
  - `[FilterAnd <IReportConfigFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
    - `[And <IReportConfigFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
    - `[DimensionName <String>]`: The name of the column to use in comparison.
    - `[DimensionOperator <OperatorType?>]`: The operator to use for comparison.
    - `[DimensionValue <String[]>]`: Array of values to use for comparison
    - `[Or <IReportConfigFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
    - `[TagName <String>]`: The name of the column to use in comparison.
    - `[TagOperator <OperatorType?>]`: The operator to use for comparison.
    - `[TagValue <String[]>]`: Array of values to use for comparison
  - `[FilterOr <IReportConfigFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
  - `[IncludeMonetaryCommitment <Boolean?>]`: If true, report includes monetary commitment.
  - `[TagName <String>]`: The name of the column to use in comparison.
  - `[TagOperator <OperatorType?>]`: The operator to use for comparison.
  - `[TagValue <String[]>]`: Array of values to use for comparison
  - `[TimePeriodFrom <DateTime?>]`: The start date to pull data from.
  - `[TimePeriodTo <DateTime?>]`: The end date to pull data to.

## RELATED LINKS

