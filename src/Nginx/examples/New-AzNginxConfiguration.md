### Example 1: Create or update the Nginx configuration for given Nginx deployment
```powershell
New-AzNginxConfiguration -DeploymentName nginx-test -Name default -ResourceGroupName nginx-test-rg -File $confFile -RootFile nginx.conf
```

```output
Location Name
-------- ----
         default
```

This command creates or updates the Nginx configuration for given Nginx deployment.
