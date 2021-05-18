### Example 1: Delete a static site
```powershell
PS C:\> Remove-AzStaticWebApp -ResourceGroupName azure-rg-test -Name staticweb01

```

This command deletes a static site.

### Example 2: Delete a static site by pipeline
```powershell
PS C:\> Get-AzStaticWebApp -ResourceGroupName azure-rg-test -Name staticweb02 | Remove-AzStaticWebApp

```

This command deletes a static site by pipeline.

