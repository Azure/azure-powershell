### Example 1: Delete the certificate resource
```powershell
Remove-AzSpringCertificate -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -Name mycertificate
```

```output
```

Delete the certificate resource.

### Example 2: Delete the certificate resource
```powershell
Get-AzSpringCertificate -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -Name mycertificate | Remove-AzSpringCertificate -InputObject $data
```

```output
```

Delete the certificate resource.

