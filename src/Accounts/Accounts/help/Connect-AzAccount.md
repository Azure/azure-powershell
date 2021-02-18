---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.accounts/connect-azaccount
=======
online version: https://docs.microsoft.com/powershell/module/az.accounts/connect-azaccount
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Connect-AzAccount

## SYNOPSIS
<<<<<<< HEAD
Connect to Azure with an authenticated account for use with Azure Resource Manager cmdlet requests.
=======
Connect to Azure with an authenticated account for use with cmdlets from the Az PowerShell modules.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## SYNTAX

### UserWithSubscriptionId (Default)
```
Connect-AzAccount [-Environment <String>] [-Tenant <String>] [-Subscription <String>] [-ContextName <String>]
<<<<<<< HEAD
 [-SkipContextPopulation] [-UseDeviceAuthentication] [-Force] [-Scope <ContextModificationScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
=======
 [-SkipContextPopulation] [-MaxContextPopulation <Int32>] [-UseDeviceAuthentication] [-Force]
 [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

### ServicePrincipalWithSubscriptionId
```
Connect-AzAccount [-Environment <String>] -Credential <PSCredential> [-ServicePrincipal] -Tenant <String>
<<<<<<< HEAD
 [-Subscription <String>] [-ContextName <String>] [-SkipContextPopulation] [-Force]
 [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
=======
 [-Subscription <String>] [-ContextName <String>] [-SkipContextPopulation] [-MaxContextPopulation <Int32>]
 [-Force] [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
 [<CommonParameters>]
```

### UserWithCredential
```
Connect-AzAccount [-Environment <String>] -Credential <PSCredential> [-Tenant <String>]
<<<<<<< HEAD
 [-Subscription <String>] [-ContextName <String>] [-SkipContextPopulation] [-Force]
 [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
=======
 [-Subscription <String>] [-ContextName <String>] [-SkipContextPopulation] [-MaxContextPopulation <Int32>]
 [-Force] [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
 [<CommonParameters>]
```

### ServicePrincipalCertificateWithSubscriptionId
```
Connect-AzAccount [-Environment <String>] -CertificateThumbprint <String> -ApplicationId <String>
 [-ServicePrincipal] -Tenant <String> [-Subscription <String>] [-ContextName <String>] [-SkipContextPopulation]
<<<<<<< HEAD
 [-Force] [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
=======
 [-MaxContextPopulation <Int32>] [-Force] [-Scope <ContextModificationScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

### AccessTokenWithSubscriptionId
```
Connect-AzAccount [-Environment <String>] [-Tenant <String>] -AccessToken <String> [-GraphAccessToken <String>]
 [-KeyVaultAccessToken <String>] -AccountId <String> [-Subscription <String>] [-ContextName <String>]
<<<<<<< HEAD
 [-SkipValidation] [-SkipContextPopulation] [-Force] [-Scope <ContextModificationScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
=======
 [-SkipValidation] [-SkipContextPopulation] [-MaxContextPopulation <Int32>] [-Force]
 [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

### ManagedServiceLogin
```
Connect-AzAccount [-Environment <String>] [-Tenant <String>] [-AccountId <String>] [-Identity]
 [-ManagedServicePort <Int32>] [-ManagedServiceHostName <String>] [-ManagedServiceSecret <SecureString>]
<<<<<<< HEAD
 [-Subscription <String>] [-ContextName <String>] [-SkipContextPopulation] [-Force]
 [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
=======
 [-Subscription <String>] [-ContextName <String>] [-SkipContextPopulation] [-MaxContextPopulation <Int32>]
 [-Force] [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
 [<CommonParameters>]
```

## DESCRIPTION
<<<<<<< HEAD
The Connect-AzAccount cmdlet connects to Azure with an authenticated account for use with Azure Resource Manager cmdlet requests.
You can use this authenticated account only with Azure Resource Manager cmdlets.
To add an authenticated account for use with Service Management cmdlets, use the Add-AzAccount or the Import-AzPublishSettingsFile cmdlet.
If no context is found for the current user, this command will populate the user's context list with a context for each of their (first 25) subscriptions. The list of contexts created for the user can be found by running "Get-AzContext -ListAvailable". To skip this context population, you can run this command with the "-SkipContextPopulation" switch parameter.
After executing this cmdlet, you can disconnect from an Azure account using Disconnect-AzAccount.

## EXAMPLES

### Example 1: Use an interactive login to connect to an Azure account
```powershell
PS C:\> Connect-AzAccount

=======

The `Connect-AzAccount` cmdlet connects to Azure with an authenticated account for use with cmdlets
from the Az PowerShell modules. You can use this authenticated account only with Azure Resource
Manager requests. To add an authenticated account for use with Service Management, use the
`Add-AzureAccount` cmdlet from the Azure PowerShell module. If no context is found for the current
user, the user's context list is populated with a context for each of their first 25 subscriptions.
The list of contexts created for the user can be found by running `Get-AzContext -ListAvailable`. To
skip this context population, specify the **SkipContextPopulation** switch parameter. After
executing this cmdlet, you can disconnect from an Azure account using `Disconnect-AzAccount`.

## EXAMPLES

### Example 1: Connect to an Azure account

This example connects to an Azure account. You must provide a Microsoft account or organizational ID
credentials. If multi-factor authentication is enabled for your credentials, you must log in using
the interactive option or use service principal authentication.

```powershell
Connect-AzAccount
```

```Output
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Account                SubscriptionName TenantId                Environment
-------                ---------------- --------                -----------
azureuser@contoso.com  Subscription1    xxxx-xxxx-xxxx-xxxx     AzureCloud
```

<<<<<<< HEAD
This command connects to an Azure account.
To run Azure Resource Manager cmdlets with this account, you must provide Microsoft account or organizational ID credentials at the prompt.
If multi-factor authentication is enabled for your credentials, you must log in using the interactive option or use service principal authentication.

### Example 2: (Windows PowerShell 5.1 only) Connect to an Azure account using organizational ID credentials
```powershell
PS C:\> $Credential = Get-Credential
PS C:\> Connect-AzAccount -Credential $Credential

=======
### Example 2: (Windows PowerShell 5.1 only) Connect to Azure using organizational ID credentials

This scenario works only in Windows PowerShell 5.1. The first command prompts for user credentials
and stores them in the `$Credential` variable. The second command connects to an Azure account using
the credentials stored in `$Credential`. This account authenticates with Azure using organizational
ID credentials.

```powershell
$Credential = Get-Credential
Connect-AzAccount -Credential $Credential
```

```Output
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Account                SubscriptionName TenantId                Environment
-------                ---------------- --------                -----------
azureuser@contoso.com  Subscription1    xxxx-xxxx-xxxx-xxxx     AzureCloud
```

<<<<<<< HEAD
This scenario works only in Windows PowerShell 5.1. The first command will prompt for user credentials (username and password), and then stores them in the $Credential variable.
The second command connects to an Azure account using the credentials stored in $Credential.
This account authenticates with Azure Resource Manager using organizational ID credentials.
You cannot use multi-factor authentication or Microsoft account credentials to run Azure Resource Manager cmdlets with this account.

### Example 3: Connect to an Azure service principal account
```powershell
PS C:\> $Credential = Get-Credential
PS C:\> Connect-AzAccount -Credential $Credential -Tenant "xxxx-xxxx-xxxx-xxxx" -ServicePrincipal

=======
### Example 3: Connect to Azure using a service principal account

The first command prompts for service principal credentials and stores them in the `$Credential`
variable. Enter your application ID for the username and service principal secret as the password
when prompted. The second command connects the specified Azure tenant using the service principal
credentials stored in the `$Credential` variable. The **ServicePrincipal** switch parameter
indicates that the account authenticates as a service principal.

```powershell
$Credential = Get-Credential
Connect-AzAccount -Credential $Credential -Tenant 'xxxx-xxxx-xxxx-xxxx' -ServicePrincipal
```

```Output
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Account                SubscriptionName TenantId                Environment
-------                ---------------- --------                -----------
xxxx-xxxx-xxxx-xxxx    Subscription1    xxxx-xxxx-xxxx-xxxx     AzureCloud
```

<<<<<<< HEAD
The first command gets the service principal credentials (application id and service principal secret), and then stores them in the $Credential variable.
The second command connect to Azure using the service principal credentials stored in $Credential for the specified Tenant.
The ServicePrincipal switch parameter indicates that the account authenticates as a service principal.

### Example 4: Use an interactive login to connect to an account for a specific tenant and subscription
```powershell
PS C:\> Connect-AzAccount -Tenant "xxxx-xxxx-xxxx-xxxx" -SubscriptionId "yyyy-yyyy-yyyy-yyyy"

=======
### Example 4: Use an interactive login to connect to a specific tenant and subscription

This example connects to an Azure account with the specified tenant and subscription.

```powershell
Connect-AzAccount -Tenant 'xxxx-xxxx-xxxx-xxxx' -SubscriptionId 'yyyy-yyyy-yyyy-yyyy'
```

```Output
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Account                SubscriptionName TenantId                Environment
-------                ---------------- --------                -----------
azureuser@contoso.com  Subscription1    xxxx-xxxx-xxxx-xxxx     AzureCloud
```

<<<<<<< HEAD
This command connects to an Azure account and configured AzureRM PowerShell to run cmdlets for the specified tenant and subscription by default.

### Example 5: Add an Account Using Managed Service Identity Login
```powershell
PS C:\> Connect-AzAccount -Identity

=======
### Example 5: Connect using a Managed Service Identity

This example connects using the Managed Service Identity (MSI) of the host environment. For example,
you sign into Azure from a virtual machine that has an assigned MSI.

```powershell
Connect-AzAccount -Identity
```

```Output
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Account                SubscriptionName TenantId                Environment
-------                ---------------- --------                -----------
MSI@50342              Subscription1    xxxx-xxxx-xxxx-xxxx     AzureCloud
```

<<<<<<< HEAD
This command connects using the managed service identity of the host environment (for example, if executed on a
VirtualMachine with an assigned Managed Service Identity, this will allow the code to login using that assigned identity)

### Example 6: Add an Account Using Managed Service Identity Login and ClientId
```powershell
PS C:\> $identity = Get-AzUserAssignedIdentity -ResourceGroupName "myResourceGroup" -Name "myUserAssignedIdentity"
PS C:\> Get-AzVM -ResourceGroupName contoso -Name testvm | Update-AzVM -IdentityType UserAssigned -IdentityId $identity.Id
PS C:\> Connect-AzAccount -Identity -AccountId $identity.ClientId # Run on the "testvm" virtual machine

Account                SubscriptionName TenantId                Environment
-------                ---------------- --------                -----------
yyyy-yyyy-yyyy-yyyy    Subscription1    xxxx-xxxx-xxxx-xxxx     AzureCloud
```

This command connects using the managed service identity of "myUserAssignedIdentity" by adding the User Assigned Identity to the Virtual Machine, then connecting using the ClientId of the User Assigned Identity.
More information about configuring Managed Identities can be found here: https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/qs-configure-powershell-windows-vm.

### Example 7: Add an Account Using Managed Service Identity Login and ClientId
```powershell
PS C:\> $identity = Get-AzUserAssignedIdentity -ResourceGroupName "myResourceGroup" -Name "myUserAssignedIdentity"
PS C:\> Get-AzVM -ResourceGroupName contoso -Name testvm | Update-AzVM -IdentityType UserAssigned -IdentityId $identity.Id
PS C:\> Connect-AzAccount -Identity -AccountId $identity.Id # Run on the "testvm" virtual machine

=======
### Example 6: Connect using Managed Service Identity login and ClientId

This example connects using the Managed Service Identity of **myUserAssignedIdentity**. It adds the
user assigned identity to the virtual machine, then connects using the ClientId of the user assigned
identity. For more information, see
[Configure managed identities for Azure resources on an Azure VM](/azure/active-directory/managed-identities-azure-resources/qs-configure-powershell-windows-vm).

```powershell
$identity = Get-AzUserAssignedIdentity -ResourceGroupName 'myResourceGroup' -Name 'myUserAssignedIdentity'
Get-AzVM -ResourceGroupName contoso -Name testvm | Update-AzVM -IdentityType UserAssigned -IdentityId $identity.Id
Connect-AzAccount -Identity -AccountId $identity.ClientId # Run on the virtual machine
```

```Output
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Account                SubscriptionName TenantId                Environment
-------                ---------------- --------                -----------
yyyy-yyyy-yyyy-yyyy    Subscription1    xxxx-xxxx-xxxx-xxxx     AzureCloud
```

<<<<<<< HEAD
This command connects using the managed service identity of "myUserAssignedIdentity" by adding the User Assigned Identity to the Virtual Machine, then connecting using the Id of the User Assigned Identity.
More information about configuring Managed Identities can be found here: https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/qs-configure-powershell-windows-vm.

### Example 8: Add an account using certificates
```powershell
# For more information on creating a self-signed certificate
# and giving it proper permissions, please see the following:
# https://docs.microsoft.com/en-us/azure/active-directory/develop/howto-authenticate-service-principal-powershell
PS C:\> $Thumbprint = "0SZTNJ34TCCMUJ5MJZGR8XQD3S0RVHJBA33Z8ZXV"
PS C:\> $TenantId = "4cd76576-b611-43d0-8f2b-adcb139531bf"
PS C:\> $ApplicationId = "3794a65a-e4e4-493d-ac1d-f04308d712dd"
PS C:\> Connect-AzAccount -CertificateThumbprint $Thumbprint -ApplicationId $ApplicationId -Tenant $TenantId -ServicePrincipal

=======
### Example 7: Connect using certificates

This example connects to an Azure account using certificate-based service principal authentication.
The service principal used for authentication must be created with the specified certificate. For
more information on creating a self-signed certificates and assigning them permissions, see
[Use Azure PowerShell to create a service principal with a certificate](/azure/active-directory/develop/howto-authenticate-service-principal-powershell)

```powershell
$Thumbprint = '0SZTNJ34TCCMUJ5MJZGR8XQD3S0RVHJBA33Z8ZXV'
$TenantId = '4cd76576-b611-43d0-8f2b-adcb139531bf'
$ApplicationId = '3794a65a-e4e4-493d-ac1d-f04308d712dd'
Connect-AzAccount -CertificateThumbprint $Thumbprint -ApplicationId $ApplicationId -Tenant $TenantId -ServicePrincipal
```

```Output
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Account             SubscriptionName TenantId            Environment
-------             ---------------- --------            -----------
xxxx-xxxx-xxxx-xxxx Subscription1    xxxx-xxxx-xxxx-xxxx AzureCloud

Account          : 3794a65a-e4e4-493d-ac1d-f04308d712dd
SubscriptionName : MyTestSubscription
SubscriptionId   : 85f0f653-1f86-4d2c-a9f1-042efc00085c
TenantId         : 4cd76576-b611-43d0-8f2b-adcb139531bf
Environment      : AzureCloud
```

<<<<<<< HEAD
This command connects to an Azure account using certificate-based service principal authentication. The service principal used for authentication should have been created with the given certificate.

### Example 9: Add an account using AccessToken authentication
```powershell
PS C:\> $url = "https://login.windows.net/<TenantId>/oauth2/token"
PS C:\> $body = "grant_type=refresh_token&refresh_token=<refreshtoken>" # Refresh token obtained from ~/.azure/TokenCache.dat
PS C:\> $response = Invoke-RestMethod $url -Method POST -Body $body
PS C:\> $AccessToken = $response.access_token
PS C:\> $body1 = $body + "&resource=https%3A%2F%2Fvault.azure.net"
PS C:\> $response = Invoke-RestMethod $url -Method POST -Body $body1
PS C:\> $body2 = $body + "&resource=https%3A%2F%2Fgraph.windows.net"
PS C:\> $GraphAccessToken = $response.access_token
PS C:\> Connect-AzAccount -AccountId "azureuser@contoso.com" -AccessToken $AccessToken -KeyVaultAccessToken $KeyVaultAccessToken -GraphAccessToken $GraphAccessToken -Tenant "xxxx-xxxx-xxxx-xxxx" -SubscriptionId "yyyy-yyyy-yyyy-yyyy"

Account                SubscriptionName TenantId                Environment
-------                ---------------- --------                -----------
azureuser@contoso.com  Subscription1    xxxx-xxxx-xxxx-xxxx     AzureCloud
```

This command connects to an Azure account specified in "AccountId" using the AccessToken and KeyVaultAccessToken provided.

## PARAMETERS

### -AccessToken
Specifies an access token.

=======
## PARAMETERS

### -AccessToken

Specifies an access token.

> [!CAUTION]
> Access tokens are a type of credential. You should take the appropriate security precautions to
> keep them confidential. Access tokens also timeout and may prevent long running tasks from
> completing.

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```yaml
Type: System.String
Parameter Sets: AccessTokenWithSubscriptionId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccountId
<<<<<<< HEAD
Account Id for access token in AccessToken parameter set. 
Account Id for managed service in ManagedService parameter set. Can be a managed service resource Id, or the associated client id. To use the SystemAssigned identity, leave this field blank.
=======

Account ID for access token in **AccessToken** parameter set. Account ID for managed service in
**ManagedService** parameter set. Can be a managed service resource ID, or the associated client ID.
To use the system assigned identity, leave this field blank.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: AccessTokenWithSubscriptionId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ManagedServiceLogin
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationId
<<<<<<< HEAD
SPN
=======

Application ID of the service principal.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: ServicePrincipalCertificateWithSubscriptionId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateThumbprint
<<<<<<< HEAD
Certificate Hash (Thumbprint)
=======

Certificate Hash or Thumbprint.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: ServicePrincipalCertificateWithSubscriptionId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContextName
<<<<<<< HEAD
Name of the default context from this login.  You will be able to select this context by this name after login.
=======

Name of the default Azure context for this login. For more information about Azure contexts, see
[Azure PowerShell context objects](/powershell/azure/context-persistence).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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

### -Credential
<<<<<<< HEAD
Specifies a PSCredential object.
For more information about the PSCredential object, type Get-Help Get-Credential.
The PSCredential object provides the user ID and password for organizational ID credentials, or the application ID and secret for service principal credentials.
=======

Specifies a **PSCredential** object. For more information about the **PSCredential** object, type
`Get-Help Get-Credential`. The **PSCredential** object provides the user ID and password for
organizational ID credentials, or the application ID and secret for service principal credentials.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: ServicePrincipalWithSubscriptionId, UserWithCredential
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
<<<<<<< HEAD
The credentials, account, tenant, and subscription used for communication with azure.
=======

The credentials, account, tenant, and subscription used for communication with Azure.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Environment
<<<<<<< HEAD
Environment containing the account to log into
=======

Environment containing the Azure account.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: EnvironmentName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
<<<<<<< HEAD
Overwrite the existing context with the same name, if any.
=======

Overwrite the existing context with the same name without prompting.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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

### -GraphAccessToken
<<<<<<< HEAD
AccessToken for Graph Service
=======

AccessToken for Graph Service.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: AccessTokenWithSubscriptionId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
<<<<<<< HEAD
Login using managed service identity in the current environment.
=======

Login using a Managed Service Identity.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ManagedServiceLogin
Aliases: MSI, ManagedService

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultAccessToken
<<<<<<< HEAD
AccessToken for KeyVault Service
=======

AccessToken for KeyVault Service.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: AccessTokenWithSubscriptionId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedServiceHostName
<<<<<<< HEAD
Host name for managed service login
=======

Obsolete. To use customized MSI endpoint, please set environment variable MSI_ENDPOINT, e.g. "http://localhost:50342/oauth2/token". Host name for the managed service.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: ManagedServiceLogin
Aliases:

Required: False
Position: Named
Default value: localhost
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedServicePort
<<<<<<< HEAD
Port number for managed service login
=======

Obsolete. To use customized MSI endpoint, please set environment variable MSI_ENDPOINT, e.g. "http://localhost:50342/oauth2/token".Port number for the managed service.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Int32
Parameter Sets: ManagedServiceLogin
Aliases:

Required: False
Position: Named
Default value: 50342
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedServiceSecret
<<<<<<< HEAD
Secret, used for some kinds of managed service login.
=======

Obsolete. To use customized MSI secret, please set environment variable MSI_SECRET. Token for the managed service login.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Security.SecureString
Parameter Sets: ManagedServiceLogin
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
### -Scope
Determines the scope of context changes, for example, whether changes apply only to the current process, or to all sessions started by this user.
=======
### -MaxContextPopulation

Max subscription number to populate contexts after login. Default is 25. To populate all subscriptions to contexts, set to -1.

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

### -Scope

Determines the scope of context changes, for example, whether changes apply only to the current
process, or to all sessions started by this user.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: Microsoft.Azure.Commands.Profile.Common.ContextModificationScope
Parameter Sets: (All)
Aliases:
Accepted values: Process, CurrentUser

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipal
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Indicates that this account authenticates by providing service principal credentials.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ServicePrincipalWithSubscriptionId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ServicePrincipalCertificateWithSubscriptionId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipContextPopulation
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Skips context population if no contexts are found.

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

### -SkipValidation
<<<<<<< HEAD
Skip validation for access token
=======

Skip validation for access token.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AccessTokenWithSubscriptionId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subscription
<<<<<<< HEAD
Subscription Name or ID
=======

Subscription Name or ID.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SubscriptionName, SubscriptionId

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Tenant
<<<<<<< HEAD
Optional tenant name or ID
=======

Optional tenant name or ID.

> [!NOTE]
> Due to limitations of the current API, you must use a tenant ID instead of a tenant name when
> connecting with a business-to-business (B2B) account.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: UserWithSubscriptionId, UserWithCredential, AccessTokenWithSubscriptionId, ManagedServiceLogin
Aliases: Domain, TenantId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ServicePrincipalWithSubscriptionId, ServicePrincipalCertificateWithSubscriptionId
Aliases: Domain, TenantId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseDeviceAuthentication
<<<<<<< HEAD
Use device code authentication instead of a browser control
=======

Use device code authentication instead of a browser control.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UserWithSubscriptionId
Aliases: DeviceCode, DeviceAuth, Device

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
<<<<<<< HEAD
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).
=======
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.Core.PSAzureProfile

## NOTES

## RELATED LINKS
