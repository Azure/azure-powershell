---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/new-azbudget
schema: 2.0.0
---

# New-AzBudget

## SYNOPSIS
The operation to create or update a budget.
Update operation requires latest eTag to be set in the request mandatorily.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

## SYNTAX

### CreateExpanded (Default)
```
New-AzBudget -Name <String> -Scope <String> [-Amount <Decimal>] [-Category <CategoryType>] [-ETag <String>]
 [-FilterMeter <String[]>] [-FilterResource <String[]>] [-FilterResourceGroup <String[]>]
 [-FilterTag <Hashtable>] [-Notification <Hashtable>] [-TimeGrain <TimeGrainType>]
 [-TimePeriodEndDate <DateTime>] [-TimePeriodStartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzBudget -Name <String> -Scope <String> -Parameter <IBudget> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzBudget -InputObject <IBillingIdentity> -Parameter <IBudget> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzBudget -InputObject <IBillingIdentity> [-Amount <Decimal>] [-Category <CategoryType>] [-ETag <String>]
 [-FilterMeter <String[]>] [-FilterResource <String[]>] [-FilterResourceGroup <String[]>]
 [-FilterTag <Hashtable>] [-Notification <Hashtable>] [-TimeGrain <TimeGrainType>]
 [-TimePeriodEndDate <DateTime>] [-TimePeriodStartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a budget.
Update operation requires latest eTag to be set in the request mandatorily.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

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

### -Amount
The total amount of cost to track with the budget

```yaml
Type: System.Decimal
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Category
The category of the budget, whether the budget tracks cost or usage.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Support.CategoryType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -ETag
eTag of the resource.
To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FilterMeter
The list of filters on meters (GUID), mandatory for budgets of usage category.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FilterResource
The list of filters on resources.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FilterResourceGroup
The list of filters on resource groups, allowed at subscription level only.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FilterTag
The dictionary of filters on tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
Budget Name.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: BudgetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Notification
Dictionary of notifications associated with the budget.
Budget can have up to five notifications.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
A budget resource.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api201901.IBudget
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Scope
The scope associated with budget operations.
This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, '/providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TimeGrain
The time covered by a budget.
Tracking of the amount will be reset based on the time grain.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Support.TimeGrainType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TimePeriodEndDate
The end date for the budget.
If not provided, we default this to 10 years from the start date.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TimePeriodStartDate
The start date for the budget.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api201901.IBudget

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api201901.IBudget

## ALIASES

### New-AzConsumptionBudget

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

#### PARAMETER <IBudget>: A budget resource.
  - `Amount <Decimal>`: The total amount of cost to track with the budget
  - `Category <CategoryType>`: The category of the budget, whether the budget tracks cost or usage.
  - `TimeGrain <TimeGrainType>`: The time covered by a budget. Tracking of the amount will be reset based on the time grain.
  - `TimePeriodStartDate <DateTime>`: The start date for the budget.
  - `[ETag <String>]`: eTag of the resource. To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not.
  - `[FilterMeter <String[]>]`: The list of filters on meters (GUID), mandatory for budgets of usage category. 
  - `[FilterResource <String[]>]`: The list of filters on resources.
  - `[FilterResourceGroup <String[]>]`: The list of filters on resource groups, allowed at subscription level only.
  - `[FilterTag <IFiltersTags>]`: The dictionary of filters on tags.
    - `[(Any) <String[]>]`: This indicates any property can be added to this object.
  - `[Notification <IBudgetPropertiesNotifications>]`: Dictionary of notifications associated with the budget. Budget can have up to five notifications.
    - `[(Any) <INotification>]`: This indicates any property can be added to this object.
  - `[TimePeriodEndDate <DateTime?>]`: The end date for the budget. If not provided, we default this to 10 years from the start date.

## RELATED LINKS

