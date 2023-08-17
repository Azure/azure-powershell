### Example 1: Remove a configuration of NGINX deployment by name
```powershell
Remove-AzNginxConfiguration -DeploymentName nginx-test -Name default -ResourceGroupName nginx-test-rg
```

This command removes a configuration of NGINX deployment by name

### Example 2: Remove a configuration of NGINX deployment by object
```powershell
Get-AzNginxConfiguration -DeploymentName nginx-test -Name default -ResourceGroupName nginx-test-rg | Remove-AzNginxConfiguration
```

This command removes a configuration of NGINX deployment by object

