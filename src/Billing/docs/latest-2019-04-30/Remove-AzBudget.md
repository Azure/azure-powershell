---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/remove-azbudget
schema: 2.0.0
---

# Remove-AzBudget

## SYNOPSIS
The operation to delete a budget.

## SYNTAX

### Delete (Default)
```
Remove-AzBudget -Name <String> -Scope <String> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzBudget -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to delete a budget.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity
Parameter Sets: DeleteViaIdentity
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
Parameter Sets: Delete
Aliases: BudgetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: Delete
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity

## OUTPUTS

### System.Boolean

## ALIASES

### Remove-AzConsumptionBudget

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

