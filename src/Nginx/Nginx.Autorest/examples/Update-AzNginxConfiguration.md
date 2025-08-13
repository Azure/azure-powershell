### Example 1: Update the Nginx configuration for given Nginx deployment
```powershell
Update-AzNginxConfiguration -DeploymentName nginx-test -Name default -ResourceGroupName nginx-test-rg -File $confFile -RootFile nginx.conf
```

```output
Location Name
-------- ----
         default
```

This command updates the Nginx configuration for given Nginx deployment.
