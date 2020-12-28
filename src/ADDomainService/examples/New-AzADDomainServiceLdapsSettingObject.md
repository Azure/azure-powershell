### Example 1: Create LdapsSetting for AzADDomain
```powershell
PS C:\> $secstr = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
New-AzADDomainServiceLdapsSettingObject -ExternalAccess Enabled -Ldap Enabled -PfxCertificatePath sahg -PfxCertificatePassword $secstr

CertificateNotAfter CertificateThumbprint ExternalAccess Ldap    PfxCertificate PfxCertificatePassword PublicCertificate
------------------- --------------------- -------------- ----    -------------- ---------------------- -----------------
                                          Enabled        Enabled                Password
```

Create LdapsSetting for AzADDomain

