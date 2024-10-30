---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azaduser
schema: 2.0.0
---

# Update-AzADUser

## SYNOPSIS
Updates entity in users

## SYNTAX

### UPNOrObjectIdParameterSet (Default)
```
Update-AzADUser -UPNOrObjectId <String> [-AccountEnabled <Boolean>] [-Password <SecureString>]
 [-ForceChangePasswordNextLogin] [-AgeGroup <String>] [-City <String>] [-CompanyName <String>]
 [-ConsentProvidedForMinor <String>] [-Country <String>] [-DeletedDateTime <DateTime>] [-Department <String>]
 [-DisplayName <String>] [-EmployeeHireDate <DateTime>] [-EmployeeId <String>] [-EmployeeType <String>]
 [-ExternalUserState <String>] [-ExternalUserStateChangeDateTime <DateTime>] [-FaxNumber <String>]
 [-GivenName <String>] [-Id <String>] [-Identity <IMicrosoftGraphObjectIdentity[]>] [-IsResourceAccount]
 [-JobTitle <String>] [-Mail <String>] [-MailNickname <String>] [-OfficeLocation <String>]
 [-OnPremisesImmutableId <String>] [-OtherMail <String[]>] [-PasswordPolicy <String>]
 [-PasswordProfile <IMicrosoftGraphPasswordProfile>] [-PostalCode <String>] [-PreferredLanguage <String>]
 [-ShowInAddressList] [-State <String>] [-StreetAddress <String>] [-Surname <String>] [-UsageLocation <String>]
 [-UserType <String>] [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ObjectIdParameterSet
```
Update-AzADUser [-AccountEnabled <Boolean>] [-Password <SecureString>] [-ForceChangePasswordNextLogin]
 [-AgeGroup <String>] [-City <String>] [-CompanyName <String>] [-ConsentProvidedForMinor <String>]
 [-Country <String>] [-DeletedDateTime <DateTime>] [-Department <String>] [-DisplayName <String>]
 [-EmployeeHireDate <DateTime>] [-EmployeeId <String>] [-EmployeeType <String>] [-ExternalUserState <String>]
 [-ExternalUserStateChangeDateTime <DateTime>] [-FaxNumber <String>] [-GivenName <String>] [-Id <String>]
 [-Identity <IMicrosoftGraphObjectIdentity[]>] [-IsResourceAccount] [-JobTitle <String>] [-Mail <String>]
 [-MailNickname <String>] [-OfficeLocation <String>] [-OnPremisesImmutableId <String>] [-OtherMail <String[]>]
 [-PasswordPolicy <String>] [-PasswordProfile <IMicrosoftGraphPasswordProfile>] [-PostalCode <String>]
 [-PreferredLanguage <String>] [-ShowInAddressList] [-State <String>] [-StreetAddress <String>]
 [-Surname <String>] [-UsageLocation <String>] [-UserType <String>] -ObjectId <String>
 [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Update-AzADUser [-AccountEnabled <Boolean>] [-Password <SecureString>] [-ForceChangePasswordNextLogin]
 [-AgeGroup <String>] [-City <String>] [-CompanyName <String>] [-ConsentProvidedForMinor <String>]
 [-Country <String>] [-DeletedDateTime <DateTime>] [-Department <String>] [-DisplayName <String>]
 [-EmployeeHireDate <DateTime>] [-EmployeeId <String>] [-EmployeeType <String>] [-ExternalUserState <String>]
 [-ExternalUserStateChangeDateTime <DateTime>] [-FaxNumber <String>] [-GivenName <String>] [-Id <String>]
 [-Identity <IMicrosoftGraphObjectIdentity[]>] [-IsResourceAccount] [-JobTitle <String>] [-Mail <String>]
 [-MailNickname <String>] [-OfficeLocation <String>] [-OnPremisesImmutableId <String>] [-OtherMail <String[]>]
 [-PasswordPolicy <String>] [-PasswordProfile <IMicrosoftGraphPasswordProfile>] [-PostalCode <String>]
 [-PreferredLanguage <String>] [-ShowInAddressList] [-State <String>] [-StreetAddress <String>]
 [-Surname <String>] [-UsageLocation <String>] [-UserType <String>] -InputObject <IMicrosoftGraphUser>
 [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UPNParameterSet
```
Update-AzADUser [-AccountEnabled <Boolean>] [-Password <SecureString>] [-ForceChangePasswordNextLogin]
 [-AgeGroup <String>] [-City <String>] [-CompanyName <String>] [-ConsentProvidedForMinor <String>]
 [-Country <String>] [-DeletedDateTime <DateTime>] [-Department <String>] [-DisplayName <String>]
 [-EmployeeHireDate <DateTime>] [-EmployeeId <String>] [-EmployeeType <String>] [-ExternalUserState <String>]
 [-ExternalUserStateChangeDateTime <DateTime>] [-FaxNumber <String>] [-GivenName <String>] [-Id <String>]
 [-Identity <IMicrosoftGraphObjectIdentity[]>] [-IsResourceAccount] [-JobTitle <String>] [-Mail <String>]
 [-MailNickname <String>] [-OfficeLocation <String>] [-OnPremisesImmutableId <String>] [-OtherMail <String[]>]
 [-PasswordPolicy <String>] [-PasswordProfile <IMicrosoftGraphPasswordProfile>] [-PostalCode <String>]
 [-PreferredLanguage <String>] [-ShowInAddressList] [-State <String>] [-StreetAddress <String>]
 [-Surname <String>] [-UsageLocation <String>] [-UserType <String>] -UserPrincipalName <String>
 [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates entity in users

## EXAMPLES

### Example 1: Update user by user principal name
```powershell
Update-AzADUser -UPNOrObjectId $upn -City $city
```

Update user by user principal name

## PARAMETERS

### -AccountEnabled
true for enabling the account; otherwise, false.
Always true when combined with `-Password`.
`-AccountEnabled $false` is ignored when changing the account's password.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases: EnableAccount

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgeGroup
Sets the age group of the user.
Allowed values: null, minor, notAdult and adult.
Refer to the legal age group property definitions for further information.
Supports $filter (eq, ne, NOT, and in).

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

### -City
The city in which the user is located.
Maximum length is 128 characters.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -CompanyName
The company name which the user is associated.
This property can be useful for describing the company that an external user comes from.
The maximum length of the company name is 64 characters.Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -ConsentProvidedForMinor
Sets whether consent has been obtained for minors.
Allowed values: null, granted, denied and notRequired.
Refer to the legal age group property definitions for further information.
Supports $filter (eq, ne, NOT, and in).

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

### -Country
The country/region in which the user is located; for example, US or UK.
Maximum length is 128 characters.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeletedDateTime
.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Department
The name for the department in which the user works.
Maximum length is 64 characters.Supports $filter (eq, ne, NOT , ge, le, and in operators).

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

### -DisplayName
The name displayed in the address book for the user.
This value is usually the combination of the user's first name, middle initial, and last name.
This property is required when a user is created and it cannot be cleared during updates.
Maximum length is 256 characters.
Supports $filter (eq, ne, NOT , ge, le, in, startsWith), $orderBy, and $search.

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

### -EmployeeHireDate
The date and time when the user was hired or will start work in case of a future hire.
Supports $filter (eq, ne, NOT , ge, le, in).

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmployeeId
The employee identifier assigned to the user by the organization.
Supports $filter (eq, ne, NOT , ge, le, in, startsWith).

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

### -EmployeeType
Captures enterprise worker type.
For example, Employee, Contractor, Consultant, or Vendor.
Supports $filter (eq, ne, NOT , ge, le, in, startsWith).

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

### -ExternalUserState
For an external user invited to the tenant using the invitation API, this property represents the invited user's invitation status.
For invited users, the state can be PendingAcceptance or Accepted, or null for all other users.
Supports $filter (eq, ne, NOT , in).

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

### -ExternalUserStateChangeDateTime
Shows the timestamp for the latest change to the externalUserState property.
Supports $filter (eq, ne, NOT , in).

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FaxNumber
The fax number of the user.
Supports $filter (eq, ne, NOT , ge, le, in, startsWith).

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

### -ForceChangePasswordNextLogin
It must be specified if the user must change the password on the next successful login (true).
Default behavior is (false) to not change the password on the next successful login.

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

### -GivenName
The given name (first name) of the user.
Maximum length is 64 characters.
Supports $filter (eq, ne, NOT , ge, le, in, startsWith).

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

### -Id
Read-only.

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

### -Identity
Represents the identities that can be used to sign in to this user account.
An identity can be provided by Microsoft (also known as a local account), by organizations, or by social identity providers such as Facebook, Google, and Microsoft, and tied to a user account.
May contain multiple items with the same signInType value.
Supports $filter (eq) only where the signInType is not userPrincipalName.
To construct, see NOTES section for IDENTITY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphObjectIdentity[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
user input object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphUser
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsResourceAccount
Do not use - reserved for future use.

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

### -JobTitle
The user's job title.
Maximum length is 128 characters.
Supports $filter (eq, ne, NOT , ge, le, in, startsWith).

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

### -Mail
The SMTP address for the user, for example, admin@contoso.com.
Changes to this property will also update the user's proxyAddresses collection to include the value as an SMTP address.
While this property can contain accent characters, using them can cause access issues with other Microsoft applications for the user.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith, endsWith).

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

### -MailNickname
The mail alias for the user.
This property must be specified when a user is created.
Maximum length is 64 characters.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -ObjectId
The user principal name of the user to be updated.

```yaml
Type: System.String
Parameter Sets: ObjectIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfficeLocation
The office location in the user's place of business.
Maximum length is 128 characters.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -OnPremisesImmutableId
This property is used to associate an on-premises Active Directory user account to their Azure AD user object.
This property must be specified when creating a new user account in the Graph if you are using a federated domain for the user's userPrincipalName (UPN) property.
NOTE: The $ and _ characters cannot be used when specifying this property.
Returned only on $select.
Supports $filter (eq, ne, NOT, ge, le, in)..

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

### -OtherMail
A list of additional email addresses for the user; for example: ['bob@contoso.com', 'Robert@fabrikam.com'].NOTE: While this property can contain accent characters, they can cause access issues to first-party applications for the user.Supports $filter (eq, NOT, ge, le, in, startsWith).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -Password
The password for the user.
This property is required when a user is created.

It can be updated, but the user will be required to change the password on the next login.

The password must satisfy minimum requirements as speci./fied by the user's passwordPolicies property.
By default, a strong password is required.
When changing the password using this method, AccountEnabled is set to true.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PasswordPolicy
Specifies password policies for the user.
This value is an enumeration with one possible value being DisableStrongPassword, which allows weaker passwords than the default policy to be specified.
DisablePasswordExpiration can also be specified.
The two may be specified together; for example: DisablePasswordExpiration, DisableStrongPassword.Supports $filter (ne, NOT).

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

### -PasswordProfile
passwordProfile
To construct, see NOTES section for PASSWORDPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PostalCode
The postal code for the user's postal address.
The postal code is specific to the user's country/region.
In the United States of America, this attribute contains the ZIP code.
Maximum length is 40 characters.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -PreferredLanguage
The preferred language for the user.
Should follow ISO 639-1 Code; for example en-US.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowInAddressList
true if the Outlook global address list should contain this user, otherwise false.
If not set, this will be treated as true.
For users invited through the invitation manager, this property will be set to false.
Supports $filter (eq, ne, NOT, in).

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

### -State
The state or province in the user's address.
Maximum length is 128 characters.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -StreetAddress
The street address of the user's place of business.
Maximum length is 1024 characters.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -Surname
The user's surname (family name or last name).
Maximum length is 64 characters.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -UPNOrObjectId
The user principal name or object id of the user to be updated.

```yaml
Type: System.String
Parameter Sets: UPNOrObjectIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsageLocation
A two letter country code (ISO standard 3166).
Required for users that will be assigned licenses due to legal requirement to check for availability of services in countries.
Examples include: US, JP, and GB.
Not nullable.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith).

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

### -UserPrincipalName
The user principal name (UPN) of the user.
The UPN is an Internet-style login name for the user based on the Internet standard RFC 822.
By convention, this should map to the user's email name.
The general format is alias@domain, where domain must be present in the tenant's collection of verified domains.
This property is required when a user is created.
The verified domains for the tenant can be accessed from the verifiedDomains property of organization.NOTE: While this property can contain accent characters, they can cause access issues to first-party applications for the user.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith, endsWith) and $orderBy.

```yaml
Type: System.String
Parameter Sets: UPNParameterSet
Aliases: UPN

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserType
A string value that can be used to classify user types in your directory, such as Member and Guest.
Supports $filter (eq, ne, NOT, in,).

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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphUser

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

Set-AzADUser

## RELATED LINKS
