### Example 1: Create or update certificate resource
```powershell
$cert = New-AzSpringKeyVaultCertificateObject -Name "cert01" -VaultUri "https://xxxxxx.vault.azure.net" -Version "xxxxxxxxxxxxxxxxxxxxx" -ExcludePrivateKey $false
New-AzSpringCertificate -ResourceGroupName spring-rg-test -ServiceName springapp-pwsh01 -Name cert01 -Property $cert
```

```output
Name   ResourceGroupName
----   -----------------
cert01 lucas-rg-test
```

Create or update certificate resource.