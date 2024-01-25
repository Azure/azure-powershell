### Example 1: Delete the certificate resource
```powershell
Remove-AzSpringCloudCertificate -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -Name mycertificate
```

Delete the certificate resource.

### Example 2: Delete the certificate resource
```powershell
Get-AzSpringCloudCertificate -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -Name mycertificate | Remove-AzSpringCloudCertificate -InputObject $data
```

Delete the certificate resource.