---
external help file:
Module Name: Az.Cost
online version: https://docs.microsoft.com/en-us/powershell/module/az.cost/invoke-azcostusagequery
schema: 2.0.0
---

# Invoke-AzCostUsageQuery

## SYNOPSIS
Query the usage data for scope defined.

## SYNTAX

### UsageExpanded (Default)
```
Invoke-AzCostUsageQuery -Scope <String> -Timeframe <TimeframeType> -Type <ExportType>
 [-ConfigurationColumn <String[]>] [-DatasetAggregation <Hashtable>] [-DatasetGranularity <GranularityType>]
 [-DatasetGrouping <IQueryGrouping[]>] [-DimensionName <String>] [-DimensionValue <String[]>]
 [-FilterAnd <IQueryFilter[]>] [-FilterOr <IQueryFilter[]>] [-TagName <String>] [-TagValue <String[]>]
 [-TimePeriodFrom <DateTime>] [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Usage
```
Invoke-AzCostUsageQuery -Scope <String> -Parameter <IQueryDefinition> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Usage1
```
Invoke-AzCostUsageQuery -ExternalCloudProviderId <String>
 -ExternalCloudProviderType <ExternalCloudProviderType> -Parameter <IQueryDefinition>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UsageExpanded1
```
Invoke-AzCostUsageQuery -ExternalCloudProviderId <String>
 -ExternalCloudProviderType <ExternalCloudProviderType> -Timeframe <TimeframeType> -Type <ExportType>
 [-ConfigurationColumn <String[]>] [-DatasetAggregation <Hashtable>] [-DatasetGranularity <GranularityType>]
 [-DatasetGrouping <IQueryGrouping[]>] [-DimensionName <String>] [-DimensionValue <String[]>]
 [-FilterAnd <IQueryFilter[]>] [-FilterOr <IQueryFilter[]>] [-TagName <String>] [-TagValue <String[]>]
 [-TimePeriodFrom <DateTime>] [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UsageViaIdentity
```
Invoke-AzCostUsageQuery -InputObject <ICostIdentity> -Parameter <IQueryDefinition>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UsageViaIdentity1
```
Invoke-AzCostUsageQuery -InputObject <ICostIdentity> -Parameter <IQueryDefinition>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UsageViaIdentityExpanded
```
Invoke-AzCostUsageQuery -InputObject <ICostIdentity> -Timeframe <TimeframeType> -Type <ExportType>
 [-ConfigurationColumn <String[]>] [-DatasetAggregation <Hashtable>] [-DatasetGranularity <GranularityType>]
 [-DatasetGrouping <IQueryGrouping[]>] [-DimensionName <String>] [-DimensionValue <String[]>]
 [-FilterAnd <IQueryFilter[]>] [-FilterOr <IQueryFilter[]>] [-TagName <String>] [-TagValue <String[]>]
 [-TimePeriodFrom <DateTime>] [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UsageViaIdentityExpanded1
```
Invoke-AzCostUsageQuery -InputObject <ICostIdentity> -Timeframe <TimeframeType> -Type <ExportType>
 [-ConfigurationColumn <String[]>] [-DatasetAggregation <Hashtable>] [-DatasetGranularity <GranularityType>]
 [-DatasetGrouping <IQueryGrouping[]>] [-DimensionName <String>] [-DimensionValue <String[]>]
 [-FilterAnd <IQueryFilter[]>] [-FilterOr <IQueryFilter[]>] [-TagName <String>] [-TagValue <String[]>]
 [-TimePeriodFrom <DateTime>] [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Query the usage data for scope defined.

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

### -ConfigurationColumn
Array of column names to be included in the query.
Any valid query column name is allowed.
If not provided, then query includes all columns.

```yaml
Type: System.String[]
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
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
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
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
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IQueryGrouping[]
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
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

### -DimensionName
The name of the column to use in comparison.

```yaml
Type: System.String
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DimensionValue
Array of values to use for comparison

```yaml
Type: System.String[]
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalCloudProviderId
This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.

```yaml
Type: System.String
Parameter Sets: Usage1, UsageExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalCloudProviderType
The external cloud provider type associated with dimension/query operations.
This includes 'externalSubscriptions' for linked account and 'externalBillingAccounts' for consolidated account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.ExternalCloudProviderType
Parameter Sets: Usage1, UsageExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterAnd
The logical "AND" expression.
Must have at least 2 items.
To construct, see NOTES section for FILTERAND properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IQueryFilter[]
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterOr
The logical "OR" expression.
Must have at least 2 items.
To construct, see NOTES section for FILTEROR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IQueryFilter[]
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
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
Parameter Sets: UsageViaIdentity, UsageViaIdentity1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
The definition of a query.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IQueryDefinition
Parameter Sets: Usage, Usage1, UsageViaIdentity, UsageViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Usage, UsageExpanded, UsageViaIdentity, UsageViaIdentityExpanded
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
Parameter Sets: Usage, UsageExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TagName
The name of the column to use in comparison.

```yaml
Type: System.String
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TagValue
Array of values to use for comparison

```yaml
Type: System.String[]
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timeframe
The time frame for pulling data for the query.
If custom, then a specific time period must be provided.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.TimeframeType
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
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
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
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
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of the query.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.ExportType
Parameter Sets: UsageExpanded, UsageExpanded1, UsageViaIdentityExpanded, UsageViaIdentityExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IQueryDefinition

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.ICostIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IQueryResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DATASETGROUPING <IQueryGrouping[]>: Array of group by expression to use in the query. Query can have up to 2 group by clauses.
  - `Name <String>`: The name of the column to group.
  - `Type <QueryColumnType>`: Has type of the column to group.

FILTERAND <IQueryFilter[]>: The logical "AND" expression. Must have at least 2 items.
  - `[And <IQueryFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
  - `[DimensionName <String>]`: The name of the column to use in comparison.
  - `[DimensionValue <String[]>]`: Array of values to use for comparison
  - `[Or <IQueryFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
  - `[TagName <String>]`: The name of the column to use in comparison.
  - `[TagValue <String[]>]`: Array of values to use for comparison

FILTEROR <IQueryFilter[]>: The logical "OR" expression. Must have at least 2 items.
  - `[And <IQueryFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
  - `[DimensionName <String>]`: The name of the column to use in comparison.
  - `[DimensionValue <String[]>]`: Array of values to use for comparison
  - `[Or <IQueryFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
  - `[TagName <String>]`: The name of the column to use in comparison.
  - `[TagValue <String[]>]`: Array of values to use for comparison

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

PARAMETER <IQueryDefinition>: The definition of a query.
  - `Timeframe <TimeframeType>`: The time frame for pulling data for the query. If custom, then a specific time period must be provided.
  - `Type <ExportType>`: The type of the query.
  - `[ConfigurationColumn <String[]>]`: Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query includes all columns.
  - `[DatasetAggregation <IQueryDatasetAggregation>]`: Dictionary of aggregation expression to use in the query. The key of each item in the dictionary is the alias for the aggregated column. Query can have up to 2 aggregation clauses.
    - `[(Any) <IQueryAggregation>]`: This indicates any property can be added to this object.
  - `[DatasetGranularity <GranularityType?>]`: The granularity of rows in the query.
  - `[DatasetGrouping <IQueryGrouping[]>]`: Array of group by expression to use in the query. Query can have up to 2 group by clauses.
    - `Name <String>`: The name of the column to group.
    - `Type <QueryColumnType>`: Has type of the column to group.
  - `[DimensionName <String>]`: The name of the column to use in comparison.
  - `[DimensionValue <String[]>]`: Array of values to use for comparison
  - `[FilterAnd <IQueryFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
    - `[And <IQueryFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
    - `[DimensionName <String>]`: The name of the column to use in comparison.
    - `[DimensionValue <String[]>]`: Array of values to use for comparison
    - `[Or <IQueryFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
    - `[TagName <String>]`: The name of the column to use in comparison.
    - `[TagValue <String[]>]`: Array of values to use for comparison
  - `[FilterOr <IQueryFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
  - `[TagName <String>]`: The name of the column to use in comparison.
  - `[TagValue <String[]>]`: Array of values to use for comparison
  - `[TimePeriodFrom <DateTime?>]`: The start date to pull data from.
  - `[TimePeriodTo <DateTime?>]`: The end date to pull data to.

## RELATED LINKS

