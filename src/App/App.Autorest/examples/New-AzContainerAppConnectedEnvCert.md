### Example 1: Create a Certificate.
```powershell
New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
Get-ChildItem -Path cert:\LocalMachine\My
$mypwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
Get-ChildItem -Path cert:\localMachine\my\F61C9A8C53D0500F819463A66C5921AA09E1B787 | Export-PfxCertificate -FilePath C:\mypfx.pfx -Password $mypwd

New-AzContainerAppConnectedEnvCert -Name azps-connectedenvcert -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Location eastus -InputFile "C:\mypfx.pfx" -Password $mypwd
```

```output
Name                  Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----                  -------- ------              ----------------- -----------         ----------                               -----------------
azps-connectedenvcert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com F61C9A8C53D0500F819463A66C5921AA09E1B787 azps_test_group_app
```

Create a Certificate.