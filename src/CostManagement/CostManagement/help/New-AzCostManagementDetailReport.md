---
external help file: Az.CostManagement-help.xml
Module Name: Az.CostManagement
online version: https://learn.microsoft.com/powershell/module/az.costmanagement/new-azcostmanagementdetailreport
schema: 2.0.0
---

# New-AzCostManagementDetailReport

## SYNOPSIS
This API is the replacement for all previously release Usage Details APIs.
Request to generate a cost details report for the provided date range, billing period (Only enterprise customers) or Invoice Id asynchronously at a certain scope.
The initial call to request a report will return a 202 with a 'Location' and 'Retry-After' header.
The 'Location' header will provide the endpoint to poll to get the result of the report generation.
The 'Retry-After' provides the duration to wait before polling for the generated report.
A call to poll the report operation will provide a 202 response with a 'Location' header if the operation is still in progress.
Once the report generation operation completes, the polling endpoint will provide a 200 response along with details on the report blob(s) that are available for download.
The details on the file(s) available for download will be available in the polling response body.

## SYNTAX

```
New-AzCostManagementDetailReport -Scope <String> [-BillingPeriod <String>] [-InvoiceId <String>]
 [-Metric <CostDetailsMetricType>] [-TimePeriodEnd <String>] [-TimePeriodStart <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This API is the replacement for all previously release Usage Details APIs.
Request to generate a cost details report for the provided date range, billing period (Only enterprise customers) or Invoice Id asynchronously at a certain scope.
The initial call to request a report will return a 202 with a 'Location' and 'Retry-After' header.
The 'Location' header will provide the endpoint to poll to get the result of the report generation.
The 'Retry-After' provides the duration to wait before polling for the generated report.
A call to poll the report operation will provide a 202 response with a 'Location' header if the operation is still in progress.
Once the report generation operation completes, the polling endpoint will provide a 200 response along with details on the report blob(s) that are available for download.
The details on the file(s) available for download will be available in the polling response body.

## EXAMPLES

### Example 1: Request to generate a cost details report for the provided date range, billing period (Only enterprise customers) or Invoice Id asynchronously at a certain scope
```powershell
New-AzCostManagementDetailReport -Scope "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Metric 'ActualCost' -TimePeriodStart "2022-10-01" -TimePeriodEnd "2022-10-20"
```

This command requests to generate a cost details report for the provided date range, billing period (Only enterprise customers) or Invoice Id asynchronously at a certain scope.

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

### -BillingPeriod
This parameter can be used only by Enterprise Agreement customers.
Use the YearMonth(e.g.
202008) format.
This parameter cannot be used alongside either the invoiceId or timePeriod parameters.
If a timePeriod, invoiceId or billingPeriod parameter is not provided in the request body the API will return the current month's cost.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InvoiceId
This parameter can only be used by Microsoft Customer Agreement customers.
Additionally, it can only be used at the Billing Profile or Customer scope.
This parameter cannot be used alongside either the billingPeriod or timePeriod parameters.
If a timePeriod, invoiceId or billingPeriod parameter is not provided in the request body the API will return the current month's cost.

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

### -Metric
The type of the detailed report.
By default ActualCost is provided

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.CostDetailsMetricType
Parameter Sets: (All)
Aliases:

Required: False
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
The scope associated with usage details operations.
This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, '/providers/Microsoft.Billing/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope.
Also, Modern Commerce Account scopes are '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for billingAccount scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimePeriodEnd
The end date to pull data to.
example format 2020-03-15

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

### -TimePeriodStart
The start date to pull data from.
example format 2020-03-15

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

### Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20220501.ICostDetailsOperationResults

## NOTES

## RELATED LINKS
