### Example 1: Remove a certificate of NGINX deployment by name
```powershell
Remove-AzNginxCertificate -DeploymentName nginx-test -Name cert -ResourceGroupName nginx-test-rg
```

This command removes a certificate of NGINX deployment by name

### Example 2: Remove a certificate of NGINX deployment by object
```powershell
Get-AzNginxCertificate -DeploymentName nginx-test -Name cert -ResourceGroupName nginx-test-rg | Remove-AzNginxCertificate
```

This command remove a certificate of NGINX deployment by object
