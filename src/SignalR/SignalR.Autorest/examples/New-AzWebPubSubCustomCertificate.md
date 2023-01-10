### Example 1: Create or update a custom certificate
```powershell
New-AzWebPubSubCustomCertificate -Name mycustomcert -ResourceGroupName rg -ResourceName wps -KeyVaultBaseUri https://kvcustomcertificatetest.vault.azure.net/ -KeyVaultSecretName manual-test
```

```output
Name         KeyVaultBaseUri                                  KeyVaultSecretName KeyVaultSecretVersion ProvisioningState
----         ---------------                                  ------------------ --------------------- -----------------
mycustomcert https://kvcustomcertificatetest.vault.azure.net/ manual-test                              Succeeded
```

