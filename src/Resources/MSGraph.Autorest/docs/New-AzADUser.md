---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azaduser
schema: 2.0.0
---

# New-AzADUser

## SYNOPSIS
Adds new entity to users

## SYNTAX

### WithPassword (Default)
```
New-AzADUser -DisplayName <String> -MailNickname <String> -Password <SecureString> -UserPrincipalName <String>
 [-AboutMe <String>] [-AccountEnabled <Boolean>] [-AgeGroup <String>] [-Birthday <DateTime>] [-City <String>]
 [-CompanyName <String>] [-ConsentProvidedForMinor <String>] [-Country <String>] [-DeletedDateTime <DateTime>]
 [-Department <String>] [-DeviceEnrollmentLimit <Int32>] [-EmployeeHireDate <DateTime>] [-EmployeeId <String>]
 [-EmployeeType <String>] [-ExternalUserState <String>] [-ExternalUserStateChangeDateTime <DateTime>]
 [-FaxNumber <String>] [-ForceChangePasswordNextLogin] [-GivenName <String>] [-HireDate <DateTime>]
 [-ImmutableId <String>] [-Interest <String[]>] [-IsResourceAccount] [-JobTitle <String>] [-Mail <String>]
 [-MobilePhone <String>] [-MySite <String>] [-OfficeLocation <String>] [-OtherMail <String[]>]
 [-PasswordPolicy <String>] [-PostalCode <String>] [-PreferredLanguage <String>] [-PreferredName <String>]
 [-Responsibility <String[]>] [-School <String[]>] [-ShowInAddressList] [-Skill <String[]>] [-State <String>]
 [-StreetAddress <String>] [-Surname <String>] [-UsageLocation <String>] [-UserType <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### WithPasswordProfile
```
New-AzADUser -DisplayName <String> -MailNickname <String> -PasswordProfile <IMicrosoftGraphPasswordProfile>
 -UserPrincipalName <String> [-AboutMe <String>] [-AccountEnabled <Boolean>] [-AgeGroup <String>]
 [-Birthday <DateTime>] [-City <String>] [-CompanyName <String>] [-ConsentProvidedForMinor <String>]
 [-Country <String>] [-DeletedDateTime <DateTime>] [-Department <String>] [-DeviceEnrollmentLimit <Int32>]
 [-EmployeeHireDate <DateTime>] [-EmployeeId <String>] [-EmployeeType <String>] [-ExternalUserState <String>]
 [-ExternalUserStateChangeDateTime <DateTime>] [-FaxNumber <String>] [-GivenName <String>]
 [-HireDate <DateTime>] [-ImmutableId <String>] [-Interest <String[]>] [-IsResourceAccount]
 [-JobTitle <String>] [-Mail <String>] [-MobilePhone <String>] [-MySite <String>] [-OfficeLocation <String>]
 [-OtherMail <String[]>] [-PasswordPolicy <String>] [-PostalCode <String>] [-PreferredLanguage <String>]
 [-PreferredName <String>] [-Responsibility <String[]>] [-School <String[]>] [-ShowInAddressList]
 [-Skill <String[]>] [-State <String>] [-StreetAddress <String>] [-Surname <String>] [-UsageLocation <String>]
 [-UserType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Adds new entity to users

## EXAMPLES

### Example 1: Create user with password profile
```powershell
$password = "xxxxxxxxxx"
$pp = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordProfile" -Property @{Password=$password}
New-AzADUser -DisplayName $uname -PasswordProfile $pp -AccountEnabled $true -MailNickname $nickname -UserPrincipalName $upn
```

Create user with password profile

### Example 2: Create user with password
```powershell
$password = "xxxxxxxxxx"
$password = ConvertTo-SecureString -AsPlainText -Force $password
New-AzADUser -DisplayName $uname -Password $password -AccountEnabled $true -MailNickname $nickname -UserPrincipalName $upn
```

Create user with password

## PARAMETERS

### -AboutMe
A freeform text entry field for the user to describe themselves.
Returned only on $select.

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

### -AccountEnabled
true for enabling the account; otherwise, false.

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

### -Birthday
The birthday of the user.
The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time.
For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z Returned only on $select.

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

### -DeviceEnrollmentLimit
The limit on the maximum number of devices that the user is permitted to enroll.
Allowed values are 5 or 1000.

```yaml
Type: System.Int32
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

Required: True
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
Parameter Sets: WithPassword
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

### -HireDate
The hire date of the user.
The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time.
For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.
Returned only on $select.
Note: This property is specific to SharePoint Online.
We recommend using the native employeeHireDate property to set and update hire date values using Microsoft Graph APIs.

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

### -ImmutableId
This property is used to associate an on-premises Active Directory user account to their Azure AD user object.
This property must be specified when creating a new user account in the Graph if you are using a federated domain for the user's userPrincipalName (UPN) property.
NOTE: The $ and _ characters cannot be used when specifying this property.
Returned only on $select.
Supports $filter (eq, ne, NOT, ge, le, in)..

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: OnPremisesImmutableId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Interest
A list for the user to describe their interests.
Returned only on $select.

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

### -IsResourceAccount
Do not use – reserved for future use.

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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MobilePhone
The primary cellular telephone number for the user.
Read-only for users synced from on-premises directory.
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

### -MySite
The URL for the user's personal site.
Returned only on $select.

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

### -Password
Password for the user.
It must meet the tenant's password complexity requirements.
It is recommended to set a strong password.

```yaml
Type: System.Security.SecureString
Parameter Sets: WithPassword
Aliases:

Required: True
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
Parameter Sets: WithPasswordProfile
Aliases:

Required: True
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

### -PreferredName
The preferred name for the user.
Returned only on $select.

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

### -Responsibility
A list for the user to enumerate their responsibilities.
Returned only on $select.

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

### -School
A list for the user to enumerate the schools they have attended.
Returned only on $select.

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

### -Skill
A list for the user to enumerate their skills.
Returned only on $select.

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
Parameter Sets: (All)
Aliases:

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphUser

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PASSWORDPROFILE <IMicrosoftGraphPasswordProfile>: passwordProfile
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ForceChangePasswordNextSignIn <Boolean?>]`: true if the user must change her password on the next login; otherwise false. If not set, default is false. NOTE:  For Azure B2C tenants, set to false and instead use custom policies and user flows to force password reset at first sign in. See Force password reset at first logon.
  - `[ForceChangePasswordNextSignInWithMfa <Boolean?>]`: If true, at next sign-in, the user must perform a multi-factor authentication (MFA) before being forced to change their password. The behavior is identical to forceChangePasswordNextSignIn except that the user is required to first perform a multi-factor authentication before password change. After a password change, this property will be automatically reset to false. If not set, default is false.
  - `[Password <String>]`: The password for the user. This property is required when a user is created. It can be updated, but the user will be required to change the password on the next login. The password must satisfy minimum requirements as specified by the user’s passwordPolicies property. By default, a strong password is required.

## RELATED LINKS

