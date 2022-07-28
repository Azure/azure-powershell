### Example 1: Create or update certificate resource
```powershell
$cert = New-AzSpringCloudKeyVaultCertificatePropertiesObject -Name "cert01" -Type "KeyVaultCertificate" -VaultUri "https://xxxxxx.vault.azure.net" -Version "xxxxxxxxxxxxxxxxxxxxx" -ExcludePrivateKey $false
New-AzSpringCloudCertificate -ResourceGroupName lucas-rg-test -ServiceName springapp-pwsh01 -Name cert01 -Property $cert
```

```output
Name   ResourceGroupName
----   -----------------
cert01 lucas-rg-test
```

Create or update certificate resource.