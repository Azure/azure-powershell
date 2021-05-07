### Example 1: Resets the api key for an existing static site.
```powershell
PS C:\> Reset-AzStaticWebAppApiKey -ResourceGroupName azure-rg-test -Name staticweb-portal01

```

This command resets the api key for an existing static site.

### Example 2: Resets the api key for an existing static site by pipeline
```powershell
PS C:\> Get-AzStaticWebApp -ResourceGroupName azure-rg-test -Name staticweb-portal01 | Reset-AzStaticWebAppApiKey

```

This command resets the api key for an existing static site by pipeline.

