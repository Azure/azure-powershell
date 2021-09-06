---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/new-azmguser
schema: 2.0.0
---

# New-AzMgUser

## SYNOPSIS
Add new entity to users

## SYNTAX

### CreateExpanded (Default)
```
New-AzMgUser [-AboutMe <String>] [-AccountEnabled] [-AgeGroup <String>]
 [-AppRoleAssignment <IMicrosoftGraphAppRoleAssignment1[]>]
 [-AssignedLicense <IMicrosoftGraphAssignedLicense1[]>] [-Authentication <IMicrosoftGraphAuthentication>]
 [-Birthday <DateTime>] [-Calendar <IMicrosoftGraphCalendar1>] [-Chat <IMicrosoftGraphChat[]>]
 [-City <String>] [-CompanyName <String>] [-ConsentProvidedForMinor <String>] [-Country <String>]
 [-DeletedDateTime <DateTime>] [-Department <String>] [-DeviceEnrollmentLimit <Int32>]
 [-DeviceManagementTroubleshootingEvent <IMicrosoftGraphDeviceManagementTroubleshootingEvent1[]>]
 [-DisplayName <String>] [-Drive <IMicrosoftGraphDrive1>] [-EmployeeHireDate <DateTime>]
 [-EmployeeId <String>] [-EmployeeOrgData <IMicrosoftGraphEmployeeOrgData1>] [-EmployeeType <String>]
 [-Extension <IMicrosoftGraphExtension1[]>] [-ExternalUserState <String>]
 [-ExternalUserStateChangeDateTime <DateTime>] [-FaxNumber <String>] [-FollowedSite <IMicrosoftGraphSite1[]>]
 [-GivenName <String>] [-HireDate <DateTime>] [-Id <String>] [-Identity <IMicrosoftGraphObjectIdentity1[]>]
 [-InferenceClassification <IMicrosoftGraphInferenceClassification1>]
 [-Insight <IMicrosoftGraphOfficeGraphInsights1>] [-Interest <String[]>] [-IsResourceAccount]
 [-JobTitle <String>] [-Mail <String>] [-MailboxSetting <IMicrosoftGraphMailboxSettings1>]
 [-MailNickname <String>] [-ManagedAppRegistration <IMicrosoftGraphManagedAppRegistration1[]>]
 [-ManagedDevice <IMicrosoftGraphManagedDevice1[]>] [-Manager <IMicrosoftGraphDirectoryObject>]
 [-MobilePhone <String>] [-MySite <String>] [-Oauth2PermissionGrant <IMicrosoftGraphOAuth2PermissionGrant1[]>]
 [-OfficeLocation <String>] [-Onenote <IMicrosoftGraphOnenote1>]
 [-OnlineMeeting <IMicrosoftGraphOnlineMeeting1[]>]
 [-OnPremisesExtensionAttribute <IMicrosoftGraphOnPremisesExtensionAttributes1>]
 [-OnPremisesImmutableId <String>]
 [-OnPremisesProvisioningError <IMicrosoftGraphOnPremisesProvisioningError1[]>] [-OtherMail <String[]>]
 [-Outlook <IMicrosoftGraphOutlookUser1>] [-PasswordPolicy <String>]
 [-PasswordProfile <IMicrosoftGraphPasswordProfile1>] [-PastProject <String[]>]
 [-Photo <IMicrosoftGraphProfilePhoto1>] [-Planner <IMicrosoftGraphPlannerUser1>] [-PostalCode <String>]
 [-PreferredLanguage <String>] [-PreferredName <String>] [-Presence <IMicrosoftGraphPresence>]
 [-Responsibility <String[]>] [-School <String[]>] [-Setting <IMicrosoftGraphUserSettings1>]
 [-ShowInAddressList] [-Skill <String[]>] [-State <String>] [-StreetAddress <String>] [-Surname <String>]
 [-Teamwork <IMicrosoftGraphUserTeamwork>] [-Todo <IMicrosoftGraphTodo1>]
 [-TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>] [-UsageLocation <String>]
 [-UserPrincipalName <String>] [-UserType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzMgUser -Body <IMicrosoftGraphUser> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Add new entity to users

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

### -AboutMe
A freeform text entry field for the user to describe themselves.
Returned only on $select.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccountEnabled
true if the account is enabled; otherwise, false.
This property is required when a user is created.
Supports $filter (eq, ne, NOT, and in).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppRoleAssignment
Represents the app roles a user has been granted for an application.
Supports $expand.
To construct, see NOTES section for APPROLEASSIGNMENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAppRoleAssignment1[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignedLicense
The licenses that are assigned to the user, including inherited (group-based) licenses.
Not nullable.
Supports $filter (eq and NOT).
To construct, see NOTES section for ASSIGNEDLICENSE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAssignedLicense1[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Authentication
authentication
To construct, see NOTES section for AUTHENTICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAuthentication
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Represents an Azure Active Directory user object.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphUser
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Calendar
calendar
To construct, see NOTES section for CALENDAR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphCalendar1
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Chat
.
To construct, see NOTES section for CHAT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphChat[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### -DeletedDateTime
.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceManagementTroubleshootingEvent
The list of troubleshooting events for this user.
To construct, see NOTES section for DEVICEMANAGEMENTTROUBLESHOOTINGEVENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphDeviceManagementTroubleshootingEvent1[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Drive
drive
To construct, see NOTES section for DRIVE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphDrive1
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmployeeOrgData
employeeOrgData
To construct, see NOTES section for EMPLOYEEORGDATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphEmployeeOrgData1
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Extension
The collection of open extensions defined for the user.
Nullable.
To construct, see NOTES section for EXTENSION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphExtension1[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FollowedSite
.
To construct, see NOTES section for FOLLOWEDSITE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphSite1[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphObjectIdentity1[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InferenceClassification
inferenceClassification
To construct, see NOTES section for INFERENCECLASSIFICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphInferenceClassification1
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Insight
officeGraphInsights
To construct, see NOTES section for INSIGHT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphOfficeGraphInsights1
Parameter Sets: CreateExpanded
Aliases:

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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MailboxSetting
mailboxSettings
To construct, see NOTES section for MAILBOXSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphMailboxSettings1
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedAppRegistration
Zero or more managed app registrations that belong to the user.
To construct, see NOTES section for MANAGEDAPPREGISTRATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphManagedAppRegistration1[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedDevice
The managed devices associated with the user.
To construct, see NOTES section for MANAGEDDEVICE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphManagedDevice1[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Manager
Represents an Azure Active Directory object.
The directoryObject type is the base type for many other directory entity types.
To construct, see NOTES section for MANAGER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphDirectoryObject
Parameter Sets: CreateExpanded
Aliases:

Required: False
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Oauth2PermissionGrant
.
To construct, see NOTES section for OAUTH2PERMISSIONGRANT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphOAuth2PermissionGrant1[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Onenote
onenote
To construct, see NOTES section for ONENOTE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphOnenote1
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OnlineMeeting
.
To construct, see NOTES section for ONLINEMEETING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphOnlineMeeting1[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OnPremisesExtensionAttribute
onPremisesExtensionAttributes
To construct, see NOTES section for ONPREMISESEXTENSIONATTRIBUTE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphOnPremisesExtensionAttributes1
Parameter Sets: CreateExpanded
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
Note: The $ and _ characters cannot be used when specifying this property.
Supports $filter (eq, ne, NOT, ge, le, in).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OnPremisesProvisioningError
Errors when using Microsoft synchronization product during provisioning.
Supports $filter (eq, NOT, ge, le).
To construct, see NOTES section for ONPREMISESPROVISIONINGERROR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphOnPremisesProvisioningError1[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Outlook
outlookUser
To construct, see NOTES section for OUTLOOK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphOutlookUser1
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordProfile1
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PastProject
A list for the user to enumerate their past projects.
Returned only on $select.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Photo
profilePhoto
To construct, see NOTES section for PHOTO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphProfilePhoto1
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Planner
plannerUser
To construct, see NOTES section for PLANNER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPlannerUser1
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Presence
presence
To construct, see NOTES section for PRESENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPresence
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Setting
userSettings
To construct, see NOTES section for SETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphUserSettings1
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Teamwork
userTeamwork
To construct, see NOTES section for TEAMWORK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphUserTeamwork
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Todo
todo
To construct, see NOTES section for TODO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphTodo1
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TransitiveMemberOf
.
To construct, see NOTES section for TRANSITIVEMEMBEROF properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphDirectoryObject[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphUser

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


APPROLEASSIGNMENT <IMicrosoftGraphAppRoleAssignment1[]>: Represents the app roles a user has been granted for an application. Supports $expand.
  - `[DeletedDateTime <DateTime?>]`: 
  - `[Id <String>]`: Read-only.
  - `[AppRoleId <String>]`: The identifier (id) for the app role which is assigned to the principal. This app role must be exposed in the appRoles property on the resource application's service principal (resourceId). If the resource application has not declared any app roles, a default app role ID of 00000000-0000-0000-0000-000000000000 can be specified to signal that the principal is assigned to the resource app without any specific app roles. Required on create.
  - `[CreatedDateTime <DateTime?>]`: The time when the app role assignment was created.The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
  - `[PrincipalDisplayName <String>]`: The display name of the user, group, or service principal that was granted the app role assignment. Read-only. Supports $filter (eq and startswith).
  - `[PrincipalId <String>]`: The unique identifier (id) for the user, group or service principal being granted the app role. Required on create.
  - `[PrincipalType <String>]`: The type of the assigned principal. This can either be User, Group or ServicePrincipal. Read-only.
  - `[ResourceDisplayName <String>]`: The display name of the resource app's service principal to which the assignment is made.
  - `[ResourceId <String>]`: The unique identifier (id) for the resource service principal for which the assignment is made. Required on create. Supports $filter (eq only).

ASSIGNEDLICENSE <IMicrosoftGraphAssignedLicense1[]>: The licenses that are assigned to the user, including inherited (group-based) licenses. Not nullable. Supports $filter (eq and NOT).
  - `[DisabledPlan <String[]>]`: A collection of the unique identifiers for plans that have been disabled.
  - `[SkuId <String>]`: The unique identifier for the SKU.

AUTHENTICATION <IMicrosoftGraphAuthentication>: authentication
  - `[Id <String>]`: Read-only.
  - `[Fido2Method <IMicrosoftGraphFido2AuthenticationMethod1[]>]`: 
    - `[Id <String>]`: Read-only.
    - `[AaGuid <String>]`: Authenticator Attestation GUID, an identifier that indicates the type (e.g. make and model) of the authenticator.
    - `[AttestationCertificate <String[]>]`: The attestation certificate(s) attached to this security key.
    - `[AttestationLevel <String>]`: attestationLevel
    - `[CreatedDateTime <DateTime?>]`: The timestamp when this key was registered to the user.
    - `[DisplayName <String>]`: The display name of the key as given by the user.
    - `[Model <String>]`: The manufacturer-assigned model of the FIDO2 security key.
  - `[Method <IMicrosoftGraphAuthenticationMethod1[]>]`: 
    - `[Id <String>]`: Read-only.
  - `[MicrosoftAuthenticatorMethod <IMicrosoftGraphMicrosoftAuthenticatorAuthenticationMethod1[]>]`: 
    - `[Id <String>]`: Read-only.
    - `[CreatedDateTime <DateTime?>]`: The date and time that this app was registered. This property is null if the device is not registered for passwordless Phone Sign-In.
    - `[Device <IMicrosoftGraphDevice1>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[DeletedDateTime <DateTime?>]`: 
      - `[Id <String>]`: Read-only.
      - `[AccountEnabled <Boolean?>]`: true if the account is enabled; otherwise, false. Default is true. Supports $filter (eq, ne, NOT, in).
      - `[AlternativeSecurityId <IMicrosoftGraphAlternativeSecurityId1[]>]`: For internal use only. Not nullable. Supports $filter (eq, NOT, ge, le).
        - `[IdentityProvider <String>]`: For internal use only
        - `[Key <Byte[]>]`: For internal use only
        - `[Type <Int32?>]`: For internal use only
      - `[ApproximateLastSignInDateTime <DateTime?>]`: The timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only. Supports $filter (eq, ne, NOT, ge, le) and $orderBy.
      - `[ComplianceExpirationDateTime <DateTime?>]`: The timestamp when the device is no longer deemed compliant. The timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
      - `[DeviceId <String>]`: Identifier set by Azure Device Registration Service at the time of registration. Supports $filter (eq, ne, NOT, startsWith).
      - `[DeviceMetadata <String>]`: For internal use only. Set to null.
      - `[DeviceVersion <Int32?>]`: For internal use only.
      - `[DisplayName <String>]`: The display name for the device. Required. Supports $filter (eq, ne, NOT, ge, le, in, startsWith), $search, and $orderBy.
      - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the device. Read-only. Nullable.
        - `[Id <String>]`: Read-only.
      - `[IsCompliant <Boolean?>]`: true if the device complies with Mobile Device Management (MDM) policies; otherwise, false. Read-only. This can only be updated by Intune for any device OS type or by an approved MDM app for Windows OS devices. Supports $filter (eq, ne, NOT).
      - `[IsManaged <Boolean?>]`: true if the device is managed by a Mobile Device Management (MDM) app; otherwise, false. This can only be updated by Intune for any device OS type or by an approved MDM app for Windows OS devices. Supports $filter (eq, ne, NOT).
      - `[MdmAppId <String>]`: Application identifier used to register device into MDM. Read-only. Supports $filter (eq, ne, NOT, startsWith).
      - `[MemberOf <IMicrosoftGraphDirectoryObject[]>]`: Groups that this device is a member of. Read-only. Nullable. Supports $expand.
        - `[Id <String>]`: Read-only.
        - `[DeletedDateTime <DateTime?>]`: 
      - `[OnPremisesLastSyncDateTime <DateTime?>]`: The last time at which the object was synced with the on-premises directory. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z Read-only. Supports $filter (eq, ne, NOT, ge, le, in).
      - `[OnPremisesSyncEnabled <Boolean?>]`: true if this object is synced from an on-premises directory; false if this object was originally synced from an on-premises directory but is no longer synced; null if this object has never been synced from an on-premises directory (default). Read-only. Supports $filter (eq, ne, NOT, in).
      - `[OperatingSystem <String>]`: The type of operating system on the device. Required. Supports $filter (eq, ne, NOT, ge, le, startsWith).
      - `[OperatingSystemVersion <String>]`: Operating system version of the device. Required. Supports $filter (eq, ne, NOT, ge, le, startsWith).
      - `[PhysicalId <String[]>]`: For internal use only. Not nullable. Supports $filter (eq, NOT, ge, le, startsWith).
      - `[ProfileType <String>]`: The profile type of the device. Possible values: RegisteredDevice (default), SecureVM, Printer, Shared, IoT.
      - `[RegisteredOwner <IMicrosoftGraphDirectoryObject[]>]`: The user that cloud joined the device or registered their personal device. The registered owner is set at the time of registration. Currently, there can be only one owner. Read-only. Nullable. Supports $expand.
      - `[RegisteredUser <IMicrosoftGraphDirectoryObject[]>]`: Collection of registered users of the device. For cloud joined devices and registered personal devices, registered users are set to the same value as registered owners at the time of registration. Read-only. Nullable. Supports $expand.
      - `[SystemLabel <String[]>]`: List of labels applied to the device by the system.
      - `[TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>]`: Groups that this device is a member of. This operation is transitive. Supports $expand.
      - `[TrustType <String>]`: Type of trust for the joined device. Read-only. Possible values: Workplace (indicates bring your own personal devices), AzureAd (Cloud only joined devices), ServerAd (on-premises domain joined devices joined to Azure AD). For more details, see Introduction to device management in Azure Active Directory
    - `[DeviceTag <String>]`: Tags containing app metadata.
    - `[DisplayName <String>]`: The name of the device on which this app is registered.
    - `[PhoneAppVersion <String>]`: Numerical version of this instance of the Authenticator app.
  - `[WindowsHelloForBusinessMethod <IMicrosoftGraphWindowsHelloForBusinessAuthenticationMethod1[]>]`: 
    - `[Id <String>]`: Read-only.
    - `[CreatedDateTime <DateTime?>]`: The date and time that this Windows Hello for Business key was registered.
    - `[Device <IMicrosoftGraphDevice1>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
    - `[DisplayName <String>]`: The name of the device on which Windows Hello for Business is registered
    - `[KeyStrength <String>]`: authenticationMethodKeyStrength

BODY <IMicrosoftGraphUser>: Represents an Azure Active Directory user object.
  - `[DeletedDateTime <DateTime?>]`: 
  - `[Id <String>]`: Read-only.
  - `[AboutMe <String>]`: A freeform text entry field for the user to describe themselves. Returned only on $select.
  - `[AccountEnabled <Boolean?>]`: true if the account is enabled; otherwise, false. This property is required when a user is created. Supports $filter (eq, ne, NOT, and in).
  - `[AgeGroup <String>]`: Sets the age group of the user. Allowed values: null, minor, notAdult and adult. Refer to the legal age group property definitions for further information. Supports $filter (eq, ne, NOT, and in).
  - `[AppRoleAssignment <IMicrosoftGraphAppRoleAssignment1[]>]`: Represents the app roles a user has been granted for an application. Supports $expand.
    - `[DeletedDateTime <DateTime?>]`: 
    - `[Id <String>]`: Read-only.
    - `[AppRoleId <String>]`: The identifier (id) for the app role which is assigned to the principal. This app role must be exposed in the appRoles property on the resource application's service principal (resourceId). If the resource application has not declared any app roles, a default app role ID of 00000000-0000-0000-0000-000000000000 can be specified to signal that the principal is assigned to the resource app without any specific app roles. Required on create.
    - `[CreatedDateTime <DateTime?>]`: The time when the app role assignment was created.The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
    - `[PrincipalDisplayName <String>]`: The display name of the user, group, or service principal that was granted the app role assignment. Read-only. Supports $filter (eq and startswith).
    - `[PrincipalId <String>]`: The unique identifier (id) for the user, group or service principal being granted the app role. Required on create.
    - `[PrincipalType <String>]`: The type of the assigned principal. This can either be User, Group or ServicePrincipal. Read-only.
    - `[ResourceDisplayName <String>]`: The display name of the resource app's service principal to which the assignment is made.
    - `[ResourceId <String>]`: The unique identifier (id) for the resource service principal for which the assignment is made. Required on create. Supports $filter (eq only).
  - `[AssignedLicense <IMicrosoftGraphAssignedLicense1[]>]`: The licenses that are assigned to the user, including inherited (group-based) licenses. Not nullable. Supports $filter (eq and NOT).
    - `[DisabledPlan <String[]>]`: A collection of the unique identifiers for plans that have been disabled.
    - `[SkuId <String>]`: The unique identifier for the SKU.
  - `[Authentication <IMicrosoftGraphAuthentication>]`: authentication
    - `[Id <String>]`: Read-only.
    - `[Fido2Method <IMicrosoftGraphFido2AuthenticationMethod1[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[AaGuid <String>]`: Authenticator Attestation GUID, an identifier that indicates the type (e.g. make and model) of the authenticator.
      - `[AttestationCertificate <String[]>]`: The attestation certificate(s) attached to this security key.
      - `[AttestationLevel <String>]`: attestationLevel
      - `[CreatedDateTime <DateTime?>]`: The timestamp when this key was registered to the user.
      - `[DisplayName <String>]`: The display name of the key as given by the user.
      - `[Model <String>]`: The manufacturer-assigned model of the FIDO2 security key.
    - `[Method <IMicrosoftGraphAuthenticationMethod1[]>]`: 
      - `[Id <String>]`: Read-only.
    - `[MicrosoftAuthenticatorMethod <IMicrosoftGraphMicrosoftAuthenticatorAuthenticationMethod1[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[CreatedDateTime <DateTime?>]`: The date and time that this app was registered. This property is null if the device is not registered for passwordless Phone Sign-In.
      - `[Device <IMicrosoftGraphDevice1>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DeletedDateTime <DateTime?>]`: 
        - `[Id <String>]`: Read-only.
        - `[AccountEnabled <Boolean?>]`: true if the account is enabled; otherwise, false. Default is true. Supports $filter (eq, ne, NOT, in).
        - `[AlternativeSecurityId <IMicrosoftGraphAlternativeSecurityId1[]>]`: For internal use only. Not nullable. Supports $filter (eq, NOT, ge, le).
          - `[IdentityProvider <String>]`: For internal use only
          - `[Key <Byte[]>]`: For internal use only
          - `[Type <Int32?>]`: For internal use only
        - `[ApproximateLastSignInDateTime <DateTime?>]`: The timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only. Supports $filter (eq, ne, NOT, ge, le) and $orderBy.
        - `[ComplianceExpirationDateTime <DateTime?>]`: The timestamp when the device is no longer deemed compliant. The timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
        - `[DeviceId <String>]`: Identifier set by Azure Device Registration Service at the time of registration. Supports $filter (eq, ne, NOT, startsWith).
        - `[DeviceMetadata <String>]`: For internal use only. Set to null.
        - `[DeviceVersion <Int32?>]`: For internal use only.
        - `[DisplayName <String>]`: The display name for the device. Required. Supports $filter (eq, ne, NOT, ge, le, in, startsWith), $search, and $orderBy.
        - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the device. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
        - `[IsCompliant <Boolean?>]`: true if the device complies with Mobile Device Management (MDM) policies; otherwise, false. Read-only. This can only be updated by Intune for any device OS type or by an approved MDM app for Windows OS devices. Supports $filter (eq, ne, NOT).
        - `[IsManaged <Boolean?>]`: true if the device is managed by a Mobile Device Management (MDM) app; otherwise, false. This can only be updated by Intune for any device OS type or by an approved MDM app for Windows OS devices. Supports $filter (eq, ne, NOT).
        - `[MdmAppId <String>]`: Application identifier used to register device into MDM. Read-only. Supports $filter (eq, ne, NOT, startsWith).
        - `[MemberOf <IMicrosoftGraphDirectoryObject[]>]`: Groups that this device is a member of. Read-only. Nullable. Supports $expand.
          - `[Id <String>]`: Read-only.
          - `[DeletedDateTime <DateTime?>]`: 
        - `[OnPremisesLastSyncDateTime <DateTime?>]`: The last time at which the object was synced with the on-premises directory. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z Read-only. Supports $filter (eq, ne, NOT, ge, le, in).
        - `[OnPremisesSyncEnabled <Boolean?>]`: true if this object is synced from an on-premises directory; false if this object was originally synced from an on-premises directory but is no longer synced; null if this object has never been synced from an on-premises directory (default). Read-only. Supports $filter (eq, ne, NOT, in).
        - `[OperatingSystem <String>]`: The type of operating system on the device. Required. Supports $filter (eq, ne, NOT, ge, le, startsWith).
        - `[OperatingSystemVersion <String>]`: Operating system version of the device. Required. Supports $filter (eq, ne, NOT, ge, le, startsWith).
        - `[PhysicalId <String[]>]`: For internal use only. Not nullable. Supports $filter (eq, NOT, ge, le, startsWith).
        - `[ProfileType <String>]`: The profile type of the device. Possible values: RegisteredDevice (default), SecureVM, Printer, Shared, IoT.
        - `[RegisteredOwner <IMicrosoftGraphDirectoryObject[]>]`: The user that cloud joined the device or registered their personal device. The registered owner is set at the time of registration. Currently, there can be only one owner. Read-only. Nullable. Supports $expand.
        - `[RegisteredUser <IMicrosoftGraphDirectoryObject[]>]`: Collection of registered users of the device. For cloud joined devices and registered personal devices, registered users are set to the same value as registered owners at the time of registration. Read-only. Nullable. Supports $expand.
        - `[SystemLabel <String[]>]`: List of labels applied to the device by the system.
        - `[TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>]`: Groups that this device is a member of. This operation is transitive. Supports $expand.
        - `[TrustType <String>]`: Type of trust for the joined device. Read-only. Possible values: Workplace (indicates bring your own personal devices), AzureAd (Cloud only joined devices), ServerAd (on-premises domain joined devices joined to Azure AD). For more details, see Introduction to device management in Azure Active Directory
      - `[DeviceTag <String>]`: Tags containing app metadata.
      - `[DisplayName <String>]`: The name of the device on which this app is registered.
      - `[PhoneAppVersion <String>]`: Numerical version of this instance of the Authenticator app.
    - `[WindowsHelloForBusinessMethod <IMicrosoftGraphWindowsHelloForBusinessAuthenticationMethod1[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[CreatedDateTime <DateTime?>]`: The date and time that this Windows Hello for Business key was registered.
      - `[Device <IMicrosoftGraphDevice1>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
      - `[DisplayName <String>]`: The name of the device on which Windows Hello for Business is registered
      - `[KeyStrength <String>]`: authenticationMethodKeyStrength
  - `[Birthday <DateTime?>]`: The birthday of the user. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z Returned only on $select.
  - `[Calendar <IMicrosoftGraphCalendar1>]`: calendar
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Id <String>]`: Read-only.
    - `[AllowedOnlineMeetingProvider <String[]>]`: Represent the online meeting service providers that can be used to create online meetings in this calendar. Possible values are: unknown, skypeForBusiness, skypeForConsumer, teamsForBusiness.
    - `[CalendarPermission <IMicrosoftGraphCalendarPermission1[]>]`: The permissions of the users with whom the calendar is shared.
      - `[Id <String>]`: Read-only.
      - `[AllowedRole <String[]>]`: List of allowed sharing or delegating permission levels for the calendar. Possible values are: none, freeBusyRead, limitedRead, read, write, delegateWithoutPrivateEventAccess, delegateWithPrivateEventAccess, custom.
      - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Address <String>]`: The email address of an entity instance.
        - `[Name <String>]`: The display name of an entity instance.
      - `[IsInsideOrganization <Boolean?>]`: True if the user in context (sharee or delegate) is inside the same organization as the calendar owner.
      - `[IsRemovable <Boolean?>]`: True if the user can be removed from the list of sharees or delegates for the specified calendar, false otherwise. The 'My organization' user determines the permissions other people within your organization have to the given calendar. You cannot remove 'My organization' as a sharee to a calendar.
      - `[Role <String>]`: calendarRoleType
    - `[CalendarView <IMicrosoftGraphEvent1[]>]`: The calendar view for the calendar. Navigation property. Read-only.
      - `[Category <String[]>]`: The categories associated with the item
      - `[ChangeKey <String>]`: Identifies the version of the item. Every time the item is changed, changeKey changes as well. This allows Exchange to apply changes to the correct version of the object. Read-only.
      - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
      - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
      - `[Id <String>]`: Read-only.
      - `[AllowNewTimeProposal <Boolean?>]`: True if the meeting organizer allows invitees to propose a new time when responding, false otherwise. Optional. Default is true.
      - `[Attachment <IMicrosoftGraphAttachment1[]>]`: The collection of FileAttachment, ItemAttachment, and referenceAttachment attachments for the event. Navigation property. Read-only. Nullable.
        - `[Id <String>]`: Read-only.
        - `[ContentType <String>]`: The MIME type.
        - `[IsInline <Boolean?>]`: true if the attachment is an inline attachment; otherwise, false.
        - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[Name <String>]`: The display name of the attachment. This does not need to be the actual file name.
        - `[Size <Int32?>]`: The length of the attachment in bytes.
      - `[Attendee <IMicrosoftGraphAttendee1[]>]`: The collection of attendees for the event.
        - `[Type <String>]`: attendeeType
        - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
        - `[ProposedNewTime <IMicrosoftGraphTimeSlot1>]`: timeSlot
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[End <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[DateTime <String>]`: A single point of time in a combined date and time representation ({date}T{time}). For example, '2019-04-16T09:00:00'.
            - `[TimeZone <String>]`: Represents a time zone, for example, 'Pacific Standard Time'. See below for possible values.
          - `[Start <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[Status <IMicrosoftGraphResponseStatus1>]`: responseStatus
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Response <String>]`: responseType
          - `[Time <DateTime?>]`: The date and time that the response was returned. It uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
      - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Content <String>]`: The content of the item.
        - `[ContentType <String>]`: bodyType
      - `[BodyPreview <String>]`: The preview of the message associated with the event. It is in text format.
      - `[Calendar <IMicrosoftGraphCalendar1>]`: calendar
      - `[End <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
      - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the event. Nullable.
      - `[HasAttachment <Boolean?>]`: Set to true if the event has attachments.
      - `[HideAttendee <Boolean?>]`: When set to true, each attendee only sees themselves in the meeting request and meeting Tracking list. Default is false.
      - `[ICalUid <String>]`: A unique identifier for an event across calendars. This ID is different for each occurrence in a recurring series. Read-only.
      - `[Importance <String>]`: importance
      - `[Instance <IMicrosoftGraphEvent1[]>]`: The occurrences of a recurring series, if the event is a series master. This property includes occurrences that are part of the recurrence pattern, and exceptions that have been modified, but does not include occurrences that have been cancelled from the series. Navigation property. Read-only. Nullable.
      - `[IsAllDay <Boolean?>]`: Set to true if the event lasts all day.
      - `[IsCancelled <Boolean?>]`: Set to true if the event has been canceled.
      - `[IsDraft <Boolean?>]`: Set to true if the user has updated the meeting in Outlook but has not sent the updates to attendees. Set to false if all changes have been sent, or if the event is an appointment without any attendees.
      - `[IsOnlineMeeting <Boolean?>]`: True if this event has online meeting information, false otherwise. Default is false. Optional.
      - `[IsOrganizer <Boolean?>]`: Set to true if the calendar owner (specified by the owner property of the calendar) is the organizer of the event (specified by the organizer property of the event). This also applies if a delegate organized the event on behalf of the owner.
      - `[IsReminderOn <Boolean?>]`: Set to true if an alert is set to remind the user of the event.
      - `[Location <IMicrosoftGraphLocation1[]>]`: The locations where the event is held or attended from. The location and locations properties always correspond with each other. If you update the location property, any prior locations in the locations collection would be removed and replaced by the new location value.
        - `[Address <IMicrosoftGraphPhysicalAddress1>]`: physicalAddress
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[City <String>]`: The city.
          - `[CountryOrRegion <String>]`: The country or region. It's a free-format string value, for example, 'United States'.
          - `[PostalCode <String>]`: The postal code.
          - `[State <String>]`: The state.
          - `[Street <String>]`: The street.
        - `[Coordinate <IMicrosoftGraphOutlookGeoCoordinates1>]`: outlookGeoCoordinates
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Accuracy <Double?>]`: The accuracy of the latitude and longitude. As an example, the accuracy can be measured in meters, such as the latitude and longitude are accurate to within 50 meters.
          - `[Altitude <Double?>]`: The altitude of the location.
          - `[AltitudeAccuracy <Double?>]`: The accuracy of the altitude.
          - `[Latitude <Double?>]`: The latitude of the location.
          - `[Longitude <Double?>]`: The longitude of the location.
        - `[DisplayName <String>]`: The name associated with the location.
        - `[LocationEmailAddress <String>]`: Optional email address of the location.
        - `[LocationType <String>]`: locationType
        - `[LocationUri <String>]`: Optional URI representing the location.
        - `[UniqueId <String>]`: For internal use only.
        - `[UniqueIdType <String>]`: locationUniqueIdType
      - `[Location1 <IMicrosoftGraphLocation1>]`: location
      - `[MultiValueExtendedProperty <IMicrosoftGraphMultiValueLegacyExtendedProperty1[]>]`: The collection of multi-value extended properties defined for the event. Read-only. Nullable.
        - `[Id <String>]`: Read-only.
        - `[Value <String[]>]`: A collection of property values.
      - `[OnlineMeeting <IMicrosoftGraphOnlineMeetingInfo1>]`: onlineMeetingInfo
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ConferenceId <String>]`: The ID of the conference.
        - `[JoinUrl <String>]`: The external link that launches the online meeting. This is a URL that clients will launch into a browser and will redirect the user to join the meeting.
        - `[Phone <IMicrosoftGraphPhone1[]>]`: All of the phone numbers associated with this conference.
          - `[Language <String>]`: 
          - `[Number <String>]`: The phone number.
          - `[Region <String>]`: 
          - `[Type <String>]`: phoneType
        - `[QuickDial <String>]`: The pre-formatted quickdial for this call.
        - `[TollFreeNumber <String[]>]`: The toll free numbers that can be used to join the conference.
        - `[TollNumber <String>]`: The toll number that can be used to join the conference.
      - `[OnlineMeetingProvider <String>]`: onlineMeetingProviderType
      - `[OnlineMeetingUrl <String>]`: A URL for an online meeting. The property is set only when an organizer specifies an event as an online meeting such as a Skype meeting. Read-only.
      - `[Organizer <IMicrosoftGraphRecipient1>]`: recipient
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
      - `[OriginalEndTimeZone <String>]`: The end time zone that was set when the event was created. A value of tzone://Microsoft/Custom indicates that a legacy custom time zone was set in desktop Outlook.
      - `[OriginalStart <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
      - `[OriginalStartTimeZone <String>]`: The start time zone that was set when the event was created. A value of tzone://Microsoft/Custom indicates that a legacy custom time zone was set in desktop Outlook.
      - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Pattern <IMicrosoftGraphRecurrencePattern1>]`: recurrencePattern
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DayOfMonth <Int32?>]`: The day of the month on which the event occurs. Required if type is absoluteMonthly or absoluteYearly.
          - `[DaysOfWeek <String[]>]`: A collection of the days of the week on which the event occurs. Possible values are: sunday, monday, tuesday, wednesday, thursday, friday, saturday. If type is relativeMonthly or relativeYearly, and daysOfWeek specifies more than one day, the event falls on the first day that satisfies the pattern.  Required if type is weekly, relativeMonthly, or relativeYearly.
          - `[FirstDayOfWeek <String>]`: dayOfWeek
          - `[Index <String>]`: weekIndex
          - `[Interval <Int32?>]`: The number of units between occurrences, where units can be in days, weeks, months, or years, depending on the type. Required.
          - `[Month <Int32?>]`: The month in which the event occurs.  This is a number from 1 to 12.
          - `[Type <String>]`: recurrencePatternType
        - `[Range <IMicrosoftGraphRecurrenceRange1>]`: recurrenceRange
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[EndDate <DateTime?>]`: The date to stop applying the recurrence pattern. Depending on the recurrence pattern of the event, the last occurrence of the meeting may not be this date. Required if type is endDate.
          - `[NumberOfOccurrence <Int32?>]`: The number of times to repeat the event. Required and must be positive if type is numbered.
          - `[RecurrenceTimeZone <String>]`: Time zone for the startDate and endDate properties. Optional. If not specified, the time zone of the event is used.
          - `[StartDate <DateTime?>]`: The date to start applying the recurrence pattern. The first occurrence of the meeting may be this date or later, depending on the recurrence pattern of the event. Must be the same value as the start property of the recurring event. Required.
          - `[Type <String>]`: recurrenceRangeType
      - `[ReminderMinutesBeforeStart <Int32?>]`: The number of minutes before the event start time that the reminder alert occurs.
      - `[ResponseRequested <Boolean?>]`: Default is true, which represents the organizer would like an invitee to send a response to the event.
      - `[ResponseStatus <IMicrosoftGraphResponseStatus1>]`: responseStatus
      - `[Sensitivity <String>]`: sensitivity
      - `[SeriesMasterId <String>]`: The ID for the recurring series master item, if this event is part of a recurring series.
      - `[ShowAs <String>]`: freeBusyStatus
      - `[SingleValueExtendedProperty <IMicrosoftGraphSingleValueLegacyExtendedProperty1[]>]`: The collection of single-value extended properties defined for the event. Read-only. Nullable.
        - `[Id <String>]`: Read-only.
        - `[Value <String>]`: A property value.
      - `[Start <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
      - `[Subject <String>]`: The text of the event's subject line.
      - `[TransactionId <String>]`: A custom identifier specified by a client app for the server to avoid redundant POST operations in case of client retries to create the same event. This is useful when low network connectivity causes the client to time out before receiving a response from the server for the client's prior create-event request. After you set transactionId when creating an event, you cannot change transactionId in a subsequent update. This property is only returned in a response payload if an app has set it. Optional.
      - `[Type <String>]`: eventType
      - `[WebLink <String>]`: The URL to open the event in Outlook on the web.Outlook on the web opens the event in the browser if you are signed in to your mailbox. Otherwise, Outlook on the web prompts you to sign in.This URL cannot be accessed from within an iFrame.
    - `[CanEdit <Boolean?>]`: true if the user can write to the calendar, false otherwise. This property is true for the user who created the calendar. This property is also true for a user who has been shared a calendar and granted write access, through an Outlook client or the corresponding calendarPermission resource. Read-only.
    - `[CanShare <Boolean?>]`: true if the user has the permission to share the calendar, false otherwise. Only the user who created the calendar can share it. Read-only.
    - `[CanViewPrivateItem <Boolean?>]`: true if the user can read calendar items that have been marked private, false otherwise. This property is set through an Outlook client or the corresponding calendarPermission resource. Read-only.
    - `[ChangeKey <String>]`: Identifies the version of the calendar object. Every time the calendar is changed, changeKey changes as well. This allows Exchange to apply changes to the correct version of the object. Read-only.
    - `[Color <String>]`: calendarColor
    - `[DefaultOnlineMeetingProvider <String>]`: onlineMeetingProviderType
    - `[Event <IMicrosoftGraphEvent1[]>]`: The events in the calendar. Navigation property. Read-only.
    - `[HexColor <String>]`: The calendar color, expressed in a hex color code of three hexadecimal values, each ranging from 00 to FF and representing the red, green, or blue components of the color in the RGB color space. If the user has never explicitly set a color for the calendar, this property is  empty.
    - `[IsDefaultCalendar <Boolean?>]`: true if this is the default calendar where new events are created by default, false otherwise.
    - `[IsRemovable <Boolean?>]`: Indicates whether this user calendar can be deleted from the user mailbox.
    - `[IsTallyingResponse <Boolean?>]`: Indicates whether this user calendar supports tracking of meeting responses. Only meeting invites sent from users' primary calendars support tracking of meeting responses.
    - `[MultiValueExtendedProperty <IMicrosoftGraphMultiValueLegacyExtendedProperty1[]>]`: The collection of multi-value extended properties defined for the calendar. Read-only. Nullable.
    - `[Name <String>]`: The calendar name.
    - `[Owner <IMicrosoftGraphEmailAddress1>]`: emailAddress
    - `[SingleValueExtendedProperty <IMicrosoftGraphSingleValueLegacyExtendedProperty1[]>]`: The collection of single-value extended properties defined for the calendar. Read-only. Nullable.
  - `[Chat <IMicrosoftGraphChat[]>]`: 
    - `[Id <String>]`: Read-only.
    - `[ChatType <String>]`: chatType
    - `[CreatedDateTime <DateTime?>]`: Date and time at which the chat was created. Read-only.
    - `[InstalledApp <IMicrosoftGraphTeamsAppInstallation1[]>]`: A collection of all the apps in the chat. Nullable.
      - `[Id <String>]`: Read-only.
      - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Id <String>]`: Read-only.
        - `[AppDefinition <IMicrosoftGraphTeamsAppDefinition1[]>]`: The details for each version of the app.
          - `[Id <String>]`: Read-only.
          - `[Bot <IMicrosoftGraphTeamworkBot1>]`: teamworkBot
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Id <String>]`: Read-only.
          - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Application <IMicrosoftGraphIdentity1>]`: identity
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
              - `[Id <String>]`: Unique identifier for the identity.
            - `[Device <IMicrosoftGraphIdentity1>]`: identity
            - `[User <IMicrosoftGraphIdentity1>]`: identity
          - `[Description <String>]`: Verbose description of the application.
          - `[DisplayName <String>]`: The name of the app provided by the app developer.
          - `[LastModifiedDateTime <DateTime?>]`: 
          - `[PublishingState <String>]`: teamsAppPublishingState
          - `[ShortDescription <String>]`: Short description of the application.
          - `[TeamsAppId <String>]`: The ID from the Teams app manifest.
          - `[Version <String>]`: The version number of the application.
        - `[DisplayName <String>]`: The name of the catalog app provided by the app developer in the Microsoft Teams zip app package.
        - `[DistributionMethod <String>]`: teamsAppDistributionMethod
        - `[ExternalId <String>]`: The ID of the catalog provided by the app developer in the Microsoft Teams zip app package.
      - `[TeamsAppDefinition <IMicrosoftGraphTeamsAppDefinition1>]`: teamsAppDefinition
    - `[LastUpdatedDateTime <DateTime?>]`: Date and time at which the chat was renamed or list of members were last changed. Read-only.
    - `[Member <IMicrosoftGraphConversationMember1[]>]`: A collection of all the members in the chat. Nullable.
      - `[Id <String>]`: Read-only.
      - `[DisplayName <String>]`: The display name of the user.
      - `[Role <String[]>]`: The roles for that user.
      - `[VisibleHistoryStartDateTime <DateTime?>]`: The timestamp denoting how far back a conversation's history is shared with the conversation member. This property is settable only for members of a chat.
    - `[Message <IMicrosoftGraphChatMessage1[]>]`: A collection of all the messages in the chat. Nullable.
      - `[Id <String>]`: Read-only.
      - `[Attachment <IMicrosoftGraphChatMessageAttachment1[]>]`: Attached files. Attachments are currently read-only – sending attachments is not supported.
        - `[Content <String>]`: The content of the attachment. If the attachment is a rich card, set the property to the rich card object. This property and contentUrl are mutually exclusive.
        - `[ContentType <String>]`: The media type of the content attachment. It can have the following values: reference: Attachment is a link to another file. Populate the contentURL with the link to the object.Any contentTypes supported by the Bot Framework's Attachment objectapplication/vnd.microsoft.card.codesnippet: A code snippet. application/vnd.microsoft.card.announcement: An announcement header.
        - `[ContentUrl <String>]`: URL for the content of the attachment. Supported protocols: http, https, file and data.
        - `[Id <String>]`: Read-only. Unique id of the attachment.
        - `[Name <String>]`: Name of the attachment.
        - `[ThumbnailUrl <String>]`: URL to a thumbnail image that the channel can use if it supports using an alternative, smaller form of content or contentUrl. For example, if you set contentType to application/word and set contentUrl to the location of the Word document, you might include a thumbnail image that represents the document. The channel could display the thumbnail image instead of the document. When the user clicks the image, the channel would open the document.
      - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
      - `[ChannelIdentity <IMicrosoftGraphChannelIdentity1>]`: channelIdentity
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ChannelId <String>]`: The identity of the channel in which the message was posted.
        - `[TeamId <String>]`: The identity of the team in which the message was posted.
      - `[ChatId <String>]`: If the message was sent in a chat, represents the identity of the chat.
      - `[CreatedDateTime <DateTime?>]`: Timestamp of when the chat message was created.
      - `[DeletedDateTime <DateTime?>]`: Read only. Timestamp at which the chat message was deleted, or null if not deleted.
      - `[Etag <String>]`: Read-only. Version number of the chat message.
      - `[From <IMicrosoftGraphChatMessageFromIdentitySet1>]`: chatMessageFromIdentitySet
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Application <IMicrosoftGraphIdentity1>]`: identity
        - `[Device <IMicrosoftGraphIdentity1>]`: identity
        - `[User <IMicrosoftGraphIdentity1>]`: identity
      - `[HostedContent <IMicrosoftGraphChatMessageHostedContent1[]>]`: Content in a message hosted by Microsoft Teams - for example, images or code snippets.
        - `[ContentByte <Byte[]>]`: Write only. Bytes for the hosted content (such as images).
        - `[ContentType <String>]`: Write only. Content type, such as image/png, image/jpg.
        - `[Id <String>]`: Read-only.
      - `[Importance <String>]`: chatMessageImportance
      - `[LastEditedDateTime <DateTime?>]`: Read only. Timestamp when edits to the chat message were made. Triggers an 'Edited' flag in the Teams UI. If no edits are made the value is null.
      - `[LastModifiedDateTime <DateTime?>]`: Read only. Timestamp when the chat message is created (initial setting) or modified, including when a reaction is added or removed.
      - `[Locale <String>]`: Locale of the chat message set by the client. Always set to en-us.
      - `[Mention <IMicrosoftGraphChatMessageMention1[]>]`: List of entities mentioned in the chat message. Currently supports user, bot, team, channel.
        - `[Id <Int32?>]`: Index of an entity being mentioned in the specified chatMessage. Matches the {index} value in the corresponding <at id='{index}'> tag in the message body.
        - `[MentionText <String>]`: String used to represent the mention. For example, a user's display name, a team name.
        - `[Mentioned <IMicrosoftGraphChatMessageMentionedIdentitySet1>]`: chatMessageMentionedIdentitySet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Application <IMicrosoftGraphIdentity1>]`: identity
          - `[Device <IMicrosoftGraphIdentity1>]`: identity
          - `[User <IMicrosoftGraphIdentity1>]`: identity
          - `[Conversation <IMicrosoftGraphTeamworkConversationIdentity1>]`: teamworkConversationIdentity
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
            - `[Id <String>]`: Unique identifier for the identity.
            - `[ConversationIdentityType <String>]`: teamworkConversationIdentityType
      - `[MessageType <String>]`: chatMessageType
      - `[PolicyViolation <IMicrosoftGraphChatMessagePolicyViolation1>]`: chatMessagePolicyViolation
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DlpAction <String>]`: chatMessagePolicyViolationDlpActionTypes
        - `[JustificationText <String>]`: Justification text provided by the sender of the message when overriding a policy violation.
        - `[PolicyTip <IMicrosoftGraphChatMessagePolicyViolationPolicyTip1>]`: chatMessagePolicyViolationPolicyTip
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ComplianceUrl <String>]`: The URL a user can visit to read about the data loss prevention policies for the organization. (ie, policies about what users shouldn't say in chats)
          - `[GeneralText <String>]`: Explanatory text shown to the sender of the message.
          - `[MatchedConditionDescription <String[]>]`: The list of improper data in the message that was detected by the data loss prevention app. Each DLP app defines its own conditions, examples include 'Credit Card Number' and 'Social Security Number'.
        - `[UserAction <String>]`: chatMessagePolicyViolationUserActionTypes
        - `[VerdictDetail <String>]`: chatMessagePolicyViolationVerdictDetailsTypes
      - `[Reaction <IMicrosoftGraphChatMessageReaction1[]>]`: Reactions for this chat message (for example, Like).
        - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[ReactionType <String>]`: Supported values are like, angry, sad, laugh, heart, surprised.
        - `[User <IMicrosoftGraphChatMessageReactionIdentitySet1>]`: chatMessageReactionIdentitySet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Application <IMicrosoftGraphIdentity1>]`: identity
          - `[Device <IMicrosoftGraphIdentity1>]`: identity
          - `[User <IMicrosoftGraphIdentity1>]`: identity
      - `[Reply <IMicrosoftGraphChatMessage1[]>]`: Replies for a specified message.
      - `[ReplyToId <String>]`: Read-only. ID of the parent chat message or root chat message of the thread. (Only applies to chat messages in channels, not chats.)
      - `[Subject <String>]`: The subject of the chat message, in plaintext.
      - `[Summary <String>]`: Summary text of the chat message that could be used for push notifications and summary views or fall back views. Only applies to channel chat messages, not chat messages in a chat.
      - `[WebUrl <String>]`: Read-only. Link to the message in Microsoft Teams.
    - `[Tab <IMicrosoftGraphTeamsTab1[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[Configuration <IMicrosoftGraphTeamsTabConfiguration1>]`: teamsTabConfiguration
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ContentUrl <String>]`: Url used for rendering tab contents in Teams. Required.
        - `[EntityId <String>]`: Identifier for the entity hosted by the tab provider.
        - `[RemoveUrl <String>]`: Url called by Teams client when a Tab is removed using the Teams Client.
        - `[WebsiteUrl <String>]`: Url for showing tab contents outside of Teams.
      - `[DisplayName <String>]`: Name of the tab.
      - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
      - `[WebUrl <String>]`: Deep link URL of the tab instance. Read only.
    - `[Topic <String>]`: (Optional) Subject or topic for the chat. Only available for group chats.
  - `[City <String>]`: The city in which the user is located. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[CompanyName <String>]`: The company name which the user is associated. This property can be useful for describing the company that an external user comes from. The maximum length of the company name is 64 characters.Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[ConsentProvidedForMinor <String>]`: Sets whether consent has been obtained for minors. Allowed values: null, granted, denied and notRequired. Refer to the legal age group property definitions for further information. Supports $filter (eq, ne, NOT, and in).
  - `[Country <String>]`: The country/region in which the user is located; for example, US or UK. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[Department <String>]`: The name for the department in which the user works. Maximum length is 64 characters.Supports $filter (eq, ne, NOT , ge, le, and in operators).
  - `[DeviceEnrollmentLimit <Int32?>]`: The limit on the maximum number of devices that the user is permitted to enroll. Allowed values are 5 or 1000.
  - `[DeviceManagementTroubleshootingEvent <IMicrosoftGraphDeviceManagementTroubleshootingEvent1[]>]`: The list of troubleshooting events for this user.
    - `[Id <String>]`: Read-only.
    - `[CorrelationId <String>]`: Id used for tracing the failure in the service.
    - `[EventDateTime <DateTime?>]`: Time when the event occurred .
  - `[DisplayName <String>]`: The name displayed in the address book for the user. This value is usually the combination of the user's first name, middle initial, and last name. This property is required when a user is created and it cannot be cleared during updates. Maximum length is 256 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith), $orderBy, and $search.
  - `[Drive <IMicrosoftGraphDrive1>]`: drive
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
    - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
    - `[Description <String>]`: Provides a user-visible description of the item. Optional.
    - `[ETag <String>]`: ETag for the item. Read-only.
    - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
    - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
    - `[Name <String>]`: The name of the item. Read-write.
    - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[DriveId <String>]`: Unique identifier of the drive instance that contains the item. Read-only.
      - `[DriveType <String>]`: Identifies the type of drive. See [drive][] resource for values.
      - `[Id <String>]`: Unique identifier of the item in the drive. Read-only.
      - `[Name <String>]`: The name of the item being referenced. Read-only.
      - `[Path <String>]`: Path that can be used to navigate to the item. Read-only.
      - `[ShareId <String>]`: A unique identifier for a shared resource that can be accessed via the [Shares][] API.
      - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ListId <String>]`: The unique identifier (guid) for the item's list in SharePoint.
        - `[ListItemId <String>]`: An integer identifier for the item within the containing list.
        - `[ListItemUniqueId <String>]`: The unique identifier (guid) for the item within OneDrive for Business or a SharePoint site.
        - `[SiteId <String>]`: The unique identifier (guid) for the item's site collection (SPSite).
        - `[SiteUrl <String>]`: The SharePoint URL for the site that contains the item.
        - `[TenantId <String>]`: The unique identifier (guid) for the tenancy.
        - `[WebId <String>]`: The unique identifier (guid) for the item's site (SPWeb).
      - `[SiteId <String>]`: For OneDrive for Business and SharePoint, this property represents the ID of the site that contains the parent document library of the driveItem resource. The value is the same as the id property of that [site][] resource. It is an opaque string that consists of three identifiers of the site. For OneDrive, this property is not populated.
    - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
    - `[Id <String>]`: Read-only.
    - `[DriveType <String>]`: Describes the type of drive represented by this resource. OneDrive personal drives will return personal. OneDrive for Business will return business. SharePoint document libraries will return documentLibrary. Read-only.
    - `[Following <IMicrosoftGraphDriveItem1[]>]`: The list of items the user is following. Only in OneDrive for Business.
      - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
      - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
      - `[Description <String>]`: Provides a user-visible description of the item. Optional.
      - `[ETag <String>]`: ETag for the item. Read-only.
      - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
      - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
      - `[Name <String>]`: The name of the item. Read-write.
      - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
      - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
      - `[Id <String>]`: Read-only.
      - `[Analytic <IMicrosoftGraphItemAnalytics1>]`: itemAnalytics
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Id <String>]`: Read-only.
        - `[AllTime <IMicrosoftGraphItemActivityStat1>]`: itemActivityStat
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[Access <IMicrosoftGraphItemActionStat1>]`: itemActionStat
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[ActionCount <Int32?>]`: The number of times the action took place. Read-only.
            - `[ActorCount <Int32?>]`: The number of distinct actors that performed the action. Read-only.
          - `[Activity <IMicrosoftGraphItemActivity1[]>]`: Exposes the itemActivities represented in this itemActivityStat resource.
            - `[Id <String>]`: Read-only.
            - `[Access <IMicrosoftGraphAccessAction>]`: accessAction
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[ActivityDateTime <DateTime?>]`: Details about when the activity took place. Read-only.
            - `[Actor <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[DriveItem <IMicrosoftGraphDriveItem1>]`: driveItem
          - `[Create <IMicrosoftGraphItemActionStat1>]`: itemActionStat
          - `[Delete <IMicrosoftGraphItemActionStat1>]`: itemActionStat
          - `[Edit <IMicrosoftGraphItemActionStat1>]`: itemActionStat
          - `[EndDateTime <DateTime?>]`: When the interval ends. Read-only.
          - `[IncompleteData <IMicrosoftGraphIncompleteData1>]`: incompleteData
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[MissingDataBeforeDateTime <DateTime?>]`: The service does not have source data before the specified time.
            - `[WasThrottled <Boolean?>]`: Some data was not recorded due to excessive activity.
          - `[IsTrending <Boolean?>]`: Indicates whether the item is 'trending.' Read-only.
          - `[Move <IMicrosoftGraphItemActionStat1>]`: itemActionStat
          - `[StartDateTime <DateTime?>]`: When the interval starts. Read-only.
        - `[ItemActivityStat <IMicrosoftGraphItemActivityStat1[]>]`: 
        - `[LastSevenDay <IMicrosoftGraphItemActivityStat1>]`: itemActivityStat
      - `[Audio <IMicrosoftGraphAudio1>]`: audio
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Album <String>]`: The title of the album for this audio file.
        - `[AlbumArtist <String>]`: The artist named on the album for the audio file.
        - `[Artist <String>]`: The performing artist for the audio file.
        - `[Bitrate <Int64?>]`: Bitrate expressed in kbps.
        - `[Composer <String>]`: The name of the composer of the audio file.
        - `[Copyright <String>]`: Copyright information for the audio file.
        - `[Disc <Int32?>]`: The number of the disc this audio file came from.
        - `[DiscCount <Int32?>]`: The total number of discs in this album.
        - `[Duration <Int64?>]`: Duration of the audio file, expressed in milliseconds
        - `[Genre <String>]`: The genre of this audio file.
        - `[HasDrm <Boolean?>]`: Indicates if the file is protected with digital rights management.
        - `[IsVariableBitrate <Boolean?>]`: Indicates if the file is encoded with a variable bitrate.
        - `[Title <String>]`: The title of the audio file.
        - `[Track <Int32?>]`: The number of the track on the original disc for this audio file.
        - `[TrackCount <Int32?>]`: The total number of tracks on the original disc for this audio file.
        - `[Year <Int32?>]`: The year the audio file was recorded.
      - `[CTag <String>]`: An eTag for the content of the item. This eTag is not changed if only the metadata is changed. Note This property is not returned if the item is a folder. Read-only.
      - `[Child <IMicrosoftGraphDriveItem1[]>]`: Collection containing Item objects for the immediate children of Item. Only items representing folders have children. Read-only. Nullable.
      - `[Content <Byte[]>]`: The content stream, if the item represents a file.
      - `[Deleted <IMicrosoftGraphDeleted1>]`: deleted
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[State <String>]`: Represents the state of the deleted item.
      - `[File <IMicrosoftGraphFile1>]`: file
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Hash <IMicrosoftGraphHashes1>]`: hashes
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Crc32Hash <String>]`: The CRC32 value of the file (if available). Read-only.
          - `[QuickXorHash <String>]`: A proprietary hash of the file that can be used to determine if the contents of the file have changed (if available). Read-only.
          - `[Sha1Hash <String>]`: SHA1 hash for the contents of the file (if available). Read-only.
          - `[Sha256Hash <String>]`: SHA256 hash for the contents of the file (if available). Read-only.
        - `[MimeType <String>]`: The MIME type for the file. This is determined by logic on the server and might not be the value provided when the file was uploaded. Read-only.
        - `[ProcessingMetadata <Boolean?>]`: 
      - `[FileSystemInfo <IMicrosoftGraphFileSystemInfo1>]`: fileSystemInfo
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[CreatedDateTime <DateTime?>]`: The UTC date and time the file was created on a client.
        - `[LastAccessedDateTime <DateTime?>]`: The UTC date and time the file was last accessed. Available for the recent file list only.
        - `[LastModifiedDateTime <DateTime?>]`: The UTC date and time the file was last modified on a client.
      - `[Folder <IMicrosoftGraphFolder1>]`: folder
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ChildCount <Int32?>]`: Number of children contained immediately within this container.
        - `[View <IMicrosoftGraphFolderView1>]`: folderView
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[SortBy <String>]`: The method by which the folder should be sorted.
          - `[SortOrder <String>]`: If true, indicates that items should be sorted in descending order. Otherwise, items should be sorted ascending.
          - `[ViewType <String>]`: The type of view that should be used to represent the folder.
      - `[Image <IMicrosoftGraphImage1>]`: image
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Height <Int32?>]`: Optional. Height of the image, in pixels. Read-only.
        - `[Width <Int32?>]`: Optional. Width of the image, in pixels. Read-only.
      - `[ListItem <IMicrosoftGraphListItem1>]`: listItem
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
        - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
        - `[Description <String>]`: Provides a user-visible description of the item. Optional.
        - `[ETag <String>]`: ETag for the item. Read-only.
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
        - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
        - `[Name <String>]`: The name of the item. Read-write.
        - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
        - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
        - `[Id <String>]`: Read-only.
        - `[Analytic <IMicrosoftGraphItemAnalytics1>]`: itemAnalytics
        - `[ContentType <IMicrosoftGraphContentTypeInfo1>]`: contentTypeInfo
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: The id of the content type.
          - `[Name <String>]`: The name of the content type.
        - `[DriveItem <IMicrosoftGraphDriveItem1>]`: driveItem
        - `[Field <IMicrosoftGraphFieldValueSet1>]`: fieldValueSet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
        - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
        - `[Version <IMicrosoftGraphListItemVersion1[]>]`: The list of previous versions of the list item.
          - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[LastModifiedDateTime <DateTime?>]`: Date and time the version was last modified. Read-only.
          - `[Publication <IMicrosoftGraphPublicationFacet1>]`: publicationFacet
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Level <String>]`: The state of publication for this document. Either published or checkout. Read-only.
            - `[VersionId <String>]`: The unique identifier for the version that is visible to the current caller. Read-only.
          - `[Id <String>]`: Read-only.
          - `[Field <IMicrosoftGraphFieldValueSet1>]`: fieldValueSet
      - `[Location <IMicrosoftGraphGeoCoordinates1>]`: geoCoordinates
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Altitude <Double?>]`: Optional. The altitude (height), in feet,  above sea level for the item. Read-only.
        - `[Latitude <Double?>]`: Optional. The latitude, in decimal, for the item. Writable on OneDrive Personal.
        - `[Longitude <Double?>]`: Optional. The longitude, in decimal, for the item. Writable on OneDrive Personal.
      - `[Package <IMicrosoftGraphPackage1>]`: package
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Type <String>]`: A string indicating the type of package. While oneNote is the only currently defined value, you should expect other package types to be returned and handle them accordingly.
      - `[PendingOperation <IMicrosoftGraphPendingOperations1>]`: pendingOperations
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[PendingContentUpdate <IMicrosoftGraphPendingContentUpdate1>]`: pendingContentUpdate
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[QueuedDateTime <DateTime?>]`: Date and time the pending binary operation was queued in UTC time. Read-only.
      - `[Permission <IMicrosoftGraphPermission1[]>]`: The set of permissions for the item. Read-only. Nullable.
        - `[Id <String>]`: Read-only.
        - `[ExpirationDateTime <DateTime?>]`: A format of yyyy-MM-ddTHH:mm:ssZ of DateTimeOffset indicates the expiration time of the permission. DateTime.MinValue indicates there is no expiration set for this permission. Optional.
        - `[GrantedTo <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[GrantedToIdentity <IMicrosoftGraphIdentitySet1[]>]`: For link type permissions, the details of the users to whom permission was granted. Read-only.
        - `[HasPassword <Boolean?>]`: This indicates whether password is set for this permission, it's only showing in response. Optional and Read-only and for OneDrive Personal only.
        - `[InheritedFrom <IMicrosoftGraphItemReference1>]`: itemReference
        - `[Invitation <IMicrosoftGraphSharingInvitation1>]`: sharingInvitation
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Email <String>]`: The email address provided for the recipient of the sharing invitation. Read-only.
          - `[InvitedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[RedeemedBy <String>]`: 
          - `[SignInRequired <Boolean?>]`: If true the recipient of the invitation needs to sign in in order to access the shared item. Read-only.
        - `[Link <IMicrosoftGraphSharingLink1>]`: sharingLink
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Application <IMicrosoftGraphIdentity1>]`: identity
          - `[PreventsDownload <Boolean?>]`: If true then the user can only use this link to view the item on the web, and cannot use it to download the contents of the item. Only for OneDrive for Business and SharePoint.
          - `[Scope <String>]`: The scope of the link represented by this permission. Value anonymous indicates the link is usable by anyone, organization indicates the link is only usable for users signed into the same tenant.
          - `[Type <String>]`: The type of the link created.
          - `[WebHtml <String>]`: For embed links, this property contains the HTML code for an <iframe> element that will embed the item in a webpage.
          - `[WebUrl <String>]`: A URL that opens the item in the browser on the OneDrive website.
        - `[Role <String[]>]`: The type of permission, e.g. read. See below for the full list of roles. Read-only.
        - `[ShareId <String>]`: A unique token that can be used to access this shared item via the [shares API][]. Read-only.
      - `[Photo <IMicrosoftGraphPhoto1>]`: photo
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[CameraMake <String>]`: Camera manufacturer. Read-only.
        - `[CameraModel <String>]`: Camera model. Read-only.
        - `[ExposureDenominator <Double?>]`: The denominator for the exposure time fraction from the camera. Read-only.
        - `[ExposureNumerator <Double?>]`: The numerator for the exposure time fraction from the camera. Read-only.
        - `[FNumber <Double?>]`: The F-stop value from the camera. Read-only.
        - `[FocalLength <Double?>]`: The focal length from the camera. Read-only.
        - `[Iso <Int32?>]`: The ISO value from the camera. Read-only.
        - `[Orientation <Int32?>]`: The orientation value from the camera. Writable on OneDrive Personal.
        - `[TakenDateTime <DateTime?>]`: The date and time the photo was taken in UTC time. Read-only.
      - `[Publication <IMicrosoftGraphPublicationFacet1>]`: publicationFacet
      - `[RemoteItem <IMicrosoftGraphRemoteItem1>]`: remoteItem
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
        - `[File <IMicrosoftGraphFile1>]`: file
        - `[FileSystemInfo <IMicrosoftGraphFileSystemInfo1>]`: fileSystemInfo
        - `[Folder <IMicrosoftGraphFolder1>]`: folder
        - `[Id <String>]`: Unique identifier for the remote item in its drive. Read-only.
        - `[Image <IMicrosoftGraphImage1>]`: image
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
        - `[Name <String>]`: Optional. Filename of the remote item. Read-only.
        - `[Package <IMicrosoftGraphPackage1>]`: package
        - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
        - `[Shared <IMicrosoftGraphShared1>]`: shared
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Owner <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[Scope <String>]`: Indicates the scope of how the item is shared: anonymous, organization, or users. Read-only.
          - `[SharedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[SharedDateTime <DateTime?>]`: The UTC date and time when the item was shared. Read-only.
        - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
        - `[Size <Int64?>]`: Size of the remote item. Read-only.
        - `[SpecialFolder <IMicrosoftGraphSpecialFolder1>]`: specialFolder
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Name <String>]`: The unique identifier for this item in the /drive/special collection
        - `[Video <IMicrosoftGraphVideo1>]`: video
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[AudioBitsPerSample <Int32?>]`: Number of audio bits per sample.
          - `[AudioChannel <Int32?>]`: Number of audio channels.
          - `[AudioFormat <String>]`: Name of the audio format (AAC, MP3, etc.).
          - `[AudioSamplesPerSecond <Int32?>]`: Number of audio samples per second.
          - `[Bitrate <Int32?>]`: Bit rate of the video in bits per second.
          - `[Duration <Int64?>]`: Duration of the file in milliseconds.
          - `[FourCc <String>]`: 'Four character code' name of the video format.
          - `[FrameRate <Double?>]`: Frame rate of the video.
          - `[Height <Int32?>]`: Height of the video, in pixels.
          - `[Width <Int32?>]`: Width of the video, in pixels.
        - `[WebDavUrl <String>]`: DAV compatible URL for the item.
        - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
      - `[Root <IMicrosoftGraphRoot>]`: root
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[SearchResult <IMicrosoftGraphSearchResult1>]`: searchResult
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[OnClickTelemetryUrl <String>]`: A callback URL that can be used to record telemetry information. The application should issue a GET on this URL if the user interacts with this item to improve the quality of results.
      - `[Shared <IMicrosoftGraphShared1>]`: shared
      - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
      - `[Size <Int64?>]`: Size of the item in bytes. Read-only.
      - `[SpecialFolder <IMicrosoftGraphSpecialFolder1>]`: specialFolder
      - `[Subscription <IMicrosoftGraphSubscription1[]>]`: The set of subscriptions on the item. Only supported on the root of a drive.
        - `[Id <String>]`: Read-only.
        - `[ApplicationId <String>]`: Identifier of the application used to create the subscription. Read-only.
        - `[ChangeType <String>]`: Indicates the type of change in the subscribed resource that will raise a change notification. The supported values are: created, updated, deleted. Multiple values can be combined using a comma-separated list. Required. Note: Drive root item and list change notifications support only the updated changeType. User and group change notifications support updated and deleted changeType.
        - `[ClientState <String>]`: Specifies the value of the clientState property sent by the service in each change notification. The maximum length is 255 characters. The client can check that the change notification came from the service by comparing the value of the clientState property sent with the subscription with the value of the clientState property received with each change notification. Optional.
        - `[CreatorId <String>]`: Identifier of the user or service principal that created the subscription. If the app used delegated permissions to create the subscription, this field contains the ID of the signed-in user the app called on behalf of. If the app used application permissions, this field contains the ID of the service principal corresponding to the app. Read-only.
        - `[EncryptionCertificate <String>]`: A base64-encoded representation of a certificate with a public key used to encrypt resource data in change notifications. Optional. Required when includeResourceData is true.
        - `[EncryptionCertificateId <String>]`: A custom app-provided identifier to help identify the certificate needed to decrypt resource data. Optional. Required when includeResourceData is true.
        - `[ExpirationDateTime <DateTime?>]`: Specifies the date and time when the webhook subscription expires. The time is in UTC, and can be an amount of time from subscription creation that varies for the resource subscribed to.  See the table below for maximum supported subscription length of time. Required.
        - `[IncludeResourceData <Boolean?>]`: When set to true, change notifications include resource data (such as content of a chat message). Optional.
        - `[LatestSupportedTlsVersion <String>]`: Specifies the latest version of Transport Layer Security (TLS) that the notification endpoint, specified by notificationUrl, supports. The possible values are: v1_0, v1_1, v1_2, v1_3. For subscribers whose notification endpoint supports a version lower than the currently recommended version (TLS 1.2), specifying this property by a set timeline allows them to temporarily use their deprecated version of TLS before completing their upgrade to TLS 1.2. For these subscribers, not setting this property per the timeline would result in subscription operations failing. For subscribers whose notification endpoint already supports TLS 1.2, setting this property is optional. In such cases, Microsoft Graph defaults the property to v1_2.
        - `[LifecycleNotificationUrl <String>]`: The URL of the endpoint that receives lifecycle notifications, including subscriptionRemoved and missed notifications. This URL must make use of the HTTPS protocol. Optional. Read more about how Outlook resources use lifecycle notifications.
        - `[NotificationQueryOption <String>]`: OData Query Options for specifying value for the targeting resource. Clients receive notifications when resource reaches the state matching the query options provided here. With this new property in the subscription creation payload along with all existing properties, Webhooks will deliver notifications whenever a resource reaches the desired state mentioned in the notificationQueryOptions property eg  when the print job is completed, when a print job resource isFetchable property value becomes true etc.
        - `[NotificationUrl <String>]`: The URL of the endpoint that receives the change notifications. This URL must make use of the HTTPS protocol. Required.
        - `[Resource <String>]`: Specifies the resource that will be monitored for changes. Do not include the base URL (https://graph.microsoft.com/beta/). See the possible resource path values for each supported resource. Required.
      - `[Thumbnail <IMicrosoftGraphThumbnailSet1[]>]`: Collection containing [ThumbnailSet][] objects associated with the item. For more info, see [getting thumbnails][]. Read-only. Nullable.
        - `[Id <String>]`: Read-only.
        - `[Large <IMicrosoftGraphThumbnail1>]`: thumbnail
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Content <Byte[]>]`: The content stream for the thumbnail.
          - `[Height <Int32?>]`: The height of the thumbnail, in pixels.
          - `[SourceItemId <String>]`: The unique identifier of the item that provided the thumbnail. This is only available when a folder thumbnail is requested.
          - `[Url <String>]`: The URL used to fetch the thumbnail content.
          - `[Width <Int32?>]`: The width of the thumbnail, in pixels.
        - `[Medium <IMicrosoftGraphThumbnail1>]`: thumbnail
        - `[Small <IMicrosoftGraphThumbnail1>]`: thumbnail
        - `[Source <IMicrosoftGraphThumbnail1>]`: thumbnail
      - `[Version <IMicrosoftGraphDriveItemVersion1[]>]`: The list of previous versions of the item. For more info, see [getting previous versions][]. Read-only. Nullable.
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedDateTime <DateTime?>]`: Date and time the version was last modified. Read-only.
        - `[Publication <IMicrosoftGraphPublicationFacet1>]`: publicationFacet
        - `[Id <String>]`: Read-only.
        - `[Content <Byte[]>]`: 
        - `[Size <Int64?>]`: Indicates the size of the content stream for this version of the item.
      - `[Video <IMicrosoftGraphVideo1>]`: video
      - `[WebDavUrl <String>]`: WebDAV compatible URL for the item.
      - `[Workbook <IMicrosoftGraphWorkbook1>]`: workbook
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Id <String>]`: Read-only.
        - `[Application <IMicrosoftGraphWorkbookApplication1>]`: workbookApplication
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[CalculationMode <String>]`: Returns the calculation mode used in the workbook. Possible values are: Automatic, AutomaticExceptTables, Manual.
        - `[Comment <IMicrosoftGraphWorkbookComment1[]>]`: 
          - `[Id <String>]`: Read-only.
          - `[Content <String>]`: The content of the comment.
          - `[ContentType <String>]`: Indicates the type for the comment.
          - `[Reply <IMicrosoftGraphWorkbookCommentReply1[]>]`: Read-only. Nullable.
            - `[Id <String>]`: Read-only.
            - `[Content <String>]`: The content of replied comment.
            - `[ContentType <String>]`: Indicates the type for the replied comment.
        - `[Function <IMicrosoftGraphWorkbookFunctions1>]`: workbookFunctions
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
        - `[Name <IMicrosoftGraphWorkbookNamedItem1[]>]`: Represents a collection of workbooks scoped named items (named ranges and constants). Read-only.
          - `[Id <String>]`: Read-only.
          - `[Comment <String>]`: Represents the comment associated with this name.
          - `[Name <String>]`: The name of the object. Read-only.
          - `[Scope <String>]`: Indicates whether the name is scoped to the workbook or to a specific worksheet. Read-only.
          - `[Type <String>]`: Indicates what type of reference is associated with the name. Possible values are: String, Integer, Double, Boolean, Range. Read-only.
          - `[Value <IMicrosoftGraphJson>]`: Json
          - `[Visible <Boolean?>]`: Specifies whether the object is visible or not.
          - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Id <String>]`: Read-only.
            - `[Chart <IMicrosoftGraphWorkbookChart1[]>]`: Returns collection of charts that are part of the worksheet. Read-only.
              - `[Id <String>]`: Read-only.
              - `[Axis <IMicrosoftGraphWorkbookChartAxes1>]`: workbookChartAxes
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Id <String>]`: Read-only.
                - `[CategoryAxis <IMicrosoftGraphWorkbookChartAxis1>]`: workbookChartAxis
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Format <IMicrosoftGraphWorkbookChartAxisFormat1>]`: workbookChartAxisFormat
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Id <String>]`: Read-only.
                      - `[Bold <Boolean?>]`: Represents the bold status of font.
                      - `[Color <String>]`: HTML color code representation of the text color. E.g. #FF0000 represents Red.
                      - `[Italic <Boolean?>]`: Represents the italic status of the font.
                      - `[Name <String>]`: Font name (e.g. 'Calibri')
                      - `[Size <Double?>]`: Size of the font (e.g. 11)
                      - `[Underline <String>]`: Type of underline applied to the font. The possible values are: None, Single.
                    - `[Line <IMicrosoftGraphWorkbookChartLineFormat1>]`: workbookChartLineFormat
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Id <String>]`: Read-only.
                      - `[Color <String>]`: HTML color code representing the color of lines in the chart.
                  - `[MajorGridline <IMicrosoftGraphWorkbookChartGridlines1>]`: workbookChartGridlines
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Format <IMicrosoftGraphWorkbookChartGridlinesFormat1>]`: workbookChartGridlinesFormat
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Id <String>]`: Read-only.
                      - `[Line <IMicrosoftGraphWorkbookChartLineFormat1>]`: workbookChartLineFormat
                    - `[Visible <Boolean?>]`: Boolean value representing if the axis gridlines are visible or not.
                  - `[MajorUnit <IMicrosoftGraphJson>]`: Json
                  - `[Maximum <IMicrosoftGraphJson>]`: Json
                  - `[Minimum <IMicrosoftGraphJson>]`: Json
                  - `[MinorGridline <IMicrosoftGraphWorkbookChartGridlines1>]`: workbookChartGridlines
                  - `[MinorUnit <IMicrosoftGraphJson>]`: Json
                  - `[Title <IMicrosoftGraphWorkbookChartAxisTitle1>]`: workbookChartAxisTitle
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Format <IMicrosoftGraphWorkbookChartAxisTitleFormat1>]`: workbookChartAxisTitleFormat
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Id <String>]`: Read-only.
                      - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                    - `[Text <String>]`: Represents the axis title.
                    - `[Visible <Boolean?>]`: A boolean that specifies the visibility of an axis title.
                - `[SeriesAxis <IMicrosoftGraphWorkbookChartAxis1>]`: workbookChartAxis
                - `[ValueAxis <IMicrosoftGraphWorkbookChartAxis1>]`: workbookChartAxis
              - `[DataLabel <IMicrosoftGraphWorkbookChartDataLabels1>]`: workbookChartDataLabels
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Id <String>]`: Read-only.
                - `[Format <IMicrosoftGraphWorkbookChartDataLabelFormat1>]`: workbookChartDataLabelFormat
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                  - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                - `[Position <String>]`: DataLabelPosition value that represents the position of the data label. The possible values are: None, Center, InsideEnd, InsideBase, OutsideEnd, Left, Right, Top, Bottom, BestFit, Callout.
                - `[Separator <String>]`: String representing the separator used for the data labels on a chart.
                - `[ShowBubbleSize <Boolean?>]`: Boolean value representing if the data label bubble size is visible or not.
                - `[ShowCategoryName <Boolean?>]`: Boolean value representing if the data label category name is visible or not.
                - `[ShowLegendKey <Boolean?>]`: Boolean value representing if the data label legend key is visible or not.
                - `[ShowPercentage <Boolean?>]`: Boolean value representing if the data label percentage is visible or not.
                - `[ShowSeriesName <Boolean?>]`: Boolean value representing if the data label series name is visible or not.
                - `[ShowValue <Boolean?>]`: Boolean value representing if the data label value is visible or not.
              - `[Format <IMicrosoftGraphWorkbookChartAreaFormat1>]`: workbookChartAreaFormat
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Id <String>]`: Read-only.
                - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
              - `[Height <Double?>]`: Represents the height, in points, of the chart object.
              - `[Left <Double?>]`: The distance, in points, from the left side of the chart to the worksheet origin.
              - `[Legend <IMicrosoftGraphWorkbookChartLegend1>]`: workbookChartLegend
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Id <String>]`: Read-only.
                - `[Format <IMicrosoftGraphWorkbookChartLegendFormat1>]`: workbookChartLegendFormat
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                  - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                - `[Overlay <Boolean?>]`: Boolean value for whether the chart legend should overlap with the main body of the chart.
                - `[Position <String>]`: Represents the position of the legend on the chart. The possible values are: Top, Bottom, Left, Right, Corner, Custom.
                - `[Visible <Boolean?>]`: A boolean value the represents the visibility of a ChartLegend object.
              - `[Name <String>]`: Represents the name of a chart object.
              - `[Series <IMicrosoftGraphWorkbookChartSeries1[]>]`: Represents either a single series or collection of series in the chart. Read-only.
                - `[Id <String>]`: Read-only.
                - `[Format <IMicrosoftGraphWorkbookChartSeriesFormat1>]`: workbookChartSeriesFormat
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                  - `[Line <IMicrosoftGraphWorkbookChartLineFormat1>]`: workbookChartLineFormat
                - `[Name <String>]`: Represents the name of a series in a chart.
                - `[Point <IMicrosoftGraphWorkbookChartPoint1[]>]`: Represents a collection of all points in the series. Read-only.
                  - `[Id <String>]`: Read-only.
                  - `[Format <IMicrosoftGraphWorkbookChartPointFormat1>]`: workbookChartPointFormat
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                  - `[Value <IMicrosoftGraphJson>]`: Json
              - `[Title <IMicrosoftGraphWorkbookChartTitle1>]`: workbookChartTitle
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Id <String>]`: Read-only.
                - `[Format <IMicrosoftGraphWorkbookChartTitleFormat1>]`: workbookChartTitleFormat
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                  - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                - `[Overlay <Boolean?>]`: Boolean value representing if the chart title will overlay the chart or not.
                - `[Text <String>]`: Represents the title text of a chart.
                - `[Visible <Boolean?>]`: A boolean value the represents the visibility of a chart title object.
              - `[Top <Double?>]`: Represents the distance, in points, from the top edge of the object to the top of row 1 (on a worksheet) or the top of the chart area (on a chart).
              - `[Width <Double?>]`: Represents the width, in points, of the chart object.
              - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
            - `[Name <String>]`: The display name of the worksheet.
            - `[Names <IMicrosoftGraphWorkbookNamedItem1[]>]`: Returns collection of names that are associated with the worksheet. Read-only.
            - `[PivotTable <IMicrosoftGraphWorkbookPivotTable1[]>]`: Collection of PivotTables that are part of the worksheet.
              - `[Id <String>]`: Read-only.
              - `[Name <String>]`: Name of the PivotTable.
              - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
            - `[Position <Int32?>]`: The zero-based position of the worksheet within the workbook.
            - `[Protection <IMicrosoftGraphWorkbookWorksheetProtection1>]`: workbookWorksheetProtection
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[Id <String>]`: Read-only.
              - `[Option <IMicrosoftGraphWorkbookWorksheetProtectionOptions1>]`: workbookWorksheetProtectionOptions
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[AllowAutoFilter <Boolean?>]`: Represents the worksheet protection option of allowing using auto filter feature.
                - `[AllowDeleteColumn <Boolean?>]`: Represents the worksheet protection option of allowing deleting columns.
                - `[AllowDeleteRow <Boolean?>]`: Represents the worksheet protection option of allowing deleting rows.
                - `[AllowFormatCell <Boolean?>]`: Represents the worksheet protection option of allowing formatting cells.
                - `[AllowFormatColumn <Boolean?>]`: Represents the worksheet protection option of allowing formatting columns.
                - `[AllowFormatRow <Boolean?>]`: Represents the worksheet protection option of allowing formatting rows.
                - `[AllowInsertColumn <Boolean?>]`: Represents the worksheet protection option of allowing inserting columns.
                - `[AllowInsertHyperlink <Boolean?>]`: Represents the worksheet protection option of allowing inserting hyperlinks.
                - `[AllowInsertRow <Boolean?>]`: Represents the worksheet protection option of allowing inserting rows.
                - `[AllowPivotTable <Boolean?>]`: Represents the worksheet protection option of allowing using pivot table feature.
                - `[AllowSort <Boolean?>]`: Represents the worksheet protection option of allowing using sort feature.
              - `[Protected <Boolean?>]`: Indicates if the worksheet is protected.  Read-only.
            - `[Table <IMicrosoftGraphWorkbookTable1[]>]`: Collection of tables that are part of the worksheet. Read-only.
              - `[Id <String>]`: Read-only.
              - `[Column <IMicrosoftGraphWorkbookTableColumn1[]>]`: Represents a collection of all the columns in the table. Read-only.
                - `[Id <String>]`: Read-only.
                - `[Filter <IMicrosoftGraphWorkbookFilter1>]`: workbookFilter
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Criterion <IMicrosoftGraphWorkbookFilterCriteria1>]`: workbookFilterCriteria
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Color <String>]`: 
                    - `[Criterion1 <String>]`: 
                    - `[Criterion2 <String>]`: 
                    - `[DynamicCriterion <String>]`: 
                    - `[FilterOn <String>]`: 
                    - `[Icon <IMicrosoftGraphWorkbookIcon1>]`: workbookIcon
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Index <Int32?>]`: Represents the index of the icon in the given set.
                      - `[Set <String>]`: Represents the set that the icon is part of. Possible values are: Invalid, ThreeArrows, ThreeArrowsGray, ThreeFlags, ThreeTrafficLights1, ThreeTrafficLights2, ThreeSigns, ThreeSymbols, ThreeSymbols2, FourArrows, FourArrowsGray, FourRedToBlack, FourRating, FourTrafficLights, FiveArrows, FiveArrowsGray, FiveRating, FiveQuarters, ThreeStars, ThreeTriangles, FiveBoxes.
                    - `[Operator <String>]`: 
                    - `[Value <IMicrosoftGraphJson>]`: Json
                - `[Index <Int32?>]`: Returns the index number of the column within the columns collection of the table. Zero-indexed. Read-only.
                - `[Name <String>]`: Returns the name of the table column.
                - `[Value <IMicrosoftGraphJson>]`: Json
              - `[HighlightFirstColumn <Boolean?>]`: Indicates whether the first column contains special formatting.
              - `[HighlightLastColumn <Boolean?>]`: Indicates whether the last column contains special formatting.
              - `[LegacyId <String>]`: Legacy Id used in older Excle clients. The value of the identifier remains the same even when the table is renamed. This property should be interpreted as an opaque string value and should not be parsed to any other type. Read-only.
              - `[Name <String>]`: Name of the table.
              - `[Row <IMicrosoftGraphWorkbookTableRow1[]>]`: Represents a collection of all the rows in the table. Read-only.
                - `[Id <String>]`: Read-only.
                - `[Index <Int32?>]`: Returns the index number of the row within the rows collection of the table. Zero-indexed. Read-only.
                - `[Value <IMicrosoftGraphJson>]`: Json
              - `[ShowBandedColumn <Boolean?>]`: Indicates whether the columns show banded formatting in which odd columns are highlighted differently from even ones to make reading the table easier.
              - `[ShowBandedRow <Boolean?>]`: Indicates whether the rows show banded formatting in which odd rows are highlighted differently from even ones to make reading the table easier.
              - `[ShowFilterButton <Boolean?>]`: Indicates whether the filter buttons are visible at the top of each column header. Setting this is only allowed if the table contains a header row.
              - `[ShowHeader <Boolean?>]`: Indicates whether the header row is visible or not. This value can be set to show or remove the header row.
              - `[ShowTotal <Boolean?>]`: Indicates whether the total row is visible or not. This value can be set to show or remove the total row.
              - `[Sort <IMicrosoftGraphWorkbookTableSort1>]`: workbookTableSort
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Id <String>]`: Read-only.
                - `[Field <IMicrosoftGraphWorkbookSortField1[]>]`: Represents the current conditions used to last sort the table. Read-only.
                  - `[Ascending <Boolean?>]`: Represents whether the sorting is done in an ascending fashion.
                  - `[Color <String>]`: Represents the color that is the target of the condition if the sorting is on font or cell color.
                  - `[DataOption <String>]`: Represents additional sorting options for this field. Possible values are: Normal, TextAsNumber.
                  - `[Icon <IMicrosoftGraphWorkbookIcon1>]`: workbookIcon
                  - `[Key <Int32?>]`: Represents the column (or row, depending on the sort orientation) that the condition is on. Represented as an offset from the first column (or row).
                  - `[SortOn <String>]`: Represents the type of sorting of this condition. Possible values are: Value, CellColor, FontColor, Icon.
                - `[MatchCase <Boolean?>]`: Represents whether the casing impacted the last sort of the table. Read-only.
                - `[Method <String>]`: Represents Chinese character ordering method last used to sort the table. Possible values are: PinYin, StrokeCount. Read-only.
              - `[Style <String>]`: Constant value that represents the Table style. Possible values are: TableStyleLight1 thru TableStyleLight21, TableStyleMedium1 thru TableStyleMedium28, TableStyleStyleDark1 thru TableStyleStyleDark11. A custom user-defined style present in the workbook can also be specified.
              - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
            - `[Visibility <String>]`: The Visibility of the worksheet. The possible values are: Visible, Hidden, VeryHidden.
        - `[Operation <IMicrosoftGraphWorkbookOperation1[]>]`: The status of Workbook operations. Getting an operation collection is not supported, but you can get the status of a long-running operation if the Location header is returned in the response. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[Error <IMicrosoftGraphWorkbookOperationError1>]`: workbookOperationError
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Code <String>]`: The error code.
            - `[InnerError <IMicrosoftGraphWorkbookOperationError1>]`: workbookOperationError
            - `[Message <String>]`: The error message.
          - `[ResourceLocation <String>]`: The resource URI for the result.
          - `[Status <String>]`: workbookOperationStatus
        - `[Table <IMicrosoftGraphWorkbookTable1[]>]`: Represents a collection of tables associated with the workbook. Read-only.
        - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1[]>]`: Represents a collection of worksheets associated with the workbook. Read-only.
    - `[Items <IMicrosoftGraphDriveItem1[]>]`: All items contained in the drive. Read-only. Nullable.
    - `[List <IMicrosoftGraphList1>]`: list
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
      - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
      - `[Description <String>]`: Provides a user-visible description of the item. Optional.
      - `[ETag <String>]`: ETag for the item. Read-only.
      - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
      - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
      - `[Name <String>]`: The name of the item. Read-write.
      - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
      - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
      - `[Id <String>]`: Read-only.
      - `[Column <IMicrosoftGraphColumnDefinition1[]>]`: The collection of field definitions for this list.
        - `[Id <String>]`: Read-only.
        - `[Boolean <IMicrosoftGraphBooleanColumn>]`: booleanColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Calculated <IMicrosoftGraphCalculatedColumn1>]`: calculatedColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Format <String>]`: For dateTime output types, the format of the value. Must be one of dateOnly or dateTime.
          - `[Formula <String>]`: The formula used to compute the value for this column.
          - `[OutputType <String>]`: The output type used to format values in this column. Must be one of boolean, currency, dateTime, number, or text.
        - `[Choice <IMicrosoftGraphChoiceColumn1>]`: choiceColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[AllowTextEntry <Boolean?>]`: If true, allows custom values that aren't in the configured choices.
          - `[Choice <String[]>]`: The list of values available for this column.
          - `[DisplayAs <String>]`: How the choices are to be presented in the UX. Must be one of checkBoxes, dropDownMenu, or radioButtons
        - `[ColumnGroup <String>]`: For site columns, the name of the group this column belongs to. Helps organize related columns.
        - `[Currency <IMicrosoftGraphCurrencyColumn1>]`: currencyColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Locale <String>]`: Specifies the locale from which to infer the currency symbol.
        - `[DateTime <IMicrosoftGraphDateTimeColumn1>]`: dateTimeColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DisplayAs <String>]`: How the value should be presented in the UX. Must be one of default, friendly, or standard. See below for more details. If unspecified, treated as default.
          - `[Format <String>]`: Indicates whether the value should be presented as a date only or a date and time. Must be one of dateOnly or dateTime
        - `[DefaultValue <IMicrosoftGraphDefaultColumnValue1>]`: defaultColumnValue
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Formula <String>]`: The formula used to compute the default value for this column.
          - `[Value <String>]`: The direct value to use as the default value for this column.
        - `[Description <String>]`: The user-facing description of the column.
        - `[DisplayName <String>]`: The user-facing name of the column.
        - `[EnforceUniqueValue <Boolean?>]`: If true, no two list items may have the same value for this column.
        - `[Geolocation <IMicrosoftGraphGeolocationColumn>]`: geolocationColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Hidden <Boolean?>]`: Specifies whether the column is displayed in the user interface.
        - `[Indexed <Boolean?>]`: Specifies whether the column values can used for sorting and searching.
        - `[Lookup <IMicrosoftGraphLookupColumn1>]`: lookupColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[AllowMultipleValue <Boolean?>]`: Indicates whether multiple values can be selected from the source.
          - `[AllowUnlimitedLength <Boolean?>]`: Indicates whether values in the column should be able to exceed the standard limit of 255 characters.
          - `[ColumnName <String>]`: The name of the lookup source column.
          - `[ListId <String>]`: The unique identifier of the lookup source list.
          - `[PrimaryLookupColumnId <String>]`: If specified, this column is a secondary lookup, pulling an additional field from the list item looked up by the primary lookup. Use the list item looked up by the primary as the source for the column named here.
        - `[Name <String>]`: The API-facing name of the column as it appears in the [fields][] on a [listItem][]. For the user-facing name, see displayName.
        - `[Number <IMicrosoftGraphNumberColumn1>]`: numberColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DecimalPlace <String>]`: How many decimal places to display. See below for information about the possible values.
          - `[DisplayAs <String>]`: How the value should be presented in the UX. Must be one of number or percentage. If unspecified, treated as number.
          - `[Maximum <Double?>]`: The maximum permitted value.
          - `[Minimum <Double?>]`: The minimum permitted value.
        - `[PersonOrGroup <IMicrosoftGraphPersonOrGroupColumn1>]`: personOrGroupColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[AllowMultipleSelection <Boolean?>]`: Indicates whether multiple values can be selected from the source.
          - `[ChooseFromType <String>]`: Whether to allow selection of people only, or people and groups. Must be one of peopleAndGroups or peopleOnly.
          - `[DisplayAs <String>]`: How to display the information about the person or group chosen. See below.
        - `[ReadOnly <Boolean?>]`: Specifies whether the column values can be modified.
        - `[Required <Boolean?>]`: Specifies whether the column value is not optional.
        - `[Text <IMicrosoftGraphTextColumn1>]`: textColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[AllowMultipleLine <Boolean?>]`: Whether to allow multiple lines of text.
          - `[AppendChangesToExistingText <Boolean?>]`: Whether updates to this column should replace existing text, or append to it.
          - `[LinesForEditing <Int32?>]`: The size of the text box.
          - `[MaxLength <Int32?>]`: The maximum number of characters for the value.
          - `[TextType <String>]`: The type of text being stored. Must be one of plain or richText
      - `[ContentType <IMicrosoftGraphContentType1[]>]`: The collection of content types present in this list.
        - `[Id <String>]`: Read-only.
        - `[ColumnLink <IMicrosoftGraphColumnLink1[]>]`: The collection of columns that are required by this content type
          - `[Id <String>]`: Read-only.
          - `[Name <String>]`: The name of the column  in this content type.
        - `[Description <String>]`: The descriptive text for the item.
        - `[Group <String>]`: The name of the group this content type belongs to. Helps organize related content types.
        - `[Hidden <Boolean?>]`: Indicates whether the content type is hidden in the list's 'New' menu.
        - `[InheritedFrom <IMicrosoftGraphItemReference1>]`: itemReference
        - `[Name <String>]`: The name of the content type.
        - `[Order <IMicrosoftGraphContentTypeOrder1>]`: contentTypeOrder
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Default <Boolean?>]`: Whether this is the default Content Type
          - `[Position <Int32?>]`: Specifies the position in which the Content Type appears in the selection UI.
        - `[ParentId <String>]`: The unique identifier of the content type.
        - `[ReadOnly <Boolean?>]`: If true, the content type cannot be modified unless this value is first set to false.
        - `[Sealed <Boolean?>]`: If true, the content type cannot be modified by users or through push-down operations. Only site collection administrators can seal or unseal content types.
      - `[DisplayName <String>]`: The displayable title of the list.
      - `[Drive <IMicrosoftGraphDrive1>]`: drive
      - `[Items <IMicrosoftGraphListItem1[]>]`: All items contained in the list.
      - `[List <IMicrosoftGraphListInfo1>]`: listInfo
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ContentTypesEnabled <Boolean?>]`: If true, indicates that content types are enabled for this list.
        - `[Hidden <Boolean?>]`: If true, indicates that the list is not normally visible in the SharePoint user experience.
        - `[Template <String>]`: An enumerated value that represents the base list template used in creating the list. Possible values include documentLibrary, genericList, task, survey, announcements, contacts, and more.
      - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
      - `[Subscription <IMicrosoftGraphSubscription1[]>]`: The set of subscriptions on the list.
      - `[System <IMicrosoftGraphSystemFacet>]`: systemFacet
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Owner <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[Quota <IMicrosoftGraphQuota1>]`: quota
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Deleted <Int64?>]`: Total space consumed by files in the recycle bin, in bytes. Read-only.
      - `[Remaining <Int64?>]`: Total space remaining before reaching the quota limit, in bytes. Read-only.
      - `[State <String>]`: Enumeration value that indicates the state of the storage space. Read-only.
      - `[StoragePlanInformation <IMicrosoftGraphStoragePlanInformation1>]`: storagePlanInformation
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[UpgradeAvailable <Boolean?>]`: Indicates if there are higher storage quota plans available. Read-only.
      - `[Total <Int64?>]`: Total allowed storage space, in bytes. Read-only.
      - `[Used <Int64?>]`: Total space used, in bytes. Read-only.
    - `[Root <IMicrosoftGraphDriveItem1>]`: driveItem
    - `[SharePointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
    - `[Special <IMicrosoftGraphDriveItem1[]>]`: Collection of common folders available in OneDrive. Read-only. Nullable.
    - `[System <IMicrosoftGraphSystemFacet>]`: systemFacet
  - `[EmployeeHireDate <DateTime?>]`: The date and time when the user was hired or will start work in case of a future hire. Supports $filter (eq, ne, NOT , ge, le, in).
  - `[EmployeeId <String>]`: The employee identifier assigned to the user by the organization. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
  - `[EmployeeOrgData <IMicrosoftGraphEmployeeOrgData1>]`: employeeOrgData
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[CostCenter <String>]`: The cost center associated with the user. Returned only on $select. Supports $filter.
    - `[Division <String>]`: The name of the division in which the user works. Returned only on $select. Supports $filter.
  - `[EmployeeType <String>]`: Captures enterprise worker type. For example, Employee, Contractor, Consultant, or Vendor. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
  - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the user. Nullable.
  - `[ExternalUserState <String>]`: For an external user invited to the tenant using the invitation API, this property represents the invited user's invitation status. For invited users, the state can be PendingAcceptance or Accepted, or null for all other users. Supports $filter (eq, ne, NOT , in).
  - `[ExternalUserStateChangeDateTime <DateTime?>]`: Shows the timestamp for the latest change to the externalUserState property. Supports $filter (eq, ne, NOT , in).
  - `[FaxNumber <String>]`: The fax number of the user. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
  - `[FollowedSite <IMicrosoftGraphSite1[]>]`: 
    - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
    - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
    - `[Description <String>]`: Provides a user-visible description of the item. Optional.
    - `[ETag <String>]`: ETag for the item. Read-only.
    - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
    - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
    - `[Name <String>]`: The name of the item. Read-write.
    - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
    - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
    - `[Id <String>]`: Read-only.
    - `[Analytic <IMicrosoftGraphItemAnalytics1>]`: itemAnalytics
    - `[Column <IMicrosoftGraphColumnDefinition1[]>]`: The collection of column definitions reusable across lists under this site.
    - `[ContentType <IMicrosoftGraphContentType1[]>]`: The collection of content types defined for this site.
    - `[DisplayName <String>]`: The full title for the site. Read-only.
    - `[Drive <IMicrosoftGraphDrive1>]`: drive
    - `[Drives <IMicrosoftGraphDrive1[]>]`: The collection of drives (document libraries) under this site.
    - `[Error <IMicrosoftGraphPublicError1>]`: publicError
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Code <String>]`: Represents the error code.
      - `[Detail <IMicrosoftGraphPublicErrorDetail1[]>]`: Details of the error.
        - `[Code <String>]`: The error code.
        - `[Message <String>]`: The error message.
        - `[Target <String>]`: The target of the error.
      - `[InnerError <IMicrosoftGraphPublicInnerError1>]`: publicInnerError
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Code <String>]`: The error code.
        - `[Detail <IMicrosoftGraphPublicErrorDetail1[]>]`: A collection of error details.
        - `[Message <String>]`: The error message.
        - `[Target <String>]`: The target of the error.
      - `[Message <String>]`: A non-localized message for the developer.
      - `[Target <String>]`: The target of the error.
    - `[Items <IMicrosoftGraphBaseItem1[]>]`: Used to address any item contained in this site. This collection cannot be enumerated.
      - `[Id <String>]`: Read-only.
      - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
      - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
      - `[Description <String>]`: Provides a user-visible description of the item. Optional.
      - `[ETag <String>]`: ETag for the item. Read-only.
      - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
      - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
      - `[Name <String>]`: The name of the item. Read-write.
      - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
      - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
    - `[List <IMicrosoftGraphList1[]>]`: The collection of lists under this site.
    - `[Onenote <IMicrosoftGraphOnenote1>]`: onenote
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[Notebook <IMicrosoftGraphNotebook1[]>]`: The collection of OneNote notebooks that are owned by the user or group. Read-only. Nullable.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[DisplayName <String>]`: The name of the notebook.
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedDateTime <DateTime?>]`: The date and time when the notebook was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
        - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
        - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
        - `[Id <String>]`: Read-only.
        - `[IsDefault <Boolean?>]`: Indicates whether this is the user's default notebook. Read-only.
        - `[IsShared <Boolean?>]`: Indicates whether the notebook is shared. If true, the contents of the notebook can be seen by people other than the owner. Read-only.
        - `[Link <IMicrosoftGraphNotebookLinks1>]`: notebookLinks
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[OneNoteClientUrl <IMicrosoftGraphExternalLink1>]`: externalLink
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Href <String>]`: The url of the link.
          - `[OneNoteWebUrl <IMicrosoftGraphExternalLink1>]`: externalLink
        - `[Section <IMicrosoftGraphOnenoteSection1[]>]`: The sections in the notebook. Read-only. Nullable.
          - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[DisplayName <String>]`: The name of the notebook.
          - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[LastModifiedDateTime <DateTime?>]`: The date and time when the notebook was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
          - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
          - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
          - `[Id <String>]`: Read-only.
          - `[IsDefault <Boolean?>]`: Indicates whether this is the user's default section. Read-only.
          - `[Link <IMicrosoftGraphSectionLinks1>]`: sectionLinks
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[OneNoteClientUrl <IMicrosoftGraphExternalLink1>]`: externalLink
            - `[OneNoteWebUrl <IMicrosoftGraphExternalLink1>]`: externalLink
          - `[Page <IMicrosoftGraphOnenotePage1[]>]`: The collection of pages in the section.  Read-only. Nullable.
            - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
            - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
            - `[Id <String>]`: Read-only.
            - `[Content <Byte[]>]`: The page's HTML content.
            - `[ContentUrl <String>]`: The URL for the page's HTML content.  Read-only.
            - `[CreatedByAppId <String>]`: The unique identifier of the application that created the page. Read-only.
            - `[LastModifiedDateTime <DateTime?>]`: The date and time when the page was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
            - `[Level <Int32?>]`: The indentation level of the page. Read-only.
            - `[Link <IMicrosoftGraphPageLinks1>]`: pageLinks
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[OneNoteClientUrl <IMicrosoftGraphExternalLink1>]`: externalLink
              - `[OneNoteWebUrl <IMicrosoftGraphExternalLink1>]`: externalLink
            - `[Order <Int32?>]`: The order of the page within its parent section. Read-only.
            - `[ParentNotebook <IMicrosoftGraphNotebook1>]`: notebook
            - `[ParentSection <IMicrosoftGraphOnenoteSection1>]`: onenoteSection
            - `[Title <String>]`: The title of the page.
            - `[UserTag <String[]>]`: 
          - `[PagesUrl <String>]`: The pages endpoint where you can get details for all the pages in the section. Read-only.
          - `[ParentNotebook <IMicrosoftGraphNotebook1>]`: notebook
          - `[ParentSectionGroup <IMicrosoftGraphSectionGroup1>]`: sectionGroup
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[DisplayName <String>]`: The name of the notebook.
            - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[LastModifiedDateTime <DateTime?>]`: The date and time when the notebook was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
            - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
            - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
            - `[Id <String>]`: Read-only.
            - `[ParentNotebook <IMicrosoftGraphNotebook1>]`: notebook
            - `[ParentSectionGroup <IMicrosoftGraphSectionGroup1>]`: sectionGroup
            - `[Section <IMicrosoftGraphOnenoteSection1[]>]`: The sections in the section group. Read-only. Nullable.
            - `[SectionGroup <IMicrosoftGraphSectionGroup1[]>]`: The section groups in the section. Read-only. Nullable.
            - `[SectionGroupsUrl <String>]`: The URL for the sectionGroups navigation property, which returns all the section groups in the section group. Read-only.
            - `[SectionsUrl <String>]`: The URL for the sections navigation property, which returns all the sections in the section group. Read-only.
        - `[SectionGroup <IMicrosoftGraphSectionGroup1[]>]`: The section groups in the notebook. Read-only. Nullable.
        - `[SectionGroupsUrl <String>]`: The URL for the sectionGroups navigation property, which returns all the section groups in the notebook. Read-only.
        - `[SectionsUrl <String>]`: The URL for the sections navigation property, which returns all the sections in the notebook. Read-only.
        - `[UserRole <String>]`: onenoteUserRole
      - `[Operation <IMicrosoftGraphOnenoteOperation1[]>]`: The status of OneNote operations. Getting an operations collection is not supported, but you can get the status of long-running operations if the Operation-Location header is returned in the response. Read-only. Nullable.
        - `[CreatedDateTime <DateTime?>]`: The start time of the operation.
        - `[LastActionDateTime <DateTime?>]`: The time of the last action of the operation.
        - `[Status <String>]`: operationStatus
        - `[Id <String>]`: Read-only.
        - `[Error <IMicrosoftGraphOnenoteOperationError1>]`: onenoteOperationError
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Code <String>]`: The error code.
          - `[Message <String>]`: The error message.
        - `[PercentComplete <String>]`: The operation percent complete if the operation is still in running status.
        - `[ResourceId <String>]`: The resource id.
        - `[ResourceLocation <String>]`: The resource URI for the object. For example, the resource URI for a copied page or section.
      - `[Page <IMicrosoftGraphOnenotePage1[]>]`: The pages in all OneNote notebooks that are owned by the user or group.  Read-only. Nullable.
      - `[Resource <IMicrosoftGraphOnenoteResource1[]>]`: The image and other file resources in OneNote pages. Getting a resources collection is not supported, but you can get the binary content of a specific resource. Read-only. Nullable.
        - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
        - `[Id <String>]`: Read-only.
        - `[Content <Byte[]>]`: The content stream
        - `[ContentUrl <String>]`: The URL for downloading the content
      - `[Section <IMicrosoftGraphOnenoteSection1[]>]`: The sections in all OneNote notebooks that are owned by the user or group.  Read-only. Nullable.
      - `[SectionGroup <IMicrosoftGraphSectionGroup1[]>]`: The section groups in all OneNote notebooks that are owned by the user or group.  Read-only. Nullable.
    - `[Permission <IMicrosoftGraphPermission1[]>]`: The permissions associated with the site. Nullable.
    - `[Root <IMicrosoftGraphRoot>]`: root
    - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
    - `[Site <IMicrosoftGraphSite1[]>]`: The collection of the sub-sites under this site.
    - `[SiteCollection <IMicrosoftGraphSiteCollection1>]`: siteCollection
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[DataLocationCode <String>]`: The geographic region code for where this site collection resides. Read-only.
      - `[Hostname <String>]`: The hostname for the site collection. Read-only.
      - `[Root <IMicrosoftGraphRoot>]`: root
  - `[GivenName <String>]`: The given name (first name) of the user. Maximum length is 64 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
  - `[HireDate <DateTime?>]`: The hire date of the user. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.  Returned only on $select.  Note: This property is specific to SharePoint Online. We recommend using the native employeeHireDate property to set and update hire date values using Microsoft Graph APIs.
  - `[Identity <IMicrosoftGraphObjectIdentity1[]>]`: Represents the identities that can be used to sign in to this user account. An identity can be provided by Microsoft (also known as a local account), by organizations, or by social identity providers such as Facebook, Google, and Microsoft, and tied to a user account. May contain multiple items with the same signInType value. Supports $filter (eq) only where the signInType is not userPrincipalName.
    - `[Issuer <String>]`: Specifies the issuer of the identity, for example facebook.com.For local accounts (where signInType is not federated), this property is the local B2C tenant default domain name, for example contoso.onmicrosoft.com.For external users from other Azure AD organization, this will be the domain of the federated organization, for example contoso.com.Supports $filter. 512 character limit.
    - `[IssuerAssignedId <String>]`: Specifies the unique identifier assigned to the user by the issuer. The combination of issuer and issuerAssignedId must be unique within the organization. Represents the sign-in name for the user, when signInType is set to emailAddress or userName (also known as local accounts).When signInType is set to: emailAddress, (or a custom string that starts with emailAddress like emailAddress1) issuerAssignedId must be a valid email addressuserName, issuerAssignedId must be a valid local part of an email addressSupports $filter. 100 character limit.
    - `[SignInType <String>]`: Specifies the user sign-in types in your directory, such as emailAddress, userName or federated. Here, federated represents a unique identifier for a user from an issuer, that can be in any format chosen by the issuer. Additional validation is enforced on issuerAssignedId when the sign-in type is set to emailAddress or userName. This property can also be set to any custom string.
  - `[InferenceClassification <IMicrosoftGraphInferenceClassification1>]`: inferenceClassification
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Id <String>]`: Read-only.
    - `[Override <IMicrosoftGraphInferenceClassificationOverride1[]>]`: A set of overrides for a user to always classify messages from specific senders in certain ways: focused, or other. Read-only. Nullable.
      - `[Id <String>]`: Read-only.
      - `[ClassifyAs <String>]`: inferenceClassificationType
      - `[SenderEmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
  - `[Insight <IMicrosoftGraphOfficeGraphInsights1>]`: officeGraphInsights
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Id <String>]`: Read-only.
    - `[Shared <IMicrosoftGraphSharedInsight1[]>]`: Access this property from the derived type itemInsights.
      - `[Id <String>]`: Read-only.
      - `[LastShared <IMicrosoftGraphSharingDetail1>]`: sharingDetail
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[SharedBy <IMicrosoftGraphInsightIdentity1>]`: insightIdentity
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Address <String>]`: The email address of the user who shared the item.
          - `[DisplayName <String>]`: The display name of the user who shared the item.
          - `[Id <String>]`: The id of the user who shared the item.
        - `[SharedDateTime <DateTime?>]`: The date and time the file was last shared. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
        - `[SharingReference <IMicrosoftGraphResourceReference1>]`: resourceReference
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: The item's unique identifier.
          - `[Type <String>]`: A string value that can be used to classify the item, such as 'microsoft.graph.driveItem'
          - `[WebUrl <String>]`: A URL leading to the referenced item.
        - `[SharingSubject <String>]`: The subject with which the document was shared.
        - `[SharingType <String>]`: Determines the way the document was shared, can be by a 'Link', 'Attachment', 'Group', 'Site'.
      - `[LastSharedMethodId <String>]`: Read-only.
      - `[ResourceId <String>]`: Read-only.
      - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
      - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ContainerDisplayName <String>]`: A string describing where the item is stored. For example, the name of a SharePoint site or the user name identifying the owner of the OneDrive storing the item.
        - `[ContainerType <String>]`: Can be used for filtering by the type of container in which the file is stored. Such as Site or OneDriveBusiness.
        - `[ContainerWebUrl <String>]`: A path leading to the folder in which the item is stored.
        - `[MediaType <String>]`: The item's media type. Can be used for filtering for a specific type of file based on supported IANA Media Mime Types. Note that not all Media Mime Types are supported.
        - `[PreviewImageUrl <String>]`: A URL leading to the preview image for the item.
        - `[PreviewText <String>]`: A preview text for the item.
        - `[Title <String>]`: The item's title text.
        - `[Type <String>]`: The item's media type. Can be used for filtering for a specific file based on a specific type. See below for supported types.
      - `[SharingHistory <IMicrosoftGraphSharingDetail1[]>]`: 
    - `[Trending <IMicrosoftGraphTrending1[]>]`: Access this property from the derived type itemInsights.
      - `[Id <String>]`: Read-only.
      - `[LastModifiedDateTime <DateTime?>]`: 
      - `[ResourceId <String>]`: Read-only.
      - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
      - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
      - `[Weight <Double?>]`: Value indicating how much the document is currently trending. The larger the number, the more the document is currently trending around the user (the more relevant it is). Returned documents are sorted by this value.
    - `[Used <IMicrosoftGraphUsedInsight1[]>]`: Access this property from the derived type itemInsights.
      - `[Id <String>]`: Read-only.
      - `[LastUsed <IMicrosoftGraphUsageDetails1>]`: usageDetails
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[LastAccessedDateTime <DateTime?>]`: The date and time the resource was last accessed by the user. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
        - `[LastModifiedDateTime <DateTime?>]`: The date and time the resource was last modified by the user. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
      - `[ResourceId <String>]`: Read-only.
      - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
      - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
  - `[Interest <String[]>]`: A list for the user to describe their interests. Returned only on $select.
  - `[IsResourceAccount <Boolean?>]`: Do not use – reserved for future use.
  - `[JobTitle <String>]`: The user's job title. Maximum length is 128 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
  - `[Mail <String>]`: The SMTP address for the user, for example, admin@contoso.com. Changes to this property will also update the user's proxyAddresses collection to include the value as an SMTP address. While this property can contain accent characters, using them can cause access issues with other Microsoft applications for the user. Supports $filter (eq, ne, NOT, ge, le, in, startsWith, endsWith).
  - `[MailNickname <String>]`: The mail alias for the user. This property must be specified when a user is created. Maximum length is 64 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[MailboxSetting <IMicrosoftGraphMailboxSettings1>]`: mailboxSettings
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[ArchiveFolder <String>]`: Folder ID of an archive folder for the user. Read only.
    - `[AutomaticRepliesSetting <IMicrosoftGraphAutomaticRepliesSetting1>]`: automaticRepliesSetting
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ExternalAudience <String>]`: externalAudienceScope
      - `[ExternalReplyMessage <String>]`: The automatic reply to send to the specified external audience, if Status is AlwaysEnabled or Scheduled.
      - `[InternalReplyMessage <String>]`: The automatic reply to send to the audience internal to the signed-in user's organization, if Status is AlwaysEnabled or Scheduled.
      - `[ScheduledEndDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
      - `[ScheduledStartDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
      - `[Status <String>]`: automaticRepliesStatus
    - `[DateFormat <String>]`: The date format for the user's mailbox.
    - `[DelegateMeetingMessageDeliveryOption <String>]`: delegateMeetingMessageDeliveryOptions
    - `[Language <IMicrosoftGraphLocaleInfo1>]`: localeInfo
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[DisplayName <String>]`: A name representing the user's locale in natural language, for example, 'English (United States)'.
      - `[Locale <String>]`: A locale representation for the user, which includes the user's preferred language and country/region. For example, 'en-us'. The language component follows 2-letter codes as defined in ISO 639-1, and the country component follows 2-letter codes as defined in ISO 3166-1 alpha-2.
    - `[TimeFormat <String>]`: The time format for the user's mailbox.
    - `[TimeZone <String>]`: The default time zone for the user's mailbox.
    - `[WorkingHour <IMicrosoftGraphWorkingHours1>]`: workingHours
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[DaysOfWeek <String[]>]`: The days of the week on which the user works.
      - `[EndTime <String>]`: The time of the day that the user stops working.
      - `[StartTime <String>]`: The time of the day that the user starts working.
      - `[TimeZone <IMicrosoftGraphTimeZoneBase1>]`: timeZoneBase
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Name <String>]`: The name of a time zone. It can be a standard time zone name such as 'Hawaii-Aleutian Standard Time', or 'Customized Time Zone' for a custom time zone.
  - `[ManagedAppRegistration <IMicrosoftGraphManagedAppRegistration1[]>]`: Zero or more managed app registrations that belong to the user.
    - `[Id <String>]`: Read-only.
    - `[AppIdentifier <IMicrosoftGraphMobileAppIdentifier>]`: The identifier for a mobile app.
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[ApplicationVersion <String>]`: App version
    - `[AppliedPolicy <IMicrosoftGraphManagedAppPolicy1[]>]`: Zero or more policys already applied on the registered app when it last synchronized with managment service.
      - `[Id <String>]`: Read-only.
      - `[CreatedDateTime <DateTime?>]`: The date and time the policy was created.
      - `[Description <String>]`: The policy's description.
      - `[DisplayName <String>]`: Policy display name.
      - `[LastModifiedDateTime <DateTime?>]`: Last time the policy was modified.
      - `[Version <String>]`: Version of the entity.
    - `[CreatedDateTime <DateTime?>]`: Date and time of creation
    - `[DeviceName <String>]`: Host device name
    - `[DeviceTag <String>]`: App management SDK generated tag, which helps relate apps hosted on the same device. Not guaranteed to relate apps in all conditions.
    - `[DeviceType <String>]`: Host device type
    - `[FlaggedReason <String[]>]`: Zero or more reasons an app registration is flagged. E.g. app running on rooted device
    - `[IntendedPolicy <IMicrosoftGraphManagedAppPolicy1[]>]`: Zero or more policies admin intended for the app as of now.
    - `[LastSyncDateTime <DateTime?>]`: Date and time of last the app synced with management service.
    - `[ManagementSdkVersion <String>]`: App management SDK version
    - `[Operation <IMicrosoftGraphManagedAppOperation1[]>]`: Zero or more long running operations triggered on the app registration.
      - `[Id <String>]`: Read-only.
      - `[DisplayName <String>]`: The operation name.
      - `[LastModifiedDateTime <DateTime?>]`: The last time the app operation was modified.
      - `[State <String>]`: The current state of the operation
      - `[Version <String>]`: Version of the entity.
    - `[PlatformVersion <String>]`: Operating System version
    - `[UserId <String>]`: The user Id to who this app registration belongs.
    - `[Version <String>]`: Version of the entity.
  - `[ManagedDevice <IMicrosoftGraphManagedDevice1[]>]`: The managed devices associated with the user.
    - `[Id <String>]`: Read-only.
    - `[ActivationLockBypassCode <String>]`: Code that allows the Activation Lock on a device to be bypassed. This property is read-only.
    - `[AndroidSecurityPatchLevel <String>]`: Android security patch level. This property is read-only.
    - `[AzureAdDeviceId <String>]`: The unique identifier for the Azure Active Directory device. Read only. This property is read-only.
    - `[AzureAdRegistered <Boolean?>]`: Whether the device is Azure Active Directory registered. This property is read-only.
    - `[ComplianceGracePeriodExpirationDateTime <DateTime?>]`: The DateTime when device compliance grace period expires. This property is read-only.
    - `[ComplianceState <String>]`: complianceState
    - `[ConfigurationManagerClientEnabledFeature <IMicrosoftGraphConfigurationManagerClientEnabledFeatures1>]`: configuration Manager client enabled features
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[CompliancePolicy <Boolean?>]`: Whether compliance policy is managed by Intune
      - `[DeviceConfiguration <Boolean?>]`: Whether device configuration is managed by Intune
      - `[Inventory <Boolean?>]`: Whether inventory is managed by Intune
      - `[ModernApp <Boolean?>]`: Whether modern application is managed by Intune
      - `[ResourceAccess <Boolean?>]`: Whether resource access is managed by Intune
      - `[WindowsUpdateForBusiness <Boolean?>]`: Whether Windows Update for Business is managed by Intune
    - `[DeviceActionResult <IMicrosoftGraphDeviceActionResult1[]>]`: List of ComplexType deviceActionResult objects. This property is read-only.
      - `[ActionName <String>]`: Action name
      - `[ActionState <String>]`: actionState
      - `[LastUpdatedDateTime <DateTime?>]`: Time the action state was last updated
      - `[StartDateTime <DateTime?>]`: Time the action was initiated
    - `[DeviceCategory <IMicrosoftGraphDeviceCategory1>]`: Device categories provides a way to organize your devices. Using device categories, company administrators can define their own categories that make sense to their company. These categories can then be applied to a device in the Intune Azure console or selected by a user during device enrollment. You can filter reports and create dynamic Azure Active Directory device groups based on device categories.
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[Description <String>]`: Optional description for the device category.
      - `[DisplayName <String>]`: Display name for the device category.
    - `[DeviceCategoryDisplayName <String>]`: Device category display name. This property is read-only.
    - `[DeviceCompliancePolicyState <IMicrosoftGraphDeviceCompliancePolicyState1[]>]`: Device compliance policy states for this device.
      - `[Id <String>]`: Read-only.
      - `[DisplayName <String>]`: The name of the policy for this policyBase
      - `[PlatformType <String>]`: policyPlatformType
      - `[SettingCount <Int32?>]`: Count of how many setting a policy holds
      - `[SettingState <IMicrosoftGraphDeviceCompliancePolicySettingState1[]>]`: 
        - `[CurrentValue <String>]`: Current value of setting on device
        - `[ErrorCode <Int64?>]`: Error code for the setting
        - `[ErrorDescription <String>]`: Error description
        - `[InstanceDisplayName <String>]`: Name of setting instance that is being reported.
        - `[Setting <String>]`: The setting that is being reported
        - `[SettingName <String>]`: Localized/user friendly setting name that is being reported
        - `[Source <IMicrosoftGraphSettingSource1[]>]`: Contributing policies
          - `[DisplayName <String>]`: Not yet documented
          - `[Id <String>]`: Not yet documented
        - `[State <String>]`: complianceStatus
        - `[UserEmail <String>]`: UserEmail
        - `[UserId <String>]`: UserId
        - `[UserName <String>]`: UserName
        - `[UserPrincipalName <String>]`: UserPrincipalName.
      - `[State <String>]`: complianceStatus
      - `[Version <Int32?>]`: The version of the policy
    - `[DeviceConfigurationState <IMicrosoftGraphDeviceConfigurationState1[]>]`: Device configuration states for this device.
      - `[Id <String>]`: Read-only.
      - `[DisplayName <String>]`: The name of the policy for this policyBase
      - `[PlatformType <String>]`: policyPlatformType
      - `[SettingCount <Int32?>]`: Count of how many setting a policy holds
      - `[SettingState <IMicrosoftGraphDeviceConfigurationSettingState1[]>]`: 
        - `[CurrentValue <String>]`: Current value of setting on device
        - `[ErrorCode <Int64?>]`: Error code for the setting
        - `[ErrorDescription <String>]`: Error description
        - `[InstanceDisplayName <String>]`: Name of setting instance that is being reported.
        - `[Setting <String>]`: The setting that is being reported
        - `[SettingName <String>]`: Localized/user friendly setting name that is being reported
        - `[Source <IMicrosoftGraphSettingSource1[]>]`: Contributing policies
        - `[State <String>]`: complianceStatus
        - `[UserEmail <String>]`: UserEmail
        - `[UserId <String>]`: UserId
        - `[UserName <String>]`: UserName
        - `[UserPrincipalName <String>]`: UserPrincipalName.
      - `[State <String>]`: complianceStatus
      - `[Version <Int32?>]`: The version of the policy
    - `[DeviceEnrollmentType <String>]`: deviceEnrollmentType
    - `[DeviceHealthAttestationState <IMicrosoftGraphDeviceHealthAttestationState1>]`: deviceHealthAttestationState
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[AttestationIdentityKey <String>]`: TWhen an Attestation Identity Key (AIK) is present on a device, it indicates that the device has an endorsement key (EK) certificate.
      - `[BitLockerStatus <String>]`: On or Off of BitLocker Drive Encryption
      - `[BootAppSecurityVersion <String>]`: The security version number of the Boot Application
      - `[BootDebugging <String>]`: When bootDebugging is enabled, the device is used in development and testing
      - `[BootManagerSecurityVersion <String>]`: The security version number of the Boot Application
      - `[BootManagerVersion <String>]`: The version of the Boot Manager
      - `[BootRevisionListInfo <String>]`: The Boot Revision List that was loaded during initial boot on the attested device
      - `[CodeIntegrity <String>]`: When code integrity is enabled, code execution is restricted to integrity verified code
      - `[CodeIntegrityCheckVersion <String>]`: The version of the Boot Manager
      - `[CodeIntegrityPolicy <String>]`: The Code Integrity policy that is controlling the security of the boot environment
      - `[ContentNamespaceUrl <String>]`: The DHA report version. (Namespace version)
      - `[ContentVersion <String>]`: The HealthAttestation state schema version
      - `[DataExcutionPolicy <String>]`: DEP Policy defines a set of hardware and software technologies that perform additional checks on memory
      - `[DeviceHealthAttestationStatus <String>]`: The DHA report version. (Namespace version)
      - `[EarlyLaunchAntiMalwareDriverProtection <String>]`: ELAM provides protection for the computers in your network when they start up
      - `[HealthAttestationSupportedStatus <String>]`: This attribute indicates if DHA is supported for the device
      - `[HealthStatusMismatchInfo <String>]`: This attribute appears if DHA-Service detects an integrity issue
      - `[IssuedDateTime <DateTime?>]`: The DateTime when device was evaluated or issued to MDM
      - `[LastUpdateDateTime <String>]`: The Timestamp of the last update.
      - `[OperatingSystemKernelDebugging <String>]`: When operatingSystemKernelDebugging is enabled, the device is used in development and testing
      - `[OperatingSystemRevListInfo <String>]`: The Operating System Revision List that was loaded during initial boot on the attested device
      - `[Pcr0 <String>]`: The measurement that is captured in PCR[0]
      - `[PcrHashAlgorithm <String>]`: Informational attribute that identifies the HASH algorithm that was used by TPM
      - `[ResetCount <Int64?>]`: The number of times a PC device has hibernated or resumed
      - `[RestartCount <Int64?>]`: The number of times a PC device has rebooted
      - `[SafeMode <String>]`: Safe mode is a troubleshooting option for Windows that starts your computer in a limited state
      - `[SecureBoot <String>]`: When Secure Boot is enabled, the core components must have the correct cryptographic signatures
      - `[SecureBootConfigurationPolicyFingerPrint <String>]`: Fingerprint of the Custom Secure Boot Configuration Policy
      - `[TestSigning <String>]`: When test signing is allowed, the device does not enforce signature validation during boot
      - `[TpmVersion <String>]`: The security version number of the Boot Application
      - `[VirtualSecureMode <String>]`: VSM is a container that protects high value assets from a compromised kernel
      - `[WindowsPe <String>]`: Operating system running with limited services that is used to prepare a computer for Windows
    - `[DeviceName <String>]`: Name of the device. This property is read-only.
    - `[DeviceRegistrationState <String>]`: deviceRegistrationState
    - `[EasActivated <Boolean?>]`: Whether the device is Exchange ActiveSync activated. This property is read-only.
    - `[EasActivationDateTime <DateTime?>]`: Exchange ActivationSync activation time of the device. This property is read-only.
    - `[EasDeviceId <String>]`: Exchange ActiveSync Id of the device. This property is read-only.
    - `[EmailAddress <String>]`: Email(s) for the user associated with the device. This property is read-only.
    - `[EnrolledDateTime <DateTime?>]`: Enrollment time of the device. This property is read-only.
    - `[EthernetMacAddress <String>]`: Ethernet MAC. This property is read-only.
    - `[ExchangeAccessState <String>]`: deviceManagementExchangeAccessState
    - `[ExchangeAccessStateReason <String>]`: deviceManagementExchangeAccessStateReason
    - `[ExchangeLastSuccessfulSyncDateTime <DateTime?>]`: Last time the device contacted Exchange. This property is read-only.
    - `[FreeStorageSpaceInByte <Int64?>]`: Free Storage in Bytes. This property is read-only.
    - `[Iccid <String>]`: Integrated Circuit Card Identifier, it is A SIM card's unique identification number. This property is read-only.
    - `[Imei <String>]`: IMEI. This property is read-only.
    - `[IsEncrypted <Boolean?>]`: Device encryption status. This property is read-only.
    - `[IsSupervised <Boolean?>]`: Device supervised status. This property is read-only.
    - `[JailBroken <String>]`: whether the device is jail broken or rooted. This property is read-only.
    - `[LastSyncDateTime <DateTime?>]`: The date and time that the device last completed a successful sync with Intune. This property is read-only.
    - `[ManagedDeviceName <String>]`: Automatically generated name to identify a device. Can be overwritten to a user friendly name.
    - `[ManagedDeviceOwnerType <String>]`: managedDeviceOwnerType
    - `[ManagementAgent <String>]`: managementAgentType
    - `[Manufacturer <String>]`: Manufacturer of the device. This property is read-only.
    - `[Meid <String>]`: MEID. This property is read-only.
    - `[Model <String>]`: Model of the device. This property is read-only.
    - `[Note <String>]`: Notes on the device created by IT Admin
    - `[OSVersion <String>]`: Operating system version of the device. This property is read-only.
    - `[OperatingSystem <String>]`: Operating system of the device. Windows, iOS, etc. This property is read-only.
    - `[PartnerReportedThreatState <String>]`: managedDevicePartnerReportedHealthState
    - `[PhoneNumber <String>]`: Phone number of the device. This property is read-only.
    - `[PhysicalMemoryInByte <Int64?>]`: Total Memory in Bytes. This property is read-only.
    - `[RemoteAssistanceSessionErrorDetail <String>]`: An error string that identifies issues when creating Remote Assistance session objects. This property is read-only.
    - `[RemoteAssistanceSessionUrl <String>]`: Url that allows a Remote Assistance session to be established with the device. This property is read-only.
    - `[SerialNumber <String>]`: SerialNumber. This property is read-only.
    - `[SubscriberCarrier <String>]`: Subscriber Carrier. This property is read-only.
    - `[TotalStorageSpaceInByte <Int64?>]`: Total Storage in Bytes. This property is read-only.
    - `[Udid <String>]`: Unique Device Identifier for iOS and macOS devices. This property is read-only.
    - `[UserDisplayName <String>]`: User display name. This property is read-only.
    - `[UserId <String>]`: Unique Identifier for the user associated with the device. This property is read-only.
    - `[UserPrincipalName <String>]`: Device user principal name. This property is read-only.
    - `[WiFiMacAddress <String>]`: Wi-Fi MAC. This property is read-only.
  - `[Manager <IMicrosoftGraphDirectoryObject>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
  - `[MobilePhone <String>]`: The primary cellular telephone number for the user. Read-only for users synced from on-premises directory.  Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[MySite <String>]`: The URL for the user's personal site. Returned only on $select.
  - `[Oauth2PermissionGrant <IMicrosoftGraphOAuth2PermissionGrant1[]>]`: 
    - `[Id <String>]`: Read-only.
    - `[ClientId <String>]`: The id of the client service principal for the application which is authorized to act on behalf of a signed-in user when accessing an API. Required. Supports $filter (eq only).
    - `[ConsentType <String>]`: Indicates whether authorization is granted for the client application to impersonate all users or only a specific user. AllPrincipals indicates authorization to impersonate all users. Principal indicates authorization to impersonate a specific user. Consent on behalf of all users can be granted by an administrator. Non-admin users may be authorized to consent on behalf of themselves in some cases, for some delegated permissions. Required. Supports $filter (eq only).
    - `[PrincipalId <String>]`: The id of the user on behalf of whom the client is authorized to access the resource, when consentType is Principal. If consentType is AllPrincipals this value is null. Required when consentType is Principal.
    - `[ResourceId <String>]`: The id of the resource service principal to which access is authorized. This identifies the API which the client is authorized to attempt to call on behalf of a signed-in user.
    - `[Scope <String>]`: A space-separated list of the claim values for delegated permissions which should be included in access tokens for the resource application (the API). For example, openid User.Read GroupMember.Read.All. Each claim value should match the value field of one of the delegated permissions defined by the API, listed in the publishedPermissionScopes property of the resource service principal.
  - `[OfficeLocation <String>]`: The office location in the user's place of business. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[OnPremisesExtensionAttribute <IMicrosoftGraphOnPremisesExtensionAttributes1>]`: onPremisesExtensionAttributes
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[ExtensionAttribute1 <String>]`: First customizable extension attribute.
    - `[ExtensionAttribute10 <String>]`: Tenth customizable extension attribute.
    - `[ExtensionAttribute11 <String>]`: Eleventh customizable extension attribute.
    - `[ExtensionAttribute12 <String>]`: Twelfth customizable extension attribute.
    - `[ExtensionAttribute13 <String>]`: Thirteenth customizable extension attribute.
    - `[ExtensionAttribute14 <String>]`: Fourteenth customizable extension attribute.
    - `[ExtensionAttribute15 <String>]`: Fifteenth customizable extension attribute.
    - `[ExtensionAttribute2 <String>]`: Second customizable extension attribute.
    - `[ExtensionAttribute3 <String>]`: Third customizable extension attribute.
    - `[ExtensionAttribute4 <String>]`: Fourth customizable extension attribute.
    - `[ExtensionAttribute5 <String>]`: Fifth customizable extension attribute.
    - `[ExtensionAttribute6 <String>]`: Sixth customizable extension attribute.
    - `[ExtensionAttribute7 <String>]`: Seventh customizable extension attribute.
    - `[ExtensionAttribute8 <String>]`: Eighth customizable extension attribute.
    - `[ExtensionAttribute9 <String>]`: Ninth customizable extension attribute.
  - `[OnPremisesImmutableId <String>]`: This property is used to associate an on-premises Active Directory user account to their Azure AD user object. This property must be specified when creating a new user account in the Graph if you are using a federated domain for the user's userPrincipalName (UPN) property. Note: The $ and _ characters cannot be used when specifying this property. Supports $filter (eq, ne, NOT, ge, le, in).
  - `[OnPremisesProvisioningError <IMicrosoftGraphOnPremisesProvisioningError1[]>]`: Errors when using Microsoft synchronization product during provisioning.  Supports $filter (eq, NOT, ge, le).
  - `[Onenote <IMicrosoftGraphOnenote1>]`: onenote
  - `[OnlineMeeting <IMicrosoftGraphOnlineMeeting1[]>]`: 
    - `[Id <String>]`: Read-only.
    - `[AllowAttendeeToEnableCamera <Boolean?>]`: Indicates whether attendees can turn on their camera.
    - `[AllowAttendeeToEnableMic <Boolean?>]`: Indicates whether attendees can turn on their microphone.
    - `[AllowMeetingChat <String>]`: meetingChatMode
    - `[AllowTeamworkReaction <Boolean?>]`: Indicates if Teams reactions are enabled for the meeting.
    - `[AllowedPresenter <String>]`: onlineMeetingPresenters
    - `[AudioConferencing <IMicrosoftGraphAudioConferencing1>]`: audioConferencing
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ConferenceId <String>]`: The conference id of the online meeting.
      - `[DialinUrl <String>]`: A URL to the externally-accessible web page that contains dial-in information.
      - `[TollFreeNumber <String>]`: The toll-free number that connects to the Audio Conference Provider.
      - `[TollNumber <String>]`: The toll number that connects to the Audio Conference Provider.
    - `[ChatInfo <IMicrosoftGraphChatInfo1>]`: chatInfo
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[MessageId <String>]`: The unique identifier for a message in a Microsoft Teams channel.
      - `[ReplyChainMessageId <String>]`: The ID of the reply message.
      - `[ThreadId <String>]`: The unique identifier for a thread in Microsoft Teams.
    - `[CreationDateTime <DateTime?>]`: The meeting creation time in UTC. Read-only.
    - `[EndDateTime <DateTime?>]`: The meeting end time in UTC.
    - `[ExternalId <String>]`: The external ID. A custom ID. Optional.
    - `[IsEntryExitAnnounced <Boolean?>]`: Indicates whether to announce when callers join or leave.
    - `[JoinInformation <IMicrosoftGraphItemBody1>]`: itemBody
    - `[JoinWebUrl <String>]`: The join URL of the online meeting. Read-only.
    - `[LobbyBypassSetting <IMicrosoftGraphLobbyBypassSettings1>]`: lobbyBypassSettings
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[IsDialInBypassEnabled <Boolean?>]`: Specifies whether or not to always let dial-in callers bypass the lobby. Optional.
      - `[Scope <String>]`: lobbyBypassScope
    - `[Participant <IMicrosoftGraphMeetingParticipants1>]`: meetingParticipants
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Attendee <IMicrosoftGraphMeetingParticipantInfo1[]>]`: Information of the meeting attendees.
        - `[Identity <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[Role <String>]`: onlineMeetingRole
        - `[Upn <String>]`: User principal name of the participant.
      - `[Organizer <IMicrosoftGraphMeetingParticipantInfo1>]`: meetingParticipantInfo
    - `[StartDateTime <DateTime?>]`: The meeting start time in UTC.
    - `[Subject <String>]`: The subject of the online meeting.
    - `[VideoTeleconferenceId <String>]`: The video teleconferencing ID. Read-only.
  - `[OtherMail <String[]>]`: A list of additional email addresses for the user; for example: ['bob@contoso.com', 'Robert@fabrikam.com'].NOTE: While this property can contain accent characters, they can cause access issues to first-party applications for the user.Supports $filter (eq, NOT, ge, le, in, startsWith).
  - `[Outlook <IMicrosoftGraphOutlookUser1>]`: outlookUser
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Id <String>]`: Read-only.
    - `[MasterCategory <IMicrosoftGraphOutlookCategory1[]>]`: A list of categories defined for the user.
      - `[Id <String>]`: Read-only.
      - `[Color <String>]`: categoryColor
      - `[DisplayName <String>]`: A unique name that identifies a category in the user's mailbox. After a category is created, the name cannot be changed. Read-only.
  - `[PasswordPolicy <String>]`: Specifies password policies for the user. This value is an enumeration with one possible value being DisableStrongPassword, which allows weaker passwords than the default policy to be specified. DisablePasswordExpiration can also be specified. The two may be specified together; for example: DisablePasswordExpiration, DisableStrongPassword.Supports $filter (ne, NOT).
  - `[PasswordProfile <IMicrosoftGraphPasswordProfile1>]`: passwordProfile
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[ForceChangePasswordNextSignIn <Boolean?>]`: true if the user must change her password on the next login; otherwise false. If not set, default is false. NOTE:  For Azure B2C tenants, set to false and instead use custom policies and user flows to force password reset at first sign in. See Force password reset at first logon.
    - `[ForceChangePasswordNextSignInWithMfa <Boolean?>]`: If true, at next sign-in, the user must perform a multi-factor authentication (MFA) before being forced to change their password. The behavior is identical to forceChangePasswordNextSignIn except that the user is required to first perform a multi-factor authentication before password change. After a password change, this property will be automatically reset to false. If not set, default is false.
    - `[Password <String>]`: The password for the user. This property is required when a user is created. It can be updated, but the user will be required to change the password on the next login. The password must satisfy minimum requirements as specified by the user’s passwordPolicies property. By default, a strong password is required.
  - `[PastProject <String[]>]`: A list for the user to enumerate their past projects. Returned only on $select.
  - `[Photo <IMicrosoftGraphProfilePhoto1>]`: profilePhoto
  - `[Planner <IMicrosoftGraphPlannerUser1>]`: plannerUser
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Id <String>]`: Read-only.
    - `[Plan <IMicrosoftGraphPlannerPlan1[]>]`: Read-only. Nullable. Returns the plannerTasks assigned to the user.
    - `[Task <IMicrosoftGraphPlannerTask1[]>]`: Read-only. Nullable. Returns the plannerTasks assigned to the user.
  - `[PostalCode <String>]`: The postal code for the user's postal address. The postal code is specific to the user's country/region. In the United States of America, this attribute contains the ZIP code. Maximum length is 40 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[PreferredLanguage <String>]`: The preferred language for the user. Should follow ISO 639-1 Code; for example en-US. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[PreferredName <String>]`: The preferred name for the user. Returned only on $select.
  - `[Presence <IMicrosoftGraphPresence>]`: presence
    - `[Id <String>]`: Read-only.
    - `[Activity <String>]`: The supplemental information to a user's availability. Possible values are Available, Away, BeRightBack, Busy, DoNotDisturb, InACall, InAConferenceCall, Inactive,InAMeeting, Offline, OffWork,OutOfOffice, PresenceUnknown,Presenting, UrgentInterruptionsOnly.
    - `[Availability <String>]`: The base presence information for a user. Possible values are Available, AvailableIdle,  Away, BeRightBack, Busy, BusyIdle, DoNotDisturb, Offline, PresenceUnknown
  - `[Responsibility <String[]>]`: A list for the user to enumerate their responsibilities. Returned only on $select.
  - `[School <String[]>]`: A list for the user to enumerate the schools they have attended. Returned only on $select.
  - `[Setting <IMicrosoftGraphUserSettings1>]`: userSettings
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Id <String>]`: Read-only.
    - `[ContributionToContentDiscoveryAsOrganizationDisabled <Boolean?>]`: Reflects the Office Delve organization level setting. When set to true, the organization doesn't have access to Office Delve. This setting is read-only and can only be changed by administrators in the SharePoint admin center.
    - `[ContributionToContentDiscoveryDisabled <Boolean?>]`: When set to true, documents in the user's Office Delve are disabled. Users can control this setting in Office Delve.
    - `[ShiftPreference <IMicrosoftGraphShiftPreferences1>]`: shiftPreferences
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
      - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
      - `[Id <String>]`: Read-only.
      - `[Availability <IMicrosoftGraphShiftAvailability1[]>]`: Availability of the user to be scheduled for work and its recurrence pattern.
        - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
        - `[TimeSlot <IMicrosoftGraphTimeRange1[]>]`: The time slot(s) preferred by the user.
          - `[EndTime <String>]`: End time for the time range.
          - `[StartTime <String>]`: Start time for the time range.
        - `[TimeZone <String>]`: Specifies the time zone for the indicated time.
  - `[ShowInAddressList <Boolean?>]`: true if the Outlook global address list should contain this user, otherwise false. If not set, this will be treated as true. For users invited through the invitation manager, this property will be set to false. Supports $filter (eq, ne, NOT, in).
  - `[Skill <String[]>]`: A list for the user to enumerate their skills. Returned only on $select.
  - `[State <String>]`: The state or province in the user's address. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[StreetAddress <String>]`: The street address of the user's place of business. Maximum length is 1024 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[Surname <String>]`: The user's surname (family name or last name). Maximum length is 64 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[Teamwork <IMicrosoftGraphUserTeamwork>]`: userTeamwork
    - `[Id <String>]`: Read-only.
    - `[InstalledApp <IMicrosoftGraphUserScopeTeamsAppInstallation1[]>]`: The apps installed in the personal scope of this user.
      - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
      - `[TeamsAppDefinition <IMicrosoftGraphTeamsAppDefinition1>]`: teamsAppDefinition
      - `[Id <String>]`: Read-only.
      - `[ChatCreatedDateTime <DateTime?>]`: Date and time at which the chat was created. Read-only.
      - `[ChatId <String>]`: Read-only.
      - `[ChatInstalledApp <IMicrosoftGraphTeamsAppInstallation1[]>]`: A collection of all the apps in the chat. Nullable.
      - `[ChatLastUpdatedDateTime <DateTime?>]`: Date and time at which the chat was renamed or list of members were last changed. Read-only.
      - `[ChatMember <IMicrosoftGraphConversationMember1[]>]`: A collection of all the members in the chat. Nullable.
      - `[ChatMessage <IMicrosoftGraphChatMessage1[]>]`: A collection of all the messages in the chat. Nullable.
      - `[ChatTab <IMicrosoftGraphTeamsTab1[]>]`: 
      - `[ChatTopic <String>]`: (Optional) Subject or topic for the chat. Only available for group chats.
      - `[ChatType <String>]`: chatType
  - `[Todo <IMicrosoftGraphTodo1>]`: todo
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Id <String>]`: Read-only.
    - `[List <IMicrosoftGraphTodoTaskList1[]>]`: The task lists in the users mailbox.
      - `[Id <String>]`: Read-only.
      - `[DisplayName <String>]`: The name of the task list.
      - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the task list. Nullable.
      - `[IsOwner <Boolean?>]`: True if the user is owner of the given task list.
      - `[IsShared <Boolean?>]`: True if the task list is shared with other users
      - `[Task <IMicrosoftGraphTodoTask1[]>]`: The tasks in this task list. Read-only. Nullable.
        - `[Id <String>]`: Read-only.
        - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
        - `[BodyLastModifiedDateTime <DateTime?>]`: The date and time when the task was last modified. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
        - `[CompletedDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[CreatedDateTime <DateTime?>]`: The date and time when the task was created. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
        - `[DueDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the task. Nullable.
        - `[Importance <String>]`: importance
        - `[IsReminderOn <Boolean?>]`: Set to true if an alert is set to remind the user of the task.
        - `[LastModifiedDateTime <DateTime?>]`: The date and time when the task was last modified. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
        - `[LinkedResource <IMicrosoftGraphLinkedResource1[]>]`: A collection of resources linked to the task.
          - `[Id <String>]`: Read-only.
          - `[ApplicationName <String>]`: Field indicating the app name of the source that is sending the linkedResource.
          - `[DisplayName <String>]`: Field indicating the title of the linkedResource.
          - `[ExternalId <String>]`: Id of the object that is associated with this task on the third-party/partner system.
          - `[WebUrl <String>]`: Deep link to the linkedResource.
        - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
        - `[ReminderDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[Status <String>]`: taskStatus
        - `[Title <String>]`: A brief description of the task.
      - `[WellknownListName <String>]`: wellknownListName
  - `[TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>]`: 
  - `[UsageLocation <String>]`: A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement to check for availability of services in countries.  Examples include: US, JP, and GB. Not nullable. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[UserPrincipalName <String>]`: The user principal name (UPN) of the user. The UPN is an Internet-style login name for the user based on the Internet standard RFC 822. By convention, this should map to the user's email name. The general format is alias@domain, where domain must be present in the tenant's collection of verified domains. This property is required when a user is created. The verified domains for the tenant can be accessed from the verifiedDomains property of organization.NOTE: While this property can contain accent characters, they can cause access issues to first-party applications for the user. Supports $filter (eq, ne, NOT, ge, le, in, startsWith, endsWith) and $orderBy.
  - `[UserType <String>]`: A string value that can be used to classify user types in your directory, such as Member and Guest. Supports $filter (eq, ne, NOT, in,).

CALENDAR <IMicrosoftGraphCalendar1>: calendar
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Read-only.
  - `[AllowedOnlineMeetingProvider <String[]>]`: Represent the online meeting service providers that can be used to create online meetings in this calendar. Possible values are: unknown, skypeForBusiness, skypeForConsumer, teamsForBusiness.
  - `[CalendarPermission <IMicrosoftGraphCalendarPermission1[]>]`: The permissions of the users with whom the calendar is shared.
    - `[Id <String>]`: Read-only.
    - `[AllowedRole <String[]>]`: List of allowed sharing or delegating permission levels for the calendar. Possible values are: none, freeBusyRead, limitedRead, read, write, delegateWithoutPrivateEventAccess, delegateWithPrivateEventAccess, custom.
    - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Address <String>]`: The email address of an entity instance.
      - `[Name <String>]`: The display name of an entity instance.
    - `[IsInsideOrganization <Boolean?>]`: True if the user in context (sharee or delegate) is inside the same organization as the calendar owner.
    - `[IsRemovable <Boolean?>]`: True if the user can be removed from the list of sharees or delegates for the specified calendar, false otherwise. The 'My organization' user determines the permissions other people within your organization have to the given calendar. You cannot remove 'My organization' as a sharee to a calendar.
    - `[Role <String>]`: calendarRoleType
  - `[CalendarView <IMicrosoftGraphEvent1[]>]`: The calendar view for the calendar. Navigation property. Read-only.
    - `[Category <String[]>]`: The categories associated with the item
    - `[ChangeKey <String>]`: Identifies the version of the item. Every time the item is changed, changeKey changes as well. This allows Exchange to apply changes to the correct version of the object. Read-only.
    - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
    - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
    - `[Id <String>]`: Read-only.
    - `[AllowNewTimeProposal <Boolean?>]`: True if the meeting organizer allows invitees to propose a new time when responding, false otherwise. Optional. Default is true.
    - `[Attachment <IMicrosoftGraphAttachment1[]>]`: The collection of FileAttachment, ItemAttachment, and referenceAttachment attachments for the event. Navigation property. Read-only. Nullable.
      - `[Id <String>]`: Read-only.
      - `[ContentType <String>]`: The MIME type.
      - `[IsInline <Boolean?>]`: true if the attachment is an inline attachment; otherwise, false.
      - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
      - `[Name <String>]`: The display name of the attachment. This does not need to be the actual file name.
      - `[Size <Int32?>]`: The length of the attachment in bytes.
    - `[Attendee <IMicrosoftGraphAttendee1[]>]`: The collection of attendees for the event.
      - `[Type <String>]`: attendeeType
      - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
      - `[ProposedNewTime <IMicrosoftGraphTimeSlot1>]`: timeSlot
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[End <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DateTime <String>]`: A single point of time in a combined date and time representation ({date}T{time}). For example, '2019-04-16T09:00:00'.
          - `[TimeZone <String>]`: Represents a time zone, for example, 'Pacific Standard Time'. See below for possible values.
        - `[Start <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
      - `[Status <IMicrosoftGraphResponseStatus1>]`: responseStatus
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Response <String>]`: responseType
        - `[Time <DateTime?>]`: The date and time that the response was returned. It uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
    - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Content <String>]`: The content of the item.
      - `[ContentType <String>]`: bodyType
    - `[BodyPreview <String>]`: The preview of the message associated with the event. It is in text format.
    - `[Calendar <IMicrosoftGraphCalendar1>]`: calendar
    - `[End <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
    - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the event. Nullable.
      - `[Id <String>]`: Read-only.
    - `[HasAttachment <Boolean?>]`: Set to true if the event has attachments.
    - `[HideAttendee <Boolean?>]`: When set to true, each attendee only sees themselves in the meeting request and meeting Tracking list. Default is false.
    - `[ICalUid <String>]`: A unique identifier for an event across calendars. This ID is different for each occurrence in a recurring series. Read-only.
    - `[Importance <String>]`: importance
    - `[Instance <IMicrosoftGraphEvent1[]>]`: The occurrences of a recurring series, if the event is a series master. This property includes occurrences that are part of the recurrence pattern, and exceptions that have been modified, but does not include occurrences that have been cancelled from the series. Navigation property. Read-only. Nullable.
    - `[IsAllDay <Boolean?>]`: Set to true if the event lasts all day.
    - `[IsCancelled <Boolean?>]`: Set to true if the event has been canceled.
    - `[IsDraft <Boolean?>]`: Set to true if the user has updated the meeting in Outlook but has not sent the updates to attendees. Set to false if all changes have been sent, or if the event is an appointment without any attendees.
    - `[IsOnlineMeeting <Boolean?>]`: True if this event has online meeting information, false otherwise. Default is false. Optional.
    - `[IsOrganizer <Boolean?>]`: Set to true if the calendar owner (specified by the owner property of the calendar) is the organizer of the event (specified by the organizer property of the event). This also applies if a delegate organized the event on behalf of the owner.
    - `[IsReminderOn <Boolean?>]`: Set to true if an alert is set to remind the user of the event.
    - `[Location <IMicrosoftGraphLocation1[]>]`: The locations where the event is held or attended from. The location and locations properties always correspond with each other. If you update the location property, any prior locations in the locations collection would be removed and replaced by the new location value.
      - `[Address <IMicrosoftGraphPhysicalAddress1>]`: physicalAddress
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[City <String>]`: The city.
        - `[CountryOrRegion <String>]`: The country or region. It's a free-format string value, for example, 'United States'.
        - `[PostalCode <String>]`: The postal code.
        - `[State <String>]`: The state.
        - `[Street <String>]`: The street.
      - `[Coordinate <IMicrosoftGraphOutlookGeoCoordinates1>]`: outlookGeoCoordinates
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Accuracy <Double?>]`: The accuracy of the latitude and longitude. As an example, the accuracy can be measured in meters, such as the latitude and longitude are accurate to within 50 meters.
        - `[Altitude <Double?>]`: The altitude of the location.
        - `[AltitudeAccuracy <Double?>]`: The accuracy of the altitude.
        - `[Latitude <Double?>]`: The latitude of the location.
        - `[Longitude <Double?>]`: The longitude of the location.
      - `[DisplayName <String>]`: The name associated with the location.
      - `[LocationEmailAddress <String>]`: Optional email address of the location.
      - `[LocationType <String>]`: locationType
      - `[LocationUri <String>]`: Optional URI representing the location.
      - `[UniqueId <String>]`: For internal use only.
      - `[UniqueIdType <String>]`: locationUniqueIdType
    - `[Location1 <IMicrosoftGraphLocation1>]`: location
    - `[MultiValueExtendedProperty <IMicrosoftGraphMultiValueLegacyExtendedProperty1[]>]`: The collection of multi-value extended properties defined for the event. Read-only. Nullable.
      - `[Id <String>]`: Read-only.
      - `[Value <String[]>]`: A collection of property values.
    - `[OnlineMeeting <IMicrosoftGraphOnlineMeetingInfo1>]`: onlineMeetingInfo
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ConferenceId <String>]`: The ID of the conference.
      - `[JoinUrl <String>]`: The external link that launches the online meeting. This is a URL that clients will launch into a browser and will redirect the user to join the meeting.
      - `[Phone <IMicrosoftGraphPhone1[]>]`: All of the phone numbers associated with this conference.
        - `[Language <String>]`: 
        - `[Number <String>]`: The phone number.
        - `[Region <String>]`: 
        - `[Type <String>]`: phoneType
      - `[QuickDial <String>]`: The pre-formatted quickdial for this call.
      - `[TollFreeNumber <String[]>]`: The toll free numbers that can be used to join the conference.
      - `[TollNumber <String>]`: The toll number that can be used to join the conference.
    - `[OnlineMeetingProvider <String>]`: onlineMeetingProviderType
    - `[OnlineMeetingUrl <String>]`: A URL for an online meeting. The property is set only when an organizer specifies an event as an online meeting such as a Skype meeting. Read-only.
    - `[Organizer <IMicrosoftGraphRecipient1>]`: recipient
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
    - `[OriginalEndTimeZone <String>]`: The end time zone that was set when the event was created. A value of tzone://Microsoft/Custom indicates that a legacy custom time zone was set in desktop Outlook.
    - `[OriginalStart <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
    - `[OriginalStartTimeZone <String>]`: The start time zone that was set when the event was created. A value of tzone://Microsoft/Custom indicates that a legacy custom time zone was set in desktop Outlook.
    - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Pattern <IMicrosoftGraphRecurrencePattern1>]`: recurrencePattern
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DayOfMonth <Int32?>]`: The day of the month on which the event occurs. Required if type is absoluteMonthly or absoluteYearly.
        - `[DaysOfWeek <String[]>]`: A collection of the days of the week on which the event occurs. Possible values are: sunday, monday, tuesday, wednesday, thursday, friday, saturday. If type is relativeMonthly or relativeYearly, and daysOfWeek specifies more than one day, the event falls on the first day that satisfies the pattern.  Required if type is weekly, relativeMonthly, or relativeYearly.
        - `[FirstDayOfWeek <String>]`: dayOfWeek
        - `[Index <String>]`: weekIndex
        - `[Interval <Int32?>]`: The number of units between occurrences, where units can be in days, weeks, months, or years, depending on the type. Required.
        - `[Month <Int32?>]`: The month in which the event occurs.  This is a number from 1 to 12.
        - `[Type <String>]`: recurrencePatternType
      - `[Range <IMicrosoftGraphRecurrenceRange1>]`: recurrenceRange
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[EndDate <DateTime?>]`: The date to stop applying the recurrence pattern. Depending on the recurrence pattern of the event, the last occurrence of the meeting may not be this date. Required if type is endDate.
        - `[NumberOfOccurrence <Int32?>]`: The number of times to repeat the event. Required and must be positive if type is numbered.
        - `[RecurrenceTimeZone <String>]`: Time zone for the startDate and endDate properties. Optional. If not specified, the time zone of the event is used.
        - `[StartDate <DateTime?>]`: The date to start applying the recurrence pattern. The first occurrence of the meeting may be this date or later, depending on the recurrence pattern of the event. Must be the same value as the start property of the recurring event. Required.
        - `[Type <String>]`: recurrenceRangeType
    - `[ReminderMinutesBeforeStart <Int32?>]`: The number of minutes before the event start time that the reminder alert occurs.
    - `[ResponseRequested <Boolean?>]`: Default is true, which represents the organizer would like an invitee to send a response to the event.
    - `[ResponseStatus <IMicrosoftGraphResponseStatus1>]`: responseStatus
    - `[Sensitivity <String>]`: sensitivity
    - `[SeriesMasterId <String>]`: The ID for the recurring series master item, if this event is part of a recurring series.
    - `[ShowAs <String>]`: freeBusyStatus
    - `[SingleValueExtendedProperty <IMicrosoftGraphSingleValueLegacyExtendedProperty1[]>]`: The collection of single-value extended properties defined for the event. Read-only. Nullable.
      - `[Id <String>]`: Read-only.
      - `[Value <String>]`: A property value.
    - `[Start <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
    - `[Subject <String>]`: The text of the event's subject line.
    - `[TransactionId <String>]`: A custom identifier specified by a client app for the server to avoid redundant POST operations in case of client retries to create the same event. This is useful when low network connectivity causes the client to time out before receiving a response from the server for the client's prior create-event request. After you set transactionId when creating an event, you cannot change transactionId in a subsequent update. This property is only returned in a response payload if an app has set it. Optional.
    - `[Type <String>]`: eventType
    - `[WebLink <String>]`: The URL to open the event in Outlook on the web.Outlook on the web opens the event in the browser if you are signed in to your mailbox. Otherwise, Outlook on the web prompts you to sign in.This URL cannot be accessed from within an iFrame.
  - `[CanEdit <Boolean?>]`: true if the user can write to the calendar, false otherwise. This property is true for the user who created the calendar. This property is also true for a user who has been shared a calendar and granted write access, through an Outlook client or the corresponding calendarPermission resource. Read-only.
  - `[CanShare <Boolean?>]`: true if the user has the permission to share the calendar, false otherwise. Only the user who created the calendar can share it. Read-only.
  - `[CanViewPrivateItem <Boolean?>]`: true if the user can read calendar items that have been marked private, false otherwise. This property is set through an Outlook client or the corresponding calendarPermission resource. Read-only.
  - `[ChangeKey <String>]`: Identifies the version of the calendar object. Every time the calendar is changed, changeKey changes as well. This allows Exchange to apply changes to the correct version of the object. Read-only.
  - `[Color <String>]`: calendarColor
  - `[DefaultOnlineMeetingProvider <String>]`: onlineMeetingProviderType
  - `[Event <IMicrosoftGraphEvent1[]>]`: The events in the calendar. Navigation property. Read-only.
  - `[HexColor <String>]`: The calendar color, expressed in a hex color code of three hexadecimal values, each ranging from 00 to FF and representing the red, green, or blue components of the color in the RGB color space. If the user has never explicitly set a color for the calendar, this property is  empty.
  - `[IsDefaultCalendar <Boolean?>]`: true if this is the default calendar where new events are created by default, false otherwise.
  - `[IsRemovable <Boolean?>]`: Indicates whether this user calendar can be deleted from the user mailbox.
  - `[IsTallyingResponse <Boolean?>]`: Indicates whether this user calendar supports tracking of meeting responses. Only meeting invites sent from users' primary calendars support tracking of meeting responses.
  - `[MultiValueExtendedProperty <IMicrosoftGraphMultiValueLegacyExtendedProperty1[]>]`: The collection of multi-value extended properties defined for the calendar. Read-only. Nullable.
  - `[Name <String>]`: The calendar name.
  - `[Owner <IMicrosoftGraphEmailAddress1>]`: emailAddress
  - `[SingleValueExtendedProperty <IMicrosoftGraphSingleValueLegacyExtendedProperty1[]>]`: The collection of single-value extended properties defined for the calendar. Read-only. Nullable.

CHAT <IMicrosoftGraphChat[]>: .
  - `[Id <String>]`: Read-only.
  - `[ChatType <String>]`: chatType
  - `[CreatedDateTime <DateTime?>]`: Date and time at which the chat was created. Read-only.
  - `[InstalledApp <IMicrosoftGraphTeamsAppInstallation1[]>]`: A collection of all the apps in the chat. Nullable.
    - `[Id <String>]`: Read-only.
    - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[AppDefinition <IMicrosoftGraphTeamsAppDefinition1[]>]`: The details for each version of the app.
        - `[Id <String>]`: Read-only.
        - `[Bot <IMicrosoftGraphTeamworkBot1>]`: teamworkBot
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Application <IMicrosoftGraphIdentity1>]`: identity
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
            - `[Id <String>]`: Unique identifier for the identity.
          - `[Device <IMicrosoftGraphIdentity1>]`: identity
          - `[User <IMicrosoftGraphIdentity1>]`: identity
        - `[Description <String>]`: Verbose description of the application.
        - `[DisplayName <String>]`: The name of the app provided by the app developer.
        - `[LastModifiedDateTime <DateTime?>]`: 
        - `[PublishingState <String>]`: teamsAppPublishingState
        - `[ShortDescription <String>]`: Short description of the application.
        - `[TeamsAppId <String>]`: The ID from the Teams app manifest.
        - `[Version <String>]`: The version number of the application.
      - `[DisplayName <String>]`: The name of the catalog app provided by the app developer in the Microsoft Teams zip app package.
      - `[DistributionMethod <String>]`: teamsAppDistributionMethod
      - `[ExternalId <String>]`: The ID of the catalog provided by the app developer in the Microsoft Teams zip app package.
    - `[TeamsAppDefinition <IMicrosoftGraphTeamsAppDefinition1>]`: teamsAppDefinition
  - `[LastUpdatedDateTime <DateTime?>]`: Date and time at which the chat was renamed or list of members were last changed. Read-only.
  - `[Member <IMicrosoftGraphConversationMember1[]>]`: A collection of all the members in the chat. Nullable.
    - `[Id <String>]`: Read-only.
    - `[DisplayName <String>]`: The display name of the user.
    - `[Role <String[]>]`: The roles for that user.
    - `[VisibleHistoryStartDateTime <DateTime?>]`: The timestamp denoting how far back a conversation's history is shared with the conversation member. This property is settable only for members of a chat.
  - `[Message <IMicrosoftGraphChatMessage1[]>]`: A collection of all the messages in the chat. Nullable.
    - `[Id <String>]`: Read-only.
    - `[Attachment <IMicrosoftGraphChatMessageAttachment1[]>]`: Attached files. Attachments are currently read-only – sending attachments is not supported.
      - `[Content <String>]`: The content of the attachment. If the attachment is a rich card, set the property to the rich card object. This property and contentUrl are mutually exclusive.
      - `[ContentType <String>]`: The media type of the content attachment. It can have the following values: reference: Attachment is a link to another file. Populate the contentURL with the link to the object.Any contentTypes supported by the Bot Framework's Attachment objectapplication/vnd.microsoft.card.codesnippet: A code snippet. application/vnd.microsoft.card.announcement: An announcement header.
      - `[ContentUrl <String>]`: URL for the content of the attachment. Supported protocols: http, https, file and data.
      - `[Id <String>]`: Read-only. Unique id of the attachment.
      - `[Name <String>]`: Name of the attachment.
      - `[ThumbnailUrl <String>]`: URL to a thumbnail image that the channel can use if it supports using an alternative, smaller form of content or contentUrl. For example, if you set contentType to application/word and set contentUrl to the location of the Word document, you might include a thumbnail image that represents the document. The channel could display the thumbnail image instead of the document. When the user clicks the image, the channel would open the document.
    - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Content <String>]`: The content of the item.
      - `[ContentType <String>]`: bodyType
    - `[ChannelIdentity <IMicrosoftGraphChannelIdentity1>]`: channelIdentity
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ChannelId <String>]`: The identity of the channel in which the message was posted.
      - `[TeamId <String>]`: The identity of the team in which the message was posted.
    - `[ChatId <String>]`: If the message was sent in a chat, represents the identity of the chat.
    - `[CreatedDateTime <DateTime?>]`: Timestamp of when the chat message was created.
    - `[DeletedDateTime <DateTime?>]`: Read only. Timestamp at which the chat message was deleted, or null if not deleted.
    - `[Etag <String>]`: Read-only. Version number of the chat message.
    - `[From <IMicrosoftGraphChatMessageFromIdentitySet1>]`: chatMessageFromIdentitySet
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Application <IMicrosoftGraphIdentity1>]`: identity
      - `[Device <IMicrosoftGraphIdentity1>]`: identity
      - `[User <IMicrosoftGraphIdentity1>]`: identity
    - `[HostedContent <IMicrosoftGraphChatMessageHostedContent1[]>]`: Content in a message hosted by Microsoft Teams - for example, images or code snippets.
      - `[ContentByte <Byte[]>]`: Write only. Bytes for the hosted content (such as images).
      - `[ContentType <String>]`: Write only. Content type, such as image/png, image/jpg.
      - `[Id <String>]`: Read-only.
    - `[Importance <String>]`: chatMessageImportance
    - `[LastEditedDateTime <DateTime?>]`: Read only. Timestamp when edits to the chat message were made. Triggers an 'Edited' flag in the Teams UI. If no edits are made the value is null.
    - `[LastModifiedDateTime <DateTime?>]`: Read only. Timestamp when the chat message is created (initial setting) or modified, including when a reaction is added or removed.
    - `[Locale <String>]`: Locale of the chat message set by the client. Always set to en-us.
    - `[Mention <IMicrosoftGraphChatMessageMention1[]>]`: List of entities mentioned in the chat message. Currently supports user, bot, team, channel.
      - `[Id <Int32?>]`: Index of an entity being mentioned in the specified chatMessage. Matches the {index} value in the corresponding <at id='{index}'> tag in the message body.
      - `[MentionText <String>]`: String used to represent the mention. For example, a user's display name, a team name.
      - `[Mentioned <IMicrosoftGraphChatMessageMentionedIdentitySet1>]`: chatMessageMentionedIdentitySet
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Application <IMicrosoftGraphIdentity1>]`: identity
        - `[Device <IMicrosoftGraphIdentity1>]`: identity
        - `[User <IMicrosoftGraphIdentity1>]`: identity
        - `[Conversation <IMicrosoftGraphTeamworkConversationIdentity1>]`: teamworkConversationIdentity
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
          - `[Id <String>]`: Unique identifier for the identity.
          - `[ConversationIdentityType <String>]`: teamworkConversationIdentityType
    - `[MessageType <String>]`: chatMessageType
    - `[PolicyViolation <IMicrosoftGraphChatMessagePolicyViolation1>]`: chatMessagePolicyViolation
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[DlpAction <String>]`: chatMessagePolicyViolationDlpActionTypes
      - `[JustificationText <String>]`: Justification text provided by the sender of the message when overriding a policy violation.
      - `[PolicyTip <IMicrosoftGraphChatMessagePolicyViolationPolicyTip1>]`: chatMessagePolicyViolationPolicyTip
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ComplianceUrl <String>]`: The URL a user can visit to read about the data loss prevention policies for the organization. (ie, policies about what users shouldn't say in chats)
        - `[GeneralText <String>]`: Explanatory text shown to the sender of the message.
        - `[MatchedConditionDescription <String[]>]`: The list of improper data in the message that was detected by the data loss prevention app. Each DLP app defines its own conditions, examples include 'Credit Card Number' and 'Social Security Number'.
      - `[UserAction <String>]`: chatMessagePolicyViolationUserActionTypes
      - `[VerdictDetail <String>]`: chatMessagePolicyViolationVerdictDetailsTypes
    - `[Reaction <IMicrosoftGraphChatMessageReaction1[]>]`: Reactions for this chat message (for example, Like).
      - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
      - `[ReactionType <String>]`: Supported values are like, angry, sad, laugh, heart, surprised.
      - `[User <IMicrosoftGraphChatMessageReactionIdentitySet1>]`: chatMessageReactionIdentitySet
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Application <IMicrosoftGraphIdentity1>]`: identity
        - `[Device <IMicrosoftGraphIdentity1>]`: identity
        - `[User <IMicrosoftGraphIdentity1>]`: identity
    - `[Reply <IMicrosoftGraphChatMessage1[]>]`: Replies for a specified message.
    - `[ReplyToId <String>]`: Read-only. ID of the parent chat message or root chat message of the thread. (Only applies to chat messages in channels, not chats.)
    - `[Subject <String>]`: The subject of the chat message, in plaintext.
    - `[Summary <String>]`: Summary text of the chat message that could be used for push notifications and summary views or fall back views. Only applies to channel chat messages, not chat messages in a chat.
    - `[WebUrl <String>]`: Read-only. Link to the message in Microsoft Teams.
  - `[Tab <IMicrosoftGraphTeamsTab1[]>]`: 
    - `[Id <String>]`: Read-only.
    - `[Configuration <IMicrosoftGraphTeamsTabConfiguration1>]`: teamsTabConfiguration
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ContentUrl <String>]`: Url used for rendering tab contents in Teams. Required.
      - `[EntityId <String>]`: Identifier for the entity hosted by the tab provider.
      - `[RemoveUrl <String>]`: Url called by Teams client when a Tab is removed using the Teams Client.
      - `[WebsiteUrl <String>]`: Url for showing tab contents outside of Teams.
    - `[DisplayName <String>]`: Name of the tab.
    - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
    - `[WebUrl <String>]`: Deep link URL of the tab instance. Read only.
  - `[Topic <String>]`: (Optional) Subject or topic for the chat. Only available for group chats.

DEVICEMANAGEMENTTROUBLESHOOTINGEVENT <IMicrosoftGraphDeviceManagementTroubleshootingEvent1[]>: The list of troubleshooting events for this user.
  - `[Id <String>]`: Read-only.
  - `[CorrelationId <String>]`: Id used for tracing the failure in the service.
  - `[EventDateTime <DateTime?>]`: Time when the event occurred .

DRIVE <IMicrosoftGraphDrive1>: drive
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Application <IMicrosoftGraphIdentity1>]`: identity
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
      - `[Id <String>]`: Unique identifier for the identity.
    - `[Device <IMicrosoftGraphIdentity1>]`: identity
    - `[User <IMicrosoftGraphIdentity1>]`: identity
  - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
    - `[DeletedDateTime <DateTime?>]`: 
    - `[Id <String>]`: Read-only.
    - `[AboutMe <String>]`: A freeform text entry field for the user to describe themselves. Returned only on $select.
    - `[AccountEnabled <Boolean?>]`: true if the account is enabled; otherwise, false. This property is required when a user is created. Supports $filter (eq, ne, NOT, and in).
    - `[AgeGroup <String>]`: Sets the age group of the user. Allowed values: null, minor, notAdult and adult. Refer to the legal age group property definitions for further information. Supports $filter (eq, ne, NOT, and in).
    - `[AppRoleAssignment <IMicrosoftGraphAppRoleAssignment1[]>]`: Represents the app roles a user has been granted for an application. Supports $expand.
      - `[DeletedDateTime <DateTime?>]`: 
      - `[Id <String>]`: Read-only.
      - `[AppRoleId <String>]`: The identifier (id) for the app role which is assigned to the principal. This app role must be exposed in the appRoles property on the resource application's service principal (resourceId). If the resource application has not declared any app roles, a default app role ID of 00000000-0000-0000-0000-000000000000 can be specified to signal that the principal is assigned to the resource app without any specific app roles. Required on create.
      - `[CreatedDateTime <DateTime?>]`: The time when the app role assignment was created.The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
      - `[PrincipalDisplayName <String>]`: The display name of the user, group, or service principal that was granted the app role assignment. Read-only. Supports $filter (eq and startswith).
      - `[PrincipalId <String>]`: The unique identifier (id) for the user, group or service principal being granted the app role. Required on create.
      - `[PrincipalType <String>]`: The type of the assigned principal. This can either be User, Group or ServicePrincipal. Read-only.
      - `[ResourceDisplayName <String>]`: The display name of the resource app's service principal to which the assignment is made.
      - `[ResourceId <String>]`: The unique identifier (id) for the resource service principal for which the assignment is made. Required on create. Supports $filter (eq only).
    - `[AssignedLicense <IMicrosoftGraphAssignedLicense1[]>]`: The licenses that are assigned to the user, including inherited (group-based) licenses. Not nullable. Supports $filter (eq and NOT).
      - `[DisabledPlan <String[]>]`: A collection of the unique identifiers for plans that have been disabled.
      - `[SkuId <String>]`: The unique identifier for the SKU.
    - `[Authentication <IMicrosoftGraphAuthentication>]`: authentication
      - `[Id <String>]`: Read-only.
      - `[Fido2Method <IMicrosoftGraphFido2AuthenticationMethod1[]>]`: 
        - `[Id <String>]`: Read-only.
        - `[AaGuid <String>]`: Authenticator Attestation GUID, an identifier that indicates the type (e.g. make and model) of the authenticator.
        - `[AttestationCertificate <String[]>]`: The attestation certificate(s) attached to this security key.
        - `[AttestationLevel <String>]`: attestationLevel
        - `[CreatedDateTime <DateTime?>]`: The timestamp when this key was registered to the user.
        - `[DisplayName <String>]`: The display name of the key as given by the user.
        - `[Model <String>]`: The manufacturer-assigned model of the FIDO2 security key.
      - `[Method <IMicrosoftGraphAuthenticationMethod1[]>]`: 
        - `[Id <String>]`: Read-only.
      - `[MicrosoftAuthenticatorMethod <IMicrosoftGraphMicrosoftAuthenticatorAuthenticationMethod1[]>]`: 
        - `[Id <String>]`: Read-only.
        - `[CreatedDateTime <DateTime?>]`: The date and time that this app was registered. This property is null if the device is not registered for passwordless Phone Sign-In.
        - `[Device <IMicrosoftGraphDevice1>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DeletedDateTime <DateTime?>]`: 
          - `[Id <String>]`: Read-only.
          - `[AccountEnabled <Boolean?>]`: true if the account is enabled; otherwise, false. Default is true. Supports $filter (eq, ne, NOT, in).
          - `[AlternativeSecurityId <IMicrosoftGraphAlternativeSecurityId1[]>]`: For internal use only. Not nullable. Supports $filter (eq, NOT, ge, le).
            - `[IdentityProvider <String>]`: For internal use only
            - `[Key <Byte[]>]`: For internal use only
            - `[Type <Int32?>]`: For internal use only
          - `[ApproximateLastSignInDateTime <DateTime?>]`: The timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only. Supports $filter (eq, ne, NOT, ge, le) and $orderBy.
          - `[ComplianceExpirationDateTime <DateTime?>]`: The timestamp when the device is no longer deemed compliant. The timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
          - `[DeviceId <String>]`: Identifier set by Azure Device Registration Service at the time of registration. Supports $filter (eq, ne, NOT, startsWith).
          - `[DeviceMetadata <String>]`: For internal use only. Set to null.
          - `[DeviceVersion <Int32?>]`: For internal use only.
          - `[DisplayName <String>]`: The display name for the device. Required. Supports $filter (eq, ne, NOT, ge, le, in, startsWith), $search, and $orderBy.
          - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the device. Read-only. Nullable.
            - `[Id <String>]`: Read-only.
          - `[IsCompliant <Boolean?>]`: true if the device complies with Mobile Device Management (MDM) policies; otherwise, false. Read-only. This can only be updated by Intune for any device OS type or by an approved MDM app for Windows OS devices. Supports $filter (eq, ne, NOT).
          - `[IsManaged <Boolean?>]`: true if the device is managed by a Mobile Device Management (MDM) app; otherwise, false. This can only be updated by Intune for any device OS type or by an approved MDM app for Windows OS devices. Supports $filter (eq, ne, NOT).
          - `[MdmAppId <String>]`: Application identifier used to register device into MDM. Read-only. Supports $filter (eq, ne, NOT, startsWith).
          - `[MemberOf <IMicrosoftGraphDirectoryObject[]>]`: Groups that this device is a member of. Read-only. Nullable. Supports $expand.
            - `[Id <String>]`: Read-only.
            - `[DeletedDateTime <DateTime?>]`: 
          - `[OnPremisesLastSyncDateTime <DateTime?>]`: The last time at which the object was synced with the on-premises directory. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z Read-only. Supports $filter (eq, ne, NOT, ge, le, in).
          - `[OnPremisesSyncEnabled <Boolean?>]`: true if this object is synced from an on-premises directory; false if this object was originally synced from an on-premises directory but is no longer synced; null if this object has never been synced from an on-premises directory (default). Read-only. Supports $filter (eq, ne, NOT, in).
          - `[OperatingSystem <String>]`: The type of operating system on the device. Required. Supports $filter (eq, ne, NOT, ge, le, startsWith).
          - `[OperatingSystemVersion <String>]`: Operating system version of the device. Required. Supports $filter (eq, ne, NOT, ge, le, startsWith).
          - `[PhysicalId <String[]>]`: For internal use only. Not nullable. Supports $filter (eq, NOT, ge, le, startsWith).
          - `[ProfileType <String>]`: The profile type of the device. Possible values: RegisteredDevice (default), SecureVM, Printer, Shared, IoT.
          - `[RegisteredOwner <IMicrosoftGraphDirectoryObject[]>]`: The user that cloud joined the device or registered their personal device. The registered owner is set at the time of registration. Currently, there can be only one owner. Read-only. Nullable. Supports $expand.
          - `[RegisteredUser <IMicrosoftGraphDirectoryObject[]>]`: Collection of registered users of the device. For cloud joined devices and registered personal devices, registered users are set to the same value as registered owners at the time of registration. Read-only. Nullable. Supports $expand.
          - `[SystemLabel <String[]>]`: List of labels applied to the device by the system.
          - `[TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>]`: Groups that this device is a member of. This operation is transitive. Supports $expand.
          - `[TrustType <String>]`: Type of trust for the joined device. Read-only. Possible values: Workplace (indicates bring your own personal devices), AzureAd (Cloud only joined devices), ServerAd (on-premises domain joined devices joined to Azure AD). For more details, see Introduction to device management in Azure Active Directory
        - `[DeviceTag <String>]`: Tags containing app metadata.
        - `[DisplayName <String>]`: The name of the device on which this app is registered.
        - `[PhoneAppVersion <String>]`: Numerical version of this instance of the Authenticator app.
      - `[WindowsHelloForBusinessMethod <IMicrosoftGraphWindowsHelloForBusinessAuthenticationMethod1[]>]`: 
        - `[Id <String>]`: Read-only.
        - `[CreatedDateTime <DateTime?>]`: The date and time that this Windows Hello for Business key was registered.
        - `[Device <IMicrosoftGraphDevice1>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
        - `[DisplayName <String>]`: The name of the device on which Windows Hello for Business is registered
        - `[KeyStrength <String>]`: authenticationMethodKeyStrength
    - `[Birthday <DateTime?>]`: The birthday of the user. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z Returned only on $select.
    - `[Calendar <IMicrosoftGraphCalendar1>]`: calendar
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[AllowedOnlineMeetingProvider <String[]>]`: Represent the online meeting service providers that can be used to create online meetings in this calendar. Possible values are: unknown, skypeForBusiness, skypeForConsumer, teamsForBusiness.
      - `[CalendarPermission <IMicrosoftGraphCalendarPermission1[]>]`: The permissions of the users with whom the calendar is shared.
        - `[Id <String>]`: Read-only.
        - `[AllowedRole <String[]>]`: List of allowed sharing or delegating permission levels for the calendar. Possible values are: none, freeBusyRead, limitedRead, read, write, delegateWithoutPrivateEventAccess, delegateWithPrivateEventAccess, custom.
        - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Address <String>]`: The email address of an entity instance.
          - `[Name <String>]`: The display name of an entity instance.
        - `[IsInsideOrganization <Boolean?>]`: True if the user in context (sharee or delegate) is inside the same organization as the calendar owner.
        - `[IsRemovable <Boolean?>]`: True if the user can be removed from the list of sharees or delegates for the specified calendar, false otherwise. The 'My organization' user determines the permissions other people within your organization have to the given calendar. You cannot remove 'My organization' as a sharee to a calendar.
        - `[Role <String>]`: calendarRoleType
      - `[CalendarView <IMicrosoftGraphEvent1[]>]`: The calendar view for the calendar. Navigation property. Read-only.
        - `[Category <String[]>]`: The categories associated with the item
        - `[ChangeKey <String>]`: Identifies the version of the item. Every time the item is changed, changeKey changes as well. This allows Exchange to apply changes to the correct version of the object. Read-only.
        - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[Id <String>]`: Read-only.
        - `[AllowNewTimeProposal <Boolean?>]`: True if the meeting organizer allows invitees to propose a new time when responding, false otherwise. Optional. Default is true.
        - `[Attachment <IMicrosoftGraphAttachment1[]>]`: The collection of FileAttachment, ItemAttachment, and referenceAttachment attachments for the event. Navigation property. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[ContentType <String>]`: The MIME type.
          - `[IsInline <Boolean?>]`: true if the attachment is an inline attachment; otherwise, false.
          - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
          - `[Name <String>]`: The display name of the attachment. This does not need to be the actual file name.
          - `[Size <Int32?>]`: The length of the attachment in bytes.
        - `[Attendee <IMicrosoftGraphAttendee1[]>]`: The collection of attendees for the event.
          - `[Type <String>]`: attendeeType
          - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
          - `[ProposedNewTime <IMicrosoftGraphTimeSlot1>]`: timeSlot
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[End <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[DateTime <String>]`: A single point of time in a combined date and time representation ({date}T{time}). For example, '2019-04-16T09:00:00'.
              - `[TimeZone <String>]`: Represents a time zone, for example, 'Pacific Standard Time'. See below for possible values.
            - `[Start <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
          - `[Status <IMicrosoftGraphResponseStatus1>]`: responseStatus
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Response <String>]`: responseType
            - `[Time <DateTime?>]`: The date and time that the response was returned. It uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Content <String>]`: The content of the item.
          - `[ContentType <String>]`: bodyType
        - `[BodyPreview <String>]`: The preview of the message associated with the event. It is in text format.
        - `[Calendar <IMicrosoftGraphCalendar1>]`: calendar
        - `[End <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the event. Nullable.
        - `[HasAttachment <Boolean?>]`: Set to true if the event has attachments.
        - `[HideAttendee <Boolean?>]`: When set to true, each attendee only sees themselves in the meeting request and meeting Tracking list. Default is false.
        - `[ICalUid <String>]`: A unique identifier for an event across calendars. This ID is different for each occurrence in a recurring series. Read-only.
        - `[Importance <String>]`: importance
        - `[Instance <IMicrosoftGraphEvent1[]>]`: The occurrences of a recurring series, if the event is a series master. This property includes occurrences that are part of the recurrence pattern, and exceptions that have been modified, but does not include occurrences that have been cancelled from the series. Navigation property. Read-only. Nullable.
        - `[IsAllDay <Boolean?>]`: Set to true if the event lasts all day.
        - `[IsCancelled <Boolean?>]`: Set to true if the event has been canceled.
        - `[IsDraft <Boolean?>]`: Set to true if the user has updated the meeting in Outlook but has not sent the updates to attendees. Set to false if all changes have been sent, or if the event is an appointment without any attendees.
        - `[IsOnlineMeeting <Boolean?>]`: True if this event has online meeting information, false otherwise. Default is false. Optional.
        - `[IsOrganizer <Boolean?>]`: Set to true if the calendar owner (specified by the owner property of the calendar) is the organizer of the event (specified by the organizer property of the event). This also applies if a delegate organized the event on behalf of the owner.
        - `[IsReminderOn <Boolean?>]`: Set to true if an alert is set to remind the user of the event.
        - `[Location <IMicrosoftGraphLocation1[]>]`: The locations where the event is held or attended from. The location and locations properties always correspond with each other. If you update the location property, any prior locations in the locations collection would be removed and replaced by the new location value.
          - `[Address <IMicrosoftGraphPhysicalAddress1>]`: physicalAddress
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[City <String>]`: The city.
            - `[CountryOrRegion <String>]`: The country or region. It's a free-format string value, for example, 'United States'.
            - `[PostalCode <String>]`: The postal code.
            - `[State <String>]`: The state.
            - `[Street <String>]`: The street.
          - `[Coordinate <IMicrosoftGraphOutlookGeoCoordinates1>]`: outlookGeoCoordinates
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Accuracy <Double?>]`: The accuracy of the latitude and longitude. As an example, the accuracy can be measured in meters, such as the latitude and longitude are accurate to within 50 meters.
            - `[Altitude <Double?>]`: The altitude of the location.
            - `[AltitudeAccuracy <Double?>]`: The accuracy of the altitude.
            - `[Latitude <Double?>]`: The latitude of the location.
            - `[Longitude <Double?>]`: The longitude of the location.
          - `[DisplayName <String>]`: The name associated with the location.
          - `[LocationEmailAddress <String>]`: Optional email address of the location.
          - `[LocationType <String>]`: locationType
          - `[LocationUri <String>]`: Optional URI representing the location.
          - `[UniqueId <String>]`: For internal use only.
          - `[UniqueIdType <String>]`: locationUniqueIdType
        - `[Location1 <IMicrosoftGraphLocation1>]`: location
        - `[MultiValueExtendedProperty <IMicrosoftGraphMultiValueLegacyExtendedProperty1[]>]`: The collection of multi-value extended properties defined for the event. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[Value <String[]>]`: A collection of property values.
        - `[OnlineMeeting <IMicrosoftGraphOnlineMeetingInfo1>]`: onlineMeetingInfo
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ConferenceId <String>]`: The ID of the conference.
          - `[JoinUrl <String>]`: The external link that launches the online meeting. This is a URL that clients will launch into a browser and will redirect the user to join the meeting.
          - `[Phone <IMicrosoftGraphPhone1[]>]`: All of the phone numbers associated with this conference.
            - `[Language <String>]`: 
            - `[Number <String>]`: The phone number.
            - `[Region <String>]`: 
            - `[Type <String>]`: phoneType
          - `[QuickDial <String>]`: The pre-formatted quickdial for this call.
          - `[TollFreeNumber <String[]>]`: The toll free numbers that can be used to join the conference.
          - `[TollNumber <String>]`: The toll number that can be used to join the conference.
        - `[OnlineMeetingProvider <String>]`: onlineMeetingProviderType
        - `[OnlineMeetingUrl <String>]`: A URL for an online meeting. The property is set only when an organizer specifies an event as an online meeting such as a Skype meeting. Read-only.
        - `[Organizer <IMicrosoftGraphRecipient1>]`: recipient
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
        - `[OriginalEndTimeZone <String>]`: The end time zone that was set when the event was created. A value of tzone://Microsoft/Custom indicates that a legacy custom time zone was set in desktop Outlook.
        - `[OriginalStart <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[OriginalStartTimeZone <String>]`: The start time zone that was set when the event was created. A value of tzone://Microsoft/Custom indicates that a legacy custom time zone was set in desktop Outlook.
        - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Pattern <IMicrosoftGraphRecurrencePattern1>]`: recurrencePattern
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[DayOfMonth <Int32?>]`: The day of the month on which the event occurs. Required if type is absoluteMonthly or absoluteYearly.
            - `[DaysOfWeek <String[]>]`: A collection of the days of the week on which the event occurs. Possible values are: sunday, monday, tuesday, wednesday, thursday, friday, saturday. If type is relativeMonthly or relativeYearly, and daysOfWeek specifies more than one day, the event falls on the first day that satisfies the pattern.  Required if type is weekly, relativeMonthly, or relativeYearly.
            - `[FirstDayOfWeek <String>]`: dayOfWeek
            - `[Index <String>]`: weekIndex
            - `[Interval <Int32?>]`: The number of units between occurrences, where units can be in days, weeks, months, or years, depending on the type. Required.
            - `[Month <Int32?>]`: The month in which the event occurs.  This is a number from 1 to 12.
            - `[Type <String>]`: recurrencePatternType
          - `[Range <IMicrosoftGraphRecurrenceRange1>]`: recurrenceRange
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[EndDate <DateTime?>]`: The date to stop applying the recurrence pattern. Depending on the recurrence pattern of the event, the last occurrence of the meeting may not be this date. Required if type is endDate.
            - `[NumberOfOccurrence <Int32?>]`: The number of times to repeat the event. Required and must be positive if type is numbered.
            - `[RecurrenceTimeZone <String>]`: Time zone for the startDate and endDate properties. Optional. If not specified, the time zone of the event is used.
            - `[StartDate <DateTime?>]`: The date to start applying the recurrence pattern. The first occurrence of the meeting may be this date or later, depending on the recurrence pattern of the event. Must be the same value as the start property of the recurring event. Required.
            - `[Type <String>]`: recurrenceRangeType
        - `[ReminderMinutesBeforeStart <Int32?>]`: The number of minutes before the event start time that the reminder alert occurs.
        - `[ResponseRequested <Boolean?>]`: Default is true, which represents the organizer would like an invitee to send a response to the event.
        - `[ResponseStatus <IMicrosoftGraphResponseStatus1>]`: responseStatus
        - `[Sensitivity <String>]`: sensitivity
        - `[SeriesMasterId <String>]`: The ID for the recurring series master item, if this event is part of a recurring series.
        - `[ShowAs <String>]`: freeBusyStatus
        - `[SingleValueExtendedProperty <IMicrosoftGraphSingleValueLegacyExtendedProperty1[]>]`: The collection of single-value extended properties defined for the event. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[Value <String>]`: A property value.
        - `[Start <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[Subject <String>]`: The text of the event's subject line.
        - `[TransactionId <String>]`: A custom identifier specified by a client app for the server to avoid redundant POST operations in case of client retries to create the same event. This is useful when low network connectivity causes the client to time out before receiving a response from the server for the client's prior create-event request. After you set transactionId when creating an event, you cannot change transactionId in a subsequent update. This property is only returned in a response payload if an app has set it. Optional.
        - `[Type <String>]`: eventType
        - `[WebLink <String>]`: The URL to open the event in Outlook on the web.Outlook on the web opens the event in the browser if you are signed in to your mailbox. Otherwise, Outlook on the web prompts you to sign in.This URL cannot be accessed from within an iFrame.
      - `[CanEdit <Boolean?>]`: true if the user can write to the calendar, false otherwise. This property is true for the user who created the calendar. This property is also true for a user who has been shared a calendar and granted write access, through an Outlook client or the corresponding calendarPermission resource. Read-only.
      - `[CanShare <Boolean?>]`: true if the user has the permission to share the calendar, false otherwise. Only the user who created the calendar can share it. Read-only.
      - `[CanViewPrivateItem <Boolean?>]`: true if the user can read calendar items that have been marked private, false otherwise. This property is set through an Outlook client or the corresponding calendarPermission resource. Read-only.
      - `[ChangeKey <String>]`: Identifies the version of the calendar object. Every time the calendar is changed, changeKey changes as well. This allows Exchange to apply changes to the correct version of the object. Read-only.
      - `[Color <String>]`: calendarColor
      - `[DefaultOnlineMeetingProvider <String>]`: onlineMeetingProviderType
      - `[Event <IMicrosoftGraphEvent1[]>]`: The events in the calendar. Navigation property. Read-only.
      - `[HexColor <String>]`: The calendar color, expressed in a hex color code of three hexadecimal values, each ranging from 00 to FF and representing the red, green, or blue components of the color in the RGB color space. If the user has never explicitly set a color for the calendar, this property is  empty.
      - `[IsDefaultCalendar <Boolean?>]`: true if this is the default calendar where new events are created by default, false otherwise.
      - `[IsRemovable <Boolean?>]`: Indicates whether this user calendar can be deleted from the user mailbox.
      - `[IsTallyingResponse <Boolean?>]`: Indicates whether this user calendar supports tracking of meeting responses. Only meeting invites sent from users' primary calendars support tracking of meeting responses.
      - `[MultiValueExtendedProperty <IMicrosoftGraphMultiValueLegacyExtendedProperty1[]>]`: The collection of multi-value extended properties defined for the calendar. Read-only. Nullable.
      - `[Name <String>]`: The calendar name.
      - `[Owner <IMicrosoftGraphEmailAddress1>]`: emailAddress
      - `[SingleValueExtendedProperty <IMicrosoftGraphSingleValueLegacyExtendedProperty1[]>]`: The collection of single-value extended properties defined for the calendar. Read-only. Nullable.
    - `[Chat <IMicrosoftGraphChat[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[ChatType <String>]`: chatType
      - `[CreatedDateTime <DateTime?>]`: Date and time at which the chat was created. Read-only.
      - `[InstalledApp <IMicrosoftGraphTeamsAppInstallation1[]>]`: A collection of all the apps in the chat. Nullable.
        - `[Id <String>]`: Read-only.
        - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[AppDefinition <IMicrosoftGraphTeamsAppDefinition1[]>]`: The details for each version of the app.
            - `[Id <String>]`: Read-only.
            - `[Bot <IMicrosoftGraphTeamworkBot1>]`: teamworkBot
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[Id <String>]`: Read-only.
            - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[Description <String>]`: Verbose description of the application.
            - `[DisplayName <String>]`: The name of the app provided by the app developer.
            - `[LastModifiedDateTime <DateTime?>]`: 
            - `[PublishingState <String>]`: teamsAppPublishingState
            - `[ShortDescription <String>]`: Short description of the application.
            - `[TeamsAppId <String>]`: The ID from the Teams app manifest.
            - `[Version <String>]`: The version number of the application.
          - `[DisplayName <String>]`: The name of the catalog app provided by the app developer in the Microsoft Teams zip app package.
          - `[DistributionMethod <String>]`: teamsAppDistributionMethod
          - `[ExternalId <String>]`: The ID of the catalog provided by the app developer in the Microsoft Teams zip app package.
        - `[TeamsAppDefinition <IMicrosoftGraphTeamsAppDefinition1>]`: teamsAppDefinition
      - `[LastUpdatedDateTime <DateTime?>]`: Date and time at which the chat was renamed or list of members were last changed. Read-only.
      - `[Member <IMicrosoftGraphConversationMember1[]>]`: A collection of all the members in the chat. Nullable.
        - `[Id <String>]`: Read-only.
        - `[DisplayName <String>]`: The display name of the user.
        - `[Role <String[]>]`: The roles for that user.
        - `[VisibleHistoryStartDateTime <DateTime?>]`: The timestamp denoting how far back a conversation's history is shared with the conversation member. This property is settable only for members of a chat.
      - `[Message <IMicrosoftGraphChatMessage1[]>]`: A collection of all the messages in the chat. Nullable.
        - `[Id <String>]`: Read-only.
        - `[Attachment <IMicrosoftGraphChatMessageAttachment1[]>]`: Attached files. Attachments are currently read-only – sending attachments is not supported.
          - `[Content <String>]`: The content of the attachment. If the attachment is a rich card, set the property to the rich card object. This property and contentUrl are mutually exclusive.
          - `[ContentType <String>]`: The media type of the content attachment. It can have the following values: reference: Attachment is a link to another file. Populate the contentURL with the link to the object.Any contentTypes supported by the Bot Framework's Attachment objectapplication/vnd.microsoft.card.codesnippet: A code snippet. application/vnd.microsoft.card.announcement: An announcement header.
          - `[ContentUrl <String>]`: URL for the content of the attachment. Supported protocols: http, https, file and data.
          - `[Id <String>]`: Read-only. Unique id of the attachment.
          - `[Name <String>]`: Name of the attachment.
          - `[ThumbnailUrl <String>]`: URL to a thumbnail image that the channel can use if it supports using an alternative, smaller form of content or contentUrl. For example, if you set contentType to application/word and set contentUrl to the location of the Word document, you might include a thumbnail image that represents the document. The channel could display the thumbnail image instead of the document. When the user clicks the image, the channel would open the document.
        - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
        - `[ChannelIdentity <IMicrosoftGraphChannelIdentity1>]`: channelIdentity
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ChannelId <String>]`: The identity of the channel in which the message was posted.
          - `[TeamId <String>]`: The identity of the team in which the message was posted.
        - `[ChatId <String>]`: If the message was sent in a chat, represents the identity of the chat.
        - `[CreatedDateTime <DateTime?>]`: Timestamp of when the chat message was created.
        - `[DeletedDateTime <DateTime?>]`: Read only. Timestamp at which the chat message was deleted, or null if not deleted.
        - `[Etag <String>]`: Read-only. Version number of the chat message.
        - `[From <IMicrosoftGraphChatMessageFromIdentitySet1>]`: chatMessageFromIdentitySet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Application <IMicrosoftGraphIdentity1>]`: identity
          - `[Device <IMicrosoftGraphIdentity1>]`: identity
          - `[User <IMicrosoftGraphIdentity1>]`: identity
        - `[HostedContent <IMicrosoftGraphChatMessageHostedContent1[]>]`: Content in a message hosted by Microsoft Teams - for example, images or code snippets.
          - `[ContentByte <Byte[]>]`: Write only. Bytes for the hosted content (such as images).
          - `[ContentType <String>]`: Write only. Content type, such as image/png, image/jpg.
          - `[Id <String>]`: Read-only.
        - `[Importance <String>]`: chatMessageImportance
        - `[LastEditedDateTime <DateTime?>]`: Read only. Timestamp when edits to the chat message were made. Triggers an 'Edited' flag in the Teams UI. If no edits are made the value is null.
        - `[LastModifiedDateTime <DateTime?>]`: Read only. Timestamp when the chat message is created (initial setting) or modified, including when a reaction is added or removed.
        - `[Locale <String>]`: Locale of the chat message set by the client. Always set to en-us.
        - `[Mention <IMicrosoftGraphChatMessageMention1[]>]`: List of entities mentioned in the chat message. Currently supports user, bot, team, channel.
          - `[Id <Int32?>]`: Index of an entity being mentioned in the specified chatMessage. Matches the {index} value in the corresponding <at id='{index}'> tag in the message body.
          - `[MentionText <String>]`: String used to represent the mention. For example, a user's display name, a team name.
          - `[Mentioned <IMicrosoftGraphChatMessageMentionedIdentitySet1>]`: chatMessageMentionedIdentitySet
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Application <IMicrosoftGraphIdentity1>]`: identity
            - `[Device <IMicrosoftGraphIdentity1>]`: identity
            - `[User <IMicrosoftGraphIdentity1>]`: identity
            - `[Conversation <IMicrosoftGraphTeamworkConversationIdentity1>]`: teamworkConversationIdentity
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
              - `[Id <String>]`: Unique identifier for the identity.
              - `[ConversationIdentityType <String>]`: teamworkConversationIdentityType
        - `[MessageType <String>]`: chatMessageType
        - `[PolicyViolation <IMicrosoftGraphChatMessagePolicyViolation1>]`: chatMessagePolicyViolation
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DlpAction <String>]`: chatMessagePolicyViolationDlpActionTypes
          - `[JustificationText <String>]`: Justification text provided by the sender of the message when overriding a policy violation.
          - `[PolicyTip <IMicrosoftGraphChatMessagePolicyViolationPolicyTip1>]`: chatMessagePolicyViolationPolicyTip
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[ComplianceUrl <String>]`: The URL a user can visit to read about the data loss prevention policies for the organization. (ie, policies about what users shouldn't say in chats)
            - `[GeneralText <String>]`: Explanatory text shown to the sender of the message.
            - `[MatchedConditionDescription <String[]>]`: The list of improper data in the message that was detected by the data loss prevention app. Each DLP app defines its own conditions, examples include 'Credit Card Number' and 'Social Security Number'.
          - `[UserAction <String>]`: chatMessagePolicyViolationUserActionTypes
          - `[VerdictDetail <String>]`: chatMessagePolicyViolationVerdictDetailsTypes
        - `[Reaction <IMicrosoftGraphChatMessageReaction1[]>]`: Reactions for this chat message (for example, Like).
          - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
          - `[ReactionType <String>]`: Supported values are like, angry, sad, laugh, heart, surprised.
          - `[User <IMicrosoftGraphChatMessageReactionIdentitySet1>]`: chatMessageReactionIdentitySet
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Application <IMicrosoftGraphIdentity1>]`: identity
            - `[Device <IMicrosoftGraphIdentity1>]`: identity
            - `[User <IMicrosoftGraphIdentity1>]`: identity
        - `[Reply <IMicrosoftGraphChatMessage1[]>]`: Replies for a specified message.
        - `[ReplyToId <String>]`: Read-only. ID of the parent chat message or root chat message of the thread. (Only applies to chat messages in channels, not chats.)
        - `[Subject <String>]`: The subject of the chat message, in plaintext.
        - `[Summary <String>]`: Summary text of the chat message that could be used for push notifications and summary views or fall back views. Only applies to channel chat messages, not chat messages in a chat.
        - `[WebUrl <String>]`: Read-only. Link to the message in Microsoft Teams.
      - `[Tab <IMicrosoftGraphTeamsTab1[]>]`: 
        - `[Id <String>]`: Read-only.
        - `[Configuration <IMicrosoftGraphTeamsTabConfiguration1>]`: teamsTabConfiguration
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ContentUrl <String>]`: Url used for rendering tab contents in Teams. Required.
          - `[EntityId <String>]`: Identifier for the entity hosted by the tab provider.
          - `[RemoveUrl <String>]`: Url called by Teams client when a Tab is removed using the Teams Client.
          - `[WebsiteUrl <String>]`: Url for showing tab contents outside of Teams.
        - `[DisplayName <String>]`: Name of the tab.
        - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
        - `[WebUrl <String>]`: Deep link URL of the tab instance. Read only.
      - `[Topic <String>]`: (Optional) Subject or topic for the chat. Only available for group chats.
    - `[City <String>]`: The city in which the user is located. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[CompanyName <String>]`: The company name which the user is associated. This property can be useful for describing the company that an external user comes from. The maximum length of the company name is 64 characters.Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[ConsentProvidedForMinor <String>]`: Sets whether consent has been obtained for minors. Allowed values: null, granted, denied and notRequired. Refer to the legal age group property definitions for further information. Supports $filter (eq, ne, NOT, and in).
    - `[Country <String>]`: The country/region in which the user is located; for example, US or UK. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[Department <String>]`: The name for the department in which the user works. Maximum length is 64 characters.Supports $filter (eq, ne, NOT , ge, le, and in operators).
    - `[DeviceEnrollmentLimit <Int32?>]`: The limit on the maximum number of devices that the user is permitted to enroll. Allowed values are 5 or 1000.
    - `[DeviceManagementTroubleshootingEvent <IMicrosoftGraphDeviceManagementTroubleshootingEvent1[]>]`: The list of troubleshooting events for this user.
      - `[Id <String>]`: Read-only.
      - `[CorrelationId <String>]`: Id used for tracing the failure in the service.
      - `[EventDateTime <DateTime?>]`: Time when the event occurred .
    - `[DisplayName <String>]`: The name displayed in the address book for the user. This value is usually the combination of the user's first name, middle initial, and last name. This property is required when a user is created and it cannot be cleared during updates. Maximum length is 256 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith), $orderBy, and $search.
    - `[Drive <IMicrosoftGraphDrive1>]`: drive
    - `[EmployeeHireDate <DateTime?>]`: The date and time when the user was hired or will start work in case of a future hire. Supports $filter (eq, ne, NOT , ge, le, in).
    - `[EmployeeId <String>]`: The employee identifier assigned to the user by the organization. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
    - `[EmployeeOrgData <IMicrosoftGraphEmployeeOrgData1>]`: employeeOrgData
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[CostCenter <String>]`: The cost center associated with the user. Returned only on $select. Supports $filter.
      - `[Division <String>]`: The name of the division in which the user works. Returned only on $select. Supports $filter.
    - `[EmployeeType <String>]`: Captures enterprise worker type. For example, Employee, Contractor, Consultant, or Vendor. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
    - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the user. Nullable.
    - `[ExternalUserState <String>]`: For an external user invited to the tenant using the invitation API, this property represents the invited user's invitation status. For invited users, the state can be PendingAcceptance or Accepted, or null for all other users. Supports $filter (eq, ne, NOT , in).
    - `[ExternalUserStateChangeDateTime <DateTime?>]`: Shows the timestamp for the latest change to the externalUserState property. Supports $filter (eq, ne, NOT , in).
    - `[FaxNumber <String>]`: The fax number of the user. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
    - `[FollowedSite <IMicrosoftGraphSite1[]>]`: 
      - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
      - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
      - `[Description <String>]`: Provides a user-visible description of the item. Optional.
      - `[ETag <String>]`: ETag for the item. Read-only.
      - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
      - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
      - `[Name <String>]`: The name of the item. Read-write.
      - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DriveId <String>]`: Unique identifier of the drive instance that contains the item. Read-only.
        - `[DriveType <String>]`: Identifies the type of drive. See [drive][] resource for values.
        - `[Id <String>]`: Unique identifier of the item in the drive. Read-only.
        - `[Name <String>]`: The name of the item being referenced. Read-only.
        - `[Path <String>]`: Path that can be used to navigate to the item. Read-only.
        - `[ShareId <String>]`: A unique identifier for a shared resource that can be accessed via the [Shares][] API.
        - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ListId <String>]`: The unique identifier (guid) for the item's list in SharePoint.
          - `[ListItemId <String>]`: An integer identifier for the item within the containing list.
          - `[ListItemUniqueId <String>]`: The unique identifier (guid) for the item within OneDrive for Business or a SharePoint site.
          - `[SiteId <String>]`: The unique identifier (guid) for the item's site collection (SPSite).
          - `[SiteUrl <String>]`: The SharePoint URL for the site that contains the item.
          - `[TenantId <String>]`: The unique identifier (guid) for the tenancy.
          - `[WebId <String>]`: The unique identifier (guid) for the item's site (SPWeb).
        - `[SiteId <String>]`: For OneDrive for Business and SharePoint, this property represents the ID of the site that contains the parent document library of the driveItem resource. The value is the same as the id property of that [site][] resource. It is an opaque string that consists of three identifiers of the site. For OneDrive, this property is not populated.
      - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
      - `[Id <String>]`: Read-only.
      - `[Analytic <IMicrosoftGraphItemAnalytics1>]`: itemAnalytics
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Id <String>]`: Read-only.
        - `[AllTime <IMicrosoftGraphItemActivityStat1>]`: itemActivityStat
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[Access <IMicrosoftGraphItemActionStat1>]`: itemActionStat
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[ActionCount <Int32?>]`: The number of times the action took place. Read-only.
            - `[ActorCount <Int32?>]`: The number of distinct actors that performed the action. Read-only.
          - `[Activity <IMicrosoftGraphItemActivity1[]>]`: Exposes the itemActivities represented in this itemActivityStat resource.
            - `[Id <String>]`: Read-only.
            - `[Access <IMicrosoftGraphAccessAction>]`: accessAction
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[ActivityDateTime <DateTime?>]`: Details about when the activity took place. Read-only.
            - `[Actor <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[DriveItem <IMicrosoftGraphDriveItem1>]`: driveItem
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
              - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
              - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
              - `[Description <String>]`: Provides a user-visible description of the item. Optional.
              - `[ETag <String>]`: ETag for the item. Read-only.
              - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
              - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
              - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
              - `[Name <String>]`: The name of the item. Read-write.
              - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
              - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
              - `[Id <String>]`: Read-only.
              - `[Analytic <IMicrosoftGraphItemAnalytics1>]`: itemAnalytics
              - `[Audio <IMicrosoftGraphAudio1>]`: audio
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Album <String>]`: The title of the album for this audio file.
                - `[AlbumArtist <String>]`: The artist named on the album for the audio file.
                - `[Artist <String>]`: The performing artist for the audio file.
                - `[Bitrate <Int64?>]`: Bitrate expressed in kbps.
                - `[Composer <String>]`: The name of the composer of the audio file.
                - `[Copyright <String>]`: Copyright information for the audio file.
                - `[Disc <Int32?>]`: The number of the disc this audio file came from.
                - `[DiscCount <Int32?>]`: The total number of discs in this album.
                - `[Duration <Int64?>]`: Duration of the audio file, expressed in milliseconds
                - `[Genre <String>]`: The genre of this audio file.
                - `[HasDrm <Boolean?>]`: Indicates if the file is protected with digital rights management.
                - `[IsVariableBitrate <Boolean?>]`: Indicates if the file is encoded with a variable bitrate.
                - `[Title <String>]`: The title of the audio file.
                - `[Track <Int32?>]`: The number of the track on the original disc for this audio file.
                - `[TrackCount <Int32?>]`: The total number of tracks on the original disc for this audio file.
                - `[Year <Int32?>]`: The year the audio file was recorded.
              - `[CTag <String>]`: An eTag for the content of the item. This eTag is not changed if only the metadata is changed. Note This property is not returned if the item is a folder. Read-only.
              - `[Child <IMicrosoftGraphDriveItem1[]>]`: Collection containing Item objects for the immediate children of Item. Only items representing folders have children. Read-only. Nullable.
              - `[Content <Byte[]>]`: The content stream, if the item represents a file.
              - `[Deleted <IMicrosoftGraphDeleted1>]`: deleted
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[State <String>]`: Represents the state of the deleted item.
              - `[File <IMicrosoftGraphFile1>]`: file
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Hash <IMicrosoftGraphHashes1>]`: hashes
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Crc32Hash <String>]`: The CRC32 value of the file (if available). Read-only.
                  - `[QuickXorHash <String>]`: A proprietary hash of the file that can be used to determine if the contents of the file have changed (if available). Read-only.
                  - `[Sha1Hash <String>]`: SHA1 hash for the contents of the file (if available). Read-only.
                  - `[Sha256Hash <String>]`: SHA256 hash for the contents of the file (if available). Read-only.
                - `[MimeType <String>]`: The MIME type for the file. This is determined by logic on the server and might not be the value provided when the file was uploaded. Read-only.
                - `[ProcessingMetadata <Boolean?>]`: 
              - `[FileSystemInfo <IMicrosoftGraphFileSystemInfo1>]`: fileSystemInfo
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[CreatedDateTime <DateTime?>]`: The UTC date and time the file was created on a client.
                - `[LastAccessedDateTime <DateTime?>]`: The UTC date and time the file was last accessed. Available for the recent file list only.
                - `[LastModifiedDateTime <DateTime?>]`: The UTC date and time the file was last modified on a client.
              - `[Folder <IMicrosoftGraphFolder1>]`: folder
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[ChildCount <Int32?>]`: Number of children contained immediately within this container.
                - `[View <IMicrosoftGraphFolderView1>]`: folderView
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[SortBy <String>]`: The method by which the folder should be sorted.
                  - `[SortOrder <String>]`: If true, indicates that items should be sorted in descending order. Otherwise, items should be sorted ascending.
                  - `[ViewType <String>]`: The type of view that should be used to represent the folder.
              - `[Image <IMicrosoftGraphImage1>]`: image
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Height <Int32?>]`: Optional. Height of the image, in pixels. Read-only.
                - `[Width <Int32?>]`: Optional. Width of the image, in pixels. Read-only.
              - `[ListItem <IMicrosoftGraphListItem1>]`: listItem
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
                - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
                - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
                - `[Description <String>]`: Provides a user-visible description of the item. Optional.
                - `[ETag <String>]`: ETag for the item. Read-only.
                - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
                - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
                - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
                - `[Name <String>]`: The name of the item. Read-write.
                - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
                - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
                - `[Id <String>]`: Read-only.
                - `[Analytic <IMicrosoftGraphItemAnalytics1>]`: itemAnalytics
                - `[ContentType <IMicrosoftGraphContentTypeInfo1>]`: contentTypeInfo
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: The id of the content type.
                  - `[Name <String>]`: The name of the content type.
                - `[DriveItem <IMicrosoftGraphDriveItem1>]`: driveItem
                - `[Field <IMicrosoftGraphFieldValueSet1>]`: fieldValueSet
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
                - `[Version <IMicrosoftGraphListItemVersion1[]>]`: The list of previous versions of the list item.
                  - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
                  - `[LastModifiedDateTime <DateTime?>]`: Date and time the version was last modified. Read-only.
                  - `[Publication <IMicrosoftGraphPublicationFacet1>]`: publicationFacet
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Level <String>]`: The state of publication for this document. Either published or checkout. Read-only.
                    - `[VersionId <String>]`: The unique identifier for the version that is visible to the current caller. Read-only.
                  - `[Id <String>]`: Read-only.
                  - `[Field <IMicrosoftGraphFieldValueSet1>]`: fieldValueSet
              - `[Location <IMicrosoftGraphGeoCoordinates1>]`: geoCoordinates
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Altitude <Double?>]`: Optional. The altitude (height), in feet,  above sea level for the item. Read-only.
                - `[Latitude <Double?>]`: Optional. The latitude, in decimal, for the item. Writable on OneDrive Personal.
                - `[Longitude <Double?>]`: Optional. The longitude, in decimal, for the item. Writable on OneDrive Personal.
              - `[Package <IMicrosoftGraphPackage1>]`: package
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Type <String>]`: A string indicating the type of package. While oneNote is the only currently defined value, you should expect other package types to be returned and handle them accordingly.
              - `[PendingOperation <IMicrosoftGraphPendingOperations1>]`: pendingOperations
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[PendingContentUpdate <IMicrosoftGraphPendingContentUpdate1>]`: pendingContentUpdate
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[QueuedDateTime <DateTime?>]`: Date and time the pending binary operation was queued in UTC time. Read-only.
              - `[Permission <IMicrosoftGraphPermission1[]>]`: The set of permissions for the item. Read-only. Nullable.
                - `[Id <String>]`: Read-only.
                - `[ExpirationDateTime <DateTime?>]`: A format of yyyy-MM-ddTHH:mm:ssZ of DateTimeOffset indicates the expiration time of the permission. DateTime.MinValue indicates there is no expiration set for this permission. Optional.
                - `[GrantedTo <IMicrosoftGraphIdentitySet1>]`: identitySet
                - `[GrantedToIdentity <IMicrosoftGraphIdentitySet1[]>]`: For link type permissions, the details of the users to whom permission was granted. Read-only.
                - `[HasPassword <Boolean?>]`: This indicates whether password is set for this permission, it's only showing in response. Optional and Read-only and for OneDrive Personal only.
                - `[InheritedFrom <IMicrosoftGraphItemReference1>]`: itemReference
                - `[Invitation <IMicrosoftGraphSharingInvitation1>]`: sharingInvitation
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Email <String>]`: The email address provided for the recipient of the sharing invitation. Read-only.
                  - `[InvitedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
                  - `[RedeemedBy <String>]`: 
                  - `[SignInRequired <Boolean?>]`: If true the recipient of the invitation needs to sign in in order to access the shared item. Read-only.
                - `[Link <IMicrosoftGraphSharingLink1>]`: sharingLink
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Application <IMicrosoftGraphIdentity1>]`: identity
                  - `[PreventsDownload <Boolean?>]`: If true then the user can only use this link to view the item on the web, and cannot use it to download the contents of the item. Only for OneDrive for Business and SharePoint.
                  - `[Scope <String>]`: The scope of the link represented by this permission. Value anonymous indicates the link is usable by anyone, organization indicates the link is only usable for users signed into the same tenant.
                  - `[Type <String>]`: The type of the link created.
                  - `[WebHtml <String>]`: For embed links, this property contains the HTML code for an <iframe> element that will embed the item in a webpage.
                  - `[WebUrl <String>]`: A URL that opens the item in the browser on the OneDrive website.
                - `[Role <String[]>]`: The type of permission, e.g. read. See below for the full list of roles. Read-only.
                - `[ShareId <String>]`: A unique token that can be used to access this shared item via the [shares API][]. Read-only.
              - `[Photo <IMicrosoftGraphPhoto1>]`: photo
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[CameraMake <String>]`: Camera manufacturer. Read-only.
                - `[CameraModel <String>]`: Camera model. Read-only.
                - `[ExposureDenominator <Double?>]`: The denominator for the exposure time fraction from the camera. Read-only.
                - `[ExposureNumerator <Double?>]`: The numerator for the exposure time fraction from the camera. Read-only.
                - `[FNumber <Double?>]`: The F-stop value from the camera. Read-only.
                - `[FocalLength <Double?>]`: The focal length from the camera. Read-only.
                - `[Iso <Int32?>]`: The ISO value from the camera. Read-only.
                - `[Orientation <Int32?>]`: The orientation value from the camera. Writable on OneDrive Personal.
                - `[TakenDateTime <DateTime?>]`: The date and time the photo was taken in UTC time. Read-only.
              - `[Publication <IMicrosoftGraphPublicationFacet1>]`: publicationFacet
              - `[RemoteItem <IMicrosoftGraphRemoteItem1>]`: remoteItem
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
                - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
                - `[File <IMicrosoftGraphFile1>]`: file
                - `[FileSystemInfo <IMicrosoftGraphFileSystemInfo1>]`: fileSystemInfo
                - `[Folder <IMicrosoftGraphFolder1>]`: folder
                - `[Id <String>]`: Unique identifier for the remote item in its drive. Read-only.
                - `[Image <IMicrosoftGraphImage1>]`: image
                - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
                - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
                - `[Name <String>]`: Optional. Filename of the remote item. Read-only.
                - `[Package <IMicrosoftGraphPackage1>]`: package
                - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
                - `[Shared <IMicrosoftGraphShared1>]`: shared
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Owner <IMicrosoftGraphIdentitySet1>]`: identitySet
                  - `[Scope <String>]`: Indicates the scope of how the item is shared: anonymous, organization, or users. Read-only.
                  - `[SharedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
                  - `[SharedDateTime <DateTime?>]`: The UTC date and time when the item was shared. Read-only.
                - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
                - `[Size <Int64?>]`: Size of the remote item. Read-only.
                - `[SpecialFolder <IMicrosoftGraphSpecialFolder1>]`: specialFolder
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Name <String>]`: The unique identifier for this item in the /drive/special collection
                - `[Video <IMicrosoftGraphVideo1>]`: video
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[AudioBitsPerSample <Int32?>]`: Number of audio bits per sample.
                  - `[AudioChannel <Int32?>]`: Number of audio channels.
                  - `[AudioFormat <String>]`: Name of the audio format (AAC, MP3, etc.).
                  - `[AudioSamplesPerSecond <Int32?>]`: Number of audio samples per second.
                  - `[Bitrate <Int32?>]`: Bit rate of the video in bits per second.
                  - `[Duration <Int64?>]`: Duration of the file in milliseconds.
                  - `[FourCc <String>]`: 'Four character code' name of the video format.
                  - `[FrameRate <Double?>]`: Frame rate of the video.
                  - `[Height <Int32?>]`: Height of the video, in pixels.
                  - `[Width <Int32?>]`: Width of the video, in pixels.
                - `[WebDavUrl <String>]`: DAV compatible URL for the item.
                - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
              - `[Root <IMicrosoftGraphRoot>]`: root
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[SearchResult <IMicrosoftGraphSearchResult1>]`: searchResult
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[OnClickTelemetryUrl <String>]`: A callback URL that can be used to record telemetry information. The application should issue a GET on this URL if the user interacts with this item to improve the quality of results.
              - `[Shared <IMicrosoftGraphShared1>]`: shared
              - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
              - `[Size <Int64?>]`: Size of the item in bytes. Read-only.
              - `[SpecialFolder <IMicrosoftGraphSpecialFolder1>]`: specialFolder
              - `[Subscription <IMicrosoftGraphSubscription1[]>]`: The set of subscriptions on the item. Only supported on the root of a drive.
                - `[Id <String>]`: Read-only.
                - `[ApplicationId <String>]`: Identifier of the application used to create the subscription. Read-only.
                - `[ChangeType <String>]`: Indicates the type of change in the subscribed resource that will raise a change notification. The supported values are: created, updated, deleted. Multiple values can be combined using a comma-separated list. Required. Note: Drive root item and list change notifications support only the updated changeType. User and group change notifications support updated and deleted changeType.
                - `[ClientState <String>]`: Specifies the value of the clientState property sent by the service in each change notification. The maximum length is 255 characters. The client can check that the change notification came from the service by comparing the value of the clientState property sent with the subscription with the value of the clientState property received with each change notification. Optional.
                - `[CreatorId <String>]`: Identifier of the user or service principal that created the subscription. If the app used delegated permissions to create the subscription, this field contains the ID of the signed-in user the app called on behalf of. If the app used application permissions, this field contains the ID of the service principal corresponding to the app. Read-only.
                - `[EncryptionCertificate <String>]`: A base64-encoded representation of a certificate with a public key used to encrypt resource data in change notifications. Optional. Required when includeResourceData is true.
                - `[EncryptionCertificateId <String>]`: A custom app-provided identifier to help identify the certificate needed to decrypt resource data. Optional. Required when includeResourceData is true.
                - `[ExpirationDateTime <DateTime?>]`: Specifies the date and time when the webhook subscription expires. The time is in UTC, and can be an amount of time from subscription creation that varies for the resource subscribed to.  See the table below for maximum supported subscription length of time. Required.
                - `[IncludeResourceData <Boolean?>]`: When set to true, change notifications include resource data (such as content of a chat message). Optional.
                - `[LatestSupportedTlsVersion <String>]`: Specifies the latest version of Transport Layer Security (TLS) that the notification endpoint, specified by notificationUrl, supports. The possible values are: v1_0, v1_1, v1_2, v1_3. For subscribers whose notification endpoint supports a version lower than the currently recommended version (TLS 1.2), specifying this property by a set timeline allows them to temporarily use their deprecated version of TLS before completing their upgrade to TLS 1.2. For these subscribers, not setting this property per the timeline would result in subscription operations failing. For subscribers whose notification endpoint already supports TLS 1.2, setting this property is optional. In such cases, Microsoft Graph defaults the property to v1_2.
                - `[LifecycleNotificationUrl <String>]`: The URL of the endpoint that receives lifecycle notifications, including subscriptionRemoved and missed notifications. This URL must make use of the HTTPS protocol. Optional. Read more about how Outlook resources use lifecycle notifications.
                - `[NotificationQueryOption <String>]`: OData Query Options for specifying value for the targeting resource. Clients receive notifications when resource reaches the state matching the query options provided here. With this new property in the subscription creation payload along with all existing properties, Webhooks will deliver notifications whenever a resource reaches the desired state mentioned in the notificationQueryOptions property eg  when the print job is completed, when a print job resource isFetchable property value becomes true etc.
                - `[NotificationUrl <String>]`: The URL of the endpoint that receives the change notifications. This URL must make use of the HTTPS protocol. Required.
                - `[Resource <String>]`: Specifies the resource that will be monitored for changes. Do not include the base URL (https://graph.microsoft.com/beta/). See the possible resource path values for each supported resource. Required.
              - `[Thumbnail <IMicrosoftGraphThumbnailSet1[]>]`: Collection containing [ThumbnailSet][] objects associated with the item. For more info, see [getting thumbnails][]. Read-only. Nullable.
                - `[Id <String>]`: Read-only.
                - `[Large <IMicrosoftGraphThumbnail1>]`: thumbnail
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Content <Byte[]>]`: The content stream for the thumbnail.
                  - `[Height <Int32?>]`: The height of the thumbnail, in pixels.
                  - `[SourceItemId <String>]`: The unique identifier of the item that provided the thumbnail. This is only available when a folder thumbnail is requested.
                  - `[Url <String>]`: The URL used to fetch the thumbnail content.
                  - `[Width <Int32?>]`: The width of the thumbnail, in pixels.
                - `[Medium <IMicrosoftGraphThumbnail1>]`: thumbnail
                - `[Small <IMicrosoftGraphThumbnail1>]`: thumbnail
                - `[Source <IMicrosoftGraphThumbnail1>]`: thumbnail
              - `[Version <IMicrosoftGraphDriveItemVersion1[]>]`: The list of previous versions of the item. For more info, see [getting previous versions][]. Read-only. Nullable.
                - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
                - `[LastModifiedDateTime <DateTime?>]`: Date and time the version was last modified. Read-only.
                - `[Publication <IMicrosoftGraphPublicationFacet1>]`: publicationFacet
                - `[Id <String>]`: Read-only.
                - `[Content <Byte[]>]`: 
                - `[Size <Int64?>]`: Indicates the size of the content stream for this version of the item.
              - `[Video <IMicrosoftGraphVideo1>]`: video
              - `[WebDavUrl <String>]`: WebDAV compatible URL for the item.
              - `[Workbook <IMicrosoftGraphWorkbook1>]`: workbook
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Id <String>]`: Read-only.
                - `[Application <IMicrosoftGraphWorkbookApplication1>]`: workbookApplication
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[CalculationMode <String>]`: Returns the calculation mode used in the workbook. Possible values are: Automatic, AutomaticExceptTables, Manual.
                - `[Comment <IMicrosoftGraphWorkbookComment1[]>]`: 
                  - `[Id <String>]`: Read-only.
                  - `[Content <String>]`: The content of the comment.
                  - `[ContentType <String>]`: Indicates the type for the comment.
                  - `[Reply <IMicrosoftGraphWorkbookCommentReply1[]>]`: Read-only. Nullable.
                    - `[Id <String>]`: Read-only.
                    - `[Content <String>]`: The content of replied comment.
                    - `[ContentType <String>]`: Indicates the type for the replied comment.
                - `[Function <IMicrosoftGraphWorkbookFunctions1>]`: workbookFunctions
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                - `[Name <IMicrosoftGraphWorkbookNamedItem1[]>]`: Represents a collection of workbooks scoped named items (named ranges and constants). Read-only.
                  - `[Id <String>]`: Read-only.
                  - `[Comment <String>]`: Represents the comment associated with this name.
                  - `[Name <String>]`: The name of the object. Read-only.
                  - `[Scope <String>]`: Indicates whether the name is scoped to the workbook or to a specific worksheet. Read-only.
                  - `[Type <String>]`: Indicates what type of reference is associated with the name. Possible values are: String, Integer, Double, Boolean, Range. Read-only.
                  - `[Value <IMicrosoftGraphJson>]`: Json
                  - `[Visible <Boolean?>]`: Specifies whether the object is visible or not.
                  - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Chart <IMicrosoftGraphWorkbookChart1[]>]`: Returns collection of charts that are part of the worksheet. Read-only.
                      - `[Id <String>]`: Read-only.
                      - `[Axis <IMicrosoftGraphWorkbookChartAxes1>]`: workbookChartAxes
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Id <String>]`: Read-only.
                        - `[CategoryAxis <IMicrosoftGraphWorkbookChartAxis1>]`: workbookChartAxis
                          - `[(Any) <Object>]`: This indicates any property can be added to this object.
                          - `[Id <String>]`: Read-only.
                          - `[Format <IMicrosoftGraphWorkbookChartAxisFormat1>]`: workbookChartAxisFormat
                            - `[(Any) <Object>]`: This indicates any property can be added to this object.
                            - `[Id <String>]`: Read-only.
                            - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                              - `[(Any) <Object>]`: This indicates any property can be added to this object.
                              - `[Id <String>]`: Read-only.
                              - `[Bold <Boolean?>]`: Represents the bold status of font.
                              - `[Color <String>]`: HTML color code representation of the text color. E.g. #FF0000 represents Red.
                              - `[Italic <Boolean?>]`: Represents the italic status of the font.
                              - `[Name <String>]`: Font name (e.g. 'Calibri')
                              - `[Size <Double?>]`: Size of the font (e.g. 11)
                              - `[Underline <String>]`: Type of underline applied to the font. The possible values are: None, Single.
                            - `[Line <IMicrosoftGraphWorkbookChartLineFormat1>]`: workbookChartLineFormat
                              - `[(Any) <Object>]`: This indicates any property can be added to this object.
                              - `[Id <String>]`: Read-only.
                              - `[Color <String>]`: HTML color code representing the color of lines in the chart.
                          - `[MajorGridline <IMicrosoftGraphWorkbookChartGridlines1>]`: workbookChartGridlines
                            - `[(Any) <Object>]`: This indicates any property can be added to this object.
                            - `[Id <String>]`: Read-only.
                            - `[Format <IMicrosoftGraphWorkbookChartGridlinesFormat1>]`: workbookChartGridlinesFormat
                              - `[(Any) <Object>]`: This indicates any property can be added to this object.
                              - `[Id <String>]`: Read-only.
                              - `[Line <IMicrosoftGraphWorkbookChartLineFormat1>]`: workbookChartLineFormat
                            - `[Visible <Boolean?>]`: Boolean value representing if the axis gridlines are visible or not.
                          - `[MajorUnit <IMicrosoftGraphJson>]`: Json
                          - `[Maximum <IMicrosoftGraphJson>]`: Json
                          - `[Minimum <IMicrosoftGraphJson>]`: Json
                          - `[MinorGridline <IMicrosoftGraphWorkbookChartGridlines1>]`: workbookChartGridlines
                          - `[MinorUnit <IMicrosoftGraphJson>]`: Json
                          - `[Title <IMicrosoftGraphWorkbookChartAxisTitle1>]`: workbookChartAxisTitle
                            - `[(Any) <Object>]`: This indicates any property can be added to this object.
                            - `[Id <String>]`: Read-only.
                            - `[Format <IMicrosoftGraphWorkbookChartAxisTitleFormat1>]`: workbookChartAxisTitleFormat
                              - `[(Any) <Object>]`: This indicates any property can be added to this object.
                              - `[Id <String>]`: Read-only.
                              - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                            - `[Text <String>]`: Represents the axis title.
                            - `[Visible <Boolean?>]`: A boolean that specifies the visibility of an axis title.
                        - `[SeriesAxis <IMicrosoftGraphWorkbookChartAxis1>]`: workbookChartAxis
                        - `[ValueAxis <IMicrosoftGraphWorkbookChartAxis1>]`: workbookChartAxis
                      - `[DataLabel <IMicrosoftGraphWorkbookChartDataLabels1>]`: workbookChartDataLabels
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Id <String>]`: Read-only.
                        - `[Format <IMicrosoftGraphWorkbookChartDataLabelFormat1>]`: workbookChartDataLabelFormat
                          - `[(Any) <Object>]`: This indicates any property can be added to this object.
                          - `[Id <String>]`: Read-only.
                          - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                            - `[(Any) <Object>]`: This indicates any property can be added to this object.
                            - `[Id <String>]`: Read-only.
                          - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                        - `[Position <String>]`: DataLabelPosition value that represents the position of the data label. The possible values are: None, Center, InsideEnd, InsideBase, OutsideEnd, Left, Right, Top, Bottom, BestFit, Callout.
                        - `[Separator <String>]`: String representing the separator used for the data labels on a chart.
                        - `[ShowBubbleSize <Boolean?>]`: Boolean value representing if the data label bubble size is visible or not.
                        - `[ShowCategoryName <Boolean?>]`: Boolean value representing if the data label category name is visible or not.
                        - `[ShowLegendKey <Boolean?>]`: Boolean value representing if the data label legend key is visible or not.
                        - `[ShowPercentage <Boolean?>]`: Boolean value representing if the data label percentage is visible or not.
                        - `[ShowSeriesName <Boolean?>]`: Boolean value representing if the data label series name is visible or not.
                        - `[ShowValue <Boolean?>]`: Boolean value representing if the data label value is visible or not.
                      - `[Format <IMicrosoftGraphWorkbookChartAreaFormat1>]`: workbookChartAreaFormat
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Id <String>]`: Read-only.
                        - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                        - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                      - `[Height <Double?>]`: Represents the height, in points, of the chart object.
                      - `[Left <Double?>]`: The distance, in points, from the left side of the chart to the worksheet origin.
                      - `[Legend <IMicrosoftGraphWorkbookChartLegend1>]`: workbookChartLegend
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Id <String>]`: Read-only.
                        - `[Format <IMicrosoftGraphWorkbookChartLegendFormat1>]`: workbookChartLegendFormat
                          - `[(Any) <Object>]`: This indicates any property can be added to this object.
                          - `[Id <String>]`: Read-only.
                          - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                          - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                        - `[Overlay <Boolean?>]`: Boolean value for whether the chart legend should overlap with the main body of the chart.
                        - `[Position <String>]`: Represents the position of the legend on the chart. The possible values are: Top, Bottom, Left, Right, Corner, Custom.
                        - `[Visible <Boolean?>]`: A boolean value the represents the visibility of a ChartLegend object.
                      - `[Name <String>]`: Represents the name of a chart object.
                      - `[Series <IMicrosoftGraphWorkbookChartSeries1[]>]`: Represents either a single series or collection of series in the chart. Read-only.
                        - `[Id <String>]`: Read-only.
                        - `[Format <IMicrosoftGraphWorkbookChartSeriesFormat1>]`: workbookChartSeriesFormat
                          - `[(Any) <Object>]`: This indicates any property can be added to this object.
                          - `[Id <String>]`: Read-only.
                          - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                          - `[Line <IMicrosoftGraphWorkbookChartLineFormat1>]`: workbookChartLineFormat
                        - `[Name <String>]`: Represents the name of a series in a chart.
                        - `[Point <IMicrosoftGraphWorkbookChartPoint1[]>]`: Represents a collection of all points in the series. Read-only.
                          - `[Id <String>]`: Read-only.
                          - `[Format <IMicrosoftGraphWorkbookChartPointFormat1>]`: workbookChartPointFormat
                            - `[(Any) <Object>]`: This indicates any property can be added to this object.
                            - `[Id <String>]`: Read-only.
                            - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                          - `[Value <IMicrosoftGraphJson>]`: Json
                      - `[Title <IMicrosoftGraphWorkbookChartTitle1>]`: workbookChartTitle
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Id <String>]`: Read-only.
                        - `[Format <IMicrosoftGraphWorkbookChartTitleFormat1>]`: workbookChartTitleFormat
                          - `[(Any) <Object>]`: This indicates any property can be added to this object.
                          - `[Id <String>]`: Read-only.
                          - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                          - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                        - `[Overlay <Boolean?>]`: Boolean value representing if the chart title will overlay the chart or not.
                        - `[Text <String>]`: Represents the title text of a chart.
                        - `[Visible <Boolean?>]`: A boolean value the represents the visibility of a chart title object.
                      - `[Top <Double?>]`: Represents the distance, in points, from the top edge of the object to the top of row 1 (on a worksheet) or the top of the chart area (on a chart).
                      - `[Width <Double?>]`: Represents the width, in points, of the chart object.
                      - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
                    - `[Name <String>]`: The display name of the worksheet.
                    - `[Names <IMicrosoftGraphWorkbookNamedItem1[]>]`: Returns collection of names that are associated with the worksheet. Read-only.
                    - `[PivotTable <IMicrosoftGraphWorkbookPivotTable1[]>]`: Collection of PivotTables that are part of the worksheet.
                      - `[Id <String>]`: Read-only.
                      - `[Name <String>]`: Name of the PivotTable.
                      - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
                    - `[Position <Int32?>]`: The zero-based position of the worksheet within the workbook.
                    - `[Protection <IMicrosoftGraphWorkbookWorksheetProtection1>]`: workbookWorksheetProtection
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Id <String>]`: Read-only.
                      - `[Option <IMicrosoftGraphWorkbookWorksheetProtectionOptions1>]`: workbookWorksheetProtectionOptions
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[AllowAutoFilter <Boolean?>]`: Represents the worksheet protection option of allowing using auto filter feature.
                        - `[AllowDeleteColumn <Boolean?>]`: Represents the worksheet protection option of allowing deleting columns.
                        - `[AllowDeleteRow <Boolean?>]`: Represents the worksheet protection option of allowing deleting rows.
                        - `[AllowFormatCell <Boolean?>]`: Represents the worksheet protection option of allowing formatting cells.
                        - `[AllowFormatColumn <Boolean?>]`: Represents the worksheet protection option of allowing formatting columns.
                        - `[AllowFormatRow <Boolean?>]`: Represents the worksheet protection option of allowing formatting rows.
                        - `[AllowInsertColumn <Boolean?>]`: Represents the worksheet protection option of allowing inserting columns.
                        - `[AllowInsertHyperlink <Boolean?>]`: Represents the worksheet protection option of allowing inserting hyperlinks.
                        - `[AllowInsertRow <Boolean?>]`: Represents the worksheet protection option of allowing inserting rows.
                        - `[AllowPivotTable <Boolean?>]`: Represents the worksheet protection option of allowing using pivot table feature.
                        - `[AllowSort <Boolean?>]`: Represents the worksheet protection option of allowing using sort feature.
                      - `[Protected <Boolean?>]`: Indicates if the worksheet is protected.  Read-only.
                    - `[Table <IMicrosoftGraphWorkbookTable1[]>]`: Collection of tables that are part of the worksheet. Read-only.
                      - `[Id <String>]`: Read-only.
                      - `[Column <IMicrosoftGraphWorkbookTableColumn1[]>]`: Represents a collection of all the columns in the table. Read-only.
                        - `[Id <String>]`: Read-only.
                        - `[Filter <IMicrosoftGraphWorkbookFilter1>]`: workbookFilter
                          - `[(Any) <Object>]`: This indicates any property can be added to this object.
                          - `[Id <String>]`: Read-only.
                          - `[Criterion <IMicrosoftGraphWorkbookFilterCriteria1>]`: workbookFilterCriteria
                            - `[(Any) <Object>]`: This indicates any property can be added to this object.
                            - `[Color <String>]`: 
                            - `[Criterion1 <String>]`: 
                            - `[Criterion2 <String>]`: 
                            - `[DynamicCriterion <String>]`: 
                            - `[FilterOn <String>]`: 
                            - `[Icon <IMicrosoftGraphWorkbookIcon1>]`: workbookIcon
                              - `[(Any) <Object>]`: This indicates any property can be added to this object.
                              - `[Index <Int32?>]`: Represents the index of the icon in the given set.
                              - `[Set <String>]`: Represents the set that the icon is part of. Possible values are: Invalid, ThreeArrows, ThreeArrowsGray, ThreeFlags, ThreeTrafficLights1, ThreeTrafficLights2, ThreeSigns, ThreeSymbols, ThreeSymbols2, FourArrows, FourArrowsGray, FourRedToBlack, FourRating, FourTrafficLights, FiveArrows, FiveArrowsGray, FiveRating, FiveQuarters, ThreeStars, ThreeTriangles, FiveBoxes.
                            - `[Operator <String>]`: 
                            - `[Value <IMicrosoftGraphJson>]`: Json
                        - `[Index <Int32?>]`: Returns the index number of the column within the columns collection of the table. Zero-indexed. Read-only.
                        - `[Name <String>]`: Returns the name of the table column.
                        - `[Value <IMicrosoftGraphJson>]`: Json
                      - `[HighlightFirstColumn <Boolean?>]`: Indicates whether the first column contains special formatting.
                      - `[HighlightLastColumn <Boolean?>]`: Indicates whether the last column contains special formatting.
                      - `[LegacyId <String>]`: Legacy Id used in older Excle clients. The value of the identifier remains the same even when the table is renamed. This property should be interpreted as an opaque string value and should not be parsed to any other type. Read-only.
                      - `[Name <String>]`: Name of the table.
                      - `[Row <IMicrosoftGraphWorkbookTableRow1[]>]`: Represents a collection of all the rows in the table. Read-only.
                        - `[Id <String>]`: Read-only.
                        - `[Index <Int32?>]`: Returns the index number of the row within the rows collection of the table. Zero-indexed. Read-only.
                        - `[Value <IMicrosoftGraphJson>]`: Json
                      - `[ShowBandedColumn <Boolean?>]`: Indicates whether the columns show banded formatting in which odd columns are highlighted differently from even ones to make reading the table easier.
                      - `[ShowBandedRow <Boolean?>]`: Indicates whether the rows show banded formatting in which odd rows are highlighted differently from even ones to make reading the table easier.
                      - `[ShowFilterButton <Boolean?>]`: Indicates whether the filter buttons are visible at the top of each column header. Setting this is only allowed if the table contains a header row.
                      - `[ShowHeader <Boolean?>]`: Indicates whether the header row is visible or not. This value can be set to show or remove the header row.
                      - `[ShowTotal <Boolean?>]`: Indicates whether the total row is visible or not. This value can be set to show or remove the total row.
                      - `[Sort <IMicrosoftGraphWorkbookTableSort1>]`: workbookTableSort
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Id <String>]`: Read-only.
                        - `[Field <IMicrosoftGraphWorkbookSortField1[]>]`: Represents the current conditions used to last sort the table. Read-only.
                          - `[Ascending <Boolean?>]`: Represents whether the sorting is done in an ascending fashion.
                          - `[Color <String>]`: Represents the color that is the target of the condition if the sorting is on font or cell color.
                          - `[DataOption <String>]`: Represents additional sorting options for this field. Possible values are: Normal, TextAsNumber.
                          - `[Icon <IMicrosoftGraphWorkbookIcon1>]`: workbookIcon
                          - `[Key <Int32?>]`: Represents the column (or row, depending on the sort orientation) that the condition is on. Represented as an offset from the first column (or row).
                          - `[SortOn <String>]`: Represents the type of sorting of this condition. Possible values are: Value, CellColor, FontColor, Icon.
                        - `[MatchCase <Boolean?>]`: Represents whether the casing impacted the last sort of the table. Read-only.
                        - `[Method <String>]`: Represents Chinese character ordering method last used to sort the table. Possible values are: PinYin, StrokeCount. Read-only.
                      - `[Style <String>]`: Constant value that represents the Table style. Possible values are: TableStyleLight1 thru TableStyleLight21, TableStyleMedium1 thru TableStyleMedium28, TableStyleStyleDark1 thru TableStyleStyleDark11. A custom user-defined style present in the workbook can also be specified.
                      - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
                    - `[Visibility <String>]`: The Visibility of the worksheet. The possible values are: Visible, Hidden, VeryHidden.
                - `[Operation <IMicrosoftGraphWorkbookOperation1[]>]`: The status of Workbook operations. Getting an operation collection is not supported, but you can get the status of a long-running operation if the Location header is returned in the response. Read-only. Nullable.
                  - `[Id <String>]`: Read-only.
                  - `[Error <IMicrosoftGraphWorkbookOperationError1>]`: workbookOperationError
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Code <String>]`: The error code.
                    - `[InnerError <IMicrosoftGraphWorkbookOperationError1>]`: workbookOperationError
                    - `[Message <String>]`: The error message.
                  - `[ResourceLocation <String>]`: The resource URI for the result.
                  - `[Status <String>]`: workbookOperationStatus
                - `[Table <IMicrosoftGraphWorkbookTable1[]>]`: Represents a collection of tables associated with the workbook. Read-only.
                - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1[]>]`: Represents a collection of worksheets associated with the workbook. Read-only.
          - `[Create <IMicrosoftGraphItemActionStat1>]`: itemActionStat
          - `[Delete <IMicrosoftGraphItemActionStat1>]`: itemActionStat
          - `[Edit <IMicrosoftGraphItemActionStat1>]`: itemActionStat
          - `[EndDateTime <DateTime?>]`: When the interval ends. Read-only.
          - `[IncompleteData <IMicrosoftGraphIncompleteData1>]`: incompleteData
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[MissingDataBeforeDateTime <DateTime?>]`: The service does not have source data before the specified time.
            - `[WasThrottled <Boolean?>]`: Some data was not recorded due to excessive activity.
          - `[IsTrending <Boolean?>]`: Indicates whether the item is 'trending.' Read-only.
          - `[Move <IMicrosoftGraphItemActionStat1>]`: itemActionStat
          - `[StartDateTime <DateTime?>]`: When the interval starts. Read-only.
        - `[ItemActivityStat <IMicrosoftGraphItemActivityStat1[]>]`: 
        - `[LastSevenDay <IMicrosoftGraphItemActivityStat1>]`: itemActivityStat
      - `[Column <IMicrosoftGraphColumnDefinition1[]>]`: The collection of column definitions reusable across lists under this site.
        - `[Id <String>]`: Read-only.
        - `[Boolean <IMicrosoftGraphBooleanColumn>]`: booleanColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Calculated <IMicrosoftGraphCalculatedColumn1>]`: calculatedColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Format <String>]`: For dateTime output types, the format of the value. Must be one of dateOnly or dateTime.
          - `[Formula <String>]`: The formula used to compute the value for this column.
          - `[OutputType <String>]`: The output type used to format values in this column. Must be one of boolean, currency, dateTime, number, or text.
        - `[Choice <IMicrosoftGraphChoiceColumn1>]`: choiceColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[AllowTextEntry <Boolean?>]`: If true, allows custom values that aren't in the configured choices.
          - `[Choice <String[]>]`: The list of values available for this column.
          - `[DisplayAs <String>]`: How the choices are to be presented in the UX. Must be one of checkBoxes, dropDownMenu, or radioButtons
        - `[ColumnGroup <String>]`: For site columns, the name of the group this column belongs to. Helps organize related columns.
        - `[Currency <IMicrosoftGraphCurrencyColumn1>]`: currencyColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Locale <String>]`: Specifies the locale from which to infer the currency symbol.
        - `[DateTime <IMicrosoftGraphDateTimeColumn1>]`: dateTimeColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DisplayAs <String>]`: How the value should be presented in the UX. Must be one of default, friendly, or standard. See below for more details. If unspecified, treated as default.
          - `[Format <String>]`: Indicates whether the value should be presented as a date only or a date and time. Must be one of dateOnly or dateTime
        - `[DefaultValue <IMicrosoftGraphDefaultColumnValue1>]`: defaultColumnValue
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Formula <String>]`: The formula used to compute the default value for this column.
          - `[Value <String>]`: The direct value to use as the default value for this column.
        - `[Description <String>]`: The user-facing description of the column.
        - `[DisplayName <String>]`: The user-facing name of the column.
        - `[EnforceUniqueValue <Boolean?>]`: If true, no two list items may have the same value for this column.
        - `[Geolocation <IMicrosoftGraphGeolocationColumn>]`: geolocationColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Hidden <Boolean?>]`: Specifies whether the column is displayed in the user interface.
        - `[Indexed <Boolean?>]`: Specifies whether the column values can used for sorting and searching.
        - `[Lookup <IMicrosoftGraphLookupColumn1>]`: lookupColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[AllowMultipleValue <Boolean?>]`: Indicates whether multiple values can be selected from the source.
          - `[AllowUnlimitedLength <Boolean?>]`: Indicates whether values in the column should be able to exceed the standard limit of 255 characters.
          - `[ColumnName <String>]`: The name of the lookup source column.
          - `[ListId <String>]`: The unique identifier of the lookup source list.
          - `[PrimaryLookupColumnId <String>]`: If specified, this column is a secondary lookup, pulling an additional field from the list item looked up by the primary lookup. Use the list item looked up by the primary as the source for the column named here.
        - `[Name <String>]`: The API-facing name of the column as it appears in the [fields][] on a [listItem][]. For the user-facing name, see displayName.
        - `[Number <IMicrosoftGraphNumberColumn1>]`: numberColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DecimalPlace <String>]`: How many decimal places to display. See below for information about the possible values.
          - `[DisplayAs <String>]`: How the value should be presented in the UX. Must be one of number or percentage. If unspecified, treated as number.
          - `[Maximum <Double?>]`: The maximum permitted value.
          - `[Minimum <Double?>]`: The minimum permitted value.
        - `[PersonOrGroup <IMicrosoftGraphPersonOrGroupColumn1>]`: personOrGroupColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[AllowMultipleSelection <Boolean?>]`: Indicates whether multiple values can be selected from the source.
          - `[ChooseFromType <String>]`: Whether to allow selection of people only, or people and groups. Must be one of peopleAndGroups or peopleOnly.
          - `[DisplayAs <String>]`: How to display the information about the person or group chosen. See below.
        - `[ReadOnly <Boolean?>]`: Specifies whether the column values can be modified.
        - `[Required <Boolean?>]`: Specifies whether the column value is not optional.
        - `[Text <IMicrosoftGraphTextColumn1>]`: textColumn
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[AllowMultipleLine <Boolean?>]`: Whether to allow multiple lines of text.
          - `[AppendChangesToExistingText <Boolean?>]`: Whether updates to this column should replace existing text, or append to it.
          - `[LinesForEditing <Int32?>]`: The size of the text box.
          - `[MaxLength <Int32?>]`: The maximum number of characters for the value.
          - `[TextType <String>]`: The type of text being stored. Must be one of plain or richText
      - `[ContentType <IMicrosoftGraphContentType1[]>]`: The collection of content types defined for this site.
        - `[Id <String>]`: Read-only.
        - `[ColumnLink <IMicrosoftGraphColumnLink1[]>]`: The collection of columns that are required by this content type
          - `[Id <String>]`: Read-only.
          - `[Name <String>]`: The name of the column  in this content type.
        - `[Description <String>]`: The descriptive text for the item.
        - `[Group <String>]`: The name of the group this content type belongs to. Helps organize related content types.
        - `[Hidden <Boolean?>]`: Indicates whether the content type is hidden in the list's 'New' menu.
        - `[InheritedFrom <IMicrosoftGraphItemReference1>]`: itemReference
        - `[Name <String>]`: The name of the content type.
        - `[Order <IMicrosoftGraphContentTypeOrder1>]`: contentTypeOrder
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Default <Boolean?>]`: Whether this is the default Content Type
          - `[Position <Int32?>]`: Specifies the position in which the Content Type appears in the selection UI.
        - `[ParentId <String>]`: The unique identifier of the content type.
        - `[ReadOnly <Boolean?>]`: If true, the content type cannot be modified unless this value is first set to false.
        - `[Sealed <Boolean?>]`: If true, the content type cannot be modified by users or through push-down operations. Only site collection administrators can seal or unseal content types.
      - `[DisplayName <String>]`: The full title for the site. Read-only.
      - `[Drive <IMicrosoftGraphDrive1>]`: drive
      - `[Drives <IMicrosoftGraphDrive1[]>]`: The collection of drives (document libraries) under this site.
      - `[Error <IMicrosoftGraphPublicError1>]`: publicError
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Code <String>]`: Represents the error code.
        - `[Detail <IMicrosoftGraphPublicErrorDetail1[]>]`: Details of the error.
          - `[Code <String>]`: The error code.
          - `[Message <String>]`: The error message.
          - `[Target <String>]`: The target of the error.
        - `[InnerError <IMicrosoftGraphPublicInnerError1>]`: publicInnerError
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Code <String>]`: The error code.
          - `[Detail <IMicrosoftGraphPublicErrorDetail1[]>]`: A collection of error details.
          - `[Message <String>]`: The error message.
          - `[Target <String>]`: The target of the error.
        - `[Message <String>]`: A non-localized message for the developer.
        - `[Target <String>]`: The target of the error.
      - `[Items <IMicrosoftGraphBaseItem1[]>]`: Used to address any item contained in this site. This collection cannot be enumerated.
        - `[Id <String>]`: Read-only.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
        - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
        - `[Description <String>]`: Provides a user-visible description of the item. Optional.
        - `[ETag <String>]`: ETag for the item. Read-only.
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
        - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
        - `[Name <String>]`: The name of the item. Read-write.
        - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
        - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
      - `[List <IMicrosoftGraphList1[]>]`: The collection of lists under this site.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
        - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
        - `[Description <String>]`: Provides a user-visible description of the item. Optional.
        - `[ETag <String>]`: ETag for the item. Read-only.
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
        - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
        - `[Name <String>]`: The name of the item. Read-write.
        - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
        - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
        - `[Id <String>]`: Read-only.
        - `[Column <IMicrosoftGraphColumnDefinition1[]>]`: The collection of field definitions for this list.
        - `[ContentType <IMicrosoftGraphContentType1[]>]`: The collection of content types present in this list.
        - `[DisplayName <String>]`: The displayable title of the list.
        - `[Drive <IMicrosoftGraphDrive1>]`: drive
        - `[Items <IMicrosoftGraphListItem1[]>]`: All items contained in the list.
        - `[List <IMicrosoftGraphListInfo1>]`: listInfo
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ContentTypesEnabled <Boolean?>]`: If true, indicates that content types are enabled for this list.
          - `[Hidden <Boolean?>]`: If true, indicates that the list is not normally visible in the SharePoint user experience.
          - `[Template <String>]`: An enumerated value that represents the base list template used in creating the list. Possible values include documentLibrary, genericList, task, survey, announcements, contacts, and more.
        - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
        - `[Subscription <IMicrosoftGraphSubscription1[]>]`: The set of subscriptions on the list.
        - `[System <IMicrosoftGraphSystemFacet>]`: systemFacet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Onenote <IMicrosoftGraphOnenote1>]`: onenote
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Id <String>]`: Read-only.
        - `[Notebook <IMicrosoftGraphNotebook1[]>]`: The collection of OneNote notebooks that are owned by the user or group. Read-only. Nullable.
          - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[DisplayName <String>]`: The name of the notebook.
          - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[LastModifiedDateTime <DateTime?>]`: The date and time when the notebook was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
          - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
          - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
          - `[Id <String>]`: Read-only.
          - `[IsDefault <Boolean?>]`: Indicates whether this is the user's default notebook. Read-only.
          - `[IsShared <Boolean?>]`: Indicates whether the notebook is shared. If true, the contents of the notebook can be seen by people other than the owner. Read-only.
          - `[Link <IMicrosoftGraphNotebookLinks1>]`: notebookLinks
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[OneNoteClientUrl <IMicrosoftGraphExternalLink1>]`: externalLink
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[Href <String>]`: The url of the link.
            - `[OneNoteWebUrl <IMicrosoftGraphExternalLink1>]`: externalLink
          - `[Section <IMicrosoftGraphOnenoteSection1[]>]`: The sections in the notebook. Read-only. Nullable.
            - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[DisplayName <String>]`: The name of the notebook.
            - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[LastModifiedDateTime <DateTime?>]`: The date and time when the notebook was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
            - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
            - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
            - `[Id <String>]`: Read-only.
            - `[IsDefault <Boolean?>]`: Indicates whether this is the user's default section. Read-only.
            - `[Link <IMicrosoftGraphSectionLinks1>]`: sectionLinks
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[OneNoteClientUrl <IMicrosoftGraphExternalLink1>]`: externalLink
              - `[OneNoteWebUrl <IMicrosoftGraphExternalLink1>]`: externalLink
            - `[Page <IMicrosoftGraphOnenotePage1[]>]`: The collection of pages in the section.  Read-only. Nullable.
              - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
              - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
              - `[Id <String>]`: Read-only.
              - `[Content <Byte[]>]`: The page's HTML content.
              - `[ContentUrl <String>]`: The URL for the page's HTML content.  Read-only.
              - `[CreatedByAppId <String>]`: The unique identifier of the application that created the page. Read-only.
              - `[LastModifiedDateTime <DateTime?>]`: The date and time when the page was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
              - `[Level <Int32?>]`: The indentation level of the page. Read-only.
              - `[Link <IMicrosoftGraphPageLinks1>]`: pageLinks
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[OneNoteClientUrl <IMicrosoftGraphExternalLink1>]`: externalLink
                - `[OneNoteWebUrl <IMicrosoftGraphExternalLink1>]`: externalLink
              - `[Order <Int32?>]`: The order of the page within its parent section. Read-only.
              - `[ParentNotebook <IMicrosoftGraphNotebook1>]`: notebook
              - `[ParentSection <IMicrosoftGraphOnenoteSection1>]`: onenoteSection
              - `[Title <String>]`: The title of the page.
              - `[UserTag <String[]>]`: 
            - `[PagesUrl <String>]`: The pages endpoint where you can get details for all the pages in the section. Read-only.
            - `[ParentNotebook <IMicrosoftGraphNotebook1>]`: notebook
            - `[ParentSectionGroup <IMicrosoftGraphSectionGroup1>]`: sectionGroup
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
              - `[DisplayName <String>]`: The name of the notebook.
              - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
              - `[LastModifiedDateTime <DateTime?>]`: The date and time when the notebook was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
              - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
              - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
              - `[Id <String>]`: Read-only.
              - `[ParentNotebook <IMicrosoftGraphNotebook1>]`: notebook
              - `[ParentSectionGroup <IMicrosoftGraphSectionGroup1>]`: sectionGroup
              - `[Section <IMicrosoftGraphOnenoteSection1[]>]`: The sections in the section group. Read-only. Nullable.
              - `[SectionGroup <IMicrosoftGraphSectionGroup1[]>]`: The section groups in the section. Read-only. Nullable.
              - `[SectionGroupsUrl <String>]`: The URL for the sectionGroups navigation property, which returns all the section groups in the section group. Read-only.
              - `[SectionsUrl <String>]`: The URL for the sections navigation property, which returns all the sections in the section group. Read-only.
          - `[SectionGroup <IMicrosoftGraphSectionGroup1[]>]`: The section groups in the notebook. Read-only. Nullable.
          - `[SectionGroupsUrl <String>]`: The URL for the sectionGroups navigation property, which returns all the section groups in the notebook. Read-only.
          - `[SectionsUrl <String>]`: The URL for the sections navigation property, which returns all the sections in the notebook. Read-only.
          - `[UserRole <String>]`: onenoteUserRole
        - `[Operation <IMicrosoftGraphOnenoteOperation1[]>]`: The status of OneNote operations. Getting an operations collection is not supported, but you can get the status of long-running operations if the Operation-Location header is returned in the response. Read-only. Nullable.
          - `[CreatedDateTime <DateTime?>]`: The start time of the operation.
          - `[LastActionDateTime <DateTime?>]`: The time of the last action of the operation.
          - `[Status <String>]`: operationStatus
          - `[Id <String>]`: Read-only.
          - `[Error <IMicrosoftGraphOnenoteOperationError1>]`: onenoteOperationError
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Code <String>]`: The error code.
            - `[Message <String>]`: The error message.
          - `[PercentComplete <String>]`: The operation percent complete if the operation is still in running status.
          - `[ResourceId <String>]`: The resource id.
          - `[ResourceLocation <String>]`: The resource URI for the object. For example, the resource URI for a copied page or section.
        - `[Page <IMicrosoftGraphOnenotePage1[]>]`: The pages in all OneNote notebooks that are owned by the user or group.  Read-only. Nullable.
        - `[Resource <IMicrosoftGraphOnenoteResource1[]>]`: The image and other file resources in OneNote pages. Getting a resources collection is not supported, but you can get the binary content of a specific resource. Read-only. Nullable.
          - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
          - `[Id <String>]`: Read-only.
          - `[Content <Byte[]>]`: The content stream
          - `[ContentUrl <String>]`: The URL for downloading the content
        - `[Section <IMicrosoftGraphOnenoteSection1[]>]`: The sections in all OneNote notebooks that are owned by the user or group.  Read-only. Nullable.
        - `[SectionGroup <IMicrosoftGraphSectionGroup1[]>]`: The section groups in all OneNote notebooks that are owned by the user or group.  Read-only. Nullable.
      - `[Permission <IMicrosoftGraphPermission1[]>]`: The permissions associated with the site. Nullable.
      - `[Root <IMicrosoftGraphRoot>]`: root
      - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
      - `[Site <IMicrosoftGraphSite1[]>]`: The collection of the sub-sites under this site.
      - `[SiteCollection <IMicrosoftGraphSiteCollection1>]`: siteCollection
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DataLocationCode <String>]`: The geographic region code for where this site collection resides. Read-only.
        - `[Hostname <String>]`: The hostname for the site collection. Read-only.
        - `[Root <IMicrosoftGraphRoot>]`: root
    - `[GivenName <String>]`: The given name (first name) of the user. Maximum length is 64 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
    - `[HireDate <DateTime?>]`: The hire date of the user. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.  Returned only on $select.  Note: This property is specific to SharePoint Online. We recommend using the native employeeHireDate property to set and update hire date values using Microsoft Graph APIs.
    - `[Identity <IMicrosoftGraphObjectIdentity1[]>]`: Represents the identities that can be used to sign in to this user account. An identity can be provided by Microsoft (also known as a local account), by organizations, or by social identity providers such as Facebook, Google, and Microsoft, and tied to a user account. May contain multiple items with the same signInType value. Supports $filter (eq) only where the signInType is not userPrincipalName.
      - `[Issuer <String>]`: Specifies the issuer of the identity, for example facebook.com.For local accounts (where signInType is not federated), this property is the local B2C tenant default domain name, for example contoso.onmicrosoft.com.For external users from other Azure AD organization, this will be the domain of the federated organization, for example contoso.com.Supports $filter. 512 character limit.
      - `[IssuerAssignedId <String>]`: Specifies the unique identifier assigned to the user by the issuer. The combination of issuer and issuerAssignedId must be unique within the organization. Represents the sign-in name for the user, when signInType is set to emailAddress or userName (also known as local accounts).When signInType is set to: emailAddress, (or a custom string that starts with emailAddress like emailAddress1) issuerAssignedId must be a valid email addressuserName, issuerAssignedId must be a valid local part of an email addressSupports $filter. 100 character limit.
      - `[SignInType <String>]`: Specifies the user sign-in types in your directory, such as emailAddress, userName or federated. Here, federated represents a unique identifier for a user from an issuer, that can be in any format chosen by the issuer. Additional validation is enforced on issuerAssignedId when the sign-in type is set to emailAddress or userName. This property can also be set to any custom string.
    - `[InferenceClassification <IMicrosoftGraphInferenceClassification1>]`: inferenceClassification
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[Override <IMicrosoftGraphInferenceClassificationOverride1[]>]`: A set of overrides for a user to always classify messages from specific senders in certain ways: focused, or other. Read-only. Nullable.
        - `[Id <String>]`: Read-only.
        - `[ClassifyAs <String>]`: inferenceClassificationType
        - `[SenderEmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
    - `[Insight <IMicrosoftGraphOfficeGraphInsights1>]`: officeGraphInsights
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[Shared <IMicrosoftGraphSharedInsight1[]>]`: Access this property from the derived type itemInsights.
        - `[Id <String>]`: Read-only.
        - `[LastShared <IMicrosoftGraphSharingDetail1>]`: sharingDetail
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[SharedBy <IMicrosoftGraphInsightIdentity1>]`: insightIdentity
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Address <String>]`: The email address of the user who shared the item.
            - `[DisplayName <String>]`: The display name of the user who shared the item.
            - `[Id <String>]`: The id of the user who shared the item.
          - `[SharedDateTime <DateTime?>]`: The date and time the file was last shared. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
          - `[SharingReference <IMicrosoftGraphResourceReference1>]`: resourceReference
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Id <String>]`: The item's unique identifier.
            - `[Type <String>]`: A string value that can be used to classify the item, such as 'microsoft.graph.driveItem'
            - `[WebUrl <String>]`: A URL leading to the referenced item.
          - `[SharingSubject <String>]`: The subject with which the document was shared.
          - `[SharingType <String>]`: Determines the way the document was shared, can be by a 'Link', 'Attachment', 'Group', 'Site'.
        - `[LastSharedMethodId <String>]`: Read-only.
        - `[ResourceId <String>]`: Read-only.
        - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
        - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ContainerDisplayName <String>]`: A string describing where the item is stored. For example, the name of a SharePoint site or the user name identifying the owner of the OneDrive storing the item.
          - `[ContainerType <String>]`: Can be used for filtering by the type of container in which the file is stored. Such as Site or OneDriveBusiness.
          - `[ContainerWebUrl <String>]`: A path leading to the folder in which the item is stored.
          - `[MediaType <String>]`: The item's media type. Can be used for filtering for a specific type of file based on supported IANA Media Mime Types. Note that not all Media Mime Types are supported.
          - `[PreviewImageUrl <String>]`: A URL leading to the preview image for the item.
          - `[PreviewText <String>]`: A preview text for the item.
          - `[Title <String>]`: The item's title text.
          - `[Type <String>]`: The item's media type. Can be used for filtering for a specific file based on a specific type. See below for supported types.
        - `[SharingHistory <IMicrosoftGraphSharingDetail1[]>]`: 
      - `[Trending <IMicrosoftGraphTrending1[]>]`: Access this property from the derived type itemInsights.
        - `[Id <String>]`: Read-only.
        - `[LastModifiedDateTime <DateTime?>]`: 
        - `[ResourceId <String>]`: Read-only.
        - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
        - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
        - `[Weight <Double?>]`: Value indicating how much the document is currently trending. The larger the number, the more the document is currently trending around the user (the more relevant it is). Returned documents are sorted by this value.
      - `[Used <IMicrosoftGraphUsedInsight1[]>]`: Access this property from the derived type itemInsights.
        - `[Id <String>]`: Read-only.
        - `[LastUsed <IMicrosoftGraphUsageDetails1>]`: usageDetails
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[LastAccessedDateTime <DateTime?>]`: The date and time the resource was last accessed by the user. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
          - `[LastModifiedDateTime <DateTime?>]`: The date and time the resource was last modified by the user. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
        - `[ResourceId <String>]`: Read-only.
        - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
        - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
    - `[Interest <String[]>]`: A list for the user to describe their interests. Returned only on $select.
    - `[IsResourceAccount <Boolean?>]`: Do not use – reserved for future use.
    - `[JobTitle <String>]`: The user's job title. Maximum length is 128 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
    - `[Mail <String>]`: The SMTP address for the user, for example, admin@contoso.com. Changes to this property will also update the user's proxyAddresses collection to include the value as an SMTP address. While this property can contain accent characters, using them can cause access issues with other Microsoft applications for the user. Supports $filter (eq, ne, NOT, ge, le, in, startsWith, endsWith).
    - `[MailNickname <String>]`: The mail alias for the user. This property must be specified when a user is created. Maximum length is 64 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[MailboxSetting <IMicrosoftGraphMailboxSettings1>]`: mailboxSettings
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ArchiveFolder <String>]`: Folder ID of an archive folder for the user. Read only.
      - `[AutomaticRepliesSetting <IMicrosoftGraphAutomaticRepliesSetting1>]`: automaticRepliesSetting
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ExternalAudience <String>]`: externalAudienceScope
        - `[ExternalReplyMessage <String>]`: The automatic reply to send to the specified external audience, if Status is AlwaysEnabled or Scheduled.
        - `[InternalReplyMessage <String>]`: The automatic reply to send to the audience internal to the signed-in user's organization, if Status is AlwaysEnabled or Scheduled.
        - `[ScheduledEndDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[ScheduledStartDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[Status <String>]`: automaticRepliesStatus
      - `[DateFormat <String>]`: The date format for the user's mailbox.
      - `[DelegateMeetingMessageDeliveryOption <String>]`: delegateMeetingMessageDeliveryOptions
      - `[Language <IMicrosoftGraphLocaleInfo1>]`: localeInfo
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DisplayName <String>]`: A name representing the user's locale in natural language, for example, 'English (United States)'.
        - `[Locale <String>]`: A locale representation for the user, which includes the user's preferred language and country/region. For example, 'en-us'. The language component follows 2-letter codes as defined in ISO 639-1, and the country component follows 2-letter codes as defined in ISO 3166-1 alpha-2.
      - `[TimeFormat <String>]`: The time format for the user's mailbox.
      - `[TimeZone <String>]`: The default time zone for the user's mailbox.
      - `[WorkingHour <IMicrosoftGraphWorkingHours1>]`: workingHours
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DaysOfWeek <String[]>]`: The days of the week on which the user works.
        - `[EndTime <String>]`: The time of the day that the user stops working.
        - `[StartTime <String>]`: The time of the day that the user starts working.
        - `[TimeZone <IMicrosoftGraphTimeZoneBase1>]`: timeZoneBase
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Name <String>]`: The name of a time zone. It can be a standard time zone name such as 'Hawaii-Aleutian Standard Time', or 'Customized Time Zone' for a custom time zone.
    - `[ManagedAppRegistration <IMicrosoftGraphManagedAppRegistration1[]>]`: Zero or more managed app registrations that belong to the user.
      - `[Id <String>]`: Read-only.
      - `[AppIdentifier <IMicrosoftGraphMobileAppIdentifier>]`: The identifier for a mobile app.
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ApplicationVersion <String>]`: App version
      - `[AppliedPolicy <IMicrosoftGraphManagedAppPolicy1[]>]`: Zero or more policys already applied on the registered app when it last synchronized with managment service.
        - `[Id <String>]`: Read-only.
        - `[CreatedDateTime <DateTime?>]`: The date and time the policy was created.
        - `[Description <String>]`: The policy's description.
        - `[DisplayName <String>]`: Policy display name.
        - `[LastModifiedDateTime <DateTime?>]`: Last time the policy was modified.
        - `[Version <String>]`: Version of the entity.
      - `[CreatedDateTime <DateTime?>]`: Date and time of creation
      - `[DeviceName <String>]`: Host device name
      - `[DeviceTag <String>]`: App management SDK generated tag, which helps relate apps hosted on the same device. Not guaranteed to relate apps in all conditions.
      - `[DeviceType <String>]`: Host device type
      - `[FlaggedReason <String[]>]`: Zero or more reasons an app registration is flagged. E.g. app running on rooted device
      - `[IntendedPolicy <IMicrosoftGraphManagedAppPolicy1[]>]`: Zero or more policies admin intended for the app as of now.
      - `[LastSyncDateTime <DateTime?>]`: Date and time of last the app synced with management service.
      - `[ManagementSdkVersion <String>]`: App management SDK version
      - `[Operation <IMicrosoftGraphManagedAppOperation1[]>]`: Zero or more long running operations triggered on the app registration.
        - `[Id <String>]`: Read-only.
        - `[DisplayName <String>]`: The operation name.
        - `[LastModifiedDateTime <DateTime?>]`: The last time the app operation was modified.
        - `[State <String>]`: The current state of the operation
        - `[Version <String>]`: Version of the entity.
      - `[PlatformVersion <String>]`: Operating System version
      - `[UserId <String>]`: The user Id to who this app registration belongs.
      - `[Version <String>]`: Version of the entity.
    - `[ManagedDevice <IMicrosoftGraphManagedDevice1[]>]`: The managed devices associated with the user.
      - `[Id <String>]`: Read-only.
      - `[ActivationLockBypassCode <String>]`: Code that allows the Activation Lock on a device to be bypassed. This property is read-only.
      - `[AndroidSecurityPatchLevel <String>]`: Android security patch level. This property is read-only.
      - `[AzureAdDeviceId <String>]`: The unique identifier for the Azure Active Directory device. Read only. This property is read-only.
      - `[AzureAdRegistered <Boolean?>]`: Whether the device is Azure Active Directory registered. This property is read-only.
      - `[ComplianceGracePeriodExpirationDateTime <DateTime?>]`: The DateTime when device compliance grace period expires. This property is read-only.
      - `[ComplianceState <String>]`: complianceState
      - `[ConfigurationManagerClientEnabledFeature <IMicrosoftGraphConfigurationManagerClientEnabledFeatures1>]`: configuration Manager client enabled features
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[CompliancePolicy <Boolean?>]`: Whether compliance policy is managed by Intune
        - `[DeviceConfiguration <Boolean?>]`: Whether device configuration is managed by Intune
        - `[Inventory <Boolean?>]`: Whether inventory is managed by Intune
        - `[ModernApp <Boolean?>]`: Whether modern application is managed by Intune
        - `[ResourceAccess <Boolean?>]`: Whether resource access is managed by Intune
        - `[WindowsUpdateForBusiness <Boolean?>]`: Whether Windows Update for Business is managed by Intune
      - `[DeviceActionResult <IMicrosoftGraphDeviceActionResult1[]>]`: List of ComplexType deviceActionResult objects. This property is read-only.
        - `[ActionName <String>]`: Action name
        - `[ActionState <String>]`: actionState
        - `[LastUpdatedDateTime <DateTime?>]`: Time the action state was last updated
        - `[StartDateTime <DateTime?>]`: Time the action was initiated
      - `[DeviceCategory <IMicrosoftGraphDeviceCategory1>]`: Device categories provides a way to organize your devices. Using device categories, company administrators can define their own categories that make sense to their company. These categories can then be applied to a device in the Intune Azure console or selected by a user during device enrollment. You can filter reports and create dynamic Azure Active Directory device groups based on device categories.
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Id <String>]`: Read-only.
        - `[Description <String>]`: Optional description for the device category.
        - `[DisplayName <String>]`: Display name for the device category.
      - `[DeviceCategoryDisplayName <String>]`: Device category display name. This property is read-only.
      - `[DeviceCompliancePolicyState <IMicrosoftGraphDeviceCompliancePolicyState1[]>]`: Device compliance policy states for this device.
        - `[Id <String>]`: Read-only.
        - `[DisplayName <String>]`: The name of the policy for this policyBase
        - `[PlatformType <String>]`: policyPlatformType
        - `[SettingCount <Int32?>]`: Count of how many setting a policy holds
        - `[SettingState <IMicrosoftGraphDeviceCompliancePolicySettingState1[]>]`: 
          - `[CurrentValue <String>]`: Current value of setting on device
          - `[ErrorCode <Int64?>]`: Error code for the setting
          - `[ErrorDescription <String>]`: Error description
          - `[InstanceDisplayName <String>]`: Name of setting instance that is being reported.
          - `[Setting <String>]`: The setting that is being reported
          - `[SettingName <String>]`: Localized/user friendly setting name that is being reported
          - `[Source <IMicrosoftGraphSettingSource1[]>]`: Contributing policies
            - `[DisplayName <String>]`: Not yet documented
            - `[Id <String>]`: Not yet documented
          - `[State <String>]`: complianceStatus
          - `[UserEmail <String>]`: UserEmail
          - `[UserId <String>]`: UserId
          - `[UserName <String>]`: UserName
          - `[UserPrincipalName <String>]`: UserPrincipalName.
        - `[State <String>]`: complianceStatus
        - `[Version <Int32?>]`: The version of the policy
      - `[DeviceConfigurationState <IMicrosoftGraphDeviceConfigurationState1[]>]`: Device configuration states for this device.
        - `[Id <String>]`: Read-only.
        - `[DisplayName <String>]`: The name of the policy for this policyBase
        - `[PlatformType <String>]`: policyPlatformType
        - `[SettingCount <Int32?>]`: Count of how many setting a policy holds
        - `[SettingState <IMicrosoftGraphDeviceConfigurationSettingState1[]>]`: 
          - `[CurrentValue <String>]`: Current value of setting on device
          - `[ErrorCode <Int64?>]`: Error code for the setting
          - `[ErrorDescription <String>]`: Error description
          - `[InstanceDisplayName <String>]`: Name of setting instance that is being reported.
          - `[Setting <String>]`: The setting that is being reported
          - `[SettingName <String>]`: Localized/user friendly setting name that is being reported
          - `[Source <IMicrosoftGraphSettingSource1[]>]`: Contributing policies
          - `[State <String>]`: complianceStatus
          - `[UserEmail <String>]`: UserEmail
          - `[UserId <String>]`: UserId
          - `[UserName <String>]`: UserName
          - `[UserPrincipalName <String>]`: UserPrincipalName.
        - `[State <String>]`: complianceStatus
        - `[Version <Int32?>]`: The version of the policy
      - `[DeviceEnrollmentType <String>]`: deviceEnrollmentType
      - `[DeviceHealthAttestationState <IMicrosoftGraphDeviceHealthAttestationState1>]`: deviceHealthAttestationState
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[AttestationIdentityKey <String>]`: TWhen an Attestation Identity Key (AIK) is present on a device, it indicates that the device has an endorsement key (EK) certificate.
        - `[BitLockerStatus <String>]`: On or Off of BitLocker Drive Encryption
        - `[BootAppSecurityVersion <String>]`: The security version number of the Boot Application
        - `[BootDebugging <String>]`: When bootDebugging is enabled, the device is used in development and testing
        - `[BootManagerSecurityVersion <String>]`: The security version number of the Boot Application
        - `[BootManagerVersion <String>]`: The version of the Boot Manager
        - `[BootRevisionListInfo <String>]`: The Boot Revision List that was loaded during initial boot on the attested device
        - `[CodeIntegrity <String>]`: When code integrity is enabled, code execution is restricted to integrity verified code
        - `[CodeIntegrityCheckVersion <String>]`: The version of the Boot Manager
        - `[CodeIntegrityPolicy <String>]`: The Code Integrity policy that is controlling the security of the boot environment
        - `[ContentNamespaceUrl <String>]`: The DHA report version. (Namespace version)
        - `[ContentVersion <String>]`: The HealthAttestation state schema version
        - `[DataExcutionPolicy <String>]`: DEP Policy defines a set of hardware and software technologies that perform additional checks on memory
        - `[DeviceHealthAttestationStatus <String>]`: The DHA report version. (Namespace version)
        - `[EarlyLaunchAntiMalwareDriverProtection <String>]`: ELAM provides protection for the computers in your network when they start up
        - `[HealthAttestationSupportedStatus <String>]`: This attribute indicates if DHA is supported for the device
        - `[HealthStatusMismatchInfo <String>]`: This attribute appears if DHA-Service detects an integrity issue
        - `[IssuedDateTime <DateTime?>]`: The DateTime when device was evaluated or issued to MDM
        - `[LastUpdateDateTime <String>]`: The Timestamp of the last update.
        - `[OperatingSystemKernelDebugging <String>]`: When operatingSystemKernelDebugging is enabled, the device is used in development and testing
        - `[OperatingSystemRevListInfo <String>]`: The Operating System Revision List that was loaded during initial boot on the attested device
        - `[Pcr0 <String>]`: The measurement that is captured in PCR[0]
        - `[PcrHashAlgorithm <String>]`: Informational attribute that identifies the HASH algorithm that was used by TPM
        - `[ResetCount <Int64?>]`: The number of times a PC device has hibernated or resumed
        - `[RestartCount <Int64?>]`: The number of times a PC device has rebooted
        - `[SafeMode <String>]`: Safe mode is a troubleshooting option for Windows that starts your computer in a limited state
        - `[SecureBoot <String>]`: When Secure Boot is enabled, the core components must have the correct cryptographic signatures
        - `[SecureBootConfigurationPolicyFingerPrint <String>]`: Fingerprint of the Custom Secure Boot Configuration Policy
        - `[TestSigning <String>]`: When test signing is allowed, the device does not enforce signature validation during boot
        - `[TpmVersion <String>]`: The security version number of the Boot Application
        - `[VirtualSecureMode <String>]`: VSM is a container that protects high value assets from a compromised kernel
        - `[WindowsPe <String>]`: Operating system running with limited services that is used to prepare a computer for Windows
      - `[DeviceName <String>]`: Name of the device. This property is read-only.
      - `[DeviceRegistrationState <String>]`: deviceRegistrationState
      - `[EasActivated <Boolean?>]`: Whether the device is Exchange ActiveSync activated. This property is read-only.
      - `[EasActivationDateTime <DateTime?>]`: Exchange ActivationSync activation time of the device. This property is read-only.
      - `[EasDeviceId <String>]`: Exchange ActiveSync Id of the device. This property is read-only.
      - `[EmailAddress <String>]`: Email(s) for the user associated with the device. This property is read-only.
      - `[EnrolledDateTime <DateTime?>]`: Enrollment time of the device. This property is read-only.
      - `[EthernetMacAddress <String>]`: Ethernet MAC. This property is read-only.
      - `[ExchangeAccessState <String>]`: deviceManagementExchangeAccessState
      - `[ExchangeAccessStateReason <String>]`: deviceManagementExchangeAccessStateReason
      - `[ExchangeLastSuccessfulSyncDateTime <DateTime?>]`: Last time the device contacted Exchange. This property is read-only.
      - `[FreeStorageSpaceInByte <Int64?>]`: Free Storage in Bytes. This property is read-only.
      - `[Iccid <String>]`: Integrated Circuit Card Identifier, it is A SIM card's unique identification number. This property is read-only.
      - `[Imei <String>]`: IMEI. This property is read-only.
      - `[IsEncrypted <Boolean?>]`: Device encryption status. This property is read-only.
      - `[IsSupervised <Boolean?>]`: Device supervised status. This property is read-only.
      - `[JailBroken <String>]`: whether the device is jail broken or rooted. This property is read-only.
      - `[LastSyncDateTime <DateTime?>]`: The date and time that the device last completed a successful sync with Intune. This property is read-only.
      - `[ManagedDeviceName <String>]`: Automatically generated name to identify a device. Can be overwritten to a user friendly name.
      - `[ManagedDeviceOwnerType <String>]`: managedDeviceOwnerType
      - `[ManagementAgent <String>]`: managementAgentType
      - `[Manufacturer <String>]`: Manufacturer of the device. This property is read-only.
      - `[Meid <String>]`: MEID. This property is read-only.
      - `[Model <String>]`: Model of the device. This property is read-only.
      - `[Note <String>]`: Notes on the device created by IT Admin
      - `[OSVersion <String>]`: Operating system version of the device. This property is read-only.
      - `[OperatingSystem <String>]`: Operating system of the device. Windows, iOS, etc. This property is read-only.
      - `[PartnerReportedThreatState <String>]`: managedDevicePartnerReportedHealthState
      - `[PhoneNumber <String>]`: Phone number of the device. This property is read-only.
      - `[PhysicalMemoryInByte <Int64?>]`: Total Memory in Bytes. This property is read-only.
      - `[RemoteAssistanceSessionErrorDetail <String>]`: An error string that identifies issues when creating Remote Assistance session objects. This property is read-only.
      - `[RemoteAssistanceSessionUrl <String>]`: Url that allows a Remote Assistance session to be established with the device. This property is read-only.
      - `[SerialNumber <String>]`: SerialNumber. This property is read-only.
      - `[SubscriberCarrier <String>]`: Subscriber Carrier. This property is read-only.
      - `[TotalStorageSpaceInByte <Int64?>]`: Total Storage in Bytes. This property is read-only.
      - `[Udid <String>]`: Unique Device Identifier for iOS and macOS devices. This property is read-only.
      - `[UserDisplayName <String>]`: User display name. This property is read-only.
      - `[UserId <String>]`: Unique Identifier for the user associated with the device. This property is read-only.
      - `[UserPrincipalName <String>]`: Device user principal name. This property is read-only.
      - `[WiFiMacAddress <String>]`: Wi-Fi MAC. This property is read-only.
    - `[Manager <IMicrosoftGraphDirectoryObject>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
    - `[MobilePhone <String>]`: The primary cellular telephone number for the user. Read-only for users synced from on-premises directory.  Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[MySite <String>]`: The URL for the user's personal site. Returned only on $select.
    - `[Oauth2PermissionGrant <IMicrosoftGraphOAuth2PermissionGrant1[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[ClientId <String>]`: The id of the client service principal for the application which is authorized to act on behalf of a signed-in user when accessing an API. Required. Supports $filter (eq only).
      - `[ConsentType <String>]`: Indicates whether authorization is granted for the client application to impersonate all users or only a specific user. AllPrincipals indicates authorization to impersonate all users. Principal indicates authorization to impersonate a specific user. Consent on behalf of all users can be granted by an administrator. Non-admin users may be authorized to consent on behalf of themselves in some cases, for some delegated permissions. Required. Supports $filter (eq only).
      - `[PrincipalId <String>]`: The id of the user on behalf of whom the client is authorized to access the resource, when consentType is Principal. If consentType is AllPrincipals this value is null. Required when consentType is Principal.
      - `[ResourceId <String>]`: The id of the resource service principal to which access is authorized. This identifies the API which the client is authorized to attempt to call on behalf of a signed-in user.
      - `[Scope <String>]`: A space-separated list of the claim values for delegated permissions which should be included in access tokens for the resource application (the API). For example, openid User.Read GroupMember.Read.All. Each claim value should match the value field of one of the delegated permissions defined by the API, listed in the publishedPermissionScopes property of the resource service principal.
    - `[OfficeLocation <String>]`: The office location in the user's place of business. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[OnPremisesExtensionAttribute <IMicrosoftGraphOnPremisesExtensionAttributes1>]`: onPremisesExtensionAttributes
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ExtensionAttribute1 <String>]`: First customizable extension attribute.
      - `[ExtensionAttribute10 <String>]`: Tenth customizable extension attribute.
      - `[ExtensionAttribute11 <String>]`: Eleventh customizable extension attribute.
      - `[ExtensionAttribute12 <String>]`: Twelfth customizable extension attribute.
      - `[ExtensionAttribute13 <String>]`: Thirteenth customizable extension attribute.
      - `[ExtensionAttribute14 <String>]`: Fourteenth customizable extension attribute.
      - `[ExtensionAttribute15 <String>]`: Fifteenth customizable extension attribute.
      - `[ExtensionAttribute2 <String>]`: Second customizable extension attribute.
      - `[ExtensionAttribute3 <String>]`: Third customizable extension attribute.
      - `[ExtensionAttribute4 <String>]`: Fourth customizable extension attribute.
      - `[ExtensionAttribute5 <String>]`: Fifth customizable extension attribute.
      - `[ExtensionAttribute6 <String>]`: Sixth customizable extension attribute.
      - `[ExtensionAttribute7 <String>]`: Seventh customizable extension attribute.
      - `[ExtensionAttribute8 <String>]`: Eighth customizable extension attribute.
      - `[ExtensionAttribute9 <String>]`: Ninth customizable extension attribute.
    - `[OnPremisesImmutableId <String>]`: This property is used to associate an on-premises Active Directory user account to their Azure AD user object. This property must be specified when creating a new user account in the Graph if you are using a federated domain for the user's userPrincipalName (UPN) property. Note: The $ and _ characters cannot be used when specifying this property. Supports $filter (eq, ne, NOT, ge, le, in).
    - `[OnPremisesProvisioningError <IMicrosoftGraphOnPremisesProvisioningError1[]>]`: Errors when using Microsoft synchronization product during provisioning.  Supports $filter (eq, NOT, ge, le).
    - `[Onenote <IMicrosoftGraphOnenote1>]`: onenote
    - `[OnlineMeeting <IMicrosoftGraphOnlineMeeting1[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[AllowAttendeeToEnableCamera <Boolean?>]`: Indicates whether attendees can turn on their camera.
      - `[AllowAttendeeToEnableMic <Boolean?>]`: Indicates whether attendees can turn on their microphone.
      - `[AllowMeetingChat <String>]`: meetingChatMode
      - `[AllowTeamworkReaction <Boolean?>]`: Indicates if Teams reactions are enabled for the meeting.
      - `[AllowedPresenter <String>]`: onlineMeetingPresenters
      - `[AudioConferencing <IMicrosoftGraphAudioConferencing1>]`: audioConferencing
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ConferenceId <String>]`: The conference id of the online meeting.
        - `[DialinUrl <String>]`: A URL to the externally-accessible web page that contains dial-in information.
        - `[TollFreeNumber <String>]`: The toll-free number that connects to the Audio Conference Provider.
        - `[TollNumber <String>]`: The toll number that connects to the Audio Conference Provider.
      - `[ChatInfo <IMicrosoftGraphChatInfo1>]`: chatInfo
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[MessageId <String>]`: The unique identifier for a message in a Microsoft Teams channel.
        - `[ReplyChainMessageId <String>]`: The ID of the reply message.
        - `[ThreadId <String>]`: The unique identifier for a thread in Microsoft Teams.
      - `[CreationDateTime <DateTime?>]`: The meeting creation time in UTC. Read-only.
      - `[EndDateTime <DateTime?>]`: The meeting end time in UTC.
      - `[ExternalId <String>]`: The external ID. A custom ID. Optional.
      - `[IsEntryExitAnnounced <Boolean?>]`: Indicates whether to announce when callers join or leave.
      - `[JoinInformation <IMicrosoftGraphItemBody1>]`: itemBody
      - `[JoinWebUrl <String>]`: The join URL of the online meeting. Read-only.
      - `[LobbyBypassSetting <IMicrosoftGraphLobbyBypassSettings1>]`: lobbyBypassSettings
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[IsDialInBypassEnabled <Boolean?>]`: Specifies whether or not to always let dial-in callers bypass the lobby. Optional.
        - `[Scope <String>]`: lobbyBypassScope
      - `[Participant <IMicrosoftGraphMeetingParticipants1>]`: meetingParticipants
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Attendee <IMicrosoftGraphMeetingParticipantInfo1[]>]`: Information of the meeting attendees.
          - `[Identity <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[Role <String>]`: onlineMeetingRole
          - `[Upn <String>]`: User principal name of the participant.
        - `[Organizer <IMicrosoftGraphMeetingParticipantInfo1>]`: meetingParticipantInfo
      - `[StartDateTime <DateTime?>]`: The meeting start time in UTC.
      - `[Subject <String>]`: The subject of the online meeting.
      - `[VideoTeleconferenceId <String>]`: The video teleconferencing ID. Read-only.
    - `[OtherMail <String[]>]`: A list of additional email addresses for the user; for example: ['bob@contoso.com', 'Robert@fabrikam.com'].NOTE: While this property can contain accent characters, they can cause access issues to first-party applications for the user.Supports $filter (eq, NOT, ge, le, in, startsWith).
    - `[Outlook <IMicrosoftGraphOutlookUser1>]`: outlookUser
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[MasterCategory <IMicrosoftGraphOutlookCategory1[]>]`: A list of categories defined for the user.
        - `[Id <String>]`: Read-only.
        - `[Color <String>]`: categoryColor
        - `[DisplayName <String>]`: A unique name that identifies a category in the user's mailbox. After a category is created, the name cannot be changed. Read-only.
    - `[PasswordPolicy <String>]`: Specifies password policies for the user. This value is an enumeration with one possible value being DisableStrongPassword, which allows weaker passwords than the default policy to be specified. DisablePasswordExpiration can also be specified. The two may be specified together; for example: DisablePasswordExpiration, DisableStrongPassword.Supports $filter (ne, NOT).
    - `[PasswordProfile <IMicrosoftGraphPasswordProfile1>]`: passwordProfile
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ForceChangePasswordNextSignIn <Boolean?>]`: true if the user must change her password on the next login; otherwise false. If not set, default is false. NOTE:  For Azure B2C tenants, set to false and instead use custom policies and user flows to force password reset at first sign in. See Force password reset at first logon.
      - `[ForceChangePasswordNextSignInWithMfa <Boolean?>]`: If true, at next sign-in, the user must perform a multi-factor authentication (MFA) before being forced to change their password. The behavior is identical to forceChangePasswordNextSignIn except that the user is required to first perform a multi-factor authentication before password change. After a password change, this property will be automatically reset to false. If not set, default is false.
      - `[Password <String>]`: The password for the user. This property is required when a user is created. It can be updated, but the user will be required to change the password on the next login. The password must satisfy minimum requirements as specified by the user’s passwordPolicies property. By default, a strong password is required.
    - `[PastProject <String[]>]`: A list for the user to enumerate their past projects. Returned only on $select.
    - `[Photo <IMicrosoftGraphProfilePhoto1>]`: profilePhoto
    - `[Planner <IMicrosoftGraphPlannerUser1>]`: plannerUser
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[Plan <IMicrosoftGraphPlannerPlan1[]>]`: Read-only. Nullable. Returns the plannerTasks assigned to the user.
      - `[Task <IMicrosoftGraphPlannerTask1[]>]`: Read-only. Nullable. Returns the plannerTasks assigned to the user.
    - `[PostalCode <String>]`: The postal code for the user's postal address. The postal code is specific to the user's country/region. In the United States of America, this attribute contains the ZIP code. Maximum length is 40 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[PreferredLanguage <String>]`: The preferred language for the user. Should follow ISO 639-1 Code; for example en-US. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[PreferredName <String>]`: The preferred name for the user. Returned only on $select.
    - `[Presence <IMicrosoftGraphPresence>]`: presence
      - `[Id <String>]`: Read-only.
      - `[Activity <String>]`: The supplemental information to a user's availability. Possible values are Available, Away, BeRightBack, Busy, DoNotDisturb, InACall, InAConferenceCall, Inactive,InAMeeting, Offline, OffWork,OutOfOffice, PresenceUnknown,Presenting, UrgentInterruptionsOnly.
      - `[Availability <String>]`: The base presence information for a user. Possible values are Available, AvailableIdle,  Away, BeRightBack, Busy, BusyIdle, DoNotDisturb, Offline, PresenceUnknown
    - `[Responsibility <String[]>]`: A list for the user to enumerate their responsibilities. Returned only on $select.
    - `[School <String[]>]`: A list for the user to enumerate the schools they have attended. Returned only on $select.
    - `[Setting <IMicrosoftGraphUserSettings1>]`: userSettings
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[ContributionToContentDiscoveryAsOrganizationDisabled <Boolean?>]`: Reflects the Office Delve organization level setting. When set to true, the organization doesn't have access to Office Delve. This setting is read-only and can only be changed by administrators in the SharePoint admin center.
      - `[ContributionToContentDiscoveryDisabled <Boolean?>]`: When set to true, documents in the user's Office Delve are disabled. Users can control this setting in Office Delve.
      - `[ShiftPreference <IMicrosoftGraphShiftPreferences1>]`: shiftPreferences
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[Id <String>]`: Read-only.
        - `[Availability <IMicrosoftGraphShiftAvailability1[]>]`: Availability of the user to be scheduled for work and its recurrence pattern.
          - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
          - `[TimeSlot <IMicrosoftGraphTimeRange1[]>]`: The time slot(s) preferred by the user.
            - `[EndTime <String>]`: End time for the time range.
            - `[StartTime <String>]`: Start time for the time range.
          - `[TimeZone <String>]`: Specifies the time zone for the indicated time.
    - `[ShowInAddressList <Boolean?>]`: true if the Outlook global address list should contain this user, otherwise false. If not set, this will be treated as true. For users invited through the invitation manager, this property will be set to false. Supports $filter (eq, ne, NOT, in).
    - `[Skill <String[]>]`: A list for the user to enumerate their skills. Returned only on $select.
    - `[State <String>]`: The state or province in the user's address. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[StreetAddress <String>]`: The street address of the user's place of business. Maximum length is 1024 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[Surname <String>]`: The user's surname (family name or last name). Maximum length is 64 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[Teamwork <IMicrosoftGraphUserTeamwork>]`: userTeamwork
      - `[Id <String>]`: Read-only.
      - `[InstalledApp <IMicrosoftGraphUserScopeTeamsAppInstallation1[]>]`: The apps installed in the personal scope of this user.
        - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
        - `[TeamsAppDefinition <IMicrosoftGraphTeamsAppDefinition1>]`: teamsAppDefinition
        - `[Id <String>]`: Read-only.
        - `[ChatCreatedDateTime <DateTime?>]`: Date and time at which the chat was created. Read-only.
        - `[ChatId <String>]`: Read-only.
        - `[ChatInstalledApp <IMicrosoftGraphTeamsAppInstallation1[]>]`: A collection of all the apps in the chat. Nullable.
        - `[ChatLastUpdatedDateTime <DateTime?>]`: Date and time at which the chat was renamed or list of members were last changed. Read-only.
        - `[ChatMember <IMicrosoftGraphConversationMember1[]>]`: A collection of all the members in the chat. Nullable.
        - `[ChatMessage <IMicrosoftGraphChatMessage1[]>]`: A collection of all the messages in the chat. Nullable.
        - `[ChatTab <IMicrosoftGraphTeamsTab1[]>]`: 
        - `[ChatTopic <String>]`: (Optional) Subject or topic for the chat. Only available for group chats.
        - `[ChatType <String>]`: chatType
    - `[Todo <IMicrosoftGraphTodo1>]`: todo
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[List <IMicrosoftGraphTodoTaskList1[]>]`: The task lists in the users mailbox.
        - `[Id <String>]`: Read-only.
        - `[DisplayName <String>]`: The name of the task list.
        - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the task list. Nullable.
        - `[IsOwner <Boolean?>]`: True if the user is owner of the given task list.
        - `[IsShared <Boolean?>]`: True if the task list is shared with other users
        - `[Task <IMicrosoftGraphTodoTask1[]>]`: The tasks in this task list. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
          - `[BodyLastModifiedDateTime <DateTime?>]`: The date and time when the task was last modified. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
          - `[CompletedDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
          - `[CreatedDateTime <DateTime?>]`: The date and time when the task was created. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
          - `[DueDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
          - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the task. Nullable.
          - `[Importance <String>]`: importance
          - `[IsReminderOn <Boolean?>]`: Set to true if an alert is set to remind the user of the task.
          - `[LastModifiedDateTime <DateTime?>]`: The date and time when the task was last modified. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
          - `[LinkedResource <IMicrosoftGraphLinkedResource1[]>]`: A collection of resources linked to the task.
            - `[Id <String>]`: Read-only.
            - `[ApplicationName <String>]`: Field indicating the app name of the source that is sending the linkedResource.
            - `[DisplayName <String>]`: Field indicating the title of the linkedResource.
            - `[ExternalId <String>]`: Id of the object that is associated with this task on the third-party/partner system.
            - `[WebUrl <String>]`: Deep link to the linkedResource.
          - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
          - `[ReminderDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
          - `[Status <String>]`: taskStatus
          - `[Title <String>]`: A brief description of the task.
        - `[WellknownListName <String>]`: wellknownListName
    - `[TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>]`: 
    - `[UsageLocation <String>]`: A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement to check for availability of services in countries.  Examples include: US, JP, and GB. Not nullable. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[UserPrincipalName <String>]`: The user principal name (UPN) of the user. The UPN is an Internet-style login name for the user based on the Internet standard RFC 822. By convention, this should map to the user's email name. The general format is alias@domain, where domain must be present in the tenant's collection of verified domains. This property is required when a user is created. The verified domains for the tenant can be accessed from the verifiedDomains property of organization.NOTE: While this property can contain accent characters, they can cause access issues to first-party applications for the user. Supports $filter (eq, ne, NOT, ge, le, in, startsWith, endsWith) and $orderBy.
    - `[UserType <String>]`: A string value that can be used to classify user types in your directory, such as Member and Guest. Supports $filter (eq, ne, NOT, in,).
  - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
  - `[Description <String>]`: Provides a user-visible description of the item. Optional.
  - `[ETag <String>]`: ETag for the item. Read-only.
  - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
  - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
  - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
  - `[Name <String>]`: The name of the item. Read-write.
  - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
  - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
  - `[Id <String>]`: Read-only.
  - `[DriveType <String>]`: Describes the type of drive represented by this resource. OneDrive personal drives will return personal. OneDrive for Business will return business. SharePoint document libraries will return documentLibrary. Read-only.
  - `[Following <IMicrosoftGraphDriveItem1[]>]`: The list of items the user is following. Only in OneDrive for Business.
  - `[Items <IMicrosoftGraphDriveItem1[]>]`: All items contained in the drive. Read-only. Nullable.
  - `[List <IMicrosoftGraphList1>]`: list
  - `[Owner <IMicrosoftGraphIdentitySet1>]`: identitySet
  - `[Quota <IMicrosoftGraphQuota1>]`: quota
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Deleted <Int64?>]`: Total space consumed by files in the recycle bin, in bytes. Read-only.
    - `[Remaining <Int64?>]`: Total space remaining before reaching the quota limit, in bytes. Read-only.
    - `[State <String>]`: Enumeration value that indicates the state of the storage space. Read-only.
    - `[StoragePlanInformation <IMicrosoftGraphStoragePlanInformation1>]`: storagePlanInformation
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[UpgradeAvailable <Boolean?>]`: Indicates if there are higher storage quota plans available. Read-only.
    - `[Total <Int64?>]`: Total allowed storage space, in bytes. Read-only.
    - `[Used <Int64?>]`: Total space used, in bytes. Read-only.
  - `[Root <IMicrosoftGraphDriveItem1>]`: driveItem
  - `[SharePointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
  - `[Special <IMicrosoftGraphDriveItem1[]>]`: Collection of common folders available in OneDrive. Read-only. Nullable.
  - `[System <IMicrosoftGraphSystemFacet>]`: systemFacet

EMPLOYEEORGDATA <IMicrosoftGraphEmployeeOrgData1>: employeeOrgData
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[CostCenter <String>]`: The cost center associated with the user. Returned only on $select. Supports $filter.
  - `[Division <String>]`: The name of the division in which the user works. Returned only on $select. Supports $filter.

EXTENSION <IMicrosoftGraphExtension1[]>: The collection of open extensions defined for the user. Nullable.
  - `[Id <String>]`: Read-only.

FOLLOWEDSITE <IMicrosoftGraphSite1[]>: .
  - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Application <IMicrosoftGraphIdentity1>]`: identity
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
      - `[Id <String>]`: Unique identifier for the identity.
    - `[Device <IMicrosoftGraphIdentity1>]`: identity
    - `[User <IMicrosoftGraphIdentity1>]`: identity
  - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
    - `[DeletedDateTime <DateTime?>]`: 
    - `[Id <String>]`: Read-only.
    - `[AboutMe <String>]`: A freeform text entry field for the user to describe themselves. Returned only on $select.
    - `[AccountEnabled <Boolean?>]`: true if the account is enabled; otherwise, false. This property is required when a user is created. Supports $filter (eq, ne, NOT, and in).
    - `[AgeGroup <String>]`: Sets the age group of the user. Allowed values: null, minor, notAdult and adult. Refer to the legal age group property definitions for further information. Supports $filter (eq, ne, NOT, and in).
    - `[AppRoleAssignment <IMicrosoftGraphAppRoleAssignment1[]>]`: Represents the app roles a user has been granted for an application. Supports $expand.
      - `[DeletedDateTime <DateTime?>]`: 
      - `[Id <String>]`: Read-only.
      - `[AppRoleId <String>]`: The identifier (id) for the app role which is assigned to the principal. This app role must be exposed in the appRoles property on the resource application's service principal (resourceId). If the resource application has not declared any app roles, a default app role ID of 00000000-0000-0000-0000-000000000000 can be specified to signal that the principal is assigned to the resource app without any specific app roles. Required on create.
      - `[CreatedDateTime <DateTime?>]`: The time when the app role assignment was created.The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
      - `[PrincipalDisplayName <String>]`: The display name of the user, group, or service principal that was granted the app role assignment. Read-only. Supports $filter (eq and startswith).
      - `[PrincipalId <String>]`: The unique identifier (id) for the user, group or service principal being granted the app role. Required on create.
      - `[PrincipalType <String>]`: The type of the assigned principal. This can either be User, Group or ServicePrincipal. Read-only.
      - `[ResourceDisplayName <String>]`: The display name of the resource app's service principal to which the assignment is made.
      - `[ResourceId <String>]`: The unique identifier (id) for the resource service principal for which the assignment is made. Required on create. Supports $filter (eq only).
    - `[AssignedLicense <IMicrosoftGraphAssignedLicense1[]>]`: The licenses that are assigned to the user, including inherited (group-based) licenses. Not nullable. Supports $filter (eq and NOT).
      - `[DisabledPlan <String[]>]`: A collection of the unique identifiers for plans that have been disabled.
      - `[SkuId <String>]`: The unique identifier for the SKU.
    - `[Authentication <IMicrosoftGraphAuthentication>]`: authentication
      - `[Id <String>]`: Read-only.
      - `[Fido2Method <IMicrosoftGraphFido2AuthenticationMethod1[]>]`: 
        - `[Id <String>]`: Read-only.
        - `[AaGuid <String>]`: Authenticator Attestation GUID, an identifier that indicates the type (e.g. make and model) of the authenticator.
        - `[AttestationCertificate <String[]>]`: The attestation certificate(s) attached to this security key.
        - `[AttestationLevel <String>]`: attestationLevel
        - `[CreatedDateTime <DateTime?>]`: The timestamp when this key was registered to the user.
        - `[DisplayName <String>]`: The display name of the key as given by the user.
        - `[Model <String>]`: The manufacturer-assigned model of the FIDO2 security key.
      - `[Method <IMicrosoftGraphAuthenticationMethod1[]>]`: 
        - `[Id <String>]`: Read-only.
      - `[MicrosoftAuthenticatorMethod <IMicrosoftGraphMicrosoftAuthenticatorAuthenticationMethod1[]>]`: 
        - `[Id <String>]`: Read-only.
        - `[CreatedDateTime <DateTime?>]`: The date and time that this app was registered. This property is null if the device is not registered for passwordless Phone Sign-In.
        - `[Device <IMicrosoftGraphDevice1>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DeletedDateTime <DateTime?>]`: 
          - `[Id <String>]`: Read-only.
          - `[AccountEnabled <Boolean?>]`: true if the account is enabled; otherwise, false. Default is true. Supports $filter (eq, ne, NOT, in).
          - `[AlternativeSecurityId <IMicrosoftGraphAlternativeSecurityId1[]>]`: For internal use only. Not nullable. Supports $filter (eq, NOT, ge, le).
            - `[IdentityProvider <String>]`: For internal use only
            - `[Key <Byte[]>]`: For internal use only
            - `[Type <Int32?>]`: For internal use only
          - `[ApproximateLastSignInDateTime <DateTime?>]`: The timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only. Supports $filter (eq, ne, NOT, ge, le) and $orderBy.
          - `[ComplianceExpirationDateTime <DateTime?>]`: The timestamp when the device is no longer deemed compliant. The timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
          - `[DeviceId <String>]`: Identifier set by Azure Device Registration Service at the time of registration. Supports $filter (eq, ne, NOT, startsWith).
          - `[DeviceMetadata <String>]`: For internal use only. Set to null.
          - `[DeviceVersion <Int32?>]`: For internal use only.
          - `[DisplayName <String>]`: The display name for the device. Required. Supports $filter (eq, ne, NOT, ge, le, in, startsWith), $search, and $orderBy.
          - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the device. Read-only. Nullable.
            - `[Id <String>]`: Read-only.
          - `[IsCompliant <Boolean?>]`: true if the device complies with Mobile Device Management (MDM) policies; otherwise, false. Read-only. This can only be updated by Intune for any device OS type or by an approved MDM app for Windows OS devices. Supports $filter (eq, ne, NOT).
          - `[IsManaged <Boolean?>]`: true if the device is managed by a Mobile Device Management (MDM) app; otherwise, false. This can only be updated by Intune for any device OS type or by an approved MDM app for Windows OS devices. Supports $filter (eq, ne, NOT).
          - `[MdmAppId <String>]`: Application identifier used to register device into MDM. Read-only. Supports $filter (eq, ne, NOT, startsWith).
          - `[MemberOf <IMicrosoftGraphDirectoryObject[]>]`: Groups that this device is a member of. Read-only. Nullable. Supports $expand.
            - `[Id <String>]`: Read-only.
            - `[DeletedDateTime <DateTime?>]`: 
          - `[OnPremisesLastSyncDateTime <DateTime?>]`: The last time at which the object was synced with the on-premises directory. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z Read-only. Supports $filter (eq, ne, NOT, ge, le, in).
          - `[OnPremisesSyncEnabled <Boolean?>]`: true if this object is synced from an on-premises directory; false if this object was originally synced from an on-premises directory but is no longer synced; null if this object has never been synced from an on-premises directory (default). Read-only. Supports $filter (eq, ne, NOT, in).
          - `[OperatingSystem <String>]`: The type of operating system on the device. Required. Supports $filter (eq, ne, NOT, ge, le, startsWith).
          - `[OperatingSystemVersion <String>]`: Operating system version of the device. Required. Supports $filter (eq, ne, NOT, ge, le, startsWith).
          - `[PhysicalId <String[]>]`: For internal use only. Not nullable. Supports $filter (eq, NOT, ge, le, startsWith).
          - `[ProfileType <String>]`: The profile type of the device. Possible values: RegisteredDevice (default), SecureVM, Printer, Shared, IoT.
          - `[RegisteredOwner <IMicrosoftGraphDirectoryObject[]>]`: The user that cloud joined the device or registered their personal device. The registered owner is set at the time of registration. Currently, there can be only one owner. Read-only. Nullable. Supports $expand.
          - `[RegisteredUser <IMicrosoftGraphDirectoryObject[]>]`: Collection of registered users of the device. For cloud joined devices and registered personal devices, registered users are set to the same value as registered owners at the time of registration. Read-only. Nullable. Supports $expand.
          - `[SystemLabel <String[]>]`: List of labels applied to the device by the system.
          - `[TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>]`: Groups that this device is a member of. This operation is transitive. Supports $expand.
          - `[TrustType <String>]`: Type of trust for the joined device. Read-only. Possible values: Workplace (indicates bring your own personal devices), AzureAd (Cloud only joined devices), ServerAd (on-premises domain joined devices joined to Azure AD). For more details, see Introduction to device management in Azure Active Directory
        - `[DeviceTag <String>]`: Tags containing app metadata.
        - `[DisplayName <String>]`: The name of the device on which this app is registered.
        - `[PhoneAppVersion <String>]`: Numerical version of this instance of the Authenticator app.
      - `[WindowsHelloForBusinessMethod <IMicrosoftGraphWindowsHelloForBusinessAuthenticationMethod1[]>]`: 
        - `[Id <String>]`: Read-only.
        - `[CreatedDateTime <DateTime?>]`: The date and time that this Windows Hello for Business key was registered.
        - `[Device <IMicrosoftGraphDevice1>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
        - `[DisplayName <String>]`: The name of the device on which Windows Hello for Business is registered
        - `[KeyStrength <String>]`: authenticationMethodKeyStrength
    - `[Birthday <DateTime?>]`: The birthday of the user. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z Returned only on $select.
    - `[Calendar <IMicrosoftGraphCalendar1>]`: calendar
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[AllowedOnlineMeetingProvider <String[]>]`: Represent the online meeting service providers that can be used to create online meetings in this calendar. Possible values are: unknown, skypeForBusiness, skypeForConsumer, teamsForBusiness.
      - `[CalendarPermission <IMicrosoftGraphCalendarPermission1[]>]`: The permissions of the users with whom the calendar is shared.
        - `[Id <String>]`: Read-only.
        - `[AllowedRole <String[]>]`: List of allowed sharing or delegating permission levels for the calendar. Possible values are: none, freeBusyRead, limitedRead, read, write, delegateWithoutPrivateEventAccess, delegateWithPrivateEventAccess, custom.
        - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Address <String>]`: The email address of an entity instance.
          - `[Name <String>]`: The display name of an entity instance.
        - `[IsInsideOrganization <Boolean?>]`: True if the user in context (sharee or delegate) is inside the same organization as the calendar owner.
        - `[IsRemovable <Boolean?>]`: True if the user can be removed from the list of sharees or delegates for the specified calendar, false otherwise. The 'My organization' user determines the permissions other people within your organization have to the given calendar. You cannot remove 'My organization' as a sharee to a calendar.
        - `[Role <String>]`: calendarRoleType
      - `[CalendarView <IMicrosoftGraphEvent1[]>]`: The calendar view for the calendar. Navigation property. Read-only.
        - `[Category <String[]>]`: The categories associated with the item
        - `[ChangeKey <String>]`: Identifies the version of the item. Every time the item is changed, changeKey changes as well. This allows Exchange to apply changes to the correct version of the object. Read-only.
        - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[Id <String>]`: Read-only.
        - `[AllowNewTimeProposal <Boolean?>]`: True if the meeting organizer allows invitees to propose a new time when responding, false otherwise. Optional. Default is true.
        - `[Attachment <IMicrosoftGraphAttachment1[]>]`: The collection of FileAttachment, ItemAttachment, and referenceAttachment attachments for the event. Navigation property. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[ContentType <String>]`: The MIME type.
          - `[IsInline <Boolean?>]`: true if the attachment is an inline attachment; otherwise, false.
          - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
          - `[Name <String>]`: The display name of the attachment. This does not need to be the actual file name.
          - `[Size <Int32?>]`: The length of the attachment in bytes.
        - `[Attendee <IMicrosoftGraphAttendee1[]>]`: The collection of attendees for the event.
          - `[Type <String>]`: attendeeType
          - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
          - `[ProposedNewTime <IMicrosoftGraphTimeSlot1>]`: timeSlot
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[End <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[DateTime <String>]`: A single point of time in a combined date and time representation ({date}T{time}). For example, '2019-04-16T09:00:00'.
              - `[TimeZone <String>]`: Represents a time zone, for example, 'Pacific Standard Time'. See below for possible values.
            - `[Start <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
          - `[Status <IMicrosoftGraphResponseStatus1>]`: responseStatus
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Response <String>]`: responseType
            - `[Time <DateTime?>]`: The date and time that the response was returned. It uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Content <String>]`: The content of the item.
          - `[ContentType <String>]`: bodyType
        - `[BodyPreview <String>]`: The preview of the message associated with the event. It is in text format.
        - `[Calendar <IMicrosoftGraphCalendar1>]`: calendar
        - `[End <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the event. Nullable.
        - `[HasAttachment <Boolean?>]`: Set to true if the event has attachments.
        - `[HideAttendee <Boolean?>]`: When set to true, each attendee only sees themselves in the meeting request and meeting Tracking list. Default is false.
        - `[ICalUid <String>]`: A unique identifier for an event across calendars. This ID is different for each occurrence in a recurring series. Read-only.
        - `[Importance <String>]`: importance
        - `[Instance <IMicrosoftGraphEvent1[]>]`: The occurrences of a recurring series, if the event is a series master. This property includes occurrences that are part of the recurrence pattern, and exceptions that have been modified, but does not include occurrences that have been cancelled from the series. Navigation property. Read-only. Nullable.
        - `[IsAllDay <Boolean?>]`: Set to true if the event lasts all day.
        - `[IsCancelled <Boolean?>]`: Set to true if the event has been canceled.
        - `[IsDraft <Boolean?>]`: Set to true if the user has updated the meeting in Outlook but has not sent the updates to attendees. Set to false if all changes have been sent, or if the event is an appointment without any attendees.
        - `[IsOnlineMeeting <Boolean?>]`: True if this event has online meeting information, false otherwise. Default is false. Optional.
        - `[IsOrganizer <Boolean?>]`: Set to true if the calendar owner (specified by the owner property of the calendar) is the organizer of the event (specified by the organizer property of the event). This also applies if a delegate organized the event on behalf of the owner.
        - `[IsReminderOn <Boolean?>]`: Set to true if an alert is set to remind the user of the event.
        - `[Location <IMicrosoftGraphLocation1[]>]`: The locations where the event is held or attended from. The location and locations properties always correspond with each other. If you update the location property, any prior locations in the locations collection would be removed and replaced by the new location value.
          - `[Address <IMicrosoftGraphPhysicalAddress1>]`: physicalAddress
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[City <String>]`: The city.
            - `[CountryOrRegion <String>]`: The country or region. It's a free-format string value, for example, 'United States'.
            - `[PostalCode <String>]`: The postal code.
            - `[State <String>]`: The state.
            - `[Street <String>]`: The street.
          - `[Coordinate <IMicrosoftGraphOutlookGeoCoordinates1>]`: outlookGeoCoordinates
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Accuracy <Double?>]`: The accuracy of the latitude and longitude. As an example, the accuracy can be measured in meters, such as the latitude and longitude are accurate to within 50 meters.
            - `[Altitude <Double?>]`: The altitude of the location.
            - `[AltitudeAccuracy <Double?>]`: The accuracy of the altitude.
            - `[Latitude <Double?>]`: The latitude of the location.
            - `[Longitude <Double?>]`: The longitude of the location.
          - `[DisplayName <String>]`: The name associated with the location.
          - `[LocationEmailAddress <String>]`: Optional email address of the location.
          - `[LocationType <String>]`: locationType
          - `[LocationUri <String>]`: Optional URI representing the location.
          - `[UniqueId <String>]`: For internal use only.
          - `[UniqueIdType <String>]`: locationUniqueIdType
        - `[Location1 <IMicrosoftGraphLocation1>]`: location
        - `[MultiValueExtendedProperty <IMicrosoftGraphMultiValueLegacyExtendedProperty1[]>]`: The collection of multi-value extended properties defined for the event. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[Value <String[]>]`: A collection of property values.
        - `[OnlineMeeting <IMicrosoftGraphOnlineMeetingInfo1>]`: onlineMeetingInfo
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ConferenceId <String>]`: The ID of the conference.
          - `[JoinUrl <String>]`: The external link that launches the online meeting. This is a URL that clients will launch into a browser and will redirect the user to join the meeting.
          - `[Phone <IMicrosoftGraphPhone1[]>]`: All of the phone numbers associated with this conference.
            - `[Language <String>]`: 
            - `[Number <String>]`: The phone number.
            - `[Region <String>]`: 
            - `[Type <String>]`: phoneType
          - `[QuickDial <String>]`: The pre-formatted quickdial for this call.
          - `[TollFreeNumber <String[]>]`: The toll free numbers that can be used to join the conference.
          - `[TollNumber <String>]`: The toll number that can be used to join the conference.
        - `[OnlineMeetingProvider <String>]`: onlineMeetingProviderType
        - `[OnlineMeetingUrl <String>]`: A URL for an online meeting. The property is set only when an organizer specifies an event as an online meeting such as a Skype meeting. Read-only.
        - `[Organizer <IMicrosoftGraphRecipient1>]`: recipient
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[EmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
        - `[OriginalEndTimeZone <String>]`: The end time zone that was set when the event was created. A value of tzone://Microsoft/Custom indicates that a legacy custom time zone was set in desktop Outlook.
        - `[OriginalStart <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[OriginalStartTimeZone <String>]`: The start time zone that was set when the event was created. A value of tzone://Microsoft/Custom indicates that a legacy custom time zone was set in desktop Outlook.
        - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Pattern <IMicrosoftGraphRecurrencePattern1>]`: recurrencePattern
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[DayOfMonth <Int32?>]`: The day of the month on which the event occurs. Required if type is absoluteMonthly or absoluteYearly.
            - `[DaysOfWeek <String[]>]`: A collection of the days of the week on which the event occurs. Possible values are: sunday, monday, tuesday, wednesday, thursday, friday, saturday. If type is relativeMonthly or relativeYearly, and daysOfWeek specifies more than one day, the event falls on the first day that satisfies the pattern.  Required if type is weekly, relativeMonthly, or relativeYearly.
            - `[FirstDayOfWeek <String>]`: dayOfWeek
            - `[Index <String>]`: weekIndex
            - `[Interval <Int32?>]`: The number of units between occurrences, where units can be in days, weeks, months, or years, depending on the type. Required.
            - `[Month <Int32?>]`: The month in which the event occurs.  This is a number from 1 to 12.
            - `[Type <String>]`: recurrencePatternType
          - `[Range <IMicrosoftGraphRecurrenceRange1>]`: recurrenceRange
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[EndDate <DateTime?>]`: The date to stop applying the recurrence pattern. Depending on the recurrence pattern of the event, the last occurrence of the meeting may not be this date. Required if type is endDate.
            - `[NumberOfOccurrence <Int32?>]`: The number of times to repeat the event. Required and must be positive if type is numbered.
            - `[RecurrenceTimeZone <String>]`: Time zone for the startDate and endDate properties. Optional. If not specified, the time zone of the event is used.
            - `[StartDate <DateTime?>]`: The date to start applying the recurrence pattern. The first occurrence of the meeting may be this date or later, depending on the recurrence pattern of the event. Must be the same value as the start property of the recurring event. Required.
            - `[Type <String>]`: recurrenceRangeType
        - `[ReminderMinutesBeforeStart <Int32?>]`: The number of minutes before the event start time that the reminder alert occurs.
        - `[ResponseRequested <Boolean?>]`: Default is true, which represents the organizer would like an invitee to send a response to the event.
        - `[ResponseStatus <IMicrosoftGraphResponseStatus1>]`: responseStatus
        - `[Sensitivity <String>]`: sensitivity
        - `[SeriesMasterId <String>]`: The ID for the recurring series master item, if this event is part of a recurring series.
        - `[ShowAs <String>]`: freeBusyStatus
        - `[SingleValueExtendedProperty <IMicrosoftGraphSingleValueLegacyExtendedProperty1[]>]`: The collection of single-value extended properties defined for the event. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[Value <String>]`: A property value.
        - `[Start <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[Subject <String>]`: The text of the event's subject line.
        - `[TransactionId <String>]`: A custom identifier specified by a client app for the server to avoid redundant POST operations in case of client retries to create the same event. This is useful when low network connectivity causes the client to time out before receiving a response from the server for the client's prior create-event request. After you set transactionId when creating an event, you cannot change transactionId in a subsequent update. This property is only returned in a response payload if an app has set it. Optional.
        - `[Type <String>]`: eventType
        - `[WebLink <String>]`: The URL to open the event in Outlook on the web.Outlook on the web opens the event in the browser if you are signed in to your mailbox. Otherwise, Outlook on the web prompts you to sign in.This URL cannot be accessed from within an iFrame.
      - `[CanEdit <Boolean?>]`: true if the user can write to the calendar, false otherwise. This property is true for the user who created the calendar. This property is also true for a user who has been shared a calendar and granted write access, through an Outlook client or the corresponding calendarPermission resource. Read-only.
      - `[CanShare <Boolean?>]`: true if the user has the permission to share the calendar, false otherwise. Only the user who created the calendar can share it. Read-only.
      - `[CanViewPrivateItem <Boolean?>]`: true if the user can read calendar items that have been marked private, false otherwise. This property is set through an Outlook client or the corresponding calendarPermission resource. Read-only.
      - `[ChangeKey <String>]`: Identifies the version of the calendar object. Every time the calendar is changed, changeKey changes as well. This allows Exchange to apply changes to the correct version of the object. Read-only.
      - `[Color <String>]`: calendarColor
      - `[DefaultOnlineMeetingProvider <String>]`: onlineMeetingProviderType
      - `[Event <IMicrosoftGraphEvent1[]>]`: The events in the calendar. Navigation property. Read-only.
      - `[HexColor <String>]`: The calendar color, expressed in a hex color code of three hexadecimal values, each ranging from 00 to FF and representing the red, green, or blue components of the color in the RGB color space. If the user has never explicitly set a color for the calendar, this property is  empty.
      - `[IsDefaultCalendar <Boolean?>]`: true if this is the default calendar where new events are created by default, false otherwise.
      - `[IsRemovable <Boolean?>]`: Indicates whether this user calendar can be deleted from the user mailbox.
      - `[IsTallyingResponse <Boolean?>]`: Indicates whether this user calendar supports tracking of meeting responses. Only meeting invites sent from users' primary calendars support tracking of meeting responses.
      - `[MultiValueExtendedProperty <IMicrosoftGraphMultiValueLegacyExtendedProperty1[]>]`: The collection of multi-value extended properties defined for the calendar. Read-only. Nullable.
      - `[Name <String>]`: The calendar name.
      - `[Owner <IMicrosoftGraphEmailAddress1>]`: emailAddress
      - `[SingleValueExtendedProperty <IMicrosoftGraphSingleValueLegacyExtendedProperty1[]>]`: The collection of single-value extended properties defined for the calendar. Read-only. Nullable.
    - `[Chat <IMicrosoftGraphChat[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[ChatType <String>]`: chatType
      - `[CreatedDateTime <DateTime?>]`: Date and time at which the chat was created. Read-only.
      - `[InstalledApp <IMicrosoftGraphTeamsAppInstallation1[]>]`: A collection of all the apps in the chat. Nullable.
        - `[Id <String>]`: Read-only.
        - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[AppDefinition <IMicrosoftGraphTeamsAppDefinition1[]>]`: The details for each version of the app.
            - `[Id <String>]`: Read-only.
            - `[Bot <IMicrosoftGraphTeamworkBot1>]`: teamworkBot
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[Id <String>]`: Read-only.
            - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[Description <String>]`: Verbose description of the application.
            - `[DisplayName <String>]`: The name of the app provided by the app developer.
            - `[LastModifiedDateTime <DateTime?>]`: 
            - `[PublishingState <String>]`: teamsAppPublishingState
            - `[ShortDescription <String>]`: Short description of the application.
            - `[TeamsAppId <String>]`: The ID from the Teams app manifest.
            - `[Version <String>]`: The version number of the application.
          - `[DisplayName <String>]`: The name of the catalog app provided by the app developer in the Microsoft Teams zip app package.
          - `[DistributionMethod <String>]`: teamsAppDistributionMethod
          - `[ExternalId <String>]`: The ID of the catalog provided by the app developer in the Microsoft Teams zip app package.
        - `[TeamsAppDefinition <IMicrosoftGraphTeamsAppDefinition1>]`: teamsAppDefinition
      - `[LastUpdatedDateTime <DateTime?>]`: Date and time at which the chat was renamed or list of members were last changed. Read-only.
      - `[Member <IMicrosoftGraphConversationMember1[]>]`: A collection of all the members in the chat. Nullable.
        - `[Id <String>]`: Read-only.
        - `[DisplayName <String>]`: The display name of the user.
        - `[Role <String[]>]`: The roles for that user.
        - `[VisibleHistoryStartDateTime <DateTime?>]`: The timestamp denoting how far back a conversation's history is shared with the conversation member. This property is settable only for members of a chat.
      - `[Message <IMicrosoftGraphChatMessage1[]>]`: A collection of all the messages in the chat. Nullable.
        - `[Id <String>]`: Read-only.
        - `[Attachment <IMicrosoftGraphChatMessageAttachment1[]>]`: Attached files. Attachments are currently read-only – sending attachments is not supported.
          - `[Content <String>]`: The content of the attachment. If the attachment is a rich card, set the property to the rich card object. This property and contentUrl are mutually exclusive.
          - `[ContentType <String>]`: The media type of the content attachment. It can have the following values: reference: Attachment is a link to another file. Populate the contentURL with the link to the object.Any contentTypes supported by the Bot Framework's Attachment objectapplication/vnd.microsoft.card.codesnippet: A code snippet. application/vnd.microsoft.card.announcement: An announcement header.
          - `[ContentUrl <String>]`: URL for the content of the attachment. Supported protocols: http, https, file and data.
          - `[Id <String>]`: Read-only. Unique id of the attachment.
          - `[Name <String>]`: Name of the attachment.
          - `[ThumbnailUrl <String>]`: URL to a thumbnail image that the channel can use if it supports using an alternative, smaller form of content or contentUrl. For example, if you set contentType to application/word and set contentUrl to the location of the Word document, you might include a thumbnail image that represents the document. The channel could display the thumbnail image instead of the document. When the user clicks the image, the channel would open the document.
        - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
        - `[ChannelIdentity <IMicrosoftGraphChannelIdentity1>]`: channelIdentity
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ChannelId <String>]`: The identity of the channel in which the message was posted.
          - `[TeamId <String>]`: The identity of the team in which the message was posted.
        - `[ChatId <String>]`: If the message was sent in a chat, represents the identity of the chat.
        - `[CreatedDateTime <DateTime?>]`: Timestamp of when the chat message was created.
        - `[DeletedDateTime <DateTime?>]`: Read only. Timestamp at which the chat message was deleted, or null if not deleted.
        - `[Etag <String>]`: Read-only. Version number of the chat message.
        - `[From <IMicrosoftGraphChatMessageFromIdentitySet1>]`: chatMessageFromIdentitySet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Application <IMicrosoftGraphIdentity1>]`: identity
          - `[Device <IMicrosoftGraphIdentity1>]`: identity
          - `[User <IMicrosoftGraphIdentity1>]`: identity
        - `[HostedContent <IMicrosoftGraphChatMessageHostedContent1[]>]`: Content in a message hosted by Microsoft Teams - for example, images or code snippets.
          - `[ContentByte <Byte[]>]`: Write only. Bytes for the hosted content (such as images).
          - `[ContentType <String>]`: Write only. Content type, such as image/png, image/jpg.
          - `[Id <String>]`: Read-only.
        - `[Importance <String>]`: chatMessageImportance
        - `[LastEditedDateTime <DateTime?>]`: Read only. Timestamp when edits to the chat message were made. Triggers an 'Edited' flag in the Teams UI. If no edits are made the value is null.
        - `[LastModifiedDateTime <DateTime?>]`: Read only. Timestamp when the chat message is created (initial setting) or modified, including when a reaction is added or removed.
        - `[Locale <String>]`: Locale of the chat message set by the client. Always set to en-us.
        - `[Mention <IMicrosoftGraphChatMessageMention1[]>]`: List of entities mentioned in the chat message. Currently supports user, bot, team, channel.
          - `[Id <Int32?>]`: Index of an entity being mentioned in the specified chatMessage. Matches the {index} value in the corresponding <at id='{index}'> tag in the message body.
          - `[MentionText <String>]`: String used to represent the mention. For example, a user's display name, a team name.
          - `[Mentioned <IMicrosoftGraphChatMessageMentionedIdentitySet1>]`: chatMessageMentionedIdentitySet
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Application <IMicrosoftGraphIdentity1>]`: identity
            - `[Device <IMicrosoftGraphIdentity1>]`: identity
            - `[User <IMicrosoftGraphIdentity1>]`: identity
            - `[Conversation <IMicrosoftGraphTeamworkConversationIdentity1>]`: teamworkConversationIdentity
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
              - `[Id <String>]`: Unique identifier for the identity.
              - `[ConversationIdentityType <String>]`: teamworkConversationIdentityType
        - `[MessageType <String>]`: chatMessageType
        - `[PolicyViolation <IMicrosoftGraphChatMessagePolicyViolation1>]`: chatMessagePolicyViolation
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DlpAction <String>]`: chatMessagePolicyViolationDlpActionTypes
          - `[JustificationText <String>]`: Justification text provided by the sender of the message when overriding a policy violation.
          - `[PolicyTip <IMicrosoftGraphChatMessagePolicyViolationPolicyTip1>]`: chatMessagePolicyViolationPolicyTip
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[ComplianceUrl <String>]`: The URL a user can visit to read about the data loss prevention policies for the organization. (ie, policies about what users shouldn't say in chats)
            - `[GeneralText <String>]`: Explanatory text shown to the sender of the message.
            - `[MatchedConditionDescription <String[]>]`: The list of improper data in the message that was detected by the data loss prevention app. Each DLP app defines its own conditions, examples include 'Credit Card Number' and 'Social Security Number'.
          - `[UserAction <String>]`: chatMessagePolicyViolationUserActionTypes
          - `[VerdictDetail <String>]`: chatMessagePolicyViolationVerdictDetailsTypes
        - `[Reaction <IMicrosoftGraphChatMessageReaction1[]>]`: Reactions for this chat message (for example, Like).
          - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
          - `[ReactionType <String>]`: Supported values are like, angry, sad, laugh, heart, surprised.
          - `[User <IMicrosoftGraphChatMessageReactionIdentitySet1>]`: chatMessageReactionIdentitySet
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Application <IMicrosoftGraphIdentity1>]`: identity
            - `[Device <IMicrosoftGraphIdentity1>]`: identity
            - `[User <IMicrosoftGraphIdentity1>]`: identity
        - `[Reply <IMicrosoftGraphChatMessage1[]>]`: Replies for a specified message.
        - `[ReplyToId <String>]`: Read-only. ID of the parent chat message or root chat message of the thread. (Only applies to chat messages in channels, not chats.)
        - `[Subject <String>]`: The subject of the chat message, in plaintext.
        - `[Summary <String>]`: Summary text of the chat message that could be used for push notifications and summary views or fall back views. Only applies to channel chat messages, not chat messages in a chat.
        - `[WebUrl <String>]`: Read-only. Link to the message in Microsoft Teams.
      - `[Tab <IMicrosoftGraphTeamsTab1[]>]`: 
        - `[Id <String>]`: Read-only.
        - `[Configuration <IMicrosoftGraphTeamsTabConfiguration1>]`: teamsTabConfiguration
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ContentUrl <String>]`: Url used for rendering tab contents in Teams. Required.
          - `[EntityId <String>]`: Identifier for the entity hosted by the tab provider.
          - `[RemoveUrl <String>]`: Url called by Teams client when a Tab is removed using the Teams Client.
          - `[WebsiteUrl <String>]`: Url for showing tab contents outside of Teams.
        - `[DisplayName <String>]`: Name of the tab.
        - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
        - `[WebUrl <String>]`: Deep link URL of the tab instance. Read only.
      - `[Topic <String>]`: (Optional) Subject or topic for the chat. Only available for group chats.
    - `[City <String>]`: The city in which the user is located. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[CompanyName <String>]`: The company name which the user is associated. This property can be useful for describing the company that an external user comes from. The maximum length of the company name is 64 characters.Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[ConsentProvidedForMinor <String>]`: Sets whether consent has been obtained for minors. Allowed values: null, granted, denied and notRequired. Refer to the legal age group property definitions for further information. Supports $filter (eq, ne, NOT, and in).
    - `[Country <String>]`: The country/region in which the user is located; for example, US or UK. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[Department <String>]`: The name for the department in which the user works. Maximum length is 64 characters.Supports $filter (eq, ne, NOT , ge, le, and in operators).
    - `[DeviceEnrollmentLimit <Int32?>]`: The limit on the maximum number of devices that the user is permitted to enroll. Allowed values are 5 or 1000.
    - `[DeviceManagementTroubleshootingEvent <IMicrosoftGraphDeviceManagementTroubleshootingEvent1[]>]`: The list of troubleshooting events for this user.
      - `[Id <String>]`: Read-only.
      - `[CorrelationId <String>]`: Id used for tracing the failure in the service.
      - `[EventDateTime <DateTime?>]`: Time when the event occurred .
    - `[DisplayName <String>]`: The name displayed in the address book for the user. This value is usually the combination of the user's first name, middle initial, and last name. This property is required when a user is created and it cannot be cleared during updates. Maximum length is 256 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith), $orderBy, and $search.
    - `[Drive <IMicrosoftGraphDrive1>]`: drive
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
      - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
      - `[Description <String>]`: Provides a user-visible description of the item. Optional.
      - `[ETag <String>]`: ETag for the item. Read-only.
      - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
      - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
      - `[Name <String>]`: The name of the item. Read-write.
      - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DriveId <String>]`: Unique identifier of the drive instance that contains the item. Read-only.
        - `[DriveType <String>]`: Identifies the type of drive. See [drive][] resource for values.
        - `[Id <String>]`: Unique identifier of the item in the drive. Read-only.
        - `[Name <String>]`: The name of the item being referenced. Read-only.
        - `[Path <String>]`: Path that can be used to navigate to the item. Read-only.
        - `[ShareId <String>]`: A unique identifier for a shared resource that can be accessed via the [Shares][] API.
        - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ListId <String>]`: The unique identifier (guid) for the item's list in SharePoint.
          - `[ListItemId <String>]`: An integer identifier for the item within the containing list.
          - `[ListItemUniqueId <String>]`: The unique identifier (guid) for the item within OneDrive for Business or a SharePoint site.
          - `[SiteId <String>]`: The unique identifier (guid) for the item's site collection (SPSite).
          - `[SiteUrl <String>]`: The SharePoint URL for the site that contains the item.
          - `[TenantId <String>]`: The unique identifier (guid) for the tenancy.
          - `[WebId <String>]`: The unique identifier (guid) for the item's site (SPWeb).
        - `[SiteId <String>]`: For OneDrive for Business and SharePoint, this property represents the ID of the site that contains the parent document library of the driveItem resource. The value is the same as the id property of that [site][] resource. It is an opaque string that consists of three identifiers of the site. For OneDrive, this property is not populated.
      - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
      - `[Id <String>]`: Read-only.
      - `[DriveType <String>]`: Describes the type of drive represented by this resource. OneDrive personal drives will return personal. OneDrive for Business will return business. SharePoint document libraries will return documentLibrary. Read-only.
      - `[Following <IMicrosoftGraphDriveItem1[]>]`: The list of items the user is following. Only in OneDrive for Business.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
        - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
        - `[Description <String>]`: Provides a user-visible description of the item. Optional.
        - `[ETag <String>]`: ETag for the item. Read-only.
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
        - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
        - `[Name <String>]`: The name of the item. Read-write.
        - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
        - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
        - `[Id <String>]`: Read-only.
        - `[Analytic <IMicrosoftGraphItemAnalytics1>]`: itemAnalytics
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[AllTime <IMicrosoftGraphItemActivityStat1>]`: itemActivityStat
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Id <String>]`: Read-only.
            - `[Access <IMicrosoftGraphItemActionStat1>]`: itemActionStat
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[ActionCount <Int32?>]`: The number of times the action took place. Read-only.
              - `[ActorCount <Int32?>]`: The number of distinct actors that performed the action. Read-only.
            - `[Activity <IMicrosoftGraphItemActivity1[]>]`: Exposes the itemActivities represented in this itemActivityStat resource.
              - `[Id <String>]`: Read-only.
              - `[Access <IMicrosoftGraphAccessAction>]`: accessAction
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[ActivityDateTime <DateTime?>]`: Details about when the activity took place. Read-only.
              - `[Actor <IMicrosoftGraphIdentitySet1>]`: identitySet
              - `[DriveItem <IMicrosoftGraphDriveItem1>]`: driveItem
            - `[Create <IMicrosoftGraphItemActionStat1>]`: itemActionStat
            - `[Delete <IMicrosoftGraphItemActionStat1>]`: itemActionStat
            - `[Edit <IMicrosoftGraphItemActionStat1>]`: itemActionStat
            - `[EndDateTime <DateTime?>]`: When the interval ends. Read-only.
            - `[IncompleteData <IMicrosoftGraphIncompleteData1>]`: incompleteData
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[MissingDataBeforeDateTime <DateTime?>]`: The service does not have source data before the specified time.
              - `[WasThrottled <Boolean?>]`: Some data was not recorded due to excessive activity.
            - `[IsTrending <Boolean?>]`: Indicates whether the item is 'trending.' Read-only.
            - `[Move <IMicrosoftGraphItemActionStat1>]`: itemActionStat
            - `[StartDateTime <DateTime?>]`: When the interval starts. Read-only.
          - `[ItemActivityStat <IMicrosoftGraphItemActivityStat1[]>]`: 
          - `[LastSevenDay <IMicrosoftGraphItemActivityStat1>]`: itemActivityStat
        - `[Audio <IMicrosoftGraphAudio1>]`: audio
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Album <String>]`: The title of the album for this audio file.
          - `[AlbumArtist <String>]`: The artist named on the album for the audio file.
          - `[Artist <String>]`: The performing artist for the audio file.
          - `[Bitrate <Int64?>]`: Bitrate expressed in kbps.
          - `[Composer <String>]`: The name of the composer of the audio file.
          - `[Copyright <String>]`: Copyright information for the audio file.
          - `[Disc <Int32?>]`: The number of the disc this audio file came from.
          - `[DiscCount <Int32?>]`: The total number of discs in this album.
          - `[Duration <Int64?>]`: Duration of the audio file, expressed in milliseconds
          - `[Genre <String>]`: The genre of this audio file.
          - `[HasDrm <Boolean?>]`: Indicates if the file is protected with digital rights management.
          - `[IsVariableBitrate <Boolean?>]`: Indicates if the file is encoded with a variable bitrate.
          - `[Title <String>]`: The title of the audio file.
          - `[Track <Int32?>]`: The number of the track on the original disc for this audio file.
          - `[TrackCount <Int32?>]`: The total number of tracks on the original disc for this audio file.
          - `[Year <Int32?>]`: The year the audio file was recorded.
        - `[CTag <String>]`: An eTag for the content of the item. This eTag is not changed if only the metadata is changed. Note This property is not returned if the item is a folder. Read-only.
        - `[Child <IMicrosoftGraphDriveItem1[]>]`: Collection containing Item objects for the immediate children of Item. Only items representing folders have children. Read-only. Nullable.
        - `[Content <Byte[]>]`: The content stream, if the item represents a file.
        - `[Deleted <IMicrosoftGraphDeleted1>]`: deleted
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[State <String>]`: Represents the state of the deleted item.
        - `[File <IMicrosoftGraphFile1>]`: file
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Hash <IMicrosoftGraphHashes1>]`: hashes
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Crc32Hash <String>]`: The CRC32 value of the file (if available). Read-only.
            - `[QuickXorHash <String>]`: A proprietary hash of the file that can be used to determine if the contents of the file have changed (if available). Read-only.
            - `[Sha1Hash <String>]`: SHA1 hash for the contents of the file (if available). Read-only.
            - `[Sha256Hash <String>]`: SHA256 hash for the contents of the file (if available). Read-only.
          - `[MimeType <String>]`: The MIME type for the file. This is determined by logic on the server and might not be the value provided when the file was uploaded. Read-only.
          - `[ProcessingMetadata <Boolean?>]`: 
        - `[FileSystemInfo <IMicrosoftGraphFileSystemInfo1>]`: fileSystemInfo
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[CreatedDateTime <DateTime?>]`: The UTC date and time the file was created on a client.
          - `[LastAccessedDateTime <DateTime?>]`: The UTC date and time the file was last accessed. Available for the recent file list only.
          - `[LastModifiedDateTime <DateTime?>]`: The UTC date and time the file was last modified on a client.
        - `[Folder <IMicrosoftGraphFolder1>]`: folder
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ChildCount <Int32?>]`: Number of children contained immediately within this container.
          - `[View <IMicrosoftGraphFolderView1>]`: folderView
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[SortBy <String>]`: The method by which the folder should be sorted.
            - `[SortOrder <String>]`: If true, indicates that items should be sorted in descending order. Otherwise, items should be sorted ascending.
            - `[ViewType <String>]`: The type of view that should be used to represent the folder.
        - `[Image <IMicrosoftGraphImage1>]`: image
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Height <Int32?>]`: Optional. Height of the image, in pixels. Read-only.
          - `[Width <Int32?>]`: Optional. Width of the image, in pixels. Read-only.
        - `[ListItem <IMicrosoftGraphListItem1>]`: listItem
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
          - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
          - `[Description <String>]`: Provides a user-visible description of the item. Optional.
          - `[ETag <String>]`: ETag for the item. Read-only.
          - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
          - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
          - `[Name <String>]`: The name of the item. Read-write.
          - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
          - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
          - `[Id <String>]`: Read-only.
          - `[Analytic <IMicrosoftGraphItemAnalytics1>]`: itemAnalytics
          - `[ContentType <IMicrosoftGraphContentTypeInfo1>]`: contentTypeInfo
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Id <String>]`: The id of the content type.
            - `[Name <String>]`: The name of the content type.
          - `[DriveItem <IMicrosoftGraphDriveItem1>]`: driveItem
          - `[Field <IMicrosoftGraphFieldValueSet1>]`: fieldValueSet
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Id <String>]`: Read-only.
          - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
          - `[Version <IMicrosoftGraphListItemVersion1[]>]`: The list of previous versions of the list item.
            - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[LastModifiedDateTime <DateTime?>]`: Date and time the version was last modified. Read-only.
            - `[Publication <IMicrosoftGraphPublicationFacet1>]`: publicationFacet
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[Level <String>]`: The state of publication for this document. Either published or checkout. Read-only.
              - `[VersionId <String>]`: The unique identifier for the version that is visible to the current caller. Read-only.
            - `[Id <String>]`: Read-only.
            - `[Field <IMicrosoftGraphFieldValueSet1>]`: fieldValueSet
        - `[Location <IMicrosoftGraphGeoCoordinates1>]`: geoCoordinates
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Altitude <Double?>]`: Optional. The altitude (height), in feet,  above sea level for the item. Read-only.
          - `[Latitude <Double?>]`: Optional. The latitude, in decimal, for the item. Writable on OneDrive Personal.
          - `[Longitude <Double?>]`: Optional. The longitude, in decimal, for the item. Writable on OneDrive Personal.
        - `[Package <IMicrosoftGraphPackage1>]`: package
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Type <String>]`: A string indicating the type of package. While oneNote is the only currently defined value, you should expect other package types to be returned and handle them accordingly.
        - `[PendingOperation <IMicrosoftGraphPendingOperations1>]`: pendingOperations
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[PendingContentUpdate <IMicrosoftGraphPendingContentUpdate1>]`: pendingContentUpdate
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[QueuedDateTime <DateTime?>]`: Date and time the pending binary operation was queued in UTC time. Read-only.
        - `[Permission <IMicrosoftGraphPermission1[]>]`: The set of permissions for the item. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[ExpirationDateTime <DateTime?>]`: A format of yyyy-MM-ddTHH:mm:ssZ of DateTimeOffset indicates the expiration time of the permission. DateTime.MinValue indicates there is no expiration set for this permission. Optional.
          - `[GrantedTo <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[GrantedToIdentity <IMicrosoftGraphIdentitySet1[]>]`: For link type permissions, the details of the users to whom permission was granted. Read-only.
          - `[HasPassword <Boolean?>]`: This indicates whether password is set for this permission, it's only showing in response. Optional and Read-only and for OneDrive Personal only.
          - `[InheritedFrom <IMicrosoftGraphItemReference1>]`: itemReference
          - `[Invitation <IMicrosoftGraphSharingInvitation1>]`: sharingInvitation
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Email <String>]`: The email address provided for the recipient of the sharing invitation. Read-only.
            - `[InvitedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[RedeemedBy <String>]`: 
            - `[SignInRequired <Boolean?>]`: If true the recipient of the invitation needs to sign in in order to access the shared item. Read-only.
          - `[Link <IMicrosoftGraphSharingLink1>]`: sharingLink
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Application <IMicrosoftGraphIdentity1>]`: identity
            - `[PreventsDownload <Boolean?>]`: If true then the user can only use this link to view the item on the web, and cannot use it to download the contents of the item. Only for OneDrive for Business and SharePoint.
            - `[Scope <String>]`: The scope of the link represented by this permission. Value anonymous indicates the link is usable by anyone, organization indicates the link is only usable for users signed into the same tenant.
            - `[Type <String>]`: The type of the link created.
            - `[WebHtml <String>]`: For embed links, this property contains the HTML code for an <iframe> element that will embed the item in a webpage.
            - `[WebUrl <String>]`: A URL that opens the item in the browser on the OneDrive website.
          - `[Role <String[]>]`: The type of permission, e.g. read. See below for the full list of roles. Read-only.
          - `[ShareId <String>]`: A unique token that can be used to access this shared item via the [shares API][]. Read-only.
        - `[Photo <IMicrosoftGraphPhoto1>]`: photo
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[CameraMake <String>]`: Camera manufacturer. Read-only.
          - `[CameraModel <String>]`: Camera model. Read-only.
          - `[ExposureDenominator <Double?>]`: The denominator for the exposure time fraction from the camera. Read-only.
          - `[ExposureNumerator <Double?>]`: The numerator for the exposure time fraction from the camera. Read-only.
          - `[FNumber <Double?>]`: The F-stop value from the camera. Read-only.
          - `[FocalLength <Double?>]`: The focal length from the camera. Read-only.
          - `[Iso <Int32?>]`: The ISO value from the camera. Read-only.
          - `[Orientation <Int32?>]`: The orientation value from the camera. Writable on OneDrive Personal.
          - `[TakenDateTime <DateTime?>]`: The date and time the photo was taken in UTC time. Read-only.
        - `[Publication <IMicrosoftGraphPublicationFacet1>]`: publicationFacet
        - `[RemoteItem <IMicrosoftGraphRemoteItem1>]`: remoteItem
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
          - `[File <IMicrosoftGraphFile1>]`: file
          - `[FileSystemInfo <IMicrosoftGraphFileSystemInfo1>]`: fileSystemInfo
          - `[Folder <IMicrosoftGraphFolder1>]`: folder
          - `[Id <String>]`: Unique identifier for the remote item in its drive. Read-only.
          - `[Image <IMicrosoftGraphImage1>]`: image
          - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
          - `[Name <String>]`: Optional. Filename of the remote item. Read-only.
          - `[Package <IMicrosoftGraphPackage1>]`: package
          - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
          - `[Shared <IMicrosoftGraphShared1>]`: shared
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Owner <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[Scope <String>]`: Indicates the scope of how the item is shared: anonymous, organization, or users. Read-only.
            - `[SharedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
            - `[SharedDateTime <DateTime?>]`: The UTC date and time when the item was shared. Read-only.
          - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
          - `[Size <Int64?>]`: Size of the remote item. Read-only.
          - `[SpecialFolder <IMicrosoftGraphSpecialFolder1>]`: specialFolder
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Name <String>]`: The unique identifier for this item in the /drive/special collection
          - `[Video <IMicrosoftGraphVideo1>]`: video
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[AudioBitsPerSample <Int32?>]`: Number of audio bits per sample.
            - `[AudioChannel <Int32?>]`: Number of audio channels.
            - `[AudioFormat <String>]`: Name of the audio format (AAC, MP3, etc.).
            - `[AudioSamplesPerSecond <Int32?>]`: Number of audio samples per second.
            - `[Bitrate <Int32?>]`: Bit rate of the video in bits per second.
            - `[Duration <Int64?>]`: Duration of the file in milliseconds.
            - `[FourCc <String>]`: 'Four character code' name of the video format.
            - `[FrameRate <Double?>]`: Frame rate of the video.
            - `[Height <Int32?>]`: Height of the video, in pixels.
            - `[Width <Int32?>]`: Width of the video, in pixels.
          - `[WebDavUrl <String>]`: DAV compatible URL for the item.
          - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
        - `[Root <IMicrosoftGraphRoot>]`: root
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[SearchResult <IMicrosoftGraphSearchResult1>]`: searchResult
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[OnClickTelemetryUrl <String>]`: A callback URL that can be used to record telemetry information. The application should issue a GET on this URL if the user interacts with this item to improve the quality of results.
        - `[Shared <IMicrosoftGraphShared1>]`: shared
        - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
        - `[Size <Int64?>]`: Size of the item in bytes. Read-only.
        - `[SpecialFolder <IMicrosoftGraphSpecialFolder1>]`: specialFolder
        - `[Subscription <IMicrosoftGraphSubscription1[]>]`: The set of subscriptions on the item. Only supported on the root of a drive.
          - `[Id <String>]`: Read-only.
          - `[ApplicationId <String>]`: Identifier of the application used to create the subscription. Read-only.
          - `[ChangeType <String>]`: Indicates the type of change in the subscribed resource that will raise a change notification. The supported values are: created, updated, deleted. Multiple values can be combined using a comma-separated list. Required. Note: Drive root item and list change notifications support only the updated changeType. User and group change notifications support updated and deleted changeType.
          - `[ClientState <String>]`: Specifies the value of the clientState property sent by the service in each change notification. The maximum length is 255 characters. The client can check that the change notification came from the service by comparing the value of the clientState property sent with the subscription with the value of the clientState property received with each change notification. Optional.
          - `[CreatorId <String>]`: Identifier of the user or service principal that created the subscription. If the app used delegated permissions to create the subscription, this field contains the ID of the signed-in user the app called on behalf of. If the app used application permissions, this field contains the ID of the service principal corresponding to the app. Read-only.
          - `[EncryptionCertificate <String>]`: A base64-encoded representation of a certificate with a public key used to encrypt resource data in change notifications. Optional. Required when includeResourceData is true.
          - `[EncryptionCertificateId <String>]`: A custom app-provided identifier to help identify the certificate needed to decrypt resource data. Optional. Required when includeResourceData is true.
          - `[ExpirationDateTime <DateTime?>]`: Specifies the date and time when the webhook subscription expires. The time is in UTC, and can be an amount of time from subscription creation that varies for the resource subscribed to.  See the table below for maximum supported subscription length of time. Required.
          - `[IncludeResourceData <Boolean?>]`: When set to true, change notifications include resource data (such as content of a chat message). Optional.
          - `[LatestSupportedTlsVersion <String>]`: Specifies the latest version of Transport Layer Security (TLS) that the notification endpoint, specified by notificationUrl, supports. The possible values are: v1_0, v1_1, v1_2, v1_3. For subscribers whose notification endpoint supports a version lower than the currently recommended version (TLS 1.2), specifying this property by a set timeline allows them to temporarily use their deprecated version of TLS before completing their upgrade to TLS 1.2. For these subscribers, not setting this property per the timeline would result in subscription operations failing. For subscribers whose notification endpoint already supports TLS 1.2, setting this property is optional. In such cases, Microsoft Graph defaults the property to v1_2.
          - `[LifecycleNotificationUrl <String>]`: The URL of the endpoint that receives lifecycle notifications, including subscriptionRemoved and missed notifications. This URL must make use of the HTTPS protocol. Optional. Read more about how Outlook resources use lifecycle notifications.
          - `[NotificationQueryOption <String>]`: OData Query Options for specifying value for the targeting resource. Clients receive notifications when resource reaches the state matching the query options provided here. With this new property in the subscription creation payload along with all existing properties, Webhooks will deliver notifications whenever a resource reaches the desired state mentioned in the notificationQueryOptions property eg  when the print job is completed, when a print job resource isFetchable property value becomes true etc.
          - `[NotificationUrl <String>]`: The URL of the endpoint that receives the change notifications. This URL must make use of the HTTPS protocol. Required.
          - `[Resource <String>]`: Specifies the resource that will be monitored for changes. Do not include the base URL (https://graph.microsoft.com/beta/). See the possible resource path values for each supported resource. Required.
        - `[Thumbnail <IMicrosoftGraphThumbnailSet1[]>]`: Collection containing [ThumbnailSet][] objects associated with the item. For more info, see [getting thumbnails][]. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[Large <IMicrosoftGraphThumbnail1>]`: thumbnail
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Content <Byte[]>]`: The content stream for the thumbnail.
            - `[Height <Int32?>]`: The height of the thumbnail, in pixels.
            - `[SourceItemId <String>]`: The unique identifier of the item that provided the thumbnail. This is only available when a folder thumbnail is requested.
            - `[Url <String>]`: The URL used to fetch the thumbnail content.
            - `[Width <Int32?>]`: The width of the thumbnail, in pixels.
          - `[Medium <IMicrosoftGraphThumbnail1>]`: thumbnail
          - `[Small <IMicrosoftGraphThumbnail1>]`: thumbnail
          - `[Source <IMicrosoftGraphThumbnail1>]`: thumbnail
        - `[Version <IMicrosoftGraphDriveItemVersion1[]>]`: The list of previous versions of the item. For more info, see [getting previous versions][]. Read-only. Nullable.
          - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[LastModifiedDateTime <DateTime?>]`: Date and time the version was last modified. Read-only.
          - `[Publication <IMicrosoftGraphPublicationFacet1>]`: publicationFacet
          - `[Id <String>]`: Read-only.
          - `[Content <Byte[]>]`: 
          - `[Size <Int64?>]`: Indicates the size of the content stream for this version of the item.
        - `[Video <IMicrosoftGraphVideo1>]`: video
        - `[WebDavUrl <String>]`: WebDAV compatible URL for the item.
        - `[Workbook <IMicrosoftGraphWorkbook1>]`: workbook
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[Application <IMicrosoftGraphWorkbookApplication1>]`: workbookApplication
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Id <String>]`: Read-only.
            - `[CalculationMode <String>]`: Returns the calculation mode used in the workbook. Possible values are: Automatic, AutomaticExceptTables, Manual.
          - `[Comment <IMicrosoftGraphWorkbookComment1[]>]`: 
            - `[Id <String>]`: Read-only.
            - `[Content <String>]`: The content of the comment.
            - `[ContentType <String>]`: Indicates the type for the comment.
            - `[Reply <IMicrosoftGraphWorkbookCommentReply1[]>]`: Read-only. Nullable.
              - `[Id <String>]`: Read-only.
              - `[Content <String>]`: The content of replied comment.
              - `[ContentType <String>]`: Indicates the type for the replied comment.
          - `[Function <IMicrosoftGraphWorkbookFunctions1>]`: workbookFunctions
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Id <String>]`: Read-only.
          - `[Name <IMicrosoftGraphWorkbookNamedItem1[]>]`: Represents a collection of workbooks scoped named items (named ranges and constants). Read-only.
            - `[Id <String>]`: Read-only.
            - `[Comment <String>]`: Represents the comment associated with this name.
            - `[Name <String>]`: The name of the object. Read-only.
            - `[Scope <String>]`: Indicates whether the name is scoped to the workbook or to a specific worksheet. Read-only.
            - `[Type <String>]`: Indicates what type of reference is associated with the name. Possible values are: String, Integer, Double, Boolean, Range. Read-only.
            - `[Value <IMicrosoftGraphJson>]`: Json
            - `[Visible <Boolean?>]`: Specifies whether the object is visible or not.
            - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[Id <String>]`: Read-only.
              - `[Chart <IMicrosoftGraphWorkbookChart1[]>]`: Returns collection of charts that are part of the worksheet. Read-only.
                - `[Id <String>]`: Read-only.
                - `[Axis <IMicrosoftGraphWorkbookChartAxes1>]`: workbookChartAxes
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[CategoryAxis <IMicrosoftGraphWorkbookChartAxis1>]`: workbookChartAxis
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Format <IMicrosoftGraphWorkbookChartAxisFormat1>]`: workbookChartAxisFormat
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Id <String>]`: Read-only.
                      - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Id <String>]`: Read-only.
                        - `[Bold <Boolean?>]`: Represents the bold status of font.
                        - `[Color <String>]`: HTML color code representation of the text color. E.g. #FF0000 represents Red.
                        - `[Italic <Boolean?>]`: Represents the italic status of the font.
                        - `[Name <String>]`: Font name (e.g. 'Calibri')
                        - `[Size <Double?>]`: Size of the font (e.g. 11)
                        - `[Underline <String>]`: Type of underline applied to the font. The possible values are: None, Single.
                      - `[Line <IMicrosoftGraphWorkbookChartLineFormat1>]`: workbookChartLineFormat
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Id <String>]`: Read-only.
                        - `[Color <String>]`: HTML color code representing the color of lines in the chart.
                    - `[MajorGridline <IMicrosoftGraphWorkbookChartGridlines1>]`: workbookChartGridlines
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Id <String>]`: Read-only.
                      - `[Format <IMicrosoftGraphWorkbookChartGridlinesFormat1>]`: workbookChartGridlinesFormat
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Id <String>]`: Read-only.
                        - `[Line <IMicrosoftGraphWorkbookChartLineFormat1>]`: workbookChartLineFormat
                      - `[Visible <Boolean?>]`: Boolean value representing if the axis gridlines are visible or not.
                    - `[MajorUnit <IMicrosoftGraphJson>]`: Json
                    - `[Maximum <IMicrosoftGraphJson>]`: Json
                    - `[Minimum <IMicrosoftGraphJson>]`: Json
                    - `[MinorGridline <IMicrosoftGraphWorkbookChartGridlines1>]`: workbookChartGridlines
                    - `[MinorUnit <IMicrosoftGraphJson>]`: Json
                    - `[Title <IMicrosoftGraphWorkbookChartAxisTitle1>]`: workbookChartAxisTitle
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Id <String>]`: Read-only.
                      - `[Format <IMicrosoftGraphWorkbookChartAxisTitleFormat1>]`: workbookChartAxisTitleFormat
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Id <String>]`: Read-only.
                        - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                      - `[Text <String>]`: Represents the axis title.
                      - `[Visible <Boolean?>]`: A boolean that specifies the visibility of an axis title.
                  - `[SeriesAxis <IMicrosoftGraphWorkbookChartAxis1>]`: workbookChartAxis
                  - `[ValueAxis <IMicrosoftGraphWorkbookChartAxis1>]`: workbookChartAxis
                - `[DataLabel <IMicrosoftGraphWorkbookChartDataLabels1>]`: workbookChartDataLabels
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Format <IMicrosoftGraphWorkbookChartDataLabelFormat1>]`: workbookChartDataLabelFormat
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Id <String>]`: Read-only.
                    - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                  - `[Position <String>]`: DataLabelPosition value that represents the position of the data label. The possible values are: None, Center, InsideEnd, InsideBase, OutsideEnd, Left, Right, Top, Bottom, BestFit, Callout.
                  - `[Separator <String>]`: String representing the separator used for the data labels on a chart.
                  - `[ShowBubbleSize <Boolean?>]`: Boolean value representing if the data label bubble size is visible or not.
                  - `[ShowCategoryName <Boolean?>]`: Boolean value representing if the data label category name is visible or not.
                  - `[ShowLegendKey <Boolean?>]`: Boolean value representing if the data label legend key is visible or not.
                  - `[ShowPercentage <Boolean?>]`: Boolean value representing if the data label percentage is visible or not.
                  - `[ShowSeriesName <Boolean?>]`: Boolean value representing if the data label series name is visible or not.
                  - `[ShowValue <Boolean?>]`: Boolean value representing if the data label value is visible or not.
                - `[Format <IMicrosoftGraphWorkbookChartAreaFormat1>]`: workbookChartAreaFormat
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                  - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                - `[Height <Double?>]`: Represents the height, in points, of the chart object.
                - `[Left <Double?>]`: The distance, in points, from the left side of the chart to the worksheet origin.
                - `[Legend <IMicrosoftGraphWorkbookChartLegend1>]`: workbookChartLegend
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Format <IMicrosoftGraphWorkbookChartLegendFormat1>]`: workbookChartLegendFormat
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                    - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                  - `[Overlay <Boolean?>]`: Boolean value for whether the chart legend should overlap with the main body of the chart.
                  - `[Position <String>]`: Represents the position of the legend on the chart. The possible values are: Top, Bottom, Left, Right, Corner, Custom.
                  - `[Visible <Boolean?>]`: A boolean value the represents the visibility of a ChartLegend object.
                - `[Name <String>]`: Represents the name of a chart object.
                - `[Series <IMicrosoftGraphWorkbookChartSeries1[]>]`: Represents either a single series or collection of series in the chart. Read-only.
                  - `[Id <String>]`: Read-only.
                  - `[Format <IMicrosoftGraphWorkbookChartSeriesFormat1>]`: workbookChartSeriesFormat
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                    - `[Line <IMicrosoftGraphWorkbookChartLineFormat1>]`: workbookChartLineFormat
                  - `[Name <String>]`: Represents the name of a series in a chart.
                  - `[Point <IMicrosoftGraphWorkbookChartPoint1[]>]`: Represents a collection of all points in the series. Read-only.
                    - `[Id <String>]`: Read-only.
                    - `[Format <IMicrosoftGraphWorkbookChartPointFormat1>]`: workbookChartPointFormat
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Id <String>]`: Read-only.
                      - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                    - `[Value <IMicrosoftGraphJson>]`: Json
                - `[Title <IMicrosoftGraphWorkbookChartTitle1>]`: workbookChartTitle
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Format <IMicrosoftGraphWorkbookChartTitleFormat1>]`: workbookChartTitleFormat
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Fill <IMicrosoftGraphWorkbookChartFill1>]`: workbookChartFill
                    - `[Font <IMicrosoftGraphWorkbookChartFont1>]`: workbookChartFont
                  - `[Overlay <Boolean?>]`: Boolean value representing if the chart title will overlay the chart or not.
                  - `[Text <String>]`: Represents the title text of a chart.
                  - `[Visible <Boolean?>]`: A boolean value the represents the visibility of a chart title object.
                - `[Top <Double?>]`: Represents the distance, in points, from the top edge of the object to the top of row 1 (on a worksheet) or the top of the chart area (on a chart).
                - `[Width <Double?>]`: Represents the width, in points, of the chart object.
                - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
              - `[Name <String>]`: The display name of the worksheet.
              - `[Names <IMicrosoftGraphWorkbookNamedItem1[]>]`: Returns collection of names that are associated with the worksheet. Read-only.
              - `[PivotTable <IMicrosoftGraphWorkbookPivotTable1[]>]`: Collection of PivotTables that are part of the worksheet.
                - `[Id <String>]`: Read-only.
                - `[Name <String>]`: Name of the PivotTable.
                - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
              - `[Position <Int32?>]`: The zero-based position of the worksheet within the workbook.
              - `[Protection <IMicrosoftGraphWorkbookWorksheetProtection1>]`: workbookWorksheetProtection
                - `[(Any) <Object>]`: This indicates any property can be added to this object.
                - `[Id <String>]`: Read-only.
                - `[Option <IMicrosoftGraphWorkbookWorksheetProtectionOptions1>]`: workbookWorksheetProtectionOptions
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[AllowAutoFilter <Boolean?>]`: Represents the worksheet protection option of allowing using auto filter feature.
                  - `[AllowDeleteColumn <Boolean?>]`: Represents the worksheet protection option of allowing deleting columns.
                  - `[AllowDeleteRow <Boolean?>]`: Represents the worksheet protection option of allowing deleting rows.
                  - `[AllowFormatCell <Boolean?>]`: Represents the worksheet protection option of allowing formatting cells.
                  - `[AllowFormatColumn <Boolean?>]`: Represents the worksheet protection option of allowing formatting columns.
                  - `[AllowFormatRow <Boolean?>]`: Represents the worksheet protection option of allowing formatting rows.
                  - `[AllowInsertColumn <Boolean?>]`: Represents the worksheet protection option of allowing inserting columns.
                  - `[AllowInsertHyperlink <Boolean?>]`: Represents the worksheet protection option of allowing inserting hyperlinks.
                  - `[AllowInsertRow <Boolean?>]`: Represents the worksheet protection option of allowing inserting rows.
                  - `[AllowPivotTable <Boolean?>]`: Represents the worksheet protection option of allowing using pivot table feature.
                  - `[AllowSort <Boolean?>]`: Represents the worksheet protection option of allowing using sort feature.
                - `[Protected <Boolean?>]`: Indicates if the worksheet is protected.  Read-only.
              - `[Table <IMicrosoftGraphWorkbookTable1[]>]`: Collection of tables that are part of the worksheet. Read-only.
                - `[Id <String>]`: Read-only.
                - `[Column <IMicrosoftGraphWorkbookTableColumn1[]>]`: Represents a collection of all the columns in the table. Read-only.
                  - `[Id <String>]`: Read-only.
                  - `[Filter <IMicrosoftGraphWorkbookFilter1>]`: workbookFilter
                    - `[(Any) <Object>]`: This indicates any property can be added to this object.
                    - `[Id <String>]`: Read-only.
                    - `[Criterion <IMicrosoftGraphWorkbookFilterCriteria1>]`: workbookFilterCriteria
                      - `[(Any) <Object>]`: This indicates any property can be added to this object.
                      - `[Color <String>]`: 
                      - `[Criterion1 <String>]`: 
                      - `[Criterion2 <String>]`: 
                      - `[DynamicCriterion <String>]`: 
                      - `[FilterOn <String>]`: 
                      - `[Icon <IMicrosoftGraphWorkbookIcon1>]`: workbookIcon
                        - `[(Any) <Object>]`: This indicates any property can be added to this object.
                        - `[Index <Int32?>]`: Represents the index of the icon in the given set.
                        - `[Set <String>]`: Represents the set that the icon is part of. Possible values are: Invalid, ThreeArrows, ThreeArrowsGray, ThreeFlags, ThreeTrafficLights1, ThreeTrafficLights2, ThreeSigns, ThreeSymbols, ThreeSymbols2, FourArrows, FourArrowsGray, FourRedToBlack, FourRating, FourTrafficLights, FiveArrows, FiveArrowsGray, FiveRating, FiveQuarters, ThreeStars, ThreeTriangles, FiveBoxes.
                      - `[Operator <String>]`: 
                      - `[Value <IMicrosoftGraphJson>]`: Json
                  - `[Index <Int32?>]`: Returns the index number of the column within the columns collection of the table. Zero-indexed. Read-only.
                  - `[Name <String>]`: Returns the name of the table column.
                  - `[Value <IMicrosoftGraphJson>]`: Json
                - `[HighlightFirstColumn <Boolean?>]`: Indicates whether the first column contains special formatting.
                - `[HighlightLastColumn <Boolean?>]`: Indicates whether the last column contains special formatting.
                - `[LegacyId <String>]`: Legacy Id used in older Excle clients. The value of the identifier remains the same even when the table is renamed. This property should be interpreted as an opaque string value and should not be parsed to any other type. Read-only.
                - `[Name <String>]`: Name of the table.
                - `[Row <IMicrosoftGraphWorkbookTableRow1[]>]`: Represents a collection of all the rows in the table. Read-only.
                  - `[Id <String>]`: Read-only.
                  - `[Index <Int32?>]`: Returns the index number of the row within the rows collection of the table. Zero-indexed. Read-only.
                  - `[Value <IMicrosoftGraphJson>]`: Json
                - `[ShowBandedColumn <Boolean?>]`: Indicates whether the columns show banded formatting in which odd columns are highlighted differently from even ones to make reading the table easier.
                - `[ShowBandedRow <Boolean?>]`: Indicates whether the rows show banded formatting in which odd rows are highlighted differently from even ones to make reading the table easier.
                - `[ShowFilterButton <Boolean?>]`: Indicates whether the filter buttons are visible at the top of each column header. Setting this is only allowed if the table contains a header row.
                - `[ShowHeader <Boolean?>]`: Indicates whether the header row is visible or not. This value can be set to show or remove the header row.
                - `[ShowTotal <Boolean?>]`: Indicates whether the total row is visible or not. This value can be set to show or remove the total row.
                - `[Sort <IMicrosoftGraphWorkbookTableSort1>]`: workbookTableSort
                  - `[(Any) <Object>]`: This indicates any property can be added to this object.
                  - `[Id <String>]`: Read-only.
                  - `[Field <IMicrosoftGraphWorkbookSortField1[]>]`: Represents the current conditions used to last sort the table. Read-only.
                    - `[Ascending <Boolean?>]`: Represents whether the sorting is done in an ascending fashion.
                    - `[Color <String>]`: Represents the color that is the target of the condition if the sorting is on font or cell color.
                    - `[DataOption <String>]`: Represents additional sorting options for this field. Possible values are: Normal, TextAsNumber.
                    - `[Icon <IMicrosoftGraphWorkbookIcon1>]`: workbookIcon
                    - `[Key <Int32?>]`: Represents the column (or row, depending on the sort orientation) that the condition is on. Represented as an offset from the first column (or row).
                    - `[SortOn <String>]`: Represents the type of sorting of this condition. Possible values are: Value, CellColor, FontColor, Icon.
                  - `[MatchCase <Boolean?>]`: Represents whether the casing impacted the last sort of the table. Read-only.
                  - `[Method <String>]`: Represents Chinese character ordering method last used to sort the table. Possible values are: PinYin, StrokeCount. Read-only.
                - `[Style <String>]`: Constant value that represents the Table style. Possible values are: TableStyleLight1 thru TableStyleLight21, TableStyleMedium1 thru TableStyleMedium28, TableStyleStyleDark1 thru TableStyleStyleDark11. A custom user-defined style present in the workbook can also be specified.
                - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1>]`: workbookWorksheet
              - `[Visibility <String>]`: The Visibility of the worksheet. The possible values are: Visible, Hidden, VeryHidden.
          - `[Operation <IMicrosoftGraphWorkbookOperation1[]>]`: The status of Workbook operations. Getting an operation collection is not supported, but you can get the status of a long-running operation if the Location header is returned in the response. Read-only. Nullable.
            - `[Id <String>]`: Read-only.
            - `[Error <IMicrosoftGraphWorkbookOperationError1>]`: workbookOperationError
              - `[(Any) <Object>]`: This indicates any property can be added to this object.
              - `[Code <String>]`: The error code.
              - `[InnerError <IMicrosoftGraphWorkbookOperationError1>]`: workbookOperationError
              - `[Message <String>]`: The error message.
            - `[ResourceLocation <String>]`: The resource URI for the result.
            - `[Status <String>]`: workbookOperationStatus
          - `[Table <IMicrosoftGraphWorkbookTable1[]>]`: Represents a collection of tables associated with the workbook. Read-only.
          - `[Worksheet <IMicrosoftGraphWorkbookWorksheet1[]>]`: Represents a collection of worksheets associated with the workbook. Read-only.
      - `[Items <IMicrosoftGraphDriveItem1[]>]`: All items contained in the drive. Read-only. Nullable.
      - `[List <IMicrosoftGraphList1>]`: list
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
        - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
        - `[Description <String>]`: Provides a user-visible description of the item. Optional.
        - `[ETag <String>]`: ETag for the item. Read-only.
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
        - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
        - `[Name <String>]`: The name of the item. Read-write.
        - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
        - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
        - `[Id <String>]`: Read-only.
        - `[Column <IMicrosoftGraphColumnDefinition1[]>]`: The collection of field definitions for this list.
          - `[Id <String>]`: Read-only.
          - `[Boolean <IMicrosoftGraphBooleanColumn>]`: booleanColumn
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Calculated <IMicrosoftGraphCalculatedColumn1>]`: calculatedColumn
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Format <String>]`: For dateTime output types, the format of the value. Must be one of dateOnly or dateTime.
            - `[Formula <String>]`: The formula used to compute the value for this column.
            - `[OutputType <String>]`: The output type used to format values in this column. Must be one of boolean, currency, dateTime, number, or text.
          - `[Choice <IMicrosoftGraphChoiceColumn1>]`: choiceColumn
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[AllowTextEntry <Boolean?>]`: If true, allows custom values that aren't in the configured choices.
            - `[Choice <String[]>]`: The list of values available for this column.
            - `[DisplayAs <String>]`: How the choices are to be presented in the UX. Must be one of checkBoxes, dropDownMenu, or radioButtons
          - `[ColumnGroup <String>]`: For site columns, the name of the group this column belongs to. Helps organize related columns.
          - `[Currency <IMicrosoftGraphCurrencyColumn1>]`: currencyColumn
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Locale <String>]`: Specifies the locale from which to infer the currency symbol.
          - `[DateTime <IMicrosoftGraphDateTimeColumn1>]`: dateTimeColumn
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[DisplayAs <String>]`: How the value should be presented in the UX. Must be one of default, friendly, or standard. See below for more details. If unspecified, treated as default.
            - `[Format <String>]`: Indicates whether the value should be presented as a date only or a date and time. Must be one of dateOnly or dateTime
          - `[DefaultValue <IMicrosoftGraphDefaultColumnValue1>]`: defaultColumnValue
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Formula <String>]`: The formula used to compute the default value for this column.
            - `[Value <String>]`: The direct value to use as the default value for this column.
          - `[Description <String>]`: The user-facing description of the column.
          - `[DisplayName <String>]`: The user-facing name of the column.
          - `[EnforceUniqueValue <Boolean?>]`: If true, no two list items may have the same value for this column.
          - `[Geolocation <IMicrosoftGraphGeolocationColumn>]`: geolocationColumn
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Hidden <Boolean?>]`: Specifies whether the column is displayed in the user interface.
          - `[Indexed <Boolean?>]`: Specifies whether the column values can used for sorting and searching.
          - `[Lookup <IMicrosoftGraphLookupColumn1>]`: lookupColumn
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[AllowMultipleValue <Boolean?>]`: Indicates whether multiple values can be selected from the source.
            - `[AllowUnlimitedLength <Boolean?>]`: Indicates whether values in the column should be able to exceed the standard limit of 255 characters.
            - `[ColumnName <String>]`: The name of the lookup source column.
            - `[ListId <String>]`: The unique identifier of the lookup source list.
            - `[PrimaryLookupColumnId <String>]`: If specified, this column is a secondary lookup, pulling an additional field from the list item looked up by the primary lookup. Use the list item looked up by the primary as the source for the column named here.
          - `[Name <String>]`: The API-facing name of the column as it appears in the [fields][] on a [listItem][]. For the user-facing name, see displayName.
          - `[Number <IMicrosoftGraphNumberColumn1>]`: numberColumn
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[DecimalPlace <String>]`: How many decimal places to display. See below for information about the possible values.
            - `[DisplayAs <String>]`: How the value should be presented in the UX. Must be one of number or percentage. If unspecified, treated as number.
            - `[Maximum <Double?>]`: The maximum permitted value.
            - `[Minimum <Double?>]`: The minimum permitted value.
          - `[PersonOrGroup <IMicrosoftGraphPersonOrGroupColumn1>]`: personOrGroupColumn
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[AllowMultipleSelection <Boolean?>]`: Indicates whether multiple values can be selected from the source.
            - `[ChooseFromType <String>]`: Whether to allow selection of people only, or people and groups. Must be one of peopleAndGroups or peopleOnly.
            - `[DisplayAs <String>]`: How to display the information about the person or group chosen. See below.
          - `[ReadOnly <Boolean?>]`: Specifies whether the column values can be modified.
          - `[Required <Boolean?>]`: Specifies whether the column value is not optional.
          - `[Text <IMicrosoftGraphTextColumn1>]`: textColumn
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[AllowMultipleLine <Boolean?>]`: Whether to allow multiple lines of text.
            - `[AppendChangesToExistingText <Boolean?>]`: Whether updates to this column should replace existing text, or append to it.
            - `[LinesForEditing <Int32?>]`: The size of the text box.
            - `[MaxLength <Int32?>]`: The maximum number of characters for the value.
            - `[TextType <String>]`: The type of text being stored. Must be one of plain or richText
        - `[ContentType <IMicrosoftGraphContentType1[]>]`: The collection of content types present in this list.
          - `[Id <String>]`: Read-only.
          - `[ColumnLink <IMicrosoftGraphColumnLink1[]>]`: The collection of columns that are required by this content type
            - `[Id <String>]`: Read-only.
            - `[Name <String>]`: The name of the column  in this content type.
          - `[Description <String>]`: The descriptive text for the item.
          - `[Group <String>]`: The name of the group this content type belongs to. Helps organize related content types.
          - `[Hidden <Boolean?>]`: Indicates whether the content type is hidden in the list's 'New' menu.
          - `[InheritedFrom <IMicrosoftGraphItemReference1>]`: itemReference
          - `[Name <String>]`: The name of the content type.
          - `[Order <IMicrosoftGraphContentTypeOrder1>]`: contentTypeOrder
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Default <Boolean?>]`: Whether this is the default Content Type
            - `[Position <Int32?>]`: Specifies the position in which the Content Type appears in the selection UI.
          - `[ParentId <String>]`: The unique identifier of the content type.
          - `[ReadOnly <Boolean?>]`: If true, the content type cannot be modified unless this value is first set to false.
          - `[Sealed <Boolean?>]`: If true, the content type cannot be modified by users or through push-down operations. Only site collection administrators can seal or unseal content types.
        - `[DisplayName <String>]`: The displayable title of the list.
        - `[Drive <IMicrosoftGraphDrive1>]`: drive
        - `[Items <IMicrosoftGraphListItem1[]>]`: All items contained in the list.
        - `[List <IMicrosoftGraphListInfo1>]`: listInfo
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ContentTypesEnabled <Boolean?>]`: If true, indicates that content types are enabled for this list.
          - `[Hidden <Boolean?>]`: If true, indicates that the list is not normally visible in the SharePoint user experience.
          - `[Template <String>]`: An enumerated value that represents the base list template used in creating the list. Possible values include documentLibrary, genericList, task, survey, announcements, contacts, and more.
        - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
        - `[Subscription <IMicrosoftGraphSubscription1[]>]`: The set of subscriptions on the list.
        - `[System <IMicrosoftGraphSystemFacet>]`: systemFacet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Owner <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[Quota <IMicrosoftGraphQuota1>]`: quota
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Deleted <Int64?>]`: Total space consumed by files in the recycle bin, in bytes. Read-only.
        - `[Remaining <Int64?>]`: Total space remaining before reaching the quota limit, in bytes. Read-only.
        - `[State <String>]`: Enumeration value that indicates the state of the storage space. Read-only.
        - `[StoragePlanInformation <IMicrosoftGraphStoragePlanInformation1>]`: storagePlanInformation
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[UpgradeAvailable <Boolean?>]`: Indicates if there are higher storage quota plans available. Read-only.
        - `[Total <Int64?>]`: Total allowed storage space, in bytes. Read-only.
        - `[Used <Int64?>]`: Total space used, in bytes. Read-only.
      - `[Root <IMicrosoftGraphDriveItem1>]`: driveItem
      - `[SharePointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
      - `[Special <IMicrosoftGraphDriveItem1[]>]`: Collection of common folders available in OneDrive. Read-only. Nullable.
      - `[System <IMicrosoftGraphSystemFacet>]`: systemFacet
    - `[EmployeeHireDate <DateTime?>]`: The date and time when the user was hired or will start work in case of a future hire. Supports $filter (eq, ne, NOT , ge, le, in).
    - `[EmployeeId <String>]`: The employee identifier assigned to the user by the organization. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
    - `[EmployeeOrgData <IMicrosoftGraphEmployeeOrgData1>]`: employeeOrgData
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[CostCenter <String>]`: The cost center associated with the user. Returned only on $select. Supports $filter.
      - `[Division <String>]`: The name of the division in which the user works. Returned only on $select. Supports $filter.
    - `[EmployeeType <String>]`: Captures enterprise worker type. For example, Employee, Contractor, Consultant, or Vendor. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
    - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the user. Nullable.
    - `[ExternalUserState <String>]`: For an external user invited to the tenant using the invitation API, this property represents the invited user's invitation status. For invited users, the state can be PendingAcceptance or Accepted, or null for all other users. Supports $filter (eq, ne, NOT , in).
    - `[ExternalUserStateChangeDateTime <DateTime?>]`: Shows the timestamp for the latest change to the externalUserState property. Supports $filter (eq, ne, NOT , in).
    - `[FaxNumber <String>]`: The fax number of the user. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
    - `[FollowedSite <IMicrosoftGraphSite1[]>]`: 
    - `[GivenName <String>]`: The given name (first name) of the user. Maximum length is 64 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
    - `[HireDate <DateTime?>]`: The hire date of the user. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.  Returned only on $select.  Note: This property is specific to SharePoint Online. We recommend using the native employeeHireDate property to set and update hire date values using Microsoft Graph APIs.
    - `[Identity <IMicrosoftGraphObjectIdentity1[]>]`: Represents the identities that can be used to sign in to this user account. An identity can be provided by Microsoft (also known as a local account), by organizations, or by social identity providers such as Facebook, Google, and Microsoft, and tied to a user account. May contain multiple items with the same signInType value. Supports $filter (eq) only where the signInType is not userPrincipalName.
      - `[Issuer <String>]`: Specifies the issuer of the identity, for example facebook.com.For local accounts (where signInType is not federated), this property is the local B2C tenant default domain name, for example contoso.onmicrosoft.com.For external users from other Azure AD organization, this will be the domain of the federated organization, for example contoso.com.Supports $filter. 512 character limit.
      - `[IssuerAssignedId <String>]`: Specifies the unique identifier assigned to the user by the issuer. The combination of issuer and issuerAssignedId must be unique within the organization. Represents the sign-in name for the user, when signInType is set to emailAddress or userName (also known as local accounts).When signInType is set to: emailAddress, (or a custom string that starts with emailAddress like emailAddress1) issuerAssignedId must be a valid email addressuserName, issuerAssignedId must be a valid local part of an email addressSupports $filter. 100 character limit.
      - `[SignInType <String>]`: Specifies the user sign-in types in your directory, such as emailAddress, userName or federated. Here, federated represents a unique identifier for a user from an issuer, that can be in any format chosen by the issuer. Additional validation is enforced on issuerAssignedId when the sign-in type is set to emailAddress or userName. This property can also be set to any custom string.
    - `[InferenceClassification <IMicrosoftGraphInferenceClassification1>]`: inferenceClassification
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[Override <IMicrosoftGraphInferenceClassificationOverride1[]>]`: A set of overrides for a user to always classify messages from specific senders in certain ways: focused, or other. Read-only. Nullable.
        - `[Id <String>]`: Read-only.
        - `[ClassifyAs <String>]`: inferenceClassificationType
        - `[SenderEmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
    - `[Insight <IMicrosoftGraphOfficeGraphInsights1>]`: officeGraphInsights
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[Shared <IMicrosoftGraphSharedInsight1[]>]`: Access this property from the derived type itemInsights.
        - `[Id <String>]`: Read-only.
        - `[LastShared <IMicrosoftGraphSharingDetail1>]`: sharingDetail
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[SharedBy <IMicrosoftGraphInsightIdentity1>]`: insightIdentity
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Address <String>]`: The email address of the user who shared the item.
            - `[DisplayName <String>]`: The display name of the user who shared the item.
            - `[Id <String>]`: The id of the user who shared the item.
          - `[SharedDateTime <DateTime?>]`: The date and time the file was last shared. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
          - `[SharingReference <IMicrosoftGraphResourceReference1>]`: resourceReference
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[Id <String>]`: The item's unique identifier.
            - `[Type <String>]`: A string value that can be used to classify the item, such as 'microsoft.graph.driveItem'
            - `[WebUrl <String>]`: A URL leading to the referenced item.
          - `[SharingSubject <String>]`: The subject with which the document was shared.
          - `[SharingType <String>]`: Determines the way the document was shared, can be by a 'Link', 'Attachment', 'Group', 'Site'.
        - `[LastSharedMethodId <String>]`: Read-only.
        - `[ResourceId <String>]`: Read-only.
        - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
        - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ContainerDisplayName <String>]`: A string describing where the item is stored. For example, the name of a SharePoint site or the user name identifying the owner of the OneDrive storing the item.
          - `[ContainerType <String>]`: Can be used for filtering by the type of container in which the file is stored. Such as Site or OneDriveBusiness.
          - `[ContainerWebUrl <String>]`: A path leading to the folder in which the item is stored.
          - `[MediaType <String>]`: The item's media type. Can be used for filtering for a specific type of file based on supported IANA Media Mime Types. Note that not all Media Mime Types are supported.
          - `[PreviewImageUrl <String>]`: A URL leading to the preview image for the item.
          - `[PreviewText <String>]`: A preview text for the item.
          - `[Title <String>]`: The item's title text.
          - `[Type <String>]`: The item's media type. Can be used for filtering for a specific file based on a specific type. See below for supported types.
        - `[SharingHistory <IMicrosoftGraphSharingDetail1[]>]`: 
      - `[Trending <IMicrosoftGraphTrending1[]>]`: Access this property from the derived type itemInsights.
        - `[Id <String>]`: Read-only.
        - `[LastModifiedDateTime <DateTime?>]`: 
        - `[ResourceId <String>]`: Read-only.
        - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
        - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
        - `[Weight <Double?>]`: Value indicating how much the document is currently trending. The larger the number, the more the document is currently trending around the user (the more relevant it is). Returned documents are sorted by this value.
      - `[Used <IMicrosoftGraphUsedInsight1[]>]`: Access this property from the derived type itemInsights.
        - `[Id <String>]`: Read-only.
        - `[LastUsed <IMicrosoftGraphUsageDetails1>]`: usageDetails
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[LastAccessedDateTime <DateTime?>]`: The date and time the resource was last accessed by the user. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
          - `[LastModifiedDateTime <DateTime?>]`: The date and time the resource was last modified by the user. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
        - `[ResourceId <String>]`: Read-only.
        - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
        - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
    - `[Interest <String[]>]`: A list for the user to describe their interests. Returned only on $select.
    - `[IsResourceAccount <Boolean?>]`: Do not use – reserved for future use.
    - `[JobTitle <String>]`: The user's job title. Maximum length is 128 characters. Supports $filter (eq, ne, NOT , ge, le, in, startsWith).
    - `[Mail <String>]`: The SMTP address for the user, for example, admin@contoso.com. Changes to this property will also update the user's proxyAddresses collection to include the value as an SMTP address. While this property can contain accent characters, using them can cause access issues with other Microsoft applications for the user. Supports $filter (eq, ne, NOT, ge, le, in, startsWith, endsWith).
    - `[MailNickname <String>]`: The mail alias for the user. This property must be specified when a user is created. Maximum length is 64 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[MailboxSetting <IMicrosoftGraphMailboxSettings1>]`: mailboxSettings
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ArchiveFolder <String>]`: Folder ID of an archive folder for the user. Read only.
      - `[AutomaticRepliesSetting <IMicrosoftGraphAutomaticRepliesSetting1>]`: automaticRepliesSetting
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ExternalAudience <String>]`: externalAudienceScope
        - `[ExternalReplyMessage <String>]`: The automatic reply to send to the specified external audience, if Status is AlwaysEnabled or Scheduled.
        - `[InternalReplyMessage <String>]`: The automatic reply to send to the audience internal to the signed-in user's organization, if Status is AlwaysEnabled or Scheduled.
        - `[ScheduledEndDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[ScheduledStartDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[Status <String>]`: automaticRepliesStatus
      - `[DateFormat <String>]`: The date format for the user's mailbox.
      - `[DelegateMeetingMessageDeliveryOption <String>]`: delegateMeetingMessageDeliveryOptions
      - `[Language <IMicrosoftGraphLocaleInfo1>]`: localeInfo
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DisplayName <String>]`: A name representing the user's locale in natural language, for example, 'English (United States)'.
        - `[Locale <String>]`: A locale representation for the user, which includes the user's preferred language and country/region. For example, 'en-us'. The language component follows 2-letter codes as defined in ISO 639-1, and the country component follows 2-letter codes as defined in ISO 3166-1 alpha-2.
      - `[TimeFormat <String>]`: The time format for the user's mailbox.
      - `[TimeZone <String>]`: The default time zone for the user's mailbox.
      - `[WorkingHour <IMicrosoftGraphWorkingHours1>]`: workingHours
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DaysOfWeek <String[]>]`: The days of the week on which the user works.
        - `[EndTime <String>]`: The time of the day that the user stops working.
        - `[StartTime <String>]`: The time of the day that the user starts working.
        - `[TimeZone <IMicrosoftGraphTimeZoneBase1>]`: timeZoneBase
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Name <String>]`: The name of a time zone. It can be a standard time zone name such as 'Hawaii-Aleutian Standard Time', or 'Customized Time Zone' for a custom time zone.
    - `[ManagedAppRegistration <IMicrosoftGraphManagedAppRegistration1[]>]`: Zero or more managed app registrations that belong to the user.
      - `[Id <String>]`: Read-only.
      - `[AppIdentifier <IMicrosoftGraphMobileAppIdentifier>]`: The identifier for a mobile app.
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ApplicationVersion <String>]`: App version
      - `[AppliedPolicy <IMicrosoftGraphManagedAppPolicy1[]>]`: Zero or more policys already applied on the registered app when it last synchronized with managment service.
        - `[Id <String>]`: Read-only.
        - `[CreatedDateTime <DateTime?>]`: The date and time the policy was created.
        - `[Description <String>]`: The policy's description.
        - `[DisplayName <String>]`: Policy display name.
        - `[LastModifiedDateTime <DateTime?>]`: Last time the policy was modified.
        - `[Version <String>]`: Version of the entity.
      - `[CreatedDateTime <DateTime?>]`: Date and time of creation
      - `[DeviceName <String>]`: Host device name
      - `[DeviceTag <String>]`: App management SDK generated tag, which helps relate apps hosted on the same device. Not guaranteed to relate apps in all conditions.
      - `[DeviceType <String>]`: Host device type
      - `[FlaggedReason <String[]>]`: Zero or more reasons an app registration is flagged. E.g. app running on rooted device
      - `[IntendedPolicy <IMicrosoftGraphManagedAppPolicy1[]>]`: Zero or more policies admin intended for the app as of now.
      - `[LastSyncDateTime <DateTime?>]`: Date and time of last the app synced with management service.
      - `[ManagementSdkVersion <String>]`: App management SDK version
      - `[Operation <IMicrosoftGraphManagedAppOperation1[]>]`: Zero or more long running operations triggered on the app registration.
        - `[Id <String>]`: Read-only.
        - `[DisplayName <String>]`: The operation name.
        - `[LastModifiedDateTime <DateTime?>]`: The last time the app operation was modified.
        - `[State <String>]`: The current state of the operation
        - `[Version <String>]`: Version of the entity.
      - `[PlatformVersion <String>]`: Operating System version
      - `[UserId <String>]`: The user Id to who this app registration belongs.
      - `[Version <String>]`: Version of the entity.
    - `[ManagedDevice <IMicrosoftGraphManagedDevice1[]>]`: The managed devices associated with the user.
      - `[Id <String>]`: Read-only.
      - `[ActivationLockBypassCode <String>]`: Code that allows the Activation Lock on a device to be bypassed. This property is read-only.
      - `[AndroidSecurityPatchLevel <String>]`: Android security patch level. This property is read-only.
      - `[AzureAdDeviceId <String>]`: The unique identifier for the Azure Active Directory device. Read only. This property is read-only.
      - `[AzureAdRegistered <Boolean?>]`: Whether the device is Azure Active Directory registered. This property is read-only.
      - `[ComplianceGracePeriodExpirationDateTime <DateTime?>]`: The DateTime when device compliance grace period expires. This property is read-only.
      - `[ComplianceState <String>]`: complianceState
      - `[ConfigurationManagerClientEnabledFeature <IMicrosoftGraphConfigurationManagerClientEnabledFeatures1>]`: configuration Manager client enabled features
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[CompliancePolicy <Boolean?>]`: Whether compliance policy is managed by Intune
        - `[DeviceConfiguration <Boolean?>]`: Whether device configuration is managed by Intune
        - `[Inventory <Boolean?>]`: Whether inventory is managed by Intune
        - `[ModernApp <Boolean?>]`: Whether modern application is managed by Intune
        - `[ResourceAccess <Boolean?>]`: Whether resource access is managed by Intune
        - `[WindowsUpdateForBusiness <Boolean?>]`: Whether Windows Update for Business is managed by Intune
      - `[DeviceActionResult <IMicrosoftGraphDeviceActionResult1[]>]`: List of ComplexType deviceActionResult objects. This property is read-only.
        - `[ActionName <String>]`: Action name
        - `[ActionState <String>]`: actionState
        - `[LastUpdatedDateTime <DateTime?>]`: Time the action state was last updated
        - `[StartDateTime <DateTime?>]`: Time the action was initiated
      - `[DeviceCategory <IMicrosoftGraphDeviceCategory1>]`: Device categories provides a way to organize your devices. Using device categories, company administrators can define their own categories that make sense to their company. These categories can then be applied to a device in the Intune Azure console or selected by a user during device enrollment. You can filter reports and create dynamic Azure Active Directory device groups based on device categories.
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Id <String>]`: Read-only.
        - `[Description <String>]`: Optional description for the device category.
        - `[DisplayName <String>]`: Display name for the device category.
      - `[DeviceCategoryDisplayName <String>]`: Device category display name. This property is read-only.
      - `[DeviceCompliancePolicyState <IMicrosoftGraphDeviceCompliancePolicyState1[]>]`: Device compliance policy states for this device.
        - `[Id <String>]`: Read-only.
        - `[DisplayName <String>]`: The name of the policy for this policyBase
        - `[PlatformType <String>]`: policyPlatformType
        - `[SettingCount <Int32?>]`: Count of how many setting a policy holds
        - `[SettingState <IMicrosoftGraphDeviceCompliancePolicySettingState1[]>]`: 
          - `[CurrentValue <String>]`: Current value of setting on device
          - `[ErrorCode <Int64?>]`: Error code for the setting
          - `[ErrorDescription <String>]`: Error description
          - `[InstanceDisplayName <String>]`: Name of setting instance that is being reported.
          - `[Setting <String>]`: The setting that is being reported
          - `[SettingName <String>]`: Localized/user friendly setting name that is being reported
          - `[Source <IMicrosoftGraphSettingSource1[]>]`: Contributing policies
            - `[DisplayName <String>]`: Not yet documented
            - `[Id <String>]`: Not yet documented
          - `[State <String>]`: complianceStatus
          - `[UserEmail <String>]`: UserEmail
          - `[UserId <String>]`: UserId
          - `[UserName <String>]`: UserName
          - `[UserPrincipalName <String>]`: UserPrincipalName.
        - `[State <String>]`: complianceStatus
        - `[Version <Int32?>]`: The version of the policy
      - `[DeviceConfigurationState <IMicrosoftGraphDeviceConfigurationState1[]>]`: Device configuration states for this device.
        - `[Id <String>]`: Read-only.
        - `[DisplayName <String>]`: The name of the policy for this policyBase
        - `[PlatformType <String>]`: policyPlatformType
        - `[SettingCount <Int32?>]`: Count of how many setting a policy holds
        - `[SettingState <IMicrosoftGraphDeviceConfigurationSettingState1[]>]`: 
          - `[CurrentValue <String>]`: Current value of setting on device
          - `[ErrorCode <Int64?>]`: Error code for the setting
          - `[ErrorDescription <String>]`: Error description
          - `[InstanceDisplayName <String>]`: Name of setting instance that is being reported.
          - `[Setting <String>]`: The setting that is being reported
          - `[SettingName <String>]`: Localized/user friendly setting name that is being reported
          - `[Source <IMicrosoftGraphSettingSource1[]>]`: Contributing policies
          - `[State <String>]`: complianceStatus
          - `[UserEmail <String>]`: UserEmail
          - `[UserId <String>]`: UserId
          - `[UserName <String>]`: UserName
          - `[UserPrincipalName <String>]`: UserPrincipalName.
        - `[State <String>]`: complianceStatus
        - `[Version <Int32?>]`: The version of the policy
      - `[DeviceEnrollmentType <String>]`: deviceEnrollmentType
      - `[DeviceHealthAttestationState <IMicrosoftGraphDeviceHealthAttestationState1>]`: deviceHealthAttestationState
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[AttestationIdentityKey <String>]`: TWhen an Attestation Identity Key (AIK) is present on a device, it indicates that the device has an endorsement key (EK) certificate.
        - `[BitLockerStatus <String>]`: On or Off of BitLocker Drive Encryption
        - `[BootAppSecurityVersion <String>]`: The security version number of the Boot Application
        - `[BootDebugging <String>]`: When bootDebugging is enabled, the device is used in development and testing
        - `[BootManagerSecurityVersion <String>]`: The security version number of the Boot Application
        - `[BootManagerVersion <String>]`: The version of the Boot Manager
        - `[BootRevisionListInfo <String>]`: The Boot Revision List that was loaded during initial boot on the attested device
        - `[CodeIntegrity <String>]`: When code integrity is enabled, code execution is restricted to integrity verified code
        - `[CodeIntegrityCheckVersion <String>]`: The version of the Boot Manager
        - `[CodeIntegrityPolicy <String>]`: The Code Integrity policy that is controlling the security of the boot environment
        - `[ContentNamespaceUrl <String>]`: The DHA report version. (Namespace version)
        - `[ContentVersion <String>]`: The HealthAttestation state schema version
        - `[DataExcutionPolicy <String>]`: DEP Policy defines a set of hardware and software technologies that perform additional checks on memory
        - `[DeviceHealthAttestationStatus <String>]`: The DHA report version. (Namespace version)
        - `[EarlyLaunchAntiMalwareDriverProtection <String>]`: ELAM provides protection for the computers in your network when they start up
        - `[HealthAttestationSupportedStatus <String>]`: This attribute indicates if DHA is supported for the device
        - `[HealthStatusMismatchInfo <String>]`: This attribute appears if DHA-Service detects an integrity issue
        - `[IssuedDateTime <DateTime?>]`: The DateTime when device was evaluated or issued to MDM
        - `[LastUpdateDateTime <String>]`: The Timestamp of the last update.
        - `[OperatingSystemKernelDebugging <String>]`: When operatingSystemKernelDebugging is enabled, the device is used in development and testing
        - `[OperatingSystemRevListInfo <String>]`: The Operating System Revision List that was loaded during initial boot on the attested device
        - `[Pcr0 <String>]`: The measurement that is captured in PCR[0]
        - `[PcrHashAlgorithm <String>]`: Informational attribute that identifies the HASH algorithm that was used by TPM
        - `[ResetCount <Int64?>]`: The number of times a PC device has hibernated or resumed
        - `[RestartCount <Int64?>]`: The number of times a PC device has rebooted
        - `[SafeMode <String>]`: Safe mode is a troubleshooting option for Windows that starts your computer in a limited state
        - `[SecureBoot <String>]`: When Secure Boot is enabled, the core components must have the correct cryptographic signatures
        - `[SecureBootConfigurationPolicyFingerPrint <String>]`: Fingerprint of the Custom Secure Boot Configuration Policy
        - `[TestSigning <String>]`: When test signing is allowed, the device does not enforce signature validation during boot
        - `[TpmVersion <String>]`: The security version number of the Boot Application
        - `[VirtualSecureMode <String>]`: VSM is a container that protects high value assets from a compromised kernel
        - `[WindowsPe <String>]`: Operating system running with limited services that is used to prepare a computer for Windows
      - `[DeviceName <String>]`: Name of the device. This property is read-only.
      - `[DeviceRegistrationState <String>]`: deviceRegistrationState
      - `[EasActivated <Boolean?>]`: Whether the device is Exchange ActiveSync activated. This property is read-only.
      - `[EasActivationDateTime <DateTime?>]`: Exchange ActivationSync activation time of the device. This property is read-only.
      - `[EasDeviceId <String>]`: Exchange ActiveSync Id of the device. This property is read-only.
      - `[EmailAddress <String>]`: Email(s) for the user associated with the device. This property is read-only.
      - `[EnrolledDateTime <DateTime?>]`: Enrollment time of the device. This property is read-only.
      - `[EthernetMacAddress <String>]`: Ethernet MAC. This property is read-only.
      - `[ExchangeAccessState <String>]`: deviceManagementExchangeAccessState
      - `[ExchangeAccessStateReason <String>]`: deviceManagementExchangeAccessStateReason
      - `[ExchangeLastSuccessfulSyncDateTime <DateTime?>]`: Last time the device contacted Exchange. This property is read-only.
      - `[FreeStorageSpaceInByte <Int64?>]`: Free Storage in Bytes. This property is read-only.
      - `[Iccid <String>]`: Integrated Circuit Card Identifier, it is A SIM card's unique identification number. This property is read-only.
      - `[Imei <String>]`: IMEI. This property is read-only.
      - `[IsEncrypted <Boolean?>]`: Device encryption status. This property is read-only.
      - `[IsSupervised <Boolean?>]`: Device supervised status. This property is read-only.
      - `[JailBroken <String>]`: whether the device is jail broken or rooted. This property is read-only.
      - `[LastSyncDateTime <DateTime?>]`: The date and time that the device last completed a successful sync with Intune. This property is read-only.
      - `[ManagedDeviceName <String>]`: Automatically generated name to identify a device. Can be overwritten to a user friendly name.
      - `[ManagedDeviceOwnerType <String>]`: managedDeviceOwnerType
      - `[ManagementAgent <String>]`: managementAgentType
      - `[Manufacturer <String>]`: Manufacturer of the device. This property is read-only.
      - `[Meid <String>]`: MEID. This property is read-only.
      - `[Model <String>]`: Model of the device. This property is read-only.
      - `[Note <String>]`: Notes on the device created by IT Admin
      - `[OSVersion <String>]`: Operating system version of the device. This property is read-only.
      - `[OperatingSystem <String>]`: Operating system of the device. Windows, iOS, etc. This property is read-only.
      - `[PartnerReportedThreatState <String>]`: managedDevicePartnerReportedHealthState
      - `[PhoneNumber <String>]`: Phone number of the device. This property is read-only.
      - `[PhysicalMemoryInByte <Int64?>]`: Total Memory in Bytes. This property is read-only.
      - `[RemoteAssistanceSessionErrorDetail <String>]`: An error string that identifies issues when creating Remote Assistance session objects. This property is read-only.
      - `[RemoteAssistanceSessionUrl <String>]`: Url that allows a Remote Assistance session to be established with the device. This property is read-only.
      - `[SerialNumber <String>]`: SerialNumber. This property is read-only.
      - `[SubscriberCarrier <String>]`: Subscriber Carrier. This property is read-only.
      - `[TotalStorageSpaceInByte <Int64?>]`: Total Storage in Bytes. This property is read-only.
      - `[Udid <String>]`: Unique Device Identifier for iOS and macOS devices. This property is read-only.
      - `[UserDisplayName <String>]`: User display name. This property is read-only.
      - `[UserId <String>]`: Unique Identifier for the user associated with the device. This property is read-only.
      - `[UserPrincipalName <String>]`: Device user principal name. This property is read-only.
      - `[WiFiMacAddress <String>]`: Wi-Fi MAC. This property is read-only.
    - `[Manager <IMicrosoftGraphDirectoryObject>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
    - `[MobilePhone <String>]`: The primary cellular telephone number for the user. Read-only for users synced from on-premises directory.  Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[MySite <String>]`: The URL for the user's personal site. Returned only on $select.
    - `[Oauth2PermissionGrant <IMicrosoftGraphOAuth2PermissionGrant1[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[ClientId <String>]`: The id of the client service principal for the application which is authorized to act on behalf of a signed-in user when accessing an API. Required. Supports $filter (eq only).
      - `[ConsentType <String>]`: Indicates whether authorization is granted for the client application to impersonate all users or only a specific user. AllPrincipals indicates authorization to impersonate all users. Principal indicates authorization to impersonate a specific user. Consent on behalf of all users can be granted by an administrator. Non-admin users may be authorized to consent on behalf of themselves in some cases, for some delegated permissions. Required. Supports $filter (eq only).
      - `[PrincipalId <String>]`: The id of the user on behalf of whom the client is authorized to access the resource, when consentType is Principal. If consentType is AllPrincipals this value is null. Required when consentType is Principal.
      - `[ResourceId <String>]`: The id of the resource service principal to which access is authorized. This identifies the API which the client is authorized to attempt to call on behalf of a signed-in user.
      - `[Scope <String>]`: A space-separated list of the claim values for delegated permissions which should be included in access tokens for the resource application (the API). For example, openid User.Read GroupMember.Read.All. Each claim value should match the value field of one of the delegated permissions defined by the API, listed in the publishedPermissionScopes property of the resource service principal.
    - `[OfficeLocation <String>]`: The office location in the user's place of business. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[OnPremisesExtensionAttribute <IMicrosoftGraphOnPremisesExtensionAttributes1>]`: onPremisesExtensionAttributes
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ExtensionAttribute1 <String>]`: First customizable extension attribute.
      - `[ExtensionAttribute10 <String>]`: Tenth customizable extension attribute.
      - `[ExtensionAttribute11 <String>]`: Eleventh customizable extension attribute.
      - `[ExtensionAttribute12 <String>]`: Twelfth customizable extension attribute.
      - `[ExtensionAttribute13 <String>]`: Thirteenth customizable extension attribute.
      - `[ExtensionAttribute14 <String>]`: Fourteenth customizable extension attribute.
      - `[ExtensionAttribute15 <String>]`: Fifteenth customizable extension attribute.
      - `[ExtensionAttribute2 <String>]`: Second customizable extension attribute.
      - `[ExtensionAttribute3 <String>]`: Third customizable extension attribute.
      - `[ExtensionAttribute4 <String>]`: Fourth customizable extension attribute.
      - `[ExtensionAttribute5 <String>]`: Fifth customizable extension attribute.
      - `[ExtensionAttribute6 <String>]`: Sixth customizable extension attribute.
      - `[ExtensionAttribute7 <String>]`: Seventh customizable extension attribute.
      - `[ExtensionAttribute8 <String>]`: Eighth customizable extension attribute.
      - `[ExtensionAttribute9 <String>]`: Ninth customizable extension attribute.
    - `[OnPremisesImmutableId <String>]`: This property is used to associate an on-premises Active Directory user account to their Azure AD user object. This property must be specified when creating a new user account in the Graph if you are using a federated domain for the user's userPrincipalName (UPN) property. Note: The $ and _ characters cannot be used when specifying this property. Supports $filter (eq, ne, NOT, ge, le, in).
    - `[OnPremisesProvisioningError <IMicrosoftGraphOnPremisesProvisioningError1[]>]`: Errors when using Microsoft synchronization product during provisioning.  Supports $filter (eq, NOT, ge, le).
    - `[Onenote <IMicrosoftGraphOnenote1>]`: onenote
    - `[OnlineMeeting <IMicrosoftGraphOnlineMeeting1[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[AllowAttendeeToEnableCamera <Boolean?>]`: Indicates whether attendees can turn on their camera.
      - `[AllowAttendeeToEnableMic <Boolean?>]`: Indicates whether attendees can turn on their microphone.
      - `[AllowMeetingChat <String>]`: meetingChatMode
      - `[AllowTeamworkReaction <Boolean?>]`: Indicates if Teams reactions are enabled for the meeting.
      - `[AllowedPresenter <String>]`: onlineMeetingPresenters
      - `[AudioConferencing <IMicrosoftGraphAudioConferencing1>]`: audioConferencing
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ConferenceId <String>]`: The conference id of the online meeting.
        - `[DialinUrl <String>]`: A URL to the externally-accessible web page that contains dial-in information.
        - `[TollFreeNumber <String>]`: The toll-free number that connects to the Audio Conference Provider.
        - `[TollNumber <String>]`: The toll number that connects to the Audio Conference Provider.
      - `[ChatInfo <IMicrosoftGraphChatInfo1>]`: chatInfo
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[MessageId <String>]`: The unique identifier for a message in a Microsoft Teams channel.
        - `[ReplyChainMessageId <String>]`: The ID of the reply message.
        - `[ThreadId <String>]`: The unique identifier for a thread in Microsoft Teams.
      - `[CreationDateTime <DateTime?>]`: The meeting creation time in UTC. Read-only.
      - `[EndDateTime <DateTime?>]`: The meeting end time in UTC.
      - `[ExternalId <String>]`: The external ID. A custom ID. Optional.
      - `[IsEntryExitAnnounced <Boolean?>]`: Indicates whether to announce when callers join or leave.
      - `[JoinInformation <IMicrosoftGraphItemBody1>]`: itemBody
      - `[JoinWebUrl <String>]`: The join URL of the online meeting. Read-only.
      - `[LobbyBypassSetting <IMicrosoftGraphLobbyBypassSettings1>]`: lobbyBypassSettings
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[IsDialInBypassEnabled <Boolean?>]`: Specifies whether or not to always let dial-in callers bypass the lobby. Optional.
        - `[Scope <String>]`: lobbyBypassScope
      - `[Participant <IMicrosoftGraphMeetingParticipants1>]`: meetingParticipants
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Attendee <IMicrosoftGraphMeetingParticipantInfo1[]>]`: Information of the meeting attendees.
          - `[Identity <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[Role <String>]`: onlineMeetingRole
          - `[Upn <String>]`: User principal name of the participant.
        - `[Organizer <IMicrosoftGraphMeetingParticipantInfo1>]`: meetingParticipantInfo
      - `[StartDateTime <DateTime?>]`: The meeting start time in UTC.
      - `[Subject <String>]`: The subject of the online meeting.
      - `[VideoTeleconferenceId <String>]`: The video teleconferencing ID. Read-only.
    - `[OtherMail <String[]>]`: A list of additional email addresses for the user; for example: ['bob@contoso.com', 'Robert@fabrikam.com'].NOTE: While this property can contain accent characters, they can cause access issues to first-party applications for the user.Supports $filter (eq, NOT, ge, le, in, startsWith).
    - `[Outlook <IMicrosoftGraphOutlookUser1>]`: outlookUser
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[MasterCategory <IMicrosoftGraphOutlookCategory1[]>]`: A list of categories defined for the user.
        - `[Id <String>]`: Read-only.
        - `[Color <String>]`: categoryColor
        - `[DisplayName <String>]`: A unique name that identifies a category in the user's mailbox. After a category is created, the name cannot be changed. Read-only.
    - `[PasswordPolicy <String>]`: Specifies password policies for the user. This value is an enumeration with one possible value being DisableStrongPassword, which allows weaker passwords than the default policy to be specified. DisablePasswordExpiration can also be specified. The two may be specified together; for example: DisablePasswordExpiration, DisableStrongPassword.Supports $filter (ne, NOT).
    - `[PasswordProfile <IMicrosoftGraphPasswordProfile1>]`: passwordProfile
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ForceChangePasswordNextSignIn <Boolean?>]`: true if the user must change her password on the next login; otherwise false. If not set, default is false. NOTE:  For Azure B2C tenants, set to false and instead use custom policies and user flows to force password reset at first sign in. See Force password reset at first logon.
      - `[ForceChangePasswordNextSignInWithMfa <Boolean?>]`: If true, at next sign-in, the user must perform a multi-factor authentication (MFA) before being forced to change their password. The behavior is identical to forceChangePasswordNextSignIn except that the user is required to first perform a multi-factor authentication before password change. After a password change, this property will be automatically reset to false. If not set, default is false.
      - `[Password <String>]`: The password for the user. This property is required when a user is created. It can be updated, but the user will be required to change the password on the next login. The password must satisfy minimum requirements as specified by the user’s passwordPolicies property. By default, a strong password is required.
    - `[PastProject <String[]>]`: A list for the user to enumerate their past projects. Returned only on $select.
    - `[Photo <IMicrosoftGraphProfilePhoto1>]`: profilePhoto
    - `[Planner <IMicrosoftGraphPlannerUser1>]`: plannerUser
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[Plan <IMicrosoftGraphPlannerPlan1[]>]`: Read-only. Nullable. Returns the plannerTasks assigned to the user.
      - `[Task <IMicrosoftGraphPlannerTask1[]>]`: Read-only. Nullable. Returns the plannerTasks assigned to the user.
    - `[PostalCode <String>]`: The postal code for the user's postal address. The postal code is specific to the user's country/region. In the United States of America, this attribute contains the ZIP code. Maximum length is 40 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[PreferredLanguage <String>]`: The preferred language for the user. Should follow ISO 639-1 Code; for example en-US. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[PreferredName <String>]`: The preferred name for the user. Returned only on $select.
    - `[Presence <IMicrosoftGraphPresence>]`: presence
      - `[Id <String>]`: Read-only.
      - `[Activity <String>]`: The supplemental information to a user's availability. Possible values are Available, Away, BeRightBack, Busy, DoNotDisturb, InACall, InAConferenceCall, Inactive,InAMeeting, Offline, OffWork,OutOfOffice, PresenceUnknown,Presenting, UrgentInterruptionsOnly.
      - `[Availability <String>]`: The base presence information for a user. Possible values are Available, AvailableIdle,  Away, BeRightBack, Busy, BusyIdle, DoNotDisturb, Offline, PresenceUnknown
    - `[Responsibility <String[]>]`: A list for the user to enumerate their responsibilities. Returned only on $select.
    - `[School <String[]>]`: A list for the user to enumerate the schools they have attended. Returned only on $select.
    - `[Setting <IMicrosoftGraphUserSettings1>]`: userSettings
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[ContributionToContentDiscoveryAsOrganizationDisabled <Boolean?>]`: Reflects the Office Delve organization level setting. When set to true, the organization doesn't have access to Office Delve. This setting is read-only and can only be changed by administrators in the SharePoint admin center.
      - `[ContributionToContentDiscoveryDisabled <Boolean?>]`: When set to true, documents in the user's Office Delve are disabled. Users can control this setting in Office Delve.
      - `[ShiftPreference <IMicrosoftGraphShiftPreferences1>]`: shiftPreferences
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[Id <String>]`: Read-only.
        - `[Availability <IMicrosoftGraphShiftAvailability1[]>]`: Availability of the user to be scheduled for work and its recurrence pattern.
          - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
          - `[TimeSlot <IMicrosoftGraphTimeRange1[]>]`: The time slot(s) preferred by the user.
            - `[EndTime <String>]`: End time for the time range.
            - `[StartTime <String>]`: Start time for the time range.
          - `[TimeZone <String>]`: Specifies the time zone for the indicated time.
    - `[ShowInAddressList <Boolean?>]`: true if the Outlook global address list should contain this user, otherwise false. If not set, this will be treated as true. For users invited through the invitation manager, this property will be set to false. Supports $filter (eq, ne, NOT, in).
    - `[Skill <String[]>]`: A list for the user to enumerate their skills. Returned only on $select.
    - `[State <String>]`: The state or province in the user's address. Maximum length is 128 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[StreetAddress <String>]`: The street address of the user's place of business. Maximum length is 1024 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[Surname <String>]`: The user's surname (family name or last name). Maximum length is 64 characters. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[Teamwork <IMicrosoftGraphUserTeamwork>]`: userTeamwork
      - `[Id <String>]`: Read-only.
      - `[InstalledApp <IMicrosoftGraphUserScopeTeamsAppInstallation1[]>]`: The apps installed in the personal scope of this user.
        - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
        - `[TeamsAppDefinition <IMicrosoftGraphTeamsAppDefinition1>]`: teamsAppDefinition
        - `[Id <String>]`: Read-only.
        - `[ChatCreatedDateTime <DateTime?>]`: Date and time at which the chat was created. Read-only.
        - `[ChatId <String>]`: Read-only.
        - `[ChatInstalledApp <IMicrosoftGraphTeamsAppInstallation1[]>]`: A collection of all the apps in the chat. Nullable.
        - `[ChatLastUpdatedDateTime <DateTime?>]`: Date and time at which the chat was renamed or list of members were last changed. Read-only.
        - `[ChatMember <IMicrosoftGraphConversationMember1[]>]`: A collection of all the members in the chat. Nullable.
        - `[ChatMessage <IMicrosoftGraphChatMessage1[]>]`: A collection of all the messages in the chat. Nullable.
        - `[ChatTab <IMicrosoftGraphTeamsTab1[]>]`: 
        - `[ChatTopic <String>]`: (Optional) Subject or topic for the chat. Only available for group chats.
        - `[ChatType <String>]`: chatType
    - `[Todo <IMicrosoftGraphTodo1>]`: todo
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[List <IMicrosoftGraphTodoTaskList1[]>]`: The task lists in the users mailbox.
        - `[Id <String>]`: Read-only.
        - `[DisplayName <String>]`: The name of the task list.
        - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the task list. Nullable.
        - `[IsOwner <Boolean?>]`: True if the user is owner of the given task list.
        - `[IsShared <Boolean?>]`: True if the task list is shared with other users
        - `[Task <IMicrosoftGraphTodoTask1[]>]`: The tasks in this task list. Read-only. Nullable.
          - `[Id <String>]`: Read-only.
          - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
          - `[BodyLastModifiedDateTime <DateTime?>]`: The date and time when the task was last modified. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
          - `[CompletedDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
          - `[CreatedDateTime <DateTime?>]`: The date and time when the task was created. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
          - `[DueDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
          - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the task. Nullable.
          - `[Importance <String>]`: importance
          - `[IsReminderOn <Boolean?>]`: Set to true if an alert is set to remind the user of the task.
          - `[LastModifiedDateTime <DateTime?>]`: The date and time when the task was last modified. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
          - `[LinkedResource <IMicrosoftGraphLinkedResource1[]>]`: A collection of resources linked to the task.
            - `[Id <String>]`: Read-only.
            - `[ApplicationName <String>]`: Field indicating the app name of the source that is sending the linkedResource.
            - `[DisplayName <String>]`: Field indicating the title of the linkedResource.
            - `[ExternalId <String>]`: Id of the object that is associated with this task on the third-party/partner system.
            - `[WebUrl <String>]`: Deep link to the linkedResource.
          - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
          - `[ReminderDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
          - `[Status <String>]`: taskStatus
          - `[Title <String>]`: A brief description of the task.
        - `[WellknownListName <String>]`: wellknownListName
    - `[TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>]`: 
    - `[UsageLocation <String>]`: A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement to check for availability of services in countries.  Examples include: US, JP, and GB. Not nullable. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
    - `[UserPrincipalName <String>]`: The user principal name (UPN) of the user. The UPN is an Internet-style login name for the user based on the Internet standard RFC 822. By convention, this should map to the user's email name. The general format is alias@domain, where domain must be present in the tenant's collection of verified domains. This property is required when a user is created. The verified domains for the tenant can be accessed from the verifiedDomains property of organization.NOTE: While this property can contain accent characters, they can cause access issues to first-party applications for the user. Supports $filter (eq, ne, NOT, ge, le, in, startsWith, endsWith) and $orderBy.
    - `[UserType <String>]`: A string value that can be used to classify user types in your directory, such as Member and Guest. Supports $filter (eq, ne, NOT, in,).
  - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
  - `[Description <String>]`: Provides a user-visible description of the item. Optional.
  - `[ETag <String>]`: ETag for the item. Read-only.
  - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
  - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
  - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
  - `[Name <String>]`: The name of the item. Read-write.
  - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
  - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
  - `[Id <String>]`: Read-only.
  - `[Analytic <IMicrosoftGraphItemAnalytics1>]`: itemAnalytics
  - `[Column <IMicrosoftGraphColumnDefinition1[]>]`: The collection of column definitions reusable across lists under this site.
  - `[ContentType <IMicrosoftGraphContentType1[]>]`: The collection of content types defined for this site.
  - `[DisplayName <String>]`: The full title for the site. Read-only.
  - `[Drive <IMicrosoftGraphDrive1>]`: drive
  - `[Drives <IMicrosoftGraphDrive1[]>]`: The collection of drives (document libraries) under this site.
  - `[Error <IMicrosoftGraphPublicError1>]`: publicError
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Code <String>]`: Represents the error code.
    - `[Detail <IMicrosoftGraphPublicErrorDetail1[]>]`: Details of the error.
      - `[Code <String>]`: The error code.
      - `[Message <String>]`: The error message.
      - `[Target <String>]`: The target of the error.
    - `[InnerError <IMicrosoftGraphPublicInnerError1>]`: publicInnerError
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Code <String>]`: The error code.
      - `[Detail <IMicrosoftGraphPublicErrorDetail1[]>]`: A collection of error details.
      - `[Message <String>]`: The error message.
      - `[Target <String>]`: The target of the error.
    - `[Message <String>]`: A non-localized message for the developer.
    - `[Target <String>]`: The target of the error.
  - `[Items <IMicrosoftGraphBaseItem1[]>]`: Used to address any item contained in this site. This collection cannot be enumerated.
    - `[Id <String>]`: Read-only.
    - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[CreatedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
    - `[CreatedDateTime <DateTime?>]`: Date and time of item creation. Read-only.
    - `[Description <String>]`: Provides a user-visible description of the item. Optional.
    - `[ETag <String>]`: ETag for the item. Read-only.
    - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[LastModifiedByUser <IMicrosoftGraphUser>]`: Represents an Azure Active Directory user object.
    - `[LastModifiedDateTime <DateTime?>]`: Date and time the item was last modified. Read-only.
    - `[Name <String>]`: The name of the item. Read-write.
    - `[ParentReference <IMicrosoftGraphItemReference1>]`: itemReference
    - `[WebUrl <String>]`: URL that displays the resource in the browser. Read-only.
  - `[List <IMicrosoftGraphList1[]>]`: The collection of lists under this site.
  - `[Onenote <IMicrosoftGraphOnenote1>]`: onenote
  - `[Permission <IMicrosoftGraphPermission1[]>]`: The permissions associated with the site. Nullable.
  - `[Root <IMicrosoftGraphRoot>]`: root
  - `[SharepointId <IMicrosoftGraphSharepointIds1>]`: sharepointIds
  - `[Site <IMicrosoftGraphSite1[]>]`: The collection of the sub-sites under this site.
  - `[SiteCollection <IMicrosoftGraphSiteCollection1>]`: siteCollection
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[DataLocationCode <String>]`: The geographic region code for where this site collection resides. Read-only.
    - `[Hostname <String>]`: The hostname for the site collection. Read-only.
    - `[Root <IMicrosoftGraphRoot>]`: root

IDENTITY <IMicrosoftGraphObjectIdentity1[]>: Represents the identities that can be used to sign in to this user account. An identity can be provided by Microsoft (also known as a local account), by organizations, or by social identity providers such as Facebook, Google, and Microsoft, and tied to a user account. May contain multiple items with the same signInType value. Supports $filter (eq) only where the signInType is not userPrincipalName.
  - `[Issuer <String>]`: Specifies the issuer of the identity, for example facebook.com.For local accounts (where signInType is not federated), this property is the local B2C tenant default domain name, for example contoso.onmicrosoft.com.For external users from other Azure AD organization, this will be the domain of the federated organization, for example contoso.com.Supports $filter. 512 character limit.
  - `[IssuerAssignedId <String>]`: Specifies the unique identifier assigned to the user by the issuer. The combination of issuer and issuerAssignedId must be unique within the organization. Represents the sign-in name for the user, when signInType is set to emailAddress or userName (also known as local accounts).When signInType is set to: emailAddress, (or a custom string that starts with emailAddress like emailAddress1) issuerAssignedId must be a valid email addressuserName, issuerAssignedId must be a valid local part of an email addressSupports $filter. 100 character limit.
  - `[SignInType <String>]`: Specifies the user sign-in types in your directory, such as emailAddress, userName or federated. Here, federated represents a unique identifier for a user from an issuer, that can be in any format chosen by the issuer. Additional validation is enforced on issuerAssignedId when the sign-in type is set to emailAddress or userName. This property can also be set to any custom string.

INFERENCECLASSIFICATION <IMicrosoftGraphInferenceClassification1>: inferenceClassification
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Read-only.
  - `[Override <IMicrosoftGraphInferenceClassificationOverride1[]>]`: A set of overrides for a user to always classify messages from specific senders in certain ways: focused, or other. Read-only. Nullable.
    - `[Id <String>]`: Read-only.
    - `[ClassifyAs <String>]`: inferenceClassificationType
    - `[SenderEmailAddress <IMicrosoftGraphEmailAddress1>]`: emailAddress
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Address <String>]`: The email address of an entity instance.
      - `[Name <String>]`: The display name of an entity instance.

INSIGHT <IMicrosoftGraphOfficeGraphInsights1>: officeGraphInsights
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Read-only.
  - `[Shared <IMicrosoftGraphSharedInsight1[]>]`: Access this property from the derived type itemInsights.
    - `[Id <String>]`: Read-only.
    - `[LastShared <IMicrosoftGraphSharingDetail1>]`: sharingDetail
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[SharedBy <IMicrosoftGraphInsightIdentity1>]`: insightIdentity
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Address <String>]`: The email address of the user who shared the item.
        - `[DisplayName <String>]`: The display name of the user who shared the item.
        - `[Id <String>]`: The id of the user who shared the item.
      - `[SharedDateTime <DateTime?>]`: The date and time the file was last shared. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
      - `[SharingReference <IMicrosoftGraphResourceReference1>]`: resourceReference
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Id <String>]`: The item's unique identifier.
        - `[Type <String>]`: A string value that can be used to classify the item, such as 'microsoft.graph.driveItem'
        - `[WebUrl <String>]`: A URL leading to the referenced item.
      - `[SharingSubject <String>]`: The subject with which the document was shared.
      - `[SharingType <String>]`: Determines the way the document was shared, can be by a 'Link', 'Attachment', 'Group', 'Site'.
    - `[LastSharedMethodId <String>]`: Read-only.
    - `[ResourceId <String>]`: Read-only.
    - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
    - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[ContainerDisplayName <String>]`: A string describing where the item is stored. For example, the name of a SharePoint site or the user name identifying the owner of the OneDrive storing the item.
      - `[ContainerType <String>]`: Can be used for filtering by the type of container in which the file is stored. Such as Site or OneDriveBusiness.
      - `[ContainerWebUrl <String>]`: A path leading to the folder in which the item is stored.
      - `[MediaType <String>]`: The item's media type. Can be used for filtering for a specific type of file based on supported IANA Media Mime Types. Note that not all Media Mime Types are supported.
      - `[PreviewImageUrl <String>]`: A URL leading to the preview image for the item.
      - `[PreviewText <String>]`: A preview text for the item.
      - `[Title <String>]`: The item's title text.
      - `[Type <String>]`: The item's media type. Can be used for filtering for a specific file based on a specific type. See below for supported types.
    - `[SharingHistory <IMicrosoftGraphSharingDetail1[]>]`: 
  - `[Trending <IMicrosoftGraphTrending1[]>]`: Access this property from the derived type itemInsights.
    - `[Id <String>]`: Read-only.
    - `[LastModifiedDateTime <DateTime?>]`: 
    - `[ResourceId <String>]`: Read-only.
    - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
    - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization
    - `[Weight <Double?>]`: Value indicating how much the document is currently trending. The larger the number, the more the document is currently trending around the user (the more relevant it is). Returned documents are sorted by this value.
  - `[Used <IMicrosoftGraphUsedInsight1[]>]`: Access this property from the derived type itemInsights.
    - `[Id <String>]`: Read-only.
    - `[LastUsed <IMicrosoftGraphUsageDetails1>]`: usageDetails
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[LastAccessedDateTime <DateTime?>]`: The date and time the resource was last accessed by the user. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
      - `[LastModifiedDateTime <DateTime?>]`: The date and time the resource was last modified by the user. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 would look like this: 2014-01-01T00:00:00Z. Read-only.
    - `[ResourceId <String>]`: Read-only.
    - `[ResourceReference <IMicrosoftGraphResourceReference1>]`: resourceReference
    - `[ResourceVisualization <IMicrosoftGraphResourceVisualization1>]`: resourceVisualization

MAILBOXSETTING <IMicrosoftGraphMailboxSettings1>: mailboxSettings
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ArchiveFolder <String>]`: Folder ID of an archive folder for the user. Read only.
  - `[AutomaticRepliesSetting <IMicrosoftGraphAutomaticRepliesSetting1>]`: automaticRepliesSetting
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[ExternalAudience <String>]`: externalAudienceScope
    - `[ExternalReplyMessage <String>]`: The automatic reply to send to the specified external audience, if Status is AlwaysEnabled or Scheduled.
    - `[InternalReplyMessage <String>]`: The automatic reply to send to the audience internal to the signed-in user's organization, if Status is AlwaysEnabled or Scheduled.
    - `[ScheduledEndDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[DateTime <String>]`: A single point of time in a combined date and time representation ({date}T{time}). For example, '2019-04-16T09:00:00'.
      - `[TimeZone <String>]`: Represents a time zone, for example, 'Pacific Standard Time'. See below for possible values.
    - `[ScheduledStartDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
    - `[Status <String>]`: automaticRepliesStatus
  - `[DateFormat <String>]`: The date format for the user's mailbox.
  - `[DelegateMeetingMessageDeliveryOption <String>]`: delegateMeetingMessageDeliveryOptions
  - `[Language <IMicrosoftGraphLocaleInfo1>]`: localeInfo
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[DisplayName <String>]`: A name representing the user's locale in natural language, for example, 'English (United States)'.
    - `[Locale <String>]`: A locale representation for the user, which includes the user's preferred language and country/region. For example, 'en-us'. The language component follows 2-letter codes as defined in ISO 639-1, and the country component follows 2-letter codes as defined in ISO 3166-1 alpha-2.
  - `[TimeFormat <String>]`: The time format for the user's mailbox.
  - `[TimeZone <String>]`: The default time zone for the user's mailbox.
  - `[WorkingHour <IMicrosoftGraphWorkingHours1>]`: workingHours
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[DaysOfWeek <String[]>]`: The days of the week on which the user works.
    - `[EndTime <String>]`: The time of the day that the user stops working.
    - `[StartTime <String>]`: The time of the day that the user starts working.
    - `[TimeZone <IMicrosoftGraphTimeZoneBase1>]`: timeZoneBase
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Name <String>]`: The name of a time zone. It can be a standard time zone name such as 'Hawaii-Aleutian Standard Time', or 'Customized Time Zone' for a custom time zone.

MANAGEDAPPREGISTRATION <IMicrosoftGraphManagedAppRegistration1[]>: Zero or more managed app registrations that belong to the user.
  - `[Id <String>]`: Read-only.
  - `[AppIdentifier <IMicrosoftGraphMobileAppIdentifier>]`: The identifier for a mobile app.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ApplicationVersion <String>]`: App version
  - `[AppliedPolicy <IMicrosoftGraphManagedAppPolicy1[]>]`: Zero or more policys already applied on the registered app when it last synchronized with managment service.
    - `[Id <String>]`: Read-only.
    - `[CreatedDateTime <DateTime?>]`: The date and time the policy was created.
    - `[Description <String>]`: The policy's description.
    - `[DisplayName <String>]`: Policy display name.
    - `[LastModifiedDateTime <DateTime?>]`: Last time the policy was modified.
    - `[Version <String>]`: Version of the entity.
  - `[CreatedDateTime <DateTime?>]`: Date and time of creation
  - `[DeviceName <String>]`: Host device name
  - `[DeviceTag <String>]`: App management SDK generated tag, which helps relate apps hosted on the same device. Not guaranteed to relate apps in all conditions.
  - `[DeviceType <String>]`: Host device type
  - `[FlaggedReason <String[]>]`: Zero or more reasons an app registration is flagged. E.g. app running on rooted device
  - `[IntendedPolicy <IMicrosoftGraphManagedAppPolicy1[]>]`: Zero or more policies admin intended for the app as of now.
  - `[LastSyncDateTime <DateTime?>]`: Date and time of last the app synced with management service.
  - `[ManagementSdkVersion <String>]`: App management SDK version
  - `[Operation <IMicrosoftGraphManagedAppOperation1[]>]`: Zero or more long running operations triggered on the app registration.
    - `[Id <String>]`: Read-only.
    - `[DisplayName <String>]`: The operation name.
    - `[LastModifiedDateTime <DateTime?>]`: The last time the app operation was modified.
    - `[State <String>]`: The current state of the operation
    - `[Version <String>]`: Version of the entity.
  - `[PlatformVersion <String>]`: Operating System version
  - `[UserId <String>]`: The user Id to who this app registration belongs.
  - `[Version <String>]`: Version of the entity.

MANAGEDDEVICE <IMicrosoftGraphManagedDevice1[]>: The managed devices associated with the user.
  - `[Id <String>]`: Read-only.
  - `[ActivationLockBypassCode <String>]`: Code that allows the Activation Lock on a device to be bypassed. This property is read-only.
  - `[AndroidSecurityPatchLevel <String>]`: Android security patch level. This property is read-only.
  - `[AzureAdDeviceId <String>]`: The unique identifier for the Azure Active Directory device. Read only. This property is read-only.
  - `[AzureAdRegistered <Boolean?>]`: Whether the device is Azure Active Directory registered. This property is read-only.
  - `[ComplianceGracePeriodExpirationDateTime <DateTime?>]`: The DateTime when device compliance grace period expires. This property is read-only.
  - `[ComplianceState <String>]`: complianceState
  - `[ConfigurationManagerClientEnabledFeature <IMicrosoftGraphConfigurationManagerClientEnabledFeatures1>]`: configuration Manager client enabled features
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[CompliancePolicy <Boolean?>]`: Whether compliance policy is managed by Intune
    - `[DeviceConfiguration <Boolean?>]`: Whether device configuration is managed by Intune
    - `[Inventory <Boolean?>]`: Whether inventory is managed by Intune
    - `[ModernApp <Boolean?>]`: Whether modern application is managed by Intune
    - `[ResourceAccess <Boolean?>]`: Whether resource access is managed by Intune
    - `[WindowsUpdateForBusiness <Boolean?>]`: Whether Windows Update for Business is managed by Intune
  - `[DeviceActionResult <IMicrosoftGraphDeviceActionResult1[]>]`: List of ComplexType deviceActionResult objects. This property is read-only.
    - `[ActionName <String>]`: Action name
    - `[ActionState <String>]`: actionState
    - `[LastUpdatedDateTime <DateTime?>]`: Time the action state was last updated
    - `[StartDateTime <DateTime?>]`: Time the action was initiated
  - `[DeviceCategory <IMicrosoftGraphDeviceCategory1>]`: Device categories provides a way to organize your devices. Using device categories, company administrators can define their own categories that make sense to their company. These categories can then be applied to a device in the Intune Azure console or selected by a user during device enrollment. You can filter reports and create dynamic Azure Active Directory device groups based on device categories.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Id <String>]`: Read-only.
    - `[Description <String>]`: Optional description for the device category.
    - `[DisplayName <String>]`: Display name for the device category.
  - `[DeviceCategoryDisplayName <String>]`: Device category display name. This property is read-only.
  - `[DeviceCompliancePolicyState <IMicrosoftGraphDeviceCompliancePolicyState1[]>]`: Device compliance policy states for this device.
    - `[Id <String>]`: Read-only.
    - `[DisplayName <String>]`: The name of the policy for this policyBase
    - `[PlatformType <String>]`: policyPlatformType
    - `[SettingCount <Int32?>]`: Count of how many setting a policy holds
    - `[SettingState <IMicrosoftGraphDeviceCompliancePolicySettingState1[]>]`: 
      - `[CurrentValue <String>]`: Current value of setting on device
      - `[ErrorCode <Int64?>]`: Error code for the setting
      - `[ErrorDescription <String>]`: Error description
      - `[InstanceDisplayName <String>]`: Name of setting instance that is being reported.
      - `[Setting <String>]`: The setting that is being reported
      - `[SettingName <String>]`: Localized/user friendly setting name that is being reported
      - `[Source <IMicrosoftGraphSettingSource1[]>]`: Contributing policies
        - `[DisplayName <String>]`: Not yet documented
        - `[Id <String>]`: Not yet documented
      - `[State <String>]`: complianceStatus
      - `[UserEmail <String>]`: UserEmail
      - `[UserId <String>]`: UserId
      - `[UserName <String>]`: UserName
      - `[UserPrincipalName <String>]`: UserPrincipalName.
    - `[State <String>]`: complianceStatus
    - `[Version <Int32?>]`: The version of the policy
  - `[DeviceConfigurationState <IMicrosoftGraphDeviceConfigurationState1[]>]`: Device configuration states for this device.
    - `[Id <String>]`: Read-only.
    - `[DisplayName <String>]`: The name of the policy for this policyBase
    - `[PlatformType <String>]`: policyPlatformType
    - `[SettingCount <Int32?>]`: Count of how many setting a policy holds
    - `[SettingState <IMicrosoftGraphDeviceConfigurationSettingState1[]>]`: 
      - `[CurrentValue <String>]`: Current value of setting on device
      - `[ErrorCode <Int64?>]`: Error code for the setting
      - `[ErrorDescription <String>]`: Error description
      - `[InstanceDisplayName <String>]`: Name of setting instance that is being reported.
      - `[Setting <String>]`: The setting that is being reported
      - `[SettingName <String>]`: Localized/user friendly setting name that is being reported
      - `[Source <IMicrosoftGraphSettingSource1[]>]`: Contributing policies
      - `[State <String>]`: complianceStatus
      - `[UserEmail <String>]`: UserEmail
      - `[UserId <String>]`: UserId
      - `[UserName <String>]`: UserName
      - `[UserPrincipalName <String>]`: UserPrincipalName.
    - `[State <String>]`: complianceStatus
    - `[Version <Int32?>]`: The version of the policy
  - `[DeviceEnrollmentType <String>]`: deviceEnrollmentType
  - `[DeviceHealthAttestationState <IMicrosoftGraphDeviceHealthAttestationState1>]`: deviceHealthAttestationState
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[AttestationIdentityKey <String>]`: TWhen an Attestation Identity Key (AIK) is present on a device, it indicates that the device has an endorsement key (EK) certificate.
    - `[BitLockerStatus <String>]`: On or Off of BitLocker Drive Encryption
    - `[BootAppSecurityVersion <String>]`: The security version number of the Boot Application
    - `[BootDebugging <String>]`: When bootDebugging is enabled, the device is used in development and testing
    - `[BootManagerSecurityVersion <String>]`: The security version number of the Boot Application
    - `[BootManagerVersion <String>]`: The version of the Boot Manager
    - `[BootRevisionListInfo <String>]`: The Boot Revision List that was loaded during initial boot on the attested device
    - `[CodeIntegrity <String>]`: When code integrity is enabled, code execution is restricted to integrity verified code
    - `[CodeIntegrityCheckVersion <String>]`: The version of the Boot Manager
    - `[CodeIntegrityPolicy <String>]`: The Code Integrity policy that is controlling the security of the boot environment
    - `[ContentNamespaceUrl <String>]`: The DHA report version. (Namespace version)
    - `[ContentVersion <String>]`: The HealthAttestation state schema version
    - `[DataExcutionPolicy <String>]`: DEP Policy defines a set of hardware and software technologies that perform additional checks on memory
    - `[DeviceHealthAttestationStatus <String>]`: The DHA report version. (Namespace version)
    - `[EarlyLaunchAntiMalwareDriverProtection <String>]`: ELAM provides protection for the computers in your network when they start up
    - `[HealthAttestationSupportedStatus <String>]`: This attribute indicates if DHA is supported for the device
    - `[HealthStatusMismatchInfo <String>]`: This attribute appears if DHA-Service detects an integrity issue
    - `[IssuedDateTime <DateTime?>]`: The DateTime when device was evaluated or issued to MDM
    - `[LastUpdateDateTime <String>]`: The Timestamp of the last update.
    - `[OperatingSystemKernelDebugging <String>]`: When operatingSystemKernelDebugging is enabled, the device is used in development and testing
    - `[OperatingSystemRevListInfo <String>]`: The Operating System Revision List that was loaded during initial boot on the attested device
    - `[Pcr0 <String>]`: The measurement that is captured in PCR[0]
    - `[PcrHashAlgorithm <String>]`: Informational attribute that identifies the HASH algorithm that was used by TPM
    - `[ResetCount <Int64?>]`: The number of times a PC device has hibernated or resumed
    - `[RestartCount <Int64?>]`: The number of times a PC device has rebooted
    - `[SafeMode <String>]`: Safe mode is a troubleshooting option for Windows that starts your computer in a limited state
    - `[SecureBoot <String>]`: When Secure Boot is enabled, the core components must have the correct cryptographic signatures
    - `[SecureBootConfigurationPolicyFingerPrint <String>]`: Fingerprint of the Custom Secure Boot Configuration Policy
    - `[TestSigning <String>]`: When test signing is allowed, the device does not enforce signature validation during boot
    - `[TpmVersion <String>]`: The security version number of the Boot Application
    - `[VirtualSecureMode <String>]`: VSM is a container that protects high value assets from a compromised kernel
    - `[WindowsPe <String>]`: Operating system running with limited services that is used to prepare a computer for Windows
  - `[DeviceName <String>]`: Name of the device. This property is read-only.
  - `[DeviceRegistrationState <String>]`: deviceRegistrationState
  - `[EasActivated <Boolean?>]`: Whether the device is Exchange ActiveSync activated. This property is read-only.
  - `[EasActivationDateTime <DateTime?>]`: Exchange ActivationSync activation time of the device. This property is read-only.
  - `[EasDeviceId <String>]`: Exchange ActiveSync Id of the device. This property is read-only.
  - `[EmailAddress <String>]`: Email(s) for the user associated with the device. This property is read-only.
  - `[EnrolledDateTime <DateTime?>]`: Enrollment time of the device. This property is read-only.
  - `[EthernetMacAddress <String>]`: Ethernet MAC. This property is read-only.
  - `[ExchangeAccessState <String>]`: deviceManagementExchangeAccessState
  - `[ExchangeAccessStateReason <String>]`: deviceManagementExchangeAccessStateReason
  - `[ExchangeLastSuccessfulSyncDateTime <DateTime?>]`: Last time the device contacted Exchange. This property is read-only.
  - `[FreeStorageSpaceInByte <Int64?>]`: Free Storage in Bytes. This property is read-only.
  - `[Iccid <String>]`: Integrated Circuit Card Identifier, it is A SIM card's unique identification number. This property is read-only.
  - `[Imei <String>]`: IMEI. This property is read-only.
  - `[IsEncrypted <Boolean?>]`: Device encryption status. This property is read-only.
  - `[IsSupervised <Boolean?>]`: Device supervised status. This property is read-only.
  - `[JailBroken <String>]`: whether the device is jail broken or rooted. This property is read-only.
  - `[LastSyncDateTime <DateTime?>]`: The date and time that the device last completed a successful sync with Intune. This property is read-only.
  - `[ManagedDeviceName <String>]`: Automatically generated name to identify a device. Can be overwritten to a user friendly name.
  - `[ManagedDeviceOwnerType <String>]`: managedDeviceOwnerType
  - `[ManagementAgent <String>]`: managementAgentType
  - `[Manufacturer <String>]`: Manufacturer of the device. This property is read-only.
  - `[Meid <String>]`: MEID. This property is read-only.
  - `[Model <String>]`: Model of the device. This property is read-only.
  - `[Note <String>]`: Notes on the device created by IT Admin
  - `[OSVersion <String>]`: Operating system version of the device. This property is read-only.
  - `[OperatingSystem <String>]`: Operating system of the device. Windows, iOS, etc. This property is read-only.
  - `[PartnerReportedThreatState <String>]`: managedDevicePartnerReportedHealthState
  - `[PhoneNumber <String>]`: Phone number of the device. This property is read-only.
  - `[PhysicalMemoryInByte <Int64?>]`: Total Memory in Bytes. This property is read-only.
  - `[RemoteAssistanceSessionErrorDetail <String>]`: An error string that identifies issues when creating Remote Assistance session objects. This property is read-only.
  - `[RemoteAssistanceSessionUrl <String>]`: Url that allows a Remote Assistance session to be established with the device. This property is read-only.
  - `[SerialNumber <String>]`: SerialNumber. This property is read-only.
  - `[SubscriberCarrier <String>]`: Subscriber Carrier. This property is read-only.
  - `[TotalStorageSpaceInByte <Int64?>]`: Total Storage in Bytes. This property is read-only.
  - `[Udid <String>]`: Unique Device Identifier for iOS and macOS devices. This property is read-only.
  - `[UserDisplayName <String>]`: User display name. This property is read-only.
  - `[UserId <String>]`: Unique Identifier for the user associated with the device. This property is read-only.
  - `[UserPrincipalName <String>]`: Device user principal name. This property is read-only.
  - `[WiFiMacAddress <String>]`: Wi-Fi MAC. This property is read-only.

MANAGER <IMicrosoftGraphDirectoryObject>: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
  - `[Id <String>]`: Read-only.
  - `[DeletedDateTime <DateTime?>]`: 

OAUTH2PERMISSIONGRANT <IMicrosoftGraphOAuth2PermissionGrant1[]>: .
  - `[Id <String>]`: Read-only.
  - `[ClientId <String>]`: The id of the client service principal for the application which is authorized to act on behalf of a signed-in user when accessing an API. Required. Supports $filter (eq only).
  - `[ConsentType <String>]`: Indicates whether authorization is granted for the client application to impersonate all users or only a specific user. AllPrincipals indicates authorization to impersonate all users. Principal indicates authorization to impersonate a specific user. Consent on behalf of all users can be granted by an administrator. Non-admin users may be authorized to consent on behalf of themselves in some cases, for some delegated permissions. Required. Supports $filter (eq only).
  - `[PrincipalId <String>]`: The id of the user on behalf of whom the client is authorized to access the resource, when consentType is Principal. If consentType is AllPrincipals this value is null. Required when consentType is Principal.
  - `[ResourceId <String>]`: The id of the resource service principal to which access is authorized. This identifies the API which the client is authorized to attempt to call on behalf of a signed-in user.
  - `[Scope <String>]`: A space-separated list of the claim values for delegated permissions which should be included in access tokens for the resource application (the API). For example, openid User.Read GroupMember.Read.All. Each claim value should match the value field of one of the delegated permissions defined by the API, listed in the publishedPermissionScopes property of the resource service principal.

ONENOTE <IMicrosoftGraphOnenote1>: onenote
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Read-only.
  - `[Notebook <IMicrosoftGraphNotebook1[]>]`: The collection of OneNote notebooks that are owned by the user or group. Read-only. Nullable.
    - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Application <IMicrosoftGraphIdentity1>]`: identity
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
        - `[Id <String>]`: Unique identifier for the identity.
      - `[Device <IMicrosoftGraphIdentity1>]`: identity
      - `[User <IMicrosoftGraphIdentity1>]`: identity
    - `[DisplayName <String>]`: The name of the notebook.
    - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[LastModifiedDateTime <DateTime?>]`: The date and time when the notebook was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
    - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
    - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
    - `[Id <String>]`: Read-only.
    - `[IsDefault <Boolean?>]`: Indicates whether this is the user's default notebook. Read-only.
    - `[IsShared <Boolean?>]`: Indicates whether the notebook is shared. If true, the contents of the notebook can be seen by people other than the owner. Read-only.
    - `[Link <IMicrosoftGraphNotebookLinks1>]`: notebookLinks
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[OneNoteClientUrl <IMicrosoftGraphExternalLink1>]`: externalLink
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Href <String>]`: The url of the link.
      - `[OneNoteWebUrl <IMicrosoftGraphExternalLink1>]`: externalLink
    - `[Section <IMicrosoftGraphOnenoteSection1[]>]`: The sections in the notebook. Read-only. Nullable.
      - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[DisplayName <String>]`: The name of the notebook.
      - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[LastModifiedDateTime <DateTime?>]`: The date and time when the notebook was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
      - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
      - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
      - `[Id <String>]`: Read-only.
      - `[IsDefault <Boolean?>]`: Indicates whether this is the user's default section. Read-only.
      - `[Link <IMicrosoftGraphSectionLinks1>]`: sectionLinks
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[OneNoteClientUrl <IMicrosoftGraphExternalLink1>]`: externalLink
        - `[OneNoteWebUrl <IMicrosoftGraphExternalLink1>]`: externalLink
      - `[Page <IMicrosoftGraphOnenotePage1[]>]`: The collection of pages in the section.  Read-only. Nullable.
        - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
        - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
        - `[Id <String>]`: Read-only.
        - `[Content <Byte[]>]`: The page's HTML content.
        - `[ContentUrl <String>]`: The URL for the page's HTML content.  Read-only.
        - `[CreatedByAppId <String>]`: The unique identifier of the application that created the page. Read-only.
        - `[LastModifiedDateTime <DateTime?>]`: The date and time when the page was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
        - `[Level <Int32?>]`: The indentation level of the page. Read-only.
        - `[Link <IMicrosoftGraphPageLinks1>]`: pageLinks
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[OneNoteClientUrl <IMicrosoftGraphExternalLink1>]`: externalLink
          - `[OneNoteWebUrl <IMicrosoftGraphExternalLink1>]`: externalLink
        - `[Order <Int32?>]`: The order of the page within its parent section. Read-only.
        - `[ParentNotebook <IMicrosoftGraphNotebook1>]`: notebook
        - `[ParentSection <IMicrosoftGraphOnenoteSection1>]`: onenoteSection
        - `[Title <String>]`: The title of the page.
        - `[UserTag <String[]>]`: 
      - `[PagesUrl <String>]`: The pages endpoint where you can get details for all the pages in the section. Read-only.
      - `[ParentNotebook <IMicrosoftGraphNotebook1>]`: notebook
      - `[ParentSectionGroup <IMicrosoftGraphSectionGroup1>]`: sectionGroup
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[DisplayName <String>]`: The name of the notebook.
        - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[LastModifiedDateTime <DateTime?>]`: The date and time when the notebook was last modified. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
        - `[CreatedDateTime <DateTime?>]`: The date and time when the page was created. The timestamp represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
        - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
        - `[Id <String>]`: Read-only.
        - `[ParentNotebook <IMicrosoftGraphNotebook1>]`: notebook
        - `[ParentSectionGroup <IMicrosoftGraphSectionGroup1>]`: sectionGroup
        - `[Section <IMicrosoftGraphOnenoteSection1[]>]`: The sections in the section group. Read-only. Nullable.
        - `[SectionGroup <IMicrosoftGraphSectionGroup1[]>]`: The section groups in the section. Read-only. Nullable.
        - `[SectionGroupsUrl <String>]`: The URL for the sectionGroups navigation property, which returns all the section groups in the section group. Read-only.
        - `[SectionsUrl <String>]`: The URL for the sections navigation property, which returns all the sections in the section group. Read-only.
    - `[SectionGroup <IMicrosoftGraphSectionGroup1[]>]`: The section groups in the notebook. Read-only. Nullable.
    - `[SectionGroupsUrl <String>]`: The URL for the sectionGroups navigation property, which returns all the section groups in the notebook. Read-only.
    - `[SectionsUrl <String>]`: The URL for the sections navigation property, which returns all the sections in the notebook. Read-only.
    - `[UserRole <String>]`: onenoteUserRole
  - `[Operation <IMicrosoftGraphOnenoteOperation1[]>]`: The status of OneNote operations. Getting an operations collection is not supported, but you can get the status of long-running operations if the Operation-Location header is returned in the response. Read-only. Nullable.
    - `[CreatedDateTime <DateTime?>]`: The start time of the operation.
    - `[LastActionDateTime <DateTime?>]`: The time of the last action of the operation.
    - `[Status <String>]`: operationStatus
    - `[Id <String>]`: Read-only.
    - `[Error <IMicrosoftGraphOnenoteOperationError1>]`: onenoteOperationError
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Code <String>]`: The error code.
      - `[Message <String>]`: The error message.
    - `[PercentComplete <String>]`: The operation percent complete if the operation is still in running status.
    - `[ResourceId <String>]`: The resource id.
    - `[ResourceLocation <String>]`: The resource URI for the object. For example, the resource URI for a copied page or section.
  - `[Page <IMicrosoftGraphOnenotePage1[]>]`: The pages in all OneNote notebooks that are owned by the user or group.  Read-only. Nullable.
  - `[Resource <IMicrosoftGraphOnenoteResource1[]>]`: The image and other file resources in OneNote pages. Getting a resources collection is not supported, but you can get the binary content of a specific resource. Read-only. Nullable.
    - `[Self <String>]`: The endpoint where you can get details about the page. Read-only.
    - `[Id <String>]`: Read-only.
    - `[Content <Byte[]>]`: The content stream
    - `[ContentUrl <String>]`: The URL for downloading the content
  - `[Section <IMicrosoftGraphOnenoteSection1[]>]`: The sections in all OneNote notebooks that are owned by the user or group.  Read-only. Nullable.
  - `[SectionGroup <IMicrosoftGraphSectionGroup1[]>]`: The section groups in all OneNote notebooks that are owned by the user or group.  Read-only. Nullable.

ONLINEMEETING <IMicrosoftGraphOnlineMeeting1[]>: .
  - `[Id <String>]`: Read-only.
  - `[AllowAttendeeToEnableCamera <Boolean?>]`: Indicates whether attendees can turn on their camera.
  - `[AllowAttendeeToEnableMic <Boolean?>]`: Indicates whether attendees can turn on their microphone.
  - `[AllowMeetingChat <String>]`: meetingChatMode
  - `[AllowTeamworkReaction <Boolean?>]`: Indicates if Teams reactions are enabled for the meeting.
  - `[AllowedPresenter <String>]`: onlineMeetingPresenters
  - `[AudioConferencing <IMicrosoftGraphAudioConferencing1>]`: audioConferencing
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[ConferenceId <String>]`: The conference id of the online meeting.
    - `[DialinUrl <String>]`: A URL to the externally-accessible web page that contains dial-in information.
    - `[TollFreeNumber <String>]`: The toll-free number that connects to the Audio Conference Provider.
    - `[TollNumber <String>]`: The toll number that connects to the Audio Conference Provider.
  - `[ChatInfo <IMicrosoftGraphChatInfo1>]`: chatInfo
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[MessageId <String>]`: The unique identifier for a message in a Microsoft Teams channel.
    - `[ReplyChainMessageId <String>]`: The ID of the reply message.
    - `[ThreadId <String>]`: The unique identifier for a thread in Microsoft Teams.
  - `[CreationDateTime <DateTime?>]`: The meeting creation time in UTC. Read-only.
  - `[EndDateTime <DateTime?>]`: The meeting end time in UTC.
  - `[ExternalId <String>]`: The external ID. A custom ID. Optional.
  - `[IsEntryExitAnnounced <Boolean?>]`: Indicates whether to announce when callers join or leave.
  - `[JoinInformation <IMicrosoftGraphItemBody1>]`: itemBody
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Content <String>]`: The content of the item.
    - `[ContentType <String>]`: bodyType
  - `[JoinWebUrl <String>]`: The join URL of the online meeting. Read-only.
  - `[LobbyBypassSetting <IMicrosoftGraphLobbyBypassSettings1>]`: lobbyBypassSettings
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[IsDialInBypassEnabled <Boolean?>]`: Specifies whether or not to always let dial-in callers bypass the lobby. Optional.
    - `[Scope <String>]`: lobbyBypassScope
  - `[Participant <IMicrosoftGraphMeetingParticipants1>]`: meetingParticipants
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Attendee <IMicrosoftGraphMeetingParticipantInfo1[]>]`: Information of the meeting attendees.
      - `[Identity <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Application <IMicrosoftGraphIdentity1>]`: identity
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
          - `[Id <String>]`: Unique identifier for the identity.
        - `[Device <IMicrosoftGraphIdentity1>]`: identity
        - `[User <IMicrosoftGraphIdentity1>]`: identity
      - `[Role <String>]`: onlineMeetingRole
      - `[Upn <String>]`: User principal name of the participant.
    - `[Organizer <IMicrosoftGraphMeetingParticipantInfo1>]`: meetingParticipantInfo
  - `[StartDateTime <DateTime?>]`: The meeting start time in UTC.
  - `[Subject <String>]`: The subject of the online meeting.
  - `[VideoTeleconferenceId <String>]`: The video teleconferencing ID. Read-only.

ONPREMISESEXTENSIONATTRIBUTE <IMicrosoftGraphOnPremisesExtensionAttributes1>: onPremisesExtensionAttributes
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ExtensionAttribute1 <String>]`: First customizable extension attribute.
  - `[ExtensionAttribute10 <String>]`: Tenth customizable extension attribute.
  - `[ExtensionAttribute11 <String>]`: Eleventh customizable extension attribute.
  - `[ExtensionAttribute12 <String>]`: Twelfth customizable extension attribute.
  - `[ExtensionAttribute13 <String>]`: Thirteenth customizable extension attribute.
  - `[ExtensionAttribute14 <String>]`: Fourteenth customizable extension attribute.
  - `[ExtensionAttribute15 <String>]`: Fifteenth customizable extension attribute.
  - `[ExtensionAttribute2 <String>]`: Second customizable extension attribute.
  - `[ExtensionAttribute3 <String>]`: Third customizable extension attribute.
  - `[ExtensionAttribute4 <String>]`: Fourth customizable extension attribute.
  - `[ExtensionAttribute5 <String>]`: Fifth customizable extension attribute.
  - `[ExtensionAttribute6 <String>]`: Sixth customizable extension attribute.
  - `[ExtensionAttribute7 <String>]`: Seventh customizable extension attribute.
  - `[ExtensionAttribute8 <String>]`: Eighth customizable extension attribute.
  - `[ExtensionAttribute9 <String>]`: Ninth customizable extension attribute.

ONPREMISESPROVISIONINGERROR <IMicrosoftGraphOnPremisesProvisioningError1[]>: Errors when using Microsoft synchronization product during provisioning. Supports $filter (eq, NOT, ge, le).
  - `[Category <String>]`: Category of the provisioning error. Note: Currently, there is only one possible value. Possible value: PropertyConflict - indicates a property value is not unique. Other objects contain the same value for the property.
  - `[OccurredDateTime <DateTime?>]`: The date and time at which the error occurred.
  - `[PropertyCausingError <String>]`: Name of the directory property causing the error. Current possible values: UserPrincipalName or ProxyAddress
  - `[Value <String>]`: Value of the property causing the error.

OUTLOOK <IMicrosoftGraphOutlookUser1>: outlookUser
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Read-only.
  - `[MasterCategory <IMicrosoftGraphOutlookCategory1[]>]`: A list of categories defined for the user.
    - `[Id <String>]`: Read-only.
    - `[Color <String>]`: categoryColor
    - `[DisplayName <String>]`: A unique name that identifies a category in the user's mailbox. After a category is created, the name cannot be changed. Read-only.

PASSWORDPROFILE <IMicrosoftGraphPasswordProfile1>: passwordProfile
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ForceChangePasswordNextSignIn <Boolean?>]`: true if the user must change her password on the next login; otherwise false. If not set, default is false. NOTE:  For Azure B2C tenants, set to false and instead use custom policies and user flows to force password reset at first sign in. See Force password reset at first logon.
  - `[ForceChangePasswordNextSignInWithMfa <Boolean?>]`: If true, at next sign-in, the user must perform a multi-factor authentication (MFA) before being forced to change their password. The behavior is identical to forceChangePasswordNextSignIn except that the user is required to first perform a multi-factor authentication before password change. After a password change, this property will be automatically reset to false. If not set, default is false.
  - `[Password <String>]`: The password for the user. This property is required when a user is created. It can be updated, but the user will be required to change the password on the next login. The password must satisfy minimum requirements as specified by the user’s passwordPolicies property. By default, a strong password is required.

PHOTO <IMicrosoftGraphProfilePhoto1>: profilePhoto
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Read-only.
  - `[Height <Int32?>]`: The height of the photo. Read-only.
  - `[Width <Int32?>]`: The width of the photo. Read-only.

PLANNER <IMicrosoftGraphPlannerUser1>: plannerUser
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Read-only.
  - `[Plan <IMicrosoftGraphPlannerPlan1[]>]`: Read-only. Nullable. Returns the plannerTasks assigned to the user.
    - `[Id <String>]`: Read-only.
    - `[Bucket <IMicrosoftGraphPlannerBucket1[]>]`: Collection of buckets in the plan. Read-only. Nullable.
      - `[Id <String>]`: Read-only.
      - `[Name <String>]`: Name of the bucket.
      - `[OrderHint <String>]`: Hint used to order items of this type in a list view. The format is defined as outlined here.
      - `[PlanId <String>]`: Plan ID to which the bucket belongs.
      - `[Task <IMicrosoftGraphPlannerTask1[]>]`: Read-only. Nullable. The collection of tasks in the bucket.
        - `[Id <String>]`: Read-only.
        - `[ActiveChecklistItemCount <Int32?>]`: Number of checklist items with value set to false, representing incomplete items.
        - `[AppliedCategory <IMicrosoftGraphPlannerAppliedCategories>]`: plannerAppliedCategories
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[AssignedToTaskBoardFormat <IMicrosoftGraphPlannerAssignedToTaskBoardTaskFormat1>]`: plannerAssignedToTaskBoardTaskFormat
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[OrderHintsByAssignee <IMicrosoftGraphPlannerOrderHintsByAssignee>]`: plannerOrderHintsByAssignee
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[UnassignedOrderHint <String>]`: Hint value used to order the task on the AssignedTo view of the Task Board when the task is not assigned to anyone, or if the orderHintsByAssignee dictionary does not provide an order hint for the user the task is assigned to. The format is defined as outlined here.
        - `[AssigneePriority <String>]`: Hint used to order items of this type in a list view. The format is defined as outlined here.
        - `[Assignment <IMicrosoftGraphPlannerAssignments>]`: plannerAssignments
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[BucketId <String>]`: Bucket ID to which the task belongs. The bucket needs to be in the plan that the task is in. It is 28 characters long and case-sensitive. Format validation is done on the service.
        - `[BucketTaskBoardFormat <IMicrosoftGraphPlannerBucketTaskBoardTaskFormat1>]`: plannerBucketTaskBoardTaskFormat
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[OrderHint <String>]`: Hint used to order tasks in the Bucket view of the Task Board. The format is defined as outlined here.
        - `[ChecklistItemCount <Int32?>]`: Number of checklist items that are present on the task.
        - `[CompletedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Application <IMicrosoftGraphIdentity1>]`: identity
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
            - `[Id <String>]`: Unique identifier for the identity.
          - `[Device <IMicrosoftGraphIdentity1>]`: identity
          - `[User <IMicrosoftGraphIdentity1>]`: identity
        - `[CompletedDateTime <DateTime?>]`: Read-only. Date and time at which the 'percentComplete' of the task is set to '100'. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[ConversationThreadId <String>]`: Thread ID of the conversation on the task. This is the ID of the conversation thread object created in the group.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
        - `[CreatedDateTime <DateTime?>]`: Read-only. Date and time at which the task is created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[Detail <IMicrosoftGraphPlannerTaskDetails1>]`: plannerTaskDetails
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[Checklist <IMicrosoftGraphPlannerChecklistItems>]`: plannerChecklistItems
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Description <String>]`: Description of the task
          - `[PreviewType <String>]`: plannerPreviewType
          - `[Reference <IMicrosoftGraphPlannerExternalReferences>]`: plannerExternalReferences
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DueDateTime <DateTime?>]`: Date and time at which the task is due. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[HasDescription <Boolean?>]`: Read-only. Value is true if the details object of the task has a non-empty description and false otherwise.
        - `[OrderHint <String>]`: Hint used to order items of this type in a list view. The format is defined as outlined here.
        - `[PercentComplete <Int32?>]`: Percentage of task completion. When set to 100, the task is considered completed.
        - `[PlanId <String>]`: Plan ID to which the task belongs.
        - `[PreviewType <String>]`: plannerPreviewType
        - `[ProgressTaskBoardFormat <IMicrosoftGraphPlannerProgressTaskBoardTaskFormat1>]`: plannerProgressTaskBoardTaskFormat
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
          - `[OrderHint <String>]`: Hint value used to order the task on the Progress view of the Task Board. The format is defined as outlined here.
        - `[ReferenceCount <Int32?>]`: Number of external references that exist on the task.
        - `[StartDateTime <DateTime?>]`: Date and time at which the task starts. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[Title <String>]`: Title of the task.
    - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
    - `[CreatedDateTime <DateTime?>]`: Read-only. Date and time at which the plan is created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
    - `[Detail <IMicrosoftGraphPlannerPlanDetails1>]`: plannerPlanDetails
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[CategoryDescription <IMicrosoftGraphPlannerCategoryDescriptions1>]`: plannerCategoryDescriptions
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Category1 <String>]`: The label associated with Category 1
        - `[Category2 <String>]`: The label associated with Category 2
        - `[Category3 <String>]`: The label associated with Category 3
        - `[Category4 <String>]`: The label associated with Category 4
        - `[Category5 <String>]`: The label associated with Category 5
        - `[Category6 <String>]`: The label associated with Category 6
      - `[SharedWith <IMicrosoftGraphPlannerUserIds>]`: plannerUserIds
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Owner <String>]`: ID of the Group that owns the plan. A valid group must exist before this field can be set. After it is set, this property can’t be updated.
    - `[Task <IMicrosoftGraphPlannerTask1[]>]`: Collection of tasks in the plan. Read-only. Nullable.
    - `[Title <String>]`: Required. Title of the plan.
  - `[Task <IMicrosoftGraphPlannerTask1[]>]`: Read-only. Nullable. Returns the plannerTasks assigned to the user.

PRESENCE <IMicrosoftGraphPresence>: presence
  - `[Id <String>]`: Read-only.
  - `[Activity <String>]`: The supplemental information to a user's availability. Possible values are Available, Away, BeRightBack, Busy, DoNotDisturb, InACall, InAConferenceCall, Inactive,InAMeeting, Offline, OffWork,OutOfOffice, PresenceUnknown,Presenting, UrgentInterruptionsOnly.
  - `[Availability <String>]`: The base presence information for a user. Possible values are Available, AvailableIdle,  Away, BeRightBack, Busy, BusyIdle, DoNotDisturb, Offline, PresenceUnknown

SETTING <IMicrosoftGraphUserSettings1>: userSettings
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Read-only.
  - `[ContributionToContentDiscoveryAsOrganizationDisabled <Boolean?>]`: Reflects the Office Delve organization level setting. When set to true, the organization doesn't have access to Office Delve. This setting is read-only and can only be changed by administrators in the SharePoint admin center.
  - `[ContributionToContentDiscoveryDisabled <Boolean?>]`: When set to true, documents in the user's Office Delve are disabled. Users can control this setting in Office Delve.
  - `[ShiftPreference <IMicrosoftGraphShiftPreferences1>]`: shiftPreferences
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
    - `[LastModifiedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Application <IMicrosoftGraphIdentity1>]`: identity
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
        - `[Id <String>]`: Unique identifier for the identity.
      - `[Device <IMicrosoftGraphIdentity1>]`: identity
      - `[User <IMicrosoftGraphIdentity1>]`: identity
    - `[LastModifiedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
    - `[Id <String>]`: Read-only.
    - `[Availability <IMicrosoftGraphShiftAvailability1[]>]`: Availability of the user to be scheduled for work and its recurrence pattern.
      - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Pattern <IMicrosoftGraphRecurrencePattern1>]`: recurrencePattern
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DayOfMonth <Int32?>]`: The day of the month on which the event occurs. Required if type is absoluteMonthly or absoluteYearly.
          - `[DaysOfWeek <String[]>]`: A collection of the days of the week on which the event occurs. Possible values are: sunday, monday, tuesday, wednesday, thursday, friday, saturday. If type is relativeMonthly or relativeYearly, and daysOfWeek specifies more than one day, the event falls on the first day that satisfies the pattern.  Required if type is weekly, relativeMonthly, or relativeYearly.
          - `[FirstDayOfWeek <String>]`: dayOfWeek
          - `[Index <String>]`: weekIndex
          - `[Interval <Int32?>]`: The number of units between occurrences, where units can be in days, weeks, months, or years, depending on the type. Required.
          - `[Month <Int32?>]`: The month in which the event occurs.  This is a number from 1 to 12.
          - `[Type <String>]`: recurrencePatternType
        - `[Range <IMicrosoftGraphRecurrenceRange1>]`: recurrenceRange
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[EndDate <DateTime?>]`: The date to stop applying the recurrence pattern. Depending on the recurrence pattern of the event, the last occurrence of the meeting may not be this date. Required if type is endDate.
          - `[NumberOfOccurrence <Int32?>]`: The number of times to repeat the event. Required and must be positive if type is numbered.
          - `[RecurrenceTimeZone <String>]`: Time zone for the startDate and endDate properties. Optional. If not specified, the time zone of the event is used.
          - `[StartDate <DateTime?>]`: The date to start applying the recurrence pattern. The first occurrence of the meeting may be this date or later, depending on the recurrence pattern of the event. Must be the same value as the start property of the recurring event. Required.
          - `[Type <String>]`: recurrenceRangeType
      - `[TimeSlot <IMicrosoftGraphTimeRange1[]>]`: The time slot(s) preferred by the user.
        - `[EndTime <String>]`: End time for the time range.
        - `[StartTime <String>]`: Start time for the time range.
      - `[TimeZone <String>]`: Specifies the time zone for the indicated time.

TEAMWORK <IMicrosoftGraphUserTeamwork>: userTeamwork
  - `[Id <String>]`: Read-only.
  - `[InstalledApp <IMicrosoftGraphUserScopeTeamsAppInstallation1[]>]`: The apps installed in the personal scope of this user.
    - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Id <String>]`: Read-only.
      - `[AppDefinition <IMicrosoftGraphTeamsAppDefinition1[]>]`: The details for each version of the app.
        - `[Id <String>]`: Read-only.
        - `[Bot <IMicrosoftGraphTeamworkBot1>]`: teamworkBot
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Id <String>]`: Read-only.
        - `[CreatedBy <IMicrosoftGraphIdentitySet1>]`: identitySet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Application <IMicrosoftGraphIdentity1>]`: identity
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
            - `[Id <String>]`: Unique identifier for the identity.
          - `[Device <IMicrosoftGraphIdentity1>]`: identity
          - `[User <IMicrosoftGraphIdentity1>]`: identity
        - `[Description <String>]`: Verbose description of the application.
        - `[DisplayName <String>]`: The name of the app provided by the app developer.
        - `[LastModifiedDateTime <DateTime?>]`: 
        - `[PublishingState <String>]`: teamsAppPublishingState
        - `[ShortDescription <String>]`: Short description of the application.
        - `[TeamsAppId <String>]`: The ID from the Teams app manifest.
        - `[Version <String>]`: The version number of the application.
      - `[DisplayName <String>]`: The name of the catalog app provided by the app developer in the Microsoft Teams zip app package.
      - `[DistributionMethod <String>]`: teamsAppDistributionMethod
      - `[ExternalId <String>]`: The ID of the catalog provided by the app developer in the Microsoft Teams zip app package.
    - `[TeamsAppDefinition <IMicrosoftGraphTeamsAppDefinition1>]`: teamsAppDefinition
    - `[Id <String>]`: Read-only.
    - `[ChatCreatedDateTime <DateTime?>]`: Date and time at which the chat was created. Read-only.
    - `[ChatId <String>]`: Read-only.
    - `[ChatInstalledApp <IMicrosoftGraphTeamsAppInstallation1[]>]`: A collection of all the apps in the chat. Nullable.
      - `[Id <String>]`: Read-only.
      - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
      - `[TeamsAppDefinition <IMicrosoftGraphTeamsAppDefinition1>]`: teamsAppDefinition
    - `[ChatLastUpdatedDateTime <DateTime?>]`: Date and time at which the chat was renamed or list of members were last changed. Read-only.
    - `[ChatMember <IMicrosoftGraphConversationMember1[]>]`: A collection of all the members in the chat. Nullable.
      - `[Id <String>]`: Read-only.
      - `[DisplayName <String>]`: The display name of the user.
      - `[Role <String[]>]`: The roles for that user.
      - `[VisibleHistoryStartDateTime <DateTime?>]`: The timestamp denoting how far back a conversation's history is shared with the conversation member. This property is settable only for members of a chat.
    - `[ChatMessage <IMicrosoftGraphChatMessage1[]>]`: A collection of all the messages in the chat. Nullable.
      - `[Id <String>]`: Read-only.
      - `[Attachment <IMicrosoftGraphChatMessageAttachment1[]>]`: Attached files. Attachments are currently read-only – sending attachments is not supported.
        - `[Content <String>]`: The content of the attachment. If the attachment is a rich card, set the property to the rich card object. This property and contentUrl are mutually exclusive.
        - `[ContentType <String>]`: The media type of the content attachment. It can have the following values: reference: Attachment is a link to another file. Populate the contentURL with the link to the object.Any contentTypes supported by the Bot Framework's Attachment objectapplication/vnd.microsoft.card.codesnippet: A code snippet. application/vnd.microsoft.card.announcement: An announcement header.
        - `[ContentUrl <String>]`: URL for the content of the attachment. Supported protocols: http, https, file and data.
        - `[Id <String>]`: Read-only. Unique id of the attachment.
        - `[Name <String>]`: Name of the attachment.
        - `[ThumbnailUrl <String>]`: URL to a thumbnail image that the channel can use if it supports using an alternative, smaller form of content or contentUrl. For example, if you set contentType to application/word and set contentUrl to the location of the Word document, you might include a thumbnail image that represents the document. The channel could display the thumbnail image instead of the document. When the user clicks the image, the channel would open the document.
      - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Content <String>]`: The content of the item.
        - `[ContentType <String>]`: bodyType
      - `[ChannelIdentity <IMicrosoftGraphChannelIdentity1>]`: channelIdentity
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ChannelId <String>]`: The identity of the channel in which the message was posted.
        - `[TeamId <String>]`: The identity of the team in which the message was posted.
      - `[ChatId <String>]`: If the message was sent in a chat, represents the identity of the chat.
      - `[CreatedDateTime <DateTime?>]`: Timestamp of when the chat message was created.
      - `[DeletedDateTime <DateTime?>]`: Read only. Timestamp at which the chat message was deleted, or null if not deleted.
      - `[Etag <String>]`: Read-only. Version number of the chat message.
      - `[From <IMicrosoftGraphChatMessageFromIdentitySet1>]`: chatMessageFromIdentitySet
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Application <IMicrosoftGraphIdentity1>]`: identity
        - `[Device <IMicrosoftGraphIdentity1>]`: identity
        - `[User <IMicrosoftGraphIdentity1>]`: identity
      - `[HostedContent <IMicrosoftGraphChatMessageHostedContent1[]>]`: Content in a message hosted by Microsoft Teams - for example, images or code snippets.
        - `[ContentByte <Byte[]>]`: Write only. Bytes for the hosted content (such as images).
        - `[ContentType <String>]`: Write only. Content type, such as image/png, image/jpg.
        - `[Id <String>]`: Read-only.
      - `[Importance <String>]`: chatMessageImportance
      - `[LastEditedDateTime <DateTime?>]`: Read only. Timestamp when edits to the chat message were made. Triggers an 'Edited' flag in the Teams UI. If no edits are made the value is null.
      - `[LastModifiedDateTime <DateTime?>]`: Read only. Timestamp when the chat message is created (initial setting) or modified, including when a reaction is added or removed.
      - `[Locale <String>]`: Locale of the chat message set by the client. Always set to en-us.
      - `[Mention <IMicrosoftGraphChatMessageMention1[]>]`: List of entities mentioned in the chat message. Currently supports user, bot, team, channel.
        - `[Id <Int32?>]`: Index of an entity being mentioned in the specified chatMessage. Matches the {index} value in the corresponding <at id='{index}'> tag in the message body.
        - `[MentionText <String>]`: String used to represent the mention. For example, a user's display name, a team name.
        - `[Mentioned <IMicrosoftGraphChatMessageMentionedIdentitySet1>]`: chatMessageMentionedIdentitySet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Application <IMicrosoftGraphIdentity1>]`: identity
          - `[Device <IMicrosoftGraphIdentity1>]`: identity
          - `[User <IMicrosoftGraphIdentity1>]`: identity
          - `[Conversation <IMicrosoftGraphTeamworkConversationIdentity1>]`: teamworkConversationIdentity
            - `[(Any) <Object>]`: This indicates any property can be added to this object.
            - `[DisplayName <String>]`: The identity's display name. Note that this may not always be available or up to date. For example, if a user changes their display name, the API may show the new value in a future response, but the items associated with the user won't show up as having changed when using delta.
            - `[Id <String>]`: Unique identifier for the identity.
            - `[ConversationIdentityType <String>]`: teamworkConversationIdentityType
      - `[MessageType <String>]`: chatMessageType
      - `[PolicyViolation <IMicrosoftGraphChatMessagePolicyViolation1>]`: chatMessagePolicyViolation
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DlpAction <String>]`: chatMessagePolicyViolationDlpActionTypes
        - `[JustificationText <String>]`: Justification text provided by the sender of the message when overriding a policy violation.
        - `[PolicyTip <IMicrosoftGraphChatMessagePolicyViolationPolicyTip1>]`: chatMessagePolicyViolationPolicyTip
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[ComplianceUrl <String>]`: The URL a user can visit to read about the data loss prevention policies for the organization. (ie, policies about what users shouldn't say in chats)
          - `[GeneralText <String>]`: Explanatory text shown to the sender of the message.
          - `[MatchedConditionDescription <String[]>]`: The list of improper data in the message that was detected by the data loss prevention app. Each DLP app defines its own conditions, examples include 'Credit Card Number' and 'Social Security Number'.
        - `[UserAction <String>]`: chatMessagePolicyViolationUserActionTypes
        - `[VerdictDetail <String>]`: chatMessagePolicyViolationVerdictDetailsTypes
      - `[Reaction <IMicrosoftGraphChatMessageReaction1[]>]`: Reactions for this chat message (for example, Like).
        - `[CreatedDateTime <DateTime?>]`: The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
        - `[ReactionType <String>]`: Supported values are like, angry, sad, laugh, heart, surprised.
        - `[User <IMicrosoftGraphChatMessageReactionIdentitySet1>]`: chatMessageReactionIdentitySet
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Application <IMicrosoftGraphIdentity1>]`: identity
          - `[Device <IMicrosoftGraphIdentity1>]`: identity
          - `[User <IMicrosoftGraphIdentity1>]`: identity
      - `[Reply <IMicrosoftGraphChatMessage1[]>]`: Replies for a specified message.
      - `[ReplyToId <String>]`: Read-only. ID of the parent chat message or root chat message of the thread. (Only applies to chat messages in channels, not chats.)
      - `[Subject <String>]`: The subject of the chat message, in plaintext.
      - `[Summary <String>]`: Summary text of the chat message that could be used for push notifications and summary views or fall back views. Only applies to channel chat messages, not chat messages in a chat.
      - `[WebUrl <String>]`: Read-only. Link to the message in Microsoft Teams.
    - `[ChatTab <IMicrosoftGraphTeamsTab1[]>]`: 
      - `[Id <String>]`: Read-only.
      - `[Configuration <IMicrosoftGraphTeamsTabConfiguration1>]`: teamsTabConfiguration
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[ContentUrl <String>]`: Url used for rendering tab contents in Teams. Required.
        - `[EntityId <String>]`: Identifier for the entity hosted by the tab provider.
        - `[RemoveUrl <String>]`: Url called by Teams client when a Tab is removed using the Teams Client.
        - `[WebsiteUrl <String>]`: Url for showing tab contents outside of Teams.
      - `[DisplayName <String>]`: Name of the tab.
      - `[TeamsApp <IMicrosoftGraphTeamsApp1>]`: teamsApp
      - `[WebUrl <String>]`: Deep link URL of the tab instance. Read only.
    - `[ChatTopic <String>]`: (Optional) Subject or topic for the chat. Only available for group chats.
    - `[ChatType <String>]`: chatType

TODO <IMicrosoftGraphTodo1>: todo
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Read-only.
  - `[List <IMicrosoftGraphTodoTaskList1[]>]`: The task lists in the users mailbox.
    - `[Id <String>]`: Read-only.
    - `[DisplayName <String>]`: The name of the task list.
    - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the task list. Nullable.
      - `[Id <String>]`: Read-only.
    - `[IsOwner <Boolean?>]`: True if the user is owner of the given task list.
    - `[IsShared <Boolean?>]`: True if the task list is shared with other users
    - `[Task <IMicrosoftGraphTodoTask1[]>]`: The tasks in this task list. Read-only. Nullable.
      - `[Id <String>]`: Read-only.
      - `[Body <IMicrosoftGraphItemBody1>]`: itemBody
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Content <String>]`: The content of the item.
        - `[ContentType <String>]`: bodyType
      - `[BodyLastModifiedDateTime <DateTime?>]`: The date and time when the task was last modified. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
      - `[CompletedDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[DateTime <String>]`: A single point of time in a combined date and time representation ({date}T{time}). For example, '2019-04-16T09:00:00'.
        - `[TimeZone <String>]`: Represents a time zone, for example, 'Pacific Standard Time'. See below for possible values.
      - `[CreatedDateTime <DateTime?>]`: The date and time when the task was created. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
      - `[DueDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
      - `[Extension <IMicrosoftGraphExtension1[]>]`: The collection of open extensions defined for the task. Nullable.
      - `[Importance <String>]`: importance
      - `[IsReminderOn <Boolean?>]`: Set to true if an alert is set to remind the user of the task.
      - `[LastModifiedDateTime <DateTime?>]`: The date and time when the task was last modified. By default, it is in UTC. You can provide a custom time zone in the request header. The property value uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2020 would look like this: '2020-01-01T00:00:00Z'.
      - `[LinkedResource <IMicrosoftGraphLinkedResource1[]>]`: A collection of resources linked to the task.
        - `[Id <String>]`: Read-only.
        - `[ApplicationName <String>]`: Field indicating the app name of the source that is sending the linkedResource.
        - `[DisplayName <String>]`: Field indicating the title of the linkedResource.
        - `[ExternalId <String>]`: Id of the object that is associated with this task on the third-party/partner system.
        - `[WebUrl <String>]`: Deep link to the linkedResource.
      - `[Recurrence <IMicrosoftGraphPatternedRecurrence1>]`: patternedRecurrence
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Pattern <IMicrosoftGraphRecurrencePattern1>]`: recurrencePattern
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[DayOfMonth <Int32?>]`: The day of the month on which the event occurs. Required if type is absoluteMonthly or absoluteYearly.
          - `[DaysOfWeek <String[]>]`: A collection of the days of the week on which the event occurs. Possible values are: sunday, monday, tuesday, wednesday, thursday, friday, saturday. If type is relativeMonthly or relativeYearly, and daysOfWeek specifies more than one day, the event falls on the first day that satisfies the pattern.  Required if type is weekly, relativeMonthly, or relativeYearly.
          - `[FirstDayOfWeek <String>]`: dayOfWeek
          - `[Index <String>]`: weekIndex
          - `[Interval <Int32?>]`: The number of units between occurrences, where units can be in days, weeks, months, or years, depending on the type. Required.
          - `[Month <Int32?>]`: The month in which the event occurs.  This is a number from 1 to 12.
          - `[Type <String>]`: recurrencePatternType
        - `[Range <IMicrosoftGraphRecurrenceRange1>]`: recurrenceRange
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[EndDate <DateTime?>]`: The date to stop applying the recurrence pattern. Depending on the recurrence pattern of the event, the last occurrence of the meeting may not be this date. Required if type is endDate.
          - `[NumberOfOccurrence <Int32?>]`: The number of times to repeat the event. Required and must be positive if type is numbered.
          - `[RecurrenceTimeZone <String>]`: Time zone for the startDate and endDate properties. Optional. If not specified, the time zone of the event is used.
          - `[StartDate <DateTime?>]`: The date to start applying the recurrence pattern. The first occurrence of the meeting may be this date or later, depending on the recurrence pattern of the event. Must be the same value as the start property of the recurring event. Required.
          - `[Type <String>]`: recurrenceRangeType
      - `[ReminderDateTime <IMicrosoftGraphDateTimeZone1>]`: dateTimeTimeZone
      - `[Status <String>]`: taskStatus
      - `[Title <String>]`: A brief description of the task.
    - `[WellknownListName <String>]`: wellknownListName

TRANSITIVEMEMBEROF <IMicrosoftGraphDirectoryObject[]>: .
  - `[Id <String>]`: Read-only.
  - `[DeletedDateTime <DateTime?>]`: 

## RELATED LINKS

