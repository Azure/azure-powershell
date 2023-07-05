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