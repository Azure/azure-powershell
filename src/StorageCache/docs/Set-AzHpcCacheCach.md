---
external help file:
Module Name: HpcCache
online version: https://docs.microsoft.com/powershell/module/hpccache/set-azhpccachecach
schema: 2.0.0
---

# Set-AzHpcCacheCach

## SYNOPSIS
Create or update a Cache.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzHpcCacheCach -EName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-CacheSizeGb <Int32>] [-DirectoryServicesSetting <ICacheDirectorySettings>]
 [-IdentityType <CacheIdentityType>] [-KeyEncryptionKeyUrl <String>] [-Location <String>]
 [-NetworkSettingDnsSearchDomain <String>] [-NetworkSettingDnsServer <String[]>] [-NetworkSettingMtu <Int32>]
 [-NetworkSettingNtpServer <String>] [-ProvisioningState <ProvisioningStateType>]
 [-SecuritySettingAccessPolicy <INfsAccessPolicy[]>] [-SkuName <String>] [-SourceVaultId <String>]
 [-Subnet <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzHpcCacheCach -EName <String> -ResourceGroupName <String> -Cache <ICache> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a Cache.

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
```

### -Cache
A Cache instance.
Follows Azure Resource Manager standards: https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/resource-api-reference.md
To construct, see NOTES section for CACHE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.ICache
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CacheSizeGb
The size of this Cache, in GB.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
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

### -DirectoryServicesSetting
Specifies Directory Services settings of the cache.
To construct, see NOTES section for DIRECTORYSERVICESSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.ICacheDirectorySettings
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EName
Name of Cache.
Length of name must not be greater than 80 and chars must be from the [-0-9a-zA-Z_] char class.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CacheName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The type of identity used for the cache

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Support.CacheIdentityType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyEncryptionKeyUrl
The URL referencing a key encryption key in Key Vault.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Region name string.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSettingDnsSearchDomain
DNS search domain

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSettingDnsServer
DNS servers for the cache to use.
It will be set from the network configuration if no value is provided.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSettingMtu
The IPv4 maximum transmission unit configured for the subnet.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSettingNtpServer
NTP server IP Address or FQDN for the cache to use.
The default is time.windows.com.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### -ProvisioningState
ARM provisioning state, see https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/Addendum.md#provisioningstate-property

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Support.ProvisioningStateType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Target resource group.

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

### -SecuritySettingAccessPolicy
NFS access policies defined for this cache.
To construct, see NOTES section for SECURITYSETTINGACCESSPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.INfsAccessPolicy[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
SKU name for this Cache.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceVaultId
Resource Id.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subnet
Subnet used for the Cache.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
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

### Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.ICache

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.ICache

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CACHE <ICache>: A Cache instance. Follows Azure Resource Manager standards: https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/resource-api-reference.md
  - `[DirectoryServicesSetting <ICacheDirectorySettings>]`: Specifies Directory Services settings of the cache.
    - `[ActiveDirectoryCacheNetBiosName <String>]`: The NetBIOS name to assign to the HPC Cache when it joins the Active Directory domain as a server. Length must 1-15 characters from the class [-0-9a-zA-Z].
    - `[ActiveDirectoryDomainName <String>]`: The fully qualified domain name of the Active Directory domain controller.
    - `[ActiveDirectoryDomainNetBiosName <String>]`: The Active Directory domain's NetBIOS name.
    - `[ActiveDirectoryPrimaryDnsIPAddress <String>]`: Primary DNS IP address used to resolve the Active Directory domain controller's fully qualified domain name.
    - `[ActiveDirectorySecondaryDnsIPAddress <String>]`: Secondary DNS IP address used to resolve the Active Directory domain controller's fully qualified domain name.
    - `[CredentialsBindDn <String>]`: The Bind Distinguished Name identity to be used in the secure LDAP connection. This value is stored encrypted and not returned on response.
    - `[CredentialsBindPassword <String>]`: The Bind password to be used in the secure LDAP connection. This value is stored encrypted and not returned on response.
    - `[CredentialsPassword <String>]`: Plain text password of the Active Directory domain administrator. This value is stored encrypted and not returned on response.
    - `[CredentialsUsername <String>]`: Username of the Active Directory domain administrator. This value is stored encrypted and not returned on response.
    - `[UsernameDownloadAutoDownloadCertificate <Boolean?>]`: Determines if the certificate should be automatically downloaded. This applies to 'caCertificateURI' only if 'requireValidCertificate' is true.
    - `[UsernameDownloadCaCertificateUri <String>]`: The URI of the CA certificate to validate the LDAP secure connection. This field must be populated when 'requireValidCertificate' is set to true.
    - `[UsernameDownloadEncryptLdapConnection <Boolean?>]`: Whether or not the LDAP connection should be encrypted.
    - `[UsernameDownloadExtendedGroup <Boolean?>]`: Whether or not Extended Groups is enabled.
    - `[UsernameDownloadGroupFileUri <String>]`: The URI of the file containing group information (in /etc/group file format). This field must be populated when 'usernameSource' is set to 'File'.
    - `[UsernameDownloadLdapBaseDn <String>]`: The base distinguished name for the LDAP domain.
    - `[UsernameDownloadLdapServer <String>]`: The fully qualified domain name or IP address of the LDAP server to use.
    - `[UsernameDownloadRequireValidCertificate <Boolean?>]`: Determines if the certificates must be validated by a certificate authority. When true, caCertificateURI must be provided.
    - `[UsernameDownloadUserFileUri <String>]`: The URI of the file containing user information (in /etc/passwd file format). This field must be populated when 'usernameSource' is set to 'File'.
    - `[UsernameDownloadUsernameSource <UsernameSource?>]`: This setting determines how the cache gets username and group names for clients.
  - `[HealthState <HealthStateType?>]`: List of Cache health states.
  - `[HealthStatusDescription <String>]`: Describes explanation of state.
  - `[IdentityType <CacheIdentityType?>]`: The type of identity used for the cache
  - `[KeyEncryptionKeyUrl <String>]`: The URL referencing a key encryption key in Key Vault.
  - `[Location <String>]`: Region name string.
  - `[NetworkSettingDnsSearchDomain <String>]`: DNS search domain
  - `[NetworkSettingDnsServer <String[]>]`: DNS servers for the cache to use.  It will be set from the network configuration if no value is provided.
  - `[NetworkSettingMtu <Int32?>]`: The IPv4 maximum transmission unit configured for the subnet.
  - `[NetworkSettingNtpServer <String>]`: NTP server IP Address or FQDN for the cache to use. The default is time.windows.com.
  - `[ProvisioningState <ProvisioningStateType?>]`: ARM provisioning state, see https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/Addendum.md#provisioningstate-property
  - `[SecuritySettingAccessPolicy <INfsAccessPolicy[]>]`: NFS access policies defined for this cache.
    - `AccessRule <INfsAccessRule[]>`: The set of rules describing client accesses allowed under this policy.
      - `Access <NfsAccessRuleAccess>`: Access allowed by this rule.
      - `Scope <NfsAccessRuleScope>`: Scope for this rule. The scope and filter determine which clients match the rule.
      - `[AnonymousGid <String>]`: GID value that replaces 0 when rootSquash is true. This will use the value of anonymousUID if not provided.
      - `[AnonymousUid <String>]`: UID value that replaces 0 when rootSquash is true. 65534 will be used if not provided.
      - `[Filter <String>]`: Filter applied to the scope for this rule. The filter's format depends on its scope. 'default' scope matches all clients and has no filter value. 'network' scope takes a filter in CIDR format (for example, 10.99.1.0/24). 'host' takes an IP address or fully qualified domain name as filter. If a client does not match any filter rule and there is no default rule, access is denied.
      - `[RootSquash <Boolean?>]`: Map root accesses to anonymousUID and anonymousGID.
      - `[SubmountAccess <Boolean?>]`: For the default policy, allow access to subdirectories under the root export. If this is set to no, clients can only mount the path '/'. If set to yes, clients can mount a deeper path, like '/a/b'.
      - `[Suid <Boolean?>]`: Allow SUID semantics.
    - `Name <String>`: Name identifying this policy. Access Policy names are not case sensitive.
  - `[SizeGb <Int32?>]`: The size of this Cache, in GB.
  - `[SkuName <String>]`: SKU name for this Cache.
  - `[SourceVaultId <String>]`: Resource Id.
  - `[Subnet <String>]`: Subnet used for the Cache.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[Tag <ICacheTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

DIRECTORYSERVICESSETTING <ICacheDirectorySettings>: Specifies Directory Services settings of the cache.
  - `[ActiveDirectoryCacheNetBiosName <String>]`: The NetBIOS name to assign to the HPC Cache when it joins the Active Directory domain as a server. Length must 1-15 characters from the class [-0-9a-zA-Z].
  - `[ActiveDirectoryDomainName <String>]`: The fully qualified domain name of the Active Directory domain controller.
  - `[ActiveDirectoryDomainNetBiosName <String>]`: The Active Directory domain's NetBIOS name.
  - `[ActiveDirectoryPrimaryDnsIPAddress <String>]`: Primary DNS IP address used to resolve the Active Directory domain controller's fully qualified domain name.
  - `[ActiveDirectorySecondaryDnsIPAddress <String>]`: Secondary DNS IP address used to resolve the Active Directory domain controller's fully qualified domain name.
  - `[CredentialsBindDn <String>]`: The Bind Distinguished Name identity to be used in the secure LDAP connection. This value is stored encrypted and not returned on response.
  - `[CredentialsBindPassword <String>]`: The Bind password to be used in the secure LDAP connection. This value is stored encrypted and not returned on response.
  - `[CredentialsPassword <String>]`: Plain text password of the Active Directory domain administrator. This value is stored encrypted and not returned on response.
  - `[CredentialsUsername <String>]`: Username of the Active Directory domain administrator. This value is stored encrypted and not returned on response.
  - `[UsernameDownloadAutoDownloadCertificate <Boolean?>]`: Determines if the certificate should be automatically downloaded. This applies to 'caCertificateURI' only if 'requireValidCertificate' is true.
  - `[UsernameDownloadCaCertificateUri <String>]`: The URI of the CA certificate to validate the LDAP secure connection. This field must be populated when 'requireValidCertificate' is set to true.
  - `[UsernameDownloadEncryptLdapConnection <Boolean?>]`: Whether or not the LDAP connection should be encrypted.
  - `[UsernameDownloadExtendedGroup <Boolean?>]`: Whether or not Extended Groups is enabled.
  - `[UsernameDownloadGroupFileUri <String>]`: The URI of the file containing group information (in /etc/group file format). This field must be populated when 'usernameSource' is set to 'File'.
  - `[UsernameDownloadLdapBaseDn <String>]`: The base distinguished name for the LDAP domain.
  - `[UsernameDownloadLdapServer <String>]`: The fully qualified domain name or IP address of the LDAP server to use.
  - `[UsernameDownloadRequireValidCertificate <Boolean?>]`: Determines if the certificates must be validated by a certificate authority. When true, caCertificateURI must be provided.
  - `[UsernameDownloadUserFileUri <String>]`: The URI of the file containing user information (in /etc/passwd file format). This field must be populated when 'usernameSource' is set to 'File'.
  - `[UsernameDownloadUsernameSource <UsernameSource?>]`: This setting determines how the cache gets username and group names for clients.

SECURITYSETTINGACCESSPOLICY <INfsAccessPolicy[]>: NFS access policies defined for this cache.
  - `AccessRule <INfsAccessRule[]>`: The set of rules describing client accesses allowed under this policy.
    - `Access <NfsAccessRuleAccess>`: Access allowed by this rule.
    - `Scope <NfsAccessRuleScope>`: Scope for this rule. The scope and filter determine which clients match the rule.
    - `[AnonymousGid <String>]`: GID value that replaces 0 when rootSquash is true. This will use the value of anonymousUID if not provided.
    - `[AnonymousUid <String>]`: UID value that replaces 0 when rootSquash is true. 65534 will be used if not provided.
    - `[Filter <String>]`: Filter applied to the scope for this rule. The filter's format depends on its scope. 'default' scope matches all clients and has no filter value. 'network' scope takes a filter in CIDR format (for example, 10.99.1.0/24). 'host' takes an IP address or fully qualified domain name as filter. If a client does not match any filter rule and there is no default rule, access is denied.
    - `[RootSquash <Boolean?>]`: Map root accesses to anonymousUID and anonymousGID.
    - `[SubmountAccess <Boolean?>]`: For the default policy, allow access to subdirectories under the root export. If this is set to no, clients can only mount the path '/'. If set to yes, clients can mount a deeper path, like '/a/b'.
    - `[Suid <Boolean?>]`: Allow SUID semantics.
  - `Name <String>`: Name identifying this policy. Access Policy names are not case sensitive.

## RELATED LINKS

