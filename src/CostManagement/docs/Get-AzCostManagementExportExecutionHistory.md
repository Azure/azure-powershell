---
external help file:
Module Name: Az.Cost
online version: https://docs.microsoft.com/en-us/powershell/module/az.cost/get-azcostmanagementexportexecutionhistory
schema: 2.0.0
---

# Get-AzCostManagementExportExecutionHistory

## SYNOPSIS
The operation to get the execution history of an export for the defined scope by export name.

## SYNTAX

### Get (Default)
```
Get-AzCostManagementExportExecutionHistory -ExportName <String> -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCostManagementExportExecutionHistory -InputObject <ICostIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to get the execution history of an export for the defined scope by export name.

## EXAMPLES

### Example 1: Get execution history of cost management export
```powershell
PS C:\> Get-AzCostManagementExportExecutionHistory -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -ExportName "ps-customcolum-t"

ExecutionType ProcessingStartTime   ProcessingEndTime     Status    FileName
------------- -------------------   -----------------     ------    --------
OnDemand      6/29/2020 6:03:26 AM  6/29/2020 6:04:28 AM  Completed ad-hoc/ps-customcolum-t/20200601-20200630/ps-customcolum-t_041c4d56-f25e-4e37-99fb-ab201309e07f.csv
Scheduled     6/30/2020 12:02:53 PM 6/30/2020 12:03:34 PM Completed ad-hoc/ps-customcolum-t/20200601-20200630/ps-customcolum-t_cd5bd8b1-014f-4521-b20a-69168288263d.csv
```

This command gets execution history of cost management export.

### Example 2: Get execution history of cost management export by object
```powershell
PS C:\> $export = Get-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -ExportName "ps-customcolum-t"
PS C:\> $export | Get-AzCostManagementExportExecutionHistory -InputObject $export

ExecutionType ProcessingStartTime   ProcessingEndTime     Status    FileName
------------- -------------------   -----------------     ------    --------
OnDemand      6/29/2020 6:03:26 AM  6/29/2020 6:04:28 AM  Completed ad-hoc/ps-customcolum-t/20200601-20200630/ps-customcolum-t_041c4d56-f25e-4e37-99fb-ab201309e07f.csv
Scheduled     6/30/2020 12:02:53 PM 6/30/2020 12:03:34 PM Completed ad-hoc/ps-customcolum-t/20200601-20200630/ps-customcolum-t_cd5bd8b1-014f-4521-b20a-69168288263d.csv
```

This command gets execution history of cost management export by object.

## PARAMETERS

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

### -ExportName
Export Name.

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Scope
The scope associated with query and export operations.
This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, '/providers/Microsoft.Management/managementGroups/{managementGroupId} for Management Group scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20191101.IExportExecution

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ICostIdentity>: Identity Parameter
  - `[AlertId <String>]`: Alert ID
  - `[ExportName <String>]`: Export Name.
  - `[ExternalCloudProviderId <String>]`: This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.
  - `[ExternalCloudProviderType <ExternalCloudProviderType?>]`: The external cloud provider type associated with dimension/query operations. This includes 'externalSubscriptions' for linked account and 'externalBillingAccounts' for consolidated account.
  - `[Id <String>]`: Resource identity path
  - `[Scope <String>]`: The scope associated with view operations. This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, 'providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for External Billing Account scope and 'providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for External Subscription scope.
  - `[ViewName <String>]`: View name

## RELATED LINKS

