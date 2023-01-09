### Example 1: Create an in-memory object for AzureCDN CdnManagedHttpsParameters
```powershell
New-AzCdnManagedHttpsParametersObject -CertificateSourceParameterCertificateType Dedicated -CertificateSource Cdn -ProtocolType ServerNameIndication
```

```output
CertificateSource MinimumTlsVersion ProtocolType
----------------- ----------------- ------------
Cdn                                 TLS12
```

Create an in-memory object for AzureCDN CdnManagedHttpsParameters

