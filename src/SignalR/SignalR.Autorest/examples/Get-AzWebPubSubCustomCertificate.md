### Example 1: List all the custom certificates of a Azure Web PubSub resource
```powershell
Get-AzWebPubSubCustomCertificate -ResourceGroupName rg -ResourceName wps
```

```output
Name         KeyVaultBaseUri                                  KeyVaultSecretName KeyVaultSecretVersion ProvisioningState
----         ---------------                                  ------------------ --------------------- -----------------
mycustomcert https://kvcustomcertificatetest.vault.azure.net/ manual-test                              Succeeded
```

We can see this Web PubSub resource only contains one custom certificate.

### Example 2: Get a custom certificate by its name
```powershell
Get-AzWebPubSubCustomCertificate -ResourceGroupName rg -ResourceName wps -Name mycustomcert
```

```output
Name         KeyVaultBaseUri                                  KeyVaultSecretName KeyVaultSecretVersion ProvisioningState
----         ---------------                                  ------------------ --------------------- -----------------
mycustomcert https://kvcustomcertificatetest.vault.azure.net/ manual-test                              Succeeded
```



### Example 3: Get a custom certificate by its identity
```powershell
$customCert = Get-AzWebPubSubCustomCertificate -ResourceGroupName rg -ResourceName wps -Name mycustomcert
$customCert | Get-AzWebPubSubCustomCertificate
```

```output
Name         KeyVaultBaseUri                                  KeyVaultSecretName KeyVaultSecretVersion ProvisioningState
----         ---------------                                  ------------------ --------------------- -----------------
mycustomcert https://kvcustomcertificatetest.vault.azure.net/ manual-test                              Succeeded
```


