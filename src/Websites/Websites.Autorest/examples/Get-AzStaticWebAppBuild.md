### Example 1: List all builds under a static web app
```powershell
Get-AzStaticWebAppBuild -ResourceGroupName azure-rg-test -Name staticweb-portal04
```
```output
Kind Name    Type
---- ----    ----
     default Microsoft.Web/staticSites/builds
```

This command list all builds under a static web app. Automaticall create a new build in static web app When creating a new pull request for branch.


### Example 2: Get the details of a static site build
```powershell
Get-AzStaticWebAppBuild -ResourceGroupName azure-rg-test -Name staticweb-portal04 -EnvironmentName 'default'
```
```output
Kind Name    Type
---- ----    ----
     default Microsoft.Web/staticSites/builds
```

This command gets the details of a static site build.

### Example 3: Get the details of a static site build pipeline
```powershell
Get-AzStaticWebAppBuild  -ResourceGroupName azure-rg-test -Name staticweb-portal04 | Get-AzStaticWebAppBuild
```
```output
Kind Name    Type
---- ----    ----
     default Microsoft.Web/staticSites/builds
```

This command gets the details of a static site build by pipeline.