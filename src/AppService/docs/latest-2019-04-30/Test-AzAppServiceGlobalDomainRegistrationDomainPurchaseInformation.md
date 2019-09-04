---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/test-azappserviceglobaldomainregistrationdomainpurchaseinformation
schema: 2.0.0
---

# Test-AzAppServiceGlobalDomainRegistrationDomainPurchaseInformation

## SYNOPSIS
Validates domain registration information

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzAppServiceGlobalDomainRegistrationDomainPurchaseInformation -Location <String>
 [-SubscriptionId <String>] [-AutoRenew] [-ConsentAgreedAt <DateTime>] [-ConsentAgreedBy <String>]
 [-ConsentAgreementKey <String[]>] [-ContactAdminAddressMailingAddress1 <String>]
 [-ContactAdminAddressMailingAddress2 <String>] [-ContactAdminAddressMailingCity <String>]
 [-ContactAdminAddressMailingCountry <String>] [-ContactAdminAddressMailingPostalCode <String>]
 [-ContactAdminAddressMailingState <String>] [-ContactAdminEmail <String>] [-ContactAdminFax <String>]
 [-ContactAdminJobTitle <String>] [-ContactAdminNameFirst <String>] [-ContactAdminNameLast <String>]
 [-ContactAdminNameMiddle <String>] [-ContactAdminOrganization <String>] [-ContactAdminPhone <String>]
 [-ContactBillingAddressMailingAddress1 <String>] [-ContactBillingAddressMailingAddress2 <String>]
 [-ContactBillingAddressMailingCity <String>] [-ContactBillingAddressMailingCountry <String>]
 [-ContactBillingAddressMailingPostalCode <String>] [-ContactBillingAddressMailingState <String>]
 [-ContactBillingEmail <String>] [-ContactBillingFax <String>] [-ContactBillingJobTitle <String>]
 [-ContactBillingNameFirst <String>] [-ContactBillingNameLast <String>] [-ContactBillingNameMiddle <String>]
 [-ContactBillingOrganization <String>] [-ContactBillingPhone <String>]
 [-ContactRegistrantAddressMailingAddress1 <String>] [-ContactRegistrantAddressMailingAddress2 <String>]
 [-ContactRegistrantAddressMailingCity <String>] [-ContactRegistrantAddressMailingCountry <String>]
 [-ContactRegistrantAddressMailingPostalCode <String>] [-ContactRegistrantAddressMailingState <String>]
 [-ContactRegistrantEmail <String>] [-ContactRegistrantFax <String>] [-ContactRegistrantJobTitle <String>]
 [-ContactRegistrantNameFirst <String>] [-ContactRegistrantNameLast <String>]
 [-ContactRegistrantNameMiddle <String>] [-ContactRegistrantOrganization <String>]
 [-ContactRegistrantPhone <String>] [-ContactTechAddressMailingAddress1 <String>]
 [-ContactTechAddressMailingAddress2 <String>] [-ContactTechAddressMailingCity <String>]
 [-ContactTechAddressMailingCountry <String>] [-ContactTechAddressMailingPostalCode <String>]
 [-ContactTechAddressMailingState <String>] [-ContactTechEmail <String>] [-ContactTechFax <String>]
 [-ContactTechJobTitle <String>] [-ContactTechNameFirst <String>] [-ContactTechNameLast <String>]
 [-ContactTechNameMiddle <String>] [-ContactTechOrganization <String>] [-ContactTechPhone <String>]
 [-CreatedTime <DateTime>] [-DomainNotRenewableReason <String[]>] [-ExpirationTime <DateTime>] [-Id <String>]
 [-Kind <String>] [-LastRenewedTime <DateTime>] [-ManagedHostName <IHostName[]>] [-Name <String>]
 [-NameServer <String[]>] [-Privacy] [-PropertiesName <String>] [-ProvisioningState <ProvisioningState>]
 [-ReadyForDnsRecordManagement] [-RegistrationStatus <DomainStatus>] [-Tag <Hashtable>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Validate
```
Test-AzAppServiceGlobalDomainRegistrationDomainPurchaseInformation
 -DomainRegistrationInput <IDomainRegistrationInput> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzAppServiceGlobalDomainRegistrationDomainPurchaseInformation -InputObject <IAppServiceIdentity>
 -DomainRegistrationInput <IDomainRegistrationInput> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzAppServiceGlobalDomainRegistrationDomainPurchaseInformation -InputObject <IAppServiceIdentity>
 -Location <String> [-AutoRenew] [-ConsentAgreedAt <DateTime>] [-ConsentAgreedBy <String>]
 [-ConsentAgreementKey <String[]>] [-ContactAdminAddressMailingAddress1 <String>]
 [-ContactAdminAddressMailingAddress2 <String>] [-ContactAdminAddressMailingCity <String>]
 [-ContactAdminAddressMailingCountry <String>] [-ContactAdminAddressMailingPostalCode <String>]
 [-ContactAdminAddressMailingState <String>] [-ContactAdminEmail <String>] [-ContactAdminFax <String>]
 [-ContactAdminJobTitle <String>] [-ContactAdminNameFirst <String>] [-ContactAdminNameLast <String>]
 [-ContactAdminNameMiddle <String>] [-ContactAdminOrganization <String>] [-ContactAdminPhone <String>]
 [-ContactBillingAddressMailingAddress1 <String>] [-ContactBillingAddressMailingAddress2 <String>]
 [-ContactBillingAddressMailingCity <String>] [-ContactBillingAddressMailingCountry <String>]
 [-ContactBillingAddressMailingPostalCode <String>] [-ContactBillingAddressMailingState <String>]
 [-ContactBillingEmail <String>] [-ContactBillingFax <String>] [-ContactBillingJobTitle <String>]
 [-ContactBillingNameFirst <String>] [-ContactBillingNameLast <String>] [-ContactBillingNameMiddle <String>]
 [-ContactBillingOrganization <String>] [-ContactBillingPhone <String>]
 [-ContactRegistrantAddressMailingAddress1 <String>] [-ContactRegistrantAddressMailingAddress2 <String>]
 [-ContactRegistrantAddressMailingCity <String>] [-ContactRegistrantAddressMailingCountry <String>]
 [-ContactRegistrantAddressMailingPostalCode <String>] [-ContactRegistrantAddressMailingState <String>]
 [-ContactRegistrantEmail <String>] [-ContactRegistrantFax <String>] [-ContactRegistrantJobTitle <String>]
 [-ContactRegistrantNameFirst <String>] [-ContactRegistrantNameLast <String>]
 [-ContactRegistrantNameMiddle <String>] [-ContactRegistrantOrganization <String>]
 [-ContactRegistrantPhone <String>] [-ContactTechAddressMailingAddress1 <String>]
 [-ContactTechAddressMailingAddress2 <String>] [-ContactTechAddressMailingCity <String>]
 [-ContactTechAddressMailingCountry <String>] [-ContactTechAddressMailingPostalCode <String>]
 [-ContactTechAddressMailingState <String>] [-ContactTechEmail <String>] [-ContactTechFax <String>]
 [-ContactTechJobTitle <String>] [-ContactTechNameFirst <String>] [-ContactTechNameLast <String>]
 [-ContactTechNameMiddle <String>] [-ContactTechOrganization <String>] [-ContactTechPhone <String>]
 [-CreatedTime <DateTime>] [-DomainNotRenewableReason <String[]>] [-ExpirationTime <DateTime>] [-Id <String>]
 [-Kind <String>] [-LastRenewedTime <DateTime>] [-ManagedHostName <IHostName[]>] [-Name <String>]
 [-NameServer <String[]>] [-Privacy] [-PropertiesName <String>] [-ProvisioningState <ProvisioningState>]
 [-ReadyForDnsRecordManagement] [-RegistrationStatus <DomainStatus>] [-Tag <Hashtable>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validates domain registration information

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

### -AutoRenew
If true then domain will renewed automatically

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConsentAgreedAt
Timestamp when the agreements were accepted.

```yaml
Type: System.DateTime
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConsentAgreedBy
Client IP address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConsentAgreementKey
List of applicable legal agreement keys.
This list can be retrieved using ListLegalAgreements API under \<code\>TopLevelDomain\</code\> resource.

```yaml
Type: System.String[]
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminAddressMailingAddress1
First line of an Address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminAddressMailingAddress2
The second line of the Address.
Optional.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminAddressMailingCity
The city for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminAddressMailingCountry
The country for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminAddressMailingPostalCode
The postal code for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminAddressMailingState
The state or province for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminEmail
Email address

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminFax
Fax number

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminJobTitle
Job title

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminNameFirst
First name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminNameLast
Last name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminNameMiddle
Middle name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminOrganization
Organization

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminPhone
Phone number

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingAddressMailingAddress1
First line of an Address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingAddressMailingAddress2
The second line of the Address.
Optional.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingAddressMailingCity
The city for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingAddressMailingCountry
The country for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingAddressMailingPostalCode
The postal code for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingAddressMailingState
The state or province for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingEmail
Email address

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingFax
Fax number

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingJobTitle
Job title

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingNameFirst
First name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingNameLast
Last name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingNameMiddle
Middle name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingOrganization
Organization

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingPhone
Phone number

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantAddressMailingAddress1
First line of an Address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantAddressMailingAddress2
The second line of the Address.
Optional.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantAddressMailingCity
The city for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantAddressMailingCountry
The country for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantAddressMailingPostalCode
The postal code for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantAddressMailingState
The state or province for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantEmail
Email address

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantFax
Fax number

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantJobTitle
Job title

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantNameFirst
First name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantNameLast
Last name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantNameMiddle
Middle name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantOrganization
Organization

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantPhone
Phone number

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechAddressMailingAddress1
First line of an Address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechAddressMailingAddress2
The second line of the Address.
Optional.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechAddressMailingCity
The city for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechAddressMailingCountry
The country for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechAddressMailingPostalCode
The postal code for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechAddressMailingState
The state or province for the address.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechEmail
Email address

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechFax
Fax number

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechJobTitle
Job title

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechNameFirst
First name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechNameLast
Last name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechNameMiddle
Middle name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechOrganization
Organization

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechPhone
Phone number

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CreatedTime
Domain creation timestamp

```yaml
Type: System.DateTime
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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

### -DomainNotRenewableReason
Reasons why domain is not renewable

```yaml
Type: System.String[]
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DomainRegistrationInput
Domain registration input for validation Api
To construct, see NOTES section for DOMAINREGISTRATIONINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IDomainRegistrationInput
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ExpirationTime
Domain expiration timestamp

```yaml
Type: System.DateTime
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource Id

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity
Parameter Sets: ValidateViaIdentity, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LastRenewedTime
Timestamp when the domain was renewed last time

```yaml
Type: System.DateTime
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource Location

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ManagedHostName
All hostnames derived from the domain and assigned to Azure resources
To construct, see NOTES section for MANAGEDHOSTNAME properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150401.IHostName[]
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Resource Name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NameServer
Name servers

```yaml
Type: System.String[]
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Privacy
If true then domain privacy is enabled for this domain

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesName
Name of the domain

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
Domain provisioning state

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.ProvisioningState
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ReadyForDnsRecordManagement
If true then Azure can assign this domain to Web Apps.
This value will be true if domain registration status is active and it is hosted on name servers Azure has programmatic access to

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RegistrationStatus
Domain registration status

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.DomainStatus
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Type
Resource type

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IDomainRegistrationInput

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801Preview.IObject

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### DOMAINREGISTRATIONINPUT <IDomainRegistrationInput>: Domain registration input for validation Api
  - `Location <String>`: Resource Location
  - `ContactAdminAddressMailingAddress1 <String>`: First line of an Address.
  - `ContactAdminAddressMailingCity <String>`: The city for the address.
  - `ContactAdminAddressMailingCountry <String>`: The country for the address.
  - `ContactAdminAddressMailingPostalCode <String>`: The postal code for the address.
  - `ContactAdminAddressMailingState <String>`: The state or province for the address.
  - `ContactBillingAddressMailingAddress1 <String>`: First line of an Address.
  - `ContactBillingAddressMailingCity <String>`: The city for the address.
  - `ContactBillingAddressMailingCountry <String>`: The country for the address.
  - `ContactBillingAddressMailingPostalCode <String>`: The postal code for the address.
  - `ContactBillingAddressMailingState <String>`: The state or province for the address.
  - `ContactRegistrantAddressMailingAddress1 <String>`: First line of an Address.
  - `ContactRegistrantAddressMailingCity <String>`: The city for the address.
  - `ContactRegistrantAddressMailingCountry <String>`: The country for the address.
  - `ContactRegistrantAddressMailingPostalCode <String>`: The postal code for the address.
  - `ContactRegistrantAddressMailingState <String>`: The state or province for the address.
  - `ContactTechAddressMailingAddress1 <String>`: First line of an Address.
  - `ContactTechAddressMailingCity <String>`: The city for the address.
  - `ContactTechAddressMailingCountry <String>`: The country for the address.
  - `ContactTechAddressMailingPostalCode <String>`: The postal code for the address.
  - `ContactTechAddressMailingState <String>`: The state or province for the address.
  - `[Id <String>]`: Resource Id
  - `[Kind <String>]`: Kind of resource
  - `[Name <String>]`: Resource Name
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Type <String>]`: Resource type
  - `[AutoRenew <Boolean?>]`: If true then domain will renewed automatically
  - `[ConsentAgreedAt <DateTime?>]`: Timestamp when the agreements were accepted.
  - `[ConsentAgreedBy <String>]`: Client IP address.
  - `[ConsentAgreementKey <String[]>]`: List of applicable legal agreement keys. This list can be retrieved using ListLegalAgreements API under <code>TopLevelDomain</code> resource.
  - `[ContactAdminAddressMailingAddress2 <String>]`: The second line of the Address. Optional.
  - `[ContactAdminEmail <String>]`: Email address
  - `[ContactAdminFax <String>]`: Fax number
  - `[ContactAdminJobTitle <String>]`: Job title
  - `[ContactAdminNameFirst <String>]`: First name
  - `[ContactAdminNameLast <String>]`: Last name
  - `[ContactAdminNameMiddle <String>]`: Middle name
  - `[ContactAdminOrganization <String>]`: Organization
  - `[ContactAdminPhone <String>]`: Phone number
  - `[ContactBillingAddressMailingAddress2 <String>]`: The second line of the Address. Optional.
  - `[ContactBillingEmail <String>]`: Email address
  - `[ContactBillingFax <String>]`: Fax number
  - `[ContactBillingJobTitle <String>]`: Job title
  - `[ContactBillingNameFirst <String>]`: First name
  - `[ContactBillingNameLast <String>]`: Last name
  - `[ContactBillingNameMiddle <String>]`: Middle name
  - `[ContactBillingOrganization <String>]`: Organization
  - `[ContactBillingPhone <String>]`: Phone number
  - `[ContactRegistrantAddressMailingAddress2 <String>]`: The second line of the Address. Optional.
  - `[ContactRegistrantEmail <String>]`: Email address
  - `[ContactRegistrantFax <String>]`: Fax number
  - `[ContactRegistrantJobTitle <String>]`: Job title
  - `[ContactRegistrantNameFirst <String>]`: First name
  - `[ContactRegistrantNameLast <String>]`: Last name
  - `[ContactRegistrantNameMiddle <String>]`: Middle name
  - `[ContactRegistrantOrganization <String>]`: Organization
  - `[ContactRegistrantPhone <String>]`: Phone number
  - `[ContactTechAddressMailingAddress2 <String>]`: The second line of the Address. Optional.
  - `[ContactTechEmail <String>]`: Email address
  - `[ContactTechFax <String>]`: Fax number
  - `[ContactTechJobTitle <String>]`: Job title
  - `[ContactTechNameFirst <String>]`: First name
  - `[ContactTechNameLast <String>]`: Last name
  - `[ContactTechNameMiddle <String>]`: Middle name
  - `[ContactTechOrganization <String>]`: Organization
  - `[ContactTechPhone <String>]`: Phone number
  - `[CreatedTime <DateTime?>]`: Domain creation timestamp
  - `[DomainNotRenewableReason <String[]>]`: Reasons why domain is not renewable
  - `[ExpirationTime <DateTime?>]`: Domain expiration timestamp
  - `[LastRenewedTime <DateTime?>]`: Timestamp when the domain was renewed last time
  - `[ManagedHostName <IHostName[]>]`: All hostnames derived from the domain and assigned to Azure resources
    - `[AzureResourceName <String>]`: Name of the Azure resource the hostname is assigned to. If it is assigned to a Traffic Manager then it will be the Traffic Manager name otherwise it will be the app name.
    - `[AzureResourceType <AzureResourceType?>]`: Type of the Azure resource the hostname is assigned to.
    - `[CustomHostNameDnsRecordType <CustomHostNameDnsRecordType?>]`: Type of the DNS record.
    - `[Name <String>]`: Name of the hostname.
    - `[SiteName <String[]>]`: List of apps the hostname is assigned to. This list will have more than one app only if the hostname is pointing to a Traffic Manager.
    - `[Type <HostNameType?>]`: Type of the hostname.
  - `[NameServer <String[]>]`: Name servers
  - `[Privacy <Boolean?>]`: If true then domain privacy is enabled for this domain
  - `[PropertiesName <String>]`: Name of the domain
  - `[ProvisioningState <ProvisioningState?>]`: Domain provisioning state
  - `[ReadyForDnsRecordManagement <Boolean?>]`: If true then Azure can assign this domain to Web Apps. This value will be true if domain registration status is active and it is hosted on name servers Azure has programmatic access to
  - `[RegistrationStatus <DomainStatus?>]`: Domain registration status

#### INPUTOBJECT <IAppServiceIdentity>: Identity Parameter
  - `[AnalysisName <String>]`: Analysis Name
  - `[ApiName <String>]`: The managed API name.
  - `[BackupId <String>]`: ID of the backup.
  - `[BaseAddress <String>]`: Module base address.
  - `[CertificateOrderName <String>]`: Name of the certificate order.
  - `[ConnectionName <String>]`: The connection name.
  - `[DeletedSiteId <String>]`: The numeric ID of the deleted app, e.g. 12345
  - `[DetectorName <String>]`: Detector Resource Name
  - `[DiagnosticCategory <String>]`: Diagnostic Category
  - `[DiagnosticsName <String>]`: Name of the diagnostics item.
  - `[DomainName <String>]`: Name of the domain.
  - `[DomainOwnershipIdentifierName <String>]`: Name of domain ownership identifier.
  - `[EntityName <String>]`: Name of the hybrid connection.
  - `[FunctionName <String>]`: Function name.
  - `[GatewayName <String>]`: Name of the gateway. Only the 'primary' gateway is supported.
  - `[HostName <String>]`: Hostname in the hostname binding.
  - `[HostingEnvironmentName <String>]`: Name of the hosting environment.
  - `[Id <String>]`: Resource identity path
  - `[Instance <String>]`: Name of the instance in the multi-role pool.
  - `[InstanceId <String>]`: ID of web app instance.
  - `[Location <String>]`: 
  - `[Name <String>]`: Name of the certificate.
  - `[NamespaceName <String>]`: Name of the Service Bus namespace.
  - `[OperationId <String>]`: GUID of the operation.
  - `[PremierAddOnName <String>]`: Add-on name.
  - `[ProcessId <String>]`: PID.
  - `[PublicCertificateName <String>]`: Public certificate name.
  - `[RelayName <String>]`: Name of the Service Bus relay.
  - `[ResourceGroupName <String>]`: Name of the resource group to which the resource belongs.
  - `[RouteName <String>]`: Name of the Virtual Network route.
  - `[SiteExtensionId <String>]`: Site extension name.
  - `[SiteName <String>]`: Site Name
  - `[Slot <String>]`: Name of web app slot. If not specified then will default to production slot.
  - `[SnapshotId <String>]`: The ID of the snapshot to read.
  - `[SourceControlType <String>]`: Type of source control
  - `[SubscriptionId <String>]`: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[ThreadId <String>]`: TID.
  - `[View <String>]`: The type of view. This can either be "summary" or "detailed".
  - `[VnetName <String>]`: Name of the Virtual Network.
  - `[WebJobName <String>]`: Name of Web Job.
  - `[WorkerName <String>]`: Name of worker machine, which typically starts with RD.
  - `[WorkerPoolName <String>]`: Name of the worker pool.

#### MANAGEDHOSTNAME <IHostName[]>: All hostnames derived from the domain and assigned to Azure resources
  - `[AzureResourceName <String>]`: Name of the Azure resource the hostname is assigned to. If it is assigned to a Traffic Manager then it will be the Traffic Manager name otherwise it will be the app name.
  - `[AzureResourceType <AzureResourceType?>]`: Type of the Azure resource the hostname is assigned to.
  - `[CustomHostNameDnsRecordType <CustomHostNameDnsRecordType?>]`: Type of the DNS record.
  - `[Name <String>]`: Name of the hostname.
  - `[SiteName <String[]>]`: List of apps the hostname is assigned to. This list will have more than one app only if the hostname is pointing to a Traffic Manager.
  - `[Type <HostNameType?>]`: Type of the hostname.

## RELATED LINKS

