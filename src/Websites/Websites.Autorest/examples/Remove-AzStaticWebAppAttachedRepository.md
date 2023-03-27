### Example 1: Remove repository of static site
```powershell
Remove-AzStaticWebAppAttachedRepository -ResourceGroupName azure-rg-test -Name staticweb-portal01

```

This command removes repository of static site.

### Example 2: Remove repository of static site by pipeline
```powershell
Get-AzStaticWebAppAttachedRepository -ResourceGroupName azure-rg-test -Name staticweb-portal01 | Remove-AzStaticWebAppAttachedRepository

```

This command removes repository of static site by pipeline.