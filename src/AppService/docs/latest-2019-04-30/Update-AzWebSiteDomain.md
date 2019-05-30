---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/update-azwebsitedomain
schema: 2.0.0
---

# Update-AzWebSiteDomain

## SYNOPSIS
Creates or updates a domain.

## SYNTAX

### Update (Default)
```
Update-AzWebSiteDomain -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Domain <IDomainPatchResource>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzWebSiteDomain -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -ContactAdminAddressMailingAddress1 <String> -ContactAdminAddressMailingCity <String>
 -ContactAdminAddressMailingCountry <String> -ContactAdminAddressMailingPostalCode <String>
 -ContactAdminAddressMailingState <String> -ContactAdminEmail <String> -ContactAdminNameFirst <String>
 -ContactAdminNameLast <String> -ContactAdminPhone <String> -ContactBillingAddressMailingAddress1 <String>
 -ContactBillingAddressMailingCity <String> -ContactBillingAddressMailingCountry <String>
 -ContactBillingAddressMailingPostalCode <String> -ContactBillingAddressMailingState <String>
 -ContactBillingEmail <String> -ContactBillingNameFirst <String> -ContactBillingNameLast <String>
 -ContactBillingPhone <String> -ContactRegistrantAddressMailingAddress1 <String>
 -ContactRegistrantAddressMailingCity <String> -ContactRegistrantAddressMailingCountry <String>
 -ContactRegistrantAddressMailingPostalCode <String> -ContactRegistrantAddressMailingState <String>
 -ContactRegistrantEmail <String> -ContactRegistrantNameFirst <String> -ContactRegistrantNameLast <String>
 -ContactRegistrantPhone <String> -ContactTechAddressMailingAddress1 <String>
 -ContactTechAddressMailingCity <String> -ContactTechAddressMailingCountry <String>
 -ContactTechAddressMailingPostalCode <String> -ContactTechAddressMailingState <String>
 -ContactTechEmail <String> -ContactTechNameFirst <String> -ContactTechNameLast <String>
 -ContactTechPhone <String> [-AuthCode <String>] [-AutoRenew] [-ConsentAgreedAt <DateTime>]
 [-ConsentAgreedBy <String>] [-ConsentAgreementKey <String[]>] [-ContactAdminAddressMailingAddress2 <String>]
 [-ContactAdminFax <String>] [-ContactAdminJobTitle <String>] [-ContactAdminNameMiddle <String>]
 [-ContactAdminOrganization <String>] [-ContactBillingAddressMailingAddress2 <String>]
 [-ContactBillingFax <String>] [-ContactBillingJobTitle <String>] [-ContactBillingNameMiddle <String>]
 [-ContactBillingOrganization <String>] [-ContactRegistrantAddressMailingAddress2 <String>]
 [-ContactRegistrantFax <String>] [-ContactRegistrantJobTitle <String>]
 [-ContactRegistrantNameMiddle <String>] [-ContactRegistrantOrganization <String>]
 [-ContactTechAddressMailingAddress2 <String>] [-ContactTechFax <String>] [-ContactTechJobTitle <String>]
 [-ContactTechNameMiddle <String>] [-ContactTechOrganization <String>] [-DnsType <DnsType>]
 [-DnsZoneId <String>] [-Kind <String>] [-Privacy] [-ProvisioningState <ProvisioningState>]
 [-RegistrationStatu <DomainStatus>] [-TargetDnsType <DnsType>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWebSiteDomain -InputObject <IWebSiteIdentity> -ContactAdminAddressMailingAddress1 <String>
 -ContactAdminAddressMailingCity <String> -ContactAdminAddressMailingCountry <String>
 -ContactAdminAddressMailingPostalCode <String> -ContactAdminAddressMailingState <String>
 -ContactAdminEmail <String> -ContactAdminNameFirst <String> -ContactAdminNameLast <String>
 -ContactAdminPhone <String> -ContactBillingAddressMailingAddress1 <String>
 -ContactBillingAddressMailingCity <String> -ContactBillingAddressMailingCountry <String>
 -ContactBillingAddressMailingPostalCode <String> -ContactBillingAddressMailingState <String>
 -ContactBillingEmail <String> -ContactBillingNameFirst <String> -ContactBillingNameLast <String>
 -ContactBillingPhone <String> -ContactRegistrantAddressMailingAddress1 <String>
 -ContactRegistrantAddressMailingCity <String> -ContactRegistrantAddressMailingCountry <String>
 -ContactRegistrantAddressMailingPostalCode <String> -ContactRegistrantAddressMailingState <String>
 -ContactRegistrantEmail <String> -ContactRegistrantNameFirst <String> -ContactRegistrantNameLast <String>
 -ContactRegistrantPhone <String> -ContactTechAddressMailingAddress1 <String>
 -ContactTechAddressMailingCity <String> -ContactTechAddressMailingCountry <String>
 -ContactTechAddressMailingPostalCode <String> -ContactTechAddressMailingState <String>
 -ContactTechEmail <String> -ContactTechNameFirst <String> -ContactTechNameLast <String>
 -ContactTechPhone <String> [-AuthCode <String>] [-AutoRenew] [-ConsentAgreedAt <DateTime>]
 [-ConsentAgreedBy <String>] [-ConsentAgreementKey <String[]>] [-ContactAdminAddressMailingAddress2 <String>]
 [-ContactAdminFax <String>] [-ContactAdminJobTitle <String>] [-ContactAdminNameMiddle <String>]
 [-ContactAdminOrganization <String>] [-ContactBillingAddressMailingAddress2 <String>]
 [-ContactBillingFax <String>] [-ContactBillingJobTitle <String>] [-ContactBillingNameMiddle <String>]
 [-ContactBillingOrganization <String>] [-ContactRegistrantAddressMailingAddress2 <String>]
 [-ContactRegistrantFax <String>] [-ContactRegistrantJobTitle <String>]
 [-ContactRegistrantNameMiddle <String>] [-ContactRegistrantOrganization <String>]
 [-ContactTechAddressMailingAddress2 <String>] [-ContactTechFax <String>] [-ContactTechJobTitle <String>]
 [-ContactTechNameMiddle <String>] [-ContactTechOrganization <String>] [-DnsType <DnsType>]
 [-DnsZoneId <String>] [-Kind <String>] [-Privacy] [-ProvisioningState <ProvisioningState>]
 [-RegistrationStatu <DomainStatus>] [-TargetDnsType <DnsType>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzWebSiteDomain -InputObject <IWebSiteIdentity> [-Domain <IDomainPatchResource>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a domain.

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

### -AuthCode
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoRenew
<code>true</code> if the domain should be automatically renewed; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConsentAgreedAt
Timestamp when the agreements were accepted.

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
This list can be retrieved using ListLegalAgreements API under <code>TopLevelDomain</code> resource.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminEmail
Email address.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminFax
Fax number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminJobTitle
Job title.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminNameFirst
First name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminNameLast
Last name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminNameMiddle
Middle name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminOrganization
Organization contact belongs to.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactAdminPhone
Phone number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingEmail
Email address.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingFax
Fax number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingJobTitle
Job title.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingNameFirst
First name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingNameLast
Last name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingNameMiddle
Middle name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingOrganization
Organization contact belongs to.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactBillingPhone
Phone number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantEmail
Email address.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantFax
Fax number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantJobTitle
Job title.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantNameFirst
First name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantNameLast
Last name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantNameMiddle
Middle name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantOrganization
Organization contact belongs to.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactRegistrantPhone
Phone number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechEmail
Email address.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechFax
Fax number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechJobTitle
Job title.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechNameFirst
First name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechNameLast
Last name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechNameMiddle
Middle name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechOrganization
Organization contact belongs to.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContactTechPhone
Phone number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -DnsType
Current DNS type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.DnsType
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DnsZoneId
Azure DNS Zone to use

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Domain
ARM resource for a domain.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150401.IDomainPatchResource
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the domain.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: DomainName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Privacy
<code>true</code> if domain privacy is enabled for this domain; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
Domain provisioning state.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.ProvisioningState
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RegistrationStatu
Domain registration status.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.DomainStatus
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetDnsType
Target DNS type (would be used for migration)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.DnsType
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150401.IDomainPatchResource

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IDomain

## ALIASES

## RELATED LINKS

