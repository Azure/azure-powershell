### Example 1: Delete a static site build
```powershell
PS C:\> Remove-AzStaticWebAppBuild -ResourceGroupName azure-rg-test -Name staticweb-portal01 -EnvironmentName '2'

```

This command deletes a static site build.

### Example 2: Delete a static site build by pipeline
```powershell
PS C:\> Get-AzStaticWebAppBuild -ResourceGroupName azure-rg-test -Name staticweb-portal01 -EnvironmentName '3' | Remove-AzStaticWebAppBuild

```

This command deletes a static site build by pipeline.

