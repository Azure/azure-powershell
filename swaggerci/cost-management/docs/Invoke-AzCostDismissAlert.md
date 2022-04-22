---
external help file:
Module Name: Az.Cost
online version: https://docs.microsoft.com/en-us/powershell/module/az.cost/invoke-azcostdismissalert
schema: 2.0.0
---

# Invoke-AzCostDismissAlert

## SYNOPSIS
Dismisses the specified alert

## SYNTAX

### DismissExpanded (Default)
```
Invoke-AzCostDismissAlert -AlertId <String> -Scope <String> [-CloseTime <String>] [-CostEntityId <String>]
 [-CreationTime <String>] [-DefinitionCategory <AlertCategory>] [-DefinitionCriterion <AlertCriteria>]
 [-DefinitionType <AlertType>] [-Description <String>] [-DetailAmount <Decimal>] [-DetailCompanyName <String>]
 [-DetailContactEmail <String[]>] [-DetailContactGroup <String[]>] [-DetailContactRole <String[]>]
 [-DetailCurrentSpend <Decimal>] [-DetailDepartmentName <String>] [-DetailEnrollmentEndDate <String>]
 [-DetailEnrollmentNumber <String>] [-DetailEnrollmentStartDate <String>]
 [-DetailInvoicingThreshold <Decimal>] [-DetailMeterFilter <IAny[]>] [-DetailOperator <AlertOperator>]
 [-DetailOverridingAlert <String>] [-DetailPeriodStartDate <String>] [-DetailResourceFilter <IAny[]>]
 [-DetailResourceGroupFilter <IAny[]>] [-DetailTagFilter <IAny>] [-DetailThreshold <Decimal>]
 [-DetailTimeGrainType <AlertTimeGrainType>] [-DetailTriggeredBy <String>] [-DetailUnit <String>]
 [-ModificationTime <String>] [-Source <AlertSource>] [-Status <AlertStatus>]
 [-StatusModificationTime <String>] [-StatusModificationUserName <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Dismiss
```
Invoke-AzCostDismissAlert -AlertId <String> -Scope <String> -Parameter <IDismissAlertPayload>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DismissViaIdentity
```
Invoke-AzCostDismissAlert -InputObject <ICostIdentity> -Parameter <IDismissAlertPayload>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DismissViaIdentityExpanded
```
Invoke-AzCostDismissAlert -InputObject <ICostIdentity> [-CloseTime <String>] [-CostEntityId <String>]
 [-CreationTime <String>] [-DefinitionCategory <AlertCategory>] [-DefinitionCriterion <AlertCriteria>]
 [-DefinitionType <AlertType>] [-Description <String>] [-DetailAmount <Decimal>] [-DetailCompanyName <String>]
 [-DetailContactEmail <String[]>] [-DetailContactGroup <String[]>] [-DetailContactRole <String[]>]
 [-DetailCurrentSpend <Decimal>] [-DetailDepartmentName <String>] [-DetailEnrollmentEndDate <String>]
 [-DetailEnrollmentNumber <String>] [-DetailEnrollmentStartDate <String>]
 [-DetailInvoicingThreshold <Decimal>] [-DetailMeterFilter <IAny[]>] [-DetailOperator <AlertOperator>]
 [-DetailOverridingAlert <String>] [-DetailPeriodStartDate <String>] [-DetailResourceFilter <IAny[]>]
 [-DetailResourceGroupFilter <IAny[]>] [-DetailTagFilter <IAny>] [-DetailThreshold <Decimal>]
 [-DetailTimeGrainType <AlertTimeGrainType>] [-DetailTriggeredBy <String>] [-DetailUnit <String>]
 [-ModificationTime <String>] [-Source <AlertSource>] [-Status <AlertStatus>]
 [-StatusModificationTime <String>] [-StatusModificationUserName <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Dismisses the specified alert

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

### -AlertId
Alert ID

```yaml
Type: System.String
Parameter Sets: Dismiss, DismissExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloseTime
dateTime in which alert was closed

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CostEntityId
related budget

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreationTime
dateTime in which alert was created

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
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

### -DefinitionCategory
Alert category

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.AlertCategory
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefinitionCriterion
Criteria that triggered alert

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.AlertCriteria
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefinitionType
type of alert

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.AlertType
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Alert description

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailAmount
budget threshold amount

```yaml
Type: System.Decimal
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailCompanyName
company name

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailContactEmail
list of emails to contact

```yaml
Type: System.String[]
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailContactGroup
list of action groups to broadcast to

```yaml
Type: System.String[]
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailContactRole
list of contact roles

```yaml
Type: System.String[]
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailCurrentSpend
current spend

```yaml
Type: System.Decimal
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailDepartmentName
department name

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailEnrollmentEndDate
datetime of enrollmentEndDate

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailEnrollmentNumber
enrollment number

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailEnrollmentStartDate
datetime of enrollmentStartDate

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailInvoicingThreshold
invoicing threshold

```yaml
Type: System.Decimal
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailMeterFilter
array of meters to filter by

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.IAny[]
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailOperator
operator used to compare currentSpend with amount

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.AlertOperator
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailOverridingAlert
overriding alert

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailPeriodStartDate
datetime of periodStartDate

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailResourceFilter
array of resources to filter by

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.IAny[]
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailResourceGroupFilter
array of resourceGroups to filter by

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.IAny[]
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailTagFilter
tags to filter by

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.IAny
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailThreshold
notification threshold percentage as a decimal which activated this alert

```yaml
Type: System.Decimal
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailTimeGrainType
Type of timegrain cadence

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.AlertTimeGrainType
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailTriggeredBy
notificationId that triggered this alert

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetailUnit
unit of currency being used

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.ICostIdentity
Parameter Sets: DismissViaIdentity, DismissViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ModificationTime
dateTime in which alert was last modified

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The request payload to update an alert
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IDismissAlertPayload
Parameter Sets: Dismiss, DismissViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Scope
The scope associated with alerts operations.
This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, '/providers/Microsoft.Management/managementGroups/{managementGroupId} for Management Group scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.

```yaml
Type: System.String
Parameter Sets: Dismiss, DismissExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Source
Source of alert

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.AlertSource
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
alert status

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.AlertStatus
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusModificationTime
dateTime in which the alert status was last modified

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusModificationUserName
User who last modified the alert

```yaml
Type: System.String
Parameter Sets: DismissExpanded, DismissViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IDismissAlertPayload

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.ICostIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IAlert

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ICostIdentity>: Identity Parameter
  - `[AlertId <String>]`: Alert ID
  - `[BillingAccountId <String>]`: Enrollment ID (Legacy BillingAccount ID)
  - `[BillingProfileId <String>]`: BillingProfile ID
  - `[ExportName <String>]`: Export Name.
  - `[ExternalCloudProviderId <String>]`: This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.
  - `[ExternalCloudProviderType <ExternalCloudProviderType?>]`: The external cloud provider type associated with dimension/query operations. This includes 'externalSubscriptions' for linked account and 'externalBillingAccounts' for consolidated account.
  - `[Id <String>]`: Resource identity path
  - `[OperationId <String>]`: The target operation Id.
  - `[Scope <String>]`: The scope associated with export operations. This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, '/providers/Microsoft.Management/managementGroups/{managementGroupId} for Management Group scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.
  - `[ViewName <String>]`: View name

PARAMETER <IDismissAlertPayload>: The request payload to update an alert
  - `[CloseTime <String>]`: dateTime in which alert was closed
  - `[CostEntityId <String>]`: related budget
  - `[CreationTime <String>]`: dateTime in which alert was created
  - `[DefinitionCategory <AlertCategory?>]`: Alert category
  - `[DefinitionCriterion <AlertCriteria?>]`: Criteria that triggered alert
  - `[DefinitionType <AlertType?>]`: type of alert
  - `[Description <String>]`: Alert description
  - `[DetailAmount <Decimal?>]`: budget threshold amount
  - `[DetailCompanyName <String>]`: company name
  - `[DetailContactEmail <String[]>]`: list of emails to contact
  - `[DetailContactGroup <String[]>]`: list of action groups to broadcast to
  - `[DetailContactRole <String[]>]`: list of contact roles
  - `[DetailCurrentSpend <Decimal?>]`: current spend
  - `[DetailDepartmentName <String>]`: department name
  - `[DetailEnrollmentEndDate <String>]`: datetime of enrollmentEndDate
  - `[DetailEnrollmentNumber <String>]`: enrollment number
  - `[DetailEnrollmentStartDate <String>]`: datetime of enrollmentStartDate
  - `[DetailInvoicingThreshold <Decimal?>]`: invoicing threshold
  - `[DetailMeterFilter <IAny[]>]`: array of meters to filter by
  - `[DetailOperator <AlertOperator?>]`: operator used to compare currentSpend with amount
  - `[DetailOverridingAlert <String>]`: overriding alert
  - `[DetailPeriodStartDate <String>]`: datetime of periodStartDate
  - `[DetailResourceFilter <IAny[]>]`: array of resources to filter by
  - `[DetailResourceGroupFilter <IAny[]>]`: array of resourceGroups to filter by
  - `[DetailTagFilter <IAny>]`: tags to filter by
  - `[DetailThreshold <Decimal?>]`: notification threshold percentage as a decimal which activated this alert
  - `[DetailTimeGrainType <AlertTimeGrainType?>]`: Type of timegrain cadence
  - `[DetailTriggeredBy <String>]`: notificationId that triggered this alert
  - `[DetailUnit <String>]`: unit of currency being used
  - `[ModificationTime <String>]`: dateTime in which alert was last modified
  - `[Source <AlertSource?>]`: Source of alert
  - `[Status <AlertStatus?>]`: alert status
  - `[StatusModificationTime <String>]`: dateTime in which the alert status was last modified
  - `[StatusModificationUserName <String>]`: User who last modified the alert

## RELATED LINKS

