---
external help file: Az.CostManagement-help.xml
Module Name: Az.CostManagement
online version: https://learn.microsoft.com/powershell/module/az.costmanagement/invoke-azcostmanagementquery
schema: 2.0.0
---

# Invoke-AzCostManagementQuery

## SYNOPSIS
Query the usage data for scope defined.

## SYNTAX

### UsageExpanded (Default)
```
Invoke-AzCostManagementQuery -Scope <String> -Timeframe <TimeframeType> -Type <ExportType>
 [-ConfigurationColumn <String[]>] [-DatasetAggregation <Hashtable>] [-DatasetFilter <IQueryFilter>]
 [-DatasetGranularity <GranularityType>] [-DatasetGrouping <IQueryGrouping[]>] [-TimePeriodFrom <DateTime>]
 [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UsageExpanded1
```
Invoke-AzCostManagementQuery -ExternalCloudProviderId <String>
 -ExternalCloudProviderType <ExternalCloudProviderType> -Timeframe <TimeframeType> -Type <ExportType>
 [-ConfigurationColumn <String[]>] [-DatasetAggregation <Hashtable>] [-DatasetFilter <IQueryFilter>]
 [-DatasetGranularity <GranularityType>] [-DatasetGrouping <IQueryGrouping[]>] [-TimePeriodFrom <DateTime>]
 [-TimePeriodTo <DateTime>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Query the usage data for scope defined.

## EXAMPLES

### Example 1: Invoke AzCostManagementQuery by Scope
```powershell
Invoke-AzCostManagementQuery -Scope "/subscriptions/***********" -Timeframe MonthToDate -Type Usage -DatasetGranularity 'Daily'
```

```output
Column                Row
------                ---
{UsageDate, Currency} {20201101 USD, 20201102 USD, 20201103 USD, 20201104 USD…}
```

Invoke AzCostManagementQuery by Scope

### Example 2: Invoke AzCostManagementQuery by Scope with Dimensions
```powershell
$dimensions = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceGroup' -Value 'API'
$filter = New-AzCostManagementQueryFilterObject -Dimensions $dimensions
Invoke-AzCostManagementQuery -Type Usage -Scope "subscriptions/***********" -DatasetGranularity 'Monthly' -DatasetFilter $filter -Timeframe MonthToDate -Debug
```

```output
Column                   Row
------                   ---
{BillingMonth, Currency} {}
```

Invoke AzCostManagementQuery by Scope with Dimensions

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
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryFilter
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
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryGrouping[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExternalCloudProviderType
Parameter Sets: UsageExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
This includes 'subscriptions/{subscriptionId}/' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope and 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId} for Management Group scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryResult

## NOTES

## RELATED LINKS
