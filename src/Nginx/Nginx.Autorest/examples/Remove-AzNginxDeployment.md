### Example 1: Remove a NGINX deployment by name
```powershell
Remove-AzNginxDeployment -Name nginx-test -ResourceGroupName nginx-test-rg
```

This command removes a deployment by name

### Example 2: Remove a NGINX deployment by object
```powershell
Get-AzNginxDeployment -Name nginx-test -ResourceGroupName nginx-test-rg | Remove-AzNginxDeployment
```

This command removes a NGINX deployment by object
