---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/remove-azaduser
schema: 2.0.0
---

# Remove-AzADUser

## SYNOPSIS
Deletes entity from users.

## SYNTAX

### UPNOrObjectIdParameterSet (Default)
```
Remove-AzADUser -UPNOrObjectId <String> [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ObjectIdParameterSet
```
Remove-AzADUser -ObjectId <String> [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UPNParameterSet
```
Remove-AzADUser -UserPrincipalName <String> [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DisplayNameParameterSet
```
Remove-AzADUser -DisplayName <String> [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzADUser -InputObject <IMicrosoftGraphUser> [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deletes entity from users.

## EXAMPLES

### Example 1: Remove user by display name
```powershell
PS C:\> Remove-AzADUser -DisplayName $name
```

Remove user by display name

### Example 2: Remove user by pipeline input
```powershell
PS C:\> Get-AzADUser -UserPrincipalName $id | Remove-AzADUser
```

Remove user by pipeline input

## PARAMETERS

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

### -DisplayName
user display name

```yaml
Type: System.String
Parameter Sets: DisplayNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
user input object
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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

### -ObjectId
key: id of user

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

### -UPNOrObjectId
The userPrincipalName or ObjectId of the user to be deleted.

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

### -UserPrincipalName
user principal name

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

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMicrosoftGraphUser>: user input object
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[DeletedDateTime <DateTime?>]`: 
  - `[DisplayName <String>]`: The name displayed in directory
  - `[AccountEnabled <Boolean?>]`: true if the account is enabled; otherwise, false. This property is required when a user is created. Supports $filter (eq, ne, NOT, and in).
  - `[AgeGroup <String>]`: Sets the age group of the user. Allowed values: null, minor, notAdult and adult. Refer to the legal age group property definitions for further information. Supports $filter (eq, ne, NOT, and in).
  - `[ApproximateLastSignInDateTime <DateTime?>]`: The timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only. Supports $filter (eq, ne, not, ge, le, and eq on null values) and $orderBy.
  - `[City <String>]`: The city in which the user is located. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[CompanyName <String>]`: The company name which the user is associated. This property can be useful for describing the company that an external user comes from. The maximum length of the company name is 64 characters.Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[ComplianceExpirationDateTime <DateTime?>]`: The timestamp when the device is no longer deemed compliant. The timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
  - `[ConsentProvidedForMinor <String>]`: Sets whether consent has been obtained for minors. Allowed values: null, granted, denied and notRequired. Refer to the legal age group property definitions for further information. Supports $filter (eq, ne, NOT, and in).
  - `[Country <String>]`: The country/region in which the user is located; for example, US or UK. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[Department <String>]`: The name for the department in which the user works. Maximum length is 64 characters.Supports $filter (eq, ne, NOT , ge, le, and in operators).
  - `[DeviceVersion <Int32?>]`: For internal use only.
  - `[EmployeeHireDate <DateTime?>]`: The date and time when the user was hired or will start work in case of a future hire. Supports $filter (eq, ne, NOT , ge, le, in).
  - `[EmployeeId <String>]`: The employee identifier assigned to the user by the organization. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
  - `[EmployeeType <String>]`: Captures enterprise worker type. For example, Employee, Contractor, Consultant, or Vendor. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
  - `[ExternalUserState <String>]`: For an external user invited to the tenant using the invitation API, this property represents the invited user's invitation status. For invited users, the state can be PendingAcceptance or Accepted, or null for all other users. Supports $filter (eq, ne, NOT , in).
  - `[ExternalUserStateChangeDateTime <DateTime?>]`: Shows the timestamp for the latest change to the externalUserState property. Supports $filter (eq, ne, NOT , in).
  - `[FaxNumber <String>]`: The fax number of the user. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
  - `[GivenName <String>]`: The given name (first name) of the user. Maximum length is 64 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
  - `[Identity <IMicrosoftGraphObjectIdentity[]>]`: Represents the identities that can be used to sign in to this user account. An identity can be provided by Microsoft (also known as a local account), by organizations, or by social identity providers such as Facebook, Google, and Microsoft, and tied to a user account. May contain multiple items with the same signInType value. Supports $filter (eq) only where the signInType is not userPrincipalName.
    - `[Issuer <String>]`: Specifies the issuer of the identity, for example facebook.com.For local accounts (where signInType is not federated), this property is the local B2C tenant default domain name, for example contoso.onmicrosoft.com.For external users from other Azure AD organization, this will be the domain of the federated organization, for example contoso.com.Supports $filter. 512 character limit.
    - `[IssuerAssignedId <String>]`: Specifies the unique identifier assigned to the user by the issuer. The combination of issuer and issuerAssignedId must be unique within the organization. Represents the sign-in name for the user, when signInType is set to emailAddress or userName (also known as local accounts).When signInType is set to: emailAddress, (or a custom string that starts with emailAddress like emailAddress1) issuerAssignedId must be a valid email addressuserName, issuerAssignedId must be a valid local part of an email addressSupports $filter. 100 character limit.
    - `[SignInType <String>]`: Specifies the user sign-in types in your directory, such as emailAddress, userName or federated. Here, federated represents a unique identifier for a user from an issuer, that can be in any format chosen by the issuer. Additional validation is enforced on issuerAssignedId when the sign-in type is set to emailAddress or userName. This property can also be set to any custom string.
  - `[IsResourceAccount <Boolean?>]`: Do not use - reserved for future use.
  - `[JobTitle <String>]`: The user's job title. Maximum length is 128 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
  - `[Mail <String>]`: The SMTP address for the user, for example, admin@contoso.com. Changes to this property will also update the user's proxyAddresses collection to include the value as an SMTP address. While this property can contain accent characters, using them can cause access issues with other Microsoft applications for the user. Supports $filter (eq, ne, NOT, ge, le, in, startsWith, endsWith).
  - `[MailNickname <String>]`: The mail alias for the user. This property must be specified when a user is created. Maximum length is 64 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[OfficeLocation <String>]`: The office location in the user's place of business. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[OnPremisesImmutableId <String>]`: This property is used to associate an on-premises Active Directory user account to their Azure AD user object. This property must be specified when creating a new user account in the Graph if you are using a federated domain for the user's userPrincipalName (UPN) property. NOTE: The $ and _ characters cannot be used when specifying this property. Returned only on $select. Supports $filter (eq, ne, NOT, ge, le, in)..
  - `[OnPremisesLastSyncDateTime <DateTime?>]`: The last time at which the object was synced with the on-premises directory. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z Read-only. Supports $filter (eq, ne, not, ge, le, in).
  - `[OnPremisesSyncEnabled <Boolean?>]`: true if this object is synced from an on-premises directory; false if this object was originally synced from an on-premises directory but is no longer synced; null if this object has never been synced from an on-premises directory (default). Read-only. Supports $filter (eq, ne, not, in, and eq on null values).
  - `[OperatingSystem <String>]`: Operating system of the device. Windows, iOS, etc. This property is read-only.
  - `[OperatingSystemVersion <String>]`: Operating system version of the device. Required. Supports $filter (eq, ne, not, ge, le, startsWith, and eq on null values).
  - `[OtherMail <String[]>]`: A list of additional email addresses for the user; for example: ['bob@contoso.com', 'Robert@fabrikam.com'].NOTE: While this property can contain accent characters, they can cause access issues to first-party applications for the user.Supports $filter (eq, NOT, ge, le, in, startsWith).
  - `[PasswordPolicy <String>]`: Specifies password policies for the user. This value is an enumeration with one possible value being DisableStrongPassword, which allows weaker passwords than the default policy to be specified. DisablePasswordExpiration can also be specified. The two may be specified together; for example: DisablePasswordExpiration, DisableStrongPassword.Supports $filter (ne, NOT).
  - `[PasswordProfile <IMicrosoftGraphPasswordProfile>]`: passwordProfile
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[ForceChangePasswordNextSignIn <Boolean?>]`: true if the user must change her password on the next login; otherwise false. If not set, default is false. NOTE:  For Azure B2C tenants, set to false and instead use custom policies and user flows to force password reset at first sign in. See Force password reset at first logon.
    - `[ForceChangePasswordNextSignInWithMfa <Boolean?>]`: If true, at next sign-in, the user must perform a multi-factor authentication (MFA) before being forced to change their password. The behavior is identical to forceChangePasswordNextSignIn except that the user is required to first perform a multi-factor authentication before password change. After a password change, this property will be automatically reset to false. If not set, default is false.
    - `[Password <String>]`: The password for the user. This property is required when a user is created. It can be updated, but the user will be required to change the password on the next login. The password must satisfy minimum requirements as specified by the user's passwordPolicies property. By default, a strong password is required.
  - `[PhysicalId <String[]>]`: For internal use only. Not nullable. Supports $filter (eq, not, ge, le, startsWith).
  - `[PostalCode <String>]`: The postal code for the user's postal address. The postal code is specific to the user's country/region. In the United States of America, this attribute contains the ZIP code. Maximum length is 40 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[PreferredLanguage <String>]`: The preferred language for the user. Should follow ISO 639-1 Code; for example en-US. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[ShowInAddressList <Boolean?>]`: true if the Outlook global address list should contain this user, otherwise false. If not set, this will be treated as true. For users invited through the invitation manager, this property will be set to false. Supports $filter (eq, ne, NOT, in).
  - `[State <String>]`: The state or province in the user's address. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[StreetAddress <String>]`: The street address of the user's place of business. Maximum length is 1024 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[Surname <String>]`: The user's surname (family name or last name). Maximum length is 64 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[TrustType <String>]`: Type of trust for the joined device. Read-only. Possible values: Workplace (indicates bring your own personal devices), AzureAd (Cloud only joined devices), ServerAd (on-premises domain joined devices joined to Azure AD). For more details, see Introduction to device management in Azure Active Directory
  - `[UsageLocation <String>]`: A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement to check for availability of services in countries.  Examples include: US, JP, and GB. Not nullable. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[UserPrincipalName <String>]`: The user principal name (UPN) of the user. The UPN is an Internet-style login name for the user based on the Internet standard RFC 822. By convention, this should map to the user's email name. The general format is alias@domain, where domain must be present in the tenant's collection of verified domains. This property is required when a user is created. The verified domains for the tenant can be accessed from the verifiedDomains property of organization.NOTE: While this property can contain accent characters, they can cause access issues to first-party applications for the user. Supports $filter (eq, ne, NOT, ge, le, in, startsWith, endsWith) and $orderBy.
  - `[UserType <String>]`: A string value that can be used to classify user types in your directory, such as Member and Guest. Supports $filter (eq, ne, NOT, in,).

## RELATED LINKS

## RELATED LINKS
