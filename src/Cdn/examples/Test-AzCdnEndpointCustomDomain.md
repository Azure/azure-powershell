### Example 1: Test an AzureCDN custom domain under the AzureCDN endpoint
```powershell
Test-AzCdnEndpointCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -HostName 'testcm.dev.cdn.azure.cn'
```

```output
CustomDomainValidated Message Reason
--------------------- ------- ------
True
```

Test an AzureCDN custom domain under the AzureCDN endpoint


### Example 2: Test an AzureCDN custom domain under the AzureCDN endpoint via identity
```powershell
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001 | Test-AzCdnEndpointCustomDomain -HostName 'testcm.dev.cdn.azure.cn'
```

Test an AzureCDN custom domain under the AzureCDN endpoint via identity
