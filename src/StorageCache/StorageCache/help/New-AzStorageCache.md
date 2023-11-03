---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/new-azstoragecache
schema: 2.0.0
---

# New-AzStorageCache

## SYNOPSIS
Create or update a cache.

## SYNTAX

```
New-AzStorageCache -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-CacheSizeGb <Int32>] [-DirectoryServicesSetting <ICacheDirectorySettings>]
 [-EncryptionSettingRotationToLatestKeyVersionEnabled] [-IdentityType <CacheIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-KeyEncryptionKeyUrl <String>] [-Location <String>]
 [-NetworkSettingDnsSearchDomain <String>] [-NetworkSettingDnsServer <String[]>] [-NetworkSettingMtu <Int32>]
 [-NetworkSettingNtpServer <String>] [-SecuritySettingAccessPolicy <INfsAccessPolicy[]>] [-SkuName <String>]
 [-SourceVaultId <String>] [-Subnet <String>] [-Tag <Hashtable>] [-UpgradeSettingScheduledTime <DateTime>]
 [-UpgradeSettingUpgradeScheduleEnabled] [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a cache.

## EXAMPLES

### Example 1: Create or update a cache.
```powershell
New-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache -Location eastus -CacheSizeGb "3072" -Subnet "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache_2/providers/Microsoft.Network/virtualNetworks/azps-virtual-network/subnets/default" -SkuName "Standard_2G" -Zone 1
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

Create or update a cache.

### Example 2: Create or update a cache.
```powershell
New-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache -IdentityType 'UserAssigned' -IdentityUserAssignedIdentity @{"/subscriptions/{subId}/resourcegroups/azps_test_gp_storagecache/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-management-identity" = @{}} -KeyEncryptionKeyUrl "https://azps-keyvault.vault.azure.net/keys/azps-kv/4cc795e46f114ce2a65b82b312964e0e" -SourceVaultId "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.KeyVault/vaults/azps-keyvault" -Location eastus -CacheSizeGb "3072" -Subnet "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Network/virtualNetworks/azps-virtual-network/subnets/default" -SkuName "Standard_2G" -Zone 1
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

Create or update a cache.

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

### -CacheSizeGb
The size of this Cache, in GB.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.ICacheDirectorySettings
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionSettingRotationToLatestKeyVersionEnabled
Specifies whether the service will automatically rotate to the newest version of the key in the key vault.

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

### -IdentityType
The type of identity used for the cache

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Support.CacheIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
A dictionary where each key is a user assigned identity resource ID, and each key's value is an empty dictionary.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyEncryptionKeyUrl
The URL referencing a key encryption key in key vault.

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

### -Location
Region name string.

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

### -Name
Name of cache.
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

### -NetworkSettingDnsSearchDomain
DNS search domain

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

### -NetworkSettingDnsServer
DNS servers for the cache to use.
It will be set from the network configuration if no value is provided.

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

### -NetworkSettingMtu
The IPv4 maximum transmission unit configured for the subnet.

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

### -NetworkSettingNtpServer
NTP server IP Address or FQDN for the cache to use.
The default is time.windows.com.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.INfsAccessPolicy[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
SKU name for this cache.

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

### -SourceVaultId
Resource Id.

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

### -Subnet
Subnet used for the cache.

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

### -SubscriptionId
The ID of the target subscription.

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeSettingScheduledTime
When upgradeScheduleEnabled is true, this field holds the user-chosen upgrade time.
At the user-chosen time, the firmware update will automatically be installed on the cache.

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

### -UpgradeSettingUpgradeScheduleEnabled
True if the user chooses to select an installation time between now and firmwareUpdateDeadline.
Else the firmware will automatically be installed after firmwareUpdateDeadline if not triggered earlier via the upgrade operation.

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

### -Zone
Availability zones for resources.
This field should only contain a single element in the array.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.ICache

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`DIRECTORYSERVICESSETTING <ICacheDirectorySettings>`: Specifies Directory Services settings of the cache.
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

`SECURITYSETTINGACCESSPOLICY <INfsAccessPolicy[]>`: NFS access policies defined for this cache.
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

