### Example 1: List all certificates under a NGINX deployment
```powershell
Get-AzNginxCertificate -DeploymentName nginx-test -ResourceGroupName nginx-test-rg
```

```output
Location      Name
--------      ----
westcentralus cert
westcentralus cert1
```

This command lists all certificates under a NGINX deployment.

### Example 2: Get a certificate
```powershell
Get-AzNginxCertificate -DeploymentName nginx-test -Name cert -ResourceGroupName nginx-test-rg
```

```output
Location      Name
--------      ----
westcentralus cert
```

This command gets a certificate.
