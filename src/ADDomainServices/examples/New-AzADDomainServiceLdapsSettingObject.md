### Example 1: Create LdapsSetting for AzADDomain
```powershell
PS C:\> $secstr = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
New-AzADDomainServiceLdapsSettingObject -ExternalAccess Enabled -Ldaps Enabled -PfxCertificatePath sahg -PfxCertificatePassword $secstr

CertificateNotAfter CertificateThumbprint ExternalAccess Ldaps    PfxCertificate PfxCertificatePassword PublicCertificate
------------------- --------------------- -------------- ----    -------------- ---------------------- -----------------
                                          Enabled        Enabled                Password
```

Create LdapsSetting for AzADDomain

