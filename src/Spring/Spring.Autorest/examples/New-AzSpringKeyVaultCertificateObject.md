### Example 1: Create an in-memory object for KeyVaultCertificateProperties.
```powershell
New-AzSpringKeyVaultCertificateObject -KeyVaultCertName  "mycert" -VaultUri "https://myvault.vault.azure.net" -CertVersion "xxxxxxxxxxxxxxxxxxx"
```

```output
ActivateDate      :
AutoSync          :
CertVersion       : xxxxxxxxxxxxxxxxxxx
DnsName           :
ExcludePrivateKey :
ExpirationDate    :
IssuedDate        :
Issuer            :
KeyVaultCertName  : mycert
ProvisioningState :
SubjectName       :
Thumbprint        :
Type              : KeyVaultCertificate
VaultUri          : https://myvault.vault.azure.net
```

Create an in-memory object for KeyVaultCertificateProperties.