---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/get-azbudget
schema: 2.0.0
---

# Get-AzBudget

## SYNOPSIS
Gets the budget for the scope by budget name.

## SYNTAX

### ListBySubscription (Default)
```
Get-AzBudget [-Name <String>] [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzBudget -Name <String> -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzBudget -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzBudget -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByBillingAccount
```
Get-AzBudget -BillingAccountId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByBillingProfile
```
Get-AzBudget -BillingAccountId <String> -BillingProfileId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListByDepartment
```
Get-AzBudget -BillingAccountId <String> -DepartmentId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListByEnrollmentAccount
```
Get-AzBudget -BillingAccountId <String> -EnrollmentAccountId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListByInvoiceSection
```
Get-AzBudget -BillingAccountId <String> -InvoiceSectionId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListByManagementGroup
```
Get-AzBudget -ManagementGroupId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByResourceGroup
```
Get-AzBudget -ResourceGroupName <String> [-Name <String>] [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the budget for the scope by budget name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -BillingAccountId
The id of the billing account to scope the budgets to.

```yaml
Type: System.String
Parameter Sets: ListByBillingAccount, ListByBillingProfile, ListByDepartment, ListByEnrollmentAccount, ListByInvoiceSection
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BillingProfileId
The id of the billing profile to scope the budgets to.

```yaml
Type: System.String
Parameter Sets: ListByBillingProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -DepartmentId
The id of the department to scope the budgets to.

```yaml
Type: System.String
Parameter Sets: ListByDepartment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnrollmentAccountId
The id of the enrollment account to scope the budgets to.

```yaml
Type: System.String
Parameter Sets: ListByEnrollmentAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InvoiceSectionId
The id of the invoice section to scope the budgets to.

```yaml
Type: System.String
Parameter Sets: ListByInvoiceSection
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ManagementGroupId
The id of the management group to scope the budgets to.

```yaml
Type: System.String
Parameter Sets: ListByManagementGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Budget Name.

```yaml
Type: System.String
Parameter Sets: Get, ListByResourceGroup, ListBySubscription
Aliases: BudgetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The resource group name to scope the budgets to.

```yaml
Type: System.String
Parameter Sets: ListByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Scope
The scope associated with budget operations.
This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, '/providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The id of the subscription to scope the budgets to.

```yaml
Type: System.String
Parameter Sets: ListByResourceGroup, ListBySubscription
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api201901.IBudget

## ALIASES

### Get-AzConsumptionBudget

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IBillingIdentity>: Identity Parameter
  - `[AgreementName <String>]`: Agreement Id.
  - `[BillingAccountId <String>]`: BillingAccount ID
  - `[BillingAccountName <String>]`: Billing Account Id.
  - `[BillingPeriodName <String>]`: Billing Period Name.
  - `[BillingProfileId <String>]`: Billing Profile Id.
  - `[BillingProfileName <String>]`: Billing Profile Id.
  - `[BillingRoleAssignmentName <String>]`: role assignment id.
  - `[BillingRoleDefinitionName <String>]`: role definition id.
  - `[BillingSubscriptionName <String>]`: Billing Subscription Id.
  - `[BudgetName <String>]`: Budget Name.
  - `[CustomerName <String>]`: Customer Id.
  - `[DepartmentName <String>]`: Department Id.
  - `[EnrollmentAccountName <String>]`: Enrollment Account Id.
  - `[Id <String>]`: Resource identity path
  - `[InvoiceName <String>]`: The name of an invoice resource.
  - `[InvoiceSectionId <String>]`: Invoice Section Id.
  - `[InvoiceSectionName <String>]`: InvoiceSection Id.
  - `[ManagementGroupId <String>]`: Azure Management Group ID.
  - `[Name <String>]`: Enrollment Account name.
  - `[ProductName <String>]`: Invoice Id.
  - `[ReservationId <String>]`: Id of the reservation
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[Scope <String>]`: The scope associated with usage details operations. This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, '/providers/Microsoft.Billing/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope and '/providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope. For subscription, billing account, department, enrollment account and management group, you can also add billing period to the scope using '/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}'. For e.g. to specify billing period at department scope use '/providers/Microsoft.Billing/departments/{departmentId}/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}'
  - `[SubscriptionId <String>]`: Azure Subscription ID.
  - `[TransferName <String>]`: Transfer Name.

## RELATED LINKS

