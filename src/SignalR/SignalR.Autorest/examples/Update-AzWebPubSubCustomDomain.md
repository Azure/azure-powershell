### Example 1: Update a custom domain
```powershell
$cert = Get-AzWebPubSubCustomCertificate -Name mycustomcert -ResourceGroupName rg -ResourceName wps
Update-AzWebPubSubCustomDomain -Name mydomain -ResourceGroupName rg -ResourceName wps -DomainName wps.manual-test.dev.signalr.azure.com -CustomCertificateId $cert.Id
```

```output
Name     DomainName                                    ProvisioningState
----     ----------                                    -----------------
mydomain wps.manual-test.dev.signalr.azure.com Succeeded
```

Update a custom domain.