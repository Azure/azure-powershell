### Example 1: Create an in-memory object for KeyVaultCertificateProperties.
```powershell
New-AzSpringKeyVaultCertificateObject -KeyVaultCertName  "mycert" -VaultUri "https://myvault.vault.azure.net" -CertVersion "08a219d06d874795a96db47e06fbb01e"
```

```output
ActivateDate      :
AutoSync          :
CertVersion       : 08a219d06d874795a96db47e06fbb01e
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