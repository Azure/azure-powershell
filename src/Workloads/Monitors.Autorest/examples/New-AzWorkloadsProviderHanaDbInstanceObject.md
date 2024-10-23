### Example 1: Create SAP HANA provider 
```powershell
New-AzWorkloadsProviderHanaDbInstanceObject -Name SYSTEMDB -Password ''  -Username SYSTEM -Hostname 10.0.81.4 -InstanceNumber 00 -SapSid X00 -SqlPort 1433 -SslPreference Disabled
```

```output
ProviderType DbName   DbPassword DbPasswordUri DbUsername Hostname  InstanceNumber SapSid SqlPort SslCertificateUri SslHostNameInCer
                                                                                                                    tificate
------------ ------   ---------- ------------- ---------- --------  -------------- ------ ------- ----------------- ----------------
SapHana      SYSTEMDB                          SYSTEM     10.0.81.4 00             X00    1433
```

Create SAP HANA provider for an AMS instance
