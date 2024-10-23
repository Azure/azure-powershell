### Example 1: Analyzing nginx configuration before creating the nginx configuration
```powershell
$confFile = New-AzNginxConfigurationFileObject -VirtualPath "nginx.conf" -Content 'xxxx'
        
# configuration analysis
$confAnalysis = Invoke-AzNginxAnalysisConfiguration -ConfigurationName default -DeploymentName xxxx -ResourceGroupName xxxx -ConfigFile $confFile -ConfigRootFile "nginx.conf"
```

```output
Status
------
SUCCEEDED
```

This command analyzes the configuration before you submit to create your configuration for your nginx deployment