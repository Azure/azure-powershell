### Example 1: Delete an AzureCDN custom domain under the AzureCDN endpoint
```powershell
Remove-AzCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name customdomain001
```

Delete an AzureCDN custom domain under the AzureCDN endpoint

### Example 2: Delete an AzureCDN custom domain under the AzureCDN endpoint via identity
```powershell
Get-AzCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name customdomain001 | Remove-AzCdnCustomDomain
```

Delete an AzureCDN custom domain under the AzureCDN endpoint via identity