### Example 1: Remove a custom certificate by its name
```powershell
Remove-AzWebPubSubCustomCertificate -Name mycustomcert -ResourceGroupName example-rg -ResourceName example-wps
```

```output
```



### Example 2: Remove a custom certificate by its identity
```powershell
$customCert = Get-AzWebPubSubCustomCertificate -Name mycustomcert -ResourceGroupName example-rg -ResourceName example-wps
$customCert | Remove-AzWebPubSubCustomCertificate
```

```output
```

