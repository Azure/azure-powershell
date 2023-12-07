### Example 1: Create an in-memory object for UserManagedHttpsParameters
```powershell
New-AzCdnUserManagedHttpsParametersObject -CertificateSource certSource -CertificateSourceParameterResourceGroupName rgName -CertificateSourceParameterSecretName secretName -CertificateSourceParameterSubscriptionId subId -CertificateSourceParameterVaultName kvName -ProtocolType typeTest
```

```output
CertificateSource MinimumTlsVersion ProtocolType
----------------- ----------------- ------------
certSource                          typeTest
```

Create an in-memory object for UserManagedHttpsParameters