### Example 1: Create an in-memory object for AzureFrontDoor CustomerCertificateParameters
```powershell
$secretSourceId = "xxxxxxxx"
New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate" -SecretSourceId $secretSourceId               
```

```output
CertificateAuthority ExpirationDate SecretVersion Subject SubjectAlternativeName Thumbprint UseLatestVersion
-------------------- -------------- ------------- ------- ---------------------- ---------- ----------------
                                                          {}                                True
```

Create an in-memory object for AzureFrontDoor CustomerCertificateParameters