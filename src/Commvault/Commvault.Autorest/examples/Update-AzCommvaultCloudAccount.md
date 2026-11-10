### Example 1: Update the tags of a cloud account
```powershell
Update-AzCommvaultCloudAccount -ResourceGroupName rg-commvault -Name cca-contoso -Tag @{ Environment = 'Production' }
```

Updates the tags of the cloud account.

### Example 2: Update the company details of a cloud account
```powershell
Update-AzCommvaultCloudAccount -ResourceGroupName rg-commvault -Name cca-contoso -CompanyName 'Contoso' -CompanyJobTitle 'Backup Operator' -CompanyCity 'Redmond' -CompanyState 'WA' -CompanyCountry 'USA' -CompanyPostalCode '98052'
```

Updates the company details of the cloud account.

