### Example 1: Delete a custom domain
```powershell
Remove-AzStaticWebAppCustomDomain -ResourceGroupName resourceGroup -Name staticweb00 -DomainName domainName

```

This command deletes a custom domain.

### Example 2: Delete a custom domain by pipeline
```powershell
Get-AzStaticWebAppCustomDomain -ResourceGroupName resourceGroup -Name staticweb00 -DomainName domainName | Remove-AzStaticWebAppCustomDomain

```

This command deletes a custom domain by pipeline.