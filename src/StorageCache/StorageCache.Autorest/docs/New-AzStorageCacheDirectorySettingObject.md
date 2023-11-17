---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/Az.StorageCache/new-AzStorageCacheDirectorySettingObject
schema: 2.0.0
---

# New-AzStorageCacheDirectorySettingObject

## SYNOPSIS
Create an in-memory object for CacheDirectorySettings.

## SYNTAX

```
New-AzStorageCacheDirectorySettingObject [-ActiveDirectoryCacheNetBiosName <String>]
 [-ActiveDirectoryDomainName <String>] [-ActiveDirectoryDomainNetBiosName <String>]
 [-ActiveDirectoryPrimaryDnsIPAddress <String>] [-ActiveDirectorySecondaryDnsIPAddress <String>]
 [-CredentialsBindDn <String>] [-CredentialsBindPassword <String>] [-CredentialsPassword <String>]
 [-CredentialsUsername <String>] [-UsernameDownloadAutoDownloadCertificate <Boolean>]
 [-UsernameDownloadCaCertificateUri <String>] [-UsernameDownloadEncryptLdapConnection <Boolean>]
 [-UsernameDownloadExtendedGroup <Boolean>] [-UsernameDownloadGroupFileUri <String>]
 [-UsernameDownloadLdapBaseDn <String>] [-UsernameDownloadLdapServer <String>]
 [-UsernameDownloadRequireValidCertificate <Boolean>] [-UsernameDownloadUserFileUri <String>]
 [-UsernameDownloadUsernameSource <UsernameSource>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CacheDirectorySettings.

## EXAMPLES

### Example 1: Create an in-memory object for CacheDirectorySettings.
```powershell
New-AzStorageCacheDirectorySettingObject -ActiveDirectoryCacheNetBiosName "contosoSmb" -ActiveDirectoryDomainName "contosoAd.contoso.local" -ActiveDirectoryDomainNetBiosName "contosoAd" -ActiveDirectoryPrimaryDnsIPAddress "192.0.2.10" -ActiveDirectorySecondaryDnsIPAddress "192.0.2.11" -CredentialsBindDn "cn=ldapadmin,dc=contosoad,dc=contoso,dc=local" -CredentialsBindPassword "<bindPassword>" -CredentialsPassword "<password>" -CredentialsUsername "consotoAdmin" -UsernameDownloadCaCertificateUri "http://contoso.net/cacert.pem" -UsernameDownloadAutoDownloadCertificate:$False -UsernameDownloadEncryptLdapConnection:$False -UsernameDownloadExtendedGroup:$False -UsernameDownloadGroupFileUri "http://contoso.net/group.file" -UsernameDownloadLdapBaseDn "dc=contosoad,dc=contoso,dc=local" -UsernameDownloadLdapServer "192.0.2.12" -UsernameDownloadRequireValidCertificate:$False -UsernameDownloadUsernameSource 'LDAP' -UsernameDownloadUserFileUri "http://contoso.net/passwd.file"
```

```output
ActiveDirectoryCacheNetBiosName         : contosoSmb
ActiveDirectoryDomainJoined             :
ActiveDirectoryDomainName               : contosoAd.contoso.local
ActiveDirectoryDomainNetBiosName        : contosoAd
ActiveDirectoryPrimaryDnsIPAddress      : 192.0.2.10
ActiveDirectorySecondaryDnsIPAddress    : 192.0.2.11
CredentialsBindDn                       : cn=ldapadmin,dc=contosoad,dc=contoso,dc=local
CredentialsBindPassword                 : <bindPassword>
CredentialsPassword                     : <password>
CredentialsUsername                     : consotoAdmin
UsernameDownloadAutoDownloadCertificate : False
UsernameDownloadCaCertificateUri        : http://contoso.net/cacert.pem
UsernameDownloadEncryptLdapConnection   : False
UsernameDownloadExtendedGroup           : False
UsernameDownloadGroupFileUri            : http://contoso.net/group.file
UsernameDownloadLdapBaseDn              : dc=contosoad,dc=contoso,dc=local
UsernameDownloadLdapServer              : 192.0.2.12
UsernameDownloadRequireValidCertificate : False
UsernameDownloadUserFileUri             : http://contoso.net/passwd.file
UsernameDownloadUsernameDownloaded      :
UsernameDownloadUsernameSource          : LDAP
```

Create an in-memory object for CacheDirectorySettings.

## PARAMETERS

### -ActiveDirectoryCacheNetBiosName
The NetBIOS name to assign to the HPC Cache when it joins the Active Directory domain as a server.
Length must 1-15 characters from the class [-0-9a-zA-Z].

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

### -ActiveDirectoryDomainName
The fully qualified domain name of the Active Directory domain controller.

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

### -ActiveDirectoryDomainNetBiosName
The Active Directory domain's NetBIOS name.

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

### -ActiveDirectoryPrimaryDnsIPAddress
Primary DNS IP address used to resolve the Active Directory domain controller's fully qualified domain name.

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

### -ActiveDirectorySecondaryDnsIPAddress
Secondary DNS IP address used to resolve the Active Directory domain controller's fully qualified domain name.

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

### -CredentialsBindDn
The Bind Distinguished Name identity to be used in the secure LDAP connection.
This value is stored encrypted and not returned on response.

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

### -CredentialsBindPassword
The Bind password to be used in the secure LDAP connection.
This value is stored encrypted and not returned on response.

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

### -CredentialsPassword
Plain text password of the Active Directory domain administrator.
This value is stored encrypted and not returned on response.

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

### -CredentialsUsername
Username of the Active Directory domain administrator.
This value is stored encrypted and not returned on response.

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

### -UsernameDownloadAutoDownloadCertificate
Determines if the certificate should be automatically downloaded.
This applies to 'caCertificateURI' only if 'requireValidCertificate' is true.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsernameDownloadCaCertificateUri
The URI of the CA certificate to validate the LDAP secure connection.
This field must be populated when 'requireValidCertificate' is set to true.

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

### -UsernameDownloadEncryptLdapConnection
Whether or not the LDAP connection should be encrypted.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsernameDownloadExtendedGroup
Whether or not Extended Groups is enabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsernameDownloadGroupFileUri
The URI of the file containing group information (in /etc/group file format).
This field must be populated when 'usernameSource' is set to 'File'.

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

### -UsernameDownloadLdapBaseDn
The base distinguished name for the LDAP domain.

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

### -UsernameDownloadLdapServer
The fully qualified domain name or IP address of the LDAP server to use.

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

### -UsernameDownloadRequireValidCertificate
Determines if the certificates must be validated by a certificate authority.
When true, caCertificateURI must be provided.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsernameDownloadUserFileUri
The URI of the file containing user information (in /etc/passwd file format).
This field must be populated when 'usernameSource' is set to 'File'.

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

### -UsernameDownloadUsernameSource
This setting determines how the cache gets username and group names for clients.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Support.UsernameSource
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.CacheDirectorySettings

## NOTES

ALIASES

## RELATED LINKS

