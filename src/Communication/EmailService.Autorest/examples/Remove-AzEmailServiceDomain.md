### Example 1: Removes Email service custom domain.
```powershell
Remove-AzEmailServiceDomain -Name test.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

Removes Email service custom domain.

### Example 2: Removes Email service azure managed domain.
```powershell
Remove-AzEmailServiceDomain -Name AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

Removes Email service azure managed domain.

