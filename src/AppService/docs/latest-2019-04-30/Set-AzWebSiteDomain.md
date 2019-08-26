---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/set-azwebsitedomain
schema: 2.0.0
---

# Set-AzWebSiteDomain

## SYNOPSIS
Creates or updates a domain.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzWebSiteDomain -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Location <String>
 [-AuthCode <String>] [-AutoRenew] [-ConsentAgreedAt <DateTime>] [-ConsentAgreedBy <String>]
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
 [-DnsType <DnsType>] [-DnsZoneId <String>] [-Kind <String>] [-Privacy] [-Tag <Hashtable>]
 [-TargetDnsType <DnsType>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzWebSiteDomain -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Domain <IDomain>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Dynamic: False
```

### -AuthCode
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoRenew
\<code\>true\</code\> if the domain should be automatically renewed; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

### -DnsType
Current DNS type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.DnsType
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Domain
Information about a domain.
To construct, see NOTES section for DOMAIN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IDomain
Parameter Sets: Update
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource Location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
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
Parameter Sets: (All)
Aliases: DomainName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Privacy
\<code\>true\</code\> if domain privacy is enabled for this domain; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IDomain

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IDomain

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### DOMAIN <IDomain>: Information about a domain.
  - `Location <String>`: Resource Location.
  - `ContactAdminAddressMailingAddress1 <String>`: First line of an Address.
  - `ContactAdminAddressMailingCity <String>`: The city for the address.
  - `ContactAdminAddressMailingCountry <String>`: The country for the address.
  - `ContactAdminAddressMailingPostalCode <String>`: The postal code for the address.
  - `ContactAdminAddressMailingState <String>`: The state or province for the address.
  - `ContactAdminEmail <String>`: Email address.
  - `ContactAdminNameFirst <String>`: First name.
  - `ContactAdminNameLast <String>`: Last name.
  - `ContactAdminPhone <String>`: Phone number.
  - `ContactBillingAddressMailingAddress1 <String>`: First line of an Address.
  - `ContactBillingAddressMailingCity <String>`: The city for the address.
  - `ContactBillingAddressMailingCountry <String>`: The country for the address.
  - `ContactBillingAddressMailingPostalCode <String>`: The postal code for the address.
  - `ContactBillingAddressMailingState <String>`: The state or province for the address.
  - `ContactBillingEmail <String>`: Email address.
  - `ContactBillingNameFirst <String>`: First name.
  - `ContactBillingNameLast <String>`: Last name.
  - `ContactBillingPhone <String>`: Phone number.
  - `ContactRegistrantAddressMailingAddress1 <String>`: First line of an Address.
  - `ContactRegistrantAddressMailingCity <String>`: The city for the address.
  - `ContactRegistrantAddressMailingCountry <String>`: The country for the address.
  - `ContactRegistrantAddressMailingPostalCode <String>`: The postal code for the address.
  - `ContactRegistrantAddressMailingState <String>`: The state or province for the address.
  - `ContactRegistrantEmail <String>`: Email address.
  - `ContactRegistrantNameFirst <String>`: First name.
  - `ContactRegistrantNameLast <String>`: Last name.
  - `ContactRegistrantPhone <String>`: Phone number.
  - `ContactTechAddressMailingAddress1 <String>`: First line of an Address.
  - `ContactTechAddressMailingCity <String>`: The city for the address.
  - `ContactTechAddressMailingCountry <String>`: The country for the address.
  - `ContactTechAddressMailingPostalCode <String>`: The postal code for the address.
  - `ContactTechAddressMailingState <String>`: The state or province for the address.
  - `ContactTechEmail <String>`: Email address.
  - `ContactTechNameFirst <String>`: First name.
  - `ContactTechNameLast <String>`: Last name.
  - `ContactTechPhone <String>`: Phone number.
  - `[Kind <String>]`: Kind of resource.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AuthCode <String>]`: 
  - `[AutoRenew <Boolean?>]`: <code>true</code> if the domain should be automatically renewed; otherwise, <code>false</code>.
  - `[ConsentAgreedAt <DateTime?>]`: Timestamp when the agreements were accepted.
  - `[ConsentAgreedBy <String>]`: Client IP address.
  - `[ConsentAgreementKey <String[]>]`: List of applicable legal agreement keys. This list can be retrieved using ListLegalAgreements API under <code>TopLevelDomain</code> resource.
  - `[ContactAdminAddressMailingAddress2 <String>]`: The second line of the Address. Optional.
  - `[ContactAdminFax <String>]`: Fax number.
  - `[ContactAdminJobTitle <String>]`: Job title.
  - `[ContactAdminNameMiddle <String>]`: Middle name.
  - `[ContactAdminOrganization <String>]`: Organization contact belongs to.
  - `[ContactBillingAddressMailingAddress2 <String>]`: The second line of the Address. Optional.
  - `[ContactBillingFax <String>]`: Fax number.
  - `[ContactBillingJobTitle <String>]`: Job title.
  - `[ContactBillingNameMiddle <String>]`: Middle name.
  - `[ContactBillingOrganization <String>]`: Organization contact belongs to.
  - `[ContactRegistrantAddressMailingAddress2 <String>]`: The second line of the Address. Optional.
  - `[ContactRegistrantFax <String>]`: Fax number.
  - `[ContactRegistrantJobTitle <String>]`: Job title.
  - `[ContactRegistrantNameMiddle <String>]`: Middle name.
  - `[ContactRegistrantOrganization <String>]`: Organization contact belongs to.
  - `[ContactTechAddressMailingAddress2 <String>]`: The second line of the Address. Optional.
  - `[ContactTechFax <String>]`: Fax number.
  - `[ContactTechJobTitle <String>]`: Job title.
  - `[ContactTechNameMiddle <String>]`: Middle name.
  - `[ContactTechOrganization <String>]`: Organization contact belongs to.
  - `[DnsType <DnsType?>]`: Current DNS type
  - `[DnsZoneId <String>]`: Azure DNS Zone to use
  - `[Privacy <Boolean?>]`: <code>true</code> if domain privacy is enabled for this domain; otherwise, <code>false</code>.
  - `[TargetDnsType <DnsType?>]`: Target DNS type (would be used for migration)

## RELATED LINKS

