---
external help file:
Module Name: Az.Cost
online version: https://docs.microsoft.com/en-us/powershell/module/az.cost/invoke-azcostmanagementusagequery
schema: 2.0.0
---

# Invoke-AzCostManagementUsageQuery

## SYNOPSIS
Query the usage data for scope defined.

## SYNTAX

### UsageExpanded (Default)
```
Invoke-AzCostManagementUsageQuery -Scope <String> -Timeframe <TimeframeType> -Type <ExportType>
 [-ConfigurationColumn <String[]>] [-DatasetAggregation <Hashtable>] [-DatasetFilter <IQueryFilter>]
 [-DatasetGranularity <GranularityType>] [-DatasetGrouping <IQueryGrouping[]>] [-TimePeriodFrom <DateTime>]
 [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UsageExpanded1
```
Invoke-AzCostManagementUsageQuery -ExternalCloudProviderId <String>
 -ExternalCloudProviderType <ExternalCloudProviderType> -Timeframe <TimeframeType> -Type <ExportType>
 [-ConfigurationColumn <String[]>] [-DatasetAggregation <Hashtable>] [-DatasetFilter <IQueryFilter>]
 [-DatasetGranularity <GranularityType>] [-DatasetGrouping <IQueryGrouping[]>] [-TimePeriodFrom <DateTime>]
 [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UsageViaIdentityExpanded
```
Invoke-AzCostManagementUsageQuery -InputObject <ICostIdentity> -Timeframe <TimeframeType> -Type <ExportType>
 [-ConfigurationColumn <String[]>] [-DatasetAggregation <Hashtable>] [-DatasetFilter <IQueryFilter>]
 [-DatasetGranularity <GranularityType>] [-DatasetGrouping <IQueryGrouping[]>] [-TimePeriodFrom <DateTime>]
 [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UsageViaIdentityExpanded1
```
Invoke-AzCostManagementUsageQuery -InputObject <ICostIdentity> -Timeframe <TimeframeType> -Type <ExportType>
 [-ConfigurationColumn <String[]>] [-DatasetAggregation <Hashtable>] [-DatasetFilter <IQueryFilter>]
 [-DatasetGranularity <GranularityType>] [-DatasetGrouping <IQueryGrouping[]>] [-TimePeriodFrom <DateTime>]
 [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Query the usage data for scope defined.

## EXAMPLES

### Example 1: Invoke query usage of the cost management export 
```powershell
PS C:\> Invoke-AzCostManagementUsageQuery -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Timeframe MonthToDate -Type Usage  -DatasetGranularity 'daily'

NextLink Column                Row
-------- ------                ---
         {UsageDate, Currency} {20200701 USD, 20200702 USD, 20200703 USD, 20200704 USD…}
```

this command invokes query usage of the cost management export.

## PARAMETERS

### -ConfigurationColumn
Array of column names to be included in the query.

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

### -ExternalCloudProviderId
This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.

```yaml
Type: System.String
Parameter Sets: UsageExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalCloudProviderType
The external cloud provider type associated with dimension/query operations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.ExternalCloudProviderType
Parameter Sets: UsageExpanded1
Aliases:

Required: True
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
Parameter Sets: UsageViaIdentityExpanded, UsageViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Scope
The scope associated with query and export operations.

```yaml
Type: System.String
Parameter Sets: UsageExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timeframe
The time frame for pulling data for the query.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.TimeframeType
Parameter Sets: (All)
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

### -Type
The type of the query.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.ExportType
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.ICostIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20191101.IQueryResult

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

DATASETGROUPING <IQueryGrouping[]>: Array of group by expression to use in the query.
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

