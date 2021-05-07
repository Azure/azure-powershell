### Example 1: Deletes a custom domain
```powershell
PS C:\> Remove-AzStaticWebAppCustomDomain -ResourceGroupName resourceGroup -Name staticweb00 -DomainName domainName

```

This command deletes a custom domain.

### Example 2: Deletes a custom domain by pipeline
```powershell
PS C:\> Get-AzStaticWebAppCustomDomain -ResourceGroupName resourceGroup -Name staticweb00 -DomainName domainName | Remove-AzStaticWebAppCustomDomain

```

This command deletes a custom domain by pipeline.

