### Example 1: Update a custom certificate
```powershell
Update-AzWebPubSubCustomCertificate -Name mycustomcert -ResourceGroupName rg -ResourceName wps -KeyVaultBaseUri https://kvcustomcertificatetest.vault.azure.net/ -KeyVaultSecretName manual-test
```

```output
Name         KeyVaultBaseUri                                  KeyVaultSecretName KeyVaultSecretVersion ProvisioningState
----         ---------------                                  ------------------ --------------------- -----------------
mycustomcert https://kvcustomcertificatetest.vault.azure.net/ manual-test                              Succeeded
```

Update a custom certificate.