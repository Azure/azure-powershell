---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/update-azbillingaccount
schema: 2.0.0
---

# Update-AzBillingAccount

## SYNOPSIS
Updates the properties of a billing account.
Currently, displayName and address can be updated.
The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzBillingAccount -Name <String> [-BillingProfileValue <IBillingProfile[]>]
 [-Department <IDepartment[]>] [-DisplayName <String>] [-EnrollmentAccount <IEnrollmentAccount[]>]
 [-NotificationEmailAddress <String>] [-SoldToAddressLine1 <String>] [-SoldToAddressLine2 <String>]
 [-SoldToAddressLine3 <String>] [-SoldToCity <String>] [-SoldToCompanyName <String>] [-SoldToCountry <String>]
 [-SoldToDistrict <String>] [-SoldToEmail <String>] [-SoldToFirstName <String>] [-SoldToLastName <String>]
 [-SoldToMiddleName <String>] [-SoldToPhoneNumber <String>] [-SoldToPostalCode <String>]
 [-SoldToRegion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzBillingAccount -InputObject <IBillingIdentity> [-BillingProfileValue <IBillingProfile[]>]
 [-Department <IDepartment[]>] [-DisplayName <String>] [-EnrollmentAccount <IEnrollmentAccount[]>]
 [-NotificationEmailAddress <String>] [-SoldToAddressLine1 <String>] [-SoldToAddressLine2 <String>]
 [-SoldToAddressLine3 <String>] [-SoldToCity <String>] [-SoldToCompanyName <String>] [-SoldToCountry <String>]
 [-SoldToDistrict <String>] [-SoldToEmail <String>] [-SoldToFirstName <String>] [-SoldToLastName <String>]
 [-SoldToMiddleName <String>] [-SoldToPhoneNumber <String>] [-SoldToPostalCode <String>]
 [-SoldToRegion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of a billing account.
Currently, displayName and address can be updated.
The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.

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

### -BillingProfileValue
The billing profiles associated with the billing account.
To construct, see NOTES section for BILLINGPROFILEVALUE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20200501.IBillingProfile[]
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

### -Department
The departments associated to the enrollment.
To construct, see NOTES section for DEPARTMENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20200501.IDepartment[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The billing account name.

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

### -EnrollmentAccount
The accounts associated to the enrollment.
To construct, see NOTES section for ENROLLMENTACCOUNT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20200501.IEnrollmentAccount[]
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The ID that uniquely identifies a billing account.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: BillingAccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationEmailAddress
Notification email address, only for legacy accounts

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

### -SoldToAddressLine1
Address line 1.

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

### -SoldToAddressLine2
Address line 2.

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

### -SoldToAddressLine3
Address line 3.

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

### -SoldToCity
Address city.

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

### -SoldToCompanyName
Company name.

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

### -SoldToCountry
Country code uses ISO2, 2-digit format.

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

### -SoldToDistrict
Address district.

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

### -SoldToEmail
Email address.

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

### -SoldToFirstName
First name.

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

### -SoldToLastName
Last name.

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

### -SoldToMiddleName
Middle name.

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

### -SoldToPhoneNumber
Phone number.

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

### -SoldToPostalCode
Postal code.

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

### -SoldToRegion
Address region.

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

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20200501.IBillingAccount

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BILLINGPROFILEVALUE <IBillingProfile[]>: The billing profiles associated with the billing account.
  - `[BillToAddressLine1 <String>]`: Address line 1.
  - `[BillToAddressLine2 <String>]`: Address line 2.
  - `[BillToAddressLine3 <String>]`: Address line 3.
  - `[BillToCity <String>]`: Address city.
  - `[BillToCompanyName <String>]`: Company name.
  - `[BillToCountry <String>]`: Country code uses ISO2, 2-digit format.
  - `[BillToDistrict <String>]`: Address district.
  - `[BillToEmail <String>]`: Email address.
  - `[BillToFirstName <String>]`: First name.
  - `[BillToLastName <String>]`: Last name.
  - `[BillToMiddleName <String>]`: Middle name.
  - `[BillToPhoneNumber <String>]`: Phone number.
  - `[BillToPostalCode <String>]`: Postal code.
  - `[BillToRegion <String>]`: Address region.
  - `[DisplayName <String>]`: The name of the billing profile.
  - `[EnabledAzurePlan <IAzurePlan[]>]`: Information about the enabled azure plans.
    - `[SkuId <String>]`: The sku id.
  - `[IndirectRelationshipInfoBillingAccountName <String>]`: The billing account name of the partner or the customer for an indirect motion.
  - `[IndirectRelationshipInfoBillingProfileName <String>]`: The billing profile name of the partner or the customer for an indirect motion.
  - `[IndirectRelationshipInfoDisplayName <String>]`: The display name of the partner or customer for an indirect motion.
  - `[InvoiceEmailOptIn <Boolean?>]`: Flag controlling whether the invoices for the billing profile are sent through email.
  - `[InvoiceSectionValue <IInvoiceSection[]>]`: The invoice sections associated to the billing profile.
    - `[DisplayName <String>]`: The name of the invoice section.
    - `[Label <IInvoiceSectionPropertiesLabels>]`: Dictionary of metadata associated with the invoice section.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Tag <IInvoiceSectionPropertiesTags>]`: Dictionary of metadata associated with the invoice section. Maximum key/value length supported of 256 characters. Keys/value should not empty value nor null. Keys can not contain < > % & \ ? /
      - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[PoNumber <String>]`: The purchase order name that will appear on the invoices generated for the billing profile.
  - `[Tag <IBillingProfilePropertiesTags>]`: Tags of billing profiles.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

DEPARTMENT <IDepartment[]>: The departments associated to the enrollment.
  - `[CostCenter <String>]`: The cost center associated with the department.
  - `[DepartmentName <String>]`: The name of the department.
  - `[EnrollmentAccount <IEnrollmentAccount[]>]`: Associated enrollment accounts. By default this is not populated, unless it's specified in $expand.
    - `[AccountName <String>]`: The name of the enrollment account.
    - `[AccountOwner <String>]`: The owner of the enrollment account.
    - `[AccountOwnerEmail <String>]`: The enrollment account owner email address.
    - `[CostCenter <String>]`: The cost center associated with the enrollment account.
    - `[DepartmentPropertiesCostCenter <String>]`: The cost center associated with the department.
    - `[DepartmentPropertiesDepartmentName <String>]`: The name of the department.
    - `[DepartmentPropertiesStatus <String>]`: The status of the department.
    - `[EndDate <DateTime?>]`: The end date of the enrollment account.
    - `[PropertiesDepartmentPropertiesEnrollmentAccounts <IEnrollmentAccount[]>]`: Associated enrollment accounts. By default this is not populated, unless it's specified in $expand.
    - `[StartDate <DateTime?>]`: The start date of the enrollment account.
    - `[Status <String>]`: The status of the enrollment account.
  - `[Status <String>]`: The status of the department.

ENROLLMENTACCOUNT <IEnrollmentAccount[]>: The accounts associated to the enrollment.
  - `[AccountName <String>]`: The name of the enrollment account.
  - `[AccountOwner <String>]`: The owner of the enrollment account.
  - `[AccountOwnerEmail <String>]`: The enrollment account owner email address.
  - `[CostCenter <String>]`: The cost center associated with the enrollment account.
  - `[DepartmentPropertiesCostCenter <String>]`: The cost center associated with the department.
  - `[DepartmentPropertiesDepartmentName <String>]`: The name of the department.
  - `[DepartmentPropertiesStatus <String>]`: The status of the department.
  - `[EndDate <DateTime?>]`: The end date of the enrollment account.
  - `[PropertiesDepartmentPropertiesEnrollmentAccounts <IEnrollmentAccount[]>]`: Associated enrollment accounts. By default this is not populated, unless it's specified in $expand.
  - `[StartDate <DateTime?>]`: The start date of the enrollment account.
  - `[Status <String>]`: The status of the enrollment account.

INPUTOBJECT <IBillingIdentity>: Identity Parameter
  - `[AgreementName <String>]`: The ID that uniquely identifies an agreement.
  - `[BillingAccountName <String>]`: The ID that uniquely identifies a billing account.
  - `[BillingPeriodName <String>]`: The name of a BillingPeriod resource.
  - `[BillingProfileName <String>]`: The ID that uniquely identifies a billing profile.
  - `[BillingRoleAssignmentName <String>]`: The ID that uniquely identifies a role assignment.
  - `[BillingRoleDefinitionName <String>]`: The ID that uniquely identifies a role definition.
  - `[CustomerName <String>]`: The ID that uniquely identifies a customer.
  - `[Id <String>]`: Resource identity path
  - `[InstructionName <String>]`: Instruction Name.
  - `[InvoiceName <String>]`: The ID that uniquely identifies an invoice.
  - `[InvoiceSectionName <String>]`: The ID that uniquely identifies an invoice section.
  - `[Name <String>]`: Enrollment Account name.
  - `[ProductName <String>]`: The ID that uniquely identifies a product.
  - `[SubscriptionId <String>]`: The ID that uniquely identifies an Azure subscription.

## RELATED LINKS

