### Example 1: Create an IBM Db2 Provider
```powershell
New-AzWorkloadsProviderDB2InstanceObject -Name Sample -Password '' -Port 25000 -Username db2admin -Hostname 10.1.21.4 -SapSid OPA -SslPreference Disabled
```

```output
ProviderType DbName DbPassword DbPasswordUri DbPort DbUsername Hostname  SapSid SslCertificateUri SslPreference
------------ ------ ---------- ------------- ------ ---------- --------  ------ ----------------- -------------
Db2          Sample                          25000  db2admin   10.1.21.4 OPA                      Disabled
```

Create an IBM Db2 provider for an AMS Instance
