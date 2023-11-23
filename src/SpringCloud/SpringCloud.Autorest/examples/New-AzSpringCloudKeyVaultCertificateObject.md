### Example 1: Create an in-memory object for KeyVaultCertificateProperties
```powershell
New-AzSpringCloudKeyVaultCertificateObject -VaultUri "keyvaluturi" -Name 'keycert'
```

```output
ActivateDate DnsName ExpirationDate IssuedDate Issuer SubjectName Thumbprint CertVersion ExcludePrivateKey KeyVaultCertName VaultUri
------------ ------- -------------- ---------- ------ ----------- ---------- ----------- ----------------- ---------------- --------
                                                                                                           keycert          keyvaluturi
```

Create an in-memory object for KeyVaultCertificateProperties