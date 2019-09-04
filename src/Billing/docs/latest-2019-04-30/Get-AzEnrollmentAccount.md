---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/get-azenrollmentaccount
schema: 2.0.0
---

# Get-AzEnrollmentAccount

## SYNOPSIS
Gets a enrollment account by name.

## SYNTAX

### List1 (Default)
```
Get-AzEnrollmentAccount [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzEnrollmentAccount -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEnrollmentAccount -InputObject <IBillingIdentity> [-Expand <String>] [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzEnrollmentAccount -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListExpandedFilter
```
Get-AzEnrollmentAccount -BillingAccountName <String> [-Name <String>] [-ExpandDepartment] [-Tag <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a enrollment account by name.

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

### -BillingAccountName
billing Account Id.

```yaml
Type: System.String
Parameter Sets: ListExpandedFilter
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

### -Expand
May be used to expand the Department.

```yaml
Type: System.String
Parameter Sets: GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ExpandDepartment
If set, signals to expand the department on the returned enrollment account(s).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListExpandedFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Filter
The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'.
It does not currently support 'ne', 'or', or 'not'.
Tag filter is a key value pair string where key and value is separated by a colon (:).

```yaml
Type: System.String
Parameter Sets: GetViaIdentity
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
Parameter Sets: GetViaIdentity, GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
Enrollment Account name.

```yaml
Type: System.String
Parameter Sets: Get1, ListExpandedFilter
Aliases: ObjectId, EnrollmentAccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
The tag of the enrollment account(s) to filter.

```yaml
Type: System.String
Parameter Sets: ListExpandedFilter
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20180301Preview.IEnrollmentAccount

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IEnrollmentAccount

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IEnrollmentAccount1

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IEnrollmentAccountListResult

## ALIASES

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

