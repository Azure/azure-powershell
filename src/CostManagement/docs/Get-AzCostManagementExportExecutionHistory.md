---
external help file:
Module Name: Az.CostManagement
online version: https://docs.microsoft.com/en-us/powershell/module/az.costmanagement/get-azcostmanagementexportexecutionhistory
schema: 2.0.0
---

# Get-AzCostManagementExportExecutionHistory

## SYNOPSIS
The operation to get the execution history of an export for the defined scope and export name.

## SYNTAX

### Get (Default)
```
Get-AzCostManagementExportExecutionHistory -ExportName <String> -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCostManagementExportExecutionHistory -InputObject <ICostManagementIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to get the execution history of an export for the defined scope and export name.

## EXAMPLES

### Example 1: Get AzCostManagementExportExecutionHistory
```powershell
PS C:\> Get-AzCostManagementExportExecutionHistory -ExportName 'TestExport' -Scope 'subscriptions/**********'

ExecutionType ProcessingStartTime ProcessingEndTime  Status    FileName
------------- ------------------- -----------------  ------    --------
Scheduled     2020/6/11 12:03:20  2020/6/11 12:03:43 Completed ad-hoc/TestExport/20200601-20200630/TestExport_e02f95ad-584b-4b83-ba9d-41d398e855af.csv
Scheduled     2020/6/12 12:03:37  2020/6/12 12:03:48 Completed ad-hoc/TestExport/20200601-20200630/TestExport_fc41d48d-ef47-4e38-aa1e-323e286c6fcf.csv
Scheduled     2020/6/13 12:02:33  2020/6/13 12:26:33 Failed    ad-hoc/TestExport/20200601-20200630/TestExport_076501ee-bf16-424b-807e-ca5c6c23293b.csv
Scheduled     2020/6/14 12:27:28  2020/6/14 12:27:50 Completed ad-hoc/TestExport/20200601-20200630/TestExport_145cb0fa-c808-4a6b-b8bb-14a11d78a0dc.csv
Scheduled     2020/6/15 12:02:34  2020/6/15 12:02:45 Completed ad-hoc/TestExport/20200601-20200630/TestExport_7d6422d0-7a46-4a89-9556-4f616941e8ae.csv
Scheduled     2020/6/16 12:07:31  2020/6/16 12:07:43 Completed ad-hoc/TestExport/20200601-20200630/TestExport_f5c68909-63bc-4278-bfa5-2fbe008d78fe.csv
Scheduled     2020/6/17 12:03:56  2020/6/17 12:04:17 Completed ad-hoc/TestExport/20200601-20200630/TestExport_eda8f8fa-7cca-4110-8cba-e64d9f1e4b10.csv
```

Get AzCostManagementExportExecutionHistory By ExportName and Scope

### Example 2: Get AzCostManagementExportExecutionHistory by InputObject
```powershell
PS C:\> $getExport = Get-AzCostManagementExport -Name 'TestExport' -Scope 'subscriptions/**********'
Get-AzCostManagementExportExecutionHistory -InputObject $getExport

ExecutionType ProcessingStartTime ProcessingEndTime  Status    FileName
------------- ------------------- -----------------  ------    --------
Scheduled     2020/6/11 12:03:20  2020/6/11 12:03:43 Completed ad-hoc/TestExport/20200601-20200630/TestExport_e02f95ad-584b-4b83-ba9d-41d398e855af.csv
Scheduled     2020/6/12 12:03:37  2020/6/12 12:03:48 Completed ad-hoc/TestExport/20200601-20200630/TestExport_fc41d48d-ef47-4e38-aa1e-323e286c6fcf.csv
Scheduled     2020/6/13 12:02:33  2020/6/13 12:26:33 Failed    ad-hoc/TestExport/20200601-20200630/TestExport_076501ee-bf16-424b-807e-ca5c6c23293b.csv
Scheduled     2020/6/14 12:27:28  2020/6/14 12:27:50 Completed ad-hoc/TestExport/20200601-20200630/TestExport_145cb0fa-c808-4a6b-b8bb-14a11d78a0dc.csv
Scheduled     2020/6/15 12:02:34  2020/6/15 12:02:45 Completed ad-hoc/TestExport/20200601-20200630/TestExport_7d6422d0-7a46-4a89-9556-4f616941e8ae.csv
Scheduled     2020/6/16 12:07:31  2020/6/16 12:07:43 Completed ad-hoc/TestExport/20200601-20200630/TestExport_f5c68909-63bc-4278-bfa5-2fbe008d78fe.csv
Scheduled     2020/6/17 12:03:56  2020/6/17 12:04:17 Completed ad-hoc/TestExport/20200601-20200630/TestExport_eda8f8fa-7cca-4110-8cba-e64d9f1e4b10.csv
```

Get AzCostManagementExportExecutionHistory By InputObject

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
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.ICostManagementIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Scope
This parameter defines the scope of costmanagement from different perspectives 'Subscription','ResourceGroup' and 'Provide Service'.

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

### Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.ICostManagementIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ICostManagementIdentity>: Identity Parameter
  - `[AlertId <String>]`: Alert ID
  - `[ExportName <String>]`: Export Name.
  - `[ExternalCloudProviderId <String>]`: This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.
  - `[ExternalCloudProviderType <ExternalCloudProviderType?>]`: The external cloud provider type associated with dimension/query operations. This includes 'externalSubscriptions' for linked account and 'externalBillingAccounts' for consolidated account.
  - `[Id <String>]`: Resource identity path
  - `[Scope <String>]`: The scope associated with view operations. This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, 'providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for External Billing Account scope and 'providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for External Subscription scope.
  - `[ViewName <String>]`: View name

## RELATED LINKS

