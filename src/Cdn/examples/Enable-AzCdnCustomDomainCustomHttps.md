### Example 1: Enable an AzureCDN custom domain under the AzureCDN endpoint
```powershell
$customDomainHttpsParameter = New-AzCdnManagedHttpsParametersObject -CertificateSourceParameterCertificateType Dedicated -CertificateSource Cdn  -ProtocolType TLS12
Enable-AzCdnCustomDomainCustomHttps -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -CustomDomainName customdomain001 -CustomDomainHttpsParameter $customDomainHttpsParameter
```

```output
Name            ResourceGroupName
----            -----------------
customdomain001 testps-rg-da16jm
```

Enable an AzureCDN custom domain under the AzureCDN endpoint



