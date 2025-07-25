### Example 1: Removes Email service custom domain sender username resource.
```powershell
Remove-AzEmailServiceSenderUsername -SenderUsername test -DomainName testcustomdomain1.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

Removes Email service custom domain sender username resource.

### Example 2: Removes Email service azure managed domain sender username resource.
```powershell
Remove-AzEmailServiceSenderUsername -SenderUsername test -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

Removes Email service azure managed domain sender username resource.

