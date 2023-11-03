### Example 1: Create or Update a Certificate.
```powershell
New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
Get-ChildItem -Path cert:\LocalMachine\My
$mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText
Get-ChildItem -Path cert:\localMachine\my\5F98EBBFE735CDDAE00E33E0FD69050EF9220254 | Export-PfxCertificate -FilePath C:\mypfx.pfx -Password $mypwd

New-AzContainerAppManagedEnvCert -EnvName azps-env -Name azps-env-cert -ResourceGroupName azpstest_gp -Location canadacentral -InputFile "C:\mypfx.pfx" -Password $mypwd
```

```output
Name          Location      Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          --------      ------              ----------------- -----------         ----------                               -----------------
azps-env-cert canadacentral CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com 684DFA8457230B8A04675FBCB7251FA88AE10D80 azpstest_gp
```

Create or Update a Certificate.